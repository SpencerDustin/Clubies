using Clubies.Models;
using MongoDB.Bson;

namespace Clubies.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User CreateUse(User channel);
        User GetUserById(User id);
        User UpdateUser(User channel);
        void DeleteUser(User channel);
    }
}
