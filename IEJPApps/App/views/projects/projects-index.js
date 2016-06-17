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
                templateUrl: "/app/views/projects/projects-index.html",
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
        
        vm.expenditureTotal = function (projects) {
            var sum = 0;
            for (var i = 0; i < projects.length; i++) {
                sum += projects[i].ExpenditureTotal;
            }
            return sum;
        }

        vm.timeTotal = function (projects) {
            var sum = 0;
            for (var i = 0; i < projects.length; i++) {
                sum += projects[i].TimeTotal;
            }
            return sum;
        }
    }
})();