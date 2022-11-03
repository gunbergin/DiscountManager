using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Domain.Customer;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public readonly string connectionString;
        //public CustomerRepository(IConfiguration configuration)
        //{
        //    connectionString = configuration?.GetConnectionString("ConnectionString") ?? throw new ArgumentNullException(nameof(configuration));
        //}

      
    }
}
