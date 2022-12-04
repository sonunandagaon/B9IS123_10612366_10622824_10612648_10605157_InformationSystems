using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MusicEquipmentStore.Services;

namespace MusicEquipmentStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<DbContext>(d => d.UseSqlServer(Configuration.GetConnectionString("MusicStore")));
            services.AddScoped<IProductService, ProductService>();
            services.AddControllersWithViews()
                .AddJsonOptions(d =>
                {
                    d.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    d.JsonSerializerOptions.PropertyNamingPolicy = null;
                });
        }
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
    }
}

