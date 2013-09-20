APP.userRegisterViewModel = function (model) {
    var self = this;
    $.extend(self, model);

    self.firstName = ko.observable().extend({
        required: true
    });
    self.userName = ko.observable().extend({
        required: true,
        email: true
    });

    self.password = ko.observable().extend({
        required: true,
        minLength: 6
    });
    self.confirmPassword = ko.observable().extend({
        required: true,
        equal: {
            message: "Passwords must match",
            params: self.password
        }
    });
    self.submitRegistration = function () {
        var url = APP.helpers.prepareRelativeUrl("Login/RegisterUser");
        if (self.isValid())
            APP.helpers.performAjaxPost(url,
                      ko.toJSON(self),
                      function (result) {
                          if (result != null && result.success == true) {
                              alert('An account has been created.  Please login to proceed.');
                              window.location.href = "/";
                          }
                      },
                      function () {
                          alert('An error has occured. Please try again.');
                      });
        else
            self.errors.showAllMessages();

     
    };
    return ko.validatedObservable(self);
};