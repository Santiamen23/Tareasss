using Microsoft.EntityFrameworkCore;
using TareaTecWeb.Data;
using TareaTecWeb.Models;

namespace TareaTecWeb.Repositories
{
    public class BookRepository : IBookRepository
    {
        private AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateBookAsync(Book book)
        {
            await _context.books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBook(Book book)
        {
            _context.books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            return await _context.books.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task UpdateBookAsync(Book book)
        {
            _context.books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}
