using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Model
{
    /// <summary>
    /// kiểm tra bắt buộc nhập
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class Requirt : Attribute
    {

    }


    /// <summary>
    /// Kiểm tra trùng mã
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate:Attribute
    {

    }

    /// <summary>
    /// Kiểm tra khóa chính
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey:Attribute
    {

    }

    public class BaseEntity
    {
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
    }
}
