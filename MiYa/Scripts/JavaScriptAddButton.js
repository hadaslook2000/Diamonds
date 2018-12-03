function f(id) {
    if (document.getElementById(id).innerHTML == "@Html.ActionLink('-', 'Edit', new { id = item.OrderId, rfqId = item.RfqId })")
        document.getElementById(id).innerHTML ="@Html.ActionLink('+', 'Edit', new { id = item.OrderId, rfqId = item.RfqId })";
else
        document.getElementById(id).innerHTML = "@Html.ActionLink('-', 'Edit', new { id = item.OrderId, rfqId = item.RfqId })";


}

//function hiddenDetails() {
//    divDetails.style.visibility = "hidden";
//    div
//}

//function visibleDetails() {
//    divDetails.style.visibility = "visible";
//}