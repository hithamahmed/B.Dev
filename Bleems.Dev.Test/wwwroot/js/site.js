// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    //$('#customerDatatable').DataTable({});
    //$('#productsTbl').DataTable({});
})

function showError(msg) {
    Swal.fire({
        position: 'center',
        icon: 'error',
        title: 'حدث خطأ',
        text: msg
    })
};


function showDone(msg) {
    Swal.fire({
        position: 'center',
        icon: 'success',
        title: msg,
        showConfirmButton: true,
        timer: 3000
    })
};