using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomailLayer.Models
{
    public class Student
    {
        [Key]
        public int Id{ get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName{ get; set; }
        [Required]
        [MaxLength(50)]
        public string SecondName { get; set; }
        [Required]
        [MaxLength(50)]
        public string ThirdName { get; set; }
        [Required]
        [MaxLength(50)]
        public string FourthName { get; set; }
        [Required]
        public string BirthLocation{ get; set; }
        [Required]
        [SwaggerSchema(Format = "date")]
        public DateTime? DOB{ get; set; }
        [Required]
        public string NationalId { get; set; }
        [Required]
        [SwaggerSchema(Format = "date")]
        public DateTime? GradDate { get; set; }
        [Required]
        public string GradeType{ get; set; }
        [Required]
        public int CountryId{ get; set; }
        public virtual Country Country{ get; set; }
        [Required]
        public int ReligionId { get; set; }
        public virtual Religion Religion { get; set; }
        [Required]
        public string GradeImage { get; set; }
        [Required]
        public string BirthImage{ get; set; }
        [Required]
        public string PersonalImage{ get; set; }
        [Required]
        public string MilitralImage{ get; set; }


    }
}
