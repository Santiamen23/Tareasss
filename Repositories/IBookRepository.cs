using BooksTW.Models;

namespace BooksTW.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task <Book?> GetByIdAsync(Guid id);
        Task CreateBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBook(Book book);
    }
}
