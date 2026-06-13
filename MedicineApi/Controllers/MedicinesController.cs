using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MedicineApi.Services.Interfaces;
using MedicineApi.Models;

namespace MedicineApi.Controllers{

    [ApiController]
    [Route("api/[controller]")]
    public class MedicinesController : ControllerBase
    {
        private readonly ILogger<MedicinesController> _logger;
        private readonly IMedicinesService _medicinesService;

        public MedicinesController(ILogger<MedicinesController> logger,IMedicinesService medicinesService)
        {
            _logger = logger;
            _medicinesService = medicinesService;
        }

        
        [HttpGet]
        public IActionResult GetAll(string search = "")
        {
            return Ok(_medicinesService.GetAll(search));
        }

        
        [HttpPost]
        public IActionResult Add([FromBody] Medicine med)
        {
            var response = _medicinesService.Add(med);
            if(response.isCorrect){
                return Ok(med);
            } else {
                return BadRequest(response.errors);
            }
        }

        
        [HttpPost("sell/{id}")]
        public IActionResult Sell(int id, [FromQuery] int qty)
        {
            var updatedMedicine = _medicinesService.Sell(id, qty);
            if(updatedMedicine.FullName == ""){
                return NotFound();
            }
            return Ok(updatedMedicine);
        }
    }
}