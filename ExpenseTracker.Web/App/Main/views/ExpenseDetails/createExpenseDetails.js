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
                //var assingnedRoles = [];

                //for (var i = 0; i < vm.roles.length; i++) {
                //    var role = vm.roles[i];
                //    if (!role.isAssigned) {
                //        continue;
                //    }

                //    assingnedRoles.push(role.name);
                debugger;
                detailsService.createExpense(vm.details)
                    .then(function (result) {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                        vm.details = result.data.items;

                    });
            }

            //vm.user.roleNames = assingnedRoles;
            //userService.create(vm.user)
            //    .then(function () {
            //        abp.notify.info(App.localize('SavedSuccessfully'));
            //        $uibModalInstance.close();

            //    });
        //};

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };

            getDetailsData();
        }
    ]);
})();