(function () {
    "use strict";

    angular
        .module("app")
        .controller("Expenditures.EditController", ["$state", "$stateParams", "$translate", "UserService", "ProjectsService", "EmployeesService", "ExpenditureTypesService", "ExpendituresService", controller])
        .config(config);

    function config($stateProvider) {
        $stateProvider
            .state("expenditures-create", {
                url: "/expenditures/edit",
                templateUrl: "/app/views/expenditures/expenditures-edit.html",
                controller: "Expenditures.EditController",
                controllerAs: "vm",                
                data: { activeTab: "expenditures" }
            })
            .state("expenditures-edit", {
                url: "/expenditures/edit/:id",
                templateUrl: "/app/views/expenditures/expenditures-edit.html",
                controller: "Expenditures.EditController",
                controllerAs: "vm",
                data: { activeTab: "expenditures" }
            });
    }

    function controller($state, $stateParams, $translate, userService, projectsService, employeesService, expenditureTypesService, expendituresService) {
        var vm = this;

        vm.employees = [];
        vm.projects = [];
        vm.expenditureTypes = [];

        vm.transaction = {
            TransactionDate: new Date()
        };

        vm.dateFormat = "yyyy-MM-dd";

        vm.save = function () {
            if (vm.transaction.Id) {
                expendituresService.Update(vm.transaction);
            }
            else {
                console.log('create', vm.transaction);
                expendituresService.Create(vm.transaction).then(function (data) {
                    vm.transaction = data; // set new values
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

        function init() {
            employeesService.GetAll().then(function (data) {
                vm.employees = data || [];
            });

            projectsService.GetAll().then(function (data) {
                vm.projects = data || [];
            });

            expenditureTypesService.GetAll().then(function (data) {
                vm.expenditureTypes = data || [];
            });
            
            if ($stateParams.id) {
                expendituresService.GetById($stateParams.id).then(function (data) {
                    vm.transaction = data;
                });
            }
        }

        init();
    }
})();