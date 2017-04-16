angular.module('OwnerDetails', ['ngSanitize'])
.controller('OwnerDetailsController', ['$scope', '$http', function ($scope, $http) {
    var defaultItemsCountOnPage = 3;
    $scope.currentPage = 0;

    $scope.paginationItem_OnClick = function (pageNumber) {
        $scope.currentPage = pageNumber - 1;
    };

    $scope.petCreate_OnClick = function(petName) {
        if (petName == "" || petName == undefined)
            return;

        var requestBody = {
            ownerId : ownerId,
            petName : petName
        };

        $http.post('../api/Pets/Create', requestBody)
         .then(function(response) {
            getOwnerDetails();
        });
    }

    $scope.petDelete_OnClick = function(petId) {
        var requestBody = {
            petId : petId
        };

         $http.post('../api/Pets/Delete', requestBody)
         .then(function(response) {
            getOwnerDetails();
        });
    }

    var getOwnerDetails = function () {
        $http({
            method: 'GET',
            url: '../api/Owners/' + ownerId
        }).then(function (response) {
            return response.data;
        }).then(function (response) {
            if (response == null) {
                window.location = '../../Default/NotFoundError';
            }

            $scope.OwnerDetails = response;
            $scope.Pages = splitPetsListToPages(response.Pets);
        });
    };

    var splitPetsListToPages = function (items) {
        // pages generation
        var result = [];
        for (var i = 0, pageNumber = 1; i < items.length; i += defaultItemsCountOnPage, pageNumber++) {
            var itemsOnPage = [];
            for (var j = i; j < i + defaultItemsCountOnPage && j < items.length; j++) {
                itemsOnPage.push(items[j]);
            }

            var page = {
                Items: itemsOnPage
            };

            result.push(page);
        }

        return result;
    };

    getOwnerDetails();
}]);
