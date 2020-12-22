using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiskyMan.Models.BottleDescription;
using WhiskyMan.Repositories.Interfaces;

namespace WhiskyMan.API.Controllers
{
    [ApiController]
    [Route("api/bottle-descriptions")]
    public class BottleDescriptionsController : ControllerBase
    {
        private readonly IBottleDescriptionRepository repo;

        public BottleDescriptionsController(
            IBottleDescriptionRepository repo)
        {
            this.repo = repo;
        }

        [Authorize]
        [HttpPost("add-description")]
        public async Task<IActionResult> AddDescription(BottleDescriptionForAddition bottleDescription)
        {
            int id = await repo.AddBottleDescription(bottleDescription);
            return Ok(new { DescriptionId = id });
        }

        [HttpGet("active-references")]
        public async Task<IActionResult> GetActiveBottleDescriptionReferences()
            => Ok(await repo.GetActiveBottleDescriptionsReferences());
    }
}
