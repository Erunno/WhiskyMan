using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiskyMan.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BottlesController : ControllerBase
    {
        [HttpGet("all-active")]
        public async Task<IActionResult> GetActiveBottlesForView()
        {
            return Ok(new List<object>
            {
                new {Id= 2, Name ="bottleName 2", Distillery = "distillery 2", ShotPrice = 55, PictureUrl = "https://bottlesandstories.cz/1245-large_default/glenfiddich-12-yo-07l-40.jpg" },
                new {Id= 3, Name ="bottleName 3", Distillery = "distillery 3", ShotPrice = 65, PictureUrl = "https://bottlesandstories.cz/1245-large_default/glenfiddich-12-yo-07l-40.jpg" },
                new {Id= 4, Name ="bottleName 4", Distillery = "distillery 4", ShotPrice = 75, PictureUrl = "https://bottlesandstories.cz/1245-large_default/glenfiddich-12-yo-07l-40.jpg" },
                new {Id= 1, Name ="bottleName 1", Distillery = "distillery 1", ShotPrice = 45, PictureUrl = "https://bottlesandstories.cz/1245-large_default/glenfiddich-12-yo-07l-40.jpg" },
                new {Id= 1, Name ="bottleName 1", Distillery = "distillery 1", ShotPrice = 45, PictureUrl = "https://bottlesandstories.cz/1245-large_default/glenfiddich-12-yo-07l-40.jpg" },
                new {Id= 1, Name ="bottleName 1", Distillery = "distillery 1", ShotPrice = 45, PictureUrl = "https://bottlesandstories.cz/1245-large_default/glenfiddich-12-yo-07l-40.jpg" },
                new {Id= 1, Name ="bottleName 1", Distillery = "distillery 1", ShotPrice = 45, PictureUrl = "https://bottlesandstories.cz/1245-large_default/glenfiddich-12-yo-07l-40.jpg" },
                new {Id= 1, Name ="bottleName 1", Distillery = "distillery 1", ShotPrice = 45, PictureUrl = "https://bottlesandstories.cz/1245-large_default/glenfiddich-12-yo-07l-40.jpg" },
                new {Id= 1, Name ="bottleName 1", Distillery = "distillery 1", ShotPrice = 45, PictureUrl = "https://bottlesandstories.cz/1245-large_default/glenfiddich-12-yo-07l-40.jpg" },
                new {Id= 1, Name ="bottleName 1", Distillery = "distillery 1", ShotPrice = 45, PictureUrl = "https://bottlesandstories.cz/1245-large_default/glenfiddich-12-yo-07l-40.jpg" },
                new {Id= 1, Name ="bottleName 1", Distillery = "distillery 1", ShotPrice = 45, PictureUrl = "https://bottlesandstories.cz/1245-large_default/glenfiddich-12-yo-07l-40.jpg" },
            });
        } 
    }
}
