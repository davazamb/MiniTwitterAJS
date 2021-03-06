﻿(function () {
    'use strict';
    var app = angular.module('app', ["commonService","ngResource","ngRoute"]);
    app.config(function ($routeProvider) {
        $routeProvider
            .when('/loginpage', {
                template: '<login-page></login-page>'
            })
            .when('/newsfeedpage/:id', {
                template: '<news-feedpage></news-feedpage>'
            })
            .otherwise({ redirectTo: '/loginpage' })
        
    })
})();