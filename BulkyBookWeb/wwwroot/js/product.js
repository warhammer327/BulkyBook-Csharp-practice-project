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
            { "data": "title", "width": "15%" },
            { "data": "author", "width": "15%" },
            { "data": "description", "width": "15%" },
            { "data": "category.name", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `                        
                    <a class="btn btn-primary" href="/Admin/Product/Upsert?id=${data}"  style="width:auto"><i class="bi bi-pencil-square"></i>Edit</a>
                    <a class="btn btn-danger" href="" style="width:auto"><i class="bi bi-trash2"></i>Delete</a>
                    `
                },
                "width": "15%"
            },
        ]
    });
}
