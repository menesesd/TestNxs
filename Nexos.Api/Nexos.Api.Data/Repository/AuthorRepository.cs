using Microsoft.EntityFrameworkCore;
using Nexos.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Api.Data.Repository
{
    public class AuthorRepository : IAuthorRepository
    {   
        private readonly NexosContext _context;

        public AuthorRepository(NexosContext context)
        {
            _context = context;
        }      

        public async Task<Author> getById(int id)
        {
            return await _context.Authors.Where(e => e.Id == id).FirstOrDefaultAsync();
        }
    }
}
