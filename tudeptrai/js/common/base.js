
class baseJs {

    constructor() {
        this.getUrl = null;
        this.setUrl();
        this.loadData();
        this.helo();
    }

    helo() {
        alert("tu dep trai");
    }
    setUrl() {

    }

    loadData() {
        try {

            //Lấy thông tin các cột dữ liệu
            var colnums = $('table thead th');
            var getUrl = this.getUrl;//Khai báo đường dẫn đến api

            $.ajax({
                url: getUrl,//Lấy dữ liệu từ api
                method: "GET",
                async: true,//hàm chạy trươc phải không có lỗi thì hàm chạy sau mới chạy đc
            }).done(function (res) {//Nếu lấy thành công thì làm gì đấy
                $.each(res, function (index, obj) {
                    var tr = $(`<tr></tr>`);//Truy vấn đến thẻ tr
                    $.each(colnums, function (index, th) {//Vòng lặp for:lấy giá trị của colnums tại vị trí index và gán vào obj
                        var td = $(`<td><div><span></span></div></td>`);//gán td là 1 chuỗi html
                        var fileName = $(th).attr('fileName');//Đọc giá trị các fileName:vd:EmployeesCode
                        var value = obj[fileName];//lấy giá trị các kết quả của obj.vd:obj["Employeecode"]=abcd gán vào value
                        var formatType = $(th).attr('formatType');//Đọc giá trị các formatType .vd:ddmmyyyy
                        switch (formatType) {
                            case "ddmmyyyy"://Nếu formatType=ddmmyyyy
                                td.addClass("text-align-center");//Thêm class css vào thẻ td
                                value = fomatDate(value);//gọi hàm sử lý ngày tháng sử lý giá trị cũ
                                break;
                            case "Money":
                                td.addClass("text-align-right");
                                value = fomartMoney(value);
                                break;
                            case "Adr":
                                td.addClass("max-width");
                                break;
                            default:
                                break;
                        }
                        if (fileName == "Gender" && value == 1) {
                            td.append(`<input type="checkbox" checked />`);
                        } else if (fileName == "Gender" && value != 1) {
                            td.append(`<input type="checkbox" />`);
                        } else {
                            td.append(value)//Nối chuỗi vào đầu thẻ<td>value</td>
                        }                       
                        $(tr).append(td);
                    })
                    $('table tbody').append(tr);
                })

            }).fail(function (res) {//Nếu lấy thất bại thì làm gì đấy

            })
        } catch (e) {
            console.log(e);
        }
    }
}

