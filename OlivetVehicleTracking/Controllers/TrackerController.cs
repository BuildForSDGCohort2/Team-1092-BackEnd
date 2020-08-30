using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OlivetVehicleTracking.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TrackerController : ControllerBase
    {
        public IActionResult LogTrackerData()
        {
            return Ok();
        }
    }
}
