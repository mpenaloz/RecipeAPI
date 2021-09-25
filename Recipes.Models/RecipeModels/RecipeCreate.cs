
using Recipe.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Models.RecipeModels
{
    public class RecipeCreate
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Recipe must have a title.")]
        [MaxLength(100)]
        public string Name { get; set; }

        public int PrepTime { get; set; }

        public int CookTime { get; set; }

        public float ServingSize { get; set; }

        public virtual ICollection<Ingredients> Ingredients { get; set; }
        [Required]
        public int CuisineId { get; set; }
    }
}
