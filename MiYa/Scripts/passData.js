$(document).ready(function () {
    $(":input").keypress(function (event) {
        var ew = event.which;
        if (ew == 32 || ew == 64 || ew == 46 || ew == 40 || ew == 41)
            return true;
        else
        if (48 <= ew && ew <= 57)
            return true;
        else
        if (65 <= ew && ew <= 90)
            return true;
        else
        if (97 <= ew && ew <= 122)
            return true;
        else
        {
            alert("Type only English letters");
            return false;
        }
    });
    $('.goog-te-banner-frame').addClass('aaa');

    //function drop() {
    //    $('.goog-te-banner-frame').preventDefault();
    //    var data = $('.goog-te-banner-frame').dataTransfer.getData("Text1");
    //    $('.goog-te-banner-frame').target.appendChild(document.getElementById(data));
    //}
});

//$('.goog-te-banner-frame').addClass('aaa');

//function drop(ev) {
//            $('.goog-te-banner-frame').preventDefault();
//            var data = $('.goog-te-banner-frame').dataTransfer.getData("Text1");
//            $('.goog-te-banner-frame').target.appendChild(document.getElementById(data));
//}