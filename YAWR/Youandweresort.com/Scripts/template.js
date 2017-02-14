"use strict";
jQuery(document).ready(function () {



    jQuery('.animated-box').on('inview', function (event, isInView) {
        if (isInView) {
            var _this = jQuery(this),
				animationType = _this.data('animation'),
				animationDelay = _this.data('delay');
            animationDelay ? setTimeout(function () {
                _this.addClass(animationType);
            }, animationDelay) : _this.addClass(animationType);
        }
    });

    if (jQuery.isFunction(jQuery.fn.select2)) {
        // Change all the select boxes to select2
        jQuery("select:not(.disable-select2)").select2({
            minimumResultsForSearch: 10
        });
    }

    jQuery('[data-bg-img]').each(function () {
        var _this = jQuery(this);
        _this.css('background-image', 'url(' + _this.data('bg-img') + ')');
    });




    var mainImgContainer = jQuery(".image-main-box");
    // Enable the magnificPopup
    jQuery.fn.magnificPopup && mainImgContainer.magnificPopup({
        delegate: '.item:not(":hidden") .more-details',
        type: 'image',
        removalDelay: 600,
        mainClass: 'mfp-fade',
        gallery: {
            enabled: true,
            navigateByImgClick: true,
            preload: [0, 1] // Will preload 0 - before current, and 1 after the current image
        },
        image: {
            titleSrc: 'data-title',
            tError: '<a href="%url%">The image #%curr%</a> could not be loaded.'
        }
    });


    jQuery.fn.magnificPopup && jQuery('.video-url').magnificPopup({
        disableOn: 700,
        type: 'iframe',
        mainClass: 'mfp-fade',
        removalDelay: 600,
        preloader: false,
        fixedContentPos: false
    });

    // Enable isotop for gallery
    if (jQuery.fn.magnificPopup && jQuery.fn.imagesLoaded) {
        mainImgContainer.isotope({
            transitionDuration: "0.7s"
        });
        mainImgContainer.imagesLoaded(function () {
            mainImgContainer.isotope("layout");
            jQuery(".sort-section-container").on("click", "a", function (e) {
                e.preventDefault();
                jQuery(".sort-section-container a").removeClass("active");
                jQuery(this).addClass("active");
                var filterValue = jQuery(this).attr("data-filter");
                mainImgContainer.isotope({ filter: filterValue });
            });
        });
    }

    // Enable isotop for Events
    jQuery.fn.imagesLoaded && jQuery(".event-main-box, .dishes-main-box").imagesLoaded(function () {
        var eventContainer = jQuery(".event-main-box, .dishes-main-box");
        eventContainer.isotope({
            transitionDuration: "0.7s"
        });
        eventContainer.imagesLoaded(function () {
            eventContainer.isotope("layout");
            jQuery(".sort-section-container").on("click", "a", function (e) {
                e.preventDefault();
                jQuery(".sort-section-container a").removeClass("active");
                jQuery(this).addClass("active");
                var filterValue = jQuery(this).attr("data-filter");
                eventContainer.isotope({ filter: filterValue });
            });
        });
    });

    // Enable isotop for Guest Book
    if (jQuery.fn.isotope && jQuery("#guest-book").length > 0) {

        jQuery('.inner-container', "#guest-book").isotope({
            itemSelector: ".guest-book-item"
        });
    }

    var bodyElement = jQuery("body");
    // Enable isotop for Guest Book
    if (jQuery.fn.isotope && bodyElement.hasClass('blog-masonry')) {
        var eventContainer = jQuery('.post-main-container', "#blog-section");
        eventContainer.isotope({
            transitionDuration: "0.7s"
        });
        eventContainer.imagesLoaded(function () {
            itemSelector: ".post-outer-box"
        });
    }





});
var mainHeader = jQuery("#main-header");
//jQuery(window).on('scroll', function () {
//    jQuery(document).scrollTop() > 30 && mainHeader.addClass("sticky");
//    jQuery(document).scrollTop() < 30 && mainHeader.removeClass("sticky");
//});

$(document).ready(function () {
    //hidden button menu
    var windownWidth = $(window).innerWidth();
    $(window).resize(function () {
        windownWidth = $(window).innerWidth();
        if (windownWidth < 1250) {
            $('.hideItemMenu').hide();
        } else {
            $('.hideItemMenu').show();
        }
    });
    setInterval(function () {
        windownWidth = $(window).innerWidth();
        if (windownWidth < 1250) {
            $('.hideItemMenu').hide();
        } else {
            $('.hideItemMenu').show();
        }
    }, 100);
});