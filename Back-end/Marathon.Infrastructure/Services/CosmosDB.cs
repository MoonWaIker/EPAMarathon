using Azure.Identity;
using Marathon.Interfaces.Services;
using Marathon.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Marathon.Infrastructure.Services
{
    public class CosmosDB : DbContext, IDataBase
    {
        private const string accountEndpoint = "https://marathondb.documents.azure.com:443/";
        private const string databaseName = "SocialNetwork";
        private const string usersContainerName = "Users";

        public DbSet<User> Users { get; set; }

        public CosmosDB()
        {
            Users = Set<User>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToContainer(usersContainerName);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.EnableSensitiveDataLogging();
            _ = optionsBuilder.EnableDetailedErrors();
            _ = optionsBuilder.UseCosmos(accountEndpoint, new DefaultAzureCredential(), databaseName);
        }

        public void AddUser(User user)
        {
            if (Users
                .AsEnumerable()
                .Any(u => u.Email == user.Email))
            {
                throw new DbUpdateException("The email already exists!");
            }

            user.id = (Users.Count() + 1).ToString();
            Users.Add(user);
            SaveChanges();
        }
    }
}
