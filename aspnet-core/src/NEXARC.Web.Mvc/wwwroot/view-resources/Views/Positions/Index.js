(function () {
    $(function () {
        var positionService = abp.services.app.position;
        var $modal = $('#PositionCreateModal');
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
            refreshPositionList();
        });

        $('.delete-position').click(function () {
            var positionId = $(this).attr("data-position-id");
            var positionName = $(this).attr('data-position-name');

            deletePosition(positionId, positionName, false);
        });

        $('.delete-position-multi').click(function () {
            //var positionId = $(this).attr("data-position-id");
            //var positionName = $(this).attr('data-position-name');
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
                deletePosition(checked, "Multiple Records", true);
            }


        });


        $('.edit-position').click(function (e) {

            var positionId = $(this).attr("data-position-id");

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Positions/EditPositionModal?Id=' + positionId,
                type: 'POST',
                dataType: 'html',
                success: function (content) {
                    $('#PositionEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        $form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();



            if (!$form.valid()) {
                return;
            }

            var position = $form.serializeFormToObject(); //serializeFormToObject is defined in main.js


            //position.roleNames = [];
            //var $roleCheckboxes = $("input[name='role']:checked");
            //if ($roleCheckboxes) {
            //    for (var roleIndex = 0; roleIndex < $roleCheckboxes.length; roleIndex++) {
            //        var $roleCheckbox = $($roleCheckboxes[roleIndex]);
            //        position.roleNames.push($roleCheckbox.val());
            //    }
            //}

            abp.ui.setBusy($modal);
            positionService.create(position).done(function (ret) {
                $modal.modal('hide');
                location.reload(true); //reload page to see new position!
            }).always(function () {
                abp.ui.clearBusy($modal);
            });
        });

        $modal.on('shown.bs.modal', function () {
            $modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshPositionList() {
            location.reload(true); //reload page to see new position!
        }

        function deletePosition(positionId, positionName, isMultiple = false) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AbpProjectName'), positionName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        One.loader('show')
                        if (isMultiple) {
                            positionService.deleteMultiple({
                                id: positionId
                            }).done(function () {
                                refreshPositionList();
                            });
                            One.loader('hide')
                        }
                        else {
                            positionService.delete({
                                id: positionId
                            }).done(function () {
                                refreshPositionList();
                            });
                            One.loader('hide')
                        }
                    }
                }
            );
        }
    });
})();
