$(document).ready(function () {
    $("#deposit").hide();
});


$("#depositCheckbox").change(function () {
    if ($(this).prop('checked')) {
        $("#deposit").show();
    } else {
        $("#deposit").hide();
    }
})