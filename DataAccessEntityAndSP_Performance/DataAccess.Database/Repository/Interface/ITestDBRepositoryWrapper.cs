using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database.Repository.Interface
{
    public interface ITestDBRepositoryWrapper
    {
        IUserRepository UserRepository { get; }
        void Save();
    }
}
