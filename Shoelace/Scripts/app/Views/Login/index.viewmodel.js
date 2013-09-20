APP.userLoginViewModel = function (model) {
    var self = this;

    $.extend(self, model);

    //self.login = function () {
    //    var url = APP.helpers.prepareRelativeUrl("Login/LoginUser");
    //    self.returnUrl = APP.helpers.getQueryStringValByName("ReturnUrl");
    //    $.ajax({
    //        url: url,
    //        type: 'POST',
    //        contentType: 'application/json',
    //        data: ko.toJSON(self),
    //        success: function (result) {
    //            if (result != null) {
    //                if (result.validLogin)
    //                    window.location.href = result.validLoginUrl;
    //                }
    //        },
    //        error: function () {
    //            alert('An error has occured. Please try again.');
    //        }
    //    });
    //};
    self.login = function () {
        var url = APP.helpers.prepareRelativeUrl("Login/LoginUser");
        self.returnUrl = APP.helpers.getQueryStringValByName("ReturnUrl");
        APP.helpers.performAjaxPost(url,
            ko.toJSON(self),
            function (result) {
                if (result != null) {
                    if (result.validLogin)
                        window.location.href = result.validLoginUrl;
                }
            },
            function () {
                alert('An error has occured. Please try again.');
        });
    };
    return self;
};