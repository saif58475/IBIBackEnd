using DomailLayer.DTOS;
using DomailLayer.Models;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.DbContextLayer;
using ServiceLayer.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Implementation
{
    public class CountryService : ICountry
    {
        private readonly ApplicationDbContext context;
        Response<Country> responce = new Response<Country>();
        public CountryService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public Response<Country> Create(CreateCountryDto con)
        {
            try
            {

                var record = new Country() { CountryName = con.CountryName, CountryCode = con.CountryCode};
                this.context.countries.Add(record);
                this.context.SaveChanges();
                this.responce.Message = "Success";
                this.responce.MessageCode = 200;
                this.responce.Data = record;
                this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = ex.Message; this.responce.MessageCode = StatusCodes.Status400BadRequest;
                this.responce.Data = (Country)ex.Data; this.responce.Success = false;
            }

            return responce;
        }

        public Response<Country> Delete(int id)
        {
            try
            {
                var record = this.context.countries.FirstOrDefault(r => r.Id == id);
                this.context.countries.Remove(record);
                this.context.SaveChanges();
                this.responce.Message = "Success"; this.responce.MessageCode = 200; this.responce.Data = record; this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = ex.Message; this.responce.MessageCode = StatusCodes.Status400BadRequest; this.responce.Data = (Country)ex.Data; this.responce.Success = false;
            }
            return responce;
        }

        public Response<List<Country>> GetAllCountries()
        {
            var responce = new Response<List<Country>>();
            var records = this.context.countries.ToList();
            try
            {
                responce.Message = "Success";
                responce.MessageCode = 200;
                responce.Data = this.context.countries.ToList();
                responce.Success = true;
            }
            catch (Exception ex)
            {
                responce.Message = ex.Message; responce.MessageCode = StatusCodes.Status400BadRequest; responce.Data = (List<Country>)ex.Data; responce.Success = false;
            }
            return responce;
        }

        public Response<Country> GetById(int id)
        {
            try
            {
                this.responce.Message = "Success"; this.responce.MessageCode = 200; responce.Data = this.context.countries.FirstOrDefault(r => r.Id == id); this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = ex.Message; this.responce.MessageCode = StatusCodes.Status400BadRequest; this.responce.Data = (Country)ex.Data; this.responce.Success = false;
            }
            return responce;
        }

        public Response<Country> Update(Country con)
        {

            try
            {
                var record = this.context.countries.FirstOrDefault(r => r.Id == con.Id);
                record.CountryName = con.CountryName; record.CountryCode = con.CountryCode;
                this.context.countries.Update(record);
                this.context.SaveChanges();
                this.responce.Message = "Success";
                this.responce.MessageCode = 200;
                this.responce.Data = record;
                this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = ex.Message;
                this.responce.MessageCode = StatusCodes.Status400BadRequest;
                this.responce.Data = (Country)ex.Data; this.responce.Success = false;
            }
            return responce;
        }
    }
}
