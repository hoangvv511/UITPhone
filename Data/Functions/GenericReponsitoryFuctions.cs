using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Interfaces;
using System.Collections.Generic;

namespace Data.Functions
{
    class GenericReponsitoryFuctions<Entities> : IGenericReponsitory<Entities> where Entities : class
    {
        protected DbSet<Entities> DbSet;

        protected readonly DbContext _dbContext;

        public GenericReponsitoryFuctions(DbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<Entities>();
        }

        public async Task DeleteAscync(Entities entities)
        {
            throw new NotImplementedException();
        }

        public async Task EditAscync(Entities entities)
        {
            _dbContext.Entry(entities).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task InsertAscync(Entities entities)
        {
            throw new NotImplementedException();
        }

        public GenericReponsitoryFuctions()
        {

        }

    }
}
