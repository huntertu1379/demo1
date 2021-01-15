using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface ICustomerRepository:IBaseRespository<Customer>
    {
        Customer GetCustomerByCode(string customerCode);
    }
}
