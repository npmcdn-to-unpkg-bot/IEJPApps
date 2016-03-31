(function () {
    "use strict";

    angular
        .module("app")
        .controller("Projects.IndexController", ["$state", "$translate", "UserService", "ProjectsService", "projects", controller])
        .config(config);

    function config($stateProvider) {
        $stateProvider
            .state("projects", {
                url: "/projects",
                templateUrl: "/app/projects/index.html",
                controller: "Projects.IndexController",
                controllerAs: "vm",
                resolve: {
                    projects: function ($stateParams, ProjectsService) {
                        return ProjectsService.GetAll();
                    }
                },
                data: { activeTab: "projects" }
            });
    }

    function controller($state, $translate, userService, projectsService, projects) {
        var vm = this;

        vm.projects = projects || [];

        vm.delete = function (id) {
            if (id) {
                if (confirm($translate("ConfirmDelete"))) {
                    projectsService.Delete(id).then(function () {
                        $state.reload();
                    });
                }
            }
        }
        
        vm.expenditureTotal = function () {
            var sum = 0;
            for (var i = 0; i < vm.projects.length; i++) {
                sum += vm.projects[i].ExpenditureTotal;
            }
            return sum;
        }

        vm.timeTotal = function () {
            var sum = 0;
            for (var i = 0; i < vm.projects.length; i++) {
                sum += vm.projects[i].TimeTotal;
            }
            return sum;
        }
    }
})();