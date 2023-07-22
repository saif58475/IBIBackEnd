using DomailLayer.DTOS;
using DomailLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Service.Contract;
using ServiceLayer.Service.Implementation;

namespace IBIBackEnd.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }
        [HttpGet]
        [Route("GetById")]
        public Response<User> GetBYId(int id)
        {
            return this._user.GetById(id);
        }
        [HttpGet]
        [Route("GetAll")]
        public Response<List<User>> GetAll()
        {
            return this._user.GetAllRecords();
        }
        [HttpPost]
        [Route("Create")]
        public Response<User> Create(CreateUserDto user)
        {
            return this._user.AddUser(user);
        }
        [HttpPut]
        [Route("Update")]
        public Response<User> Update(User user)
        {
            return this._user.UpdateUser(user);
        }
        [HttpDelete]
        [Route("Delete")]
        public Response<User> Delete(int id)
        {
            return this._user.Delete(id);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public Response<LoginResponse> Login(LoginUserDto dto)
        {
            return this._user.Login(dto);
        }
    }
}
