using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestCouchDB.BLL.Interfaces;
using TestCouchDB.BLL.Models;
using TestCouchDB.DAL;
using TestCouchDB.DAL.Entities;

namespace TestCouchDB.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(UserModel userModel)
        {
                var id = await _userService.Create(userModel);
                return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserModel user)
        {
            var checker = await _userService.Update(user);
            return Ok(checker);
        }
    }
}