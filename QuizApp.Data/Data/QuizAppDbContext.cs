using Microsoft.EntityFrameworkCore;
using QuizApp.Data.Models;

namespace QuizApp.Data.Data
{
	public class QuizAppDbContext : DbContext
	{
		public DbSet<Quiz> Quizzes { get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet<Answer> Answers { get; set; }
		public QuizAppDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			ConfigTable(modelBuilder);
		}

		private void ConfigTable(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Answer>(x =>
			{
				x.HasKey(x => x.Id);

				x.Property(x => x.Content)
				.HasColumnType("varchar")
				.HasMaxLength(255)
				.IsRequired(true);

				x.Property(x => x.IsCorrect)
				.HasColumnType("bit")
				.HasDefaultValue(false)
				.IsRequired(true);

				x.Property(x => x.IsActive)
				.HasColumnType("bit")
				.HasDefaultValue(true)
				.IsRequired(true);

				x.HasOne(x => x.Question)
				.WithMany(x => x.Answers)
				.HasForeignKey(x => x.QuestionId);
			});

			modelBuilder.Entity<Question>(x =>
			{
				x.HasKey(x => x.Id);

				x.Property(x => x.Content)
				.HasColumnType("varchar")
				.HasMaxLength(5000)
				.IsRequired(true);

				x.Property(x => x.QuestionType)
				.HasColumnType("varchar")
				.HasMaxLength(50)
				.IsRequired(true);

				x.Property(x => x.IsActive)
				.HasColumnType("bit")
				.HasDefaultValue(true)
				.IsRequired(true);
			});

			modelBuilder.Entity<Quiz>(x =>
			{
				x.HasKey(x => x.Id);

				x.Property(x => x.Title)
				.HasColumnType("varchar")
				.HasMaxLength(255)
				.IsRequired(true);

				x.Property(x => x.Description)
				.HasColumnType("varchar")
				.HasMaxLength(500)
				.IsRequired(false);

				x.Property(x => x.Duration)
				.HasColumnType("int")
				.IsRequired(true);

				x.Property(x => x.IsActive)
				.HasColumnType("bit")
				.HasDefaultValue(true)
				.IsRequired(true);
			});

			modelBuilder.Entity<QuizQuestion>(x =>
			{
				x.HasKey(x => new
				{
					x.Id,
					x.QuizId,
					x.QuestionId
				});

				x.HasOne(x => x.Quiz).WithMany().IsRequired().HasPrincipalKey(x => x.Id).HasForeignKey(x => x.QuizId)
				.OnDelete(DeleteBehavior.NoAction);

				x.HasOne(x => x.Question).WithMany().IsRequired().HasPrincipalKey(x => x.Id).HasForeignKey(x => x.QuestionId)
				.OnDelete(DeleteBehavior.NoAction);
			});

			modelBuilder.Entity<User>(x =>
			{
				x.HasKey(x => x.Id);

				x.Property(x => x.FirstName)
				.HasMaxLength(50)
				.IsRequired(true);

				x.Property(x => x.LastName)
				.HasMaxLength(50)
				.IsRequired(true);

				x.Ignore(x => x.DisplayName);
				x.Property(x => x.DisplayName)
				.IsRequired(true);

				x.Property(x => x.DateOfBirth)
				.HasColumnType("datetime")
				.IsRequired(true);

				x.Property(x => x.IsActive)
				.HasColumnType("bit")
				.HasDefaultValue(true)
				.IsRequired(true);
			});

			modelBuilder.Entity<Role>(x =>
			{
				x.HasKey(x => x.Id);

				x.Property(x => x.Description)
				.HasColumnType("varchar")
				.HasMaxLength(50)
				.IsRequired(false);

				x.Property(x => x.IsActive)
				.HasColumnType("bit")
				.HasDefaultValue(true)
				.IsRequired(true);
			});

			modelBuilder.Entity<UserAnswer>(x =>
			{
				x.HasKey(x => new
				{
					x.Id,
					x.UserQuizId,
					x.QuestionId,
					x.AnswerId
				});

				x.Property(x => x.IsCorrect)
				.HasColumnType("bit")
				.IsRequired(false);

				x.HasOne(x => x.UserQuiz)
				.WithMany(x => x.UserAnswers)
				.HasPrincipalKey(x => x.Id)
				.HasForeignKey(x => x.UserQuizId)
				.OnDelete(DeleteBehavior.NoAction);

				x.HasOne(x => x.Question)
				.WithMany()
				.HasPrincipalKey(x => x.Id)
				.HasForeignKey(x => x.QuestionId)
				.OnDelete(DeleteBehavior.NoAction);

				x.HasOne(x => x.Answer)
				.WithMany()
				.HasPrincipalKey(x => x.Id)
				.HasForeignKey(x => x.AnswerId)
				.OnDelete(DeleteBehavior.NoAction);
			});

			modelBuilder.Entity<UserQuiz>(x =>
			{
				x.HasKey(x => new
				{
					x.Id,
					x.UserId,
					x.QuizId
				});

				x.Property(x => x.StartedAt)
				.HasColumnType("datetime")
				.HasDefaultValue(DateTime.Now)
				.IsRequired(true);

				x.Property(x => x.FinishedAt)
				.HasColumnType("datetime");

				x.HasOne(x => x.User)
				.WithMany()
				.HasPrincipalKey(x => x.Id)
				.HasForeignKey(x => x.UserId);

				x.HasOne(x => x.Quiz)
				.WithMany()
				.HasPrincipalKey(x => x.Id)
				.HasForeignKey(x => x.QuizId);
			});
		}
	}
}
