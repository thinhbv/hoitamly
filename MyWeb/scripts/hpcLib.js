/// <reference path="../ajax/likenews.aspx" />

/***********************************************
*HPC 20/08/2014
***********************************************/
function Trim(text) { return (text || "").replace(/^\s+|\s+$/g, ""); }
function CheckValue(o) { if (Trim(o) == 'Nhập từ khóa tìm kiếm ...' || Trim(o) == '') { return false; } else { return true; } }
function search(s) { if (CheckValue(s) == true) { var r = '/sitepages/timkiem.aspx?s='.concat(s) + '&pageindex=1'; window.location.href = r; } }
function searchtvpl(s) {
    var request = '/sitepages/timkiemtvpl?pageindex=1';
    if (CheckValue(s) == true)
    {
        request = request + '&s='.concat(s); 
    }
    window.location.href = request;
}
function clickButton(e, buttonid) { var evt = e ? e : window.event; var bt = document.getElementById(buttonid); if (bt) { if (evt.keyCode == 13) { bt.onclick(); return false; } } }
function showCaptcha() {
    // var chars = "23456789ABCDEFGHIJKLMNOPQRSTUVWXTZabcdefghikmnpqrstuvwxyz";
    var chars = "23456789ABCDEFGHIJKLMNOPQRSTUVWXTZ";
    var string_length = 5;
    var randomstring = '';
    for (var i = 0; i < string_length; i++) {
        var rnum = Math.floor(Math.random() * chars.length); randomstring += chars.substring(rnum, rnum + 1);
    }
    var main = lblCaptcha;
    main.innerHTML = randomstring;
}
//GOOGLE +
(function () {
    var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;
    po.src = 'https://apis.google.com/js/plusone.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);
})();

function loadobj(_url, obj) {
    var slink = urlsite + _url;
    var $loader = $('#' + obj + '');
    $loader.load(slink);
}

/* Modified to support Opera */
function bookmarksite(title, url) {
    if (window.sidebar) // firefox
        window.sidebar.addPanel(title, url, "");
    else if (window.opera && window.print) { // opera
        var elem = document.createElement('a');
        elem.setAttribute('href', url);
        elem.setAttribute('title', title);
        elem.setAttribute('rel', 'sidebar');
        elem.click();
    }
    else if (document.all)// ie
        window.external.AddFavorite(url, title);
}
function bookmarksitebeta() {
    if (window.sidebar) // firefox
        window.sidebar.addPanel(document.title, location.href, "");
    else if (window.opera && window.print) { // opera
        var elem = document.createElement('a');
        elem.setAttribute('href', location.href);
        elem.setAttribute('title', document.title);
        elem.setAttribute('rel', 'sidebar');
        elem.click();
    }
    else if (document.all)// ie
        window.external.AddFavorite(location.href, document.title);
}
function openWebLink(url) {
    if (url.length > 0)
        window.open(url, 'popup', 'location=no,directories=no,resizable=yes,status=no,toolbar=no,menubar=no, width=' + screen.width + ',height=' + screen.height + ',scrollbars=yes,top='.concat((screen.height - 500) / 2).concat(',left=').concat(20));
}
function addBookmark() {
    if (window.sidebar && window.sidebar.addPanel) { // Mozilla Firefox Bookmark
        window.sidebar.addPanel(document.title, window.location.href, '');
    } else if (window.external && ('AddFavorite' in window.external)) { // IE Favorite
        window.external.AddFavorite(location.href, document.title);
    } else if (window.opera && window.print) { // Opera Hotlist
        this.title = document.title;
        return true;
    } else { // webkit - safari/chrome
        alert('Vui lòng bấm tổ hợp phím ' + (navigator.userAgent.toLowerCase().indexOf('mac') != -1 ? 'Command/Cmd' : 'CTRL') + ' + D để lưu trang.');
    }
}
function share_twitter() { var u = location.href; t = document.title; window.open("http://twitter.com/home?status=" + encodeURIComponent(u)); }
function share_facebook() { var u = location.href; t = document.title; window.open("http://www.facebook.com/share.php?u=" + encodeURIComponent(u) + "&t=" + encodeURIComponent(t)); }
function share_google() { var u = location.href; t = document.title; window.open("http://www.google.com/bookmarks/mark?op=edit&bkmk=" + encodeURIComponent(u) + "&title=" + t + "&annotation=" + t); }
function share_buzz() { var u = location.href; t = document.title; window.open("http://buzz.yahoo.com/buzz?publisherurn=DanTri&targetUrl=" + encodeURIComponent(u)); }
function share_zing() { var u = location.href; window.open("http://link.apps.zing.vn/share?u=" + encodeURIComponent(u)); }
function share_govn() { var u = location.href; window.open("http://my.go.vn/share.aspx?url=" + encodeURIComponent(u)); }
function share_linkhay() { var u = location.href; window.open("http://linkhay.com/submit?url=" + encodeURIComponent(u)); }
function share_yahoo() { var u = location.href; t = document.title; window.open("http://buzz.yahoo.com/buzz?publisherurn=" + encodeURIComponent(u) + "&t=" + encodeURIComponent(t)); }
function share_facebook(e,u) {
    var t = document.title;
    var url = "https://www.facebook.com/sharer/sharer.php?u=" + encodeURIComponent(u) + "&t=" + encodeURIComponent(t) + "&display=popup&ref=plugin&src=share_button";
    var newwindow = window.open(url, "_blank", "menubar=no,toolbar=no,resizable=no,scrollbars=no,height=450,width=710");
    if (window.focus) newwindow.focus();
    e.preventDefault();
}

