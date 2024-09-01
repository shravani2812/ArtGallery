﻿using ArtGalleryAPI.Models.Domain;
using ArtGalleryAPI.Models.Dto;
using ArtGalleryAPI.Services.Implementation;
using ArtGalleryAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArtGalleryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserInterface appUserService;

        public AppUserController(IAppUserInterface appUserService)
        {
            this.appUserService = appUserService;
        }
        /// <summary>
        /// returns all the users from the database
        /// </summary>
        /// <returns>list of all users</returns>
        [HttpGet]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await appUserService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// returns the filtered user record based on id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>filtered user</returns>
        [HttpGet]
        [Route("{userId}")]
        [Authorize]
        public async Task<IActionResult> GetUserById([FromRoute] string userId)
        {
            try
            {
                var user = await appUserService.GetUserByIdAsync(userId);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// returns the filtered user record based on email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>filtered user</returns>
        [HttpGet]
        [Route("admin/getUserByEmail/{email}")]
        [Authorize]
        public async Task<IActionResult> GetUserByEmail([FromRoute] string email)
        {
            try
            {
                var user = await appUserService.GetUserByEmailAsync(email);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// updates the existing user in db
        /// </summary>
        /// <param name="updatedUser"></param>
        /// <returns>updated user</returns>
        [HttpPut]
        [Route("{userId}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateCategory([FromRoute] string userId, [FromBody] UpdateAppUserDto updatedAppUser)
        {
            try
            {
                var result = await appUserService.UpdateUserAsync(userId, updatedAppUser);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// delete a user in db based on id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>bool representing state of operation</returns>
        [HttpDelete]
        [Route("{userId}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteCategory([FromRoute] string userId)
        {
            try
            {
                var deleteStatus = await appUserService.DeleteUserAsync(userId);
                return Ok(deleteStatus);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
