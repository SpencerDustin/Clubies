using Clubies.Models;
using MongoDB.Bson;

namespace Clubies.Repositories.Interfaces
{
    public interface IChannelRepository
    {
        Channel CreateChannel(Channel channel);
        Channel GetChannelById(ObjectId id);
        Channel UpdateChannel(Channel channel);
        void DeleteChannel(Channel channel);
    }
}
