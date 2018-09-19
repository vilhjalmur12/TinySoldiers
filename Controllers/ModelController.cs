using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TinySoldiers.Data;
using TinySoldiers.Models;
using TinySoldiers.Extensions;


namespace TinySoldiers.Controllers 
{
    public class ModelController : Controller 
    {

        [HttpGet("")]
        public IActionResult GetAllModels([FromQuery]int pageN = 1, [FromQuery]int pageS = 10) {

            List<ModelDTO> tmp = ListExtensions.ToLightWeight(DataContext.Models);

            return Ok(tmp);
        }

        [HttpGet("model/{modelId}")]
        public IActionResult GetModelById(int modelId) {
            return Ok("This is model by id function");
        }
    }
    
}

