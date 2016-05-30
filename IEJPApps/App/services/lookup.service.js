(function () {
    "use strict";

    angular
        .module("app")
        .factory("LookupService", service);

    function service($http, $q, ErrorService) {
        return {
            getPeriodsList: getPeriodsList,
            getCurrentPeriod: getCurrentPeriod
        }

        function getPeriodsList(before, after) {
            return $http.get("/api/lookup/periods/list/" + before + "/" + after).then(handleSuccess, handleError);
        }
        
        function getCurrentPeriod() {
            return $http.get("/api/lookup/periods/current").then(handleSuccess, handleError);
        }

        function handleSuccess(res) {
            return res.data;
        }

        function handleError(res) {
            ErrorService.error('Errors.ErrorOccuredCancelled');

            return $q.reject(res.data);
        }
    }
})();