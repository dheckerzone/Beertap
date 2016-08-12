
(function() {
    "use strict";

    angular
        .module('beertap.service', ['ngResource'])
        .constant('appSettings', {
            serverPath: 'http://localhost:3000/'
        })
        .factory('Office', function ($resource, appSettings) {

            var OfficeService = $resource(appSettings.serverPath + 'office', {}, {
                'query': {
                    method: 'get',
                    headers: {
                        'accept': 'application/hal+json'
                    }
                }
            });

            return OfficeService;
        });
        
        
})();
