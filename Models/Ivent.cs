﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Models
{
    public class Ivent
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public int IventName { get; set; }
        public DateTime? DateBegin { get; set; }
        public int? DurationDays { get; set; }

        [StringLength(100)]
        public string Winner { get; set; }
    }
}
