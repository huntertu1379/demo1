window.addEventListener("load", function () {
    new EmployeeJS();
})


class EmployeeJS {


    /**
     * Hàm khởi tạo
     * CreatedBy:naTu(31/12/2020)
     * */
    constructor() {
        this.loadData();
    }


    /**
     * Hàm tạo các event
     * CreatedBy:naTu(31/12/2020)
     * */
    createdEvent() {



    }

    // #region hàm lấy dữ liệu

    /**
     * hàm load dữ liệu
     * CreatedBy:naTu(21/12/2020)
     * */
    loadData() {
        //Lấy dữ liệu
        $.ajax({
            url: "http://api.manhnv.net/api/customers",
            method: "GET"
        }).done(function (res) {
            var data =  res;
            //Đẩy dữ liệu lên table
            console.table(data);
            
            for (var i = 0; i < data.length; i++) {              
                var date = fomatDate(data[i].DateOfBirth);
                var money = fomartMoney(data[i].DebitAmount);
                var checkbox = `<input type="checkbox" />`;
                if (data[i].Gender > 0) {
                    var checkbox = `<input type="checkbox" checked />`;
                }
                var tr = $(`<tr>
                        <td> ${data[i].CustomerId} </td>
                        <td>${data[i].FullName} </td>
                        <td style="text-align:center">`+ date + `</td>
                        <td>`+ checkbox +`</td>
                        <td>${data[i].CustomerGroupName} </td>
                        <td>${data[i].PhoneNumber} </td>
                        <td>${data[i].Email} </td>
                        <td style="max-width:100px">${data[i].Address}</td>
                        <td style="text-align:right">`+money+`</td >
                        <td>${data[i].MemberCardCode} </td>
                    </tr>`);
                $('table tbody').append(tr);
            }           
        }).fail(function (res) {
            console.warn(res);
        })



    }
    // #endregion 


    // #region Các hàm sử lý dữ liệu
    /**
     * Hàm thêm sữ liệu
     * CreatedBy:naTu(31/12/2020)
     * */
    add() {

    }

    /**
     *Hàm sửa dữ liệu
     * CreatedBy:naTu(31/12/2020)
     * */
    update() {
        
    }

    /**
     * Hàm xóa dữ liệu
     * CreatedBy:naTu(l31/12/2020)
     * */
    delete() {

    }

    // #endregion



}