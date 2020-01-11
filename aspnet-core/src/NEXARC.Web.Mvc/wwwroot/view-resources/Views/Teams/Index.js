(function () {
    $(function () {
        var teamService = abp.services.app.team;
        var $modal = $('#TeamCreateModal');
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
            refreshTeamList();
        });

        $('.delete-team').click(function () {
            var teamId = $(this).attr("data-team-id");
            var teamName = $(this).attr('data-team-name');

            deleteTeam(teamId, teamName, false);
        });

        $('.delete-team-multi').click(function () {
            //var teamId = $(this).attr("data-team-id");
            //var teamName = $(this).attr('data-team-name');
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
                deleteTeam(checked, "Multiple Records", true);
            }


        });


        $('.edit-team').click(function (e) {

            var teamId = $(this).attr("data-team-id");

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Teams/EditTeamModal?Id=' + teamId,
                type: 'POST',
                dataType: 'html',
                success: function (content) {
                    $('#TeamEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        $form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();



            if (!$form.valid()) {
                return;
            }

            var team = $form.serializeFormToObject(); //serializeFormToObject is defined in main.js


            //team.roleNames = [];
            //var $roleCheckboxes = $("input[name='role']:checked");
            //if ($roleCheckboxes) {
            //    for (var roleIndex = 0; roleIndex < $roleCheckboxes.length; roleIndex++) {
            //        var $roleCheckbox = $($roleCheckboxes[roleIndex]);
            //        team.roleNames.push($roleCheckbox.val());
            //    }
            //}

            abp.ui.setBusy($modal);
            teamService.create(team).done(function (ret) {
                $modal.modal('hide');
                location.reload(true); //reload page to see new team!
            }).always(function () {
                abp.ui.clearBusy($modal);
            });
        });

        $modal.on('shown.bs.modal', function () {
            $modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshTeamList() {
            location.reload(true); //reload page to see new team!
        }

        function deleteTeam(teamId, teamName, isMultiple = false) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AbpProjectName'), teamName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        One.loader('show')
                        if (Array.isArray(teamId)) {
                            teamService.deleteMultiple({
                                id: teamId
                            }).done(function () {
                                refreshCityList();
                            });
                            One.loader('hide')
                        }
                        else {
                            teamService.delete({
                                id: teamId
                            }).done(function () {
                                refreshTeamList();
                            });
                            One.loader('hide')
                        }
                    }
                }
            );
        }
    });
})();
