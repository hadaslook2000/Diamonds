$(document).ready(function () {
    $(".quant").keypress(function()
    {
        var q = $(this).closest("tr").find(".quant").val();
        var t = $(this).closest("tr").find(".total").val();
        var c = $(this).closest("tr").find(".carat").val();
        c=


    })
});



//$(document).ready(function () {
//    $('#AjaxGrid tbody tr').click(function () {
//        var selectedraw = $(this).closest("tr");
//        var quantityElem = selectedraw.find(".quant");
//var qantity  = $(quantityElem).val();
//        var url = "FamousFolks/GetFamousFolk/" + id;
//        $.post(url,
//               null,
//               function (folk) {
//                   $('#bio').html(folk.Bio);
//               }
//        );
//    })
//});