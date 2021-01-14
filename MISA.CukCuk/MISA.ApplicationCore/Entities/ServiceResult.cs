
using MISA.ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    public class ServiceResult
    {
        public object data { get; set; }
        public string Messenger { get; set; }
        public MisaCode MISACode { get; set; }
    }
}
