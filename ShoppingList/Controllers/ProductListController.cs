using Microsoft.AspNetCore.Mvc;
using ShoppingList.Service;
using ShoppingList.Data;
using ShoppingList.Models.Models;
using ShoppingList.Service.Services;
using Microsoft.AspNetCore.Authorization;
using ShoppingList.Service.Response;
using System.Security.Claims;

[Route("api/user/productlist")]
[ApiController]
public class ProductListController : ControllerBase
{
    private readonly IProductListService _productListService;

    public ProductListController(IProductListService productListService)
    {
        _productListService = productListService;
    }

    [HttpGet("getall")]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int page)
    {
        if (Guid.TryParse(User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier).Value, out Guid UserId))
        {
            var result = await _productListService.GetAll(UserId, page);
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
            var result = await _productListService.Get(UserId, id);
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
    public async Task<IActionResult> Post([FromBody] ProductListResponse res)
    {
        if (Guid.TryParse(User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier).Value, out Guid UserId))
        {
            var result = await _productListService.Create(UserId, res);
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
    public async Task<IActionResult> Patch(Guid Id, [FromQuery] bool iscompeleted)
    {

        if (Guid.TryParse(User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier).Value, out Guid UserId))
        {
            var result = await _productListService.Update(UserId, Id, iscompeleted);
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
            var result = await _productListService.Delete(UserId, Id);
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