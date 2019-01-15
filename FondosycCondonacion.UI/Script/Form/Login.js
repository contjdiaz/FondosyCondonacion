/// <reference path="../Default/Default.aspx" />
function mostrar()
{
    MostrarForm();
}

function Restablecer(url) {
    MostrarFormRestrablecer(url);
}

function MostrarForm() {
    var page = $("#UrlSolicitudPassword").val();
    var $dialog = $('<div id="internalWindow"></div>')
           .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%" style="overflow:none"></iframe>')
           .dialog({
               autoOpen: false,
               modal: true,
               height: 250,
               width: 530,
               title: "Restablecer Contrase&#241;a",
               resizable: false,
               open: function (event, ui) {
                   $(this).css('overflow', 'hidden'); //this line does the actual hiding
               }
           });
    $dialog.dialog('open');
}

function MostrarFormRestrablecer(url) {
    var page = $("#UrlSolicitudPassword").val();
    var $dialog = $('<div id="internalWindow"></div>')
           .html('<iframe style="border: 0px; " src="' + url + '" width="100%" height="100%" style="overflow:none"></iframe>')
           .dialog({
               autoOpen: false,
               modal: true,
               height: 400,
               width: 530,
               title: "Restablecer Contrase&#241;a",
               resizable: false,
               open: function (event, ui) {
                   $(this).css('overflow', 'hidden'); //this line does the actual hiding
               }
           });
    $dialog.dialog('open');
}