using Clubies.Data.Contexts;
using Clubies.Models;
using Clubies.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace Clubies.Services
{
    public class ClubService : IClubService
    {
        private readonly IDbContextFactory<MongoDbContext> contextFactory;

        public ClubService(IDbContextFactory<MongoDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        // CREATE
        public async Task CreateClubService(Club club)
        {
            using var context = contextFactory.CreateDbContext();

            context.Clubs.Add(club);
            await context.SaveChangesAsync();
        }

        // READ ALL
        public async Task<List<Club>> GetAllUsers()
        {
            using var context = contextFactory.CreateDbContext();

            return await context.Clubs.ToListAsync();
        }

        // READ BY ID
        public async Task<Club?> GetByClubId(ObjectId id)
        {
            using var context = contextFactory.CreateDbContext();

            return await context.Clubs.FindAsync(id);
        }

        // UPDATE
        public async Task UpdateClub(Club club)
        {
            using var context = contextFactory.CreateDbContext();

            context.Clubs.Update(club);
            await context.SaveChangesAsync();
        }
        // DELETE
        public async Task DeleteClub(Club club)
        {
            using var context = contextFactory.CreateDbContext();

            context.Clubs.Remove(club);
            await context.SaveChangesAsync();
        }
    }
}
