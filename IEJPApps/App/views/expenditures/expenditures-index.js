(function () {
    "use strict";

    angular
        .module("app")
        .controller("Expenditures.IndexController", ["$state", "$translate", "UserService", "ExpendituresService", controller])
        .config(config);

    function config($stateProvider) {
        $stateProvider
            .state("expenditures", {
                url: "/expenditures",
                templateUrl: "/app/views/expenditures/expenditures-index.html",
                controller: "Expenditures.IndexController",
                controllerAs: "vm",
                data: { activeTab: "expenditures" }
            });
    }

    function controller($state, $translate, userService, expendituresService) {
        var vm = this;

        vm.transactions = [];

        vm.delete = function (id) {
            if (id) {
                if (confirm($translate("ConfirmDelete"))) {
                    expendituresService.Delete(id).then(function () {
                        $state.reload();
                    });
                }
            }
        }
        
        initController();

        function initController() {
            expendituresService.GetAll().then(function (transactions) {
                vm.transactions = transactions;
            });
        }
    }
})();