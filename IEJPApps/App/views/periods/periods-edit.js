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
        vm.period = {};

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

        function initPeriods() {
            lookupService.getPeriodsList(5, 5).then(function (periods) {
                vm.periods = periods || [];

                if (vm.periods.length) {
                    vm.period = vm.periods[0]; // defaults to first item
                    // voir si on a la periode courante, sinon, on garde la premiere periode...
                    for (var index = 0; index < vm.periods.length; index++) {
                        if (vm.periods[index].IsCurrent) {
                            vm.period = vm.periods[index];
                            break;
                        }
                    }
                    // set the start date to today for user friendlyness
                    if (!vm.period.OpenedDate) {
                        vm.period.OpenedDate = new Date();
                    }
                }
            });
        }

        function initPeriod(id) {
            periodsService.getById(id).then(function (period) {
                vm.period = period;
                vm.period.OpenedDate = new Date(vm.period.OpenedDate || undefined);
                vm.period.ClosedDate = new Date(vm.period.ClosedDate || undefined);
            });
        }

        function init() {
            if ($stateParams.id) {
                initPeriod($stateParams.id);
            } else {
                initPeriods();
            }
        }

        init();
    }
})();