(function (module) {
    "use strict";

    angular.module("app")
        .directive('optionsClass', function ($parse, filterFilter) {
            return {
                require: 'select',
                link: function (scope, elem, attrs, ngSelect) {
                    var optionsSourceStr = attrs.ngOptions.split(' ').pop(); // bug if using track by...
                    var getOptionsClass = $parse(attrs.optionsClass);

                    scope.$watchCollection(optionsSourceStr, function (items) {
                        scope.$$postDigest(function() {
                            angular.forEach(items, function(item, index) {
                                var classes = getOptionsClass(item);

                                angular.forEach(classes, function(add, className) {
                                    if (add) {
                                        var option = elem.find('option[value=\'' + item.$$hashKey + '\']');

                                        angular.element(option).addClass(className);
                                    }
                                });
                            });
                        });
                    });
                }
            };
        });
})();