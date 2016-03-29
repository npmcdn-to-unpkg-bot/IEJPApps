(function () {
    "use strict";

    angular
        .module("app")
        .controller("TimeSheet.EditController", ["$state", "$stateParams", "$translate", "UserService", "TimeSheetService", controller])
        .config(config);

    function config($stateProvider) {
        $stateProvider
            .state("timesheet-create", {
                url: "/timesheet/edit",
                templateUrl: "/app/pages/timesheet-edit.html",
                controller: "TimeSheet.EditController",
                controllerAs: "vm",
                data: { activeTab: "timesheet" }
            })

            .state("timesheet-edit", {
                url: "/timesheet/edit/:id",
                templateUrl: "/app/pages/timesheet-edit.html",
                controller: "TimeSheet.EditController",
                controllerAs: "vm",
                data: { activeTab: "timesheet" }
            });
    }

    function controller($state, $stateParams, $translate, userService, timeSheetService) {
        var vm = this;

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
                        $state.go("timesheets");
                    });
                }
            }
        }
        
        initController();

        function initController() {
            var id = $stateParams.id;
            if (id) {
                timeSheetService.GetById(id).then(function (transaction) {
                    vm.transaction = transaction;
                });
            }
        }
    }
})();