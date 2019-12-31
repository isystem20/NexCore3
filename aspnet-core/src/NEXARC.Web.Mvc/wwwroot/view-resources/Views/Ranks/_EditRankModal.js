(function ($) {
    var rankService = abp.services.app.rank;
    var $modal = $('#RankEditModal');
    var $form = $('form[name=RankEditForm]');

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

        var rank = $form.serializeFormToObject(); //serializeFormToObject is defined in main.js
        //rank.roleNames = [];
        //var $roleCheckboxes = $("input[name='role']:checked");
        //if ($roleCheckboxes) {
        //    for (var roleIndex = 0; roleIndex < $roleCheckboxes.length; roleIndex++) {
        //        var $roleCheckbox = $($roleCheckboxes[roleIndex]);
        //        rank.roleNames.push($roleCheckbox.val());
        //    }
        //}

        abp.ui.setBusy($form);
        rankService.update(rank).done(function () {
            $modal.modal('hide');
            location.reload(true); //reload page to see edited rank!
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
