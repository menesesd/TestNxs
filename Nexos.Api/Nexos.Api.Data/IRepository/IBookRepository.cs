using Nexos.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Api.Data.Repository
{
    public interface IBookRepository 
    {
        public Task<Book> getById(int id);
        public Task<ICollection<Book>> getAll();
        public Task<Book> addBook(Book newBook);
        public Task<int> numbersBooksByEditorial(int idEditorial); 
        public Task<ICollection<Book>> getBooksByYear(int year);  
        public Task<ICollection<Book>> getBooksByAuthorOrName(string filter);


    }
}
