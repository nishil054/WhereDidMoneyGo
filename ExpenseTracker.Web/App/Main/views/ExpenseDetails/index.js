(function () {
    angular.module('app').controller('app.views.expenseDetails.index', [
        '$scope', '$timeout', '$uibModal', 'abp.services.app.details',
        function ($scope, $timeout, $uibModal, detailsService) {
            var vm = this;

            vm.details = [];

            function getDetails() {
                detailsService.getDetailsData({}).then(function (result) {
                    vm.details = result.data;
                });
            }

            vm.openExpenseCreationModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/ExpenseDetails/createExpenseDetails.cshtml',
                    controller: 'app.views.expenseDetails.createExpenseDetails as vm',
                    backdrop: 'static'
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getDetails();
                });
            };

            vm.openExpenseEditModal = function (user) {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/ExpenseDetails/expenseEditModal.cshtml',
                    controller: 'app.views.users.editModal as vm',
                    backdrop: 'static',
                    resolve: {
                        id: function () {
                            return user.id;
                        }
                    }
                });

                modalInstance.rendered.then(function () {
                    $timeout(function () {
                        $.AdminBSB.input.activate();
                    }, 0);
                });

                modalInstance.result.then(function () {
                    getDetails();
                });
            };

            vm.delete = function (details) {
                abp.message.confirm(
                    "Delete user '" + details.expenseName + "'?",
                    "Delete",
                    function (result) {
                        if (result) {
                            detailsService.deleteExpense({ id: details.id })
                                .then(function () {
                                    abp.notify.info("Deleted Expense: " + details.expenseName);
                                    getDetails();
                                });
                        }
                    });
            }

            vm.refresh = function () {
                getDetails();
            };

            getDetails();
        }
    ]);
})();
