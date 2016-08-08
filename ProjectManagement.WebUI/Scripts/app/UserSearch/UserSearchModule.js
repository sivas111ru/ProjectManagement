var userSearchCtrl = function ($scope, UsersService) {
    $scope.users = [];
    $scope.foundUsers = [];
    $scope.usersToAdd = [];
    $scope.usersToRemove = [];

    $scope.init = function (task_id) {
        $scope.taskId = task_id;

        UsersService.getUsersOnTask(task_id).success(function(data) {
            $scope.users = data;
        });
    }

    $scope.inputSearchFieldListener = function () {
        var search_str = $scope.searchInput;

        if (search_str.length > 2) {
            UsersService.search(search_str).success(function (data) {
                $scope.foundUsers = data;
                console.log(data[0]);
            });
        }
    }

    $scope.userItemClick = function (itemIndex) {
        var user = $scope.foundUsers[itemIndex];

        $scope.usersToAdd.push(user);
        $scope.users.push(user);
    }
}

var UsersService = function ($http) {
    return {
        search: function(str) {
            return $http.post("/Api/SearchUsers/" + str);
        },
        getUsersOnTask: function(task_id) {
            return $http.post("/Api/GetUsersOnTask/" + task_id);
        }
    };
}

angular
    .module("UserSearch", [])
    .factory("UsersService", ["$http", UsersService])
    .controller("userSearchCtrl", ["$scope", "UsersService", userSearchCtrl]);