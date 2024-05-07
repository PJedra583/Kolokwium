using WebApplication1.Models;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Repositories;

public interface IBookRepository
{
    Task<bool> DoesBookExists(int id);
    Task<BookDTO> GetAuthors(int id);
}