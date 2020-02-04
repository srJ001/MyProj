using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Sigma.Models
{
    public class TypeCarViewModel
    {
        public List<Car> Cars { get; set; }
        public SelectList typesCar { get; set; }
        public string Type { get; set; }
        public string SearchString { get; set; }
    }
}
