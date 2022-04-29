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
    public class BookService : IBookService
    {

        private readonly IBookRepository _bookRepository;
        private readonly IEditorialRepository _editorialRepository;
        private readonly IAuthorRepository _authorRepository;
        public BookService(IBookRepository bookRepository, IEditorialRepository editorialRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _editorialRepository = editorialRepository;
            _authorRepository = authorRepository;
        }

        public async Task<ICollection<Book>> getAll()
        {          
            return await _bookRepository.getAll();          
        }

        public async Task<Book> addBook(Book newBook)
        {

            return await _bookRepository.addBook(newBook);
        }

        public async Task<string> addBookValidate(Book newBook)
        {
            Editorial editorialExists = await _editorialRepository.getById(newBook.EditorialId);

            if (editorialExists == null)
            {
                return "La editorial no está registrada";
            }

            Author authorExists = await _authorRepository.getById(newBook.AuthorId);

            if (authorExists == null)
            {
                return "El autor no está registrado";
            }

            var numberBooksByEditorial = await _bookRepository.numbersBooksByEditorial(newBook.EditorialId);

            if (editorialExists.MaximumBook != -1 && numberBooksByEditorial == editorialExists.MaximumBook)
            {
                return "No es posible registrar el libro, se alcanzó el máximo permitido" ;
            }

            return String.Empty;
        }

        public async Task<ICollection<Book>> getBooksByFilter(string filter)
        {

            filter = filter.ToLower().Trim();
            if(filter.Length == 4)
            {
                int year;

                bool isParsableToNumber = Int32.TryParse(filter, out year);

                if (isParsableToNumber)
                {
                    return await _bookRepository.getBooksByYear(year);
                }
            }
            
            return await _bookRepository.getBooksByAuthorOrName(filter);
            

        }
    }
}
