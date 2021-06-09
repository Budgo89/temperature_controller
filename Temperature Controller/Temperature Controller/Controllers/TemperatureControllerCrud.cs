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
        /// <param name="time"> формат ввода 2021-05-20T11:00:02 </param>
        /// <returns></returns>
        [HttpPost("create")]
        public IActionResult Create([FromQuery] int temperatur, [FromQuery] DateTime time)
        {
            _holder.Add(temperatur, time);   
            return Ok();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeOne">формат ввода 2021-05-20T11:00:02</param>
        /// <param name="timeTwo">формат ввода 2021-05-20T11:00:02</param>
        /// <returns></returns>
        [HttpGet("read")]
        public IActionResult Read([FromQuery] DateTime timeOne, [FromQuery] DateTime timeTwo)
        {
            return Ok(_holder.Get(timeOne, timeTwo));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="temperatur"> формат ввода 11 </param>
        /// <param name="time"> формат ввода 2021-05-20T11:00:02 </param>
        /// <returns></returns>
        [HttpPut("update")]
        public IActionResult Update([FromQuery] int temperatur, [FromQuery] DateTime time)
        {
            _holder.Update(temperatur, time);
            return Ok();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeOne">формат ввода 2021-05-20T11:00:02</param>
        /// <param name="timeTwo">формат ввода 2021-05-20T11:00:02</param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime timeOne, [FromQuery] DateTime timeTwo)
        {
            _holder.Delete(timeOne, timeTwo);
            return Ok();
        }
    }
}
