var app = angular.module("FetchNStore", []);
app.controller("callCtrl", function ($scope, $http, $document) {
    var url = $document.find("#urlInput").val();
    $scope.initiateRequest = () => {
        //$http.get("http://httpstat.us/201")
        $http.get(url)
        .then(function (response) {
            //$scope.content = response.data;
            console.log(response);
            console.log(response.data);
            $scope.statusCode = response.status;
            $scope.statusText = response.statusText;
            $scope.responseTime = Date.now();
        });
    }
});