(function () {
    $(function () {
        var cityService = abp.services.app.city;
        var $modal = $('#CityCreateModal');
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
            refreshCityList();
        });

        $('.delete-city').click(function () {
            var cityId = $(this).attr("data-city-id");
            var cityName = $(this).attr('data-city-name');

            deleteCity(cityId, cityName, false);
        });

        $('.delete-city-multi').click(function () {
            //var cityId = $(this).attr("data-city-id");
            //var cityName = $(this).attr('data-city-name');
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
                deleteCity(checked, "Multiple Records", true);
            }


        });


        $('.edit-city').click(function (e) {

            var cityId = $(this).attr("data-city-id");

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Cities/EditCityModal?Id=' + cityId,
                type: 'POST',
                dataType: 'html',
                success: function (content) {
                    $('#CityEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        $form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();



            if (!$form.valid()) {
                return;
            }

            var city = $form.serializeFormToObject(); //serializeFormToObject is defined in main.js


            //city.roleNames = [];
            //var $roleCheckboxes = $("input[name='role']:checked");
            //if ($roleCheckboxes) {
            //    for (var roleIndex = 0; roleIndex < $roleCheckboxes.length; roleIndex++) {
            //        var $roleCheckbox = $($roleCheckboxes[roleIndex]);
            //        city.roleNames.push($roleCheckbox.val());
            //    }
            //}

            abp.ui.setBusy($modal);
            cityService.create(city).done(function (ret) {
                $modal.modal('hide');
                location.reload(true); //reload page to see new city!
            }).always(function () {
                abp.ui.clearBusy($modal);
            });
        });

        $modal.on('shown.bs.modal', function () {
            $modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshCityList() {
            location.reload(true); //reload page to see new city!
        }

        function deleteCity(cityId, cityName, isMultiple = false) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'AbpProjectName'), cityName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        One.loader('show')
                        if (Array.isArray(cityId)) {
                            var complete = 0;
                            // console.log(cityId);
   
                            cityService.deleteMultiple({
                                id: cityId
                            }).done(function () {
                                refreshCityList();
                            });
                            One.loader('hide')
                        }
                        else {
                            cityService.delete({
                                id: cityId
                            }).done(function () {
                                refreshCityList();
                            });
                            One.loader('hide')
                        }
                    }
                }
            );
        }
    });
})();
