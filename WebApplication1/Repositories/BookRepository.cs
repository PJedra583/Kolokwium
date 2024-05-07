using System.Data;
using Microsoft.Data.SqlClient;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Repositories;

public class BookRepository : IBookRepository
{
    private IConfiguration _configuration;
    public BookRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<bool> DoesBookExists(int id)
    {
        var query = "SELECT 1 FROM Book WHERE PK = @ID";

        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        await using SqlCommand command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = query;
        command.Parameters.AddWithValue("@ID", id);

        await connection.OpenAsync();

        var res = await command.ExecuteScalarAsync();

        return res is not null;
    }

    public async Task<BookDTO> GetAuthors(int id)
    {
	    var query = "SELECT books.PK, books.title, authors.PK, authors.First_Name, authors.Last_Name FROM books " +
	                "JOIN books_authors as ba ON books.PK = ba.FK_book " +
	                "JOIN authors ON authors.PK = ba.FK_author " +
	                " WHERE books.PK = @ID";
	    
	    await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
	    await using SqlCommand command = new SqlCommand();

	    command.Connection = connection;
	    command.CommandText = query;
	    command.Parameters.AddWithValue("@ID", id);
	    
	    await connection.OpenAsync();

	    var reader = await command.ExecuteReaderAsync();
	    
	    BookDTO bookDto = null;

	    while (await reader.ReadAsync())
	    {
		    if (bookDto is null)
		    {
			    bookDto = new BookDTO(reader.GetInt32(0), reader.GetString(1), new List<Author>());
		    }
		    bookDto.authors.Add(new Author(reader.GetInt32(2), reader.GetString(3), reader.GetString(4)));
	    }

	    if (bookDto is null) throw new Exception();

	    await reader.CloseAsync();
	    
        return bookDto;
    }
}