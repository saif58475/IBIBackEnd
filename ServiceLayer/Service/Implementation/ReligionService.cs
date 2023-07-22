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
    public class ReligionService : IReligion
    {
        private readonly ApplicationDbContext context;
        Response<Religion> responce = new Response<Religion>();
        public ReligionService(ApplicationDbContext _context)
        {
            context = _context;
        }
        public Response<Religion> Create(CreateReligionDto rel)
        {
            try
            {

                var record = new Religion() { ReligionName = rel.ReligionName};
                this.context.religions.Add(record);
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
                this.responce.Data = (Religion)ex.Data; this.responce.Success = false;
            }

            return responce;
        }

        public Response<Religion> Delete(int id)
        {
            try
            {
                var record = this.context.religions.FirstOrDefault(r => r.Id == id);
                this.context.religions.Remove(record);
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
                this.responce.Data = (Religion)ex.Data;
                this.responce.Success = false;
            }
            return responce;
        }

        public Response<List<Religion>> GetAllReligion()
        {
            var responce = new Response<List<Religion>>();
            var records = this.context.religions.ToList();
            try
            {
                responce.Message = "Success";
                responce.MessageCode = 200;
                responce.Data = this.context.religions.ToList();
                responce.Success = true;
            }
            catch (Exception ex)
            {
                responce.Message = ex.Message;
                responce.MessageCode = StatusCodes.Status400BadRequest;
                responce.Data = (List<Religion>)ex.Data;
                responce.Success = false;
            }
            return responce;
        }

        public Response<Religion> GetById(int id)
        {
            try
            {
                this.responce.Message = "Success"; this.responce.MessageCode = 200; responce.Data = this.context.religions.FirstOrDefault(r => r.Id == id); this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = ex.Message; this.responce.MessageCode = StatusCodes.Status400BadRequest; this.responce.Data = (Religion)ex.Data; this.responce.Success = false;
            }
            return responce;
        }

        public Response<Religion> Update(Religion rel)
        {
            try
            {
                var record = this.context.religions.FirstOrDefault(r => r.Id == rel.Id);
                record.ReligionName = rel.ReligionName;
                this.context.religions.Update(record);
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
                this.responce.Data = (Religion)ex.Data; this.responce.Success = false;
            }
            return responce;
        }
    }
}
