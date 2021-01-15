using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity>
    {
        #region Declare
        IBaseRespository<TEntity> _baseRespository;
        #endregion

        #region Constructor
        public BaseService(IBaseRespository<TEntity> baseRespository)
        {
            _baseRespository = baseRespository;
        }
        #endregion

        public int AddCustomer(TEntity entity)
        {
            return _baseRespository.AddCustomer(entity);
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
            return _baseRespository.GetEntities();
        }

        public int UpdateCustomer(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
