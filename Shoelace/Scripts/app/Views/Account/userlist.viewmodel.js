APP.userListViewModel = function (model) {
    var self = model;
    $.extend(APP.userListViewModel, model);
    self.selectedUser = ko.observable({});
    self.confirmDelete = function () {
        $("#hdDeleteUserId").val(this.userId());
    };
    self.performDelete = function () {
        //alert("performDelete called for UserId: " + $("#hdDeleteUserId").val());
        var url = APP.helpers.prepareRelativeUrl("Account/DeleteUser");
        APP.helpers.performAjaxPost(url,
                JSON.stringify({ UserId: $("#hdDeleteUserId").val() }),
                function (result) {
                    if (result != null && result.success == true) {
                        alert('Your profile has been update.');
                        location.reload();
                    }
                },
                function () {
                    alert('An error has occured. Please try again.');
                });
    };
    self.cancel = function () {
        //alert("cancelDelete called");
    };
    self.showUserPermissions = function () {
        self.selectedUser(this);
        //$("#hdPermissionsUserId").val(this.userId());
    };
    self.saveUserPermissions = function () {
        var url = APP.helpers.prepareRelativeUrl("Account/SaveUserRoles");
        APP.helpers.performAjaxPost(url,
                ko.toJSON(self.selectedUser),
                function (result) {
                    //Do nothing.
                },
                function () {
                    alert('An error has occured. Please try again.');
                });
    };
    return ko.validatedObservable(self);
};