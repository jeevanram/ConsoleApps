using DataAccess.Database.DBContext;
using DataAccess.Database.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database.Repository.Implementation
{
    public class TestDBRepositoryWrapper : ITestDBRepositoryWrapper
    {
        private readonly TestDbContext _testDbContext;
        private IUserRepository? _userRepository;

        public TestDBRepositoryWrapper(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;
        }

        public IUserRepository UserRepository { get { _userRepository ??= new UserRepository(_testDbContext); return _userRepository; } }
        public void Save()
        {
            _testDbContext.SaveChanges();
        }
    }
}
