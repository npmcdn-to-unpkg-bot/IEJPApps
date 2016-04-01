(function () {
    'use strict';

    angular
        .module('app')
        .controller('Home.IndexController', ["UserService", "user", controller])
        .config(config);

    function config($stateProvider) {
        $stateProvider
            .state("home", {
                url: "/",
                templateUrl: "/app/views/home/home-index.html",
                controller: "Home.IndexController",
                controllerAs: "vm",
                resolve: {
                    user: function ($stateParams, UserService) {
                        return {
                        };
                        //UserService.GetCurrent();
                    }
                },
                data: { activeTab: "home" }
            });
    }

    function controller(UserService, user) {
        var vm = this;

        vm.user = user;

        console.log('user', user);
    }
})();