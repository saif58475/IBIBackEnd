using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomailLayer.DTOS
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
