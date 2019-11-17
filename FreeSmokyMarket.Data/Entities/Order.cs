using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FreeSmokyMarket.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public DateTime OrderDate { get; set; }
    }
}