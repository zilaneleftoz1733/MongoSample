using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using WebApiMin.Models.Entities;

namespace WebApiMin.Models.DbContexts
{
    public class MongoDbContext : DbContext
    {

        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMongoDB(@"mongodb://root:qweasd@mongo:27017/", "IstkaFullData");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToCollection("MyPerson");
        }
    }
}