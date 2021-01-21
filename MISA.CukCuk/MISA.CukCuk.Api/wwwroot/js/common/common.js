
/**
 *Hàm sử lý dữ liệu ngày tháng 
 * @param {any} date kiểu dữ liệu bất kỳ
 * CreatedBy:naTu(21/12/2020)
 */
function formatDate(date) {
    var date = new Date(date);
    if (Number.isNaN(date)) {
        return "";
    } else {
        var day = date.getDate();
        if (day < 10)
            day = '0' + day;
        var month = date.getMonth() + 1;
        month = month < 10 ? '0' + month : month;
        var year = date.getFullYear();
        return day + "/" + month + "/" + year;
    }
}


/**
 * Hàm định dạng tiền tệ
 * @param {Number} money sô tiền
 * CreatedBy:naTu(31/12/2020)
 */
function fomartMoney(money) {
    if (money) {
        var p = money.toFixed(2).split(".");
        return "$" + p[0].split("").reverse().reduce(function (acc, money, i, orig) {
            return money == "-" ? acc : money + (i && !(i % 3) ? "," : "") + acc;
        }, "") + "." + p[1];
    }
    return "";
}
