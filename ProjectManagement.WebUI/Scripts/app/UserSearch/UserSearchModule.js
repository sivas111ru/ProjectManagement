﻿var userSearchCtrl = function ($scope, SearchUsersService) {

    $scope.users = [];
    $scope.usersToAdd = [];
    $scope.usersToRemove = [];

    $scope.inputSearchFieldListener = function () {
        var search_str = $scope.searchInput;

        if (search_str.length > 2) {
            SearchUsersService.search(search_str).success(function (data) {
                $scope.users = data;
                console.log(data[0]);
            });
        }
    }

    $scope.userItemClick = function(itemIndex) {
        $scope.usersToAdd.push($scope.users[itemIndex]);
    }
}

var SearchUsersService = function ($http) {
    return {
        search: function(str) {
            return $http.post("/Api/SearchUsers/" + str);
        }
    };
}

angular
    .module("UserSearch", [])
    .factory("SearchUsersService", ["$http", SearchUsersService])
    .controller("userSearchCtrl", ["$scope", "SearchUsersService", userSearchCtrl]);