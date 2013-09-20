var APP = window.app || {};
window.app = APP;
APP.init = function () {
    ko.bindingHandlers.stopBindings = {
        init: function () {
            return { 'controlsDescendantBindings': true };
        }
    };
    ko.validation.init({
        insertMessages: false,
        decorateElement: true,
        errorElementClass: 'error'
    }, true);
}
APP.helpers = {
    addAntiForgeryToken : function(data) {
        data.__RequestVerificationToken = $('#__AjaxAntiForgeryForm input[name=__RequestVerificationToken]').val();
        return data;
    },
    prepareRelativeUrl: function (url) {
        return $('head base').attr('href') + url;
    },
    performAjaxPost : function (url, postData, successCB, failureCB) {
        $.ajax({
            url: url,
            type: 'POST',
            headers: {
                __RequestVerificationToken: $('#__AjaxAntiForgeryForm input[name=__RequestVerificationToken]').val()
            },
            contentType: 'application/json',
            data: postData,
            success: function (result) {
                successCB(result);
            },
            error: function () {
                failureCB();
            }
        });
    },
    getQueryStringValByName: function (name) {
        name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
        return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));

    }

}
$(function () { APP.init(); });
