$(document).ready(function () {

    $('#toggle-login').click(function () {
        $('#login').toggle();
    });

    $('#btnResetPassword').click(function () {
        var userName = $('#txtUserName').val();
        var hdnFromEmail = $('#hdnFromEmail').val();
        if (userName == '') {
            $("#txtUserName").parent().after("<div class='text-center validation' style='color:red;'>Please enter valid user name</div>");
        }
        else {
            $("#txtUserName").parent().next(".validation").remove(); // remove it
            if (CheckUserName(userName)) {
                if (SendEmail(userName)) {
                    $("#txtUserName").parent().after("<div class='text-center validation' style='color:green;'>Your password detail has been send to " + hdnFromEmail + " email id.</div>");
                }
                else {
                    $("#txtUserName").parent().after("<div class='text-center validation' style='color:red;'>Internal server occoured.Please contact admin for more detail</div>");
                }               
                $('#txtUserName').val('');
            }
            else {
                $("#txtUserName").parent().after("<div class='text-center validation' style='color:red;'>Please enter valid user name</div>");
            }

        }

    });
});

CheckUserName = function (userName) {
    var result;
    if (userName == '') {
        result = true;
    }
    else {
        $.ajax({
            type: "POST",
            url: "CreateUser.aspx/CheckUserName",
            contentType: "application/json; charset=utf-8",
            data: "{'userName':'" + userName + "','userId':" + 0 + "}",
            dataType: "json",
            async: false,
            success: function (data) {
                result = data.d;
            },
            error: AjaxFailed
        });
    }
    return result;
}

SendEmail = function (userName) {
    var result;
    if (userName == '') {
        result = true;
    }
    else {
        $.ajax({
            type: "POST",
            url: "CreateUser.aspx/SendEmail",
            contentType: "application/json; charset=utf-8",
            data: "{'userName':'" + userName + "'}",
            dataType: "json",
            async: false,
            success: function (data) {
                result = data.d;
            },
            error: AjaxFailed
        });
    }
    return result;
}
AjaxFailed = function (data) {
    console.log(data);
} 

