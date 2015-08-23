/* File Created: August 13, 2015 */
//home-index
(function () {
    var appObj = angular.module("homeIndex", []);

    appObj.config(function ($routeProvider) {
        $routeProvider.when("/", {
            controller: "topicsController",
            templateUrl: "/templates/topicsView.html"
        });

        $routeProvider.when("/newmessage", {
            controller: "newTopicController",
            templateUrl: "/templates/newTopicView.html"
        });

        $routeProvider.otherwise({ redirect: "/" });
    });

    //In this mechanism, when a new data is added, the user is redirected to the topicsController which again calls the get API
    //from the server and updates the page. This process will be costly from bandwidth perspective as there will be many round-trip
    //to the server side so in order to avoid that we have to do services.
    var topicsController = function ($scope, $http) {
        $scope.dataCount = 0;
        $scope.data = [];
        $scope.isBusy = true;
        var onDataReceived = function (response) {
            angular.copy(response.data, $scope.data);
            $scope.dataCount = response.data.length;
        };
        var onError = function (reason) {
            alert("Could not load data");
        };
        var setBusy = function () {
            $scope.isBusy = false;
        }
        $http.get("/api/topics?includeReplies=true").then(onDataReceived, onError).then(setBusy);



    }

    var newTopicController = function ($scope, $http, $window) {
        $scope.newTopic = {};
        $scope.save = function () {
            $http.post("/api/topics", $scope.newTopic).then(saveSuccess, saveFail);

        };
        var saveSuccess = function (response) {
            var newTopic = response.data;
            $window.location = "#/";
        };
        var saveFail = function () {
            alert("Could not save data");
        };

    }



    appObj.controller("newTopicController", newTopicController);
    appObj.controller("topicsController", topicsController);
})();

