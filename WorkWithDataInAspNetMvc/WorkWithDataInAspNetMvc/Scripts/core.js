$(document).ready(function () {
    setTimezone();
});

function setTimezone()
{
    var tz = Intl.DateTimeFormat().resolvedOptions().timeZone;
    $.cookie("timezone", tz);
}


$(function () {
    $.validator.methods.date = function (value, element) {
        if ($.browser.webkit) {
            var d = new Date();
            return this.optional(element) || !/Invalid|NaN/.test(new Date(d.toLocaleDateString(value)));
        }
        else {
            return this.optional(element) || !/Invalid|NaN/.test(new Date(value));
        }
    };
});