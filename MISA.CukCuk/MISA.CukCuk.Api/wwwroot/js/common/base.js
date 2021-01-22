class baseJs {

    constructor() {
        this.host = "";
        this.apiRouter = null;
        this.setapiRouter();
        this.loadData();
        this.initEvents();
    }

    /** 
     * Hàm gán đường dẫn đến api
     * CreatedBy:naTu(31/12/2020)
     * */
    setapiRouter() { }

    /**
     * Khởi tạo và xử lý các sự kiện
     * CreatedBy naTu {5/1/2021}
     * */
    initEvents() {
        var me = this;

        // Sự kiện click khi nhấn thêm mới
        $('#btnAdd').click(function () {
            me.formMode = "add";
            // Hiển thị dialog thông tin chi tiết
            $('.m-dialog').show();
            $(`input`).val(null);

            //var select = $(`select#cbxPositionName`);
            //select.empty();
            //$.ajax({
            //    url: me.host + me.apiRouter,
            //    method: "GET",
            //})

        })

        // Reload dữ liệu khi bấm refresh
        $('#btnRefresh').click(function () {
            this.loadData();
        }.bind(this))

        // Lưu dữ liệu khi bấm lưu
        $('#btnSave').click(me.btnSaveOnClick.bind(me));
        //    try {
        //        // Validate dữ liệu chung
        //        var inputValidates = $('input[required], input[type="email"]');//truy vấn đến những thẻ input có thuộc tính requied haowjc có type="email"
        //        $.each(inputValidates, function (index, input) {//Sét từng thẻ input vừa tìm được
        //            var value = $('input').val();//Đọc giá trị text trong ô input đó
        //            $('input').trigger('blur');//Tự động gán sự kiện blur cho thẻ input đó
        //        })
        //        var invalidInput = $('input[valid="false"]');//Truy cập đến những thẻ input có thuộc tính valid="false"
        //        if (invalidInput && invalidInput.length > 0) {//Nếu invalidInput khác null,>0 và độ dài khác 0
        //            alert("Dữ liệu không hợp lệ, vui lòng kiểm tra lại");
        //            invalidInput[0].focus();//Đưa con trỏ chuột vào vị trí invalidInput[0]
        //            return;
        //        }

        //        // Lấy dữ liệu từ form đưa vào object
        //        var employee = {};//Tạo đối tượng object rỗng
        //        var inputs = $('input[fielName]');//Truy cập đến FielName của thẻ input
        //        $.each(inputs, function (index, input) {//duyệt từng truwnowfg fielName 
        //            var propertyName = $(this).attr('fielName');//Lấy giá trị fielName
        //            var value = $(this).val();//Lấy giá trị value của thẻ input
        //            if ($(this).attr('type') == 'radio') {
        //                if (this.checked) {
        //                    employee[propertyName] = value;
        //                }
        //            } else {
        //                employee[propertyName] = value;//Gán cho object 1 thuộc tính fielName có giá trị là value
        //            }
        //        })

        //        //Kiểm tra thao tác(sửa hay xóa)
        //        var method = "POST"
        //        if (me.formMode == "edit") {
        //            method = "PUT";
        //            employee.EmployeeId = me.Id;
        //        }
        //        // Gọi service gửi về server
        //        $.ajax({
        //            url: me.host + me.apiRouter,
        //            method: method,
        //            data: JSON.stringify(employee),
        //            contentType: 'application/json',
        //        }).done(function (res) {
        //            // Hành động sau khi thêm thành công
        //            // + Thông báo thành công
        //            alert("Thêm thành công");
        //            // + Ẩn dialog thêm khách hàng
        //            $('.m-dialog').hide();
        //            // + Reload dữ liệu
        //            me.loadData();
        //        }).fail(function (res) {
        //            alert("thêm thất bại, vui lòng kiểm tra lại");
        //            console.log(res);
        //        })
        //    } catch (e) {
        //        console.log(e)
        //    }
        //})


        // Tắt dialog khi bấm icon đóng
        $('#btnClose').click(function () {
            // Ẩn dialog thông tin chi tiết
            $('.m-dialog').hide();
            $('table tbody td').removeClass(`row-selected`);
            $('input[required],input[type="Email"]').removeClass("border-red");
        })

        // Tắt dialog khi bấm hủy
        $('#btnCancel').click(function () {
            // Ẩn dialog thông tin chi tiết
            $('.m-dialog').hide();
            $('table tbody').find(`td`).removeClass(`row-selected`);
            $('input[required],input[type="Email"]').removeClass("border-red");
        })

        //Hiển thị thông tin chi thiết khi db-click 1 bản ghi
        //Xác định khu vực cần gần sự kiện:vd .trong bảng table-tbody
        $('table tbody'/*Phạm vi ảnh hưởng.Phải sinh r a trước khi thực hiện lệnh gán*/).on('dblclick'/*Sự kiện*/, 'tr'/*thẻ ảnh hưởng*/, function () {//gán sự kiện sau cho các phần tử được sinh ra sau lệnh gán 
            me.formMode = "edit";
            try {
                $(this).find(`td`).addClass(`row-selected`);
                $('.m-dialog').show();
                var Id = $(this).data('recordId');
                var inputs = $('input[fielName]');//Lấy ra tất cả các thẻ input có fielName
                $.ajax({
                    url: me.host + me.apiRouter + `/${Id}`,//Lấy dữ liệu từ api
                    method: "GET",
                }).done(function (res) {
                    var inputs = $(`input[fielName]`);
                    $.each(inputs, function (index, input) {
                        var propertyName = $(this).attr('fielName');
                        var value = res[propertyName];
                        $(this).val(value);
                    })
                })
                    .fail(function () { })
            } catch (e) {
                console.log(e);
            }
        })



        //Required field validator
        $('input[required]').blur(function () {
            //this.classList.add("border-red"); //native js
            var value = $(this).val();
            if (!value) {
                $(this).addClass("border-red");
                $(this).attr('title', 'Trường không được phép để trống');
                $(this).attr('valid', false);
            }
            else {
                $(this).removeClass('border-red');
                $(this).attr('valid', true);
            }
        })

        // Email format checker
        $('input[type="email"]').blur(function () {
            var value = $(this).val();
            var emailReg = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            if (!emailReg.test(value)) {
                $(this).addClass("border-red");
                $(this).attr('title', 'Định dạng email không đúng');
                $(this).attr('valid', false);
            } else {
                $(this).removeClass('border-red');
                $(this).attr('valid', true);
            }
        })

    }

    /**
     * Hàm load dữ liệu lên table
     * CreatedBy:naTu(31/12/2020)
     * */
    loadData() {
        $(`.loading`).show();
        $(`table tbody`).empty();
        try {
            //Lấy thông tin các cột dữ liệu
            var colnums = $('table thead th');
            //Khai báo đường dẫn đến api

            $.ajax({
                url: this.host + this.apiRouter,//Lấy dữ liệu từ api
                method: "GET",
                async: true,//hàm chạy trươc phải không có lỗi thì hàm chạy sau mới chạy đc
            }).done(function (res) {//Nếu lấy thành công thì làm gì đấy
                $.each(res, function (index, obj) {
                    var tr = $(`<tr></tr>`);//Truy vấn đến thẻ tr
                    $(tr).data('recordId', obj['EmployeeId']);
                    $.each(colnums, function (index, th) {//Vòng lặp for:lấy giá trị của colnums tại vị trí index và gán vào obj
                        var td = $(`<td><div><span></span></div></td>`);//gán td là 1 chuỗi html
                        var fileName = $(th).attr('fileName');//Đọc giá trị các fileName:vd:EmployeesCode
                        var value = obj[fileName];//lấy giá trị các kết quả của obj.vd:obj["Employeecode"]=abcd gán vào value
                        var formatType = $(th).attr('formatType');//Đọc giá trị các formatType .vd:ddmmyyyy
                        switch (formatType) {
                            case "ddmmyyyy"://Nếu formatType=ddmmyyyy
                                td.addClass("text-align-center");//Thêm class css vào thẻ td
                                value = formatDate(value);//gọi hàm sử lý ngày tháng sử lý giá trị cũ
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
                            td.append(`Trai thẳng`);
                        } else if (fileName == "Gender" && value == 0) {
                            td.append(`Nữ`);
                        } else if (fileName == "Gender" && value == 2) {
                            td.append(`BD`)
                        } else if (fileName == "WorkStatus" && value == 1) {
                            td.append(`Vẫn ngon lành cành đào :)`);
                        } else if (fileName == "WorkStatus" && value == 0) {
                            td.append(`Bị đuổi cmnr!`);
                        } else {
                            td.append(value)//Nối chuỗi vào đầu thẻ<td>value</td>
                        }                     
                        $(tr).append(td);
                    })
                    $('table tbody').append(tr);
                })
                $(`.loading`).hide();

            }).fail(function (res) {//Nếu lấy thất bại thì làm gì đấy

            })
        } catch (e) {
            console.log(e);
        }
    }

    /** ----------------------------------
    * Hàm xử lý khi nhấn button thêm mới
    * Author: naTu (25/12/2020)
    * */
    btnAddOnClick() {
        try {
            var me = this;
            me.FormMode = 'Add';
            // Hiển thị dialog thông tin chi tiết:
            dialogDetail.dialog('open');
            $('input').val(null);
            // load dữ liệu cho các combobox:
            var select = $('select#cbxCustomerGroup');
            select.empty();
            // lấy dữ liệu nhóm khách hàng:
            $('.loading').show();
            $.ajax({
                url: me.host + "/api/customergroups",
                method: "GET"
            }).done(function (res) {
                if (res) {
                    console.log(res);
                    $.each(res, function (index, obj) {
                        var option = $(`<option value="${obj.CustomerGroupId}">${obj.CustomerGroupName}</option>`);
                        select.append(option);
                        console.log(option);
                    })
                }
                $('.loading').hide();
            }).fail(function (res) {
                $('.loading').hide();
            })
        } catch (e) {
        }
    }

    /** ----------------------------------
     * Hàm xử lý khi nhấn button Lưu
     * Author: naTu (25/12/2020)
     * */
    btnSaveOnClick() {
        var me = this;
        // validate dữ liệu:
        try {
            // Validate dữ liệu chung
            var inputValidates = $('input[required], input[type="email"]');//truy vấn đến những thẻ input có thuộc tính requied haowjc có type="email"
            $.each(inputValidates, function (index, input) {//Sét từng thẻ input vừa tìm được
                var value = $(input).val();//Đọc giá trị text trong ô input đó
                if (value == "") {
                    $('input').trigger('blur');//Tự động gán sự kiện blur cho thẻ input đó
                }
               
            })
            var invalidInput = $('input[valid="false"]');//Truy cập đến những thẻ input có thuộc tính valid="false"
            if (invalidInput && invalidInput.length > 0) {//Nếu invalidInput khác null,>0 và độ dài khác 0
                    alert("Dữ liệu không hợp lệ, vui lòng kiểm tra lại");         
                invalidInput[0].focus();//Đưa con trỏ chuột vào vị trí invalidInput[0]
                return;
            }

            // Lấy dữ liệu từ form đưa vào object
            var employee = {};//Tạo đối tượng object rỗng
            var inputs = $('input[fielName]');//Truy cập đến FielName của thẻ input
            $.each(inputs, function (index, input) {//duyệt từng truwnowfg fielName 
                var propertyName = $(this).attr('fielName');//Lấy giá trị fielName
                var value = $(this).val();//Lấy giá trị value của thẻ input
                if ($(this).attr('type') == 'radio') {
                    if (this.checked) {
                        employee[propertyName] = value;
                    }
                } else {
                    employee[propertyName] = value;//Gán cho object 1 thuộc tính fielName có giá trị là value
                }
            })

            //Kiểm tra thao tác(sửa hay xóa)
            var method = "POST"
            if (me.formMode == "edit") {
                method = "PUT";
                employee.EmployeeId = me.Id;
            }
            // Gọi service gửi về server
            $.ajax({
                url: me.host + me.apiRouter,
                method: method,
                data: JSON.stringify(employee),
                contentType: 'application/json',
            }).done(function (res) {
                // Hành động sau khi thêm thành công
                // + Thông báo thành công
                alert("Thêm thành công");
                // + Ẩn dialog thêm khách hàng
                $('.m-dialog').hide();
                // + Reload dữ liệu
                me.loadData();
            }).fail(function (res) {
                alert("thêm thất bại, vui lòng kiểm tra lại");
                console.log(res);
            })
        } catch (e) {
            console.log(e)
        }
    }
}

