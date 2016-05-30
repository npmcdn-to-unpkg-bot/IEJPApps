(function () {
    "use strict";

    angular
        .module("app")
        .controller("ExpenditureTypes.EditController", ["$state", "$stateParams", "$translate", "ExpenditureTypesService", controller])
        .config(config);

    function config($stateProvider) {
        $stateProvider
            .state("expenditure-types-create", {
                url: "/expenditures/types/edit",
                templateUrl: "/app/views/expenditures/expenditureTypes-edit.html",
                controller: "ExpenditureTypes.EditController",
                controllerAs: "vm",                
                data: { activeTab: "expenditure-types" }
            })
            .state("expenditure-types-edit", {
                url: "/expenditures/types/edit/:id",
                templateUrl: "/app/views/expenditures/expenditureTypes-edit.html",
                controller: "ExpenditureTypes.EditController",
                controllerAs: "vm",
                data: { activeTab: "expenditures" }
            });
    }

    function controller($state, $stateParams, $translate, expenditureTypesService) {
        var vm = this;

        vm.expenditureType = {};

        vm.save = function () {
            if (vm.expenditureType.Id) {
                expenditureTypesService.Update(vm.expenditureType);
            }
            else {
                expenditureTypesService.Create(vm.expenditureType).then(function (data) {
                    vm.expenditureType = data; // set new values
                });
            }
        }

        vm.delete = function () {
            if (vm.expenditureType.Id) {
                if (confirm($translate("ConfirmDelete"))) {
                    expenditureTypesService.Delete(vm.expenditureType.Id).then(function () {
                        $state.go("expenditure-types");
                    });
                }
            }
        }

        function init() {
            if ($stateParams.id) {
                expenditureTypesService.GetById($stateParams.id).then(function (data) {
                    vm.expenditureType = data;
                });
            }
        }

        init();
    }
})();