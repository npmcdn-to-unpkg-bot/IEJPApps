(function () {
    "use strict";

    angular
        .module("app")
        .controller("Periods.IndexController", ["$state", "$translate", "PeriodsService", controller])
        .config(config);

    function config($stateProvider) {
        $stateProvider
            .state("periods", {
                url: "/periods",
                templateUrl: "/app/views/periods/periods-index.html",
                controller: "Periods.IndexController",
                controllerAs: "vm",
                data: { activeTab: "periods" }
            });
    }

    function controller($state, $translate, periodsService) {
        var vm = this;

        vm.periods = [];

        vm.delete = function (id) {
            if (id) {
                if (confirm($translate("ConfirmDelete"))) {
                    periodsService.remove(id).then(function () {
                        $state.reload();
                    });
                }
            }
        }

        function init() {
            periodsService.getAll().then(function (periods) {
                vm.periods = periods;
            });
        }

        init();
    }
})();