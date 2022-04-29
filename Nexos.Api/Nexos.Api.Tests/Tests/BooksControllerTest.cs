using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using Xunit;
using FluentAssertions;
using Nexos.Api.Domain;
using Newtonsoft.Json;

namespace Nexos.Api.Tests
{

    public class BooksControllerTest : IntegrationTestBuilder
    {
             

       [Fact]
        public async void Get_Books_Success()
        {        
            HttpResponseMessage respuesta = null;
            try
            {
                var response = this.TestClient.GetAsync($"/api/books").Result;
                response.EnsureSuccessStatusCode();

                var result = JsonConvert.DeserializeObject<Book[]>(
                     await response.Content.ReadAsStringAsync()
                );             
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                Assert.IsType<Book[]>(result);
            }
            catch (Exception)
            {
                respuesta.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }
        }

        [Fact]
        public async void Add_Book_Editorial_Not_Exists()
        {

            var context = GetInMemoryContext();

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

            var errorMessage = "La editorial no está registrada";
            HttpResponseMessage response = null;
            try
            {              
                Book newBook = new Book
                {
                    Tittle = "Title test",
                    Gender = "Action",
                    NumberPages = 500,
                    Year = 1996,
                    AuthorId = 1,
                    EditorialId = 1000
                };               
                response = this.TestClient.PostAsync($"/api/books", newBook, new JsonMediaTypeFormatter()).Result;
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                var responseContent = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(response.Content.ReadAsStringAsync().Result);
                responseContent["message"].Should().Be(errorMessage);
            }
        }

        [Fact]
        public async void Add_Book_Author_Not_Exists()
        {
            var context = GetInMemoryContext();

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
                     }
                 );
            context.SaveChanges();

            var errorMessage = "El autor no está registrado";
            HttpResponseMessage response = null;
            try
            {
                Book newBook = new Book
                {
                    Tittle = "Title test",
                    Gender = "Action",
                    NumberPages = 500,
                    Year = 1996,
                    AuthorId = 1000,
                    EditorialId = 1
                };
                response = this.TestClient.PostAsync($"/api/books", newBook, new JsonMediaTypeFormatter()).Result;
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                var responseContent = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(response.Content.ReadAsStringAsync().Result);
                responseContent["message"].Should().Be(errorMessage);
            }
        }

        [Fact]
        public async void Add_Book_Editorial_Limit_Maximum_Books()
        {
            var context = GetInMemoryContext();

            context.Editorials.AddRange(
                     new Editorial
                     {
                         Id = 1,
                         Name = "Editorial 1",
                         AddressCorrespondence = "Direccion de la editorial 1",
                         Phone = 123456789,
                         MaximumBook = 1,
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
                     }
                 );
            context.SaveChanges();

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


            context.Books.Add(             
                
                new Book
                {
                    Tittle = "Title test",
                    Gender = "Action",
                    NumberPages = 500,
                    Year = 1996,
                    AuthorId = 1,
                    EditorialId = 1
                }        
            );
            context.SaveChanges();

            var errorMessage = "No es posible registrar el libro, se alcanzó el máximo permitido";
            HttpResponseMessage response = null;
            try
            {
                Book newBook = new Book
                {
                    Tittle = "Title test",
                    Gender = "Action",
                    NumberPages = 500,
                    Year = 1996,
                    AuthorId = 1,
                    EditorialId = 1
                };
                response = this.TestClient.PostAsync($"/api/books", newBook, new JsonMediaTypeFormatter()).Result;
                response.EnsureSuccessStatusCode();
                var responseContent = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(response.Content.ReadAsStringAsync().Result);
                responseContent["message"].Should().Be(errorMessage);
            }
            catch (Exception)
            {
                var responseContent = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(response.Content.ReadAsStringAsync().Result);
                responseContent["message"].Should().Be(errorMessage);
            }
        }

        [Fact]
        public async void Add_Book_Success()
        {

            var context = GetInMemoryContext();

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
                     }
                 );
            context.SaveChanges();

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

            HttpResponseMessage response = null;
            try
            {
                Book newBook = new Book
                {
                    Id = 0,
                    Tittle = "Title test",
                    Gender = "Action",
                    NumberPages = 500,
                    Year = 1996,
                    AuthorId = 1,
                    EditorialId = 2
                };
                response = this.TestClient.PostAsync($"/api/books", newBook, new JsonMediaTypeFormatter()).Result;
                response.EnsureSuccessStatusCode();

                var responseContent = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, Object>>(response.Content.ReadAsStringAsync().Result);
                responseContent["id"].ToString().Should().NotBe("0");
            }
            catch (Exception)
            {
                var responseContent = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, Object>>(response.Content.ReadAsStringAsync().Result);
                responseContent["id"].ToString().Should().NotBe("0");
            }
        }

        [Fact]        
        public async void Search_Book_Failed()
        {       
         
            HttpResponseMessage response = null;
            try
            {
               
                response = this.TestClient.GetAsync($"/api/books/filter?filter={""}").Result;               
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
             
            }
            catch (Exception)
            {
               
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        [Fact]
        public async void Search_Book_Success()
        {

            HttpResponseMessage response = null;
            try
            {

                response = this.TestClient.GetAsync($"/api/books/filter?filter={"1996"}").Result;
                var result = JsonConvert.DeserializeObject<Book[]>(
                     await response.Content.ReadAsStringAsync()
                );
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                Assert.IsType<Book[]>(result);

            }
            catch (Exception)
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }



    }

}
