(function () {
    "use strict";

    angular
        .module("app")
        .controller("Projects.EditController", ["$state", "$stateParams", "$translate", "UserService", "ProjectsService", "project", controller])
        .config(config);

    function config($stateProvider) {
        $stateProvider
            .state("projects-create", {
                url: "/projects/edit",
                templateUrl: "/app/projects/edit.html",
                controller: "Projects.EditController",
                controllerAs: "vm",
                resolve: {
                    project: function ($stateParams, ProjectsService) {
                        return ProjectsService.New();
                    }
                },
                data: { activeTab: "projects" }
            })
            .state("projects-edit", {
                url: "/projects/edit/:id",
                templateUrl: "/app/projects/edit.html",
                controller: "Projects.EditController",
                controllerAs: "vm",
                resolve: {
                    project: function ($stateParams, ProjectsService) {
                        return ProjectsService.GetById($stateParams.id);
                    }
                },
                data: { activeTab: "projects" }
            });
    }

    function controller($state, $stateParams, $translate, userService, projectsService, project) {
        var vm = this;

        vm.project = project || {};

        vm.save = function () {
            if (vm.project.Id) {
                projectsService.Update(vm.project);
            }
            else {
                projectsService.Create(vm.project).then(function (project) {
                    vm.project = project; // set new values
                });
            }
        }

        vm.delete = function () {
            if (vm.project.Id) {
                if (confirm($translate("ConfirmDelete"))) {
                    projectsService.Delete(vm.project.Id).then(function () {
                        $state.go("projects");
                    });
                }
            }
        }
    }
})();