using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Discount;
using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Dictionary
{
    public static class CommonDictionary { 

    public static readonly Dictionary<MemberType, IDiscountCalculator> DiscountObjects = new Dictionary<MemberType, IDiscountCalculator>
            {
                {MemberType.Unregistered, new UnRegisteredDiscountCalculator() },
                {MemberType.Registered,  new RegisteredDiscountCalculator() },
                {MemberType.Valuable,  new ValuableDiscountCalculator() },
                {MemberType.Mostvaluable,  new MostValuableDiscountCalculator() }
            };
}

}
