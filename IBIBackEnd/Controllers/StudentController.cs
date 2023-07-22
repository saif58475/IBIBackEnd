using DomailLayer.DTOS;
using DomailLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Service.Contract;
using ServiceLayer.Service.Implementation;

namespace IBIBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _istudent;
        public StudentController(IStudent istudent)
        {
            _istudent = istudent;
        }
        [HttpGet]
        [Route("GetAll")]
        public Response<List<Student>> GetAll()
        {
            return this._istudent.GetAll();
        }
        [HttpGet]
        [Route("GetById")]
        public Response<Student> GetById(int id)
        {
            return this._istudent.GetById(id);
        }
        [HttpPost]
        [Route("Create")]
        public Response<Student> Create([FromForm] CreateStudentDto dto)
        {
            return this._istudent.Create(dto);
        }
        [HttpPut]
        [Route("Update")]
        public Response<Student> Update([FromForm] UpdateStudentDto std)
        {
            return this._istudent.Update(std);
        }
        [HttpDelete]
        [Route("Delete")]
        public Response<Student> Delete(int id)
        {
            return this._istudent.Delete(id);
        }
    }
}
