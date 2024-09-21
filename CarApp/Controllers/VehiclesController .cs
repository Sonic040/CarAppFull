using CarApp.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleService _vehicleService;

        public VehiclesController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("makes")]
        public async Task<IActionResult> GetAllMakes()
        {
            var makes = await _vehicleService.GetAllMakesAsync();
            return Ok(makes);
        }

        [HttpGet("vehicletypes/{makeId}")]
        public async Task<IActionResult> GetVehicleTypesForMake(int makeId)
        {
            var types = await _vehicleService.GetVehicleTypesForMakeIdAsync(makeId);
            return Ok(types);
        }

        [HttpGet("models")]
        public async Task<IActionResult> GetModelsForMakeAndYear([FromQuery] int makeId, [FromQuery] int year)
        {
            var models = await _vehicleService.GetModelsForMakeAndYearAsync(makeId, year);
            return Ok(models);
        }
    }
}
