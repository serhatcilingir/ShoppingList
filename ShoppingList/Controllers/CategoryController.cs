using Microsoft.AspNetCore.Mvc;
using ShoppingList.Service.Services;
using ShoppingList.Models.Models;
using Microsoft.AspNetCore.Authorization;
using ShoppingList.Service.Response;

[Route("api/category")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("getall")]
    [Authorize]
    public async Task<IActionResult> GetAll(int page)
    {
        var categories = await _categoryService.GetAll(page);
        if (categories.Status == 200)
            return Ok(categories);
        else if (categories.Status == 404)
            return NotFound(categories);
        else
            return BadRequest(categories);
    }

    [HttpGet("get/{id}")]
    [Authorize]
    public async Task<IActionResult> Get(Guid id)
    {
        var categories = await _categoryService.Get(id);
        if (categories.Status == 200)
            return Ok(categories);
        else if (categories.Status == 404)
            return NotFound(categories);
        else
            return BadRequest(categories);
    }

    [HttpPatch("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Patch(Guid id, [FromBody] CategoryResponse res)
    {

        var categories = await _categoryService.Update(id, res);
        if (categories.Status == 200)
            return Ok(categories);
        else if (categories.Status == 404)
            return NotFound(categories);
        else
            return BadRequest(categories);
    }

    [HttpPost("create")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post([FromBody] CategoryResponse res)
    {
        var categories = await _categoryService.Create(res);
        if (categories.Status == 200)
            return Ok(categories);
        else if (categories.Status == 404)
            return NotFound(categories);
        else
            return BadRequest(categories);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var categories = await _categoryService.Delete(id);
        if (categories.Status == 200)
            return Ok(categories);
        else if (categories.Status == 404)
            return NotFound(categories);
        else
            return BadRequest(categories);
    }
}