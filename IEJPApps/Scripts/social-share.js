
window.pharmajc = window.pharmajc || {};

pharmajc.Share = (function ($) {

    'use strict';

    /**
     * Has the application been initialized?
     * @private
     */
    var inited = false;

    /**
     * Initializes the class.
     * @public
     */
    var init = function (options) {

        // Abort if already initialized
        if (inited) return false;

        // Facebook
        var fbSDKUrl = '//connect.facebook.net/' + ($('html').attr('lang') == 'en' ? 'en_CA' : 'fr_CA') + '/sdk.js';
        var fbAppId = $('meta[name=ga-fbappid]').attr("content") || "";
        var url = 'https://' + location.host + location.pathname;
        $.getScript(fbSDKUrl, function () {
            FB.init({
                appId: fbAppId,
                status: true,
                cookie: true,
                xfbml: true,
                version: 'v2.5' // or v2.0, v2.1, v2.2, v2.3
            });


            $('.sharing-container .facebook').on('click', function (e) {
                e.preventDefault();

                FB.ui({
                    method: 'share',
                    href: url
                }, function (response) { });
            });
        });

        // Twitter
        $.getScript('https://platform.twitter.com/widgets.js', function () {
            var description = $('meta[property=twitter-description]').attr("content") || "";
            description = description == '' ? ($('meta[name=description]').attr("content") || "") : description;
            var qs = (description == '' ? '?' : '?text=' + description + '&') + 'url=' + url + '&hashtags=JeanCoutu';
            $('.sharing-container .twitter').attr('href', 'https://twitter.com/intent/tweet' + qs);
        });

        // Google+
        $.getScript('https://apis.google.com/js/platform.js', function () {
            $('.sharing-container .google-plus')
                .attr('href', 'https://plus.google.com/share?url=' + url)
                .on('click', function (e) {
                    window.open(this.href, '', 'menubar=no,toolbar=no,resizable=yes,scrollbars=yes,height=600,width=600');
                    return false;
                });
        });

        // Pinterest

        // Si on n'a pas d'image de SEO, cacher les bouton
        var ogImg = $("meta[property='og:image']");
        if (ogImg && ogImg.attr("content")) {
            $.getScript('https://assets.pinterest.com/js/pinit.js', function () {
                var pinObj = {
                    url: url,
                    media: ogImg.attr("content")
                };
                var description = $('meta[property=pinterest-description]').attr("content") || "";
                description = description == '' ? ($('meta[name=description]').attr("content") || "") : description;
                if (description != '') {
                    pinObj.description = description;
                }

                $('.sharing-container .pinterest').on('click', function (e) {
                    e.preventDefault();
                    PinUtils.pinOne(pinObj);
                });
            });
        } else {
            $('.sharing-container .pinterest').remove();
        }

        // Social share bar, open/close share buttons
        $('#social-share, .sharing-text').on('click', function (e) {
            e.preventDefault();
            if (!$(this).closest('.sharing-share').hasClass('open')) {
                $(this).closest('.sharing-share').addClass('open');
            } else {
                $(this).closest('.sharing-share').removeClass('open');
            }
        });

        $('.sharing-container .sharing-close-box').on('click', function () {
            $(this).closest('.sharing-share').removeClass('open');
        });

        inited = true;

        return true;
    };

    /**
     * Expose public methods & properties.
     */
    return {
        init: init,
    };

})(jQuery);
