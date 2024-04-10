using BarberShop2024.Server.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop2024.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerModel _customerModel;

        public CustomerController(ICustomerModel customerModel)
        {
            _customerModel = customerModel;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(_customerModel.GetAllCustomer());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching customer: {ex.Message}");
            }
        }

        [HttpGet("{customerId}")]
        public IActionResult GetCustomerById(int customerId)
        {
            try
            {
                return Ok(_customerModel.GetCustomerById(customerId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching the customer: {ex.Message}");
            }
        }
        /*
        [HttpDelete("{id}")]
        public IActionResult CustomerDelete(int id)
        {
            if (id == 0)
                return BadRequest();

            var customerToDelete = _customerModel.DeleteCustomer(int id);
            if (customerToDelete == null)
                return NotFound();

            _customerModel.DeleteCustomer(id);

            return NoContent();
        }*/
    }
}

