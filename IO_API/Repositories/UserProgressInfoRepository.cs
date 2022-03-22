using IO_API.IRepositories;
using IO_API.Models;

namespace IO_API.Repositories
{
    public class UserProgressInfoRepository : IUserProgressInfoRepository
    {
        private readonly DataContext _context;
        public UserProgressInfoRepository(DataContext context)
        {
            _context = context;
        }

        public UsersProgressInfo CreateNewUserProgressInfoWithUserID(string ID)
        {
            return new UsersProgressInfo{
                UserID = ID,
                Coins = 0,
                Population = 0,
            };
        }
    }
}
