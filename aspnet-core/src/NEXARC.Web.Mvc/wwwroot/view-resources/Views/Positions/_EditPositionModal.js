(function ($) {
    var positionService = abp.services.app.position;
    var $modal = $('#PositionEditModal');
    var $form = $('form[name=PositionEditForm]');

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

    function save() {

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

        abp.ui.setBusy($form);
        positionService.update(position).done(function () {
            $modal.modal('hide');
            location.reload(true); //reload page to see edited position!
        }).always(function () {
            abp.ui.clearBusy($modal);
        });
    }

    //Handle save button click
    $form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    //Handle enter key
    $form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    $modal.on('shown.bs.modal', function () {
        $form.find('input[type=text]:first').focus();
    });
})(jQuery);
