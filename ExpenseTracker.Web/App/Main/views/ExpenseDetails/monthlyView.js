(function () {
    angular.module('app').controller('app.views.expenseDetails.monthlyView', [
        '$scope','abp.services.app.details',
        function ($scope, detailsService) {
            var vm = this;
            console.log("---------------------------------------")
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