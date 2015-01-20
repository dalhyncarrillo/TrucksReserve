/**
*	Site-specific configuration settings for Highslide JS
*/
hs.graphicsDir = '/Scripts/highslide/graphics/';
hs.showCredits = false;
hs.outlineType = 'custom';
hs.fadeInOut = true;
hs.allowMultipleInstances = false;
hs.maxWidth = 1000;
hs.maxHeight = 1000;
hs.align = 'center';

hs.cacheAjax = false;
hs.forceAjaxReload = true;

//За да не може да се клика по интерфейса когато е отворена картинка
hs.dimmingOpacity = 0.75;

hs.registerOverlay({
	html: '<div class="closebutton" onclick="return hs.close(this)" title="Close"></div>',
	position: 'top right',
	useOnHtml: true,
	fade: 2 // fading the semi-transparent overlay looks bad in IE
});



