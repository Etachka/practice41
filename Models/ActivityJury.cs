using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Models
{
    [PrimaryKey("Id")]
    public class ActivityJury
    {
        public int Id { get; set; }

        public int JuryID { get; set; }
        public User Jury { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
