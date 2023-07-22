using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomailLayer.DTOS
{
    public class UpdateStudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string FourthName { get; set; }
        public string BirthLocation { get; set; }
        public DateTime? DOB { get; set; }
        public string NationalId { get; set; }
        public DateTime? GradDate { get; set; }
        public string GradeType { get; set; }
        public int CountryId { get; set; }
        public int ReligionId { get; set; }
        public IFormFile? GradeImage { get; set; }
        public IFormFile? BirthImage { get; set; }
        public IFormFile? PersonalImage { get; set; }
        public IFormFile? MilitralImage { get; set; }
    }
}
