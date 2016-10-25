var app = angular.module("FetchNStore", []);
app.controller("callCtrl", function ($scope, $http, $document) {
    var url = $document.find("#urlInput").val();
    $scope.initiateRequest = () => {
        var startTime = Date.now();
        var methodOfChoice = "GET";
        $http({
            method: methodOfChoice,
            url: url
        }).then(function successCallback(response) {
            console.log(response);
            $scope.statusCode = response.status;
            $scope.statusText = response.statusText;
            $scope.responseTime = Date.now() - startTime;
            console.log(startTime);
        }, function errorCallback(response) {
            console.log(response);
        });
    }
});