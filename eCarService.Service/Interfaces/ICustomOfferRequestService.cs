using eCarService.Model;
using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.Service.Interfaces
{
    public interface ICustomOfferRequestService : ICRUDService<Model.CustomOfferRequest, CustomOfferSearchObject,
        CustomOfferUpsertRequest, CustomOfferUpsertRequest>
    {
        CustomOfferRequest ChangeStatus(int id, string status);
    }
}
