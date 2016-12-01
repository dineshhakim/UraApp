﻿define(['app'], function (app) {
    //defining service using factory method
    app.factory('userService', function ($http, utility) {
        var serviceurl = utility.baseAddress + "User/";
        return {
            getUsersList: function () {
                var url = serviceurl;
                return $http.get(url);
            },
            getUser: function (user) {
                var url = serviceurl + user.id;
                return $http.get(url);
            },
            addUser: function (user) {
                var url = serviceurl + "AddUser";
                return $http.post(url, user);
            },
            deleteUser: function (user) {
                var url = serviceurl + "DeleteUser/" + user.id;
                return $http.delete(url);
            },
            updateUser: function (user) {
                var url = serviceurl + user.id;
                return $http.put(url, user);
            }
        };
    });
});