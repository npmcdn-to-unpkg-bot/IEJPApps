(function () {
    "use strict";

    angular
        .module("app")
        .controller("Expenditures.EditController", ["$state", "$stateParams", "$translate" ,"UserService", "ExpendituresService", controller])
        .config(config);

    function config($stateProvider) {
        $stateProvider
            .state("expenditures-create", {
                url: "/expenditures/edit",
                templateUrl: "/app/pages/expenditures-edit.html",
                controller: "Expenditures.EditController",
                controllerAs: "vm",
                data: { activeTab: "expenditures" }
            })

            .state("expenditures-edit", {
                url: "/expenditures/edit/:id",
                templateUrl: "/app/pages/expenditures-edit.html",
                controller: "Expenditures.EditController",
                controllerAs: "vm",
                data: { activeTab: "expenditures" }
            });
    }

    function controller($state, $stateParams, $translate, userService, expendituresService) {
        var vm = this;

        vm.transaction = {};

        vm.save = function () {
            if (vm.transaction.Id) {
                expendituresService.Update(vm.transaction);
            }
            else {
                expendituresService.Create(vm.transaction).then(function (transaction) {
                    vm.transaction = transaction; // set new values
                });
            }
        }

        vm.delete = function () {
            if (vm.transaction.Id) {
                if (confirm($translate("ConfirmDelete"))) {
                    expendituresService.Delete(vm.transaction.Id).then(function () {
                        $state.go("expenditures");
                    });
                }
            }
        }

        initController();

        function initController() {
            var id = $stateParams.id;
            if (id) {
                expendituresService.GetById(id).then(function (transaction) {
                    vm.transaction = transaction;
                });
            }
        }
    }
})();