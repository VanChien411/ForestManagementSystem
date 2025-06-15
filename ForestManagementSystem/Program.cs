using ForestManagementSystem.Models;
using ForestManagementSystem.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using ForestManagementSystem.Forms;
using ForestManagementSystem.Forms.User;

namespace ForestManagementSystem
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            // Configure DbContext
            var optionsBuilder = new DbContextOptionsBuilder<ForestManagementSystemContext>();
            optionsBuilder.UseSqlServer("Data Source=HT-ITN\\SQLEXPRESS;Initial Catalog=ForestManagementSystem;Integrated Security=True;Trust Server Certificate=True");

            // Create DbContext instance
            using (var context = new ForestManagementSystemContext(optionsBuilder.Options))
            {
                // Ensure database is created
                context.Database.EnsureCreated();
            }

            var loginForm = ServiceProvider.GetRequiredService<LoginForm>();
            Application.Run(loginForm);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Configure DbContext
            services.AddDbContext<ForestManagementSystemContext>(options =>
                options.UseSqlServer("Data Source=HT-ITN\\SQLEXPRESS;Initial Catalog=ForestManagementSystem;Integrated Security=True;Trust Server Certificate=True"));

            // Register forms
            services.AddTransient<MainForm>();
            services.AddTransient<LoginForm>();
            services.AddTransient<ucDefault>();
        }
    }
}