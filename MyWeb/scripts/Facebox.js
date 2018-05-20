
//Khai báo biến
var Arr_CheckBoxOnGrid = ""; //Chuỗi các CheckBox trên 1 Grid nào đó, dùng vào mục đích Select All
var fbClosed = null;
var statusShowFull = false;
//Chọn (bỏ chọn) tất cả các checkbox trên GridView
function SelectCheckBox_All(CheckBox_All) {
    if (CheckBox_All) {
        if (Arr_CheckBoxOnGrid.length > 1) {

            var Arr = Arr_CheckBoxOnGrid.split(",");
            for (var i = 0; i < Arr.length; i++) {
                var ctr_Check = document.getElementById(Arr[i]);
                if (ctr_Check) {
                    ctr_Check.checked = CheckBox_All.checked;
                }
            }
        }
    }
}

function Random_Number(len) {
    chars = new Array('0', '1', '2', '3', '4', '5', '6', '7', '8', '9');
    charCount = chars.length();
    stringLength = len;
    var outputString;
    i = 0;
    do {
        random = Math.floor(Math.random());
        random *= charCount;
        random = chars[random];
        outputString += parseString(random);
        i++;
    }
    while (i < stringLength);

    return outputString;
}

function AskBeforeDelete(message) {
    return confirm(message);
}
function isNumberKey_Date(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode == 47)//dấu "/"
        return true;
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}
function isNumberKey_int(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}
function isNumberKey_double(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode == 46)//dấu "."
        return true;
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}
///Khai báo cho face box
var div_FaceBox_OutID;
var div_FaceBox_InID;
var div_FaceBoxID;
var div_FaceBoxContentID;
var div_FaceBoxImageLoadingID;
var div_FaceBoxContentChildID;
var chk_IsShowFaceBoxID;
var IsReloadPage = false; //Để cho phép khi nhấn nút close trên Facebox có được reload lại trang hay không
var chk_IsDeleteContentID;

//Control div
var div_FaceBox_Out;
var div_FaceBox_In;
var div_FaceBox;
var div_FaceBoxContent;
var div_FaceBoxImageLoading;
var div_FaceBoxContentChild;
var chk_IsShowFaceBox;
var chk_IsDeleteContent;
var typeBrowser = 0;
var HideScrollIframe = false;
/// <summary>
/// Hàm dùng để lấy trình duyệt đang sử dụng
/// </summary>
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

