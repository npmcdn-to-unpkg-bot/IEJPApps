(function () {
    "use strict";

    angular
        .module("app")
        .controller("TimeSheet.EditController", ["$state", "$stateParams", "$translate", "UserService", "TimeSheetService", "EmployeesService", "ProjectsService", "LookupService", controller])
        .config(config);

    function config($stateProvider) {
        $stateProvider
            .state("timesheet-create", {
                url: "/timesheet/edit",
                templateUrl: "/app/views/timesheet/timesheet-edit.html",
                controller: "TimeSheet.EditController",
                controllerAs: "vm",
                data: { activeTab: "timesheet" }
            })
            .state("timesheet-edit", {
                url: "/timesheet/edit/:id",
                templateUrl: "/app/views/timesheet/timesheet-edit.html",
                controller: "TimeSheet.EditController",
                controllerAs: "vm",
                data: { activeTab: "timesheet" }
            });
    }

    function controller($state, $stateParams, $translate, userService, timeSheetService, employeesService, projectsService, lookupService) {
        var vm = this;

        vm.currentPeriod = {};
        vm.employees = [];
        vm.days = [];
        vm.projects = [];
        vm.transaction = {};

        vm.save = function () {
            if (vm.transaction.Id) {
                timeSheetService.Update(vm.transaction);
            }
            else {
                timeSheetService.Create(vm.transaction).then(function (transaction) {
                    vm.transaction = transaction; // set new values
                });
            }
        }

        vm.delete = function () {
            if (vm.transaction.Id) {
                if (confirm($translate("ConfirmDelete"))) {
                    timeSheetService.Delete(vm.transaction.Id).then(function () {
                        $state.go("timesheet");
                    });
                }
            }
        }
        
        function init() {
            employeesService.GetAll().then(function (data) {
                vm.employees = data || [];
            });

            lookupService.getCurrentPeriod().then(function (currentPeriod) {
                vm.currentPeriod = currentPeriod || {};
            });

            projectsService.GetAll().then(function (projects) {
                vm.projects = projects || [];
            });

            if ($stateParams.id) {
                timeSheetService.GetById($stateParams.id).then(function(transaction) {
                    vm.transaction = transaction;
                    vm.transaction.TransactionDate = new Date(vm.transaction.TransactionDate || 'undefined');
                });
            } else {
                vm.transaction.TransactionDate = new Date();
            }            
        }

        init();
    }
})();