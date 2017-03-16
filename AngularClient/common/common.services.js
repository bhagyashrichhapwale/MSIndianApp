(function () {
    var app = angular.module("common.services", ["ngResource"])
    .constant(
        "appSetting",
        {
            'url': 'http://localhost:61034/'
        });
}());