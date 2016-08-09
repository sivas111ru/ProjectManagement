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
                console.log(data);
            });
        }
    }

    $scope.userItemClick = function (itemIndex) {
        var user = $scope.foundUsers[itemIndex];

        $scope.searchInput = "";

        var users = $scope.users;
        var i = users.length;
        
        while (i--) {
            if (users[i].Id === user.Id) {
                return;
            }
        }

        $scope.usersToAdd.push(user);
        $scope.users.push(user);
    }

    $scope.looseFocus = function () {
        var usersFound = $scope.foundUsers;
        while (usersFound.length) {
            usersFound.pop();
        }
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
    .module("UserSearch", ["ngSanitize"])
    .factory("UsersService", ["$http", UsersService])
    .filter('searchfilter', function() {
        return function(input, query) {
            return input.replace(RegExp('(' + query + ')', 'gi'), '<span class="regexp-found">$1</span>');
        }
    })
    .controller("userSearchCtrl", ["$scope", "UsersService", userSearchCtrl]);