function showCaptcha() {
    // var chars = "23456789ABCDEFGHIJKLMNOPQRSTUVWXTZabcdefghikmnpqrstuvwxyz";
    var chars = "23456789ABCDEFGHIJKLMNOPQRSTUVWXTZ";

    var string_length = 5;
    var randomstring = '';
    for (var i = 0; i < string_length; i++) {
        var rnum = Math.floor(Math.random() * chars.length);
        randomstring += chars.substring(rnum, rnum + 1);
    }
    var main = lblCaptcha;
    main.innerHTML = randomstring;
}

function GetBrowser() {
    //#region
    var sBrowser = navigator.userAgent.toLowerCase();
    if (sBrowser.indexOf('msie') > -1)
        return 0;
    else if (sBrowser.indexOf('firefox') > -1)
        return 1;
    else if (sBrowser.indexOf('chrome') > -1)
        return 2;
    else if (sBrowser.indexOf('safari') > -1)
        return 3;
    else if (sBrowser.indexOf('opera') > -1)
        return 4;
    else if (sBrowser.indexOf('netscape') > -1)
        return 5;
    else return -1;
    //#endregion
}

function scrolltotop() {
    $(window).scroll(function () {
        if ($(this).scrollTop() > 400) {
            $('#pagescroll').fadeIn();
        } else {
            $('#pagescroll').fadeOut();
        }
        if (pagename != undefined && pagename != '')
            $('#scrollGohome').css('display', 'none');
        else
            $('#scrollGohome').css('display', 'block');
        if ($('#pagescroll').css('display') == 'none') {
        }
        else if ($('#pagescroll').css('display') == 'block') {
        }
        if ($(this).scrollTop() < 10) {
        }
    });

    $('#scrollup').click(function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
        return false;
    });
}


