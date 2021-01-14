using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Model
{
    public class Customer
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// mã khách hàng
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// họ tên
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// số thẻ thành viên
        /// </summary>
        public string MemberCardCode { get; set; }

        /// <summary>
        /// nhóm khách hàng
        /// </summary>
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// giới tính
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// địa chỉ email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// tên công ty
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// mã số thuế công ty
        /// </summary>
        public string CompanyTaxCode { get; set; }

        /// <summary>
        /// địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// ngày chỉnh sửa cuối
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// người chỉnh sửa cuối
        /// </summary>
        public string ModifiedBy { get; set; }

        #endregion

    }
}
