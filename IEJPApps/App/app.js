(function () {
    "use strict";

    var app = angular
        .module("app", [
            "toastr",
            "ui.router",
            "ui.bootstrap",
            "ngCookies",
            "pascalprecht.translate"])
        .config(config)
        .run(run)

        .filter('padzero', function () {
            return function(a,b){
                return(1e4+""+a).slice(-b);
            };
        });

    function config($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise("/");

        $stateProvider
            .state("account", {
                url: "/account",
                templateUrl: "/app/views/account/index.html",
                controller: "Account.IndexController",
                controllerAs: "vm",
                data: { activeTab: "account" }
            });
    }

    function run($http, $rootScope, $window, environment) {
        $rootScope.environment = environment;
        console.log('environment', environment);

        $rootScope.toJson = function(o) {
            return angular.toJson(o, true);
        }

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