function GravarClientes(type, action) {
    $.ajax({
        url: 'http://localhost:33053/Api/' + action,
        type: type,
        data: $('#frmAddCliente').serialize(),
        dataType: 'json',
        async: true,
        success: function (data) {
            if (data) {
                //Sucess('Cliente');
                window.setTimeout(function () {

                    location.replace('Index.html');
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
        type: "get",
        dataType: 'json',
        async: true,
        success: function (dados) {
            if (dados) {
                console.log(dados);

                MontarListaClientes(dados);
                //MontarDatatable('#tb_clientes', 'Clientes');

            } else {
                //Notificacao.errorNotifications(dados);
            }
        }
    });
}

function MontarListaClientes(dados) {
    var trHtml = "";

    $.each(dados, function (i, userData) {
        var tipoCliente = userData.TipoCliente === 1 ? 'Pessoa Fisica' : "Pessoa Juridica";
        var situacaoCliente = userData.SituacaoCliente === 1 ? 'Em Debito' : "Em Dia";

        trHtml +=
            '<tr id=' + userData.Cpf + ' class="odd gradeX">' +
            '<td id="nome" class="text-center">' + userData.Nome + '</td>' +
            '<td class="text-center">' + userData.Cpf + '</td>' +
            '<td class="text-center">' + userData.Sexo + '</td>' +
            '<td id="tipocliente" class="text-center">' + tipoCliente + '</td>' +
            '<td id="situacaocliente" class="text-center">' + situacaoCliente + '</td>' +
            '<td>' +
            '<a onclick="EditarCliente(' + "'" + userData.Cpf + "'" + ')" type="button" id="' + userData.Cpf + '" data-id="' + userData.Cpf + '" class="btn btn-space btn-success btn-rounded btn-xs">' +
            '<i class="icon icon-left fa fa-pencil"></i>Editar</a>' +
            '<a onclick="RemoverCliente(' + "'" + userData.Cpf + "'" + ')" type="button" id="' + userData.Cpf + '" data-id="' + userData.Cpf + '" class="btn btn-space btn-danger btn-rounded btn-xs">' +
            '<i class="icon icon-left fa fa-ban"></i>Remover</a>' + '</td></tr>';
    });

    $('#tb_clientes tbody').append(trHtml);
}

function EditarCliente(cpf) {
    //pegando os dados da linha selecionada
    var linha = '#' + cpf;

    var nome = $(linha + '#nome').text();
    var sexo = $(linha + '#sexo').text();
    var situacaoCliente = $(linha + '#situacaocliente').text();
    var tipoCliente = $(linha + '#tipocliente').text();

    //adicionando os dados à tela de edição
    $('#Cpf').val(cpf);
    $('#Nome').val(nome);
    $("#Sexo").find('option:contains("' + sexo + '")').prop('selected', true);
    $("#SituacaoCliente").find('option:contains("' + situacaoCliente + '")').prop('selected', true);
    $("#TipoCliente").find('option:contains("' + tipoCliente + '")').prop('selected', true);

    $('#frmAddCliente').show();
}

function RemoverCliente(cpf) {
    $.ajax({
        url: 'http://localhost:33053/Api/Clientes',
        type: "DELETE",
        mode: 'cors',
        data: cpf,
        dataType: 'json',
        async: true,
        success: function (dados) {
            if (dados) {
                console.log(dados);
                location.reload();
                //MontarDatatable('#tb_clientes', 'Clientes');

            } else {
                //Notificacao.errorNotifications(dados);
            }
        }
    });
}