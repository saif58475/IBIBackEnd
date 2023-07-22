using DomailLayer.DTOS;
using DomailLayer.Models;
using ServiceLayer.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Contract
{
    public interface IUser
    {
        //getallrecords
        Response<List<User>> GetAllRecords();
        //get record by id 
        Response<User> GetById(int id);
        //add new record
        Response<User> AddUser(CreateUserDto dto);
        //update specific record
        Response<User> UpdateUser(User user);
        //delete specific record
        Response<User> Delete(int id);

        Response<LoginResponse> Login(LoginUserDto dto);
    }
}
