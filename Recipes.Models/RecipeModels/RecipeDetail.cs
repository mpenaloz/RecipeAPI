﻿using Recipe.Data;
using Recipes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Models.RecipeModels
{
    public class RecipeDetail
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PrepTime { get; set; }

        public int CookTime { get; set; }

        public float ServingSize { get; set; }
        public int Calories { get; set; }

        public virtual ICollection<Ingredients> Ingredients { get; set; }

        public Cuisine Cuisine { get; set; }
    }
}
