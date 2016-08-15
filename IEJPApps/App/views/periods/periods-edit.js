(function () {
    "use strict";

    angular
        .module("app")
        .controller("Periods.EditController", ["$state", "$stateParams", "$translate", "LookupService", "PeriodsService", controller])
        .config(config);

    function config($stateProvider) {
        $stateProvider
            .state("periods-create", {
                url: "/periods/edit",
                templateUrl: "/app/views/periods/periods-edit.html",
                controller: "Periods.EditController",
                controllerAs: "vm",
                data: { activeTab: "periods" }
            })
            .state("periods-edit", {
                url: "/periods/edit/:id",
                templateUrl: "/app/views/periods/periods-edit.html",
                controller: "Periods.EditController",
                controllerAs: "vm",
                data: { activeTab: "periods" }
            });
    }

    function controller($state, $stateParams, $translate, lookupService, periodsService) {
        var vm = this;

        vm.periods = [];
        vm.selectedPeriod = {};
        vm.period = periodsService.defaults();

        vm.selectedPeriodChanged = function () {
            console.log('vm.selectedPeriodChanged', vm.selectedPeriod);

            if (vm.selectedPeriod) {
                vm.period.StartDate = vm.selectedPeriod.StartDate;
                vm.period.EndDate = vm.selectedPeriod.EndDate;
            }

            console.log(vm.period);
        }

        vm.save = function () {
            if (vm.period.Id) {
                periodsService.update(vm.period);
            }
            else {
                periodsService.create(vm.period).then(function (period) {
                    vm.period = period; // set new values
                });
            }
        }

        vm.delete = function () {
            if (vm.period.Id) {
                if (confirm($translate("ConfirmDelete"))) {
                    periodsService.remove(vm.period.Id).then(function () {
                        $state.go("periods");
                    });
                }
            }
        }

        vm.state = function (period) {
            return periodsService.getState(period);
        }

        function init() {
            lookupService.getPeriodsList(5, 2).then(function (periods) {
                vm.periods = periods || [];
            });

            if ($stateParams.id) {
                periodsService.getById($stateParams.id).then(function(period) {
                    vm.period = period;
                    vm.period.OpenedDate = new Date(vm.period.OpenedDate || 'undefined');
                    vm.period.ClosedDate = new Date(vm.period.ClosedDate || 'undefined');
                    console.log(vm.period);
                });
            }
        }

        init();
    }
})();