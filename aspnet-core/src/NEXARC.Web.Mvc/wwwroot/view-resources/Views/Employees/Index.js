(function () {
    $(function () {
        var employeeService = abp.services.app.employee;
        var $modal = $('#EmployeeCreateModal');
        var $form = $modal.find('form');

        $form.validate({
            highlight: function (input) {
                $(input).parents('.form-group').addClass('has-error');
            },
            unhighlight: function (input) {
                $(input).parents('.form-group').removeClass('has-error');
            },
            errorPlacement: function (error, element) {
                $(element).parent().append(error);
            },
            rules: {
                Password: "required",
                ConfirmPassword: {
                    equalTo: "#Password"
                }
            }
        });

        $('#RefreshButton').click(function () {
            //refreshemployeeList();
            refreshEmployeeList();
        });

        $('.delete-employee').click(function () {
            var employeeId = $(this).attr("data-employee-id");
            var employeeName = $(this).attr('data-employee-name');

            var Employees = {
                ListId: employeeId,
                Name: employeeName,
                AbpObjService: employeeService
            }

            deleteRecord(Employees, true);
            //deleteEmployee(employeeId, employeeName, false);
        });

        $('.delete-employee-multi').click(function () {
            //var employeeId = $(this).attr("data-employee-id");
            //var employeeName = $(this).attr('data-employee-name');
            var checked = new Array();
            $("input:checkbox[dataclass=record-key]:checked").each(function () {
                checked.push($(this).data('id'));
            });

            if (checked.length == 0) {
                One.helpers('notify', { type: 'warning', icon: 'fa fa-exclamation mr-1', message: 'No Record is selected.' });
            }
            else {
                //console.log(checked);
                //return false;
                //object = {
                //    ListId: Unique Id of the record
                //    Name: Display Name to be display
                //    AbpObjService: APB Service
                //    List: Record List to be refresh
                
                var Employees = {
                    ListId: checked,
                    Name: "Multiple Records",
                    AbpObjService: employeeService
                }

                deleteRecord(Employees, true);
            }
            
        });


        $('.edit-employee').click(function (e) {

            var employeeId = $(this).attr("data-employee-id");

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Employees/EditEmployeeModal?Id=' + employeeId,
                type: 'POST',
                dataType: 'html',
                success: function (content) {
                    $('#EmployeeEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        $form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!$form.valid()) {
                return;
            }

            var employee = $form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            console.log("TEST ME");
            //employee.roleNames = [];
            //var $roleCheckboxes = $("input[name='role']:checked");
            //if ($roleCheckboxes) {
            //    for (var roleIndex = 0; roleIndex < $roleCheckboxes.length; roleIndex++) {
            //        var $roleCheckbox = $($roleCheckboxes[roleIndex]);
            //        employee.roleNames.push($roleCheckbox.val());
            //    }
            //}

            abp.ui.setBusy($modal);
            employeeService.create(employee).done(function (ret) {
                $modal.modal('hide');
                location.reload(true); //reload page to see new employee!
            }).always(function () {
                abp.ui.clearBusy($modal);
            });
        });

        $modal.on('shown.bs.modal', function () {
            $modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshEmployeeList() {
            location.reload(true); //reload page to see new employee!
        }

    //    function deleteEmployee(employeeId, employeeName, isMultiple = false) {
    //        abp.message.confirm(
    //            abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AbpProjectName'), employeeName),
    //            function (isConfirmed) {
    //                if (isConfirmed) {
    //                    One.loader('show')
    //                    if (Array.isArray(employeeId)) {
    //                        var complete = 0;
    //                        employeeId.forEach(function (recordId) {
    //                            employeeService.delete({
    //                                id: recordId
    //                            }).done(function () {
    //                                complete = complete + 1;
    //                            });
    //                        });
    //                        refreshEmployeeList();
    //                        One.loader('hide')
    //                    }
    //                    else {
    //                        employeeService.delete({
    //                            id: employeeId
    //                        }).done(function () {
    //                            refreshEmployeeList();
    //                        });
    //                        One.loader('hide')
    //                    }
    //                }
    //            }
    //        );
    //    }
    });
})();
