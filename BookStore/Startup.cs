using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Controllers.Models;
using BookStore.Controllers.Models.Author;
using BookStore.Controllers.Models.Book;
using BookStore.Models;

using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BookStore
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
            services.AddControllers();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddDbContext<BookStoreContext>(options =>
            options.UseSqlServer(this.Configuration.GetConnectionString("BookStore")));
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", build =>
            {
                build.WithOrigins("http://localhost:4200")
                     .AllowAnyMethod()
                     .AllowAnyHeader();
            }));
            services.AddControllers()

                 .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PostBookValidator>())
                 .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PutBookValidator>())
                 .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BookResponseValidator>())
                 .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AuthorResponseValidator>())
                 .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PostAuthorValidator>())
                 .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PutAuthorValidator>())
                .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //configurations to cosume the Web API from port : 4200 (Angualr App)
            app.UseCors("ApiCorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
