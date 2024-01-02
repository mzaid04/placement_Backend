using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using placement_Backend.DTOs;
using placement_Backend.Models;

namespace placement_Backend.Controllers
{

    [Route("/api/[controller]")]
    [ApiController]
    public class PlacementsController : ControllerBase
    {
        public AppDbContext Context = new AppDbContext(new DbContextOptions<AppDbContext>());


        [Route("get")]
        [HttpGet]
        public async Task<IActionResult> get()
        {
            var placements = await Context.Placements.ToListAsync();
            return Ok(placements);
        }

        [Route("get/{PlacementId}")]
        [HttpGet]
        public async Task<IActionResult> get(int PlacementId)
        {
            Console.WriteLine(PlacementId);

            var placements = await Context.Placements.FirstOrDefaultAsync(x => x.Id == PlacementId);
            if (placements == null)
            {
                return NotFound(new { message = "Placement you are looking for has been closed or deleted." });
            }
            return Ok(placements);
        }



        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> add([FromBody] PlacementDTO placementDto)
        {
            try
            {

                if (placementDto.Title is null || placementDto.Description is null)
                {
                    var s = ModelState.Values.Select(x => x.Errors);
                    return Ok(s);
                    return StatusCode(403, new ResultDTO<PlacementDTO>
                    {
                        Message = "Something Went wrong on server.",
                        Result = new PlacementDTO
                        {
                            Title = "Title is required",
                            Description = "Description is required"
                        }
                    });


                }


                var palcement = await Context.Placements.AddAsync(new Placement
                {
                    Description = placementDto.Description,
                    Title = placementDto.Title
                });


                int result = await Context.SaveChangesAsync();

                if (result == 0)
                    return BadRequest("message");

                return Ok(palcement.Entity);

            }
            catch (Exception error)
            {
                return BadRequest("message");

            }
        }


        [Route("update/{placementId}")]
        [HttpPut]
        public async Task<IActionResult> update(int placementId, [FromBody] PlacementDTO placementDto)
        {

            try

            {
                Placement? placement = await Context.Placements.FirstOrDefaultAsync(x => x.Id == placementId);

                if (placement == null)
                    return NotFound(new { Message = "Placement not found" });

                placement.Title = placementDto.Title;
                placement.Description = placementDto.Description;


                await Context.SaveChangesAsync();

                return Ok(placement);
            }
            catch (Exception error)
            {

                return BadRequest();

            }
        }
    }
}
