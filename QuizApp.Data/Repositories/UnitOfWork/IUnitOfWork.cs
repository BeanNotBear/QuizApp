using QuizApp.Data.Data;
using QuizApp.Data.Models;
using QuizApp.Data.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data.Repositories.UnitOfWork
{
	public interface IUnitOfWork
	{
		QuizAppDbContext Context { get; }
		IGenericRepository<Quiz> QuizRepository { get; }
		IGenericRepository<Question> QuestionRepository { get; }
		IGenericRepository<UserQuiz> UserQuizRepository { get; }
		IGenericRepository<QuizQuestion> QuizQuestionRepository { get; }
		IGenericRepository<UserAnswer> UserAnswerRepository { get; }
		IGenericRepository<User> UserRepository { get; }
		IGenericRepository<Role> RoleRepository { get; }
		IGenericRepository<Answer> AnswerRepository { get; }
		IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : class;
		int SaveChanges();
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
		Task BeginTransactionAsync();
		Task CommitTransactionAsync();
		Task RollbackTransactionAsync();
	}
}
