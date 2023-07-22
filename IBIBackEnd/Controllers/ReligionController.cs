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
    public class ReligionController : ControllerBase
    {
        private readonly IReligion _religion;

        public ReligionController(IReligion religion)
        {
            _religion = religion;
        }
        [HttpGet]
        [Route("GetAll")]
        public Response<List<Religion>> GetAllCases()
        {
            return this._religion.GetAllReligion();
        }
        [HttpGet]
        [Route("GetById")]
        public Response<Religion> GetById(int id)
        {
            return this._religion.GetById(id);
        }
        [HttpPost]
        [Route("Create")]
        public Response<Religion> Create(CreateReligionDto dto)
        {
            return this._religion.Create(dto);
        }
        [HttpPut]
        [Route("Update")]
        public Response<Religion> Update(Religion rel)
        {
            return this._religion.Update(rel);
        }
        [HttpDelete]
        [Route("Delete")]
        public Response<Religion> Delete(int id)
        {
            return this._religion.Delete(id);
        }
    }
}
