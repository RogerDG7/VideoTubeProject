using System;
using Bussines.Contract;
using Bussines.Implement;
using Common.Utilities.Mapper;
using DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.CommentService;
using Services.CommentService.Implements;
using Services.UserServices.Contracts;
using Services.UserServices.Implements;
using Services.VideoService.Contracts;
using Services.VideoService.Implements;

namespace DependencyInjection;

public static class IoCRegister
{
    public static IServiceCollection AddRepository(IServiceCollection services)
    {
        services.AddScoped<IUserServiceRepository, UserServiceRepository>();
        services.AddScoped<ICommentServiceRepository, CommentServiceRepository>();
        services.AddScoped<IVideoServiceRepository, VideoServiceRepository>();


        return services;
    }

    public static IServiceCollection AddServices(IServiceCollection services)
    {
        services.AddScoped<IUserActions, UserActions>();
        services.AddScoped<ICommentActions, CommentActions>();
        services.AddScoped<IVideoActions, VideoActions>();
        services.AddScoped<VideoTubeSeedDB>();
        services.AddAutoMapper(typeof(VideoTubeProfileMap));
        return services;
    }

    public static IServiceCollection AddDbContext(IServiceCollection services, string DefaultConnection)
    {
        services.AddDbContext<VideoTubeContext>(options => options.UseNpgsql(DefaultConnection));
        return services;
    }

    public static void SowSeedDbVideoTube(IServiceScope scope)
    {
        VideoTubeSeedDB? seeder = scope.ServiceProvider.GetService<VideoTubeSeedDB>();
        seeder?.SeedAsync().Wait();
    }
}
