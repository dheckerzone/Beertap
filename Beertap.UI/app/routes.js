(function () {

    "use strict";

    angular
        .module('Beertap')
        .config(function ($routeProvider, $locationProvider) {
            $routeProvider
                .when('/office', {
                    templateUrl: '/templates/office/index.html',
                    controller: 'officeCtrl'
                })
                .when('/beer', {
                    templateUrl: '/templates/beer/index.html',
                    controller: 'beerCtrl'
                })
                .otherwise({ redirectTo: '/office' });
        });

})();