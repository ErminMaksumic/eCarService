﻿using eCarService.Model.Requests;
using eCarService.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.Service.Interfaces
{
    public interface IRatingService : ICRUDService<Model.Rating, RatingSearchObject, RatingUpsertRequest, 
        RatingUpsertRequest>
    {}
}
