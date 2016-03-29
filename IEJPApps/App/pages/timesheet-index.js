(function () {
    "use strict";

    angular
        .module("app")
        .controller("TimeSheet.IndexController", ["$state", "$translate", "UserService", "TimeSheetService", controller])
        .config(config);

    function config($stateProvider) {
        $stateProvider
            .state("timesheet", {
                url: "/timesheet",
                templateUrl: "/app/pages/timesheet-index.html",
                controller: "TimeSheet.IndexController",
                controllerAs: "vm",
                data: { activeTab: "timesheet" }
            });
    }

    function controller($state, $translate, userService, timeSheetService) {
        var vm = this;

        vm.transactions = [];

        vm.delete = function (id) {
            if (id) {
                if (confirm($translate("ConfirmDelete"))) {
                    timeSheetService.Delete(id).then(function () {
                        $state.reload();
                    });
                }
            }
        }
        
        initController();

        function initController() {
            timeSheetService.GetAll().then(function (transactions) {
                vm.transactions = transactions;
            });
        }
    }
})();