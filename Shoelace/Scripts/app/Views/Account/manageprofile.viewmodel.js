APP.manageProfileViewModel = function (model) {
    var self = model;
    $.extend(APP.manageProfileViewModel, model);

    self.firstName = ko.observable(self.firstName()).extend({
        required: true
    });
    self.saveData = function () {
        if (self.isValid()) {
            var url = APP.helpers.prepareRelativeUrl("Account/SaveProfileInfo");
            APP.helpers.performAjaxPost(url,
                    ko.toJSON(self),
                    function (result) {
                        if (result != null && result.success == true) {
                            alert('Your profile has been update.');
                            location.reload();
                        }
                    },
                    function () {
                        alert('An error has occured. Please try again.');
                    });
        }
        else
            self.errors.showAllMessages();
    };

    return ko.validatedObservable(self);
};