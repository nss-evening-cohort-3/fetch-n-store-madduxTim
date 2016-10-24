var app = angular.module("FetchNStore", []);
app.controller('callCtrl', function ($scope, $http) {
    var url = "http://httpstat.us/201";
    $scope.makeCall = () => {
        $http.get(url)
        .then(function (response) {
            $scope.content = response.data;
            $scope.statuscode = response.status;
            $scope.statustext = response.statusText;
            console.log(response);
            //$scope.timeElapsed = response.blah;
        });
    }
});