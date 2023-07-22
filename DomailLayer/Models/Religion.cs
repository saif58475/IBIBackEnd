using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomailLayer.Models
{
    public class Religion
    {
        [Key]
        public int Id{ get; set; }
        [Required]
        [MaxLength(50)]
        public string ReligionName{ get; set; }
    }
}
