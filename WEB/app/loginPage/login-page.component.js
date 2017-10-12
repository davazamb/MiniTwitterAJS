(function () {
    'use strict'
    var app = angular.module('app');
    app.component('loginPage', {
        templateUrl: 'app/loginPage/loginPage.html',
        controllerAs: 'vm',
        controller: ["$location",controller]
    });
    function controller($location) {
        var vm = this;
        vm.visit = function () {
            $location.path('newsfeedpage/' + 'visitor');
        }                                               
    }
})();