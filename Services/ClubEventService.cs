using Clubies.Data.Contexts;
using Clubies.Models;
using Clubies.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace Clubies.Services
{
    public class ClubEventService : IClubEventService
    {
        private readonly IDbContextFactory<MongoDbContext> contextFactory;

        public ClubEventService(IDbContextFactory<MongoDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        // CREATE
        public async Task CreateClubEvent(ClubEvent clubEvent)
        {
            using var context = contextFactory.CreateDbContext();

            context.ClubEvents.Add(clubEvent);
            await context.SaveChangesAsync();
        }

        // READ BY ID
        public async Task<ClubEvent?> GetByUserId(ObjectId id)
        {
            using var context = contextFactory.CreateDbContext();

            return await context.ClubEvents.FindAsync(id);
        }

        // UPDATE
        public async Task UpdateClubEvent(ClubEvent clubEvent)
        {
            using var context = contextFactory.CreateDbContext();

            context.ClubEvents.Update(clubEvent);
            await context.SaveChangesAsync();
        }
        // DELETE
        public async Task DeleteClubEvent(ClubEvent clubEvent)
        {
            using var context = contextFactory.CreateDbContext();

            context.ClubEvents.Remove(clubEvent);
            await context.SaveChangesAsync();
        }
    }
}
