define(function (require) {
    var $ = require('jquery'),
        ko = require('knockout'),
        bootstrap = require('bootstrap');

    var model = function () {
        var self = this;
        var apiURL = 'api/';

        self.getRequest = function (url, paramObject) {
            var url = apiURL + url;

            return $.ajax({
                url: url,
                method: 'GET',
                crossDomain: true,
                data: paramObject || {},
                dataType: 'json'
            });
        }
    }

    return model;
});