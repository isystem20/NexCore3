(function () {
    $('#ReturnUrlHash').val(location.hash);

    var $form = $('#LoginForm');

    $form.validate({
        highlight: function (input) {
            $(input).parents('.form-group').addClass('has-error');
        },
        unhighlight: function (input) {
            $(input).parents('.form-group').removeClass('has-error');
        },
        errorPlacement: function (error, element) {
            $(element).parents('.form-group').append(error);
        }
    });

    $form.submit(function (e) {
        e.preventDefault();

        if (!$form.valid()) {
            return;
        }

        abp.ui.setBusy(
            $('#LoginArea'),

            abp.ajax({
                contentType: 'application/x-www-form-urlencoded',
                url: $form.attr('action'),
                data: $form.serialize()
            })
        );
    });
})();
