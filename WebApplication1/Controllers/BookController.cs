using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories;
namespace WebApplication1.Controllers;


public class BookController : ControllerBase
{
    private readonly IBookRepository _bookRepository;
    public BookController(BookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet("api/books/{id}/authors")]
    public async Task<IActionResult> getAuthors(int id)
    {
        if (!await _bookRepository.DoesBookExists(id))
            return NotFound($"Book with given ID - {id} doesn't exist");

        var animal = await _bookRepository.GetAuthors(id);
            
        return Ok(animal);
    }
}