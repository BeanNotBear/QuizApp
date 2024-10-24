using Microsoft.EntityFrameworkCore;
using QuizApp.Business.Commons.Pagging;
using QuizApp.Data.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Business.Services.BaseService
{
	public class BaseService<T> : IBaseService<T> where T : class
	{
		private readonly IUnitOfWork unitOfWork;

		public BaseService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public virtual async Task<int> AddAsync(T entity)
		{
			unitOfWork.GenericRepository<T>().Add(entity);
			int rowAffected = await unitOfWork.SaveChangesAsync();
			return rowAffected;
		}

		public virtual bool Delete(Guid id)
		{
			unitOfWork.GenericRepository<T>().Delete(id);
			int rowAffected = unitOfWork.SaveChanges();
			return rowAffected > 0;
		}

		public virtual async Task<bool> DeleteAsync(Guid id)
		{
			unitOfWork.GenericRepository<T>().Delete(id);
			int rowAffected = await unitOfWork.SaveChangesAsync();
			return rowAffected > 0;
		}

		public virtual async Task<bool> DeleteAsync(T entity)
		{
			unitOfWork.GenericRepository<T>().Delete(entity);
			int rowAffected = await unitOfWork.SaveChangesAsync();
			return rowAffected > 0;
		}

		public virtual async Task<IEnumerable<T>> GetAllAsync()
		{
			var entities = await unitOfWork.GenericRepository<T>().GetAllAsync();
			return entities;
		}

		public virtual async Task<PaginatedResult<T>> GetAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "", int pageIndex = 1, int pageSize = 10)
		{
			var repository = unitOfWork.GenericRepository<T>();
			var query = repository.Get(filter, orderBy, includeProperties);
			var take = pageSize;
			var skip = (pageIndex - 1) * take;
			var count = await query.CountAsync();
			query = query.Skip(skip).Take(take);
			var items = await query.ToListAsync();
			var paginatedResult = new PaginatedResult<T>(items, count, pageIndex, pageSize);
			return paginatedResult;
		}

		public virtual async Task<T?> GetByIdAsync(Guid id)
		{
			var entity = await unitOfWork.GenericRepository<T>().GetByIdAsync(id);
			return entity;
		}

		public virtual async Task<bool> UpdateAsync(T entity)
		{
			unitOfWork.GenericRepository<T>().Update(entity);
			int rowAffected = await unitOfWork.SaveChangesAsync();
			return rowAffected > 0;
		}
	}
}
