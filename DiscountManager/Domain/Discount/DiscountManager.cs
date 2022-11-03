using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Discount
{
    public class DiscountManager
    {
        private IDiscountCalculator _calculator;

        public DiscountManager(IDiscountCalculator calculator)
        {
            _calculator = calculator;
        }



        public decimal GetDiscountedPrice(decimal amount, int years)
        {
            return _calculator.Calculate(amount, years);
        }

    }


    public class UnRegisteredDiscountCalculator : IDiscountCalculator
    {


        public decimal Calculate(decimal amount, int years)
        {
            return amount;
        }
    }

    public class RegisteredDiscountCalculator : IDiscountCalculator
    {

        private static decimal discountPercentageForMember = 0.1m;
        private static int yearLimit = 5;
        public decimal Calculate(decimal amount, int years)
        {
            decimal disc = (years > yearLimit) ? (decimal)yearLimit / 100 : (decimal)years / 100;
            return (amount - (discountPercentageForMember * amount)) - disc * (amount - (discountPercentageForMember * amount));
        }
    }

    public class ValuableDiscountCalculator : IDiscountCalculator
    {

        private const decimal discountPercentageForMember = 0.7m;
        private static readonly int yearLimit = 5;
        public decimal Calculate(decimal amount, int years)
        {
            decimal disc = (years > yearLimit) ? (decimal)yearLimit / 100 : (decimal)years / 100;
            return (discountPercentageForMember * amount) - disc * (discountPercentageForMember * amount);
        }
    }

    public class MostValuableDiscountCalculator : IDiscountCalculator
    {

        private const decimal discountPercentageForMember = 0.5m;
        private static readonly int yearLimit = 5;
        public decimal Calculate(decimal amount, int years)
        {
            decimal disc = (years > yearLimit) ? (decimal)yearLimit / 100 : (decimal)years / 100;
            return (amount - (discountPercentageForMember * amount)) - disc * (amount - (discountPercentageForMember * amount));
        }
    }







}
