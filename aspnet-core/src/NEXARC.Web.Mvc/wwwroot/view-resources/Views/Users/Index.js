(function () {
    $(function () {
        var userService = abp.services.app.user;
        var $modal = $('#UserCreateModal');
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
            refreshUserList();
        });

        $('.delete-user').click(function () {
            var userId = $(this).attr("data-user-id");
            var userName = $(this).attr('data-user-name');

            deleteUser(userId, userName, false);
        });

        $('.delete-user-multi').click(function () {
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
                deleteUser(checked, "Multiple Records", true);
            }

        });

        $('.edit-user').click(function (e) {
            var userId = $(this).attr("data-user-id");

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Users/EditUserModal?userId=' + userId,
                type: 'POST',
                dataType: 'html',
                success: function (content) {
                    $('#UserEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        $form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!$form.valid()) {
                return;
            }

            var user = $form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            user.roleNames = [];
            var $roleCheckboxes = $("input[name='role']:checked");
            if ($roleCheckboxes) {
                for (var roleIndex = 0; roleIndex < $roleCheckboxes.length; roleIndex++) {
                    var $roleCheckbox = $($roleCheckboxes[roleIndex]);
                    user.roleNames.push($roleCheckbox.val());
                }
            }

            abp.ui.setBusy($modal);
            userService.create(user).done(function () {
                $modal.modal('hide');
                location.reload(true); //reload page to see new user!
            }).always(function () {
                abp.ui.clearBusy($modal);
            });
        });

        $modal.on('shown.bs.modal', function () {
            $modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshUserList() {
            location.reload(true); //reload page to see new user!
        }

        // function deleteUser(userId, userName) {
        //     abp.message.confirm(
        //         abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AbpProjectName'), userName),
        //         function (isConfirmed) {
        //             if (isConfirmed) {
        //                 userService.delete({
        //                     id: userId
        //                 }).done(function () {
        //                     refreshUserList();
        //                 });
        //             }
        //         }
        //     );
        // }

        function deleteUser(userId, userName, isMultiple = false) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AbpProjectName'), userName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        One.loader('show')
                        if (Array.isArray(userId)) {
                            var complete = 0;
                            userId.forEach(function (recordId) {
                                userService.delete({
                                    id: recordId
                                }).done(function () {
                                    complete = complete + 1;
                                });
                            });
                            refreshUserList();
                            One.loader('hide')
                        }
                        else {
                            userService.delete({
                                id: userId
                            }).done(function () {
                                refreshUserList();
                            });
                            One.loader('hide')
                        }
                    }
                }
            );
        }
    });
})();