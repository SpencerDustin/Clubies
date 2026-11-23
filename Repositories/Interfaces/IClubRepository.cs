using Clubies.Models;

namespace Clubies.Repositories.Interfaces
{
    public interface IClubRepository
    {
        Club CreateClub(Club club);
        Club GetClubById(Club id);
        Club UpdateClub(Club club);
        void DeleteClub(Club club);
    }
}
