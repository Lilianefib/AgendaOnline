
$(document).ready(function () {

    $('#Agenda').DataTable({
        language:
        {
            "decimal": "",
            "emptyTable": "No data available in table",
            "info": "Mostrando _START_ de _END_ de _TOTAL_ entrada(s)",
            "infoEmpty": "Showing 0 to 0 of 0 entries",
            "infoFiltered": "",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ entradas",
            "loadingRecords": "Loading...",
            "processing": "",
            "search": "Pesquisar:",
            "zeroRecords": "No matching records found",
            "paginate": {
                "first": "Primeiro",
                "last": "Último",
                "next": "Próximo",
                "previous": "Anterior"
            },
            "aria": {
                "orderable": "Order by this column",
                "orderableReverse": "Reverse order this column"
            }
        }
    }
    
    );

    //5000 é a quantidade de milisegundos
    //FadeOut - Elemento de saída
    setTimeout(function () {
        $(".alert").fadeOut("slow", function () {
            $(this).alert('close');
        })
    },5000)

});
