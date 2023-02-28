using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CouchDB.Driver.Extensions;
using TestCouchDB.BLL.Interfaces;
using TestCouchDB.BLL.Models;
using TestCouchDB.DAL;
using TestCouchDB.DAL.Entities;

namespace TestCouchDB.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly MyCouchDbContext _context;
        private readonly IMapper _mapper;

        public UserService(MyCouchDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public List<UserModel> GetAll()
        {
            var users = _context.Users.ToList();
            return _mapper.Map<List<UserModel>>(users);
        }
        
        public async Task<bool> Create(UserModel userModel)
        {
            var user = _mapper.Map<UserEntity>(new UserModel
            { 
                Name = userModel.Name,
                LastName = userModel.LastName,
                Login = userModel.Login 
            });

            await _context.Users.AddAsync(user);

            return true;
        }

        public async Task<bool> Update(UserModel user)
        {
            var userForUpdate = await _context.Users.FindAsync(user.Id);

            if (userForUpdate != null)
            {
                userForUpdate.Rev = user.Rev;
                userForUpdate.Name = user.Name;
                userForUpdate.LastName = user.LastName;
                userForUpdate.Login = user.Login;
            }

            await _context.Users.AddOrUpdateAsync(userForUpdate);
            
            return true;
        }
    }
}