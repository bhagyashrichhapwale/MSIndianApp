(function () {
    angular.module("MSIndiansApp")
        .controller("BuySellCtrl", ['ItemResource','$scope','$http',BuySellCtrl])
    
    function BuySellCtrl(ItemResource,$scope,$http)
    {
        vm = this;
        vm.message = "Buy/Sell"

        ItemResource.query(function (response) {
            alert("Inside the success****");
            alert(JSON.stringify(response));
            vm.items = response;
        });

       
    }

}());