// TU VAN PHAP LUAT
function sendtvpl(fullname, email, addressIp, tittle, contents, _urlsitet, address) {
    //alert(fullname);
    var _url = '/_layouts/15/SPiteHoiNongDan/ajax/SendContents.aspx/sendtuvanphapluat';
    $.ajax({
        type: "POST",
        url: _url,
        data: "{fullname: '" + fullname + "',email:'" + email + "',addressIp:'" + addressIp + "',tittle:'" + tittle + "',contents:'" + contents + "',address:'" + address +  "' }",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            var data = msg.d;
            if (data == 'oki') {
                alert('Cảm ơn bạn đã gửi câu hỏi!');
                tvplreset();
            }
            else {
                alert('Gửi câu hỏi thất bại!');
            }
        }, error: function (msg) {
            //alert('Error');
            alert('Gửi câu hỏi thất bại!');
        }
    });
}
function GetCaptCha() {
    $.ajax({
        type: "POST",
        url: "/_layouts/15/SPiteHoiNongDan/ajax/SendContents.aspx/GetCaptCha",
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $('#validcomputer').val(response.d.strValidate);
            $('#imgCaptcha').attr('src', 'data:image/jpeg;charset=utf-8;base64,' + response.d.strBase64Image);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(thrownError);
        }
    });
}
function tvplreset() {
    $('#txt_TVPL_Hoten').val("");
    $('#txt_TVPL_Email').val("");
    $('#txt_TVPL_Tieude').val("");
    $('#txt_TVPL_Capchar').val("");
    $('#txt_TVPL_Noidung').val("");
}
function validtvpl(_urlsitet) {
    var fullname = $('#txt_TVPL_Hoten').val();
    var email = $('#txt_TVPL_Email').val();
    var address = $('#txt_TVPL_Add').val();
    var tittle = $('#txt_TVPL_Tieude').val();
    var capchar = $('#txt_TVPL_Capchar').val();
    var Valid = $('#validcomputer').val();
    var contents = $('#txt_TVPL_Noidung').val();
    var url = '';
    var reg1 = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var testmail = reg1.test(email);
    var _check = true;
    if (fullname.length < 2) {
        alert('Bạn chưa nhập Họ và tên!');
        $("#txt_TVPL_Hoten").focus();
        _check = false; return;
    }
    /*if (email.length < 2) {
        alert('Bạn chưa nhập Hộp thư điện tử!');
        $("#txt_TVPL_Email").focus();
        _check = false; return;
    }
    if (!testmail) {
        alert('Hộp thư điện tử sai định dạng!');
        $("#txt_TVPL_Email").focus(); _check = false; return;
    }*/
    if (capchar.length < 2) {
        alert('Bạn chưa nhập mã xác nhận!');
        $("#txt_TVPL_Capchar").focus();
        _check = false; return;
    } else {
        if(Valid!=capchar) {
            alert('Mã xác nhận chưa đúng!');
            $("#txt_TVPL_Capchar").focus();
            _check = false; return;
        }
    }
    if (tittle.length < 2) {
        alert('Bạn chưa nhập Tiêu đề!');
        $('#txt_TVPL_Tieude').focus();
        _check = false; return;
    }
    if (contents.length < 3) {
        alert('Bạn phải nhập nội dung câu hỏi');
        _check = false; return;
    }
    if (_check) {
        sendtvpl(encodeURIComponent(fullname), email, "", encodeURIComponent(tittle), encodeURIComponent(contents), _urlsitet, encodeURIComponent(address));
    }
}
// End

