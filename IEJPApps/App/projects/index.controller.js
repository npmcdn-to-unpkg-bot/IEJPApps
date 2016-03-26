(function () {
    "use strict";

    angular
        .module("app")
        .controller("Projects.IndexController", ["$state", "$translate", "UserService", "ProjectsService", projectsIndexController]);

    function projectsIndexController($state, $translate, userService, projectsService) {
        var vm = this;

        vm.projects = [];

        vm.delete = function (projectId) {
            console.log('projectId', projectId);
            if (projectId) {
                if (confirm($translate("ConfirmDelete"))) {
                    projectsService.Delete(projectId).then(function () {
                        $state.reload();
                    });
                }
            }
        }

        initController();

        function initController() {
            projectsService.GetAll().then(function (projects) {
                vm.projects = projects;
            });
        }
    }
})();