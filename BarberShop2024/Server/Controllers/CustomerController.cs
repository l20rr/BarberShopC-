using BarberShop2024.Server.Model;
using BarberShop2024.Shared;
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
        public IActionResult GetAllCostumer()
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
        
        [HttpDelete("{customerId}")]
        public IActionResult CustomerDelete(int customerId)
        {
            if (customerId == 0)
                return BadRequest();

            var CustomerToDelete = _customerModel.GetCustomerById(customerId);
            if (CustomerToDelete == null)
                return NotFound();

            _customerModel.DeleteCustomer(customerId);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddCostumer([FromBody] Customer customer)
        {
            var addedCostumer = await _customerModel.AddCustomer(customer);

            if (addedCostumer == null)
            {
                return BadRequest(); // Retorna 400 se não for possível adicionar o serviço
            }

            return CreatedAtAction(nameof(GetAllCostumer), new { c = addedCostumer.CustomerId }, addedCostumer); // Retorna 201 com os dados do serviço adicionado
        }

        [HttpPut("{customerId}")]
        public IActionResult UpdateCustomer(int customerId, [FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerToUpdate = _customerModel.GetCustomerById(customer.CustomerId);

            if (customerToUpdate == null)
                return NotFound();

            _customerModel.UpdateCustomer(customer);

            return NoContent(); //success
        }
    }
}

