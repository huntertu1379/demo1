using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Model
{
    public class Employee
    {
        public string EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public string IdentityCardNumber { get; set; }
        public DateTime? LevelDate { get; set; }
        public string PlaceOfIssue { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PositionName { get; set; }
        public string DepartmentName { get; set; }
        public string PersonalTaxCode { get; set; }
        public float? Salary { get; set; }
        public string JoinDate { get; set; }
        public string JobStatus { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
