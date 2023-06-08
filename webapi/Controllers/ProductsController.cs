using CandleShop.DataAccess;
using CandleShop.DataAccess.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace CandleShop.WebApi.Controllers
{
    /// <summary>
    /// Контроллер товаров.
    /// </summary>
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Контекст базы данных.
        /// </summary>
        private readonly IDatabaseContext _context;



        public ProductsController(IDatabaseContext context)
        {
            _context = context;
        }



        /// <summary>
        /// Обрабатывает GET-запрос.<br />
        /// Извлекает перечисление товаров из базы данных.
        /// </summary>
        /// <param name="from">Начиная с.</param>
        /// <param name="to">Заканчивая.</param>
        /// <returns>Перечисление товаров.</returns>
        [HttpGet]
        public IEnumerable<Product> GetProducts([FromQuery] int from, [FromQuery] int to)
        {
            var range = new Range(from, Math.Min(_context.Products.Count(), to));
            return _context.Products.AsEnumerable().Take(range);
        }


        /// <summary>
        /// Обрабатывает POST-запрос.<br />
        /// Сохраняет товар в базу данных.
        /// </summary>
        /// <param name="product">Товар.</param>
        /// <returns>Результат действия: сообщение.</returns>
        [HttpPost]
        public IActionResult PostProduct([FromBody] Product product)
        {
            if (_context.Products.Find(product.Id) is null)
            {
                _ = _context.Products.Update(product);
                _ = _context.SaveChanges();
                return Ok(new { Message = "Элемент успешно обновлен." });
            }
            else
            {
                _ = _context.Products.Add(product);
                _ = _context.SaveChanges();
                return Ok(new { Message = "Элемент успешно добавлен." });
            }
        }


        /// <summary>
        /// Обрабатывает DELETE-запрос.<br />
        /// Удаляет товар из базы данных.
        /// </summary>
        /// <param name="productId">Идентификатор товара.</param>
        /// <returns>Результат действия: сообщение.</returns>
        [HttpDelete]
        public IActionResult DeleteProduct([FromQuery] int id)
        {
            var product = _context.Products.Find(id);

            if (product is not null)
            {
                _ = _context.Products.Remove(product);
                _ = _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}