using Microsoft.AspNetCore.Mvc;
using MedicineApi.Services.Interfaces;
using MedicineApi.Models;

namespace MedicineApi.Controllers{

    [ApiController]
    [Route("api/[controller]")]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicinesService _medicinesService;

        public MedicinesController(IMedicinesService medicinesService)
        {
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
    }
}