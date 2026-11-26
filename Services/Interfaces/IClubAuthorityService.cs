using Clubies.Models;
using MongoDB.Bson;

namespace Clubies.Services.Interfaces
{
    public interface IClubAuthorityService
    {
        bool IsOwner(Club club, ObjectId userId);
        bool IsManager(Club club, ObjectId userId);
        bool IsMember(Club club, ObjectId userId);
        string GetUserClubPage(Club club, ObjectId userId);
    }
}
