alert("hello")
console.log($);
$(".currency").on('load blur', function () {
    const value = this.value.replace(/,/g, '');
    this.value = parseFloat(value).toLocaleString('vi_VN', {
        style: 'int',
        maximumFractionDigits: 0
    });
});