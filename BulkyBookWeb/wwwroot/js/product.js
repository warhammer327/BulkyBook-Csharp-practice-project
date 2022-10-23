var dataTable;

$(document).ready(function () {
    loadDataTable(); 
});
function loadDataTable() {
    dataTable = $("#myTable").DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "title","width": "15%" },
            { "data": "author", "width": "15%" },
            { "data": "description", "width": "15%" },
            { "data": "category.name", "width": "15%" },
        ]
    });
}
