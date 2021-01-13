using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    class ServiceResult
    {
        public object data { get; set; }
        public string Messenger { get; set; }
        public int MISACode { get; set; }
    }
}
