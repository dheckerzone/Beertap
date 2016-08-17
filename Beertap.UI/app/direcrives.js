(function () {
    "use strict";

    angular.module('Beertap')
    .directive('getBeer', function () {
        return {
            restrict: 'E',
            templateUrl: './templates/getBeer.html'
        };
    })
    .directive('replaceKeg', function () {
        return {
            restrict: 'E',
            templateUrl: './templates/replaceKeg.html'
        };
    });
})();