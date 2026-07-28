using System;
namespace SirketApp.DataAccess.Repository.Abstracts
{
	public interface IRepositoryBase<TEntity> where TEntity : class, new()
	{
		void Add(TEntity entity);
		void Update(TEntity entity);
		void Delete(TEntity entity);
		TEntity? GetById(int id);
		List<TEntity> GetAll();
		int SaveChanges();
    }
}

