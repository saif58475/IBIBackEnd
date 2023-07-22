using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomailLayer.Models
{
    public class User
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
        public string email { get; set; }
        [Required]
        [MaxLength(50)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "بالرجاء كتابة كلمة مرور قوية")]
        public string Password { get; set; }
        [Required]
        public int RoleId{ get; set; }


    }
}
