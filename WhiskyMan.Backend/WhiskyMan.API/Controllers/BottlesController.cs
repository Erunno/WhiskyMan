using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiskyMan.Models.Bottle;
using WhiskyMan.Repositories.Interfaces;

namespace WhiskyMan.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BottlesController : ControllerBase
    {
        private readonly IBottleRepository repo;

        public BottlesController(IBottleRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet("all-active")]
        public async Task<IActionResult> GetActiveBottlesForView()
            => Ok(await repo.GetActiveBottleViews());
        

        [HttpPost("add-bottle")]
        public async Task<IActionResult> AddBottle(BottleForAddition bottle)
            => Ok(new 
            { 
                BottleId = await repo.AddBottle(bottle)
            });
    }
}
