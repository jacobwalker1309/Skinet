using System.Linq;
using API.Error;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Helpers
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
             services.AddScoped<IProductRepository, ProductRepository>();
             services.AddScoped<IBasketRepository,BasketRepository>();
             services.AddScoped<IOrderService,OrderService>();
             services.AddScoped<ITokenService,TokenService>();
             services.AddScoped<IUnitOfWork,UnitOfWork>();
             services.AddScoped<IPaymentService,PaymentService>();
             services.AddScoped<IResponseCacheService,ResponseCacheService>();
             services.AddScoped(typeof(IGenericRepository<>),(typeof(GenericRepository<>)));
              services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });
            return services;
        }
    }
}