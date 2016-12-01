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
        });
    });
    return app;
});