$(document).ready(function() {
    // jgwery ==
    $.ajax({
        type: 'GET',
        url: '/Users/GetUsers',
        success: function (responce) {
            var table = $('.table');

            for (let i = 0; i < responce.length; i++) {
                // создаем шаблонную строку, шаблонна так как `
                var row = `<tr class="card" id="${responce[i].id}">
                           <td>${responce[i].email}</td>
                           <td>${responce[i].userName}</td>
                           <td>${responce[i].role}</td>
                           <td class="actions">
                               <a href="/Users/Edit/${responce[i].id}" class="btn-icon-edit"><i class="fa fa-edit fa-lg"></i></a>
                               <a href="/Users/Details/${responce[i].id}" class="btn-icon-details"><i class="fa fa-info fa-lg"></i></a>
                               <div class="btn-icon-delete"><i class="fa fa-times fa-lg"></i></div>
                           </td>
                       </tr>`;
                table.find('tbody').append(row);
            }
        },
    });

});