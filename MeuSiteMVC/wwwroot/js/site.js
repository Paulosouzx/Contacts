

$('.close-alert').on('click', function () {
    $('.alert').hide('hide');
});


$(document).ready(() => {
    getDatatable('#table-contacts');
    getDatatable('#table-user');

    // Use 'on' para eventos dinâmicos
    $(document).on('click', '.btn-total-contacts', function () {
        $('#modalContactsUser').modal('show');  // Abra o modal ao clicar no botão
    });
});



let table = new DataTable('#table-contacts', '#table-user');



