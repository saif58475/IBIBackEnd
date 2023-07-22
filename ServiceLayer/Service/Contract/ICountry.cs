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
    public interface ICountry
    {
        Response<List<Country>> GetAllCountries();
        Response<Country> GetById(int id);
        Response<Country> Create(CreateCountryDto con);
        Response<Country> Update(Country con);
        Response<Country> Delete(int id);
    }
}
