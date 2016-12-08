//For JWT token
 
function authInterceptor(API, auth) {
    return {
        // automatically attach Authorization header
        request: function (config) {
            var token = auth.getToken();
            if (config.url.indexOf(API) === 0 && token) {
                config.headers.Authorization = 'Bearer ' + token;
            }
            return config;
        },

        response: function (res) {
            if (res.config.url.indexOf(API) === 0 && res.data.token) {
                auth.saveToken(res.data.token);
            }

            return res;
        },
    }
}

function authService($window) {
    var srvc = this;

    srvc.parseJwt = function (token) {
        var base64Url = token.split('.')[1];
        var base64 = base64Url.replace('-', '+').replace('_', '/');
        return JSON.parse($window.atob(base64));
    };

    srvc.saveToken = function (token) {
        $window.localStorage['jwtToken'] = token
    };

    srvc.logout = function (token) {
        $window.localStorage.removeItem('jwtToken');
    };

    srvc.getToken = function () {
        return $window.localStorage['jwtToken'];
    };

    srvc.isAuthed = function () {
        var token = srvc.getToken();
        if (token) {
            var params = srvc.parseJwt(token);
            return Math.round(new Date().getTime() / 1000) <= params.exp;
        } else {
            return false;
        }
    }

}

function userTokenService($http, API, auth) {
    var srvc = this;
    srvc.getQuote = function () {
        return $http.get(API + '/auth/quote')
    }
    srvc.register = function (username, password) {
        return $http.post(API + '/auth/register', {
            username: username,
            password: password
        });
    };

    srvc.login = function (username1, password1) {
        var data1 = 'username=' + username1 + '&password=' + password1;
        var req = {
            method: 'POST',
            url: API + '/token',
            headers: {
                'Content-Type': undefined
            },
            data: data1
        }
        return $http.post(req);
    };

};

define(['ui-router', 'ngStorage', 'ngCookies'], function () {

    //defining angularjs module
    var app = angular.module("app", ['ui.router', 'ngCookies', 'ngStorage']);

    //global service
    app.constant("utility",
        {
            baseAddress: "http://localhost:51725/api/"
        });

    //manual bootstrap
    app.init = function () {
        angular.bootstrap(document, ['app']);
    };

    //defining routes
    app.config(function ($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise("/");

        $stateProvider
            .state("home", {
                url: "/",
                templateUrl: 'views/home/home.html',
                controller: 'homeCtrl'
            })
        .state("about", {
            url: "/about",
            templateUrl: 'views/account/about.html',
            controller: 'aboutCtrl'
        })
         .state("login", {
             url: "/login",
             templateUrl: 'views/login.html',
             controller: 'userCtrl'
         })

        ;
    });

    app.factory('authInterceptor', authInterceptor)
    .service('user', userService)
    .service('auth', authService)
    .constant('API', 'http://localhost:51725/api/')
    .config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    })
    return app;
});



