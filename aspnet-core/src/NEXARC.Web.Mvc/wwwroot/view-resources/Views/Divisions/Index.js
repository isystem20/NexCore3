(function () {
    $(function () {
        var divisionService = abp.services.app.division;
        var $modal = $('#DivisionCreateModal');
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
            refreshDivisionList();
        });

        $('.delete-division').click(function () {
            var divisionId = $(this).attr("data-division-id");
            var divisionName = $(this).attr('data-division-name');

            deleteDivision(divisionId, divisionName, false);
        });

        $('.delete-division-multi').click(function () {
            //var divisionId = $(this).attr("data-division-id");
            //var divisionName = $(this).attr('data-division-name');
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
                deleteDivision(checked, "Multiple Records", true);
            }


        });


        $('.edit-division').click(function (e) {

            var divisionId = $(this).attr("data-division-id");

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Divisions/EditDivisionModal?Id=' + divisionId,
                type: 'POST',
                dataType: 'html',
                success: function (content) {
                    $('#DivisionEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        $form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();



            if (!$form.valid()) {
                return;
            }

            var division = $form.serializeFormToObject(); //serializeFormToObject is defined in main.js


            //division.roleNames = [];
            //var $roleCheckboxes = $("input[name='role']:checked");
            //if ($roleCheckboxes) {
            //    for (var roleIndex = 0; roleIndex < $roleCheckboxes.length; roleIndex++) {
            //        var $roleCheckbox = $($roleCheckboxes[roleIndex]);
            //        division.roleNames.push($roleCheckbox.val());
            //    }
            //}

            abp.ui.setBusy($modal);
            divisionService.create(division).done(function (ret) {
                $modal.modal('hide');
                location.reload(true); //reload page to see new division!
            }).always(function () {
                abp.ui.clearBusy($modal);
            });
        });

        $modal.on('shown.bs.modal', function () {
            $modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshDivisionList() {
            location.reload(true); //reload page to see new division!
        }

        function deleteDivision(divisionId, divisionName, isMultiple = false) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AbpProjectName'), divisionName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        One.loader('show')
                        if (isMultiple) {
                            divisionService.delete({
                                id: divisionId
                            }).done(function () {
                            refreshDivisionList();
                            });
                            One.loader('hide')
                        }
                        else {
                            divisionService.delete({
                                id: divisionId
                            }).done(function () {
                                refreshDivisionList();
                            });
                            One.loader('hide')
                        }
                    }
                }
            );
        }
    });
})();
