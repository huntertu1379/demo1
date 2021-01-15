
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Enum;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Model;
using MISA.ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Service
{
    public class CustomerService:BaseService<Customer>, ICustomerService
    {
        #region Constructor
        IBaseRespository<Customer> _customerRepository;
        public CustomerService(IBaseRespository<Customer> customerRepository):base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetCustomerByGroupId(Guid CustomerGroupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomerByPaging(int limit, int offset)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region method
        ///// <summary>
        ///// Lấy toàn bộ danh sách khách hàng
        ///// </summary>
        ///// <returns>Danh sách khách hàng</returns>
        ///// CreatedBy:naTu(13/1/2021)
        //public IEnumerable<Customer> GetCustomers()
        //{
        //    //gán giá trị cho đối tượng customer mới bằng hàm GetCustomers
        //    var customers = _customerRepository.GetCustomers();
        //    //trả về danh sách Customer
        //    return customers;
        //}


        ///// <summary>
        ///// Lấy thoogn tin khách hàng theo mã khách hàng
        ///// </summary>
        ///// <param name="id">Mã khách hàng</param>
        ///// <returns>Thông tin một khách hàng</returns>
        ///// CreatedBy:naTu(13/1/2021)
        //Customer ICustomerService.GetCustomerById(Guid customerId)
        //{
        //    //Gán giá trị cho đối tượng customer mới
        //    var customer = _customerRepository.GetCustomerById(customerId);
        //    //trả về kết quả truy vấn
        //    return customer;
        //}

        //public ServiceResult AddCustomer(Customer customer)
        //{
        //    var serviceRedult = new ServiceResult();//Tạo đối tượng thông báo lỗi
        //    //validate dữ liệu
        //    //Check trường hợp băt buộc nhập,nếu dữ liệu chưa hợp lệ thì trả về mô tả lỗi
        //    var customerCode = customer.CustomerCode;//Lấy ra mã khách hàng từ body
        //    if (String.IsNullOrEmpty(customerCode))//Nếu customerCode null hoặc rỗng
        //    {
        //        var msg = new//tạo object lưu trữ thông báo cho dev,user
        //        {
        //            devMsg = new { fieldName = "CustomerCode", msg = "Mã khách hàng không hợp lệ", userMsg = "Mã khách hàng không được bỏ trống" },

        //            userMsg = "Mã khách hàng không được bỏ trống",
        //            Code = MisaCode.Notvalid,
        //        };
        //        serviceRedult.MISACode = MisaCode.Notvalid;
        //        serviceRedult.Messenger = "MÃ khách hàng không được bỏ trống";
        //        serviceRedult.data = msg;
        //        return serviceRedult;
        //    }
        //    //Check trùng mã
        //    var res = _customerRepository.GetCustomerByCode(customerCode);//Gọi hàm lấy thông tin khách hàng theo mã khách hàng
        //    if (res != null)//nếu kết quả trả về khác null
        //    {
        //        var msg = new
        //        {
        //            devMsg = new { fieldName = "CustomerCode", msg = "Mã khách hàng không hợp lệ", userMsg = "Mã khách hàngđã tồn tại" },

        //            userMsg = "Mã khách hàng đã tồn tại",
        //            Code = 900,
        //        };

        //        serviceRedult.MISACode = MisaCode.Notvalid; ;
        //        serviceRedult.Messenger = "Mã khách hàng kđã tồn tại";
        //        serviceRedult.data = msg;
        //        return serviceRedult;
        //    }


        //    //Thêm mới khi dữ liệu đã hợp lệ
        //    var rowAffects = _customerRepository.AddCustomer(customer);
        //    serviceRedult.MISACode = MisaCode.Success; ;
        //    serviceRedult.Messenger = "Thêm mới thành công";
        //    serviceRedult.data = rowAffects;
        //    return serviceRedult;
        //}

        //public ServiceResult UpdateCustomer(Customer customer)
        //{
        //    throw new NotImplementedException();
        //}

        //public ServiceResult DeleteCustomer(Guid customerId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Customer GetCustomerByCode(string customerCode)
        //{
        //    var res = _customerRepository.GetCustomerByCode(customerCode);
        //    return res;
        //}



        #endregion
    }
}
