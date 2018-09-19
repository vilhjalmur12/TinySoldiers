using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace TinySoldiers.Controllers 
{
    public class ModelController : Controller 
    {
        [HttpGet("")]
        public IActionResult GetAllModels() {
            return Ok("This is GetAllModels function");
        }

        [HttpGet("model/{modelId}")]
        public IActionResult GetModelById(int modelId) {
            return Ok("This is model by id function");
        }
    }
    
}

