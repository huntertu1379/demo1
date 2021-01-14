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
     public class CustomerRepository : ICustomerRepository
    {

        #region Declare
        IConfiguration _configuration;//Tạo đối tượng đọ cfile appsetting
        IDbConnection _dbConnection = null;
        string _connectionString = "";
        #endregion

        #region Contructor
        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnectionString");
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        public int AddCustomer(Customer customer)
        {
            var parameter = MappingDBType(customer);
            var res = _dbConnection.Execute("Proc_InsertCustomer", param: parameter, commandType: CommandType.StoredProcedure);
            return res;
        }

        public ServiceResult DeleteCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByCode(string customerCode)
        {
            var res = _dbConnection.Query<Customer>("Proc_GetCustomerByCode", new { customercode = customerCode.ToString() }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return res;
        }

        public Customer GetCustomerById(Guid customerId)
        {
            //Thực hiện câu truy vấn
            var res = _dbConnection.Query<Customer>("Proc_GetCustomerById", new { CustomerId = customerId.ToString() }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            //trả về kết quả truy vấn
            return res;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            //Thực hiện câu truy vấn lấy danh sách kết quả
            var res = _dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);
            //Trả về kết quả truy vấn
            return res; ;
        }

        public ServiceResult UpdateCustomer(Customer customer)
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
