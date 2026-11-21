using Clubies.Models;
using Microsoft.EntityFrameworkCore.Internal;
using MongoDB.Bson;

namespace Clubies.Services.Interfaces
{
    public interface IUserService
    {
        // CREATE
        public Task CreateUser(User user);

        // READ ALL
        public Task<List<User>> GetAllUsers();

        // READ BY ID
        public Task<User?> GetByUserId(ObjectId id);

        // UPDATE
        public Task UpdateUser(User user);

        // DELETE
        public Task DeleteUser(User user);
    }
}
