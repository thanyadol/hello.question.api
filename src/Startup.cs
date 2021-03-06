﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

//DI
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

//model
using hello.question.api.Models;
using Swashbuckle.AspNetCore.Swagger;

using AutoMapper;
using hello.question.api.Repositories;
using hello.question.api.Extensions;
using hello.question.api.Middleware;
using hello.question.api.Services;
using hello.question.api.Formatter;

namespace hello.question.api
{
    public class Startup
    {

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the 
        //container.
        public void ConfigureServices(IServiceCollection services)
        {
            //in memory
            //services.AddDbContext<NorthwindContext>(opt =>
                                     //opt.UseInMemoryDatabase("Northwind"));

            services.AddDbContext<NorthwindContext>(options =>
            options.UseMySql(this._configuration.GetConnectionString("NorthwindConnection"),
                     x => x.MigrationsHistoryTable("__EFMigrationsHistory", "dbo")));

            //add an APIs Service
            //services.AddHttpClient<IGoogleService, GoogleService>().SetHandlerLifetime(TimeSpan.FromMinutes(5));

            //for http request information
            services.AddHttpContextAccessor();

            //http client factory
            //Set 5 min as the lifetime for the HttpMessageHandler objects in the pool used for the Catalog Typed Client 
            //services.AddHttpClient<IClientService, ClientService>()
            //.SetHandlerLifetime(TimeSpan.FromMinutes(5));

            //register DI
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IChoiseRepository, ChoiseRepository>();
            services.AddScoped<ISubChoiseRepository, SubChoiseRepository>();
            services.AddScoped<IParticipantRepository, ParticipantRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<ISubQuestionRepository, SubQuestionRepository>();

            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IQuestionAnswerService, QuestionAnswerService>();
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IParticipantService, ParticipantService>();
            services.AddScoped<IChoiseService, ChoiseService>();


            // services.AddScoped<NorthwindContext>();
            services.AddApiVersioning();

            //enable Cross origin
            services.AddCors(o => o.AddPolicy("AllowCors", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins(_configuration.GetValue<string>("AppSettings:CorsUrl", string.Empty))
                    //.WithOrigins(Environment.Configuration.Instance.GetCorsURL())
                    .AllowCredentials();
            }));

            //register memory cache
            services.AddMemoryCache();

            // Add application services.
            //services.AddTransient<IEmailSender, AuthMessageSender>();
            //services.AddTransient<ISmsSender, AuthMessageSender>();

            // Adds Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Version = "v1",
                    Title = "hello.question.api",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "thanyadol",
                        Email = string.Empty,
                        Url = "https://twitter.com/thanyadol"
                    },
                    License = new License
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    }
                });
            });

            //register custom filter
            //services.AddScoped<EnsureUserAuthorizeInAsync>();

            // ...
            services.AddMvc(options => {
                 options.OutputFormatters.Insert(0, new CsvMediaTypeFormatter());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseAuthentication();
            app.UseCors("AllowCors");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for 
                // production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Adds Swagger
            if (_configuration.GetValue<bool>("AppSettings:Swagger:IsEnabled", false) == true)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "VOT-API V1");
                });
            }

            //for dependency injection service
            app.ApplicationServices.GetService<IDisposable>();

            app.ConfigureCustomExceptionMiddleware();

            //Add our new middleware to the pipeline
            app.UseMiddleware<LoggingMiddleware>();


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
