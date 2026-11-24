using Clubies.Models;
using Microsoft.EntityFrameworkCore.Internal;
using MongoDB.Bson;

namespace Clubies.Services.Interfaces
{
    public interface IClubEventService
    {
        // CREATE
        public Task CreateClubEvent(ClubEvent clubEvent);

        // READ BY ID
        public Task<ClubEvent?> GetByUserId(ObjectId id);

        // UPDATE
        public Task UpdateClubEvent(ClubEvent clubEvent);
        // DELETE
        public Task DeleteClubEvent(ClubEvent clubEvent);
    }
}
