using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Business.Commons.Pagging
{
	public class PaginatedResult<T>
	{
		public int PageIndex { get; private set; }
		public int TotalPages { get; private set; }
		public T[] Items { get; set; }

		public PaginatedResult()
		{
			Items = Array.Empty<T>();
		}

		public PaginatedResult(List<T> items, int count, int pageIndex, int pageSize)
		{
			PageIndex = pageIndex;
			TotalPages = (int)Math.Ceiling((double)count / pageSize);
			Items = items.ToArray();
		}

		public bool HasPreviousPage { get => PageIndex > 1; }
		public bool HasNextPage { get => PageIndex < TotalPages; }
	}
}
