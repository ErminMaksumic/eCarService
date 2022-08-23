using eCarService.Database;
using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.Service.Interfaces
{
    public interface IPaymentService: ICRUDService<Model.Payment, BaseSearchObject,
        PaymentUpsertRequest, PaymentUpsertRequest>
    {
    }
}
