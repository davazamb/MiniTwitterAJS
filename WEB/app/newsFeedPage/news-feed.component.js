(function () {
    'use strict'
    var app = angular.module('app');
    app.component('newsFeedPage', {
        templateUrl: 'app/newsFeedPage/newsFeedPage.html',
        controllerAs: 'vm',
        controller: [controller]
    });
    function controller() {

    }
})();