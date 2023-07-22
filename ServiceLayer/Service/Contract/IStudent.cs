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
    public interface IStudent
    {
        Response<List<Student>> GetAll();
        Response<Student> GetById(int id);
        Response<Student> Create(CreateStudentDto dto);
        Response<Student> Update(UpdateStudentDto std);
        Response<Student> Delete(int id);
    }
}
