using BarberShop2024.Server.Model;
using BarberShop2024.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop2024.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookMark _bookMarkModel;
        public BookController(IBookMark bookMarkModel)
        {
            _bookMarkModel = bookMarkModel;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                return Ok(_bookMarkModel.GetAllBooks());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching GetAllBooks: {ex.Message}");
            }
        }

        [HttpGet("{bookMarkId}")]
        public IActionResult GetBookById(int bookMarkId)
        {
            try
            {
                return Ok(_bookMarkModel.GetBookById(bookMarkId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching the GetServicesById: {ex.Message}");
            }
        }

        [HttpPut("{bookMarkId}")]
        public IActionResult UpdateUser(int bookMarkId, [FromBody] BookMark bookMark)
        {
            var updateBook = _bookMarkModel.UpdateBook(bookMarkId, bookMark);

            if (updateBook == null)
            {
                return NotFound(); // Retorna 404 se não for encontrado
            }

            return Ok(updateBook); // Retorna 200 com os dados  atualizados
        }
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookMark bookMark)
        {
            var addedBook = await _bookMarkModel.AddBook(bookMark);

            if (addedBook == null)
            {
                return BadRequest(); // Retorna 400 se não for possível adicionar o serviço
            }

            return CreatedAtAction(nameof(GetAllBooks), new { bookMarkId = addedBook.BookMarkId }, AddBook); // Retorna 201 com os dados do serviço adicionado
        }
    }
}
