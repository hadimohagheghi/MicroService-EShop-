
using DiscountService.GRPC;
using DiscountService.Infrastructure.Contexts;
using DiscountService.Infrastructure.MappingProfile;
using DiscountService.Model.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace DiscountService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddGrpc();

            builder.Services.AddDbContext<DiscountDataBaseContext>(o => o.UseSqlServer
                (builder.Configuration["DiscountConnection"]));

            builder.Services.AddAutoMapper(typeof(DiscountMappingProfile));

            builder.Services.AddTransient<IDiscountService, DiscountService.Model.Services.DiscountService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //    {
            //        endpoints.MapGrpcService<GRPCDiscountService>();

            //        endpoints.MapControllers();
            //    }
            //);


            app.MapGrpcService<GRPCDiscountService>();

            app.MapControllers();

            app.Run();
        }
    }
}
