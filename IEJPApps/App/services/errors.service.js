(function () {
    'use strict';

    angular.module('app').factory('ErrorService', Service);

    Service.$inject = ['$translate', 'toastr'];

    function Service($translate, toastr) {
        return {            
           error: error        
        };
        
        function error(message, caption) {
            message = message || "Errors.ErrorOccuredCancelled";
            caption = caption || "Errors.Error";
            
            toastr.error($translate(message), $translate(caption), {
                closeButton: true,
                positionClass: 'toast-bottom-right',
            });
        }
    }
})();