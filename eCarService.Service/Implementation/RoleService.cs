﻿using AutoMapper;
using eCarService.Database;
using eCarService.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.Service.Implementation
{
    public class RoleService : BaseService<Model.Role, Database.Role, BaseSearchObject>
    {
        public RoleService(eCarServiceContext context, IMapper mapper) : base(context, mapper)
        {}
    }
}
