angular.module('OwnerDetails', ['ngSanitize'])
.controller('OwnerDetailsController', ['$scope', '$http', function ($scope, $http) {
    var defaultItemsCountOnPage = 3;
    $scope.currentPage = 0;
    $scope.sortDirection = 'top';

    $scope.paginationItem_OnClick = function (pageNumber) {
        $scope.currentPage = pageNumber - 1;
    };

    $scope.sortDirection_OnClick = function() {
        if ($scope.sortDirection == 'top') {
            $scope.sortDirection = 'bottom';
        } 
        else {
            $scope.sortDirection = 'top';
        }

        sortPets($scope.sortDirection);
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

    var sortPets = function(sortDirection) {
        var sortCoef = 1;
        if (sortDirection == 'bottom') {
            sortCoef = -1;
        }

        $scope.OwnerDetails.Pets.sort(function(a, b){
            if(a.PetName < b.PetName) return -1*sortCoef;
            if(a.PetName > b.PetName) return sortCoef;
            return 0;
        });

        $scope.Pages = splitPetsListToPages($scope.OwnerDetails.Pets);
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
