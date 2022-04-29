using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nexos.Api.Services;
using Nexos.Api.Data;
using Nexos.Api.Data.Repository;

namespace Nexos.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson(options =>
              options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddCors(options =>
            {
                options.AddPolicy("CORS_POLICY", builder =>
                {
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                });
            });

            services.AddDbContext<NexosContext>(options =>
            {
                options.UseInMemoryDatabase("NexosTest");               
            });    

            services.AddControllers();           

            services.AddScoped<IBookService, BookService>();

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IEditorialRepository, EditorialRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CORS_POLICY");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
