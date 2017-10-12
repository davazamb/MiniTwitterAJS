(function () {
    'use strict'
    angu.module('commonService', ['ngResource'].constant('appSettings',
        {
            serverPath: 'http://localhost:56395/api/'
        })
})();