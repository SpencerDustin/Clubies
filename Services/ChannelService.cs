using Clubies.Data.Contexts;
using Clubies.Models;
using Clubies.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace Clubies.Services
{
    public class ChannelService : IChannelService
    {
        private readonly IDbContextFactory<MongoDbContext> contextFactory;

        public ChannelService(IDbContextFactory<MongoDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        // CREATE
        public async Task CreateChannel(Channel channel)
        {
            using var context = contextFactory.CreateDbContext();

            context.Channels.Add(channel);
            await context.SaveChangesAsync();
        }

        // READ ALL
        public async Task<List<Channel>> GetAllUsers()
        {
            using var context = contextFactory.CreateDbContext();

            return await context.Channels.ToListAsync();
        }

        // UPDATE
        public async Task UpdateChannel(Channel channel)
        {
            using var context = contextFactory.CreateDbContext();

            context.Channels.Update(channel);
            await context.SaveChangesAsync();
        }

        // READ BY ID
        public async Task<Channel?> GetByUserId(ObjectId id)
        {
            using var context = contextFactory.CreateDbContext();

            return await context.Channels.FindAsync(id);
        }
        // DELETE
        public async Task DeleteChannel(Channel channel)
        {
            using var context = contextFactory.CreateDbContext();

            context.Channels.Remove(channel);
            await context.SaveChangesAsync();
        }
    }
}
