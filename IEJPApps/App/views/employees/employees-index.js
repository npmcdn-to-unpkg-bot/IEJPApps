(function () {
    "use strict";

    angular
        .module("app")
        .controller("Employees.IndexController", ["$state", "$translate", "UserService", "EmployeesService", "employees", controller])
        .config(config);

    function config($stateProvider) {
        $stateProvider
            .state("employees", {
                url: "/employees",
                templateUrl: "/app/views/employees/employees-index.html",
                controller: "Employees.IndexController",
                controllerAs: "vm",
                resolve: {
                    employees: function ($stateParams, EmployeesService) {
                        return EmployeesService.GetAll();
                    }
                },
                data: { activeTab: "employees" }
            });
    }

    function controller($state, $translate, userService, employeesService, employees) {
        var vm = this;

        vm.employees = employees || [];

        vm.delete = function (id) {
            if (id) {
                if (confirm($translate("ConfirmDelete"))) {
                    employeesService.Delete(id).then(function () {
                        $state.reload();
                    });
                }
            }
        }
    }
})();