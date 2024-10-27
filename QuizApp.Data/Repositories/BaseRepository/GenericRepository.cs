using Microsoft.EntityFrameworkCore;
using QuizApp.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data.Repositories.BaseRepository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private QuizAppDbContext _context;

		public GenericRepository(QuizAppDbContext context)
		{
			_context = context;
		}

		public void Add(T entity)
		{
			_context.Set<T>().Add(entity);
		}

		public void Delete(Guid id)
		{
			var entity = _context.Set<T>().Find(id);
			if (entity != null)
			{
				_context.Set<T>().Remove(entity);
			}
		}

		public void Delete(T entity)
		{
			if (entity != null)
			{
				_context.Set<T>().Remove(entity);
			}
		}

		public IQueryable<T> Get(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "")
		{
			var query = _context.Set<T>().AsQueryable();
			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (orderBy != null)
			{
				query = orderBy(query);
			}

			if (!string.IsNullOrWhiteSpace(includeProperties))
			{
				var includes = includeProperties.Split(',');
				foreach (var include in includes)
				{
					query = query.Include(include);
				}
			}

			return query;
		}

		public IEnumerable<T> GetAll()
		{
			var entities = _context.Set<T>().ToList();
			return entities;
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			var entities = await _context.Set<T>().ToListAsync();
			return entities;
		}

		public T? GetById(Guid id)
		{
			var entity = _context.Set<T>().Find(id);
			return entity;
		}

		public async Task<T?> GetByIdAsync(Guid id)
		{
			var entity = await _context.Set<T>().FindAsync(id);
			return entity;
		}

		public IQueryable<T> GetQuery()
		{
			var query = _context.Set<T>().AsQueryable();
			return query;
		}

		public IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate)
		{
			var query = _context.Set<T>().AsQueryable();
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			return query;
		}

		public void Update(T entity)
		{
			if (entity != null)
			{
				_context.Set<T>().Update(entity);
			}
		}
	}
}
