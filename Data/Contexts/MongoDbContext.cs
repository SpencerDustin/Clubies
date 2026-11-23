using Clubies.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Clubies.Data.Contexts
{
    public class MongoDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Club> Clubs => Set<Club>();
        public DbSet<Channel> Channels => Set<Channel>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<ClubEvent> ClubEvents => Set<ClubEvent>();

        public MongoDbContext(DbContextOptions<MongoDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToCollection("Users");
            modelBuilder.Entity<Club>().ToCollection("Clubs");
            modelBuilder.Entity<Channel>().ToCollection("Channels");
            modelBuilder.Entity<Message>().ToCollection("Messages");
            modelBuilder.Entity<ClubEvent>().ToCollection("ClubEvents");
        }

    }
}
