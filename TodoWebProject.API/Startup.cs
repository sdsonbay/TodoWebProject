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
using TodoWebProject.Controllers;
using TodoWebProject.Data.TodoData;
using TodoWebProject.Data.UserData;
using TodoWebProject.Data.Utils;
using TodoWebProject.Service.TodoService;
using TodoWebProject.Service.UserService;

namespace TodoWebProject
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
            var todoConnectionString = "Server = localhost; Database = TodoDB; Integrated Security = True";
            services.AddSingleton<IProjectDbConnection>(s => new ProjectDbConnection(todoConnectionString));
            
            // Data

            services.AddSingleton<IGetAllTodosDataRequest, GetAllTodosDataRequest>();
            services.AddSingleton<IGetTodoByIdDataRequest, GetTodoByIdDataRequest>();
            services.AddSingleton<IInsertTodoDataRequest, InsertTodoDataRequest>();
            services.AddSingleton<IUpdateTodoByIdDataRequest, UpdateTodoByIdDataRequest>();
            services.AddSingleton<IDeleteTodoByIdDataRequest, DeleteTodoByIdDataRequest>();

            services.AddSingleton<IGetAllUsersDataRequest, GetAllUsersDataRequest>();
            services.AddSingleton<IGetUserByIdDataRequest, GetUserByIdDataRequest>();
            services.AddSingleton<IInsertUserDataRequest, InsertUserDataRequest>();
            
            // Services

            services.AddSingleton<IGetAllTodosServiceRequest, GetAllTodosServiceRequest>();
            services.AddSingleton<IGetTodoByIdServiceRequest, GetTodoByIdServiceRequest>();
            services.AddSingleton<IInsertTodoServiceRequest, InsertTodoServiceRequest>();
            services.AddSingleton<IUpdateTodoByIdServiceRequest, UpdateTodoByIdServiceRequest>();
            services.AddSingleton<IDeleteTodoByIdServiceRequest, DeleteTodoByIdServiceRequest>();
            
            services.AddSingleton<IGetAllUsersServiceRequest, GetAllUsersServiceRequest>();
            services.AddSingleton<IGetUserByIdServiceRequest, GetUserByIdServiceRequest>();
            services.AddSingleton<IInsertUserServiceRequest, InsertUserServiceRequest>();
            
            // Controller

            services.AddSingleton<TodoController>();

            services.AddSingleton<UserController>();
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "TodoWebProject.API", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoWebProject.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}