﻿using Dispo.Infrastructure.Repositories;
using Dispo.Infrastructure.Repositories.Interfaces;
using Dispo.Service.Cache;
using Dispo.Service.Cache.Interfaces;
using Dispo.Service.Services;
using Dispo.Service.Services.Interfaces;
using Dispo.Service.Token;
using Dispo.Service.Token.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Dispo.IoC
{
    public class Injector
    {
        public static void InjectIoCServices(IServiceCollection serviceColletion)
        {
            InjectRepositories(serviceColletion);
            InjectServices(serviceColletion);
            InjectGenerics(serviceColletion);
        }

        private static void InjectRepositories(IServiceCollection serviceColletion)
        {
            serviceColletion.AddScoped<IAccountRepository, AccountRepository>();
            serviceColletion.AddScoped<IBranchRepository, BranchRepository>();
            serviceColletion.AddScoped<ILocationRepository, LocationRepository>();
            serviceColletion.AddScoped<IMovementRepository, MovementRepository>();
            serviceColletion.AddScoped<IProductRepository, ProductRepository>();
            serviceColletion.AddScoped<IProviderRepository, ProviderRepository>();
            serviceColletion.AddScoped<IUserRepository, UserRepository>();
            serviceColletion.AddScoped<IBrandRepository, BrandRepository>();
        }

        private static void InjectServices(IServiceCollection serviceColletion)
        {
            serviceColletion.AddScoped<IAccountService, AccountService>();
            serviceColletion.AddScoped<IBranchService, BranchService>();
            serviceColletion.AddScoped<ILocationService, LocationService>();
            serviceColletion.AddScoped<IMovementService, MovementService>();
            serviceColletion.AddScoped<IProductService, ProductService>();
            serviceColletion.AddScoped<IProviderService, ProviderService>();
            serviceColletion.AddScoped<IUserService, UserService>();
            serviceColletion.AddScoped<IUserAccountService, UserAccountService>();
            serviceColletion.AddScoped<IPasswordRecoveryService, PasswordRecoveryService>();
            serviceColletion.AddScoped<IBrandService, BrandService>();
        }

        private static void InjectGenerics(IServiceCollection serviceColletion)
        {
            serviceColletion.AddScoped<ITokenGenerator, TokenGenerator>();
            serviceColletion.AddScoped<ICacheManager, CacheManager>();
            serviceColletion.AddSingleton(MappingProfile.CreateMappingProfile().CreateMapper());
        }
    }
}