// GOP Y 
function sendgopy(fullname, address, officce, phone, email, chudeid, tittle, contents, url, _urlsitet) {
    //alert(fullname);
    var _url = '/_layouts/15/SPiteHoiNongDan/ajax/SendContents.aspx/sendgopy';
    $.ajax({
        type: "POST",
        url: _url,
        data: "{fullname: '" + fullname + "',address:'" + address + "',officce:'" + officce + "',phone:'" + phone + "',email:'" + email + "',chude:'" + chudeid + "',tittle:'" + tittle + "',contents:'" + contents + "',url:'" + url + "' }",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            var data = msg.d;
            if (data == 'oki') {
                alert('Cảm ơn bạn đã góp ý!');
                gopyreset();
            }
            else {
                alert('Gửi góp ý thất bại!');
            }
        }, error: function (msg) {
            //alert('Error');
            alert('Gửi góp ý thất bại!');
        }
    });
}
function gopyreset() {
    $('#txtgopyfullname').val("");
    $('#txtgopyaddress').val("");
    $('#txtgopyofficce').val("");
    $('#txtgopyphone').val("");
    $('#txtgopyemail').val("");
    $('#txtChuDeNong').val("");

    $('#txtgopytittle').val("");
    $('#txtgopycontents').val("");
}
function validgopy(_urlsitet) {
    var fullnamegopy = $('#txtgopyfullname').val();
    var addressgopy = $('#txtgopyaddress').val();
    var officcegopy = $('#txtgopyofficce').val();
    var phonegopy = $('#txtgopyphone').val();
    var emailgopy = $('#txtgopyemail').val();
    var tittlegopy = $('#txtgopytittle').val();
    var contentsgopy = $('#txtgopycontents').val();
    var chudeid = $('#txtChuDeNong').val();
    var url = '';
    var reg1 = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var testmail = reg1.test(emailgopy);
    var _check = true;
    if (fullnamegopy.length < 2) {
        alert('Bạn chưa nhập Họ và tên!');
        $("#txtgopyfullname").focus();
        _check = false; return;
    }
    if (addressgopy.length < 2) {
        alert('Bạn chưa nhập Địa chỉ!');
        $("#txtgopyaddress").focus();
        _check = false; return;
    }
   /* if (officcegopy.length < 2) {
        alert('Bạn chưa nhập Cơ quan làm việc!');
        $("#txtgopyofficce").focus();
        _check = false; return;
    }
    if (phonegopy.length < 2) {
        alert('Bạn chưa nhập Số điện thoại!');
        $("#txtgopyphone").focus();
        _check = false; return;
    }
    if (emailgopy.length < 2) {
        alert('Bạn chưa nhập Hộp thư điện tử!');
        $("#txtgopyemail").focus();
        _check = false; return;
    }
    if (!testmail) {
        alert('Hộp thư điện tử sai định dạng!');
        $("#txtgopyemail").focus(); _check = false; return;
    }
    if (chudeid == '0') {
        alert("Bạn phải chọn Chuyên mục!");
        _check = false; return;
    }*/
    if (tittlegopy.length < 2) {
        alert('Bạn chưa nhập Tiêu đề!');
        $('#txtgopytittle').focus();
        _check = false; return;
    }
    if (contentsgopy.length < 3) {
        alert('Bạn phải nhập nội dung góp ý');
        _check = false; return;
    }
    if (_check) {
        sendgopy(fullnamegopy, addressgopy, officcegopy, phonegopy, emailgopy, chudeid, tittlegopy, contentsgopy, url, _urlsitet);
    }
}
// End

// Phan anh 
function sendphananh(fullname, address, officce, phone, email, contents) {
    //alert(fullname);
    var _url = '/_layouts/15/SPiteHoiNongDan/ajax/SendContents.aspx/sendphananh';
    $.ajax({
        type: "POST",
        url: _url,
        data: "{fullname: '" + fullname + "',address:'" + address + "',officce:'" + officce + "',phone:'" + phone + "',email:'" + email + "',contents:'" + contents +  "' }",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            var data = msg.d;
            if (data == 'oki') {
                alert('Cảm ơn bạn đã phản ánh!');
                phananhreset();
            }
            else {
                alert('Gửi phản ánh thất bại!');
            }
        }, error: function (msg) {
            //alert('Error');
            alert('Gửi phản ánh thất bại!');
        }
    });
}
function phananhreset() {
    $('#txtgopyfullname').val("");
    $('#txtgopyaddress').val("");
    $('#txtgopyofficce').val("");
    $('#txtgopyphone').val("");
    $('#txtgopyemail').val("");
    $('#txtgopycontents').val("");
}
function validphananh(_urlsitet) {
    var fullnamegopy = $('#txtgopyfullname').val();
    var addressgopy = $('#txtgopyaddress').val();
    var officcegopy = $('#txtgopyofficce').val();
    var phonegopy = $('#txtgopyphone').val();
    var emailgopy = $('#txtgopyemail').val();
    var contentsgopy = $('#txtgopycontents').val();
    var url = '';
    var reg1 = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var testmail = reg1.test(emailgopy);
    var _check = true;
    if (fullnamegopy.length < 2) {
        alert('Bạn chưa nhập Họ và tên!');
        $("#txtgopyfullname").focus();
        _check = false; return;
    }
   
    if (contentsgopy.length < 3) {
        alert('Bạn phải nhập nội dung phản ánh');
        _check = false; return;
    }
    if (_check) {
        sendphananh(fullnamegopy, addressgopy, officcegopy, phonegopy, emailgopy, contentsgopy);
    }
}
// End
// BINH LUAN TIN BAN DOC

