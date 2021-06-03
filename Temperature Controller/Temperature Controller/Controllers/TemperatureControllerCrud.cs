using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Temperature_Controller.Controllers
{
    [Route("api/crud")]
    [ApiController]
    public class TemperatureControllerCrud : ControllerBase
    {
        private readonly IValuesHolder _holder;
        public TemperatureControllerCrud(IValuesHolder holder)
        {
            _holder = holder;
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] string temperatur, [FromQuery] string time)
        {
            _holder.Add(temperatur, time);
            return Ok();
        }

        [HttpGet("read")]
        public IActionResult Read([FromQuery] string timeOne, [FromQuery] string timeTwo)
        {
            return Ok(_holder.Get(timeOne, timeTwo));
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] string temperatur, [FromQuery] string time)
        {
            _holder.Update(temperatur, time);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] string timeOne, [FromQuery] string timeTwo)
        {
            _holder.Delete(timeOne, timeTwo);
            return Ok();
        }
    }
}
