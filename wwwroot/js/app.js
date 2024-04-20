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

var triggerTabList = [].slice.call(document.querySelectorAll('#pills-tab button'))
triggerTabList.forEach(function (triggerEl) {
    var tabTrigger = new bootstrap.Tab(triggerEl)
    triggerEl.addEventListener('click', function (event) {
        event.preventDefault()
        tabTrigger.show()
    })
})
document.body.addEventListener('htmx:responseError', function (evt) {
    var response = {};
    try {
        response = JSON.parse(evt.detail.xhr.response);
    } catch (e) {
    }
    if (evt.detail.xhr.status == 500) {
        toastr.error(response.message || response.errorMessages || "Internal Server Error");
    } else if (evt.detail.xhr.status == 404) {
        toastr.warning(response.message || response.errorMessages || "Content Not Found");
    } else if (evt.detail.xhr.status == 403) {
        toastr.warning(response.message || response.errorMessages || "Forbidden");
    } else if (evt.detail.xhr.status == 400) {
        toastr.warning(response.message || response.errorMessages || "Bad Request:");
    }
});
$('.Delete').on('click', function () {
    return confirm('Bạn có muốn xóa?');
});