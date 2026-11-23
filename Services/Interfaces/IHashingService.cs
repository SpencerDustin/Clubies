namespace Clubies.Services.Interfaces
{
    public interface IHashingService
    {
        byte[] GetHash(string inputString);

        string GetHashString(string inputString);
    }
}
