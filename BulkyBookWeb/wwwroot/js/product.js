var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}

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
                    <a  onClick="Delete('/Admin/Product/Delete/${data}')" class="btn btn-danger" style="width:auto"><i class="bi bi-trash2"></i>Delete</a>
                    `
                },
                "width": "15%"
            },
        ]
    });
}


