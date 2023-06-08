using CandleShop.DataAccess.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace CandleShop.DataAccess
{
    /// <summary>
    /// Контекст базы данных.
    /// </summary>
    public sealed class DatabaseContext : DbContext, IDatabaseContext
    {
        /// <summary>
        /// Параметризированный конструктор.
        /// </summary>
        /// <param name="options">Параметры контекста базы данных.</param>
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }



        /// <inheritdoc />
        public DbSet<Image> Images { get; set; }

        /// <inheritdoc />
        public DbSet<Product> Products { get; set; }
    }
}