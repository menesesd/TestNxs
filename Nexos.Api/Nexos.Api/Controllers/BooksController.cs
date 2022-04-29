using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nexos.Api.Services;
using Nexos.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {

        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {            
            return Ok( await _bookService.getAll());
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book newBook)
        {
            string message = await _bookService.addBookValidate(newBook);

            if (!String.IsNullOrEmpty(message))
            {
                return BadRequest(new { message });
            }

            return Ok(await _bookService.addBook(newBook));
        }

        [HttpGet("filter/")]
        public async Task<IActionResult> GetBooksByFilter([FromQuery] string filter)
        {
            if (String.IsNullOrEmpty(filter))
            {
                return BadRequest();
            }
            return Ok(await _bookService.getBooksByFilter(filter));
        }

    }
      
}
