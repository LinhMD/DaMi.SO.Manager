jQuery.noConflict();
$(document).ready(function () {
    Array.from(document.getElementsByClassName("currency")).forEach(element => {
        IMask(
            element,
            {
                mask: 'num',
                blocks: {
                    num: {
                        // nested masks are available!
                        mask: Number,
                        thousandsSeparator: ','
                    }
                }
            }
        )
    })
});
toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": false,
    "progressBar": true,
    "positionClass": "toast-top-right",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}
document.body.addEventListener('htmx:responseError', function (evt) {
    if (evt.detail.xhr.status === 500) {
        toastr.error(JSON.parse(evt.detail.xhr.response).message)
    }
});