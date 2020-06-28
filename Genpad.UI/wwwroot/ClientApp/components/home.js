define(function(require) {
    var $ = require('jquery'),
        ko = require('knockout'),
        bootstrap = require('bootstrap'),
        dataService = require('../services/dataService');
    
    var viewModel = function () {
        var self = this;

        var noteModal = $('#noteFormModal');

        self.openNoteModal = function () {
            noteModal.modal('show');
        }
    }

    return viewModel;
});