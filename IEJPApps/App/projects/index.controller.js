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

        initController();

        function initController() {
            projectsService.GetAll().then(function (projects) {
                vm.projects = projects;
            });
        }
    }
})();