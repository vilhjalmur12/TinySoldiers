using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TinySoldiers.Data;
using TinySoldiers.Models;
using TinySoldiers.Extensions;
using Microsoft.Extensions.Primitives;

using System;

namespace TinySoldiers.Controllers 
{
    public class ModelController : Controller 
    {

        [HttpGet("")]
        public IActionResult GetAllModels([FromQuery]int pageNumber = 1, [FromQuery]int pageSize = 10) {

            var fullList = DataContext.Models.ToLightWeight();
            
            var listItems = fullList
                .OrderBy(c => c.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            foreach(ModelDTO item in listItems)
            {
                item.Links.AddReference("self", "http://localhost:5000/model/");
            }
            
            int maxPages = (int) Math.Ceiling(fullList.Count() / (decimal) pageSize);

            return Ok(new Envelope<ModelDTO>(listItems, pageSize, pageNumber, maxPages));
        }

        [HttpGet("model/{modelId}")]
        public IActionResult GetModelById(int modelId) {
            List<ModelDetailsDTO> _db;

            if(Request.Headers.TryGetValue("Accept-Language", out StringValues value))
            {
                _db = DataContext.Models.ToDetails(value.ToString());
            } else {
                _db = DataContext.Models.ToDetails();
            }

            ModelDetailsDTO model = _db.FirstOrDefault(m => m.Id == modelId);
            
            if(model == null) {
                return NotFound("Id not found");
            }

            model.Links.AddReference("self", "http://localhost:5000/model/");
            
            return Ok(model);
        }
    }
    
}

