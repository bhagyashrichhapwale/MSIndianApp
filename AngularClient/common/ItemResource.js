(function () {
    angular.module("common.services")
        .factory("ItemResource", ['$resource', "appSetting", ItemResource]);

    function ItemResource($resource, appSetting) {
        return $resource(appSetting.url + "api/Item/:id");
                
    }


}());