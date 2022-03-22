using IO_API.Models;

namespace IO_API.IRepositories
{
    public interface IUserProgressInfoRepository
    {
        public UsersProgressInfo CreateNewUserProgressInfoWithUserID(string ID);
    }
}
