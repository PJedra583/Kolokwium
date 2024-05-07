namespace WebApplication1.Models;

public class Author
{
    public Author(int id, string firstname, string lastname)
    {
        this.id = id;
        this.firstname = firstname;
        this.lastname = lastname;
    }

    public int id { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }

}