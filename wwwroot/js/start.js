
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
function rowSubmit(guid) {
    calculateTotal();
    ModifyInput($(`input[form='form_${guid}'].currency`));
    return true;
}
function ModifyInput(elements) {
    Array.from(elements).forEach(e => {
        e.value = (e.value || '').toString().replace(/[^0-9-]+/g, '')
    })
    return true;
}
function calculatePrice(guid) {
    var quantity = Number($(`#Quantity_${guid}`).val());
    var price = toNumber($(`#OriginalPrice_${guid}`).text() || $(`#OriginalPrice_${guid}`).val());
    var totalPrice = quantity * price;
    $(`#OriginalAmount_${guid}`).text(toCurrency(totalPrice));
    var taxRate = toNumber($(`#TaxRate_${guid}`).text());
    $(`#OriginalTaxAmount_${guid}`).text(toCurrency(totalPrice * taxRate / 100));
    var discountRate = Number($(`#DiscountPercent_${guid}`).val());
    $(`#OriginalDiscAmount_${guid}`).val(toCurrency(totalPrice * discountRate / 100));
    calculateTotal();
}
function toNumber(str) {
    return +Number((str || 0).toString().replace(/[^0-9-]+/g, ""));
}
function toCurrency(num) {
    return new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(num);
}
function calculateTotal() {
    var total = Array.from($(`table [name='OriginalAmount']`)).map(f => toNumber(f.value || f.innerText)).reduce((prev, curr) => prev + curr);
    var totaltax = Array.from($(`table [name='OriginalTaxAmount']`)).map(f => toNumber(f.value || f.innerText)).reduce((prev, curr) => prev + curr);
    var totaldisc = Array.from($(`table [name='OriginalDiscAmount']`)).map(f => toNumber(f.value || f.innerText)).reduce((prev, curr) => prev + curr);

    $(`#OriginalTaxAmount`).val(toCurrency(totaltax));
    $(`#OriginalDiscAmount`).val(toCurrency(totaldisc));
    $(`#OriginalTotalAmount`).val(toCurrency(total + totaltax - totaldisc));
}
function matchAny(params, data) {
    // If there are no search terms, return all of the data
    if ($.trim(params.term) === '') {
        return data;
    }

    // Skip if there is no 'children' property
    if (typeof data.children === 'undefined') {
        return null;
    }

    // `data.children` contains the actual options that we are matching against
    var filteredChildren = [];
    $.each(data.children, function (idx, child) {
        if (child.text.toUpperCase().indexOf(params.term.toUpperCase()) >= 0) {
            filteredChildren.push(child);
        }
    });

    // If we matched any of the timezone group's children, then set the matched children on the group
    // and return the group object
    if (filteredChildren.length) {
        var modifiedData = $.extend({}, data, true);
        modifiedData.children = filteredChildren;

        // You can return modified objects from here
        // This includes matching the `children` how you want in nested data sets
        return modifiedData;
    }

    // Return `null` if the term should not be displayed
    return null;
}
