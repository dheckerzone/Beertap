(function() {
    angular.module('Beertap')
        .controller('officeCtrl',
            function ($scope, Office, $http, appSettings) {

                Office.query().$promise.then(function (data) {
                    $scope.root = data;
                    $scope.offices = data._embedded.self;
                });

                $scope.beerOptions = ['Budweiser', 'Bud Light', 'Corona Extra', 'Labatt Blue', 'Red Horse Beer', 'San Miguel Pale Pilsen', 'Victoria Bitter'];

                $scope.selectedBrand = 'Budweiser';

                $scope.selectedOffice = {};

                $scope.loadBeers = function (office) {
                    $scope.selectedOffice = office;
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

                $scope.addKeg = function (office, brand) {
                    var link = appSettings.serverPath + office._links.AddKeg.href;

                    var newKeg = {
                        "OfficeId": office.Id,
                        "Brand": brand,
                        "Milliliters": 4000,
                        "BeerState": "New"
                    }

                    $http({
                        method: "POST",
                        url: link,
                        headers: {
                            'accept': 'application/hal+json',
                            'Content-Type': 'application/json'
                        },
                        data: newKeg
                    }).then(function (response) {
                        $scope.beers._embedded.self.push(response.data);
                    });
                }
            });
})();