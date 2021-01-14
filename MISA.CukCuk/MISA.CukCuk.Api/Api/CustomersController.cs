using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore;
using MISA.ApplicationCore.Enum;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Model;
using MISA.ApplicationCore.Service;
using MySql.Data.MySqlClient;

namespace MISA.CukCuk.Api.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        #region Constructor
        ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        #endregion
        #region function for Customer
        /// <summary>
        /// Lấy tất cả thông tin khách hàng từ db 
        /// </summary>
        /// <returns>Customer(list)</returns>
        /// CreatedBy:naTu(12/1/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var customers = _customerService.GetCustomers();
            return Ok(customers);
        }

        /// <summary>
        /// Lấy thông tin khách hàng theo id
        /// </summary>
        /// <param name="id">id của khách hàng</param>
        /// <returns></returns>
        /// CreatedBy:naTu(12/1/2021)
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var customer = _customerService.GetCustomerById(id);
            //trả về kết quả truy vấn
            return Ok(customer);
        }


        /// <summary>
        /// Thêm mới một khách hàng lên db
        /// </summary>
        /// <returns></returns>
        /// CreatedBy:naTu(12/1/2021)
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {

            var serviceResult = _customerService.AddCustomer(customer);
            if (serviceResult.MISACode == MisaCode.Notvalid)
            {
                return BadRequest(serviceResult.data);
            }
            if (serviceResult.MISACode == MisaCode.Ivalid && (int)serviceResult.data > 0)
            {
                return Ok(serviceResult.data);
            }
            else
                return NoContent();

        }

        /// <summary>
        /// Chỉnh sửa thông tin một khách hàng
        /// </summary>
        /// <returns></returns>
        ///CreatedBy:naTu(12/1/2021)
        [HttpPut]
        public IActionResult put([FromBody] Customer customer)
        {
            //Khai báo địa chỉ db
            string connectionString = "Host= ;Port= ;Database= ;User Id= ;Password=";
            //Tạo kết nối với db
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            //Tạo đối tượng lưu trữ thông tin cần sửa
            DynamicParameters dynamicParameters = new DynamicParameters();//đối tượng map name vs value
            var properties = customer.GetType().GetProperties();//Lấy ra tất cả thuộc tính có phạm vi truy cập là public
            foreach (var property in properties)//Vòng lặp duyệt từng thuộc tính
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(customer);

                if (propertyValue.GetType() == typeof(Guid))
                {
                    propertyValue = property.GetValue(customer).ToString();
                }
                dynamicParameters.Add($"@{propertyName}", propertyValue);//thực hiện gán value cho thuộc tính
            }
            //Thực hiện câu truy vấn
            var res = dbConnection.Execute("update...", commandType: CommandType.Text, param: dynamicParameters);
            //Trả về kết quả truy vấn
            return Ok();
        }


        /// <summary>
        /// Xóa thông tin một khách hàng khỏi db
        /// </summary>
        /// <param name="id">id của khách hàng</param>
        /// <returns></returns>
        /// CreatedBy:naTu(12/1/2021)
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            //Khai báo địa chỉ db
            var connectionString = "Host= ;Port= ;Database= ;User Id= ;Password= ";
            //Tạo kết nối đến db
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            //Lấy dữ liệu từ db
            var res = dbConnection.Execute("delete...", new { CustomerId = id.ToString() }, commandType: CommandType.StoredProcedure);

            //trả về kết quả truy vấn
            return Ok(res);
        }
        #endregion
    }

}
