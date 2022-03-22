using IO_API.Models;

namespace IO_API.IRepositories
{
    public interface IFieldRepository
    {
        public IList<Field> CreateNewListOfEmptyFields();
    }
}
