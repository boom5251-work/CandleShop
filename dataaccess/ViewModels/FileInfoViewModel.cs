namespace CandleShop.DataAccess.ViewModels
{
    /// <summary>
    /// Модель представления хранимого файла.
    /// </summary>
    public sealed class FileInfoViewModel
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public required string Name { get; set; }
    }
}