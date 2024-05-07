using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DTOs;
using WebApplication1.Repositories;
namespace WebApplication1.Controllers;


public class BookController : ControllerBase
{
    private readonly IBookRepository _bookRepository;
    public BookController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet("api/books/{id}/authors")]
    public async Task<IActionResult> getAuthors(int id)
    {
        if (!await _bookRepository.DoesBookExists(id))
            return NotFound($"Book with given ID - {id} doesn't exist");

        var authors = await _bookRepository.GetAuthors(id);
            
        return Ok(authors);
    }

    [HttpGet("api/books")]
    public async Task<IActionResult> addBook(BookDTO bookDto)
    {
        if (!await _bookRepository.DoesBookExists(bookDto.id))
            return NotFound($"Book with given ID - {bookDto.id} doesn't exist");
        var x =_bookRepository.addBook(bookDto);
        return Ok();
    } 
 
}