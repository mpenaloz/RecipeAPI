﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data
{
    public class Food
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Ingredients> Ingredients { get; set; }
    }
}
