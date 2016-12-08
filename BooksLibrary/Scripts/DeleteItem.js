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
                    $.ajax({
                        type: 'POST',
                        url: deleteUrl,
                        data: { id: item.parents('.card').attr('id') },
                        success: function (responce) {
                            if (responce.status === 'ok') {
                                item.parents('.card').remove();
                            } else {
                                bootbox.alert({
                                    size: "small",
                                    title: "Ошибка удаления",
                                    message: "На эту запись ссылается другая запись. Для продолжения удалите ссылающуюся запись.",
                                });
                            }
                        }
                    });
                }
            },
        }
    });
});