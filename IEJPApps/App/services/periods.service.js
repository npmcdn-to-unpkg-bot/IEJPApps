(function () {
    'use strict';

    angular
        .module('app')
        .factory('PeriodsService', ["$http", "$q", "$translate", "ErrorService", service]);

    function service($http, $q, $translate, errorService) {
        return {
            getState: getState,
            getAll: getAll,
            getById: getById,
            create: create,
            defaults: defaults,
            update: update,
            remove: remove
        };

        function getState(period) {
            if (period.OpenedDate && period.ClosedDate == null)
                return $translate("States.Opened");
            if (period.ClosedDate)
                return $translate("States.Closed");
            return "-";
        }

        function getAll() {
            return $http.get('/api/payperiods').then(handleSuccess, handleError);
        }
        
        function getById(id) {
            return $http.get('/api/payperiods/' + id).then(handleSuccess, handleError);
        }

        function create(period) {
            if (period)
                return $http.post('/api/payperiods', period).then(handleSuccess, handleError);
            return $q.when(defaults());
        }

        function defaults() {
            return {
                Id: null,
                StartDate: "",
                EndDate: "",
                OpenedDate: null,
                ClosedDate: null,
                WeekNumber: null,
                IsCurrent: false,
                IsActive: false,
                IsVisible: false
            };
        }

        function update(period) {
            return $http.put('/api/payperiods/', period).then(handleSuccess, handleError);
        }

        function remove(id) {
            return $http.delete('/api/payperiods/' + id).then(handleSuccess, handleError);
        }

        function handleSuccess(res) {
            return res.data;
        }

        function handleError(res) {
            errorService.error('Errors.ErrorOccuredCancelled');

            return $q.reject(res.data);
        }
    }
})();