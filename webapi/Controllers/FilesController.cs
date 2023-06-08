using CandleShop.DataAccess;
using CandleShop.DataAccess.DomainModels;
using CandleShop.DataAccess.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CandleShop.WebApi.Controllers
{
    /// <summary>
    /// Контроллер статических файлов.
    /// </summary>
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        /// <summary>
        /// Контекст базы данных.
        /// </summary>
        private readonly IDatabaseContext _context;



        public FilesController(IDatabaseContext context)
        {
            _context = context;
        }



        /// <summary>
        /// Обрабатывает POST-запрос.<br />
        /// Сохраняет изображение в базе данных.
        /// </summary>
        /// <param name="saveAs">Новое полное название файла.</param>
        /// <returns></returns>
        [HttpPost("images")]
        [DisableRequestSizeLimit]
        public IActionResult UploadImage([FromForm] string? saveAs = default)
        {
            var formFile = Request.Form.Files.SingleOrDefault();

            if (formFile is not null)
            {
                var bytes = ReadFileBytes(formFile);
                string fileName = saveAs is null ? formFile.FileName : saveAs;
                var dbSetAction = AddOrUpdateImage(fileName, bytes);

                if (dbSetAction == DbSetAction.Added)
                    return Ok(new { Message = "Элемент успешно добавлен." });
                else if (dbSetAction == DbSetAction.Updated)
                    return Ok(new { Message = "Элемент успешно обновлен." });
                else
                    return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            else
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// Обрабатывает GET-запрос.<br />
        /// Извлекает изображение из базы данных.
        /// </summary>
        /// <param name="productId">Идентификатор товара.</param>
        /// <returns>Файл изображения.</returns>
        [HttpGet("images")]
        public IActionResult RetrieveImage([FromQuery(Name = "product-id")] int productId)
        {
            var product = _context.Products.Find(productId);

            if (product is not null)
            {
                var image = _context.Images.Find(product.ImageId);

                if (image is not null)
                    return File(image.ImageData, "image/png");
                else
                    return NotFound();
            }
            else
            {
                return NotFound();
            }
        }


        /// <summary>
        /// Обрабатывает DELETE-запрос.<br />
        /// Удаляет изображение из базы данных.
        /// </summary>
        /// <param name="id">Идентификатор изображения.</param>
        /// <returns>Результат действия: сообщение.</returns>
        [HttpDelete("images")]
        public IActionResult DeleteImage([FromQuery] int id)
        {
            var image = _context.Images.Find(id);

            if (image is not null)
            {
                _ = _context.Images.Remove(image);
                _ = _context.SaveChanges();
                return Ok(new { Message = "Элемент успешно удален." });
            }
            else
            {
                return NotFound(new { Message = "Не удалось удалить элемент." });
            }
        }


        /// <summary>
        /// Обрабатывает GET-запрос.<br />
        /// Извлекает записи изображений из базы данных.
        /// </summary>
        /// <returns>Перечисление вхождений.</returns>
        [HttpGet("images/entries")]
        public IEnumerable<FileInfoViewModel> GetImageEntries()
        {
            var selector = (Image image) => new FileInfoViewModel { Id = image.Id, Name = image.FileName };
            return _context.Images.AsEnumerable().Select(selector);
        }


        /// <summary>
        /// Читает байты файла из HTTP-запроса.
        /// </summary>
        /// <param name="formFile">Файл из HTTP-запроса.</param>
        /// <returns>Массив байтов.</returns>
        private byte[] ReadFileBytes(IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                formFile.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }


        /// <summary>
        /// Добавляет новое в БД изображение или обновляет существующее.
        /// </summary>
        /// <param name="fileName">Название файла.</param>
        /// <param name="bytes">Данные изображения.</param>
        /// <returns>Манипуляция над набором данных.</returns>
        private DbSetAction AddOrUpdateImage(string fileName, byte[] bytes)
        {
            Image? image = _context.Images.SingleOrDefault(image => image.FileName == fileName);

            if (image is null)
            {
                // Добавление нового изображения в БД.
                image = new Image { FileName = fileName, ImageData = bytes };
                _ = _context.Images.Add(image);
                _ = _context.SaveChanges();
                return DbSetAction.Added;
            }
            else
            {
                // Обновление существующего изображения в БД.
                image.FileName = fileName;
                image.ImageData = bytes;
                _ = _context.Images.Update(image);
                _ = _context.SaveChanges();
                return DbSetAction.Updated;
            }
        }



        /// <summary>
        /// Манипуляции над набором данных.
        /// </summary>
        [Flags]
        private enum DbSetAction
        {
            /// <summary>
            /// Добавлена одна или несколько записей.
            /// </summary>
            Added = 0b1,

            /// <summary>
            /// Изменена одна или несколько записей.
            /// </summary>
            Updated = 0b10,

            /// <summary>
            /// Удалена одна или несколько записей.
            /// </summary>
            Removed = 0b100
        }
    }
}