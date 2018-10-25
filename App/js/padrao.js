function Limpar(formulario, tabelaAtivos, tabelaInativos) {
    DestruirDataTable(tabelaAtivos);
    DestruirDataTable(tabelaInativos);

    $(formulario).each(function () {
        this.reset();
    });
    $('select').val("").trigger('change');
}

function MontarDatatable(tabela, nomeController) {
    $(tabela).DataTable({
        buttons: [
            {
                extend: 'excel', text: 'Excel', title: 'Relatório de ' + nomeController,
                orientation: 'portrait',
                pageSize: 'A4',
            },
            {
                extend: 'csv', text: 'CSV', title: 'Relatório de ' + nomeController,
                orientation: 'portrait',
                pageSize: 'A4',
            },
            {
                extend: 'print', text: 'Imprimir',
                title: '',
                customize: function (win) {
                    $(win.document.body)
                        .css('font-size', '10pt')
                        .prepend(
                            '<img src="" style="position:absolute; top:0; left:0;" /><h3>Relatório de ' + nomeController + '</center> </h3>'
                        );

                    $(win.document.body).find('table')
                        .addClass('compact')
                        .css('font-size', 'inherit');
                },

                orientation: 'portrait',
                pageSize: 'A4',
            }
        ],

        "paging": true,
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
        dom: "<'row am-datatable-header'<'col-sm-6'l><'col-sm-6 text-right'B>>" +
            "<'row am-datatable-body'<'col-sm-12'tr>>" +
            "<'row am-datatable-footer'<'col-sm-5'i><'col-sm-7'p>>"
    });
}

function DestruirDataTable(tabela) {
    var body = tabela + ' tbody';

    if ($.fn.dataTable.isDataTable(tabela)) {
        $(tabela).DataTable().destroy();
        $(body).html('');
    }
}

function Sucess(objectName) {
    $('#objectName').text(objectName);
    $('#success-title').text(objectName);
    $('#md-success').modal('show');
}

function SuccessRegisterRemoveItems(quantidade, unidadeMedida, nomeItem, registro) {
    $('#quantityInserted').text(quantidade);
    $('#measureUnit').text(unidadeMedida);
    $('#itemNameInserted').text(nomeItem);
    $('#register').text(registro);
    $('#md-successRegister').modal('show');
}

function HabilitaItens(idUm, idDois, idTres, idQuatro) {
    $(idUm).show(200);
    $(idDois).show(200);
    $(idTres).show(200);
    $(idQuatro).show(200);
}

function DesabilitaItens(idUm, idDois, idTres, idQuatro) {
    $(idUm).hide(200);
    $(idDois).hide(200);
    $(idTres).hide(200);
    $(idQuatro).hide(200);
}

function PesquisarPacienteModal() {
    var nomePaciente = $('#FullName').val();

    if (nomePaciente) {
        $.ajax({
            url: "/Patient/GetByName/",
            type: "post",
            data: { name: nomePaciente },
            success: function (data) {
                if (data.success === true) {
                    MontaModalPesquisaPaciente(data.result);
                    $('#md-pacientes').modal('show');
                } else {
                    Notificacao.errorNotifications(data);
                }
            }
        });
    }
}

function MontaModalPesquisaPaciente(dados) {
    $('#frmPesquisaPaciente tbody').html('');

    $.each(dados, function (i, item) {
        var html =
            '<tr class="odd gradeX">' +
            '<td class="text-center">' +
            '<div class="am-radio">' +
            '<input type="radio" name="radioPaciente" id=' + item.PatientGuidId + item.FullName + ' value=' + item.PatientGuidId + '>' +
            '<label for=' + item.PatientGuidId + item.FullName + '></label>' +
            '</div>' +
            '</td>' +
            '<td class="text-center" id=' + item.PatientGuidId + '>' + item.FullName + '</td>' +
            '<td class="text-center" id=' + item.PatientGuidId + 'CPF' + '>' + item.Cpf + '</td>' +
            '</tr>';

        $('#frmPesquisaPaciente tbody').append(html);
    });
    $('#frmPesquisaPaciente').DataTable();
}

function SelecionarPaciente() {
    var checkedValue = $('input[name=radioPaciente]:checked').val();
    var pacienteId = "#" + checkedValue;
    var fullName = $(pacienteId).text();
    var cpf = $(pacienteId + 'CPF').text();
    if (checkedValue) {
        $('#PatientGuidId').val(checkedValue);
        $('#FullName').val(fullName);
        $('#Cpf').val(cpf);
        $('#md-pacientes').modal('hide');
    } else {
        Notification.errorNotifications('Erro');
    }
}

function PesquisarItensModal(itemType) {

    var itemName = itemType === 1 ? $('#MedicineName').val() : $('#UtensilName').val();
    var url = itemType === 1 ? '/Medicines/GetByName/' : '/Utensils/GetByName/';

    if (itemName) {
        $.ajax({
            url: url,
            type: "post",
            data: { name: itemName },
            success: function (data) {
                if (data.success === true) {
                    MontaModalPesquisaItens(data.result);
                    $('#md-itens').modal('show');
                } else {
                    Notificacao.errorNotifications(data);
                }
            }
        });
    }
}

