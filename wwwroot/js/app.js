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