using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure.Reponsitory
{
     public class CustomerRepository :BaseRespository<Customer>, ICustomerRepository
    {
  
        public CustomerRepository(IConfiguration configuration):base(configuration)
        {

        }

        public Customer GetCustomerByCode(string customerCode)
        {
            return _dbConnection.Query<Customer>("Proc_GetCustomerByCode",new{CustomerCode=customerCode}, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }


    }


}
