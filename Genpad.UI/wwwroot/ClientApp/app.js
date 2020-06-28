//Main app entry point

// App Configuration
var _appConfig = {
    mode: "dev",
    
}


// Require Configuration
requirejs.config({
    baseUrl: './ClientApp',
    paths: {
        app: 'app',
        jquery: '../lib/jquery/dist/jquery',
        bootstrap: '../lib/bootstrap/dist/js/bootstrap.bundle',
        knockout: '../lib/knockout-3.5.1',
        
    },
    shim: {
        "knockout": { deps: ["jquery"] },
        "bootstrap": { deps: ["jquery"] },
        "app": { deps: ["jquery", "knockout", "bootstrap"] },
        "dataService": { deps: ["jquery", "knockout", "bootstrap"] }
    }
});

// Main App View Model
define(function (require) {
    var $ = require('jquery'),
        ko = require('knockout'),
        bootstrap = require('bootstrap');
    
    function appViewModel() {
        var self = this;
        self.loading = ko.observable(true);

        // Load page view model
        self.initialize = function (model, name) {

            if (model != undefined) {
                self[name] = ko.computed(function () {
                    return new model(self);
                });


                if (_appConfig.mode == "dev")
                    self.logInfo("Page loaded: " + name);
            }
            
            ko.applyBindings(self);
            self.loading(false);
        }

        self.loading.subscribe(function (val) {
            if (val) {
                $('#page-loader').show();
            } else {
                $('#page-loader').hide();
            }
        });

        self.logInfo = function (message) {
            console.log(message);
        }

        self.logError = function (message) {
            console.error(message);
        }
    };

    var app = new appViewModel();
    return app;
});
