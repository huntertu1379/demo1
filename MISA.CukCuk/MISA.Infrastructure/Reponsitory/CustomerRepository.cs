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
            throw new NotImplementedException();
        }

        private DynamicParameters MappingDBType<TEntities>(TEntities entities)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = entities.GetType().GetProperties();
            foreach(var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entities);
                if (property.PropertyType == typeof(Guid))
                {
                    propertyValue = property.GetValue(entities).ToString();
                }
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            return dynamicParameters;
        }

    }


}
