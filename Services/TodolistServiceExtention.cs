using Task2.Interfaces;

namespace Task2.Services
{
    public static class TodolistServiceExtention
    {
        public static IServiceCollection AddTodolistServices(this IServiceCollection services)
        {
            services.AddSingleton<ITodolistService, TodolistService>();
            return services;
        }
    }
}
