using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sigma.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("Id")]
        public int CarId { get; set; }
        public int ManagerId { get; set; }
        public int UserId { get; set; }
        public DateTime StartOfRent { get; set; }
        public DateTime EndOfRent { get; set; }
        public DateTime DateOfOrder { get; set; }
        public decimal PriceToPay { get; set; }
    }
}
