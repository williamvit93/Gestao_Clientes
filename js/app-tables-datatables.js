var App = (function () {
    'use strict';

    var datatablesPTurl = "//cdn.datatables.net/plug-ins/1.10.13/i18n/Portuguese-Brasil.json";
    //We use this to apply style to certain elements
    $.extend(true, $.fn.dataTable.defaults, {
        "language": {
            "url": datatablesPTurl
        }
    });

    App.dataTables = function (tableId) {
        return $("#" + tableId).dataTable({
            "paging": false,
            dom:
          "<'row am-datatable-header'<'col-sm-12 inputSearchDatatable'f>>" +
          "<'row am-datatable-body'<'col-sm-12'tr>>" +
          "<'row am-datatable-footer'<'col-sm-5'i><'col-sm-7'p>>"
        });
    };

    App.dataTablesWithScrool = function (tableId) {
        return $("#" + tableId).dataTable({
            "paging": false,
            scrollX: true,
            dom:
          "<'row am-datatable-header'<'col-sm-12 inputSearchDatatable'f>>" +
          "<'row am-datatable-body'<'col-sm-12'tr>>" +
          "<'row am-datatable-footer'<'col-sm-5'i><'col-sm-7'p>>"
        });
    };

    App.dataTables2 = function (tableId) {
        return $("#" + tableId).dataTable({
            "pageLength": 5,
            dom:
          "<'row am-datatable-header'<'col-sm-12 inputSearchDatatable'f>>" +
          "<'row am-datatable-body'<'col-sm-12'tr>>" +
          "<'row am-datatable-footer'<'col-sm-5'i><'col-sm-7'p>>",
        });
    };

    App.dataTablesScrollVert = function (tableId) {
        return $("#" + tableId).dataTable({
            scrollY: 200,
            scrollCollapse: true,
            paging: false
        });
    };



    App.dataTablesWithADD = function (tableId) {
        return $("#" + tableId).dataTable({
            dom:
          "<'row am-datatable-header'<'col-sm-6 inputSearchDatatable'f>>" +
          "<'row am-datatable-body'<'col-sm-12'tr>>" +
          "<'row am-datatable-footer'<'col-sm-5'i><'col-sm-7'p>>"
        });
    };


    App.dataTablesWithExportButtons = function (tableId) {
        var url = "//cdn.datatables.net/plug-ins/1.10.13/i18n/Portuguese-Brasil.json";

        $("#" + tableId).dataTable({
            buttons: [
             'excel', 'pdf', 'print'
            ],
            "lengthMenu": [[6, 10, 25, 50, -1], [6, 10, 25, 50, "All"]],
            dom: "<'row am-datatable-header'<'col-sm-3'l><'col-sm-6 text-center'f><'col-sm-3 text-right'B>>" +
                  "<'row am-datatable-body'<'col-sm-12'tr>>" +
                  "<'row am-datatable-footer'<'col-sm-5'i><'col-sm-7'p>>"
        });
    };

    return App;
})(App || {});
