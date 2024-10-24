using Microsoft.Extensions.DependencyInjection;
using Summit.Application.Services;
using Summit.Domain.Interfaces;


namespace Summit.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service)
        {
            service.AddSingleton<ICommentService, CommentService>();
            return service;
        }
    }
}
