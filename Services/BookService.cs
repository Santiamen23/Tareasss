using BooksTW.Models;
using BooksTW.Models.Dtos;
using BooksTW.Repositories;

namespace BooksTW.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;
        public BookService(IBookRepository repo)
        {
            _repo = repo;
        }
        public async Task<Book> createBook(CreateBookDto newBook)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = newBook.Title,
                Author = newBook.Author,
                Description = newBook.Description
            };
            await _repo.CreateBookAsync(book);
            return book;
        }

        public async Task<Book?> getBookById(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Book>> getBooks()
        {
            return await _repo.GetBooksAsync();
        }

        public async Task<Book?> updateBook(Guid id, UpdateBookDto updatedBook)
        {
            var existingBook = await _repo.GetByIdAsync(id);
            if (existingBook == null) throw new ArgumentNullException(nameof(existingBook), "Book was not found");
            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.Description = updatedBook.Description;
            await _repo.UpdateBookAsync(existingBook);
            return existingBook;
        }
    }
}
