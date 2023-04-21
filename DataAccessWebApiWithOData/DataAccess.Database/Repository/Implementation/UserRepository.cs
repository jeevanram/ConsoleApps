using DataAccess.Database.DBContext;
using DataAccess.Database.Repository.Interface;
using DataAccess.Database.Model;

namespace DataAccess.Database.Repository.Implementation
{
    public class UserRepository : BaseRepository<UserInfo>, IUserRepository
    {
        public UserRepository(TestDbContext dbContext) : base(dbContext)
        {
        }
    }
}
