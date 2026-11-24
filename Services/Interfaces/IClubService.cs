using Clubies.Models;
using Microsoft.EntityFrameworkCore.Internal;
using MongoDB.Bson;

namespace Clubies.Services.Interfaces
{
    public interface IClubService
    {
        // CREATE
        public Task CreateClubService(Club club);

        // READ ALL
        public Task<List<Club>> GetAllUsers();

        // READ BY ID
        public Task<Club?> GetByClubId(ObjectId id);

        // UPDATE
        public Task UpdateClub(Club club);
        // DELETE
        public Task DeleteClub(Club club);
    }
}
