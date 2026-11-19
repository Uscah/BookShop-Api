using BookShop.Application.DTOs;
using BookShop.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.API.Controllers;

[ApiController]
[Route("api/books/{bookId}/editions}")]
public class BookEditionController : ControllerBase
{
    private readonly IBookEditionService _bookEditionService;

    public BookEditionController(IBookEditionService bookEditionService)
    {
        _bookEditionService = bookEditionService;
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin, Inventory")]
    public async Task<IActionResult> CreateEdition([FromRoute] int bookId, [FromBody] CreateBookEditionDto dto)
    {
        try
        {
            var createId = await _bookEditionService.CreateEditionAsync(bookId, dto);
            return CreatedAtAction(
                actionName: nameof(BookController.GetBook), 
                controllerName: "Book", 
                routeValues: new { id = bookId }, 
                value: createId
            );
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,Inventory")]
    public async Task<IActionResult> DeleteEdition([FromRoute] int bookId, [FromRoute] int id)
    {
        try
        {
            await _bookEditionService.DeleteEditionAsync(bookId, id);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("{id}")]
    [Authorize(Roles = "Admin,Inventory")]
    public async Task<IActionResult> UpdateEdition([FromRoute] int bookId, [FromRoute] int id, [FromBody] UpdateBookEditionDto dto)
    {
        try
        {
            await _bookEditionService.UpdateEditionAsync(bookId, id, dto);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}