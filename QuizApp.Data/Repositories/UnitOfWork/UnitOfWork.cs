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
	public class UnitOfWork : IUnitOfWork
	{
		public QuizAppDbContext Context { get; }

		public IGenericRepository<Quiz> QuizRepository { get; }

		public IGenericRepository<Question> QuestionRepository { get; }

		public IGenericRepository<UserQuiz> UserQuizRepository { get; }

		public IGenericRepository<QuizQuestion> QuizQuestionRepository { get; }

		public IGenericRepository<UserAnswer> UserAnswerRepository { get; }

		public IGenericRepository<User> UserRepository { get; }

		public IGenericRepository<Role> RoleRepository { get; }

		public IGenericRepository<Answer> AnswerRepository { get; }

		public UnitOfWork(QuizAppDbContext context, IGenericRepository<Quiz> quizRepository, IGenericRepository<Question> questionRepository, IGenericRepository<UserQuiz> userQuizRepository, IGenericRepository<QuizQuestion> quizQuestionRepository, IGenericRepository<UserAnswer> userAnswerRepository, IGenericRepository<User> userRepository, IGenericRepository<Role> roleRepository, IGenericRepository<Answer> answerRepository)
		{
			Context = context;
			QuizRepository = quizRepository;
			QuestionRepository = questionRepository;
			UserQuizRepository = userQuizRepository;
			QuizQuestionRepository = quizQuestionRepository;
			UserAnswerRepository = userAnswerRepository;
			UserRepository = userRepository;
			RoleRepository = roleRepository;
			AnswerRepository = answerRepository;
		}

		public async Task BeginTransactionAsync()
		{
			await Context.Database.BeginTransactionAsync();
		}

		public async Task CommitTransactionAsync()
		{
			await Context.Database.CommitTransactionAsync();
		}

		public IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : class
		{
			var repository = new GenericRepository<TEntity>(Context);
			return repository;
		}

		public async Task RollbackTransactionAsync()
		{
			await Context.Database.RollbackTransactionAsync();
		}

		public int SaveChanges()
		{
			int numberOfRecordChanged = Context.SaveChanges();
			return numberOfRecordChanged;
		}

		public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			int numberOfRecordChanged = await Context.SaveChangesAsync();
			return numberOfRecordChanged;
		}
	}
}
