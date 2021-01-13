
using Dapper;
using MISA.CukCuk.Entities.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

//Lớp hạ tầng:dùng để thực hiện thao tác vs csdl
namespace MISA.Infrastructure
{
    public class CustomerContext
    {
        #region method
        //Lấy tất cả danh sách khách hàng
        /// <summary>
        /// Lấy tất cả danh sách khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy:naTu(13/1/2021)
        public IEnumerable<Customer> GetCustomers()
        {
            //Khai báo địa chỉ db
            var connectionString = "Host=103.124.92.43;Port=3306;Database=MISACukCuk_MF660_MVTHANH;User Id=nvmanh;Password=12345678";
            //Tạo kết nối với db
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            //Thực hiện câu truy vấn lấy danh sách kết quả
            var res = dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);
            //Trả về kết quả truy vấn
            return res;
        }
        
        /// <summary>
        /// Lấy thông tin một khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="id">Mã khách hàng</param>
        /// <returns>Thông tin một khách hàng</returns>
        /// CreatedBy:naTu(13/1/2021)
        public IEnumerable<Customer> GetCustomerById(Guid id)
        {
            //Khai báo địa chỉ d"
            var connectionString = "Host=103.124.92.43;Port=3306;Database=MISACukCuk_MF660_MVTHANH;User Id=nvmanh;Password=12345678";
            //Tạo kết nối với db
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            //Thực hiện câu truy vấn
            var res = dbConnection.Query<Customer>("Proc_GetCustomerById", new { CustomerId = id.ToString() }, commandType: CommandType.StoredProcedure);
            //trả về kết quả truy vấn
            return res;
        }
        /// <summary>
        /// Thêm mới một khách hàng
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        /// CreatedBy:naTu(13/1/2021)
        public int InsertCustomer(Customer customer)
        {

            //khai báo địa chỉ db
            var connectionString = "Host=;Port=;Database=;User Id=;Password=";
            //Tạo kết nối đến db
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            //Tạo đối tượng trung gian ghép thuộc tính vs giá trị
            DynamicParameters dynamicParameters = new DynamicParameters();
            //Lấy tất cả các thuộc tính public của đối tượng customer
            var properties = customer.GetType().GetProperties();
            //Duyệt từng thuộc tính vừa lấy ra
            foreach (var property in properties)
            {
                //Lấy ra tên thuộc tính
                var propertyName = property.Name;
                //gán giá trị cho thuộc tính
                var propertyValue = property.GetValue(customer);
                //nếu kiểu dữ liệu của thuộc tính là Guild thì chuyển về dạng String
                if (property.GetType() == typeof(Guid))
                {
                    propertyValue = property.GetValue(customer).ToString();
                }
                //Gán giá trị vào thuộc tính
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            //Thực hiện câu truy vấn
            var res = dbConnection.Execute("Proc_InsertCustomer", commandType: CommandType.StoredProcedure, param: dynamicParameters);
            //Trả về kết quả truy vấn
            return res;
        }

        //Chỉnh sửa thông tin một khách hàng

        //xóa một khách hàng


        #endregion
    }
}
