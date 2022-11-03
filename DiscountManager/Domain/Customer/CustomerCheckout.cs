using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Domain.Customer
{
    public class CustomerCheckout : BaseEntity
    {
        public decimal Amount { get; set; }
        public MemberType Type { get; set; }
        public int Years { get; set; }

        public CustomerCheckout(decimal amount, MemberType type, int years)
        {
            if (!Enum.IsDefined(typeof(MemberType), type))
                throw new Exception("Member Type is not valid");

            if (amount < 0)
                throw new Exception("Amount can not be less than Zero");

            if (years < 0)
                throw new Exception("Years can not be less than Zero");

            Amount = amount;
            Type = type;
            Years = years;
        }
    }
}
