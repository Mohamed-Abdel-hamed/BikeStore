using BikeStore.Models;
using BikeStore.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace BikeStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // Add services to the container 
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddTransient<ICategoryServices, CategoryServices>();
            builder.Services.AddTransient<ICustomerServices, CustomerServices>();
            builder.Services.AddTransient<IBrandServices, BrandServices>();
            builder.Services.AddTransient<IProductServices, ProductServices>();
            builder.Services.AddTransient<IOrderServices, OrderServices>();
            builder.Services.AddTransient<IOrder_itemServices, Order_itemServices>();
            builder.Services.AddTransient<IStoreServices, StoreServices>();
            builder.Services.AddTransient<IStaffServices, StaffServices>();
            builder.Services.AddCors();
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "TestApi",
                    Description = "My First Api",
                    TermsOfService = new Uri(uriString: "https://www.goole.com"),
                    Contact = new OpenApiContact
                    {
                        Name = "Mohamed",
                        Email = "test@domain.com",
                        Url = new Uri(uriString: "https://www.goole.com")

                    },
                    License = new OpenApiLicense
                    {
                        Name = "My License",
                        Url = new Uri(uriString: "https://www.goole.com")
                    }
                });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter  Your JWT Key"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
           {
                    {
                       new OpenApiSecurityScheme
                       {
                           Reference=new OpenApiReference
                           {
                               Type=ReferenceType.SecurityScheme,
                               Id="Bearer"
                           },
                           Name="Bearer",
                            In = ParameterLocation.Header
                       },
                       new List<string>()
                    }

           });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}