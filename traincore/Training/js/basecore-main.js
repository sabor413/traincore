
// Slideshow module
var SlideShow = (function ($) {

    var checkMode;

    checkMode = function () {
        if (typeof Sitecore != "undefined") {
            //get parameter from url 
            var queries = {};
            $j.each(document.location.search.substr(1).split('&'), function (c, q) {
                var i = q.split('=');
                queries[i[0].toString()] = i[1].toString();
            });
            return queries["sc_mode"];
        }

        return 'visitor';
    };


    return {
        init: function (element) {
            var mode = checkMode();

            if (mode !== 'edit') {
                $(element).slides({
                    preload: true,
                    preloadImage: 'img/loading.gif',
                    play: 5000,
                    pause: 2500,
                    hoverPause: true
                });
            }
            else {
                $(element).find('.slides_container').css('width', 'auto').css('display', 'block').css('height', 'auto');
            }
        }
    }
})(jQuery);

// Module that returns additional details about a holiday within a listing by
// pulling in a JSON object
var HolidayDetails = (function ($) {

    return {
        GetJSON: function (url, appendElement) {
            $.getJSON(url, appendElement, function (data) {
                $("." + appendElement).html(
                    "<table>" +
                    "<tr><th>" + data.DifficultyLabel + "</th><td>" + data.Difficulty + "</td></tr>" +
                    "<tr><th>" + data.TypeLabel + "</th><td>" + data.Type + "</td></tr>" +
                    "<tr><th>" + data.TerrainLabel + "</th><td>" + data.Terrain + "</td></tr>"
                    + "</table>");
            });
        }
    };
}(jQuery));

// Binding
$(document).ready(function ($) {
    $('.details').click(function (e) {
        var url = $(this).attr('href');
        var element = $(this).data('target');

        e.preventDefault();

        $(this).toggleClass("closed");

        HolidayDetails.GetJSON(url, element);

        $("." + element).slideToggle();

    });

    $("#mainform").validateWebForm();

    if (typeof Sitecore != "undefined") {
        if (Sitecore.PageModes) {
            $('.errorPreview').show();
        }
    }
});
