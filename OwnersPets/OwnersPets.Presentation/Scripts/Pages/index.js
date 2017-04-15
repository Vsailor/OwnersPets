angular.module('Owners',  ['ngSanitize'])
.controller('OwnersController', ['$scope', '$http', function ($scope, $http) {
    var defaultItemsCountOnPage = 3;
    $scope.currentPage = 0;

    $scope.paginationItem_OnClick = function(pageNumber) {
       $scope.currentPage = pageNumber-1;
    };

    $scope.ownerDelete_OnClick = function(ownerId) {
        var requestBody = {
            ownerId : ownerId
        };
        
        $http.post('api/Owners/Delete', requestBody)
        .then(function(response) {
            getOwnersList();
        });
    }

    $scope.ownerCreate_OnClick = function(ownerName) {
        var requestBody = {
            ownerName : ownerName
        };

        $http.post('api/Owners/Create', requestBody)
         .then(function(response) {
            getOwnersList();
        });
    }

    var getOwnersList = function () {
        $http({
            method: 'GET',
            url: 'api/Owners'
        }).then(function (response) {
            return response.data;
        }).then(function(response) {
            $scope.OwnersList = response;
            $scope.Pages = splitOwnersListToPages(response);
        });
    };

    var splitOwnersListToPages = function(ownersList) {
        // pages generation
        var result = [];
        for (var i=0, pageNumber = 1; i<ownersList.length; i+=defaultItemsCountOnPage, pageNumber++)
        {
            var itemsOnPage = [];
            for(var j=i; j<i+defaultItemsCountOnPage && j<ownersList.length; j++)
            {
                itemsOnPage.push(ownersList[j]);
            }

            var page = {
                Items : itemsOnPage
            };

            result.push(page);
        }

        return result;
    };

    getOwnersList();
}]);
