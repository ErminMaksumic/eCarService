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
    public interface IUserService : ICRUDService<Model.User, UserSearchObject, UserInsertRequest, UserUpdateRequest>
    {
        User Login(string username, string password);
        User ChangePassword(int id, MyProfileUpdateRequest req);
        User ChangeRole(int id, int roleId);
        User BaseUpdate(int id, BasicUserUpdateRequest request);


    }
}
