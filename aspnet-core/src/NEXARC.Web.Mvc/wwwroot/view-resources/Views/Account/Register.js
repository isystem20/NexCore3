(function () {
    var $form = $('#RegisterForm');

    $.validator.addMethod("customUsername", function (value, element) {
        if (value === $form.find('input[name="EmailAddress"]').val()) {
            return true;
        }

        //Username can not be an email address (except the email address entered)
        return !$.validator.methods.email.apply(this, arguments);
    }, abp.localization.localize("RegisterFormUserNameInvalidMessage", "AbpProjectName"));

    $form.validate({
        highlight: function (input) {
            $(input).parents('.form-group').addClass('has-error');
        },

        unhighlight: function (input) {
            $(input).parents('.form-group').removeClass('has-error');
        },

        errorPlacement: function (error, element) {
            $(element).parents('.form-group').append(error);
        },
        rules: {
            UserName: {
                required: true,
                customUsername: true
            }
        }
    });
})();
