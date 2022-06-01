var datatable;

$(document).ready(function () {
    loadDataTable();
    var id = document.getElementById("empleadoId");
    if (id.value > 0) {
        $('#modal').modal('show');
    }
});

function limpiar() {
    var empleadoId = document.getElementById("empleadoId");
    var Nombbres = document.getElementById("Nombres");
    var Extension = document.getElementById("Extension");
    var Departamento = document.getElementById("Departamento");
    var Correo = document.getElementById("Correo");

    empleadoId.value = 0;
    Nombbres.value = "";
    Extension.value = "";
    Departamento.value = "";
    Correo.value = "";
}

function loadDataTable() {
    datatable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Extension/ObtenerTodos"
        },
        "columns": [
            { "data": "nombre", "width": "15%" },
            { "data": "extension", "width": "15%" },
            { "data": "departamento", "width": "15" },
            { "data": "correo", "width": "15%" },
          
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div>
                            <a href="/Extension/Crear/${data}" class="btn btn-success text-white" style="cursor:pointer;">
                                Editar
                            </a>
                            <a onclick=Delete("/Extension/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                Eliminar
                            </a>
                        </div>
                        `;
                }, "width": "20%"
            }
        ],
      



    });



}
function Delete(url) {

    swal({
        title: "Esta seguro de Eliminar este Empleado?",
        text: "Este registro no se podra recuperar",
        icon: "warning",
        buttons: true
    }).then((borrar) => {
        if (borrar) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        alert(data.message);
                        datatable.ajax.reload();
                    }
                    else {
                        alert(data.message);
                    }
                }
            });
        }
    });
}

