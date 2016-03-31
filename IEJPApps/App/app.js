﻿(function () {
    "use strict";

    angular
        .module("app", [
            "ui.router",             
            "ui.bootstrap", 
            "pascalprecht.translate"])
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
            });
    }

    function run($http, $rootScope, $window) {
        // Add JWT token as default auth header
        $http.defaults.headers.common["Authorization"] = "Bearer " + $window.jwtToken;

        // update active tab on state change
        $rootScope.$on("$stateChangeSuccess", function (event, toState/*, toParams, fromState, fromParams*/) {
            $rootScope.activeTab = toState.data.activeTab || "";
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