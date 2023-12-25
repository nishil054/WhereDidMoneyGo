(function () {
    angular.module('app').controller('app.views.expenseDetails.editExpense', [
        '$scope', '$uibModalInstance', 'abp.services.app.details', 'id',
        function ($scope, $uibModalInstance, detailsService, id) {
            var vm = this;

            vm.details = {};
            //vm.categoryItems = [];

            function init() {
                getItemsData();
            }

            init();

            function getItemsData() {

                detailsService.bindCategoryIds()
                    .then(function (result) {
                        vm.categoryItems = result.data;
                        itemService.getItemsById({
                            id: id
                        }).then(function (result) {
                            vm.details = result.data;
                            //vm.item.categoryId = vm.item.categoryId + "";
                            //$("#categoryName").select2("val", vm.item.categoryId);
                            //console.log(result.data);
                            //$scope.itemList = vm.item.itemDetails;
                        });

                    });
            }

            vm.save = function () {

                //if (vm.item.categoryId == "" || vm.item.categoryId == undefined || vm.item.categoryId == null) {
                //    abp.notify.error("Please select Category.");
                //    return;
                //}
                //if (vm.item.itemDescription == "" || vm.item.itemDescription == undefined || vm.item.itemDescription == null) {
                //    abp.notify.error("Please enter Item Description.");
                //    return;
                //}

                //for (var i = 0; i < $scope.itemList.length; i++) {
                //    if ($scope.itemList[i].uom == null || $scope.itemList[i].uom == "" || $scope.itemList[i].uom == undefined) {
                //        abp.notify.error("Please select UOM.");
                //        return;
                //    }
                //    else if ($scope.itemList[i].price == null || $scope.itemList[i].price == "" || $scope.itemList[i].price == undefined) {
                //        abp.notify.error("Please enter price.");
                //        return;
                //    }
                //    else if ($scope.itemList[i].moc == null || $scope.itemList[i].moc == "" || $scope.itemList[i].moc == undefined) {
                //        abp.notify.error("Please enter moc.");
                //        return;
                //    }
                //    else if ($scope.itemList[i].density == null || $scope.itemList[i].density == "" || $scope.itemList[i].density == undefined) {
                //        abp.notify.error("Please enter density.");
                //        return;
                //    }
                //    else if ($scope.itemList[i].grossAreaInSQM == null || $scope.itemList[i].grossAreaInSQM == "" || $scope.itemList[i].grossAreaInSQM == undefined) {
                //        abp.notify.error("Please enter grossAreaInSQM.");
                //        return;
                //    }
                //    else {
                //        /*vm.project.projectdetail.push({ projecttype: $scope.itemlist[i].projecttypeid, projectprice: $scope.itemlist[i].typeprice, projectprice: $scope.itemlist[i].typeprice, hours: $scope.itemlist[i].hours })*/;
                //    }
                //}

                vm.item.itemDetails = $scope.itemList;
                abp.ui.setBusy();
                detailsService.updateItem(vm.item)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    }).finally(function () {
                        abp.ui.clearBusy();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };
        }
    ]);
})();