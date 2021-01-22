using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Model
{
    public class Employee:BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public string IdentityCardNumber { get; set; }
        public DateTime? LevelDate { get; set; }
        public string PlaceOfIssue { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PositionGroupName { get; set; }
        public string DepartmentGroupName { get; set; }
        public string PersonalTaxCode { get; set; }
        public float? Salary { get; set; }
        public DateTime? JoinDate { get; set; }
        public string WorkStatus { get; set; }

    }
}
