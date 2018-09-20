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

            var listItems = ListExtensions.ToLightWeight(DataContext.Models)
                .OrderBy(c => c.Id)
                .Skip(pageN)
                .Take(pageS)
                .ToList();

            return Ok(new Envelope<ModelDTO>(listItems, pageS, pageN, 100));
        }

        [HttpGet("model/{modelId}")]
        public IActionResult GetModelById(int modelId) {
            return Ok("This is model by id function ");
        }
    }
    
}

