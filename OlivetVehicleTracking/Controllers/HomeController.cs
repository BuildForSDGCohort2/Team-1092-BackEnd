using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OlivetVehicleTracking.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("{PlateNo}")]
        public IActionResult SearchVehicleByPlateNo(string PlateNo)
        {
            return Ok();
        }

        [HttpGet("{PlateNo}")]
        public IActionResult GetTrackerDataForVehicle(string PlateNo)
        {
            return Ok();
        }

        [HttpGet("{PlateNo}")]
        public IActionResult GetViolationForVehicle(string PlateNo)
        {
            return Ok();
        }
    }
}
