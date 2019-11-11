(function () {
    'use strict'
    angular.module('commonService', ['ngResource'])
        .constant('appSettings',
        {
                serverPath: 'https://localhost:44375/api/' //API katmanının localhostu 
        });
})();