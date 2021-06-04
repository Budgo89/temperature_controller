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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="temperatur"> формат ввода 11 </param>
        /// <param name="time"> формат ввода 11:30 </param>
        /// <returns></returns>
        [HttpPost("create")]
        public IActionResult Create([FromQuery] string temperatur, [FromQuery] string time)
        {
            _holder.Add(temperatur, time);   
            return Ok();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeOne">формат ввода 11:30</param>
        /// <param name="timeTwo">формат ввода 11:30</param>
        /// <returns></returns>
        [HttpGet("read")]
        public IActionResult Read([FromQuery] string timeOne, [FromQuery] string timeTwo)
        {
            return Ok(_holder.Get(timeOne, timeTwo));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="temperatur"> формат ввода 11 </param>
        /// <param name="time"> формат ввода 11:30 </param>
        /// <returns></returns>
        [HttpPut("update")]
        public IActionResult Update([FromQuery] string temperatur, [FromQuery] string time)
        {
            _holder.Update(temperatur, time);
            return Ok();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeOne">формат ввода 11:30</param>
        /// <param name="timeTwo">формат ввода 11:30</param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] string timeOne, [FromQuery] string timeTwo)
        {
            _holder.Delete(timeOne, timeTwo);
            return Ok();
        }
    }
}
