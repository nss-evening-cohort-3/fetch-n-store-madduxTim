var app = angular.module("FetchNStore", []);
app.controller("callCtrl", function ($scope, $http, $document) {
    var url = document.getElementById("urlInput").innerHTML;
    $scope.responseObject = {
        StatusCode: "",
        URL: "",
        HTTP_Method: "",
        ResponseTime: ""
    };

    $scope.httpOptions = {
        availableOptions: [
        { id: "1", name: "---Pick one---" },
        { id: "2", name: "GET" },
        { id: "3", name: "HEAD" }
        ],
        selectedOption: { id: "1", name: "---Pick one---" }
    };

    $scope.storeResponse = () => {
        console.log($scope.responseObject);
        $http.post('/api/Response', $scope.responseObject);

    };

    $scope.showAll = () => {
        console.log(JSON.stringify($scope.responseObject));
        console.log($scope.responseObject);
    };

    $scope.initiateRequest = () => {
        var startTime = Date.now();
        $http({
            method: $scope.httpOptions.selectedOption.name,
            url: url
        }).then(function successCallback(response) {      
            //$document.find("#error_display").html("");
            console.log(response);
            //$scope.url = $document.find("#urlInput").val();
            //$scope.url = document.getElementById("urlInput").innerHTML;
            //$scope.methodUsed = $scope.httpOptions.selectedOption.name;
            //$scope.statusCode = response.status;
            //$scope.statusText = response.statusText;
            //$scope.responseTime = parseInt(`${Date.now() - startTime} ms`);
            $scope.responseObject["URL"] = $document.find("#urlInput").val();
            $scope.responseObject["StatusCode"] = response.status.toString();
            $scope.responseObject["HTTP_Method"] = $scope.httpOptions.selectedOption.name;
            $scope.responseObject["ResponseTime"] = parseInt(`${Date.now() - startTime} ms`);
            console.log($scope.responseObject);
        }, function errorCallback(response) {
            //document.getElementById("#error_display").innerHTML =
            //    `<p>Ooops, there was the following error: </p><p>${response}</p>`;
            console.log(response);
        });
    }
});
//INTERESTING... NEVER GOT THIS WORKING. LEANED ON NG $HTTP SHORTCUT METHODS
    //    $http({
    //        url: "/api/Response/",
    //        method : "POST",
    //        //data: JSON.stringify($scope.responseObject)
    //        data: {name:"blah"}
    //    }).then(function successCallback(response) {
    //        console.log(response);
    //    }, function errorCallback(response) {
    //        console.log(reponse);
    //    });
    //};