(function () {
    'use strict'
    var app = angular.module('app');
    app.component('loginPage', {
        templateUrl: '/app/loginPage/loginPage.html',
        controllerAs: 'vm',
        controller: ["$http", "appSettings", "$location", controller]
    });
    function controller($http, appSettings, $location) {
        var vm = this;
        vm.login = function (data) {
            $http.get(appSettings.serverPath + 'users/' + data.username + '/' + data.password)
                .then(onSuccess, onError);
            function onSuccess(response) {
                $location.path('/newsfeedpage/' + response.data);

            };
            function onError(response) {
                alert(response.data.message)
            }
        }
        vm.visit = function () {
            $location.path('/newsfeedpage/' + 'visitor');
        }
    }
})();