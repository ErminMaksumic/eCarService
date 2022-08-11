using AutoMapper;
using eCarService.Database;
using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using eCarService.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.Service.Implementation
{
        public class AdditionalServiceService : CRUDService<Model.AdditionalService, AdditionalServiceSearchObject,
        Database.AdditionalService, AdditionalServiceUpsertRequest, AdditionalServiceUpsertRequest>, 
        IAdditionalServiceService
    {
        public readonly eCarServiceContext _context;

        public AdditionalServiceService(eCarServiceContext context, IMapper mapper) : base(context, mapper)
        {
            this._context = context;
        }

        public override IQueryable<AdditionalService> AddFilter(IQueryable<AdditionalService> query, AdditionalServiceSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if(!string.IsNullOrWhiteSpace(search.Name))
            {
                filteredQuery = filteredQuery.Where(x => x.Name.StartsWith(search.Name));
            }

            return filteredQuery;
        }

        static object isLocked = new object();
        static MLContext mlContext = null;
        static ITransformer model = null;
        private readonly eCarServiceContext context;

        public async Task<List<Model.AdditionalService>> Recommend(int id)
        {
            trainData();

            var finalResult = preditctItems(id);

            return _mapper.Map<List<Model.AdditionalService>>(finalResult);
        }

        private void trainData()
        {
            lock (isLocked)
            {
                if (mlContext == null)
                {
                    mlContext = new MLContext();

                    var tmpData = _context.Reservations.Include("ReservationsAdditionalServices").ToList();

                    var data = new List<ProductEntry>();

                    foreach (var x in tmpData)
                    {
                        if (x.ReservationsAdditionalServices.Count > 1)
                        {
                            var distinctItemId = x.ReservationsAdditionalServices.Select(y => y.AdditionalServiceId).ToList();

                            distinctItemId.ForEach(y =>
                            {
                                var relatedItems = x.ReservationsAdditionalServices.Where(z => z.AdditionalServiceId != y);

                                foreach (var z in relatedItems)
                                {
                                    data.Add(new ProductEntry()
                                    {
                                        ProductID = (uint)y,
                                        CoPurchaseProductID = (uint)z.AdditionalServiceId,
                                    });
                                }
                            });
                        }
                    }

                    var disctintData = data.Select(y => new
                    {
                        ProductID = y.ProductID,
                        CoPurchaseProductID = y.CoPurchaseProductID,
                    }).Distinct();

                    var productEntries = new List<ProductEntry>();

                    foreach (var item in disctintData)
                    {
                        productEntries.Add(new ProductEntry()
                        {
                            ProductID = item.ProductID,
                            CoPurchaseProductID = item.CoPurchaseProductID,
                            Label = 0
                        });
                    }

                    var traindata = mlContext.Data.LoadFromEnumerable(productEntries);


                    //STEP 3: Your data is already encoded so all you need to do is specify options for MatrxiFactorizationTrainer with a few extra hyperparameters
                    //        LossFunction, Alpa, Lambda and a few others like K and C as shown below and call the trainer.
                    MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                    options.MatrixColumnIndexColumnName = nameof(ProductEntry.ProductID);
                    options.MatrixRowIndexColumnName = nameof(ProductEntry.CoPurchaseProductID);
                    options.LabelColumnName = "Label";
                    options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
                    options.Alpha = 0.01;
                    options.Lambda = 0.025;
                    // For better results use the following parameters
                    options.NumberOfIterations = 100;
                    options.C = 0.00001;


                    var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

                    model = est.Fit(traindata);
                }

            }
        }
        private List<Database.AdditionalService> preditctItems(int id)
        {
            List<Database.AdditionalService> allItems = new List<Database.AdditionalService>();

            for (int i = 0; i < 1000; i++)
            {
                var tmp = _context.AdditionalServices.Where(x => x.AdditionalServiceId != id);

                allItems.AddRange(tmp);
            }


            var predictionResult = new List<Tuple<Database.AdditionalService, float>>();

            foreach (var item in allItems)
            {
                var predictionEngine = mlContext.Model.CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);
                var prediction = predictionEngine.Predict(new ProductEntry()
                {
                    ProductID = (uint)id,
                    CoPurchaseProductID = (uint)item.AdditionalServiceId
                });

                predictionResult.Add(new Tuple<Database.AdditionalService, float>(item, prediction.Score));
            }

            return predictionResult.OrderByDescending(x => x.Item2).Distinct()
                .Select(x => x.Item1).Take(3).ToList();
        }

    }
    public class Copurchase_prediction
    {
        public float Score { get; set; }
    }

    public class ProductEntry
    {
        [KeyType(count: 500)]
        public uint ProductID { get; set; }

        [KeyType(count: 500)]
        public uint CoPurchaseProductID { get; set; }

        public float Label { get; set; }
    }
}

