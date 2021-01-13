using MISA.ApplicationCore.Entities;
using MISA.CukCuk.Entities.Model;
using MISA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public class CustomerService
    {
        #region method
        /// <summary>
        /// Lấy toàn bộ danh sách khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy:naTu(13/1/2021)
        public IEnumerable<Customer> GetCustomers()
        {
            //Khởi tạo đối tượng infrastructer
            var customerContext = new CustomerContext();
           //gán giá trị cho đối tượng customer mới bằng hàm GetCustomers
            var customers = customerContext.GetCustomers();
            //trả về danh sách Customer
            return customers;
        }

        /// <summary>
        /// Lấy thoogn tin khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="id">Mã khách hàng</param>
        /// <returns>Thông tin một khách hàng</returns>
        /// CreatedBy:naTu(13/1/2021)
        public IEnumerable<Customer> GetCustomerById(Guid id)
        {
            //Khởi tạo đối tượng infratructure
            var customerContext = new CustomerContext();
            //Gán giá trị cho đối tượng customer mới
            var customer = customerContext.GetCustomerById(id);
            //trả về kết quả truy vấn
            return customer;
            
        }

        public ServiceResult InsertCustomer(Customer customer)
        {
            //Khởi tạo đối tuowjgn infratructure
            var customerContext = new CustomerContext();
            //gọi hàm insert từ customerService;
            var res = customerContext.InsertCustomer(customer);
            //validate dữ liệu

                
                 

            return new ServiceResult();
        }

        #endregion
    }
}
