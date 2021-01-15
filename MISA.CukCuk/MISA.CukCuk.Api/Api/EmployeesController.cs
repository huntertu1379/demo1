using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Model;

namespace MISA.CukCuk.Api.Api
{
    public class EmployeesController : BaseEntityController<Employee>
    {
        #region Declare
        IBaseService<Employee> _baseService;
        #endregion

        #region Constructor
        public EmployeesController(IBaseService<Employee> baseService):base(baseService)
        {
            _baseService = baseService;
        }
        #endregion
    }
}
