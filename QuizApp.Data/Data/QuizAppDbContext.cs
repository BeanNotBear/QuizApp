using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data.Models;

namespace QuizApp.Data.Data
{
	public class QuizAppDbContext : IdentityDbContext<User, Role, Guid,
		IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>,
		IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
	{
		public DbSet<Quiz> Quizzes { get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet<Answer> Answers { get; set; }
		public DbSet<QuizQuestion> QuizQuestions { get; set; }
		public DbSet<UserAnswer> UserAnswers { get; set; }
		public DbSet<UserQuiz> UserQuizes { get; set; }

		public QuizAppDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Change Identity table names
			modelBuilder.Entity<User>().ToTable("Users");
			modelBuilder.Entity<Role>().ToTable("Roles");
			modelBuilder.Entity<UserRole>().ToTable("UserRoles");
			modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
			modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
			modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
			modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");

			// Configure UserRole relationships with restricted cascade delete
			modelBuilder.Entity<UserRole>(userRole =>
			{
				userRole.HasOne(ur => ur.User)
					.WithMany()
					.HasForeignKey(ur => ur.UserId)
					.OnDelete(DeleteBehavior.NoAction);

				userRole.HasOne(ur => ur.Role)
					.WithMany()
					.HasForeignKey(ur => ur.RoleId)
					.OnDelete(DeleteBehavior.NoAction);
			});

			ConfigTable(modelBuilder);
			SeedRole(modelBuilder);
		}

		private void SeedRole(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Role>().HasData(
				new Role { Id = Guid.Parse("5c35fe5b-cb5d-4072-9168-79f725c1f605"), Name = "ADMIN", IsActive = true, NormalizedName = "ADMIN" },
				new Role { Id = Guid.Parse("f0e7b8ba-05ea-4bed-be2d-62b0802bfe7e"), Name = "STUDENT", IsActive = true, NormalizedName = "STUDENT" }
			);
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
				.HasForeignKey(x => x.QuestionId)
				.OnDelete(DeleteBehavior.NoAction);
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
				// Configure composite key
				x.HasKey(x => new
				{
					x.Id,
					x.QuizId,
					x.QuestionId
				});

				// Configure relationship with Quiz
				x.HasOne(x => x.Quiz)
					.WithMany(q => q.QuizQuestions)
					.HasForeignKey(x => x.QuizId)
					.OnDelete(DeleteBehavior.NoAction);

				// Configure relationship with Question
				x.HasOne(x => x.Question)
					.WithMany(q => q.QuizQuestions)
					.HasForeignKey(x => x.QuestionId)
					.OnDelete(DeleteBehavior.NoAction);
			});

			modelBuilder.Entity<User>(x =>
			{
				x.Property(x => x.FirstName)
				.HasMaxLength(50)
				.IsRequired(true);

				x.Property(x => x.LastName)
				.HasMaxLength(50)
				.IsRequired(true);

				x.Property(x => x.DateOfBirth)
				.HasColumnType("datetime")
				.IsRequired(true);

				x.Property(x => x.IsActive)
				.HasColumnType("bit")
				.HasDefaultValue(true)
				.IsRequired(true);

				x.Property(x => x.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired(true);

				x.Ignore(x => x.DisplayName);
			});

			modelBuilder.Entity<Role>(x =>
			{
				x.Property(x => x.Description)
				.HasColumnType("varchar")
				.HasMaxLength(50)
				.IsRequired(false);

				x.Property(x => x.IsActive)
				.HasColumnType("bit")
				.HasDefaultValue(true)
				.IsRequired(true);
			});

			modelBuilder.Entity<UserRole>(x =>
			{
				x.HasKey(x => new { x.UserId, x.RoleId });
				x.HasOne(x => x.User)
				.WithMany(u => u.UserRoles)
				.HasForeignKey(x => x.UserId)
				.IsRequired(true);

				x.HasOne(x => x.Role)
				.WithMany(r => r.UserRoles)
				.HasForeignKey(x => x.RoleId)
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
					.HasForeignKey(x => x.UserId)
					.OnDelete(DeleteBehavior.NoAction);

				x.HasOne(x => x.Quiz)
					.WithMany()
					.HasPrincipalKey(x => x.Id)
					.HasForeignKey(x => x.QuizId)
					.OnDelete(DeleteBehavior.NoAction);
			});
		}
	}
}