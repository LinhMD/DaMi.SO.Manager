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
