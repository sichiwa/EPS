// vCheckList service
angular
    .module('app')
    .factory("vCheckListService", function ($http, $q) {
        return {
            // Create vCheckLists 
            createvCheckList: function (viewModel) {
                alert(viewModel);
                // Get the deferred object
                var deferred = $q.defer();
                // Initiates the AJAX call
                $http({ method: 'POST', url: '/Document/AddItem', data: viewModel })
					.success(deferred.resolve).error(deferred.reject);
                // Returns the promise - Contains result once request completes
                return deferred.promise;
            }
        }
    });