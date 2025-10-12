document.addEventListener("DOMContentLoaded", function () {

    const button = document.getElementById("button-voucher");
    const inputV = document.getElementById("input-voucher");
    button.addEventListener("click", function () {

        console.log(inputV.value);
    })

})