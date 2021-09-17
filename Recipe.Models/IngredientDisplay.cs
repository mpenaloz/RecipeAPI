using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Models
{
    public class IngredientDisplay
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int Calories { get; set; }
        
        public int FoodId { get; set; }
    }
}
