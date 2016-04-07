(function () {
    'use strict';

    angular
        .module('app')
        .factory('LookupService', Service);

    function Service($http, $q) {
        return {
            GetPeriodsList: GetPeriodsList,
            GetPeriodsNow: GetPeriodsNow
        }

        function GetPeriodsList(before, after) {
            return $http.get('/api/lookup/periods/list/' + before + '/' + after).then(handleSuccess, handleError);
        }
        
        function GetPeriodsNow() {
            return $http.get('/api/lookup/periods/current').then(handleSuccess, handleError);
        }

        function handleSuccess(res) {
            return res.data;
        }

        function handleError(res) {
            return $q.reject(res.data);
        }
    }
})();