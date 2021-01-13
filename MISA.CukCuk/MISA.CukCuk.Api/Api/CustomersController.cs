using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore;
using MISA.CukCuk.Entities.Model;
using MySql.Data.MySqlClient;

namespace MISA.CukCuk.Api.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        #region function for Customer
        /// <summary>
        /// Lấy tất cả thông tin khách hàng từ db 
        /// </summary>
        /// <returns>Customer(list)</returns>
        /// CreatedBy:naTu(12/1/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var customerService = new CustomerService();
            var customers = customerService.GetCustomers();
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
            var customerService = new CustomerService();
            var customer = customerService.GetCustomerById(id);
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
            //khai báo địa chỉ db
            string connectionString = "Host=103.124.92.43;Port=3306;Database=MS0_147_NVMANH_CukCuk;User Id=nvmanh;Password=12345678;";
            //Tạo kết nối vs db
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            //tạo đối tượng lưu trữ thông tin cần lưu vào csdl
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = customer.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(customer);
                if (property.PropertyType == typeof(Guid))
                {
                    propertyValue = property.GetValue(customer).ToString();
                }
                dynamicParameters.Add($"@{propertyName}", propertyValue);

            }
            //thưc hiện câu truy vấn
            var res = dbConnection.Execute("Proc_InsertCustomer", commandType: CommandType.StoredProcedure, param: dynamicParameters);
            //trả về kết quả truy vấn
            if (res > 0)
            {
                return Created("tạo thành công", customer);
            }
            return BadRequest("lỗi nhập dữ liệu");
        }

        /// <summary>
        /// Chỉnh sửa thông tin một khách hàng
        /// </summary>
        /// <returns></returns>
        ///CreatedBy:naTu(12/1/2021)
        [HttpPut]
        public IActionResult put([FromBody]Customer customer)
        {
            //Khai báo địa chỉ db
            string connectionString = "Host= ;Port= ;Database= ;User Id= ;Password=";
            //Tạo kết nối với db
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            //Tạo đối tượng lưu trữ thông tin cần sửa
            DynamicParameters dynamicParameters = new DynamicParameters();//đối tượng map name vs value
            var properties = customer.GetType().GetProperties();//Lấy ra tất cả thuộc tính có phạm vi truy cập là public
            foreach(var property in properties)//Vòng lặp duyệt từng thuộc tính
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
            var res = dbConnection.Execute("update...", commandType: CommandType.Text ,param: dynamicParameters);
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
            var res = dbConnection.Execute("delete...", new { CustomerId = id.ToString()}, commandType: CommandType.StoredProcedure);

            //trả về kết quả truy vấn
            return Ok(res);
        }
#endregion
    }

}
