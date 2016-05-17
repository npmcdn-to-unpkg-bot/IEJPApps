(function () {
    "use strict";

    angular
        .module("app")
        .controller("TimeSheet.IndexController", ["$state", "$translate", "TimeSheetService", "LookupService", controller])
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

    function init(vm, timeSheetService, lookupService) {
        timeSheetService.GetAll().then(function (transactions) {
            vm.transactions = transactions || [];
        });

        lookupService.getPeriodsList(15, 15).then(function (periods) {
            vm.periods = periods || [];
        });

        lookupService.getCurrentPeriod().then(function (currentPeriod) {
            vm.currentPeriod = currentPeriod || {};
        });
    }

    function controller($state, $translate, timeSheetService, lookupService) {
        var vm = this;

        vm.transactions = [];
        vm.periods = [];
        vm.currentPeriod = {};
        
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

            });
        }

        vm.timeTotal = function(transactions) {
            var sum = 0;
            for (var i = 0; i < transactions.length; i++) {
                sum += transactions[i].Time;
            }
            return sum;
        }

        init(vm, timeSheetService, lookupService);
    }
})();