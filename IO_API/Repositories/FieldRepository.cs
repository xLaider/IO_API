using IO_API.IRepositories;
using IO_API.Models;

namespace IO_API.Repositories
{
    public class FieldRepository : IFieldRepository
    {
        private readonly DataContext _context;
        private readonly IBuildingRepository _buildingRepository;
        public FieldRepository(DataContext context,
            IBuildingRepository buildingRepository)
        {
            _context = context;
            _buildingRepository = buildingRepository;
        }

        public IList<Field> CreateNewListOfEmptyFields()
        {
            IList<Field> fields = new List<Field>();
            for (int i = 0; i < 9; i++)
            {
                fields.Add(new Field());
            }
            return fields;
        }
    }
}
