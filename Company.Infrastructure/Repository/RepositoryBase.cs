using System;
using Microsoft.EntityFrameworkCore;
using Company.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Company.Infrastructure.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, new()
    {
        protected readonly CompanyDbContext _context;
        public readonly DbSet<TEntity> _collection;

        public RepositoryBase(CompanyDbContext context)
        {
            _context = context;
            _collection = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _collection.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _collection.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _collection.Update(entity);
        }

        public TEntity? GetById(int id)
        {
            return _collection.Find(id);
        }

        public List<TEntity> GetAll()
        {
            return _collection.ToList();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}

