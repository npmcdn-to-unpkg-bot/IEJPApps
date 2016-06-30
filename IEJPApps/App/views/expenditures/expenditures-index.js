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
        
        vm.total = function(transactions) {
            var sum = 0;
            for (var i = 0; i < transactions.length; i++) {
                sum += (transactions[i].Amount || 0);
            }
            return sum;
        }

        function init() {
            expendituresService.GetAll().then(function (transactions) {
                vm.transactions = transactions;
            });
        }
        
        init();
    }
})();