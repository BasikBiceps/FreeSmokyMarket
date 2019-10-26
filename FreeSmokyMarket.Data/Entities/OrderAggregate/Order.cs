using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeSmokyMarket.Data.Entities
{
    public class Order
    {
        // TODO
        // here on my opinion FirstName, LastName, Address,
        // PhoneNumber should be in separate table
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public Basket Basket { get; set; }
    }
}
