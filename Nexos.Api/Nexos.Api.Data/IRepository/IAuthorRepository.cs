using Nexos.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Api.Data.Repository
{
    public interface IAuthorRepository
    {
        public Task<Author> getById(int id);     


    }
}
