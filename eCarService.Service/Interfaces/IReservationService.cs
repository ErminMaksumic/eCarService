﻿using eCarService.Model;
using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.Service.Interfaces
{
    public interface IReservationService : ICRUDService<Model.Reservation, OrderSearchObject, 
        ReservationInsertRequest,ReservationInsertRequest>
    {
        Reservation ChangeStatus(int id, string status);
    }
}
