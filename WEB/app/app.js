(function () {
    'use strict';
    var app = angular.module('app', ['ngRoute']);
    app.config(function ($routeProvider) {
        $routeProvider
            .when('/loginpage', {
                template: '<login-page></login-page>'
            })
            .when('/newsfeedpage', {
                template: '<news-feedpage></news-feedpage>'
            })
            .otherwise({redirecto:'/login'})   
    })
})();