using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Customer;
using Domain.Enums;
using Domain.Responses;
using MediatR;

namespace Domain.Requests
{
    public class GetCustomerDiscountRequest : IRequest<GetCustomerDiscountResponse>
    {
        public decimal Amount { get; set; }
        public MemberType Type { get; set; }
        public int Years { get; set; }
    }
}
