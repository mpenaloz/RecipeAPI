using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data
{
    public class Recipess
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Recipe must have a title.")]
        [MaxLength(100)]
        public string Name { get; set; }

        public int PrepTime { get; set; }

        public int CookTime { get; set; }

        public float ServingSize { get; set; }
        public int Calories
        {
            get
            {
                int sum = 0;

                foreach (var ingredient in Ingredients)
                {
                    ingredient.Calories += sum;
                }
                return sum;
            }
        }

        public virtual ICollection<Ingredients> Ingredients { get; set; }

        [ForeignKey(nameof(Cuisine))]
        public int CuisineId { get; set; }
        public virtual Cuisine Cuisine{get;set;}


    }
}
