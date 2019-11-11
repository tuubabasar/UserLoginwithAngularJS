(function () {
    'use strict'
    var app = angular.module('app',["ngRoute"]);
    app.component('loginPage', {
        templateUrl: 'app/loginPage/loginPage.html',
        controllerAs: 'vm',
        controller: ["$http","appSettings","$location",controller]
    });

    app.controller('userInformation', function ($scope, data) {
        $scope.username = data.username;
        $scope.LastLoginTime = data.LastLoginTime;
        $scope.State = data.State;
        $scope.LastUpdateDate = data.LastUpdateDate;
        $scope.RecordState = data.RecordState;
        $scope.UserInformation = function () {
            return "Sayın" + $scope.username + "\nen son " + $scope.LastLoginTime + "tarihinde" + "\naktif oldunuz." + "\n Kullanıcı durumunuz: " + $scope.State + "\nson işlem tarihiniz" + $scope.LastUpdateDate + "\nKayıt durumunuz:" +$scope.RecordState;
        };
    });
    
    function controller($http,appsettings,$location) {
        var vm = this;

        vm.login = function (data) {
            $http.get(appsettings.serverPath + 'users/' + data.username + '/' + data.password + '/' + data.LastLoginTime + '/' + data.State + '/' + data.LastUpdateDate + '/' + data.RecordState).then(onSuccess, onError);
            
            function onSuccess(response) {
                $location.path('/homePage/' + response.data);
                alert($scope.UserInformation);
            };

            function onError(response) {
                alert(response.data.message);
                alert($scope.UserInformation);
            }
        }
    }
})