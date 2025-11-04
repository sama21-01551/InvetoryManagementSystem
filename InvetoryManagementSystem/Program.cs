


using Microsoft.EntityFrameworkCore;
using InvetoryManagementSystem.Infrastructure.Data;
using DomainLayer.Contracs;
using Persistence.Reporasitores;
using ServiceAbstraction;
using Service;
using Service.Mapping;


namespace InvetoryManagementSystem
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
            builder.Services.AddDbContext<InventoryManagementSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IServiceManager,ServiceManager>();
            builder.Services.AddAutoMapper(x=>x.AddProfile(new ItemProfile()));
            builder.Services.AddAutoMapper(x => x.AddProfile(new ReceivingOrderProfile()));
            builder.Services.AddAutoMapper(x => x.AddProfile(new SerialProfile()));
            builder.Services.AddScoped<IItemMasterReposatory, ItemMasterReposator>();
            builder.Services.AddScoped<IReceivingOrderReoisatory, RecivingOrderReposatory>();
            builder.Services.AddScoped<ISerialNumberReposatory, SerialNumberReposatory>();

            builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenaricReporasatories<,>));

            var app = builder.Build();

            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();



          //  InventoryManagementSystemContext Invetory = new InventoryManagementSystemContext();


            
        }
    }
}
