using BusinessLayer.Mapper;
using BusinessLayer.Service;
using BusinessLayer.Service.Implement;
using DataAccess;
using DataAccess.Infrastructure;
using DataAccess.Repository;
using DataAccess.Repository.Implement;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services,
        IConfiguration configuration)
    {
        //Add DB
        var connString = configuration.GetConnectionString("DatabaseConnection");
        services.AddDbContext<PRN_BookStoreContext>(options =>
        {
            options.UseSqlServer(connString).EnableSensitiveDataLogging();
        });

        // SIGN UP UNIT OF WORK FOR REPO
        services.AddTransient(typeof(IGeneric<>), typeof(Generic<>));
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        // SIGN UP REPO
        services.AddTransient<IBookRepository, BookRepository>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IUserRepository, UserRepository>();


        // SIGN UP SERVICE
        services.AddTransient<IBookService, BookService>();
        services.AddTransient<ICategoryService, CategoryService>();
        services.AddTransient<IOrderDetailService, OrderDetailService>();
        services.AddTransient<IOrderService, OrderService>();
        services.AddTransient<IUserService, UserService>();

        //AUTOMAPPER
        services.AddAutoMapper(typeof(ApplicationMapper).Assembly);
        return services;
    }
}