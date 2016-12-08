$('.btn-icon-delete').click(function() {
    var item = $(this);
    bootbox.dialog({
        size: "small",
        message: "Удалить запись?",
        onEscape: true,
        backdrop: true,
        buttons: {
            cancel: {
                label: '<i class="fa fa-times fa-2x"></i>',
            },
            yes: {
                label: '<i class="fa fa-check fa-2x"></i>',
                className: 'btn-danger',
                callback: function () {
                    $.post(deleteUrl, { id: item.parents('.card').attr('id') });
                    item.parents('.card').remove();
                    console.log('deleted');
                }
            },
        }
    });
});