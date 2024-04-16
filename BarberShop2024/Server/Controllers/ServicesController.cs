using BarberShop2024.Server.Model;
using BarberShop2024.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop2024.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServices _serviceModel;
        public ServicesController(IServices serviceModel)
        {
            _serviceModel = serviceModel;
        }
        [HttpGet]
        public IActionResult GetAllServices()
        {
            try
            {
                return Ok(_serviceModel.GetAllServices());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching GetAllServices: {ex.Message}");
            }
        }

        [HttpGet("{serviceId}")]
        public IActionResult GetServiceById(int serviceId)
        {
            try
            {
                return Ok(_serviceModel.GetServicesById(serviceId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching the GetServicesById: {ex.Message}");
            }
        }
        [HttpDelete("{serviceId}")]
        public IActionResult ServicesToDelete(int serviceId)
        {
            if (serviceId == 0)
                return BadRequest();

            var ServiceToDelete = _serviceModel.GetServicesById(serviceId);
            if (ServiceToDelete == null)
                return NotFound();

            _serviceModel.DeleteServices(serviceId);

            return NoContent();
        }
        [HttpPut("{serviceId}")]
        public IActionResult UpdateServices(int serviceId, [FromBody] ServicesBarber servicesBarber)
        {
            var updatedServices = _serviceModel.UpdateServices(serviceId, servicesBarber);

            if (updatedServices == null)
            {
                return NotFound(); // Retorna 404 se não for encontrado
            }

            return Ok(updatedServices); // Retorna 200 com os dados  atualizados
        }
        [HttpPost]
        public async Task<IActionResult> AddService([FromBody] ServicesBarber servicesBarber)
        {
            var addedService = await _serviceModel.AddServices(servicesBarber);

            if (addedService == null)
            {
                return BadRequest(); // Retorna 400 se não for possível adicionar o serviço
            }

            return CreatedAtAction(nameof(GetAllServices), new { serviceId = addedService.ServiceId }, addedService); // Retorna 201 com os dados do serviço adicionado
        }
    }
}