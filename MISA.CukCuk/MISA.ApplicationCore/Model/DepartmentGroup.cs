using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Model
{
    class DepartmentGroup:BaseEntity
    {
       public Guid DepartmentGroupId{ get; set; }
       public string DepartmentGroupName{ get; set; }
       public string Description { get; set; }
    }
}
