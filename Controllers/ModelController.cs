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

            var listItems = DataContext.Models.ToLightWeight()
                .OrderBy(c => c.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            LinkBuilder(ref listItems);
            
            return Ok(new Envelope<ModelDTO>(listItems, pageSize, pageNumber, listItems.Count()));
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

            // TODO: þurfum að geta skipta í fleiri objects fyrir links
            model.Links.AddReference("ref", "self");
            model.Links.AddReference("method", "GET");
            model.Links.AddReference("href", "http://localhost:5000/model/" + modelId);
            
            return Ok(model);
        }

        private void LinkBuilder(ref List<ModelDTO> modelList) {
            
            foreach(ModelDTO item in modelList)
            {
                item.Links.AddReference("ref", "self");
                item.Links.AddReference("method", "GET");
                item.Links.AddReference("href", "http://localhost:5000/model/" + item.Id);
            }
        }
    }
    
}