//Khởi tạo đầu tiên cho facebox
function InitFaceBox() {

    typeBrowser = GetBrowser();
    div_FaceBox_Out = document.getElementById(div_FaceBox_OutID);
    div_FaceBox_In = document.getElementById(div_FaceBox_InID);

    div_FaceBox = document.getElementById(div_FaceBoxID);
    div_FaceBoxContent = document.getElementById(div_FaceBoxContentID);
    div_FaceBoxImageLoading = document.getElementById(div_FaceBoxImageLoadingID);
    div_FaceBoxContentChild = document.getElementById(div_FaceBoxContentChildID);
    chk_IsShowFaceBox = document.getElementById(chk_IsShowFaceBoxID);
    chk_IsDeleteContent = document.getElementById(chk_IsDeleteContentID);

    div_FaceBox_Out.style.display = 'none';
    div_FaceBoxImageLoading.style.display = 'inline';
    div_FaceBoxContentChild.style.display = 'none';
}
function HideScroll(isHide) {

    if (isHide) {
        switch (typeBrowser) {
            case 0: //IE
                document.body.scrollbars = "no";
                document.documentElement.style.overflowX = 'hidden';
                document.documentElement.style.overflowY = 'hidden';
                break;
            case 1: //firefox
                document.documentElement.style.overflow = 'hidden';
                break;
            case 2: //chrome
                document.documentElement.style.overflow = 'hidden';
                break;
            case 3: //safari
                document.documentElement.style.overflow = 'hidden';
                break;
            case 4: //opera
                document.documentElement.style.overflow = 'hidden';
                break;
            case 5: //netscape
                document.documentElement.style.overflow = 'hidden';
                break;
            default:
                document.documentElement.style.overflow = 'hidden';
                break;
        }
    }
    else {
        switch (typeBrowser) {
            case 0: //IE
                document.body.scrollbars = "auto";
                document.documentElement.style.overflowX = 'auto';
                document.documentElement.style.overflowY = 'auto';
                break;
            case 1: //firefox
                document.documentElement.style.overflow = 'auto';
                break;
            case 2: //chrome
                document.documentElement.style.overflow = 'auto';
                break;
            case 3: //safari
                document.documentElement.style.overflow = 'auto';
                break;
            case 4: //opera
                document.documentElement.style.overflow = 'auto';
                break;
            case 5: //netscape
                document.documentElement.style.overflow = 'auto';
                break;
        }
    }
}
//Hiển thị facebox
function Show_FaceBox(isShow) {
    if (statusShowFull == false)
        HideScroll(isShow);
    else if (statusShowFull == true)
        HideScroll(true);
    div_FaceBox_Out.style.height = "100%";

    var x = 0, y = 0;

    var centerX, centerY;
    if (self.innerHeight) {
        centerX = self.innerWidth;
        centerY = self.innerHeight;

        div_FaceBox_Out.style.width = parseInt(self.innerWidth) + "px";
    }
    else if (document.documentElement && document.documentElement.clientHeight) {
        centerX = document.documentElement.clientWidth;
        centerY = document.documentElement.clientHeight;

        div_FaceBox_Out.style.width = parseInt(document.documentElement.clientWidth) + "px";
    }
    else if (document.body) {
        centerX = document.body.clientWidth;
        centerY = document.body.clientHeight;
        div_FaceBox_Out.style.width = parseInt(document.body.clientWidth) + "px";
    }

    var scrolledX, scrolledY;
    if (self.pageYOffset) {
        scrolledX = self.pageXOffset;
        scrolledY = self.pageYOffset;
    }
    else if (document.documentElement && document.documentElement.scrollTop) {

        scrolledX = document.documentElement.scrollLeft;
        scrolledY = document.documentElement.scrollTop;
    }
    else if (document.body) {
        scrolledX = document.body.scrollLeft;
        scrolledY = document.body.scrollTop;
    }
    x = centerX / 2 - div_FaceBox.offsetWidth / 2;
    y = centerY / 2 - div_FaceBox.offsetHeight / 2 + scrolledY;

    x = x < 0 ? 0 : x;
    y = y < 0 ? 0 : y;

    div_FaceBox.style.left = x + 'px';
    div_FaceBox.style.top = y + 'px';


    if (isShow == true) {
        div_FaceBox_Out.style.display = 'inline';
        chk_IsShowFaceBox.checked = true;
        div_FaceBox.focus();
    }
    else {

        div_FaceBoxImageLoading.style.display = 'inline';
        div_FaceBoxContentChild.style.display = 'none';

        div_FaceBox_Out.style.display = 'none';

        div_FaceBoxContent.style.height = '';

        chk_IsShowFaceBox.checked = false;
    }
    return false;
}

//Cho phép công thêm width, height cho iframe
var AllowAddWidth = true;
function IframeLoadComplete(frameId) {
    //Làm cho Iframe có thể auto height, width frame.document.body.scrollHeight
    var frame = document.getElementById(frameId);
    var innerDoc = (frame.contentDocument) ? frame.contentDocument : frame.contentWindow.document;
    var objToResize = (frame.style) ? frame.style : frame;
    if (!AllowAddWidth) {
        objToResize.height = (parseInt(innerDoc.body.style.height)) + 'px';
        objToResize.width = (parseInt(innerDoc.body.style.width)) + 'px';
        AllowAddWidth = true;
    }
    else {
        objToResize.height = (parseInt(innerDoc.body.style.height) + 10) + 'px';
        objToResize.width = (parseInt(innerDoc.body.style.width) + 22) + 'px';
    }
    div_FaceBoxImageLoading.style.display = 'none';
    div_FaceBoxContentChild.style.display = 'inline';
    ResetPosition();
    if (typeBrowser == 0)
        ResetPosition();
}
function IframeLoadComplete1(frameId) {
    //Làm cho Iframe có thể auto height, width frame.document.body.scrollHeight
    var frame = document.getElementById(frameId);
    var innerDoc = (frame.contentDocument) ? frame.contentDocument : frame.contentWindow.document;
    var objToResize = (frame.style) ? frame.style : frame;
    objToResize.height = '1000px';
    objToResize.width = '1000px';
    div_FaceBoxImageLoading.style.display = 'none';
    div_FaceBoxContentChild.style.display = 'inline';
    ResetPosition();
}
function SetShow_ChildContent(IsShow) {
    if (IsShow) {
        div_FaceBoxImageLoading.style.display = 'none';
        div_FaceBoxContentChild.style.display = 'inline';
    }
    else {
        div_FaceBoxImageLoading.style.display = 'inline';
        div_FaceBoxContentChild.style.display = 'none';
    }
}

