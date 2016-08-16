(function () {

    "use strict";

    angular
        .module('Beertap')
        .config(function ($routeProvider, $locationProvider) {
            $routeProvider
                .when('/offices', {
                    templateUrl: '/templates/office/index.html',
                    controller: 'officeCtrl'
                })
                .when('/beers', {
                    templateUrl: '/templates/beer/index.html',
                    controller: 'beerCtrl'
                })
                .otherwise({ redirectTo: '/offices' });
        });

})();