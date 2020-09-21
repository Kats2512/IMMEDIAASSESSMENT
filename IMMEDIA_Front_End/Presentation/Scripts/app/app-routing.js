var mainContent;
var titleContent;

$(function() {
    mainContent = $("#MainContent"); /// render partial views.
    titleContent = $("title"); // render titles.
});

var routingApp = $.sammy("#MainContent", function() {
    this.get("#/Home/About", function(context) {
        titleContent.html("About");
        $.get("/Home/About", function(data) {
            context.$element().html(data);
        });
    });

    this.get("#/Home/Contact", function(context) {
        titleContent.html("Contact");
        $.get("/Home/Contact", function(data) {
            context.$element().html(data);
        });
    });

    this.get("#/Home/Index", function(context) {
        titleContent.html("Home");
        $.get("/Home/Index", function(data) {
            context.$element().html(data);
        });
    });

    this.get("#/Home/GetImagesForVenue", function(context) {
        titleContent.html("Venue Photos");
        $.get("/Home/GetImagesForVenue", {
            venueId: context.params.venueId,
            venueName: context.params.venueName// pass student id
        }, function(data) {
            context.$element().html(data);
        });
    });

    this.get("#/Home/GetPhotoDetails", function(context) {
        titleContent.html("Photo Details");
        $.get("/Home/GetPhotoDetails", {
            photoId: context.params.photoId // pass student id
        }, function(data) {
            context.$element().html(data);
        });
    });

    this.get("#/Account/Register", function(context) {
        titleContent.html("Register");
        $.get("/Account/Register", function(data) {
            context.$element().html(data);
        });
    });

    this.get("#/Account/Login", function(context) {
        //alert(context.params.isPartial);
        titleContent.html("Login");
        $.get("/Account/Login", {
            isPartial: context.params.isPartial // pass student id
        }, function(data) {
            context.$element().html(data);
        });
    });

    this.get("#/", function (context) {
        titleContent.html("Home");
        $.get("/Home/Index", function (data) {
            context.$element().html(data);
        });
    });
});

$(function() {
    routingApp.run("#/Home/Index"); // default routing page.
});