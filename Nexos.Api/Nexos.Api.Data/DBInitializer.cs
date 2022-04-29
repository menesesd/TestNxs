using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nexos.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexos.Api.Data
{
    public static class DBInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new NexosContext(serviceProvider.GetRequiredService<DbContextOptions<NexosContext>>()))
            {
                if (!context.Editorials.Any())
                {
                    context.Editorials.AddRange(
                       new Editorial
                       {
                           Id = 1,
                           Name = "Editorial 1",
                           AddressCorrespondence = "Direccion de la editorial 1",
                           Phone = 123456789,
                           MaximumBook = 2,
                           Email = "editorialuno@pruebanexos.com"
                       },
                       new Editorial
                       {
                           Id = 2,
                           Name = "Editorial 2",
                           AddressCorrespondence = "Direccion de la editorial 2",
                           Phone = 987654321,
                           MaximumBook = -1,
                           Email = "editorialdos@pruebanexos.com"
                       },
                       new Editorial
                         {
                             Id = 3,
                             Name = "Editorial 3",
                             AddressCorrespondence = "Direccion de la editorial 3",
                             Phone = 987654321,
                             MaximumBook = -1,
                             Email = "editorialtres@pruebanexos.com"
                         }
                   );
                    context.SaveChanges();
                }

                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(
                      new Author
                      {
                          Id = 1,
                          FullName = "Carlos Manrique",
                          DateOfBirth = new DateTime(1995, 08, 20),
                          CityOrigin = "Medellin",
                          Email = "carlosmanrique@pruebanexos.com"
                      },
                        new Author
                        {
                            Id = 2,
                            FullName = "Ivan Godoy",
                            DateOfBirth = new DateTime(1994, 05, 20),
                            CityOrigin = "Medellin",
                            Email = "ivangodoy@pruebanexos.com"
                        }
                    );
                    context.SaveChanges();
                }


                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book
                        {
                            Tittle = "Title book 1",
                            Gender = "Action",
                            NumberPages = 450,
                            Year = 1996,
                            AuthorId = 1,
                            EditorialId = 2
                        },
                        new Book
                        {
                            Tittle = "Title book 2",
                            Gender = "Action",
                            NumberPages = 500,
                            Year = 1996,
                            AuthorId = 1,
                            EditorialId = 2
                        },
                        new Book
                        {
                            Tittle = "Title book 3",
                            Gender = "Comedy",
                            NumberPages = 650,
                            Year = 2008,
                            AuthorId = 2,
                            EditorialId = 3
                        },
                        new Book
                        {
                            Tittle = "Title book 4",
                            Gender = "Comedy",
                            NumberPages = 700,
                            Year = 2008,
                            AuthorId = 2,
                            EditorialId = 3
                        }
                    );
                    context.SaveChanges();
                }





            }
        }
    }
}
