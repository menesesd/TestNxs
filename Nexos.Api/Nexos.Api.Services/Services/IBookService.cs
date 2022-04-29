using Nexos.Api.Services;
using Nexos.Api.Data.Repository;
using Nexos.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Api.Services
{
    public interface IBookService 
    {
        public Task<ICollection<Book>> getAll();
        public Task<Book> addBook(Book newBook);
        public Task<String> addBookValidate(Book newBook);
        public Task<ICollection<Book>> getBooksByFilter(string filter);


    }
}
