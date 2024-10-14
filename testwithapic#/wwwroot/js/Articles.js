$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#ArticleData').DataTable({
        "ajax": {url:'/Jinchuriki_1/Articles/getall'},
        "columns": [
            { data: 'title', "width": "15%" },
            { data: 'summary', "width": "30%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href="/Jinchuriki_1/Articles/Read?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil"></i> Read</a>

                    </div >`

                },
                "width": "15"
            },
            { data: 'createdDate', "width": "10%" },
            { data: 'modifiedDate', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href="/Jinchuriki_1/Articles/Edit?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil"></i> Edit</a>
                        <a href="/Jinchuriki_1/Articles/Delete?id=${data}" class="btn btn-danger mx-2"><i class="bi bi-trash"></i> Delete</a>

                    </div >`
                    
                },
                "width": "15"
            }
        ]
    });
}

