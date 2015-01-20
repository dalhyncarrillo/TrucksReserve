// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

$.ajaxSetup({
    // Disable caching of AJAX responses (needed for IE)
    cache: false
});

//If at least one page has been loaded dynamically, only then window.onpopstate can be used.
var popped = false;

var indexPage = '/Main/Index';

var DivIDimgPreviewWithStyles = 'imgPreviewWithStyles';
var DivIDforLoadingPartialPages = 'partialPage';
var UlSubMenusShownOnHoverClass = 'showOnHover';
var DivIDforAnimating = 'bodyDiv';
var DivIDMsBingMap = 'mapviewer';
var DivIDSlideshow = 'my-slideshow';

var loadingPartialViewAnimationInProgress = false;

window.onpopstate = function (event) {

    if (popped === true) {
        if (event.state) {
            $('#' + DivIDforLoadingPartialPages).load(e.state);

            document.title = e.state.pageTitle;
        }
        else {
            if (document.location.pathname !== '/') {
                $('#' + DivIDforLoadingPartialPages).load(document.location.pathname);
            } else {
                $('#' + DivIDforLoadingPartialPages).load(indexPage);
            }

        }
    }
};

//Dynamic load of page with animation
function LoadPartialPage(action, model, parameter) {
    if (loadingPartialViewAnimationInProgress == true) {
        return;
    }

    loadingPartialViewAnimationInProgress = true;

    try {
        //the view, which must be open
        var pageToOpen = "";
        if (parameter !== null) {
            pageToOpen = '/' + model + '/' + action + '/' + parameter;
        }
        else {
            pageToOpen = '/' + model + '/' + action;
        }

        if (window.history && window.history.pushState) {
            window.history.pushState($(this).attr("href"), "Page Title", pageToOpen);
            SetPoppedAsTrue();
        } else {
            $.address.value($(this).attr("href"));
        }

        //hides all sub menus
        $("." + UlSubMenusShownOnHoverClass).css("display", "none");

        //animate and load the view
        AnimatePanel(pageToOpen);
    }
    catch (err) {
        loadingPartialViewAnimationInProgress = false;
    }
}

function SetPoppedAsTrue() {
    popped = true;
}

//Events for hiding and displaying the sub menus
jQuery(document).ready(function () {
    jQuery(".hover").hover(function () {
        $(this).children("." + UlSubMenusShownOnHoverClass).css("display", "block");
    }, function () {
        $(this).children("." + UlSubMenusShownOnHoverClass).css("display", "none");
    });
});


//Animates and loads the selected view
function AnimatePanel(pageToOpen) {
    //Removes the element with bing map, otherwise there is change for exception in IE, and an pop up might be displayed.
    if ($.browser.msie == true) {
        var bingMapDiv = $('#' + DivIDMsBingMap);
        if (bingMapDiv != null) {
            bingMapDiv.remove();
        }
    }
   
    var bodyDiv = $("#" + DivIDforAnimating);

    bodyDiv.animate({
        left: '-=400px'
        , opacity: 0
    }
    , 500
    , function () {
        //remove of the div, which is used to display enlarged images, to prevent duplicates
        $('#' + DivIDimgPreviewWithStyles).remove();
        //Show the loading animation
        $('#' + DivIDforLoadingPartialPages).html(GetLoadingDivHtml());
        //AJAX load of the selected view
        $('#' + DivIDforLoadingPartialPages).load(pageToOpen);
    }
    ).animate({ left: '+=1600' }, 1).delay(500).animate({
        left: '-=1200px',
        opacity: 1
    }, 500
    , function () {
        loadingPartialViewAnimationInProgress = false;
    });

}

function GetLoadingDivHtml() {
    var htmlStr = '<div class="loadingPageDiv blockWithContent"> <div class="bottomDivs" style="padding:5px 10px 4px 10px;"><img src="/Resources/Images/Site/loader.gif" /></div></div>'
    return htmlStr;
}

//Sets position of the dynamic loaded image related to the cursor
function SetImageImgPos(_top, _left) {
    if (IsNumber(_top) === true) {
        imgPosTop = _top;
    }

    if (IsNumber(_left) === true) {
        imgPosLeft = _left;
    }
}

function IsNumber(o) {
    return (o !== null && !isNaN(o - 0));
}

function LoadImageEnlarger(src) {

    $('a.enlarge').imgPreview({
        containerID: DivIDimgPreviewWithStyles,
        preloadImages: false,
        containerLoadingClass: 'imgPreloading',
        imgCSS: {
            // Limit preview size:
            'max-height': 900,
            'max-width': 900,
            'min-width': 100,
            'min-height' : 100
        },
        // When container is shown:
        onShow: function (link) {
            // Animate link:
            $(link).stop().animate({ opacity: 0.4 });
            // Reset image:
            $('img', this).stop().css({ opacity: 0 });
        },
        // When image has loaded:
        onLoad: function () {
            // Animate image
            $(this).animate({ opacity: 1 }, 300);
        },
        // When container hides: 
        onHide: function (link) {
            // Animate link:
            $(link).stop().animate({ opacity: 1 });
        },

        srcAttr: src
    });

}

//Transforms images to black-white on IE only, since other browsers support it css property for that
function DesaturateImgForIe10Plus(img) {
    if ($.browser.msie == true && $.browser.version >= 9) {
        Pixastic.process(img, "desaturate", { average: false });
    }
}

//http://stackoverflow.com/questions/4406291/jquery-validate-unobtrusive-not-working-with-dynamic-injected-elements
//Refreshes validation on dynamically loaded form
function UpdateFormValidation()
{
    $("form").removeData("validator");
    $("form").removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse("form");
}

//Hide element via animation
function HideElement(id, miliseconds) {

    var element = $("#" + id);

    if (element != null) {
        element.animate(
            { height: 'toggle' }
            , miliseconds
            );
    }
}

//Slider options
jQuery(document).ready(function ($) {

    var slideShowDiv = $('#' + DivIDSlideshow);
    if (slideShowDiv != null) {
        slideShowDiv.bjqs({
            animtype: 'slide',
            animduration: 700,
            animspeed: 6000,
            automatic: true,
            height: 130,
            width: 1200,
            responsive: true,
            randomstart: true,
            showcontrols: false,
            hoverpause: true,
            showmarkers: false,
            usecaptions: false
        });
    }

    
});