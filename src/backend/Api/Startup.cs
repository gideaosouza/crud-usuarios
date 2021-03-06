using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Repository;
using Infrastructure.Repository.Interfaces;
using System.Reflection;
using System.IO;
using Domain.Validations;
using Domain.Entities;
using Infrastructure.Context;

namespace Api
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
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.WithOrigins(Configuration.GetValue<string>("AngularClient")).AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddControllers().AddNewtonsoftJson(options =>
                       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                   );

            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            services.AddTransient<IEscolaridadeService, EscolaridadeService>();
            services.AddTransient<IEscolaridadeRepository, EscolaridadeRepository>();

            services.AddMvc().AddFluentValidation();
            
            services.AddTransient<IValidator<Usuario>, UsuarioValidator>();
            services.AddTransient<IValidator<Escolaridade>, EscolaridadeValidator>();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));

            services.AddSwaggerGen(c =>
            {
                  c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Crud Usuarios",
                        Version = "v1",
                        Description = "Crud Usuarios",
                        Contact = new OpenApiContact
                        {
                            Name = "Gide??o Souza",
                            Url = new Uri("https://github.com/gideaosouza"),
                            Email = "gideao_souza@outlook.com"
                        }
                    }
                    );
                // Set the comments path for the Swagger JSON and UI.**
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }

            app.UseHttpsRedirection();

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
