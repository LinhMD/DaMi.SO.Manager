jQuery.noConflict();
function maskAll() {
    $(document).ready(function () {
        Array.from(document.getElementsByClassName("currency")).forEach(element => {
            mask(element)
        })
    });
}
function mask(element) {
    IMask(
        element,
        {
            mask: 'num',
            blocks: {
                num: {
                    mask: Number,
                    thousandsSeparator: '.'
                }
            }
        }
    )
}

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
    if (evt.detail.xhr.status !== 200) {
        try {
            var response = JSON.parse(evt.detail.xhr.response);
            toastr.error(response.message || response.errorMessages);
        } catch (e) {
            toastr.error("Internal Server Error");
        }
    }
});
function ModifyInput(elements) {
    Array.from(elements).forEach(e => {
        e.value = (e.value || '').toString().replace(/[^0-9-]+/g, '')
    })
    return true;
}
function calculatePrice(guid) {
    var quantity = Number($(`#Quantity_${guid}`).val());
    var price = toNumber($(`#ConvertPrice_${guid}`).text());
    var totalPrice = quantity * price;
    var formatOption = { style: 'currency', currency: 'VND' };
    $(`#ConvertAmount_${guid}`).text(toCurrency(totalPrice));
    var taxRate = toNumber($(`#TaxRate_${guid}`).text());
    $(`#ConvertTaxAmount_${guid}`).text(toCurrency(totalPrice * taxRate / 100));
    var discountRate = Number($(`#DiscountPercent_${guid}`).val());
    $(`#ConvertDiscAmount_${guid}`).val(totalPrice * discountRate / 100);
    calculateTotal();
}
function toNumber(str) {
    return Number((str || 0).toString().replace(/[^0-9-]+/g, ""));
}
function toCurrency(num) {
    return new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(num);
}
function calculateTotal() {
    var totalConvert = Array.from($(`table [name='ConvertAmount']`)).map(f => toNumber(f.innerText)).reduce((prev, curr) => prev + curr);
    var totaltax = Array.from($(`table [name='ConvertTaxAmount']`)).map(f => toNumber(f.innerText)).reduce((prev, curr) => prev + curr);
    var totaldisc = Array.from($(`table [name='ConvertDiscAmount']`)).map(f => toNumber(f.value)).reduce((prev, curr) => prev + curr);
    $(`#TotalAmount`).val(toCurrency(totalConvert));
    $(`#ConvertTaxAmount`).val(toCurrency(totaltax));
    $(`#ConvertDiscAmount`).val(toCurrency(totaldisc));
    $(`#ConvertTotalAmount`).val(toCurrency(totalConvert + totaltax - totaldisc));
}
var triggerTabList = [].slice.call(document.querySelectorAll('#pills-tab button'))
triggerTabList.forEach(function (triggerEl) {
    var tabTrigger = new bootstrap.Tab(triggerEl)
    triggerEl.addEventListener('click', function (event) {
        event.preventDefault()
        tabTrigger.show()
    })
})