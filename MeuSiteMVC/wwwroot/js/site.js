$('.close-alert').on('click', function () {
    $('.alert').hide('hide');
});

$(document).ready(() => {
    // Inicializa DataTables corretamente
    $('#table-contacts').DataTable();
    $('#table-user').DataTable();

    $('.btn-total-contacts').click(function () {
        var userID = $(this).attr('user-id');

        $.ajax({
            type: 'GET',
            url: '/User/ContactListPerUserID/' + userID,
            success: function (result) {
                $("#contacts-list").html(result);
                $('#table-contact-user').DataTable();
                $('#modalContactsUser').modal('show');
            }
        });
    });
});




