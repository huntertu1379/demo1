$(document).ready(function () {
    new EmployeeJS();
})


class EmployeeJS extends baseJs {
    /**
  * Hàm khởi tạo
  * CreatedBy:naTu(31/12/2020)
  * */
    constructor() {
        super();
    }

    setapiRouter() {
        this.apiRouter = "/api/V1/employees";
    }
}