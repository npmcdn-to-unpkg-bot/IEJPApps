(function () {
    "use strict";

    angular
        .module("app")
        .controller("ExpenditureTypes.IndexController", ["$state", "$translate", "ExpenditureTypesService", controller])
        .config(config);

    function config($stateProvider) {
        $stateProvider
            .state("expenditure-types", {
                url: "/expenditures/types",
                templateUrl: "/app/views/expenditures/expenditureTypes-index.html",
                controller: "ExpenditureTypes.IndexController",
                controllerAs: "vm",
                data: { activeTab: "expenditure-types" }
            });
    }

    function controller($state, $translate, expenditureTypesService) {
        var vm = this;

        vm.expenditureTypes = [];

        vm.delete = function (id) {
            if (id) {
                if (confirm($translate("ConfirmDelete"))) {
                    expenditureTypesService.Delete(id).then(function () {
                        $state.reload();
                    });
                }
            }
        }
     
        function init() {
            expenditureTypesService.GetAll().then(function (data) {
                vm.expenditureTypes = data;
            });
        }
        
        init();
    }
})();