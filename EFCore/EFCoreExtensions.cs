using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Context;
using EFCore.Repositories.Task;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore
{
    public static class EFCoreExtensions
    {
        public static IServiceCollection AddEFCore(
                this IServiceCollection services,
                Action<DbContextOptionsBuilder> dboptions,
                ServiceLifetime scope = ServiceLifetime.Scoped)
        {

            services.AddDbContext<DataContext>(dboptions, scope);

            services.AddScoped<ITaskRepository, TaskRepository>();

            return services;
        }
    }
}