using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandleShop.DataAccess.DomainModels
{
    /// <summary>
    /// Модель товара.
    /// </summary>
    [Table("Products")]
    [Index(nameof(Name), IsUnique = true)]
    public sealed class Product
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        [Required]
        [MaxLength(250)]
        public required string Name { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        [Required]
        [MaxLength(250)]
        public required string Description { get; set; }

        /// <summary>
        /// Цена.
        /// </summary>
        [Required]
        public required double Price { get; set; }

        /// <summary>
        /// Идентификатор изображения (внешний ключ).
        /// </summary>
        public int ImageId { get; set; }


        /// <summary>
        /// Изображение.
        /// </summary>
        [ForeignKey(nameof(ImageId))]
        public Image? Image { get; set; }
    }
}