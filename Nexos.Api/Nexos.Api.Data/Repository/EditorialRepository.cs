using Microsoft.EntityFrameworkCore;
using Nexos.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Api.Data.Repository
{
    public class EditorialRepository : IEditorialRepository
    {   
        private readonly NexosContext _context;

        public EditorialRepository(NexosContext context)
        {
            _context = context;
        }      

        public async Task<Editorial> getById(int id)
        {
            return await _context.Editorials.Where(e => e.Id == id).FirstOrDefaultAsync();
        }
    }
}