//hiển thị face box không có hiển thị image ajax loading
function Show_Facebox_Content() {
    div_FaceBoxImageLoading.style.display = 'none';
    div_FaceBoxContentChild.style.display = 'inline';
    Show_FaceBox(true);
    FaceBoxLoadComplete();
    return false;
}

//Khi load facebox xong
function FaceBoxLoadComplete() {

    div_FaceBoxImageLoading.style.display = 'none';
    div_FaceBoxContentChild.style.display = 'inline';
    ResetPosition();

    if (typeBrowser == 0)
        ResetPosition();
}

//Đóng facebox
function CloseFaceBox() {
    Show_FaceBox(false);
    //Nếu mà cho phép reload lại trang
    if (IsReloadPage) {
        IsReloadPage = false;
        location.reload(true);
    }
    //Nếu cho phép xóa nội dụng trong facebox
    if (chk_IsDeleteContent.checked) {
        div_FaceBoxContentChild.innerHTML = "";
    }

    if (fbClosed != null && typeof (fbClosed) == "function") {
        fbClosed();
    }
}

function Set_IsDeleteContent(b_Value) {
    chk_IsDeleteContent.checked = b_Value;
}

//Hiển thị facebox khi có liên quan tới ajax
function Show_FaceBoxAjax(URL_Get) {
    Show_FaceBox(true);
    AjaxFunction(URL_Get);
    return false;
}
function Show_FaceBoxIframe_HideScroll(URL) {
    HideScrollIframe = true;
    Show_FaceBoxIframe(URL);
    return false;
}
//Hiển thị FaceBox với nội dung là 1 iframe
function Show_FaceBoxIframe(URL) {
    Show_FaceBox(true);
    if (HideScrollIframe) {
        div_FaceBoxContentChild.innerHTML = ' <iframe src="' + URL + '" id="ifr_FaceBox" frameborder="0" scrolling="no" onload="IframeLoadComplete(\'ifr_FaceBox\');"></iframe>';
        HideScrollIframe = false;
    } else {
        div_FaceBoxContentChild.innerHTML = ' <iframe src="' + URL + '" id="ifr_FaceBox" frameborder="0" scrolling="auto" onload="IframeLoadComplete(\'ifr_FaceBox\');"></iframe>';
    }
    return false;
}
//Hiển thị FaceBox với nội dung là 1 iframe
function Show_FaceBoxIframe_NotAddWidth(URL) {
    AllowAddWidth = false;
    Show_FaceBox(true);
    if (HideScrollIframe) {
        div_FaceBoxContentChild.innerHTML = ' <iframe src="' + URL + '" id="ifr_FaceBox" frameborder="0" scrolling="no" onload="IframeLoadComplete(\'ifr_FaceBox\');"></iframe>';
        HideScrollIframe = false;
    }
    else {
        div_FaceBoxContentChild.innerHTML = ' <iframe src="' + URL + '" id="ifr_FaceBox" frameborder="0" scrolling="auto" onload="IframeLoadComplete(\'ifr_FaceBox\');"></iframe>';
    }
    return false;
}

//Hiển thị FaceBox với nội dung là 1 iframe
function Show_FaceBoxIframe_Gallery(URL) {
    Show_FaceBox(true);
    div_FaceBoxContentChild.innerHTML = ' <iframe src="' + URL + '" id="ifr_FaceBox" frameborder="0" scrolling="no" onload="IframeLoadComplete1(\'ifr_FaceBox\');"></iframe>';
    return false;
}
function Show_FaceBoxContent(str_HTML) {
    div_FaceBoxContentChild.innerHTML = str_HTML;
    Show_FaceBox(true);
    FaceBoxLoadComplete();
    return false;
}

