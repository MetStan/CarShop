﻿namespace CarShop
{
    using MyWebServer;
    using CarShop.Data;
    using System.Threading.Tasks;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using Microsoft.EntityFrameworkCore;
    using CarShop.Services.Contracts;
    using CarShop.Services.Service;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                .Add<ApplicationDbContext>()
                .Add<IValidatorService, ValidatorService>()
                .Add<IPasswordHasher, PasswordHasher>()
                .Add<IUserService, UserService>()
                .Add<ICarService, CarService>()
                .Add<IIssueService, IssueService>()
                .Add<IViewEngine, CompilationViewEngine>())
                .WithConfiguration<ApplicationDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
