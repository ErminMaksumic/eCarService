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
    public class BaseService<TModel, TDatabase, TSearch>: IBaseService<TModel, TSearch> where TModel: class
        where TDatabase : class where TSearch : BaseSearchObject
    {
        public readonly eCarServiceContext _context;
        public readonly IMapper _mapper;

        public BaseService(eCarServiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual IQueryable<TDatabase> AddFilter(IQueryable<TDatabase> query, TSearch search = null)
        {
            return query;
        }

        public virtual IQueryable<TDatabase> AddInclude(IQueryable<TDatabase> query, TSearch search = null)
        {
            return query;
        }

        public virtual async Task<IEnumerable<TModel>> Get(TSearch search= null)
        {
            var entity = _context.Set<TDatabase>().AsQueryable();

            entity = AddFilter(entity, search);
            entity = AddInclude(entity, search);

            var list = entity.ToList();
            return _mapper.Map<IList<TModel>>(list);
        }


        public virtual TModel GetById(int id)
        {
            return _mapper.Map<TModel>(_context.Set<TDatabase>().Find(id));
        }

    }

}
