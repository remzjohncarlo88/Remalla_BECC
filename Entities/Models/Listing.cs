using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Listing
    {
        public string? Name { get; set; }

        public decimal PricePerPassenger { get; set; }

        public Vehicle VehicleType { get; set; }
    }
}
