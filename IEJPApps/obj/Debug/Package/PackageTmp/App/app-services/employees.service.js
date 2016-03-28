(function () {
    'use strict';

    angular
        .module('app')
        .factory('EmployeesService', Service);

    function Service($http, $q) {
        var service = {};

        service.GetAll = GetAll;
        service.GetById = GetById;
        service.Create = Create;
        service.Update = Update;
        service.Delete = Delete;

        return service;

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
            return $q.reject(res.data);
        }
    }
})();