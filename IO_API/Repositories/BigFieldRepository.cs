using IO_API.IRepositories;
using IO_API.Models;

namespace IO_API.Repositories
{
    public class BigFieldRepository : IBigFieldsRepository
    {
        private readonly DataContext _context;
        private readonly IFieldRepository _fieldRepository;
        public BigFieldRepository(DataContext context,
            IFieldRepository fieldRepository)
        {
            _context = context;
            _fieldRepository = fieldRepository;
        }

        public IList<BigField> CreateListOfEmptyBigFields()
        {
            IList<BigField> bigFields = new List<BigField>();
            for (int i = 0; i < 49; i++)
            {
                bigFields.Add(new BigField
                {
                    Fields = _fieldRepository.CreateNewListOfEmptyFields()
                });
            }
            return bigFields;
        }
    }
}
