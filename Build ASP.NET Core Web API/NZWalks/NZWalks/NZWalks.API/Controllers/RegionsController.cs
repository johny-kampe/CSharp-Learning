using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        public RegionsController(NZWalksDbContext dbContext) { 
            this.dbContext = dbContext;
        }
        // GET ALL REGIONS
        // GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
            //var regions = new List<Region>
            //{
            //    new Region
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Auckland Region",
            //        Code = "AKL",
            //        RegionImgUrl = "https://images.pexels.com/photos/8470793/pexels-photo-8470793.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2"
            //    },
            //    new Region
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Wellington Region",
            //        Code = "WLG",
            //        RegionImgUrl = "https://media.istockphoto.com/id/1192544479/photo/swing-bridge.jpg?s=1024x1024&w=is&k=20&c=KQJbWUQMApgCNf87YeprlUAx5dQsRRrdHBmKg9jtt9E="
            //    }
            //};

            var regions = dbContext.Regions.ToList();

            return Ok(regions);
        }

        // GET REGION BY ID
        // GET: https://localhost:portnumber/api/regions{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id) {
            //var region = dbContext.Regions.Find(id);

            var region = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if(region == null)
            {
                return NotFound();
            }

            return Ok(region);
        }
    }
}
