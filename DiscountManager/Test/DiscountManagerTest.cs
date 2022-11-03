using Domain.Requests;
using Domain.Responses;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Text;

namespace Test
{
    public class DiscountManagerTest
    {

        private HttpClient _httpClient;

        public DiscountManagerTest()
        {
            var webAppFactory = new WebApplicationFactory<Program>();

            _httpClient = webAppFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7252/");
            _httpClient.DefaultRequestHeaders.Add("Accept",
            "application/json");

        }
        [Fact]
        public async Task TestUnregistered()
        {
            GetCustomerDiscountRequest request = new GetCustomerDiscountRequest()
            {
                Amount = 200,
                Type = Domain.Enums.MemberType.Unregistered,
                Years = 3
            };

            var response = await SendRequestAsync(request);



            Assert.Equal((decimal)200,response.DiscountPrice);
        }

        [Fact]
        public async Task TestRegistered()
        {
            GetCustomerDiscountRequest request = new GetCustomerDiscountRequest()
            {
                Amount = 200,
                Type = Domain.Enums.MemberType.Registered,
                Years = 3
            };

            var response = await SendRequestAsync(request);



            Assert.Equal((decimal)174.6, response.DiscountPrice);
        }

        [Fact]
        public async Task TestValuable()
        {
            GetCustomerDiscountRequest request = new GetCustomerDiscountRequest()
            {
                Amount = 200,
                Type = Domain.Enums.MemberType.Valuable,
                Years = 3
            };

            var response = await SendRequestAsync(request);



            Assert.Equal((decimal)135.8, response.DiscountPrice);
        }

        [Fact]
        public async Task TestMostValuable()
        {
            GetCustomerDiscountRequest request = new GetCustomerDiscountRequest()
            {
                Amount = 200,
                Type = Domain.Enums.MemberType.Mostvaluable,
                Years = 3
            };

            var response = await SendRequestAsync(request);



            Assert.Equal((decimal)97, response.DiscountPrice);
        }

        public async Task<GetCustomerDiscountResponse> SendRequestAsync (GetCustomerDiscountRequest request)
        {

            string json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("Customer/GetCustomerDiscountPrice", content);
            var result = JsonConvert.DeserializeObject<GetCustomerDiscountResponse>(await response.Content.ReadAsStringAsync());
            return result;
        }
    }
}