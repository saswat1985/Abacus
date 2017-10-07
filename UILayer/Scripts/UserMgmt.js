CheckFormValidity = function () {
    var result = true;
    var txtUserName, emailId, ipaddress, userRole, firstName, lastName;
    var ipAddressValue,

    txtUserName = document.getElementById('txtUserName').value;
    emailId = document.getElementById('txtEmailId').value;
    ipaddress = document.getElementById('ddlIPAddress');
    userRole = document.getElementById('ddlUserRole');
    firstName = document.getElementById('txtFirstName').value;
    lastName = document.getElementById('txtLastName').value;
    ipAddressValue = ipaddress.options[ipaddress.selectedIndex].value;
    if (CheckUserName(txtUserName, 0)) {
        alert('User name Exists in system or invalid User name');
        document.getElementById('txtUserName').value = '';
        result = false;
        return result;
    }

    if (firstName == '') {
        alert('Enter First Name');
        result = false;
        return result;
    }

    if (lastName == '') {
        alert('Enter Last Name');
        result = false;
        return result;
    }

    if (!isEmail(emailId)) {
        alert('Not a valid E-mail ID');
        result = false;
        return result;

    }

    //    if (CheckEmailID(emailId, 0)) {
    //        alert('Email ID Already exist or Invalid Email id');
    //        document.getElementById('txtEmailId').value = '';
    //        result = false;
    //        return result;
    //    }
    if (ipAddressValue == "0") {
        alert('Select any IP Address');
        result = false;
        return result;
    }

    if (userRole.options[userRole.selectedIndex].value == "0") {
        alert('Select any user role');
        result = false;
        return result;
    }


    return result;
}

function isEmail(email) {
    return /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$/i.test(email);
}

CheckUserName = function (userName, userId) {
    var result;
    if (userName == '') {
        result = true;
    }
    else {
        $.ajax({
            type: "POST",
            url: "CreateUser.aspx/CheckUserName",
            contentType: "application/json; charset=utf-8",
            data: "{'userName':'" + userName + "','userId':" + userId + "}",
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

CheckEmailID = function (emailId, userId) {
    var result;
    if (emailId == '') {
        result = true;
    }
    else {
        $.ajax({
            type: "POST",
            url: "CreateUser.aspx/CheckEmailID",
            contentType: "application/json; charset=utf-8",
            data: "{'emailId':'" + emailId + "','userId':" + userId + "}",
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
