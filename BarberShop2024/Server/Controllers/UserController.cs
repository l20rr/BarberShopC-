using BarberShop2024.Server.Data;
using BarberShop2024.Server.Model;
using BarberShop2024.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberShop2024.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserModel _userModel;
        
        public UserController(IUserModel userModel)
        {
            _userModel = userModel;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(_userModel.GetAllUsers());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching users: {ex.Message}");
            }
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserById(int userId)
        {
            try
            {
                return Ok(_userModel.GetUserById(userId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching the user: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            if (id == 0)
                return BadRequest();

            var employeeToDelete = _userModel.GetUserById(id);
            if (employeeToDelete == null)
                return NotFound();

            _userModel.DeleteUser(id);

            return NoContent();
        }
    }
}