function showFullScreen(id) {
    var _link =  '/SitePages/LoadGalleryDetail.aspx?photoid=' + id;

    //alert(_link);
    $('#bindFullScreen').load(_link);
    var centerX, centerY;
    if (self.innerHeight) {
        centerX = self.innerWidth;
        centerY = self.innerHeight;
    }
    else if (document.documentElement && document.documentElement.clientHeight) {
        centerX = document.documentElement.clientWidth;
        centerY = document.documentElement.clientHeight;
    }
    else if (document.body) {
        centerX = document.body.clientWidth;
        centerY = document.body.clientHeight;
    }
    var scrolledX, scrolledY;
    if (self.pageYOffset) {
        scrolledX = self.pageXOffset;
        scrolledY = self.pageYOffset;
    }
    else if (document.documentElement && document.documentElement.scrollTop) {
        scrolledX = document.documentElement.scrollLeft;
        scrolledY = document.documentElement.scrollTop;
    }
    else if (document.body) {
        scrolledX = document.body.scrollLeft;
        scrolledY = document.body.scrollTop;
    }
    x = centerX / 2 - document.getElementById('bindFullScreen').offsetWidth / 2;
    y = centerY / 2 - document.getElementById('bindFullScreen').offsetHeight / 2 + scrolledY;
    x = x < 0 ? 0 : x;
    y = y < 0 ? 0 : y;

    //$('#Box_Gallery_In').css('top', (y - 400) + 'px');
    var setH = parseInt(screen.height) - parseInt($(window).height());
    if (typeBrowser == 0)
        $('#Box_Gallery_Out').css('width', parseInt(centerX) + 20);
    else
        $('#Box_Gallery_Out').css('width', centerX);
    $('#Box_Gallery_Out').css('height', '4000px');
    $('#Box_Gallery_Out').css('display', 'inline');
    //    if (typeBrowser == 2)
    //        $('#Box_Gallery_In').css('top', (y - 430) + setH + 'px');
    //    else if (typeBrowser == 0)
    //        $('#Box_Gallery_In').css('top', (y - 480) + setH + 'px');
    //    else
    //        $('#Box_Gallery_In').css('top', (y - 480) + setH + 'px');
    $('#Box_Gallery_In').css('top', scrolledY + 'px');
    $('#Box_Gallery_In').css('height', centerY + 'px');
    HideScroll(true);
    statusShowFull = true;
    
    return false;
}
function closeScreen() {
    $('#Box_Gallery_Out').css('display', 'none');
    statusShowFull = false;
    HideScroll(false);
}
function Show_FaceBoxContent2(idBind) {
    //    div_FaceBoxContentChild.innerHTML = $(idBind).html();
    $(div_FaceBoxContentChild).empty().html($(idBind).html());
    $(idBind).empty();
    Show_FaceBox(true);
    FaceBoxLoadComplete();
    return false;
}
function Show_FaceBoxImage(str_ImageURL) {
    div_FaceBoxContentChild.innerHTML = '<img src="' + str_ImageURL + '" onload="FaceBoxLoadComplete();" />';
    Show_FaceBox(true);
    return false;
}
//Reset lại vị trí của facebox để facebox nằm giữa  màn hình
function ResetPosition() {
    var x = 0, y = 0;
    var centerX, centerY;
    if (self.innerHeight) {
        div_FaceBoxContent.style.height = div_FaceBoxContent.offsetHeight >= self.innerHeight - 50 ? (self.innerHeight - 50) + 'px' : div_FaceBoxContent.style.height;

        centerX = self.innerWidth;
        centerY = self.innerHeight;
    }
    else if (document.documentElement && document.documentElement.clientHeight) {
        div_FaceBoxContent.style.height = div_FaceBoxContent.offsetHeight >= document.documentElement.clientHeight - 50 ? (document.documentElement.clientHeight - 50) + 'px' : div_FaceBoxContent.style.height;

        centerX = document.documentElement.clientWidth;
        centerY = document.documentElement.clientHeight;
    }
    else if (document.body) {
        div_FaceBoxContent.style.height = div_FaceBoxContent.offsetHeight >= document.body.clientHeight - 50 ? (document.body.clientHeight - 50) + 'px' : div_FaceBoxContent.style.height;

        centerX = document.body.clientWidth;
        centerY = document.body.clientHeight;
    }
    var scrolledX, scrolledY;
    if (self.pageYOffset) {
        scrolledX = self.pageXOffset;
        scrolledY = self.pageYOffset;
    }
    else if (document.documentElement && document.documentElement.scrollTop) {
        scrolledX = document.documentElement.scrollLeft;
        scrolledY = document.documentElement.scrollTop;
    }
    else if (document.body) {
        scrolledX = document.body.scrollLeft;
        scrolledY = document.body.scrollTop;
    }
    x = centerX / 2 - div_FaceBox.offsetWidth / 2;
    y = centerY / 2 - div_FaceBox.offsetHeight / 2 + scrolledY;

    x = x < 0 ? 0 : x;
    y = y < 0 ? 0 : y;

    div_FaceBox.style.left = (x - 10) + 'px';
    div_FaceBox.style.top = y + 'px';
}

