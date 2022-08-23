using AutoMapper;
using eCarService.Database;
using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using eCarService.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.Service.Implementation
{
    public class PaymentService : CRUDService<Model.Payment, BaseSearchObject, Database.Payment,
        PaymentUpsertRequest, PaymentUpsertRequest>, IPaymentService
    {
        public PaymentService(eCarServiceContext context, IMapper mapper) : base(context, mapper)
        { }
    }
}
