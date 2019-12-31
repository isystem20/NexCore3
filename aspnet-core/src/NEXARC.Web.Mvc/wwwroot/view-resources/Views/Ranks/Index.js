(function () {
    $(function () {
        var rankService = abp.services.app.rank;
        var $modal = $('#RankCreateModal');
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
            refreshRankList();
        });

        $('.delete-rank').click(function () {
            var rankId = $(this).attr("data-rank-id");
            var rankName = $(this).attr('data-rank-name');

            deleteRank(rankId, rankName, false);
        });

        $('.delete-rank-multi').click(function () {
            //var rankId = $(this).attr("data-rank-id");
            //var rankName = $(this).attr('data-rank-name');
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
                deleteRank(checked, "Multiple Records", true);
            }


        });


        $('.edit-rank').click(function (e) {

            var rankId = $(this).attr("data-rank-id");

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Ranks/EditRankModal?Id=' + rankId,
                type: 'POST',
                dataType: 'html',
                success: function (content) {
                    $('#RankEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        $form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();



            if (!$form.valid()) {
                return;
            }

            var rank = $form.serializeFormToObject(); //serializeFormToObject is defined in main.js


            //rank.roleNames = [];
            //var $roleCheckboxes = $("input[name='role']:checked");
            //if ($roleCheckboxes) {
            //    for (var roleIndex = 0; roleIndex < $roleCheckboxes.length; roleIndex++) {
            //        var $roleCheckbox = $($roleCheckboxes[roleIndex]);
            //        rank.roleNames.push($roleCheckbox.val());
            //    }
            //}

            abp.ui.setBusy($modal);
            rankService.create(rank).done(function (ret) {
                $modal.modal('hide');
                location.reload(true); //reload page to see new rank!
            }).always(function () {
                abp.ui.clearBusy($modal);
            });
        });

        $modal.on('shown.bs.modal', function () {
            $modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshRankList() {
            location.reload(true); //reload page to see new rank!
        }

        function deleteRank(rankId, rankName, isMultiple = false) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AbpProjectName'), rankName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        One.loader('show')
                        if (Array.isArray(rankId)) {
                            rankService.deleteMultiple({
                                id: rankId
                            }).done(function () {
                                refreshCityList();
                            });
                            One.loader('hide')
                        }
                        else {
                            rankService.delete({
                                id: rankId
                            }).done(function () {
                                refreshRankList();
                            });
                            One.loader('hide')
                        }
                    }
                }
            );
        }
    });
})();
