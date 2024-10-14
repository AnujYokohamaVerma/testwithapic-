$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#ArticleData').DataTable({
        "ajax": {url:'/Jinchuriki_1/Articles/getall'},
        "columns": [
            { data: 'title', "width": "15%" },
            { data: 'summary', "width": "15%" },
            { data: 'createdDate', "width": "15%" },
            { data: 'modifiedDate', "width": "15%" }
        ]
    });
}

