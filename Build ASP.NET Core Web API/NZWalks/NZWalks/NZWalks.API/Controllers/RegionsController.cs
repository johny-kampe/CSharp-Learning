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
            var regions = dbContext.Regions.ToList();
            //var regions = new List<Region>
            //{
            //    new Region
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Auckland Region",
            //        Code = "AKL",
            //        RegionImgUrl = "https://images.pexels.com/photos/11579523/pexels-photo-11579523.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
            //    },
            //    new Region
            //    {
            //        Id= Guid.NewGuid(),
            //        Name = "Wellington Region",
            //        Code = "WLG",
            //        RegionImgUrl = "https://images.pexels.com/photos/403781/pexels-photo-403781.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
            //    }
            //};

            return Ok(regions);
        }
    }
}
