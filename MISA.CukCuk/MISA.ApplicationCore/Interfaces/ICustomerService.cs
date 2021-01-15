using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface ICustomerService:IBaseService<Customer>
    {
        /// <summary>
        /// Lấy dữ liệu phân trang
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy:naTu(15/1/2021)
        IEnumerable<Customer> GetCustomerByPaging(int limit, int offset);

        /// <summary>
        /// Lấy danh sách khách hàng theo mã nhóm khách hàng
        /// </summary>
        /// <param name="CustomerGroupId"></param>
        /// <returns>Danh sách khách hàng theo mã nhóm khách hàng</returns>
        /// CreatedBy:naTu(15/12/2021)
        IEnumerable<Customer> GetCustomerByGroupId(Guid CustomerGroupId);


    }
}
