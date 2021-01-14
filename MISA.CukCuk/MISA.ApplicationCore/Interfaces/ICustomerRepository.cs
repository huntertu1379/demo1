using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(Guid customerId);
        int AddCustomer(Customer customer);
        ServiceResult UpdateCustomer(Customer customer);
        ServiceResult DeleteCustomer(Guid customerId);
        Customer GetCustomerByCode(string customerCode);
    }
}
