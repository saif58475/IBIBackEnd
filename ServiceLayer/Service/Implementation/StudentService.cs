using DomailLayer.DTOS;
using DomailLayer.Models;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.DbContextLayer;
using ServiceLayer.Service.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ServiceLayer.Service.Implementation
{
    public class StudentService : IStudent
    {
        private readonly ApplicationDbContext _context;
        Response<Student> responce = new Response<Student>();
        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Response<Student> Create(CreateStudentDto dto)
        {
            try
            {
                FileInfo imgBirthFileInfo = new FileInfo(dto.BirthImage.FileName);
                string imgBirthpath = Guid.NewGuid().ToString() + imgBirthFileInfo.Extension;
                string pathBirth = Path.Combine("assets/Images/BirthCertificates", imgBirthpath);
                using (Stream stream = new FileStream(pathBirth, FileMode.Create))
                {
                    dto.BirthImage.CopyTo(stream);
                };
                FileInfo imgGradeFileInfo = new FileInfo(dto.GradeImage.FileName);
                string imgGradepath = Guid.NewGuid().ToString() + imgGradeFileInfo.Extension;
                string pathGrade = Path.Combine("assets/Images/GradeImage", imgGradepath);
                using (Stream stream = new FileStream(pathGrade, FileMode.Create))
                {
                    dto.GradeImage.CopyTo(stream);
                };
                FileInfo imgMilitaryFileInfo = new FileInfo(dto.MilitralImage.FileName);
                string imgMilitrypath = Guid.NewGuid().ToString() + imgMilitaryFileInfo.Extension;
                string pathMilitry = Path.Combine("assets/Images/MilitralImage", imgMilitrypath);
                using (Stream stream = new FileStream(pathMilitry, FileMode.Create))
                {
                    dto.MilitralImage.CopyTo(stream);
                };
                FileInfo imgStudentFileInfo = new FileInfo(dto.PersonalImage.FileName);
                string imgStudentpath = Guid.NewGuid().ToString() + imgStudentFileInfo.Extension;
                string pathStudent = Path.Combine("assets/Images/StudentImage", imgStudentpath);
                using (Stream stream = new FileStream(pathStudent, FileMode.Create))
                {
                    dto.PersonalImage.CopyTo(stream);
                };
                var record = new Student() {
                    FirstName = dto.FirstName, 
                    SecondName= dto.SecondName,
                    ThirdName = dto.ThirdName,
                    FourthName = dto.FourthName,
                    BirthLocation = dto.BirthLocation,
                    DOB = dto.DOB,
                    GradDate = dto.GradDate,
                    NationalId = dto.NationalId,
                    GradeType = dto.GradeType,
                    ReligionId = dto.ReligionId,
                    CountryId = dto.CountryId,
                    BirthImage = pathBirth,
                    GradeImage = pathGrade,
                    MilitralImage = pathMilitry,
                    PersonalImage = pathStudent
                };
                this._context.students.Add(record);
                this._context.SaveChanges();
                this.responce.Message = "Success";
                this.responce.MessageCode = StatusCodes.Status200OK;
                this.responce.Data = record; 
                this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = "Failed"; this.responce.MessageCode = StatusCodes.Status400BadRequest; 
                this.responce.Data = null; this.responce.Success = false;
            }
            return this.responce;
        }

        public Response<Student> Delete(int id)
        {
            try
            {
                var record = this._context.students.FirstOrDefault(r => r.Id == id);
                this._context.students.Remove(record);
                this._context.SaveChanges();
                this.responce.Message = "Success"; this.responce.MessageCode = 200; this.responce.Data = record; this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = ex.Message; this.responce.MessageCode = StatusCodes.Status400BadRequest; this.responce.Data = (Student)ex.Data; this.responce.Success = false;
            }
            return responce;
        }

        public Response<List<Student>> GetAll()
        {
            var responce = new Response<List<Student>>();
            var records = this._context.students.ToList();
            try
            {
                responce.Message = "Success";
                responce.MessageCode = 200;
                responce.Data = this._context.students.ToList();
                responce.Success = true;
            }
            catch (Exception ex)
            {
                responce.Message = ex.Message; responce.MessageCode = StatusCodes.Status400BadRequest; responce.Data = (List<Student>)ex.Data; responce.Success = false;
            }
            return responce;
        }

        public Response<Student> GetById(int id)
        {
            try
            {
                this.responce.Message = "Success"; this.responce.MessageCode = 200;
                this.responce.Data = this._context.students.FirstOrDefault(r => r.Id == id);
                this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = ex.Message; this.responce.MessageCode = StatusCodes.Status400BadRequest;
                this.responce.Data = null; this.responce.Success = false;
            }
            return responce;
        }

        public Response<Student> Update(UpdateStudentDto rec)
        {
            var record = this._context.students.FirstOrDefault(r => r.Id == rec.Id);
            if (record != null) { 
            try
            {
                    record.FirstName = rec.FirstName;record.SecondName = rec.SecondName;record.ThirdName = rec.ThirdName;
                    record.FourthName = rec.FourthName;record.BirthLocation = rec.BirthLocation;record.NationalId = rec.NationalId;
                    record.DOB = rec.DOB;record.GradDate = rec.GradDate;record.GradeType = rec.GradeType;record.CountryId = rec.CountryId;
                    record.ReligionId = rec.ReligionId;
                    //if (rec.GradeImage != null)
                    //{
                    //    using (Stream stream = new FileStream(record.GradeImage, FileMode.Create))
                    //    {
                    //        rec.GradeImage.CopyTo(stream);
                    //    };
                    //} 
                    //if (rec)
                    //{

                    //}
                    if (rec.PersonalImage != null)
                    {
                        using (Stream stream = new FileStream(record.PersonalImage, FileMode.Create))
                        {
                            rec.PersonalImage.CopyTo(stream);
                        };
                    }
                    this._context.students.Update(record);
                    this._context.SaveChanges();
                this.responce.Message = "Success";
                this.responce.MessageCode = 200;
                this.responce.Data = record;
                this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = ex.Message;
                this.responce.MessageCode = StatusCodes.Status400BadRequest;
                this.responce.Data = null;
                this.responce.Success = false;
            }
            }
            return responce;
        }
    }
}
