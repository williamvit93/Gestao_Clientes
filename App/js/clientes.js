function GravarCliente(url) {
    $.ajax({
        url: 'http://localhost:33053/Api' + url,
        type: "post",
        data: $('#frmAddCliente').serialize(),
        dataType: 'json',
        async: true,
        success: function (data) {
            if (data.success === true) {
                Sucess('Cliente');
                window.setTimeout(function () {

                    location.replace('/Cliente/Index');
                }, 3000);
            } else {
                Notificacao.errorNotifications(data);
            }
        }
    });
}

function PesquisarClientes() {
    //DestruirDataTable('#tb_clientes');

    $.ajax({
        url: 'http://localhost:33053/Api/Clientes/Listar',
        crossDomain: true,
        type: "get",
        dataType: 'json',
        async: true,
        success: function (data) {
            if (data) {
                var dados = JSON.parse(data.result);
                console.log(dados);

                MontarListaClientes(dados);
                //MontarDatatable('#tb_clientes', 'Clientes');

            } else {
                //Notificacao.errorNotifications(data);
                console.log(dados)
            }
        },
        complete: function () {
            $(".carregando").fadeOut(300);
        }
    });
}

function MontarListaClientes(dados) {
    var trHtml = "";

    $.each(dados, function (i, userData) {
        var cpf = String(userData.Cpf);
        var tipoCliente = userData.TipoCliente == 1 ? 'Pessoa Física' : "Pessoa Jurídica";
        var situacaoCliente = userData.SituacaoCliente == 1 ? 'Em Débito' : "Em Dia";

        trHtml +=
            '<tr class="odd gradeX">' +
            '<td class="text-center">' + userData.Nome + '</td>' +
            '<td class="text-center">' + userData.Cpf + '</td>' +
            '<td class="text-center">' + userData.Sexo + '</td>' +
            '<td class="text-center">' + tipoCliente + '</td>' +
            '<td class="text-center">' + situacaoCliente + '</td>' +

            '<a href="/Clientes/Edit?id=' + cpf + '" type="button" id="' + cpf + '" data-id="' + cpf + '" class="btn btn-space btn-success btn-rounded btn-xs">' +
            '<i class="icon icon-left fa fa-pencil"></i>Editar</button>' +

            '<a href="/Clientes/Remover?id=' + cpf + '" type="button" id="' + cpf + '" data-id="' + cpf + '" class="btn btn-space btn-danger btn-rounded btn-xs">' +
            '<i class="icon icon-left fa fa-ban"></i>Inativar</button>' + '</td></tr>';
    });

    $('#tb_clientes tbody').append(trHtml);
}