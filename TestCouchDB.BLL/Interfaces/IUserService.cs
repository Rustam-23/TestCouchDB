using System.Collections.Generic;
using System.Threading.Tasks;
using TestCouchDB.BLL.Models;

namespace TestCouchDB.BLL.Interfaces
{
    public interface IUserService
    {
        public List<UserModel> GetAll();
        public Task<bool> Create(UserModel userModel);
        public Task<bool> Update(UserModel userModel);
    }
}