function sendbinhluan(fullname, email, contents, url, _id, _urlsitet) {
    var _url = '/_layouts/15/SPiteHoiNongDan/ajax/SendContents.aspx/sendbinhluan';
    $.ajax({
        type: "POST",
        url: _url,
        data: "{fullname: '" + fullname + "',email:'" + email + "',contents:'" + contents + "',url:'" + url + "',id:'" + _id + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            var data = msg.d;
            if (data == 'oki') {
                alert('Cảm ơn bạn đã bình luận!');
                resetbinhluan();
            }
            else {
                alert('Gửi góp ý bình luận thất bại!');
            }
        }, error: function (msg) {
            alert('Gửi góp ý bình luận thất bại!');
        }
    });
}
function resetbinhluan() {
    $('#txtbinhluanfullname').val("");
    $('#txtbinhluanemail').val("");
    $('#txtbinhluannoidung').val("Nội dung");
}
function validbinhluan(_urlsitet, url, _id) {
    var txtbinhluanfullname = $('#txtbinhluanfullname').val();
    var txtbinhluanemail = $('#txtbinhluanemail').val();
    var txtbinhluannoidung = $('#txtbinhluannoidung').val();
    var reg1 = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var testmail = reg1.test(txtbinhluanemail);
    var _check = true;
    if (txtbinhluanfullname.length < 2) {
        alert('Bạn chưa nhập Họ và tên!');
        $("#txtbinhluanfullname").focus();
        _check = false; return;
    }
    if (txtbinhluanemail.length < 2) {
        alert('Bạn chưa nhập Hộp thư điện tử!');
        $("#txtbinhluanemail").focus();
        _check = false; return;
    }
    if (!testmail) {
        alert('Hộp thư điện tử sai định dạng!');
        $("#txtbinhluanemail").focus(); _check = false; return;
    }
    if (txtbinhluannoidung.length < 3 || txtbinhluannoidung == 'Nội dung') {
        alert('Bạn phải nhập nội dung');
        _check = false; return;
    }
    if (_check) {
        sendbinhluan(txtbinhluanfullname, txtbinhluanemail, txtbinhluannoidung, url, _id, _urlsitet);
    }
}
// End



// LIKE NEWS

function likeNews() {
    $.ajax({
        type: "POST",
        url: "/_layouts/15/SPiteHoiNongDan/ajax/LikeNews.aspx/SetLikeNews",
        data: "{id:'" + NEWS_ID + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            $("#idlike").html(msg.d);
        },
        error: function (msg) {
        }
    });
}
function getCountlikeNews() {
    if (Get_Cookie('hndvn' + NEWS_ID)) {
        document.getElementById("imgliketop").src =  "/_layouts/15/SPiteHoiNongDan/Images/icon/i-like-checked.png";
    }
    $.ajax({
        type: "POST",
        url: "/_layouts/15/SPiteHoiNongDan/ajax/LikeNews.aspx/GetLikeNews",
        data: "{id:'" + NEWS_ID + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            $("#idlike").html(msg.d);
        },
        error: function (msg) {
        }
    });
   
}
function Set_CookieAutoRemove(name, value) {
    document.cookie = name + "=" + escape(value);
}
function Set_Cookie(name, value, expires, path, domain, secure) {
    var today = new Date();
    today.setTime(today.getTime());
    if (expires) {
        expires = expires * 1000 * 60 * 60 * 12;
    }
    var expires_date = new Date(today.getTime() + (expires));

    document.cookie = name + "=" + escape(value) +
            ((expires) ? ";expires=" + expires_date.toGMTString() : "") +
            ((path) ? ";path=" + path : "") +
            ((domain) ? ";domain=" + domain : "") +
            ((secure) ? ";secure" : "");
}
function Get_Cookie(name) {
    var start = document.cookie.indexOf(name + "=");
    var len = start + name.length + 1;
    if ((!start) &&
            (name != document.cookie.substring(0, name.length))) {
        return null;
    }
    if (start == -1) return null;
    var end = document.cookie.indexOf(";", len);
    if (end == -1) end = document.cookie.length;
    return unescape(document.cookie.substring(len, end));
}
function checklikeNews() {
    if (Get_Cookie('hndvn' + NEWS_ID)) {
        document.getElementById("imgliketop").src =  "/_layouts/15/SPiteHoiNongDan/Images/icon/i-like-checked.png";
        return false;
    }
    else {
        likeNews();
        Set_Cookie('hndvn' + NEWS_ID, 'hndvn' + NEWS_ID, '1', '/', '', '');
        document.getElementById("imgliketop").src =  "/_layouts/15/SPiteHoiNongDan/Images/icon/i-like-checked.png";
        return false;
    }
}

