(function () {
    'use strict'
    var app = angular.module('app');
    app.component('newsFeedpage', {
        templateUrl: '/app/newsFeedpage/newsFeedpage.html',
        controllerAs: 'vm',
        controller: [controller]
    });
    function controller() {

    }
})();