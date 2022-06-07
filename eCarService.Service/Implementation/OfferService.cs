using AutoMapper;
using eCarService.Database;
using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using eCarService.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.Service.Implementation
{
    public class OfferService : CRUDService<Model.Offer, OfferSearchObject, Database.Offer, OfferInsertRequest,
        OfferInsertRequest>, IOfferService
    {
        public OfferService(eCarServiceContext context, IMapper mapper) : base(context, mapper)
        { }

        public override Model.Offer Insert(OfferInsertRequest request)
        {
            Offer offer = new Offer()
            {
                Name = request.Name,
                CarServiceId = request.CarServiceId,
                Price = request.Price,
                Status = request.Status
            };

            _context.Offers.Add(offer);
            _context.SaveChanges();

            foreach (var brand in request.Brands)
            {
                Database.CarBrandOffer carBrandOffer = new CarBrandOffer();
                carBrandOffer.CarBrandId = brand;
                carBrandOffer.OfferId = offer.OfferId;

                _context.CarBrandOffers.Add(carBrandOffer);

                _context.SaveChanges();
            }

            return _mapper.Map<Model.Offer>(offer);
        }

        public override Model.Offer GetById(int id)
        {
            var entity = _context.Offers.Include("CarBrandOffers").Include("CarBrandOffers.CarBrand").FirstOrDefault(x => x.OfferId == id);

            return _mapper.Map<Model.Offer>(entity);
        }
    }
}
