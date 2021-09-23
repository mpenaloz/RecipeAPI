using Recipe.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Models.Cusine_Models
{
    public class CuisineEdit
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Recipess> Recipes { get; set; }
    }
}
