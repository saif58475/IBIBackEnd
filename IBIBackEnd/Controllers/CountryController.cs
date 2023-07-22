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
    public class CountryController : ControllerBase
    {
        private readonly ICountry _country;
        public CountryController(ICountry country)
        {
            _country = country;
        }
        [HttpGet]
        [Route("GetAll")]
        public Response<List<Country>> GetAllCountries()
        {
            return this._country.GetAllCountries();
        }
        [HttpGet]
        [Route("GetById")]
        public Response<Country> GetById(int id)
        {
            return this._country.GetById(id);
        }
        [HttpPost]
        [Route("Create")]
        public Response<Country> Create(CreateCountryDto dto)
        {
            return this._country.Create(dto);
        }
        [HttpPut]
        [Route("Update")]
        public Response<Country> Update(Country rec)
        {
            return this._country.Update(rec);
        }
        [HttpDelete]
        [Route("Delete")]
        public Response<Country> Delete(int id)
        {
            return this._country.Delete(id);
        }
    }
}
