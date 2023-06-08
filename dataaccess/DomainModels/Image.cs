using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandleShop.DataAccess.DomainModels
{
    /// <summary>
    /// Модель изображения.
    /// </summary>
    [Table("Images")]
    [Index(nameof(FileName), IsUnique = true)]
    public sealed class Image : IStoredFileInfo
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название файла.
        /// </summary>
        [Required]
        [StringLength(260, MinimumLength = 5)]
        public required string FileName { get; set; }

        /// <summary>
        /// Данные изображения.
        /// </summary>
        [Required]
        public required byte[] ImageData { get; set; }
    }
}