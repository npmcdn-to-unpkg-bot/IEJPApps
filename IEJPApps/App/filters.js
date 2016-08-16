(function (module) {
    "use strict";

    angular.module("app")
        .filter('padzero', function () {
            return function(a,b){
                return(1e4+""+a).slice(-b);
            };
        })

        .filter('shortdate', function ($filter) {
            return function (date) {
                return $filter('date')(date, "yyyy-MM-dd");
            };
        })

        .filter('perioddescr', function ($filter) {
            return function (period) {
                return '[' + $filter('padzero')(period.WeekNumber, 2) + '] ' + $filter('shortdate')(period.StartDate) + ' - ' + $filter('shortdate')(period.EndDate);
            };
        });
})();