using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sigma.Models
{
    public class TypeCar
    {
        
        [Key]
        [Display(Name = "Number of type")]
        
        public int NumberOfType { get; set; }
        [Display(Name = "Type")]
        public string NameOfType { get; set; }
        [Display(Name = "Default Price")]
        public float DefaultPrice { get; set; }
    }
}
