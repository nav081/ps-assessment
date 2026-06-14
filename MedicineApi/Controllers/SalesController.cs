using Microsoft.AspNetCore.Mvc;
using MedicineApi.Services.Interfaces;
using MedicineApi.Models;

namespace MedicineApi.Controllers{

    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }
        
        [HttpGet]
        public IActionResult GetAll(string search = "")
        {
            return Ok(_salesService.GetAllSales(search));
        }
        
        [HttpPost("medicine/{id}")]
        public IActionResult Sell(int id, [FromQuery] int qty)
        {
            var updatedMedicine = _salesService.Sell(id, qty);
            if(!updatedMedicine.Item2){
                return NotFound();
            }
            return Ok(updatedMedicine);
        }
    }
}