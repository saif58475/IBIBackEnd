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
    public interface IReligion
    {
        Response<List<Religion>> GetAllReligion();
        Response<Religion> GetById(int id);
        Response<Religion> Create(CreateReligionDto rel);
        Response<Religion> Update(Religion rel);
        Response<Religion> Delete(int id);
    }
}
