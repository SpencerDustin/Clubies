using Clubies.Models;
using Clubies.Services.Interfaces;
using MongoDB.Bson;

namespace Clubies.Services
{
    public class ClubAuthorityService : IClubAuthorityService
    {
        public string GetUserClubPage(Club club, ObjectId userId)
        {
            if (IsOwner(club, userId) || IsManager(club, userId))
            {
                return "/club/manage";
            }
            else if (IsMember(club, userId)) 
            {
                return "/club/member";
            }
            else
            {
                return "/club";
            }
        }

        public bool IsManager(Club club, ObjectId userId)
        {
            return club.Managers?.Contains(userId) == true;
        }

        public bool IsMember(Club club, ObjectId userId)
        {
            return club.Members?.Contains(userId) == true;
        }

        public bool IsOwner(Club club, ObjectId userId)
        {
            return club.Owner == userId;
        }
    }
}
