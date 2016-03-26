(function () {
    "use strict";

    angular
        .module("app")
        .controller("Employees.EditController", ["$state", "$stateParams", "$translate", "UserService", "EmployeesService", employeesEditController]);

    function employeesEditController($state, $stateParams, $translate, userService, employeesService) {
        var vm = this;

        vm.employee = {};

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

        initController();

        function initController() {
            var id = $stateParams.id;
            if (id) {
                employeesService.GetById(id).then(function (employee) {
                    vm.employee = employee;
                });
            }
        }
    }
})();