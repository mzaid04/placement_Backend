﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using placement_Backend.DTOs;
using placement_Backend.Models;
using PlacementModels.Models;

namespace placement_Backend.Controllers
{


    [Route("/api/PlacementApplication")]
    [ApiController]
    public class PlacementApplicationController : ControllerBase
    {

        public AppDbContext Context = new AppDbContext(new DbContextOptions<AppDbContext>());

        [Route("get")]
        [HttpGet]
        public async Task<IActionResult> GetPlacementApplications()
        {
            try
            {
                var placementApplications = await Context.PlacementApplications.ToListAsync();
                return Ok(placementApplications);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [Route("get/{placementApplicationId}")]
        [HttpGet]
        public async Task<IActionResult> GetOnePlacementApplication(int placementApplicationId)
        {
            PlacementApplication? placementApplication = await Context.PlacementApplications.FirstOrDefaultAsync(x => x.Id == placementApplicationId);
            if (placementApplication != null)
            {
                return Ok(placementApplication);
            }
            else return NotFound(new { Message = "Placement you are looking has been deleted or closed." });
        }


        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddPlacementApplication([FromBody] PlacementApplicationDTO placementApplicationDTO)
        {
            try
            {

                var placement = await Context.PlacementApplications.AddAsync(new PlacementApplication
                {
                    Description = placementApplicationDTO.Description,
                    UserId = placementApplicationDTO.UserId,
                    PlacementId = placementApplicationDTO.PlacementId
                });

                int saveSatus = await Context.SaveChangesAsync();


                if (saveSatus <= 0)
                {
                    return BadRequest(new { message = "Could not add Placement." });
                }
                else
                {
                    return Ok(placement.Entity);
                }

            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        //update
        [Route("update/{placementApplicationId}")]
        [HttpPut]
        public async Task<IActionResult> UpdatePlacementApplication(int placementApplicationId, [FromBody] PlacementApplicationDTO placementApplicationDTO)
        {
            try
            {
                PlacementApplication? placement = await Context.PlacementApplications.FirstOrDefaultAsync(x => x.Id == placementApplicationId);


                if (placement != null)
                {
                   
                    placement.Description = placementApplicationDTO.Description;
                    placement.UserId = placementApplicationDTO.UserId;
                    placement.PlacementId = placementApplicationDTO.PlacementId;

                    int saveSatus = await Context.SaveChangesAsync();


                    if (saveSatus <= 0)
                    {
                        return StatusCode(500, new { message = "Could not add Placement." });
                    }
                    else
                    {
                        placement = await Context.PlacementApplications.FirstOrDefaultAsync(x => x.Id == placementApplicationId);
                        return Ok(placement);
                    }


                }
                return NotFound(new { Message = "Placement you are looking has been deleted or closed." });

            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }


    }
}
