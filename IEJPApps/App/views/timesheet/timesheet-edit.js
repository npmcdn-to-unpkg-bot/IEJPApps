(function () {
    "use strict";

    angular
        .module("app")
        .controller("TimeSheet.EditController", ["$state", "$stateParams", "$translate", "UserService", "TimeSheetService", "ProjectsService", controller])
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

    function controller($state, $stateParams, $translate, userService, timeSheetService, projectsService) {
        var vm = this;

        vm.transaction = {};
        vm.projects = [];

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
                        $state.go("timesheets");
                    });
                }
            }
        }
        
        function init() {
            if ($stateParams.id) {
                timeSheetService.GetById($stateParams.id).then(function (transaction) {
                    vm.transaction = transaction;
                });
            }
            
            projectsService.GetAll().then(function (projects) {
                vm.projects = projects || [];
            });
        }

        init();
    }
})();