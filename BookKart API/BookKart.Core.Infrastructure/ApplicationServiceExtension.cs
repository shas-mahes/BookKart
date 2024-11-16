using BookKart.Core.Application.Interface;
using BookKart.Core.Infrastructure.DataContext;
using BookKart.Core.Infrastructure.Repositories.RepositoryBase;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BookKart.Core.Domain.Interfaces;
using BookKart.Core.Infrastructure.Repositories;


namespace BookKart.Core.Infrastructure;

public static class ApplicationServiceExtension
{
    public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("BookKart");
        services.AddDbContext<AppDbContext>(opt => opt.UseLazyLoadingProxies().UseSqlServer(connectionString), ServiceLifetime.Scoped);
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        #region Repositories
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
        #endregion
    }
}
