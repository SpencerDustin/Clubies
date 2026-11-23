using Clubies.Models;
using Microsoft.EntityFrameworkCore.Internal;
using MongoDB.Bson;

namespace Clubies.Services.Interfaces
{
    public interface IMessageService
    {
        // CREATE
        public Task CreateMessage(Message message);

        // READ BY ID
        public Task<Message?> GetByMessageId(ObjectId id);

        // UPDATE
        public Task UpdateMessage(Message message);
        // DELETE
        public Task MessageUser(Message message);
    }
}
