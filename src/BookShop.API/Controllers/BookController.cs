using BookShop.Application.DTOs;
using BookShop.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.API.Controllers;

[ApiController]
[Route("api/books")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<BookSummaryDto>>> Get([FromQuery] BookFilterDto filter)
    {
        try
        {
            var books = await _bookService.GetBooksAsync(filter);
            return Ok(books);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetBook([FromRoute] int id)
    {
        try
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return Ok(book);
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

    [HttpPost]
    [Authorize(Roles = "Admin,Inventory")]
    public async Task<ActionResult<int>> CreateBook([FromBody] CreateBookDto dto)
    {
        try
        {
            var createdId = await _bookService.CreateBookAsync(dto);
            return CreatedAtAction(
                actionName: nameof(GetBook), 
                controllerName: "Book", 
                routeValues: new { id = createdId }, 
                value: createdId
            );
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,Inventory")]
    public async Task<IActionResult> DeleteBook([FromRoute] int id)
    {
        try
        {
            await _bookService.DeleteBookAsync(id);
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
}