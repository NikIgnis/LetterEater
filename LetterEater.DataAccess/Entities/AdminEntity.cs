﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.DataAccess.Entities
{
    public class AdminEntity
    {
        [Key]
        public Guid AdminId { get; set; }

        public string Name { get; set; }

        public string Surename { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}