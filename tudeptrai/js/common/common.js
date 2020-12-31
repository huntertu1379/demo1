
/**
 *Hàm sử lý dữ liệu ngày tháng 
 * @param {any} date kiểu dữ liệu bất kỳ
 * CreatedBy:naTu(21/12/2020)
 */
function fomatDate(date) {
    if (date){
        var dateDefault = new Date(date)
        var day = dateDefault.getDate();
        var month = dateDefault.getMonth() + 1;
        if (day < 10) {
            day = "0" + day;
        }
        var year = dateDefault.getFullYear();
        return day + "/" + month + "/" + year;
    } 
    return "";   
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
