using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Domain.Customer;
using Domain.Dictionary;
using Domain.Discount;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Requests;
using Domain.Responses;

namespace Application.Handlers
{
    public class GetCustomerDiscountHandler : IRequestHandler<GetCustomerDiscountRequest, GetCustomerDiscountResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetCustomerDiscountHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }
        public async Task<GetCustomerDiscountResponse> Handle(GetCustomerDiscountRequest request, CancellationToken cancellationToken)
        {
            var response = new GetCustomerDiscountResponse();
            try
            {

                CustomerCheckout customerCheckout = new CustomerCheckout(request.Amount, request.Type, request.Years);

                DiscountManager discountManager = new DiscountManager(CommonDictionary.DiscountObjects[customerCheckout.Type]);
                response.DiscountPrice = (decimal)discountManager.GetDiscountedPrice(customerCheckout.Amount, customerCheckout.Years);



                return response;
            }
            catch (Exception ex)
            {

                response.ErrorMessage = ex.Message.ToString();
                return response;

            }


        }



    }
}
