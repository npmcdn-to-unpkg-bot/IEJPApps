(function () {
    "use strict";

    angular
        .module("app")
        .controller("TimeSheet.IndexController", ["$state", "$translate", "TimeSheetService", "PeriodsService", "LookupService", "ProjectsService", controller])
        .config(config);

    function config($stateProvider) {
        $stateProvider
            .state("timesheet", {
                url: "/timesheet",
                templateUrl: "/app/views/timesheet/timesheet-index.html",
                controller: "TimeSheet.IndexController",
                controllerAs: "vm",
                data: { activeTab: "timesheet" }
            });
    }

    function controller($state, $translate, timeSheetService, periodsService, lookupService, projectsService) {
        var vm = this;

        vm.transactions = [];
        vm.periods = [];
        vm.selectedPeriod = {};
        vm.projects = [];
        
        vm.delete = function(id) {
            if (id) {
                if (confirm($translate("ConfirmDelete"))) {
                    timeSheetService.Delete(id).then(function () {
                        $state.reload();
                    });
                }
            }
        }

        vm.add = function () {
            vm.transactions.push({
                TransactionDate: new Date()
            });
        }

        vm.timeTotal = function(transactions) {
            var sum = 0;
            for (var i = 0; i < transactions.length; i++) {
                sum += transactions[i].Time;
            }
            return sum;
        }

        function init() {
            timeSheetService.GetAll().then(function (transactions) {
                vm.transactions = transactions || [];
            });

            periodsService.getOpened().then(function (periods) {
                vm.periods = periods;

                vm.selectedPeriod = periodsService.getCurrentFromList(vm.periods) || vm.periods[0]; // defaults to first item
            });
        }

        init();
    }
})();