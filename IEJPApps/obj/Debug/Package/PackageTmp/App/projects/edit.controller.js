(function () {
    "use strict";

    angular
        .module("app")
        .controller("Projects.EditController", ["$state", "$stateParams", "$translate" ,"UserService", "ProjectsService", projectsEditController]);

    function projectsEditController($state, $stateParams, $translate, userService, projectsService) {
        var vm = this;

        vm.project = {};

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

        initController();

        function initController() {
            var id = $stateParams.id;
            if (id) {
                projectsService.GetById(id).then(function (project) {
                    vm.project = project;
                });
            }
        }
    }
})();