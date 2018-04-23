// Define the `phonecatApp` module
var imsApp = angular.module('imsApp', []);

// Define the `PhoneListController` controller on the `phonecatApp` module
imsApp.controller('CategoryListController', function CategoryListController($scope, $http) {

    $scope.Init = function () {

        $http({
            method: "GET",
            url: "http://localhost:49826/" + "api/Category2/get/"
        }).then(function (response) {
            alert('suc');
            $scope.Categories = response.data;
        }, function (response) {
            alert('error');
        });

    };
    $scope.Categories = [
        {
            ID: 1,
            Name: 'Nexus S 1'
        }, {
            ID: 2,
            Name: 'Nexus S 2'
        }, {
            ID: 3,
            Name: 'Nexus S 3'
        }
    ];
});