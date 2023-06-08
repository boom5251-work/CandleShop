using CandleShop.DataAccess.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace CandleShop.DataAccess
{
    /// <summary>
    /// Интерфейс контекста базы данных.
    /// </summary>
    public interface IDatabaseContext
    {
        /// <summary>
        /// Набор моделей изображений.
        /// </summary>
        public DbSet<Image> Images { get; set; }

        /// <summary>
        /// Набор моделей товаров.
        /// </summary>
        public DbSet<Product> Products { get; set; }



        /// <summary>
        /// Сохраняет изменения.
        /// </summary>
        /// <returns>Количество изменений.</returns>
        public int SaveChanges();

        /// <summary>
        /// Сохраняет изменения.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены задачи.</param>
        /// <returns>Количество изменений.</returns>
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}