(function() {
    angular.module('Beertap')
        .controller('officeCtrl',
            function ($scope, Office, $http, appSettings) {

                Office.query().$promise.then(function (data) {
                    $scope.root = data;
                    $scope.offices = data._embedded.self;
                });

                $scope.loadBeers = function (office) {
                    var link = appSettings.serverPath + office._links.Beer.href;
                    $http({
                        method: "GET",
                        url: link,
                        headers: {'accept':'application/hal+json'}
                    }).then(function (response) {
                        $scope.beers = response.data;
                    });
                }

                $scope.getBeer = function (beer,index) {
                    beer.Milliliters = 400;

                    var link = appSettings.serverPath + beer._links.GetBeer.href;

                    $http({
                        method: "POST",
                        url: link,
                        headers: {
                            'accept': 'application/hal+json',
                            'Content-Type': 'application/json'
                        },
                        data: beer
                    }).then(function (response) {
                        $scope.beers._embedded.self[index] = response.data;
                    });
                }

                $scope.replaceKeg = function (beer,index) {
                    var link = appSettings.serverPath + beer._links.ReplaceKeg.href;
                    $http({
                        method: "POST",
                        url: link,
                        headers: {
                            'accept': 'application/hal+json',
                            'Content-Type': 'application/json'
                        },
                        data: beer
                    }).then(function (response) {
                        $scope.beers._embedded.self[index] = response.data;
                    });
                }
            });
})();