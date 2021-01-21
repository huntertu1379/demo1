using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IBaseRespository<TEntity>
    {
        IEnumerable<TEntity> GetEntities();
        TEntity GetCustomerById(Guid entityId);
        int AddCustomer(TEntity entity);
        int UpdateCustomer(TEntity entity);
        int DeleteCustomer(Guid entityId);
        TEntity GetEntityBySpecs(string propertyName, object propertyValue);
    }
}
