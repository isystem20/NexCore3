(function () {
    $(function () {
        var departmentService = abp.services.app.department;
        var $modal = $('#DepartmentCreateModal');
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
            refreshDepartmentList();
        });

        $('.delete-department').click(function () {
            var departmentId = $(this).attr("data-department-id");
            var departmentName = $(this).attr('data-department-name');

            deleteDepartment(departmentId, departmentName, false);
        });

        $('.delete-department-multi').click(function () {
            //var departmentId = $(this).attr("data-department-id");
            //var departmentName = $(this).attr('data-department-name');
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
                deleteDepartment(checked, "Multiple Records", true);
            }

            
        });


        $('.edit-department').click(function (e) {

            var departmentId = $(this).attr("data-department-id");

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Departments/EditDepartmentModal?Id=' + departmentId,
                type: 'POST',
                dataType: 'html',
                success: function (content) {
                    $('#DepartmentEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        $form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();



            if (!$form.valid()) {
                return;
            }

            var department = $form.serializeFormToObject(); //serializeFormToObject is defined in main.js


            //department.roleNames = [];
            //var $roleCheckboxes = $("input[name='role']:checked");
            //if ($roleCheckboxes) {
            //    for (var roleIndex = 0; roleIndex < $roleCheckboxes.length; roleIndex++) {
            //        var $roleCheckbox = $($roleCheckboxes[roleIndex]);
            //        department.roleNames.push($roleCheckbox.val());
            //    }
            //}

            abp.ui.setBusy($modal);
            departmentService.create(department).done(function (ret) {
                $modal.modal('hide');
                location.reload(true); //reload page to see new department!
            }).always(function () {
                abp.ui.clearBusy($modal);
            });
        });

        $modal.on('shown.bs.modal', function () {
            $modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshDepartmentList() {
            location.reload(true); //reload page to see new department!
        }

        function deleteDepartment(departmentId, departmentName, isMultiple = false) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AbpProjectName'), departmentName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        One.loader('show')
                        if (Array.isArray(departmentId)) {
                            var complete = 0;
                            departmentId.forEach(function (recordId) {
                                departmentService.delete({
                                    id: recordId
                                }).done(function () {
                                    complete = complete + 1;
                                });
                            });
                            refreshDepartmentList();
                            One.loader('hide')
                        }
                        else {
                            departmentService.delete({
                                id: departmentId
                            }).done(function () {
                                refreshDepartmentList();
                            });
                            One.loader('hide')
                        }
                    }
                }
            );
        }
    });
})();
