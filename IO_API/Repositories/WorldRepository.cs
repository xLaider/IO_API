using IO_API.IRepositories;
using IO_API.Models;

namespace IO_API.Repositories
{
    public class WorldRepository : IWorldRepository
    {
        private readonly DataContext _context;
        private readonly IBigFieldsRepository _bigFieldsRepository;
        public WorldRepository(DataContext context,
            IBigFieldsRepository bigFieldsRepository)
        {
            _context = context;
            _bigFieldsRepository = bigFieldsRepository;
        }

        public World CreateNewWorldWithUserID(string ID)
        {

            return new World
            {
                UserID = ID,
                BigFields = _bigFieldsRepository.CreateListOfEmptyBigFields()
            };
        }

        public int CalculateEarningsFromWorld(World world)
        {
            int earnings = 0;
            foreach (BigField bigField in world.BigFields)
            {
                foreach(Field field in bigField.Fields)
                {
                    if (field.PlacedBuilding != null)
                    {
                        earnings += field.PlacedBuilding.AccountedCoins;
                    } 
                }
            }
            return earnings;
        }

    }
}
