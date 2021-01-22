using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Enum
{
    /// <summary>
    /// Misa code để xác định trạng thái của việc validate 
    /// </summary>
    public enum MisaCode
    {
        /// <summary>
        /// Dữ liệu hợp lệ
        /// </summary>
        Ivalid=100,

        /// <summary>
        /// Dữ liệu chưa hợp lệ
        /// </summary>
        Notvalid=900,

        /// <summary>
        /// Thêm mới thành công
        /// </summary>
        Success=200,

       Exception = 500
    }
}
