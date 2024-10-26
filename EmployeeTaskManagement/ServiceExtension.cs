using RepoEmployeeTask;
using ServiceEmployeeTask.Interfaces;
using ServiceEmployeeTask.Services;

namespace EmployeeTaskManagement
{
    public static class ServiceExtensions
    {
        public static void ConfigureCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<RepoEmployee>();
        }
    }
}
