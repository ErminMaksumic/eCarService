using AutoMapper;
using eCarService.Model.SearchObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using eCarService.Model.Requests;
using eCarService.Service.Interfaces;
using eCarService.Model.Helpers;
using eCarService.Database;

namespace eCarService.Service.Implementation
{
    public class UserService : CRUDService<Model.User, UserSearchObject, Database.User, UserInsertRequest, UserUpdateRequest>,
        IUserService
    {
        public UserService(eCarServiceContext context, IMapper mapper) : base(context, mapper)
        {}

        public override IQueryable<User> AddFilter(IQueryable<User> query, UserSearchObject searchObject = null)
        {
            var filteredQuery = base.AddFilter(query, searchObject);

            if (!string.IsNullOrWhiteSpace(searchObject.UserName))
            {
                filteredQuery = filteredQuery.Where(x => x.UserName.StartsWith(searchObject.UserName));
            }
            if (!string.IsNullOrWhiteSpace(searchObject.FullName))
            {
                filteredQuery = filteredQuery.Where(x => (x.FirstName + " " + x.LastName)
                .StartsWith(searchObject.FullName));
            }

            return filteredQuery;
        }

        public override IQueryable<User> AddInclude(IQueryable<User> query, UserSearchObject searchObject = null)
        {
            var includedQuery = base.AddInclude(query, searchObject);

            if (searchObject.IncludeRoles)
            {
                includedQuery = includedQuery.Include("UserRole.Role");
            }

            return includedQuery;
        }

        public override void BeforeInsert(UserInsertRequest request, User entity)
        {

            entity.PasswordSalt = GenerateSalt();

            var hash = GenerateHash(entity.PasswordSalt, request.Password);

            entity.PasswordHash = hash;

            base.BeforeInsert(request, entity);
        }


        public override void BeforeDelete(User entity)
        {

            if(entity?.Role?.Name == "Administrator")
            {
                throw new UserException("You cannot delete Administrator's account");
            }

            var data = _context.CarServices.Where(x => x.UserId == entity.UserId).FirstOrDefault();

            if(data!=null)
            {
                data.UserId = null;
                _context.SaveChanges();
            }
        }


        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);


            return Convert.ToBase64String(byteArray);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);

            byte[] bytes = Encoding.Unicode.GetBytes(password);

            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }


        public override Model.User Insert(UserInsertRequest request)
        {
          
                if (request != null)
                {

                    if (_context.Users.Where(a => a.UserName == request.UserName).Any())
                    {
                        throw new UserException("User with that username already exists!");
                    }
                    if (request.Password != request.PasswordConfirmation)
                    {
                        throw new UserException("The two password fields didn't match");
                    }

                    var newUser = _mapper.Map<User>(request);

                    newUser.PasswordSalt = GenerateSalt();

                    newUser.PasswordHash = GenerateHash(newUser.PasswordSalt, request.Password);


                    _context.Users.Add(newUser);
                    _context.SaveChanges();

                    return _mapper.Map<Model.User>(newUser);
                }
                    return null;
        }

        public Model.User Login(string username, string password)
        {
            var entity = _context.Users.Include("Role").
                FirstOrDefault(x => x.UserName == username);

            if (entity == null)
            {
                return null;
            }

            var hash = GenerateHash(entity.PasswordSalt, password);

            if (hash != entity.PasswordHash)
            {
                return null;
            }

            return _mapper.Map<Model.User>(entity);
        }

        public override void BeforeUpdate(User entity, UserUpdateRequest request)
        {
            if (request.Password != request.PasswordConfirmation)
            {
                throw new UserException("The two password fields didn't match");
            }

            //  save old pass
            if (string.IsNullOrWhiteSpace(request.Password) || request.Password == null)
            {
                var salt = GenerateSalt();
                var hash = GenerateHash(salt, entity.PasswordHash);
                request.Password = hash;
            }
            // password is in the request
            else
            {
                entity.PasswordSalt = GenerateSalt();
                entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);
            }
        }

        public Model.User ChangePassword(int id, MyProfileUpdateRequest req)
        {
            var entity = _context.Users.Find(id);

            if(entity!=null)
            {
                entity.PasswordSalt = GenerateSalt();
                entity.PasswordHash = GenerateHash(entity.PasswordSalt, req.Password);
                entity.Image = req.Image;
            };

            _context.SaveChanges();

            return _mapper.Map<Model.User>(entity);
        }

        public Model.User ChangeRole(int id, int roleId)
        {
            var entity = _context.Users.Find(id);

            if (entity != null)
            {
                entity.RoleId = roleId;
            }
            _context.SaveChanges();

            return _mapper.Map<Model.User>(entity);
        }
    }
}

