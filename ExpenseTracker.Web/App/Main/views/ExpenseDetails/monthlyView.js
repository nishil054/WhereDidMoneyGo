(function () {
    angular.module('app').controller('app.views.expenseDetails.monthlyView', [
        '$scope', '$uibModalInstance', 'abp.services.app.details',
        function ($scope, $uibModalInstance, detailsService) {
            var vm = this;

            vm.details = {
                isActive: true
            };

            vm.details = [];

            function getDetailsData() {

                detailsService.getDetailsData()
                    .then(function (result) {
                        vm.details = result.data.items;
                    });
            }

            

            getDetailsData();
        }
    ]);
})();