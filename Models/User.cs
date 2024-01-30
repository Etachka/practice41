using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Models
{
    public class User
    {
        public int Id { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronomic { get; set; }

        public string Email { get; set; }


        public string Gender { get; set; }

        public DateTime? Birthday { get; set; }

        public int? CountryID { get; set; }
        public Country? Country { get; set; }

        public string Phone { get; set; }

        public int? DirectionId { get; set; }
        public Direction? Direction { get; set; }

        public string Password { get; set; }

        public string? Photo { get; set; }

        public override string ToString()
        {
            return Surname + " " + Name + " " + Patronomic;
        }
    }
}
