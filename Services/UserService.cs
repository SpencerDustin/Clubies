using Clubies.Data.Contexts;
using Clubies.Models;
using Clubies.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Clubies.Services
{
    public class UserService : IUserService
    {
        private readonly IDbContextFactory<MongoDbContext> contextFactory;
        
        public UserService(IDbContextFactory<MongoDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        // CREATE
        public async Task CreateUser(User user)
        {
            using var context = contextFactory.CreateDbContext();

            context.Users.Add(user);
            await context.SaveChangesAsync();
        }

        // READ ALL
        public async Task<List<User>> GetAllUsers()
        {
            using var context = contextFactory.CreateDbContext();

            return await context.Users.ToListAsync();
        }

        // READ BY ID
        public async Task<User?> GetByUserId(ObjectId id)
        {
            using var context = contextFactory.CreateDbContext();

            return await context.Users.FindAsync(id);
        }

        // READ BY USERNAME
        public async Task<User?> GetByUsername(string username)
        {
            using var context = contextFactory.CreateDbContext();

            return await context.Users.Where(u => u.Username == username).SingleOrDefaultAsync();
        }

        // READ BY EMAIL
        public async Task<User?> GetByUserEmail(string email)
        {
            using var context = contextFactory.CreateDbContext();

            return await context.Users.Where(u => u.Email == email).SingleOrDefaultAsync();
        }

        // UPDATE
        public async Task UpdateUser(User user)
        {
            using var context = contextFactory.CreateDbContext();

            context.Users.Update(user);
            await context.SaveChangesAsync();
        }

        // DELETE
        public async Task DeleteUser(User user)
        {
            using var context = contextFactory.CreateDbContext();

            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

        public async Task<bool> ValidateLogin(User user, string unHashedPassword)
        {
            HashingService hashingService = new HashingService();

            unHashedPassword = hashingService.GetHashString(unHashedPassword);

            bool validUser = user.Password == unHashedPassword;

            return validUser;
        }
    }
}
