

//first argument should be an object with the following structure
//object = {
//    ListId: Unique Id of the record
//    Name: Display Name to be display
//    AbpObjService: APB Service
//    List: Record List to be refresh
//}
function deleteRecord(record, isMultiple = false) {

    var Name = record.Name;
    var ListId = record.ListId;
    var AbpObjService = record.AbpObjService;

    abp.message.confirm(
        abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AbpProjectName'), Name),
        function (isConfirmed) {
            if (isConfirmed) {
                One.loader('show')
                if (Array.isArray(ListId)) {
                    var complete = 0;
                    ListId.forEach(function (recordId) {
                        AbpObjService.delete({
                            id: recordId
                        }).done(function () {
                            complete = complete + 1;
                        });
                    });
                    //refreshEmployeeList();
                    if (complete > 0) {
                        location.reload(true);
                        One.loader('hide')
                    }

                }
                else {
                    AbpObjService.delete({
                        id: ListId
                    }).done(function () {
                        location.reload(true);
                    });
                    One.loader('hide')
                }
            }
        }
    );
}