function MontaModalPesquisaItens(dados) {
    $('#frmPesquisaItem tbody').html('');

    $.each(dados, function (i, item) {
        var itemId = item.ItemType === 1 ? item.MedicineId : item.UtensilsId;

        var html =
            '<tr class="odd gradeX">' +
            '<td class="text-center">' +
            '<div class="am-radio">' +
            '<input type="radio" name="radioItem" id=' + itemId + item.Description + ' value=' + itemId + '>' +
            '<label for=' + itemId + item.Description + '></label>' +
            '</div>' +
            '<input type="hidden" id="itemType" value=' + item.ItemType + '>' +
            '</td>' +
            '<td class="text-center" id=' + itemId + '>' + item.Description + '</td>' +
            '<td class="text-center">' + item.MeasureUnit + '</td>' +
            '</tr>';

        $('#frmPesquisaItem tbody').append(html);
    });

    $('#frmPesquisaItem').DataTable();
}

function MontarListaItensEstoque(dados) {
    var trHtml = "";

    $.each(dados, function (i, userData) {
        var volume = userData.TotalQuantity + " " + userData.MeasureUnit;
        var nome = "'" + userData.ItemName + "'";
        var tipoItem = userData.ItemType === 1 ? 'MEDICAMENTO' : 'UTENSILIO';
        var id = "'" + userData.ItemId + "'";
        var urlIn = "'" + 'RegisterInputStock' + "'";
        var urlOut = "'" + 'RegisterOutputStock' + "'";
        var titleOut = "'" + 'Saída' + "'";
        var titleIn = "'" + 'Entrada' + "'";
        var inputDate = userData.InputDate ? new Date(userData.InputDate).toLocaleDateString() : "-";
        var outputDate = userData.OutputDate ? new Date(userData.OutputDate).toLocaleDateString() : "-";


        trHtml +=
            '<tr class="odd gradeX">' +
            '<td class="text-center">' + tipoItem + '</td>' +
            '<td class="text-center">' + userData.ItemName + '</td>' +
            '<td class="text-center">' + volume + '</td>' +
            '<td class="text-center">' + inputDate + '</td>' +
            '<td class="text-center">' + outputDate + '</td>' +
            '<td class="text-center">' +
            '<button onclick="AbreModalEntradaSaida(' + userData.ItemType + ',' + id + ',' + nome + ',' + urlIn + ',' + titleIn + ')" type="button" data-id="' + userData.ItemId + '" class="btn btn-space btn-info btn-rounded btn-xs">' +
            '<i class="icon icon-left fa fa-plus-circle"></i>Registrar Entrada</button>' +
            '<button onclick="AbreModalEntradaSaida(' + userData.ItemType + ',' + id + ',' + nome + ',' + urlOut + ',' + titleOut + ')" type="button"  data-id="' + userData.ItemId + '" class="btn btn-space btn-warning btn-rounded btn-xs">' +
            '<i class="icon icon-left fa fa-minus-circle"></i>Registrar Saída</button>' +
            '<a href="/Stock/History?itemTypeStock=1&id=' + userData.ItemId + '" type="button" class="btn btn-space btn-success btn-rounded btn-xs">' +
            '<i class="icon icon-left fa fa-eye"></i>Ver Histórico</a>' + '</td ></tr > ';
    });

    $('#itensEstoque tbody').append(trHtml);
}

function SelecionarItem() {
    var itemType = $('#itemType').val();
    var item = '';
    var itemName = '';

    if (itemType === "1") {
        item = '#MedicineId';
        itemName = '#MedicineName';
    } else {
        item = '#UtensilsId';
        itemName = '#UtensilName';
    }

    var checkedValue = $('input[name=radioItem]:checked').val();
    var itemId = "#" + checkedValue;

    var fullName = $(itemId).text();
    if (checkedValue) {
        $(item).val(checkedValue);
        $(itemName).val(fullName);
        $('#md-itens').modal('hide');
    } else {
        Notification.errorNotifications('Erro');
    }
}

function AtualizaStatusTarefas() {
    $.ajax({
        url: '/TaskScheduler/VerifyAndSetStatus',
        type: "post",
        dataType: 'json',
        async: true,
        success: function (data) {
            if (data.success === true) {
                console.log(data);
                ListarTarefasDiarias();
            } else {
                console.log(data);
            }
        }
    });
}

function PesquisarUsuarioModal() {
    var nomeUsuario = $('#UserName').val();

    if (nomeUsuario) {
        $.ajax({
            url: "/Usuarios/GetByName/",
            type: "post",
            data: { name: nomeUsuario },
            success: function (data) {
                if (data.success === true) {
                    MontaModalPesquisaUsuario(data.result);
                    $('#md-usuarios').modal('show');
                } else {
                    Notificacao.errorNotifications(data);
                }
            }
        });
    }
}

function MontaModalPesquisaUsuario(dados) {
    $('#frmPesquisaUsuario tbody').html('');

    $.each(dados, function (i, item) {
        var html =
            '<tr class="odd gradeX">' +
            '<td class="text-center">' +
            '<div class="am-radio">' +
            '<input type="radio" name="radioUsuario" id=' + item.Id + item.Nome + ' value=' + item.Id + '>' +
            '<label for=' + item.Id + item.Nome + '></label>' +
            '</div>' +
            '</td>' +
            '<td class="text-center" id=' + item.Id + '>' + item.Nome + '</td>' +
            '</tr>';

        $('#frmPesquisaUsuario tbody').append(html);
    });
    $('#frmPesquisaUsuario').DataTable();
}

function SelecionarUsuario() {
    var checkedValue = $('input[name=radioUsuario]:checked').val();
    var usuarioId = "#" + checkedValue;
    var nomeUsuario = $(usuarioId).text();
    if (checkedValue) {
        $('#UserId').val(checkedValue);
        $('#UserName').val(nomeUsuario);
        $('#md-usuarios').modal('hide');
    } else {
        Notification.errorNotifications('Erro');
    }
}


//$(document).ready(function () {
//    App.init();
//});