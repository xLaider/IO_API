using IO_API.IRepositories;
using IO_API.Models;

namespace IO_API.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly DataContext _context;
        public BuildingRepository(DataContext context)
        {
            _context = context;
        }

    }
}
