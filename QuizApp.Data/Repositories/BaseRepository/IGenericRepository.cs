using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data.Repositories.BaseRepository
{
	public interface IGenericRepository<T> where T : class
	{
		IEnumerable<T> GetAll();
		Task<IEnumerable<T>> GetAllAsync();
		T? GetById(Guid id);
		Task<T?> GetByIdAsync(Guid id);
		void Add(T entity);
		void Update(T entity);
		void Delete(Guid id);
		void Delete(T entity);
		IQueryable<T> GetQuery();
		IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate);
		IQueryable<T> Get(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "");
	}
}
