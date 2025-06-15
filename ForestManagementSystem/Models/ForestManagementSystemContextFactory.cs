using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ForestManagementSystem.Models
{
    public class ForestManagementSystemContextFactory : IDesignTimeDbContextFactory<ForestManagementSystemContext>
    {
        private static string _connectionString;

        static ForestManagementSystemContextFactory()
        {
            // Initialize connection string in static constructor
            _connectionString = "Data Source=HT-ITN\\SQLEXPRESS;Initial Catalog=ForestManagementSystem;Integrated Security=True;Trust Server Certificate=True";
        }

        public ForestManagementSystemContextFactory()
        {
            // Constructor is now empty as initialization is done in static constructor
        }

        public ForestManagementSystemContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ForestManagementSystemContext CreateDbContext(string[] args)
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("Connection string has not been initialized.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<ForestManagementSystemContext>();
            optionsBuilder.UseSqlServer(_connectionString);

            return new ForestManagementSystemContext(optionsBuilder.Options);
        }

        public static ForestManagementSystemContext Create()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("Connection string has not been initialized.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<ForestManagementSystemContext>();
            optionsBuilder.UseSqlServer(_connectionString);

            return new ForestManagementSystemContext(optionsBuilder.Options);
        }

        public static void SetConnectionString(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString), "Connection string cannot be null or empty.");
            }
            _connectionString = connectionString;
        }

        public static string GetConnectionString()
        {
            return _connectionString;
        }
    }
} 