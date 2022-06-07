using AutoMapper;
using eCarService.Database;
using eCarService.Model.SearchObjects;
using eCarService.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.Service.Implementation
{
    public class CRUDService<TModel, TSearch, TDatabase, TInsert, TUpdate> : BaseService<TModel, TDatabase, TSearch>, 
        ICRUDService<TModel, TSearch, TInsert, TUpdate> where TModel : class where TSearch : BaseSearchObject
        where TInsert : class where TDatabase: class where TUpdate: class
    {
        public CRUDService(eCarServiceContext context, IMapper mapper) : base(context, mapper)
        { }
        public virtual TModel Insert(TInsert request)
        {
            var set = _context.Set<TDatabase>();

            TDatabase entity = _mapper.Map<TDatabase>(request);

            set.Add(entity);

            BeforeInsert(request, entity);

            _context.SaveChanges();

            return _mapper.Map<TModel>(entity);
        }

        public virtual TModel Update(int id, TUpdate request)
        {
            var set = _context.Set<TDatabase>();

            var entity = set.Find(id);

            BeforeUpdate(entity, request);

            if (entity != null)
            {
                _mapper.Map(request, entity);
            }
            else
            {
                return null;
            }

            _context.SaveChanges();

            return _mapper.Map<TModel>(entity);
        }
        public virtual TModel Delete(int id)
        {

            var set = _context.Set<TDatabase>();

            var entity = set.Find(id);

            if (entity != null)
            {

                BeforeDelete(entity);
                set.Remove(entity);

                _context.SaveChanges();
            }

            return _mapper.Map<TModel>(entity);
        }

        public virtual void BeforeInsert(TInsert insert, TDatabase entity)
        {}

        public virtual void BeforeDelete(TDatabase entity)
        { }

        public virtual void BeforeUpdate(TDatabase entity, TUpdate request)
        {}

    }

}
