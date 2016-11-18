var filteredColumn = 1;
var rows = [];

$(document).ready(function() {
    rows = $(".table tr:not(:first-child)");
});

/**
 * Column for filter
 */
$(".books-filter .dropdown-menu li").click(function () {
    var item = $(this);
    item.parents(".input-group-btn").find(".filter-title").text(item.text());
    filteredColumn = +item.attr("id");

    var input = $(".books-filter input");
    input.val("");
    input.focus();
    rows.each(function () {
        $(this).show();
    });
});

/**
 * Books filter
 */
$(".books-filter input").on("input", function (event) {
    var inputText = $(this).val();

    rows.each(function () {
        if (this.cells[filteredColumn].innerText.toLowerCase().indexOf(inputText.toLowerCase()) < 0) {
            $(this).hide();
        } else {
            $(this).show();
        } 
    });
});

