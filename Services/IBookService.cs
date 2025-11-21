using TareaTecWeb.Models;
using TareaTecWeb.Models.Dtos;

namespace TareaTecWeb.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> getBooks();
        Task<Book?> getBookById(Guid id);
        Task<Book> createBook(CreateBookDto newBook);
        Task<Book?> updateBook(Guid id, UpdateBookDto updatedBook);
    }
}
