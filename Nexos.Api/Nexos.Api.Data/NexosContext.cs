
using Microsoft.EntityFrameworkCore;
using Nexos.Api.Domain;
using System;


namespace Nexos.Api.Data
{
    public class NexosContext : DbContext 
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Editorial> Editorials { get; set; }
        public DbSet<Book> Books { get; set; }


        public NexosContext(DbContextOptions<NexosContext> options) : base(options)
        {
            

        }
      
    }
}
