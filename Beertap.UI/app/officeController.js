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

            });
})();