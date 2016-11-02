var app = angular.module("FetchNStore", []);
app.controller("callCtrl", function ($scope, $http, $document) {
    var url = $document.find("#urlInput").val();
    $scope.data = {
        availableOptions: [
        { id: "1", name: "---Pick one---" },
        { id: "2", name: "GET" },
        { id: "3", name: "HEAD" }
        ],
        selectedOption: { id: "1", name: "---Pick one---" }
    };

    //$scope.storeResponse = () => {
    //    $scope.
    //}

    //$scope.showAll = () => {
    //    $scope.
    //}

    $scope.initiateRequest = () => {
        var startTime = Date.now();
        $http({
            //method: "GET",
            //method: $scope.data.toString(),
            method: $scope.data.selectedOption.name,
            url: url
        }).then(function successCallback(response) {
            $document.find("#error_display").html("");
            console.log(response);
            $scope.url = $document.find("#urlInput").val();
            //console.log($scope.data.selectedOption.name);
            //$scope.methodUsed = $scope.data.toString();
            //console.log($scope.data.toString());
            //console.log(JSON.stringify($scope.data));
            $scope.methodUsed = $scope.data.selectedOption.name;
            $scope.statusCode = response.status;
            $scope.statusText = response.statusText;
            $scope.responseTime = `${Date.now() - startTime} ms`;         
        }, function errorCallback(response) {
            $document.find("#error_display").html(
                `<p>Ooops, there was the following error: </p><p>${response}</p>`
                );
            console.log(response);
            
        });
    }
});