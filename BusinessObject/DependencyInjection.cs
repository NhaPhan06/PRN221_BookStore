using BusinessObject.Mapper;
using BusinessObject.Service;
using BusinessObject.Service.Implement;
using DataAccess.Repository;
using DataAccess.Repository.Generic;
using DataAccess.Repository.Generic.UnitOfWork;
using DataAccess.Repository.Implement;
using DataAccess.Repository.Implement.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessObject {
    public static class DependencyInjection {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services) {
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
}