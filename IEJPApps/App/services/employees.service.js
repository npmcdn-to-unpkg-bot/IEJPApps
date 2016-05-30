(function () {
    'use strict';

    angular
        .module('app')
        .factory('EmployeesService', Service);

    function Service($http, $q, ErrorService) {
        return {
            New: New,
            GetAll: GetAll,
            GetById: GetById,
            Create: Create,
            Update: Update,
            Delete: Delete        
        };

        function New() {
            return {};
        }

        function GetAll() {
            return $http.get('/api/employees').then(handleSuccess, handleError);
        }

        function GetById(_id) {
            return $http.get('/api/employees/' + _id).then(handleSuccess, handleError);
        }

        function Create(project) {
            return $http.post('/api/employees', project).then(handleSuccess, handleError);
        }

        function Update(project) {
            return $http.put('/api/employees/', project).then(handleSuccess, handleError);
        }

        function Delete(_id) {
            return $http.delete('/api/employees/' + _id).then(handleSuccess, handleError);
        }

        // private functions

        function handleSuccess(res) {
            return res.data;
        }

        function handleError(res) {
            ErrorService.error('Errors.ErrorOccuredCancelled');

            return $q.reject(res.data);
        }
    }
})();