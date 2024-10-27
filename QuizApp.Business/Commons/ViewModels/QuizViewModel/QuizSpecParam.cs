namespace QuizApp.Business.Commons.ViewModels.QuizViewModel
{
	public class QuizSpecParam
	{
		private const int MaxPageSize = 10;

		public string? SearchByTitle { get; set; } = null;
		public bool? IsActive { get; set; } = null;
		public int? Duration { get; set; } = null;
		public string? OrderBy { get; set; } = null;
		public bool IsDescending { get; set; } = false;

		private int _pageNumber = 1;
		public int PageNumber
		{
			get => _pageNumber;
			set => _pageNumber = value <= 0 ? 1 : value;
		}

		private int _pageSize = 10;
		public int PageSize
		{
			get => _pageSize;
			set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
		}
	}
}
