APP.manageChangePasswordViewModel = function (model){
    var self = model;
    $.extend(APP.manageChangePasswordViewModel, model);
    self.OldPassword = ko.observable().extend({
        required: true
    }),
    self.NewPassword = ko.observable().extend({
        required: true,
        minLength: 6
    }),
    self.ConfirmPassword = ko.observable().extend({
        required: true,
        equal: {
            message: "Passwords must match",
            params: self.NewPassword
        }
    }),
    self.submitChangePassword = function () {
        //ko.validation.group(self, { deep: true });
        if (self.isValid())
            alert("changePassword was executed.");
        else
            self.errors.showAllMessages();
    }
    return ko.validatedObservable(self);
};