//Hàm ajax
function AjaxFunction(URL_Get) {
    var xmlHttp;
    try {
        // Firefox, Opera 8.0+, Safari
        xmlHttp = new XMLHttpRequest();
    }
    catch (e) {
        // Internet Explorer
        try {
            xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
        }
        catch (e) {
            try {
                xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            catch (e) {
                alert("Your browser does not support AJAX!");
                return false;
            }
        }
    }
    xmlHttp.onreadystatechange = function() {
        if (xmlHttp.readyState == 4) {
            div_FaceBoxContentChild.innerHTML = xmlHttp.responseText;
            FaceBoxLoadComplete();
        }
    }
    xmlHttp.open("GET", URL_Get, true);
    xmlHttp.send(null);
}


function AjaxCombobox(URL_Get, sel_ParentID, sel_ChildID, Type) {
    var sel_Parent = document.getElementById(sel_ParentID);
    var sel_Child = document.getElementById(sel_ChildID);

    URL_Get = URL_Get + "?Ma=" + sel_Parent.value + "&Type=" + Type;
    var xmlHttp;
    try {
        // Firefox, Opera 8.0+, Safari
        xmlHttp = new XMLHttpRequest();
    }
    catch (e) {
        // Internet Explorer
        try {
            xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
        }
        catch (e) {
            try {
                xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            catch (e) {
                alert("Your browser does not support AJAX!");
                return false;
            }
        }
    }
    xmlHttp.onreadystatechange = function() {

        if (xmlHttp.readyState == 4) {

            var xmlDoc = xmlHttp.responseXML.documentElement;
            var arrTable = xmlDoc.getElementsByTagName("Child");
            sel_Child.innerHTML = "";
            var strHTML = "";

            var sBrowser = navigator.userAgent;
            if (sBrowser.toLowerCase().indexOf('msie') > -1) {
                var newOpt = document.createElement("option");
                newOpt.value = "0";
                newOpt.innerText = "- - Không chọn - -";
                sel_Child.appendChild(newOpt);
            }

            for (var i = 0; i < arrTable.length; i++) {
                var opt = document.createElement("option");
                if (arrTable[i].getElementsByTagName("Ma")[0].text) {
                    opt.value = arrTable[i].getElementsByTagName("Ma")[0].text;
                    opt.innerText = arrTable[i].getElementsByTagName("Ten")[0].text;
                    sel_Child.appendChild(opt);
                }
                else {
                    opt.value = arrTable[i].getElementsByTagName("Ma")[0].textContent;
                    opt.text = arrTable[i].getElementsByTagName("Ten")[0].textContent;
                    strHTML += "<option value='" + opt.value + "'>" + opt.text + "</option>"
                }

                opt = null;
            }
            if (sBrowser.toLowerCase().indexOf('msie') < 0) {
                sel_Child.innerHTML = "<option value='0'>- - Không chọn - -</option>" + strHTML;
            }
        }
        else { }
    }
    xmlHttp.open("GET", URL_Get, true);
    xmlHttp.send(null);
}
//lấy thông tin Ajax
function AjaxGetInfo(URL_Get, div_ID) {
    var xmlHttp;
    try {
        // Firefox, Opera 8.0+, Safari
        xmlHttp = new XMLHttpRequest();
    }
    catch (e) {
        // Internet Explorer
        try {
            xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
        }
        catch (e) {
            try {
                xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            catch (e) {
                alert("Your browser does not support AJAX!");
                return false;
            }
        }
    }
    xmlHttp.onreadystatechange = function() {

        if (xmlHttp.readyState == 4) {
            document.getElementById(div_ID).innerHTML = xmlHttp.responseText;
        }
    }
    xmlHttp.open("GET", URL_Get, true);
    xmlHttp.send(null);

}

//đổi ảnh khi trỏ chuột
function ChangeImage(mID, img_Path) {
    var ctr_Image = document.getElementById(mID);
    ctr_Image.src = img_Path;
}

function trim(sString) {
    while (sString.substring(0, 1) == ' ') {
        sString = sString.substring(1, sString.length);
    }
    while (sString.substring(sString.length - 1, sString.length) == ' ') {
        sString = sString.substring(0, sString.length - 1);
    }
    return sString;
}
function OpenNewWinDow(url) {
    window.open(url);
    return false;
}

//Hàm làm tròn
function RoundNummer(num_So, num_DoDaiThapPhan) {
    num_So = Number(num_So);
    var num_Temp = 1;
    for (var i = 0; i < num_DoDaiThapPhan; i++) {
        num_Temp *= 10;
    }
    return Math.round(num_So * num_Temp) / num_Temp;
}

