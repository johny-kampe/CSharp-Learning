using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository) { 
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
        }
        // GET ALL REGIONS
        // GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
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
            var regionsDomain = await regionRepository.GetAllAsync();

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
        public async Task<IActionResult> GetById([FromRoute] Guid id) {
            //var region = dbContext.Regions.Find(id);

            //Get Region Domain Model From Database
            var regionsDomain = await regionRepository.GetByIdAsync(id);

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

        // POST: To Create New Region
        // POST: https://localhost:portnumber/api/regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map or Convert DTO to Domain Model
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImgUrl = addRegionRequestDto.RegionImgUrl
            };

            //Use Domain Model to create Region
            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

            //Mapping Domain Model to DTO
            var regionDTO = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImgUrl = regionDomainModel.RegionImgUrl
            };

            return CreatedAtAction(nameof(GetById), new {id = regionDTO.Id}, regionDTO);
        }

        // PUT: Update Region
        // POST: https://localhost:portnumber/api/regions{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            // Map DTO to Domain Model
            var regionDomainModel = new Region
            {
                Code = updateRegionRequestDto.Code,
                Name = updateRegionRequestDto.Name,
                RegionImgUrl = updateRegionRequestDto.RegionImgUrl
            };

            // Check if Region exists
            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Convert Domain Model to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImgUrl = regionDomainModel.RegionImgUrl
            };

            return Ok(regionDto);
        }

        // Delete Region
        // DELETE: https://localhost:portnumber/api/regions{id}

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // Check if Region exists
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // Optional: return the deleted object back
            // Map Domain Model to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImgUrl = regionDomainModel.RegionImgUrl
            };

            return Ok(regionDto);
        }

    }
}
