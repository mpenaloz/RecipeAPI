using Recipe.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Models
{
   public class Create_Cuisine
    {
        [Key]
        [Required]
       public int Cuisineid { get; set; }
        [Required]
      public string CuisineName { get; set; }
        public virtual ICollection<Recipes> Recipes { get; set; }
    }
}
