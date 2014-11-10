function customerEditorModel(data) {
    var self = this;
    self.customerId = ko.observable(data.customerId);
    self.companyName = ko.observable(data.companyName).extend({ required: true, minLength: 2 });
    self.contactName = ko.observable(data.contactName).extend({ required: true });
    // todo other fields 
    
}

function customerViewModel() {
    var _this = {};

    _this.page = ko.observable(1);
    _this.records = ko.observable(1);
    _this.totalPages = ko.observable(1);
    _this.rowsPerPage = ko.observable(10);
    _this.pagesText = ko.computed(function () {
        return _this.page() +
        " of " + _this.totalPages() + " pages";
    });

    _this.editingItem = ko.observable(null);
    _this.isItemEditing = function (itemToTest) {
        return _this.editingItem() && itemToTest.customerId() == _this.editingItem().customerId();
    };

    _this.customers = ko.observableArray();

    function pageBack(item) {
        _this.page(_this.page() - 1);
        loadDataFromServer();
    }

    _this.PageBack = pageBack;

    function pageNext(item) {
        _this.page(_this.page() + 1);
        loadDataFromServer();
    }

    _this.PageNext = pageNext;

    _this.EditCustomer = function (customer) {
        var editor = new customerEditorModel(ko.toJS(customer));
        editor.errors = ko.validation.group(editor);
        _this.editingItem(editor);
    };

    _this.ApplyCustomer = function(customer) {
        var editor = _this.editingItem();

        if (!editor.isValid()) {
            return;
        }

        $.ajax({
            url: '/customer',
            data: ko.toJS(editor),
            type: 'PUT',
            dataType: "json"
        }).then(function(data) {
            if (data.status != "ok") {
                return toastr.error(data.message);
            }

            var match = ko.utils.arrayFirst(_this.customers(), function (item) {
                return editor.customerId() === item.customerId();
            });

            if (match) {
                match.companyName(editor.companyName());
                match.contactName(editor.contactName());
                // todo other fields
            }

            _this.editingItem(null);

            toastr.success('Customer has been updated', '');
        });
    };

    _this.CancelEdit = function (customer) {
        _this.editingItem(null);
    };

    function loadDataFromServer() {
        var url = '/customer';
        url += '?count=' + _this.rowsPerPage() + '&page=' + _this.page();

        $.get(
            url,
            function (data) {
                if (data.status != "ok") {
                    return toastr.error(data.message);
                }
                
                _this.records(data.data.total);
                _this.totalPages((Math.ceil(data.data.total / _this.rowsPerPage())));

                var results = ko.observableArray();
                _this.customers.removeAll();
                ko.mapping.fromJS(data.data.data, {}, results);
                for (var i = 0; i < results().length; i++) {
                    _this.customers.push(results()[i]);
                };
            },
            'json'
        );
    }
    
    ko.applyBindings(_this, $("body").get(0));

    loadDataFromServer();

    return _this;
}

$(document).ready(function () {
    var viewModel = customerViewModel();
});

