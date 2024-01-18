using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

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

            // Get Data From Database - Domain models
            var regionsDomain = dbContext.Regions.ToList();

            // Map Domain Models to DTOs
            var regionsDto = new List<RegionDto>();
            foreach (var region in regionsDomain) {
                regionsDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImgUrl = region.RegionImgUrl
                });
            }

            // Return DTOs

            return Ok(regionsDto);
        }

        // GET REGION BY ID
        // GET: https://localhost:portnumber/api/regions{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id) {
            //var region = dbContext.Regions.Find(id);

            //Get Region Domain Model From Database
            var regionsDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if(regionsDomain == null)
            {
                return NotFound();
            }

            // Map/Convert Region Domain Model to Region DTO
            var regionsDto = new RegionDto
            {
                Id = regionsDomain.Id,
                Code = regionsDomain.Code,
                Name = regionsDomain.Name,
                RegionImgUrl = regionsDomain.RegionImgUrl
            };

            // Return DTO back to client    
            return Ok(regionsDto);
        }
    }
}
