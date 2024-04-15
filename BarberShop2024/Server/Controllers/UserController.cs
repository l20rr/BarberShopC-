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
        public IActionResult UserToDelete(int id)
        {
            if (id == 0)
                return BadRequest();

            var userToDelete = _userModel.GetUserById(id);
            if (userToDelete == null)
                return NotFound();

            _userModel.DeleteUser(id);

            return NoContent();
        }
        [HttpPut("{userId}")]
        public IActionResult UpdateUser(int userId, [FromBody] User user)
        {
            var updatedUser = _userModel.UpdateUser(userId, user);

            if (updatedUser == null)
            {
                return NotFound(); // Retorna 404 se o usuário não for encontrado
            }

            return Ok(updatedUser); // Retorna 200 com os dados do usuário atualizados
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            var addedUser = await _userModel.AddUser(user);

            if (addedUser == null)
            {
                return BadRequest(); // Retorna 400 se não for possível adicionar o usuário
            }

            return CreatedAtAction(nameof(GetAllUsers), new { userId = addedUser.UserId }, addedUser); // Retorna 201 com os dados do usuário adicionado
        }
    }
}
