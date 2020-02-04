using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sigma.Models
{
    public class Car
    {
      
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Manufacturer { get; set; }
        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string Model { get; set; }
        [Display(Name = "Engine Capacity")]
        [Column(TypeName = "decimal(18, 2)")]

        public decimal EngineCapacity { get; set; }
        [Display(Name = "Type of transmition")]
        public string TypeOfTransmition { get; set; }
        [Display(Name = "Additional characteristics")]
        public string AdditionalCharacteristics { get; set; }
        [Display(Name = "Price")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PriceRatio { get; set; }
        
        public int NumberOfType { get; set; }
        [Display(Name = "Type")]
        public string NameOfType { get; set; }
        public string PhotoWay { get; set; }
    }
}
