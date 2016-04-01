(function () {
    "use strict";

    angular
        .module("app")
        .controller("Employees.EditController", ["$state", "$stateParams", "$translate", "UserService", "EmployeesService", "employee", controller])
        .config(config);

    function config($stateProvider) {
        $stateProvider
            .state("employees-create", {
                url: "/employees/edit",
                templateUrl: "/app/views/employees/employees-edit.html",
                controller: "Employees.EditController",
                controllerAs: "vm",
                resolve: {
                    employee: function ($stateParams, EmployeesService) {
                        return EmployeesService.New();
                    }
                },
                data: { activeTab: "employees" }
            })
            .state("employees-edit", {
                url: "/employees/edit/:id",
                templateUrl: "/app/views/employees/employees-edit.html",
                controller: "Employees.EditController",
                controllerAs: "vm",
                resolve: {
                    employee: function ($stateParams, EmployeesService) {
                        return EmployeesService.GetById($stateParams.id);
                    }
                },
                data: { activeTab: "employees" }
            });
    }

    function controller($state, $stateParams, $translate, userService, employeesService, employee) {
        var vm = this;

        vm.employee = employee || {};

        vm.save = function () {
            if (vm.employee.Id) {
                employeesService.Update(vm.employee);
            }
            else {
                employeesService.Create(vm.employee).then(function (employee) {
                    vm.employee = employee; // set new values
                });
            }
        }

        vm.delete = function () {
            if (vm.employee.Id) {
                if (confirm($translate("ConfirmDelete"))) {
                    employeesService.Delete(vm.employee.Id).then(function () {
                        $state.go("employees");
                    });
                }
            }
        }
    }
})();