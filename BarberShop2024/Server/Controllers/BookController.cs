using BarberShop2024.Server.Model;
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
    }
}
