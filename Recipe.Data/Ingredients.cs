using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data
{
    public class Ingredients
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Calories { get; set; }

        [Required]
        public int FoodId { get; set; }

        public virtual ICollection<Recipes> Recipes { get; set; }

    }
}
