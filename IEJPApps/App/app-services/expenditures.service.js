(function () {
    'use strict';

    angular
        .module('app')
        .factory('ExpendituresService', Service);

    function Service($http, $q) {
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
            return $http.get('/api/expenditures').then(handleSuccess, handleError);
        }

        function GetById(_id) {
            return $http.get('/api/expenditures/' + _id).then(handleSuccess, handleError);
        }

        function Create(project) {
            return $http.post('/api/expenditures', project).then(handleSuccess, handleError);
        }

        function Update(project) {
            return $http.put('/api/expenditures/', project).then(handleSuccess, handleError);
        }

        function Delete(_id) {
            return $http.delete('/api/expenditures/' + _id).then(handleSuccess, handleError);
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