function LoadGrid(pageindex, totalpages) {
    BindGridComment(pageindex, totalpages);
    window.location.hash = '#comment';
}

function BindGridComment(pageindex, totalpages) {

    var pagesize = 5;
    if (totalpages != '') {
        var page = parseInt(pageindex);
        var total = parseInt(totalpages);
        if (page <= total) {
        }
        else {
            alert('Không có trang ' + page);
            pageindex = total;
        }
    }
    var _url = '/_layouts/15/SPiteHoiNongDan/ajax/Comment.aspx/GetListComment';
    $.ajax({
        type: "POST",
        url: _url,
        data: "{pageIndex:'" + pageindex + "',pageSize:'" + pagesize + "',newsID:'" + NEWS_ID + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            var data = msg.d;
            var htmlData = "";
            $.each(data, function (rec, value) {
                if (rec == 'listComment') {
                    for (var i = 0; i < data.listComment.length; i++) {
                        htmlData += "<div class=\"item\"><p class=\"desc\">" + data.listComment[i].Content + "</p>";
                        htmlData += "<p class=\"info\"><span class=\"name\">" + data.listComment[i].Fullname + "</span>  - ";
                        htmlData += "<span class=\"time\">" + data.listComment[i].Date_Create + "</span>";
                        htmlData += "<span class=\"number\" id=\"number" + data.listComment[i].ID + "\">" + data.listComment[i].NumberLike + "</span>";
                        if (Get_Cookie('hndvnLike' + data.listComment[i].ID)) {
                            htmlData += "<a class=\"liked\" id=\"" + data.listComment[i].ID + "\">Thích<span class=\"iconliked\" id=\"img"
                            + data.listComment[i].ID + "\"></span>. </a></p></div><div class=\"line\"></div>";
                        } else {
                            htmlData += "<a class=\"like\" onclick=\"javascript:LikeComment(" + data.listComment[i].ID + ");\" id=\"" + data.listComment[i].ID + "\">Thích<span class=\"iconlike\" id=\"img"
                            + data.listComment[i].ID + "\"></span>. </a></p></div><div class=\"line\"></div>";
                        }
                    }
                }
            });
            $("#dvListComment").html(htmlData);
            //Phan trang
            var _totalRecords = data.TotalRecords;
            if (_totalRecords > 0)
                Pager(pageindex, pagesize, _totalRecords);
            else $("#checkCommentVisible").css('display', 'none');
        },
        error: function (msg) {
            alert(msg);
        }
    });
}

function LikeComment(a) {
    $.ajax({
        type: "POST",
        url: "/_layouts/15/SPiteHoiNongDan/ajax/Comment.aspx/LikeComment",
        data: "{commentId:'" + a + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            $("#" + a).attr('onclick', '#');
            $("#img" + a).attr('class', 'iconliked');
            $("#number" + a).html(msg.d.numberlike);
            Set_Cookie('hndvnLike' + a, 'hndvnLike' + a, '1', '/', '', '');
        },
        error: function (msg) {
        }
    });
}

function AddReadCount() {
    if (Get_Cookie("setviewcout") == null && Get_Cookie("setviewcout")!="1") {
        $.ajax({
            type: "POST",
            url: "/_layouts/15/SPiteHoiNongDan/ajax/LikeNews.aspx/AddCountView",
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(msg) {
                Set_CookieAutoRemove('setviewcout', '1');
            },
            error: function(msg) {
            }
        });
    }
}


