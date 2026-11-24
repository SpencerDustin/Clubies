using Clubies.Data.Contexts;
using Clubies.Models;
using Clubies.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace Clubies.Services
{
    public class MessageService : IMessageService
    {
        private readonly IDbContextFactory<MongoDbContext> contextFactory;

        public MessageService(IDbContextFactory<MongoDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        // CREATE
        public async Task CreateMessage(Message message)
        {
            using var context = contextFactory.CreateDbContext();

            context.Messages.Add(message);
            await context.SaveChangesAsync();
        }

        // READ BY ID
        public async Task<Message?> GetByMessageId(ObjectId id)
        {
            using var context = contextFactory.CreateDbContext();

            return await context.Messages.FindAsync(id);
        }

        // UPDATE
        public async Task UpdateMessage(Message message)
        {
            using var context = contextFactory.CreateDbContext();

            context.Messages.Update(message);
            await context.SaveChangesAsync();
        }
        // DELETE
        public async Task MessageUser(Message message)
        {
            using var context = contextFactory.CreateDbContext();

            context.Messages.Remove(message);
            await context.SaveChangesAsync();
        }
    }
}
