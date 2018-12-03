

$(document).ready(function () {
    
    $("#carat").keypress(function (event) {
        var ew = event.which;

        if (!(48 <= ew && ew <= 57)) {
            alert("Type only numbers");
            return false;
        }        
        if (!$("#Quantity").text() == "")
        $("TotalCt").text(parseInt($("#carat").text()) + parseInt($("#Quantity").text()) + "");
    });
    $("#Quantity").keypress(function (event) {
        var ew = event.which;

        if (!(48 <= ew && ew <= 57)) {
            alert("Type only numbers");
            return false;
        }
        if (!$("#carat").text() == "")
        $("TotalCt").text( parseInt($("#carat").text()) + parseInt($("#Quantity").text()) + "");
    });
});
