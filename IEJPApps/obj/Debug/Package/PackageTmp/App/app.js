(function () {
    "use strict";

    angular
        .module("app", ["ui.router", "ui.bootstrap", "pascalprecht.translate"])
        .config(config)
        .run(run);

    function config($stateProvider, $urlRouterProvider) {
        configStateProvider($stateProvider, $urlRouterProvider);
    }

    function configStateProvider($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise("/");

        $stateProvider
            .state("home", {
                url: "/",
                templateUrl: "/app/home/index.html",
                controller: "Home.IndexController",
                controllerAs: "vm",
                data: { activeTab: "home" }
            })

            .state("account", {
                url: "/account",
                templateUrl: "/app/account/index.html",
                controller: "Account.IndexController",
                controllerAs: "vm",
                data: { activeTab: "account" }
            })

            .state("projects", {
                url: "/projects",
                templateUrl: "/app/projects/index.html",
                controller: "Projects.IndexController",
                controllerAs: "vm",
                data: { activeTab: "projects" }
            })

            .state("projects-create", {
                url: "/projects/edit",
                templateUrl: "/app/projects/edit.html",
                controller: "Projects.EditController",
                controllerAs: "vm",
                data: { activeTab: "projects" }
            })

            .state("projects-edit", {
                url: "/projects/edit/:id",
                templateUrl: "/app/projects/edit.html",
                controller: "Projects.EditController",
                controllerAs: "vm",
                data: { activeTab: "projects" }
            })

            .state("employees", {
                url: "/employees",
                templateUrl: "/app/employees/index.html",
                controller: "Employees.IndexController",
                controllerAs: "vm",
                data: { activeTab: "employees" }
            })

            .state("employees-create", {
                url: "/employees/edit",
                templateUrl: "/app/employees/edit.html",
                controller: "Employees.EditController",
                controllerAs: "vm",
                data: { activeTab: "employees" }
            })

            .state("employees-edit", {
                url: "/employees/edit/:id",
                templateUrl: "/app/employees/edit.html",
                controller: "Employees.EditController",
                controllerAs: "vm",
                data: { activeTab: "employees" }
            });
    }

    function run($http, $rootScope, $window) {
        // add JWT token as default auth header
        $http.defaults.headers.common["Authorization"] = "Bearer " + $window.jwtToken;

        // update active tab on state change
        $rootScope.$on("$stateChangeSuccess", function (event, toState/*, toParams, fromState, fromParams*/) {
            $rootScope.activeTab = toState.data.activeTab;
        });
    }

    // manually bootstrap angular after the JWT token is retrieved from the server
    $(function () {
        // get JWT token from server
        $.get("/app/token", function (token) {
            window.jwtToken = token;

            angular.bootstrap(document, ['app']);
        });
    });
})();