using Microsoft.EntityFrameworkCore;
using Nexos.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Api.Data.Repository
{
    public class BookRepository : IBookRepository
    {   
        private readonly NexosContext _context;

        public BookRepository(NexosContext context)
        {
            _context = context;
        }      

        public async Task<ICollection<Book>> getAll()
        {
           return await _context.Books
                .Include(e=>e.Editorial)
                .Include(a=>a.Author)
                .ToListAsync();
        }

        public async Task<Book> addBook(Book newBook)
        {
            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();
            newBook = await this.getById(newBook.Id);
            return newBook;
        }

        public async Task<Book> getById(int id)
        {
            return await _context.Books
                .Include(b => b.Editorial)
                .Include(b => b.Author)
                .Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> numbersBooksByEditorial(int idEditorial)
        {
            return await _context.Books.Where(b => b.EditorialId == idEditorial).CountAsync();
        }

        public async Task<ICollection<Book>> getBooksByYear(int year)
        {
            return await _context.Books
                        .Include(a => a.Author)
                        .Include(e => e.Editorial)
                        .Where(b => b.Year == year).ToListAsync();
        }

        public async Task<ICollection<Book>> getBooksByAuthorOrName(string filter)
        {
            var books = await _context.Books
                        .Include(a=>a.Author)
                        .Include(e => e.Editorial)
                        .Where(b => b.Tittle.ToLower().Contains(filter) || b.Author.FullName.ToLower().Contains(filter))
                        .ToListAsync();
            return books;
        }
    }
}
