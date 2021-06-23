var ViewModel = function () {
    var self = this;
    self.ImForms = ko.observableArray();
    self.error = ko.observable();

    var imformUri = '/api/ImForm/'

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllImForms() {
        ajaxHelper(imformUri, 'GET').done(function (data) {
            self.ImForms(data);
           // self.ImForms('NA');
        });
    }

    // Fetch the initial data.
    getAllImForms();
};

ko.applyBindings(new ViewModel());