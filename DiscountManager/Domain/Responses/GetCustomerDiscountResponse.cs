using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Responses
{
    public class GetCustomerDiscountResponse
    {
        public decimal DiscountPrice { get; set; }

        public string ErrorMessage { get; set; }
    }
}
