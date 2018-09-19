using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace TinySoldiers.Controllers 
{
    public class ModelController : Controller 
    {
        [HttpGet("")]
        public IActionResult GetAllModels([FromQuery]int pageN = 1, [FromQuery]int pageS = 10) {
            return Ok("This is GetAllModels function");
        }

        [HttpGet("model/{modelId}")]
        public IActionResult GetModelById(int modelId) {
            return Ok("This is model by id function");
        }
    }
    
}