//Phan trang
function Pager(pageindex, pagesize, _totalRecords) {

    if (_totalRecords > 0) {
        var htmlPaging = "";
        var _tongsotrang;
        _tongsotrang = eval(parseFloat(_totalRecords) / parseFloat(pagesize));
        if (_tongsotrang <= 0.5)
            _tongsotrang.split = 1;
        else if (_tongsotrang > 1) {
            var _st = _tongsotrang.toString().split(".");
            if (_st.length == 2) {
                _tongsotrang = parseFloat(_st[0]) + parseFloat(1)
            }
        }
        else { _tongsotrang = eval(Math.round(_tongsotrang)) };
        var _trangsau = eval(parseFloat(pageindex) + parseFloat(1));
        var _trangtruoc = eval(parseFloat(pageindex) - parseFloat(1));
        var _tranghtai = _trangsau - 1;
        var _denbanghi = _tranghtai * pagesize;
        var _tubanghi = _denbanghi - (pagesize - 1);
        if (_trangtruoc == 0) {
            if (_tongsotrang > 1) {
                htmlPaging += "<span></span> <a style='text-decoration:none;' href='javascript:void(0);' onclick=\"LoadGrid(" + _trangsau + ",'');\">></a> ";
            } else {
                htmlPaging += "";
            }
        }
        else {
            if (_tongsotrang > 1) {
                if (_trangtruoc < _trangsau && _trangsau <= _tongsotrang) {
                    htmlPaging += "<a style='text-decoration:none;' href='javascript:void(0);' onclick=\"LoadGrid(" + _trangtruoc + ",'');\"><</a> <span class='DivPageNumber'></span> <a style='text-decoration:none;' href='javascript:void(0);' onclick=\"LoadGrid(" + _trangsau + ",'');\">></a>";
                }
                else if (_trangsau > _tongsotrang) {
                    if (parseFloat(_totalRecords) < parseFloat(_denbanghi)) {
                        htmlPaging += "<a style='text-decoration:none;' href='javascript:void(0);' onclick=\"LoadGrid(" + _trangtruoc + ",'');\"><</a> <span class='DivPageNumber' ></span> ";
                    }
                    else {
                        htmlPaging += "<a style='text-decoration:none;' href='javascript:void(0);' onclick=\"LoadGrid(" + _trangtruoc + ",'');\"><</a> <span class='DivPageNumber'></span> ";
                    }
                }
            } else {
                htmlPaging += "";
            }

        }
        //page number
        var htmlPagesNumber = "";
        var currentPage = parseInt(pageindex);
        var numberOfPagesToDisplay = 8;
        var start = 1;
        var end = _tongsotrang;
        if (_tongsotrang > numberOfPagesToDisplay) {
            var middle = parseInt(Math.ceil(numberOfPagesToDisplay / 2)) - 1;
            var below = (currentPage - middle);
            var above = (currentPage + middle);

            if (below < 4) {
                above = numberOfPagesToDisplay;
                below = 1;
            }
            else if (above > (_tongsotrang - 4)) {
                above = _tongsotrang;
                below = (_tongsotrang - numberOfPagesToDisplay + 1);
            }
            start = below;
            end = above;
        }
        if (start > 1) {
            htmlPagesNumber += "<a href='javascript:void(0);' onclick=\"LoadGrid(1,'');\" >1</a> ";
            if (start > 3) {
                htmlPagesNumber += "<a href='javascript:void(0);' onclick=\"LoadGrid(1,'');\" >2</a> ";
            }
            if (start > 2) {
                htmlPagesNumber += "...... ";
            }
        }

        for (var i = start; i <= end; i++) {
            if (i == currentPage || (currentPage <= 0 && i == 0)) {
                htmlPagesNumber += "<span class=\"current\">" + i + "</span> ";
            }
            else {
                htmlPagesNumber += "<a href='javascript:void(0);' onclick=\"LoadGrid('" + i + "','');\" >" + i + "</a> ";
            }
        }
        if (end < _tongsotrang) {
            if (end < _tongsotrang - 1) {
                htmlPagesNumber += "...... ";
            }
            if (_tongsotrang - 2 > end) {
                var _pagePrevEnd = parseInt(_tongsotrang) - 1;
                htmlPagesNumber += "<a href='javascript:void(0);' onclick=\"LoadGrid('" + _pagePrevEnd + "','');\" >" + _pagePrevEnd + "</a> ";
            }
            htmlPagesNumber += "<a href='javascript:void(0);' onclick=\"LoadGrid('" + _tongsotrang + "','');\" >" + _tongsotrang + "</a> ";
        }
        //

        $(".totalComment").html("Ý kiến bạn đọc (" + _totalRecords + ")");
        $(".pageNav").html(htmlPagesNumber);
    }
}

