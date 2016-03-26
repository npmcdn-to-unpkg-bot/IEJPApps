(function () {
    "use strict";

    angular
        .module("app")
        .controller("Employees.IndexController", ["$state", "$translate", "UserService", "EmployeesService", employeesIndexController]);

    function employeesIndexController($state, $translate, userService, employeesService) {
        var vm = this;

        vm.employees = [];

        vm.delete = function (employeeId) {
            if (employeeId) {
                if (confirm($translate("ConfirmDelete"))) {
                    employeesService.Delete(employeeId).then(function () {
                        $state.reload();
                    });
                }
            }
        }

        initController();

        function initController() {
            employeesService.GetAll().then(function (employees) {
                vm.employees = employees;
            });
        }
    }
})();