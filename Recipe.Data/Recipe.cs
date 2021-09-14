using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data
{
    public class Recipes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int PrepTime { get; set; }

        [Required]
        public int CookTime { get; set; }

        [Required]
        public float ServingSize { get; set; }

        public virtual ICollection<Ingredients> Ingredients { get; set; }

        [ForeignKey (nameof(Cuisine))]
        public int CuisineId { get; set; }

        public virtual Cuisine Cuisine{get;set;}


    }
}
