// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('.btnDelete').click(function () {
        var id = $(this).attr('id').replace('student-', '');
        var currentThis = $(this);
        if (confirm("Delete?")) {
            $.ajax({
                url: 'Student/Delete/' + id,
                method: 'POST',
                success: function (res) {
                    alert('Xoa thanh cong');
                    location.reload();
                },
                error: function (msg) {

                }
            });
        }
    });
});