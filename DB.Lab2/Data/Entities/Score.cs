﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Lab2
{
    class Score
    {
        [Key]
        public int Id { get; set; }

        public int Points { get; set; }

    }
}