$(document).ready(function () {

   //Funciones

    function IniciarTabla() {
        $('#tablaResultados').DataTable({
            dom: '<"row top-table"<"col-sm-6"><"col-sm-6">>rt<"bottom"><"clear">',
            order: [],
            search: false,
            columns: [
                {
                    data: "palabra",
                    width: 200
                },
                { data: "cont" }         
            ]
        });
    }

    function ContarPalabras() {
        var texto = $("#txtTexto").val();

        $.ajax({
            url: "/Home/ContarPalabras",
            data: {
                texto: texto
            },
            type: "POST",
            success: function (result) {               

                var table = $('#tablaResultados').DataTable()
                table.clear();

                if (result.exitoso == true) {
                    table.rows.add(result.items);
                    table.columns.adjust().draw();
                }
                else alert("Ha ocurrido un error: " + result.error);
            

            },
            error: function () {
                alert("Ha ocurrido un error.");
            }
        })
    }

  //Eventos
    $("#btnContarPalabras").on("click", function () {

        if ($("#txtTexto").val().trim() != "") {
            var table = $('#tablaResultados').DataTable()
            table.clear();
            ContarPalabras();
        }            
        else alert("Por favor ingrese un texto");
    });

  //Ready
    IniciarTabla();
    
})