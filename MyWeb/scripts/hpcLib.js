/// <reference path="../ajax/likenews.aspx" />

/***********************************************
*HPC 20/08/2014
***********************************************/
function Trim(text) { return (text || "").replace(/^\s+|\s+$/g, ""); }
function CheckValue(o) { if (Trim(o) == 'Enter keyword search ...' || Trim(o) == 'Nhập từ khóa tìm kiếm ...' || Trim(o) == '') { return false; } else { return true; } }
function search(s) { if (CheckValue(s) == true) { var r = '/tim-kiem/?key='.concat(encodeURIComponent(s)); window.location.href = r; } }
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
function LoadGrid(pageindex, totalpages) {
    BindGridComment(pageindex, totalpages);
    window.location.hash = '#comment';
}

