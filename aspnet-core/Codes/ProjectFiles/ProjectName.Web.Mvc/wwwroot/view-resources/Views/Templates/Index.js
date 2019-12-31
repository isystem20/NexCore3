(function () {
    $(function () {
        var {{EntityLower}}Service = abp.services.app.{{EntityLower}};
        var $modal = $('#{{Entity}}CreateModal');
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
            refresh{{Entity}}List();
        });

        $('.delete-{{EntityLower}}').click(function () {
            var {{EntityLower}}Id = $(this).attr("data-{{EntityLower}}-id");
            var {{EntityLower}}Name = $(this).attr('data-{{EntityLower}}-name');

            delete{{Entity}}({{EntityLower}}Id, {{EntityLower}}Name, false);
        });

        $('.delete-{{EntityLower}}-multi').click(function () {
            //var {{EntityLower}}Id = $(this).attr("data-{{EntityLower}}-id");
            //var {{EntityLower}}Name = $(this).attr('data-{{EntityLower}}-name');
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
                delete{{Entity}}(checked, "Multiple Records", true);
            }


        });


        $('.edit-{{EntityLower}}').click(function (e) {

            var {{EntityLower}}Id = $(this).attr("data-{{EntityLower}}-id");

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + '{{EntityPlural}}/Edit{{Entity}}Modal?Id=' + {{EntityLower}}Id,
                type: 'POST',
                dataType: 'html',
                success: function (content) {
                    $('#{{Entity}}EditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        $form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();



            if (!$form.valid()) {
                return;
            }

            var {{EntityLower}} = $form.serializeFormToObject(); //serializeFormToObject is defined in main.js


            //{{EntityLower}}.roleNames = [];
            //var $roleCheckboxes = $("input[name='role']:checked");
            //if ($roleCheckboxes) {
            //    for (var roleIndex = 0; roleIndex < $roleCheckboxes.length; roleIndex++) {
            //        var $roleCheckbox = $($roleCheckboxes[roleIndex]);
            //        {{EntityLower}}.roleNames.push($roleCheckbox.val());
            //    }
            //}

            abp.ui.setBusy($modal);
            {{EntityLower}}Service.create({{EntityLower}}).done(function (ret) {
                $modal.modal('hide');
                location.reload(true); //reload page to see new {{EntityLower}}!
            }).always(function () {
                abp.ui.clearBusy($modal);
            });
        });

        $modal.on('shown.bs.modal', function () {
            $modal.find('input:not([type=hidden]):first').focus();
        });

        function refresh{{Entity}}List() {
            location.reload(true); //reload page to see new {{EntityLower}}!
        }

        function delete{{Entity}}({{EntityLower}}Id, {{EntityLower}}Name, isMultiple = false) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AbpProjectName'), {{EntityLower}}Name),
                function (isConfirmed) {
                    if (isConfirmed) {
                        One.loader('show')
                        if (Array.isArray({{EntityLower}}Id)) {
                            var complete = 0;
                            {{EntityLower}}Id.forEach(function (recordId) {
                                {{EntityLower}}Service.delete({
                                    id: recordId
                                }).done(function () {
                                    complete = complete + 1;
                                });
                            });
                            refresh{{Entity}}List();
                            One.loader('hide')
                        }
                        else {
                            {{EntityLower}}Service.delete({
                                id: {{EntityLower}}Id
                            }).done(function () {
                                refresh{{Entity}}List();
                            });
                            One.loader('hide')
                        }
                    }
                }
            );
        }
    });
})();
