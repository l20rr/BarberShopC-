﻿using BarberShop2024.Server.Model;
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
        public IActionResult UserToDelete(int serviceId)
        {
            if (serviceId == 0)
                return BadRequest();

            var ServiceToDelete = _serviceModel.GetServicesById(serviceId);
            if (ServiceToDelete == null)
                return NotFound();

            _serviceModel.DeleteServices(serviceId);

            return NoContent();
        }
    }
}