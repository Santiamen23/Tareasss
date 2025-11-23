using BooksTW.Models;
using BooksTW.Models.Dtos;

namespace BooksTW.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> getBooks();
        Task<Book?> getBookById(Guid id);
        Task<Book> createBook(CreateBookDto newBook);
        Task<Book?> updateBook(Guid id, UpdateBookDto updatedBook);
    }
}
