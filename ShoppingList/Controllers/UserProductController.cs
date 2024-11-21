﻿using Microsoft.AspNetCore.Mvc;
using ShoppingList.Service;
using ShoppingList.Data.ModelMap;
using ShoppingList.Models.Models;
using ShoppingList.Service.Services;
using Microsoft.AspNetCore.Authorization;
using ShoppingList.Service.Response;
using System.Security.Claims;
namespace ShoppingList.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class UserProductController : ControllerBase
    {
        private readonly IUserProductService _userProductService;

        public UserProductController(IUserProductService userProductService)
        {
            _userProductService = userProductService;
        }

        [HttpGet("getall")]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] int page)
        {
            if (Guid.TryParse(User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier).Value, out Guid UserId))
            {
                var result = await _userProductService.GetAll(UserId, page);
                if (result.Status == 200)
                {
                    return Ok(result);
                }
                else if (result.Status == 404)
                {
                    return NotFound(result);
                }
                else
                    return BadRequest(result);
            }
            return BadRequest();
        }
        [HttpGet("get/{id}")]
        [Authorize]
        public async Task<IActionResult> Get(Guid id)
        {

            if (Guid.TryParse(User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier).Value, out Guid UserId))
            {
                var result = await _userProductService.Get(UserId, id);
                if (result.Status == 200)
                {
                    return Ok(result);
                }
                else if (result.Status == 404)
                {
                    return NotFound(result);
                }
                else
                    return BadRequest(result);
            }
            return BadRequest();
        }
        [HttpPost("Create")]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] UserProductResponse res)
        {
            if (Guid.TryParse(User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier).Value, out Guid UserId))
            {
                var result = await _userProductService.Create(UserId, res);
                if (result.Status == 200)
                {
                    return Ok(result);
                }
                else if (result.Status == 404)
                {
                    return NotFound(result);
                }
                else
                    return BadRequest(result);
            }
            return BadRequest();
        }

        [HttpDelete("delete/{Id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid Id)
        {

            if (Guid.TryParse(User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier).Value, out Guid UserId))
            {
                var result = await _userProductService.Delete(UserId, Id);
                if (result.Status == 200)
                {
                    return Ok(result);
                }
                else if (result.Status == 404)
                {
                    return NotFound(result);
                }
                else
                    return BadRequest(result);
            }
            return BadRequest();

        }
        [HttpPatch("update/{Id}")]
        [Authorize]
        public async Task<IActionResult> Patch(Guid Id, [FromBody] UserProductUpdateResponse res)
        {

            if (Guid.TryParse(User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier).Value, out Guid UserId))
            {
                var result = await _userProductService.Update(UserId, Id, res);
                if (result.Status == 200)
                {
                    return Ok(result);
                }
                else if (result.Status == 404)
                {
                    return NotFound(result);
                }
                else
                    return BadRequest(result);
            }
            return BadRequest();
        }
    }

}
