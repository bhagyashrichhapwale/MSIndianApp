(function () {
    var app = angular.module("MSIndiansApp", ['ui.router','common.services']);

    app.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise('/home');

        $stateProvider.
            state('home', {
                url: '/home',
                views: {
                    'main@': {
                        templateUrl: '../app/html/home.html'

                    }
                }
            }).
            state('buysell', {
                parent: 'home',
                url: '/buysell',
                views:
                    {
                        'main@': {
                            templateUrl: '../app/html/buysell.html',
                            controller: 'BuySellCtrl as vm'
                            
                        }
                    }
            })

    }]);
}());