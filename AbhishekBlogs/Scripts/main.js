function datetime(h) {
  
    (function (g) {
        var c = Alldefaultconfig, e = { months: c.timemonthName, dateplace: "tglxnya", timeplace: "clockx", timeFormat: c.timeFormat }, e = g.extend({}, e, h), b = new Date; g = b.getDate(); c = b.getMonth(); b = b.getYear(); b = 1E3 > b ? b + 1900 : b; document.getElementById(e.dateplace).innerHTML = e.months[c] + " " + g + ", " + b; var f = function (a) { 10 > a && (a = "0" + a); return a }; setInterval("12" === e.timeFormat ? function () {
            var a = "", a = new Date, d = a.getHours(), b = a.getMinutes(), c = a.getSeconds(), a = 12 > d ? "AM" : "PM"; 0 == d && (d = 12); 12 < d &&
            (d -= 12); d = f(d); b = f(b); c = f(c); document.getElementById(e.timeplace).innerHTML = d + ":" + b + ":" + c + " " + a
        } : function () { var a = new Date, b = a.getHours(), c = a.getMinutes(), a = a.getSeconds(), b = f(b), c = f(c), a = f(a); document.getElementById(e.timeplace).innerHTML = b + ":" + c + ":" + a }, 500)
    })(jQuery)
};

//Navigation Call by MKR
function menunav(c) {
    c("#mobilenav").click(function () {("#menunav").slideToggle(); c(this).toggleClass("active"); return false }); c("#topmobilenav").click(function () { c("#topmenunav").slideToggle(); c(this).toggleClass("active"); return false }); c(".sf-menu ul").each(function () { var e = c(this).parent("li"); e.append("<i></i>") }); var b = function () { var e = c(window).width(); if (e > 979) { c("#menunav").css("display", "block"); c("#menunav").superfish({ animation: { height: "show" }, animationOut: { height: "hide" } }); c(".sf-menu i").css("display", "none") } else { if (e <= 979 && c("#mobilenav").attr("class") === "active") { c("#menunav").css("display", "block"); c("#menunav").superfish("destroy"); c(".sf-menu i").css("display", "block") } else { if (e <= 979 && c("#mobilenav").attr("class") !== "active") { c("#menunav").css("display", "none"); c("#menunav").superfish("destroy"); c(".sf-menu i").css("display", "block") } } } }; var a = function () { var e = c(window).width(); if (e > 979) { c("#topmenunav").css("display", "block"); c("#topmenunav").superfish({ animation: { height: "show" }, animationOut: { height: "hide" } }); c(".sf-menu i").css("display", "none") } else { if (e <= 979 && c("#topmobilenav").attr("class") === "active") { c("#topmenunav").css("display", "block"); c("#topmenunav").superfish("destroy"); c(".sf-menu i").css("display", "block") } else { if (e <= 979 && c("#topmobilenav").attr("class") !== "active") { c("#topmenunav").css("display", "none"); c("#topmenunav").superfish("destroy"); c(".sf-menu i").css("display", "block") } } } }; b(); a(); c(window).resize(b); c(window).resize(a); c(".sf-menu i").click(function () { var e = c(this).parent("li"); var f = e.children("ul"); f.slideToggle(); c(this).toggleClass("active"); return false }); var d = window.location.href; c("#menunav a, #topmenunav a").each(function () { if (this.href === d) { var e = c(this).parents("li").children("a").addClass("current") } })
};

// Subscription User Section


function validatename() {
    var validateuser = validationfield($("#userName"));
    if (!validateuser) {
        $("#nameerror").show();

    }
}
function validateemail() {
    var validateemail = validateEmail($("#userEmail").val());
    if (!validateemail) {
        $("#emailerror").show();

    }
}
function removenameerror() {
    $("#nameerror").hide();

}
function removeemailerror() {
    $("#emailerror").hide();

}

function saveUser() {
    //btnUser
    $("#btnUser").attr('disabled', 'disabled');
   var validateuser = validationfield($("#userName"));
    var validateemail = validateEmail($("#userEmail").val());
    if (!validateuser) {
        $("#nameerror").show();

    }
    if (!validateemail) {
        $("#emailerror").show();

    }
    toastr.options.timeOut = 10000;
    toastr.options.positionClass = 'toast-bottom-right';

    if (validateuser && validateemail) {
        $("#nameerror").hide();
        $("#emailerror").hide();
        var userDetails = {};
        userDetails.userName = $("#userName").val();;
        userDetails.userEmail = $("#userEmail").val();;


        $.ajax({
            url: 'http://firstcrazydeveloper.com/api/User',
            dataType: "json",
            type: "POST",
            contentType: 'application/json; charset=utf-8',
            //data: JSON.stringify({ name: 'Rintu', email: 'Rintu@gmial.com' }),
            data: JSON.stringify(userDetails),
            async: true,
            processData: false,
            cache: false,
            success: function (data) {
                $(".ui-dialog-titlebar-close").click();
                toastr.success('User subscription updated successfully.');
                $("#btnUser").removeAttr('disabled');
            },
            error: function (xhr) {
                $("#btnUser").removeAttr('disabled');
                toastr.error('User subscription not update');
            }

        });
    }
}
function checkEmail(email,errorctrl) {

   
    var filter = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;;

    if (!filter.test(email.value)) {
       email.focus;
        return false;
    }
   
    return true;
}
function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}

function validationfield(field, errorCtrl) {
    if (field.val() == undefined || field.val() == '') {
        field.focus;
        return false;

    }
    else {
        
        return true;
    }
}

menunav(jQuery);
datetime();