using System.ComponentModel.DataAnnotations;

namespace CandleShop.DataAccess.DomainModels
{
    /// <summary>
    /// Интерфейс хранимого файла.
    /// </summary>
    public interface IStoredFileInfo
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
        [StringLength(260)]
        public string FileName { get; set; }
    }
}
