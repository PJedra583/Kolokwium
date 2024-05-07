using WebApplication1.Models;

namespace WebApplication1.Repositories;

public interface IBookRepository
{
    Task<bool> DoesBookExists(int id);
    Task<List<Author>> GetAuthors(int id);
}