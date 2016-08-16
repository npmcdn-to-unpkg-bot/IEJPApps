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
        .run(run);

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

    function run($http, $rootScope, $window, environment, $cookies, $translate) {
        $rootScope.environment = environment || {};
        //console.log('environment', environment);

        if (environment) {
            // set current user language
            $translate.uses(environment.language);
        }

        $rootScope.toJson = function(o) {
            return angular.toJson(o, true);
        }

        //$rootScope

        // Add JWT token as default auth header
        if ($window.jwtToken) {
            $http.defaults.headers.common["Authorization"] = "Bearer " + $window.jwtToken;
        }

        // update active tab on state change
        $rootScope.$on("$stateChangeSuccess", function (event, toState/*, toParams, fromState, fromParams*/) {
            $rootScope.activeTab = toState.data.activeTab || "";
        });
    }

    // manually bootstrap angular after the JWT token is retrieved from the server
    $(function () {
        // get JWT token from server
        //$.get("/api/token", function (token) {
        //    window.jwtToken = token;

        //    angular.bootstrap(document, ['app']);
        //});

        // Quick fix for when we click a link in menu... was not closing menu bar
        $(document).on('click', '.navbar-collapse.in', function (e) {
            if ($(e.target).is('a') && $(e.target).attr('class') !== 'dropdown-toggle') {
                $(this).collapse('hide');
            }
        });
    });
})();