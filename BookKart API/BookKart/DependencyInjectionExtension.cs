using BookKart.Service;
using Microsoft.Azure.ServiceBus.Primitives;

namespace BookKart.API
{
    public static class DependencyInjectionExtension
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Auto Mapper 
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<BookService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<UserService>();
            services.AddScoped<UserRoleService>();
            services.AddScoped<CartService>();
            services.AddScoped<OrderDetailsService>();
        }
    }
}
