using IO_API.Models;

namespace IO_API.IRepositories
{
    public interface IBigFieldsRepository
    {
        public IList<BigField> CreateListOfEmptyBigFields();
    }
}
