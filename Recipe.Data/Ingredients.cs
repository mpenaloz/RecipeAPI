using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data
{
    public class Ingredients
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public int Calories { get; set; }

        [ForeignKey(nameof(Food))]
        public int FoodId { get; set; }

        public virtual ICollection<Food> Food { get; set; }

    }
}
