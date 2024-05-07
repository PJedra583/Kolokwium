namespace WebApplication1.Models.DTOs;

public class BookDTO
{
    public BookDTO(int id, string title, List<Author> authors)
    {
        this.id = id;
        this.title = title;
        this.authors = authors;
    }

    public int id { get; set; }
    public string title { get; set; }
    public List<Author> authors { get; set; }
}