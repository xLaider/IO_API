using IO_API.Models;

namespace IO_API.IRepositories
{
    public interface IWorldRepository
    {
        public World CreateNewWorldWithUserID(string ID);
        public int CalculateEarningsFromWorld(World world);
    }
}
