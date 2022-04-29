using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Nexos.Api.Data;
using Nexos.Api.Domain;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace Nexos.Api.Tests
{
    public abstract class IntegrationTestBuilder : IDisposable
    {
        protected HttpClient TestClient;
        private bool Disposed;   


        protected IntegrationTestBuilder() {
        
            BootstrapTestingSuite();
        }

        protected void BootstrapTestingSuite()
        {
            Disposed = false;

            var appFactory = new StartupTest();
            TestClient = appFactory.CreateClient();
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
                return;

            if (disposing)
            {
                TestClient.Dispose();
            }

            Disposed = true;
        }


        public NexosContext GetInMemoryContext()
        {
            DbContextOptions<NexosContext> options;
            var builder = new DbContextOptionsBuilder<NexosContext>();
            builder.UseInMemoryDatabase(databaseName: "NexosTest");
            options = builder.Options;
            NexosContext dataContext = new NexosContext(options);
            dataContext.Database.EnsureDeleted();
            dataContext.Database.EnsureCreated();
            return dataContext;
        }


    }


   
}
