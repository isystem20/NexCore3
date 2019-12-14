(function () {
    $(function () {
        var roleService = abp.services.app.role;
        var $modal = $('#RoleCreateModal');
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
            }
        });

        $('#RefreshButton').click(function () {
            refreshRoleList();
        });

        $('.delete-role').click(function () {
            var roleId = $(this).attr("data-role-id");
            var roleName = $(this).attr('data-role-name');

            deleteRole(roleId, roleName, false);
        });

        $('.delete-role-multi').click(function () {
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
                deleteRole(checked, "Multiple Records", true);
            }

        });

        $('.edit-role').click(function (e) {
            var roleId = $(this).attr("data-role-id");

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Roles/EditRoleModal?roleId=' + roleId,
                type: 'POST',
                dataType: 'html',
                success: function (content) {
                    $('#RoleEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        $form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!$form.valid()) {
                return;
            }

            var role = $form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            role.grantedPermissions = [];
            $("input:checkbox[name=permission]:checked").each(function () {
                role.grantedPermissions.push($(this).val());
            });
            /*
            var _$permissionCheckboxes = $("input[name='permission']:checked");
            if (_$permissionCheckboxes) {
                for (var permissionIndex = 0; permissionIndex < _$permissionCheckboxes.length; permissionIndex++) {
                    var _$permissionCheckbox = $(_$permissionCheckboxes[permissionIndex]);
                    role.grantedPermissions.push(_$permissionCheckbox.val());
                }
            }*/

            abp.ui.setBusy($modal);
            roleService.create(role).done(function () {
                $modal.modal('hide');
                location.reload(true); //reload page to see new role!
            }).always(function () {
                abp.ui.clearBusy($modal);
            });
        });

        $modal.on('shown.bs.modal', function () {
            $modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshRoleList() {
            location.reload(true); //reload page to see new role!
        }

        /*function deleteRole(roleId, roleName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AbpProjectName'), roleName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        roleService.delete({
                            id: roleId
                        }).done(function () {
                            refreshRoleList();
                        });
                    }
                }
            );
        }*/

        function deleteRole(roleId, roleName, isMultiple = false) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AbpProjectName'), roleName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        One.loader('show')
                        if (Array.isArray(roleId)) {
                            var complete = 0;
                            roleId.forEach(function (recordId) {
                                roleService.delete({
                                    id: recordId
                                }).done(function () {
                                    complete = complete + 1;
                                });
                            });
                            refreshRoleList();
                            One.loader('hide')
                        }
                        else {
                            roleService.delete({
                                id: roleId
                            }).done(function () {
                                refreshRoleList();
                            });
                            One.loader('hide')
                        }
                    }
                }
            );
        }
    });
})();