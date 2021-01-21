using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure.Reponsitory
{
    public class BaseRespository<TEntity> : IBaseRespository<TEntity>
    {
        #region Declare
        IConfiguration _configuration;//Tạo đối tượng đọ cfile appsetting
        protected IDbConnection _dbConnection = null;
        string _connectionString = "";
        protected string TableName=typeof(TEntity).Name;
        #endregion

        #region Contructor
        public BaseRespository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnectionString");
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        public int AddCustomer(TEntity entity)
        {
            var parameter = MappingDBType(entity);
            var res = _dbConnection.Execute($"Proc_Insert{TableName}", param: parameter, commandType: CommandType.StoredProcedure);
            return res;
        }

        public int DeleteCustomer(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public TEntity GetCustomerById(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetEntities()
        {
            return _dbConnection.Query<TEntity>("Proc_GetCustomers", commandType: CommandType.StoredProcedure); ;
        }

        public int UpdateCustomer(TEntity entity)
        {
            throw new NotImplementedException();
        }

        private DynamicParameters MappingDBType(TEntity entities)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = entities.GetType().GetProperties();
            foreach (var property in properties)
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

        public TEntity GetEntityBySpecs(string propertyName, object propertyValue)
        {
            return _dbConnection.Query<TEntity>($"Select * from {TableName} Where {propertyName}='{propertyValue}'").FirstOrDefault();
        }
        #endregion
    }
}
