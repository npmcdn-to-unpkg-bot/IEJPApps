(function () {
    "use strict";

    angular
        .module("app")
        .controller("TimeSheet.IndexController", ["$state", "TimeSheetService", "LookupService", "transactions", "periods", "current", controller])
        .config(config);

    function config($stateProvider) {
        $stateProvider
            .state("timesheet", {
                url: "/timesheet",
                templateUrl: "/app/views/timesheet/timesheet-index.html",
                controller: "TimeSheet.IndexController",
                controllerAs: "vm",
                data: { activeTab: "timesheet" },
                resolve: {
                    transactions: function ($stateParams, TimeSheetService) {
                        return TimeSheetService.GetAll();
                    },
                    periods: function ($stateParams, LookupService) {
                        return LookupService.GetPeriodsList(15, 15);
                    },
                    current: function ($stateParams, LookupService) {
                        return LookupService.GetCurrentPeriod();
                    }
                }
            });
    }

    function controller($state, timeSheetService, lookupService, transactions, periods, current) {
        var vm = this;

        vm.transactions = transactions || [];
        vm.periods = periods || [];
        vm.currentPeriod = current || {};
        
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
    }
})();