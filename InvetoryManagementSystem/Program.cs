


using Microsoft.EntityFrameworkCore;
using InvetoryManagementSystem.Infrastructure.Data;
using DomainLayer.Contracs;
using Persistence.Reporasitores;
using ServiceAbstraction;
using Service;
using Service.Mapping;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DomainLayer.Models.IdentityModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
//using DomainLayer.Models.IdentityModule;


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
            /////////////////////
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
            ///////////
            // builder.Services.AddEndpointsApiExplorer();
            #region Swagger
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Inventory Management API",
                    Version = "v1"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter JWT token as: Bearer {your token}"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
            });
            #endregion
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<InventoryManagementSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<InventoryManagementSystemContext>().AddDefaultTokenProviders();
        
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options => { 
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWTToken:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWTToken:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTToken:securiytkey"]))

                };
           
            


            });
         

              
           

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(x => x.AddProfile(new ItemProfile()));
            builder.Services.AddAutoMapper(x => x.AddProfile(new ReceivingOrderProfile()));
            builder.Services.AddAutoMapper(x => x.AddProfile(new SerialProfile()));
            builder.Services.AddAutoMapper(x => x.AddProfile(new stokbalanceprofile()));

            //  builder.Services.AddAutoMapper(typeof(Service.AssemplyReference).Assembly);
            builder.Services.AddScoped<IItemService,ItemMasterServices>();
            builder.Services.AddScoped<ISerialService,SerialNumberService>();
            builder.Services.AddScoped<IRecivingOrderService,ReceivingOrderService>();
            builder.Services.AddScoped<IstokBalanceService, Stockbalanceservice>();
            builder.Services.AddScoped<IIdentityService, IdentityService>();

            builder.Services.AddScoped<IServiceManager,ServiceManager>();
            builder.Services.AddScoped<IItemMasterReposatory, ItemMasterReposator>();
            builder.Services.AddScoped<IReceivingOrderReoisatory, RecivingOrderReposatory>();
            builder.Services.AddScoped<ISerialNumberReposatory, SerialNumberReposatory>();
            builder.Services.AddScoped<IstokBalanceReposatory, StokBalance_Reposatory>();
            builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenaricReporasatories<,>));
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var app = builder.Build();

            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //
            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();



          //  InventoryManagementSystemContext Invetory = new InventoryManagementSystemContext();


            
        }
    }
}
