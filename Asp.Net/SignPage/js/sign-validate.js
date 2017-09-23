!function ($) {

    var FocusEvent = function () {
        function FocusEvent(elemt_str, validator) {
            (typeof elemt_str == 'string') ? this.element = document.getElementById(elemt_str) : this.element = null;
            (typeof validator == 'string') ? this.validator = validator : this.validator = null;
        }

        FocusEvent.prototype.addFocus = function () {
            var ele = this.element;
            var val = this.validator;
            ele.addEventListener('focus', function () {
                var validatorName = this.parentElement.getElementsByClassName(val);

                for (var i = 0, length = validatorName.length; i < length; i++) {
                    validatorName[i].style.visibility = 'hidden';
                }

            }, false);
        };

        //FocusEvent.prototype.removeFocus = function () {
        //};

        return FocusEvent;
    }();

    (new FocusEvent('nameBox',          'validator')).addFocus();
    (new FocusEvent('emailBox',         'validator')).addFocus();
    (new FocusEvent('phoneBox',         'validator')).addFocus();
    (new FocusEvent('passwdBox',        'validator')).addFocus();
    (new FocusEvent('confirmPasswdBox', 'validator')).addFocus();

}(window);