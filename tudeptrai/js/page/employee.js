window.addEventListener("load", function () {
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

    setUrl() {
        this.getUrl = "http://api.manhnv.net/api/employees";
    }
}