(function () {
    angular.module('app').controller('app.views.expenseDetails.createExpenseDetails', [
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

            vm.save = function () {
                detailsService.createExpense(vm.details)
                    .then(function (result) {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                        vm.details = result.data.items;

                    });
            }

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };

            getDetailsData();
        }
    ]);
})();