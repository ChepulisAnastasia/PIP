$(document).onload(function() {

    $.ajax({
        type: 'GET',
        url: '/Books/GetBooks',
        success: function(responce) {
            
        },
    });

});