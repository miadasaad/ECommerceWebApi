
using BLayer.Managers.Categories;
using BLayer.Managers.Customers;
using BLayer.Managers.Products;
using DALayer.Data.Context;
using DALayer.Data.Models;
using DALayer.Repos.Categories;
using DALayer.Repos.Customers;
using DALayer.Repos.Order;
using DALayer.Repos.OrderProducts;
using DALayer.Repos.Products;
using DALayer.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace E_Commerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connection_string = builder.Configuration.GetConnectionString("Ecommerce");
            builder.Services.AddDbContext<ECommerceDb>(options => options.UseSqlServer(connection_string));
            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy(name: MyAllowSpecificOrigins,
            //                      policy =>
            //                      {
            //                          policy.AllowAnyOrigin()
            //                          .AllowAnyHeader()
            //                          .AllowAnyMethod();
            //                      });
            //});
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IProduct, ProductRepo>();
            builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
            builder.Services.AddScoped<IOrder, OrderRepo>();
            builder.Services.AddScoped<IOrderProductRepo, OrderProductRepo>();
            builder.Services.AddScoped<ICustomerManger, CustomerManager>();
            builder.Services.AddScoped<IProductManager , ProductManager>();
            builder.Services.AddScoped<Icategory ,CategoryRepo>();
            builder.Services.AddScoped<ICategoryManager, CategoryManager>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}