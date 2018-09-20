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

            var tmp2 = DataContext.Models.ToDetails();

            var listItems = ListExtensions.ToLightWeight(DataContext.Models)
                .OrderBy(c => c.Id)
                .Skip((pageN - 1) * pageS)
                .Take(pageS)
                .ToList();

            LinkBuilder(ref listItems);
            
            return Ok(new Envelope<ModelDTO>(listItems, pageS, pageN, tmp.Count()));
        }

        [HttpGet("model/{modelId}")]
        public IActionResult GetModelById(int modelId) {
            var _db = ListExtensions.ToLightWeight(DataContext.Models);

            ModelDTO model = _db.FirstOrDefault(m => m.Id == modelId);

            return Ok(model);
        }

        private void LinkBuilder(ref List<ModelDTO> modelList) {
            
            foreach(ModelDTO item in modelList)
            {
                item.Links.TryAdd("method", "GET");
                var getUri = "http://localhost:5000/model/" + item.Id;
                item.Links.TryAdd("uri", getUri);
            }
        }
    }
    
}

