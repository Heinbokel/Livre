using Livre.models;
using Microsoft.EntityFrameworkCore;

namespace Livre.configurations
{
    public class LivreDbContext : DbContext
    {
        // The configuration containing our app settings/values.
        private readonly IConfiguration _configuration;

        //DbSets defining our tables for our models.
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookImage> BookImages { get; set; }

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="configuration"><The IConfiguration to use./param>
        public LivreDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        /// <summary>
        /// Configures the database configurations.
        /// </summary>
        /// <param name="optionsBuilder">The DbContextOptionsBuilder to use.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Tells EF Core to use our database connection string from our appsettings.json
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            // Enable EF Core logging (logs the SQL it generates and more)
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            // Enable more verbose error explanations.
            optionsBuilder.EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
