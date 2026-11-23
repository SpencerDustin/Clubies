using Clubies.Models;
using Microsoft.EntityFrameworkCore.Internal;
using MongoDB.Bson;

namespace Clubies.Services.Interfaces
{
    public interface IChannelService
    {
        // CREATE
        public Task CreateChannel(Channel channel);

        // READ ALL
        public Task<List<Channel>> GetAllUsers();

        // UPDATE
        public Task UpdateChannel(Channel channel);

        // READ BY ID
        public Task<Channel?> GetByUserId(ObjectId id);
        // DELETE
        public Task DeleteChannel(Channel channel);
    }
}
