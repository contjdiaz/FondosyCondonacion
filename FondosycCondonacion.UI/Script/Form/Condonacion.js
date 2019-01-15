$(function () {
    $("#txtFecha").datepicker({ dateFormat: 'dd/mm/yy', nextText: "", prevText: "", changeMonth: true, changeYear: true }).mask("99/99/9999");
    //$("#txtFechaFin").datepicker({ dateFormat: 'dd/mm/yy', nextText: "", prevText: "", changeMonth: true, changeYear: true, maxDate: '0' }).mask("99/99/9999");

    $(document).find('body').append('<div title="Resultado" id="MensajeGenerico"></div>');

    $('#MensajeGenerico').dialog({
        autoOpen: false,
        bgiframe: true,
        resizable: true,
        height: 200,
        width: 400,
        show: 'fade',
        closeText: "Cerrar",
        modal: true,
        buttons: {
            "Aceptar": function () {
                $(this).dialog("close");
            },
            "Cancelar": function () {
                $(this).dialog("close");
            }
        }
    });
});

function LimpiarControles() {
    $("#txtFecha").val("");
    $("#fulDocumentoAval").val("");
}

var validFilesTypes = ["pdf"];
var validFileSize;

function CheckFileWithSize(file, size) {
    validFileSize = size * 1024;
    var isValidFile = CheckExtension(file);

    if (isValidFile)
        isValidFile = CheckFileSize(file);

    return isValidFile;
}

function CheckExtension(file) {
    var filePath = file.value;
    var ext = filePath.substring(filePath.lastIndexOf('.') + 1).toLowerCase();
    var isValidFile = false;

    for (var i = 0; i < validFilesTypes.length; i++) {
        if (ext == validFilesTypes[i]) {
            isValidFile = true;
            break;
        }
    }

    if (!isValidFile) {
        file.value = null;
        $('#MensajeGenerico').html("El formato del documento no es .pdf");
        $('#MensajeGenerico').dialog('open');

        return false;
    }

    return isValidFile;
}

function CheckFileSize(file) {
    var fileSize = file.files[0].size;
    var isValidFile = false;

    if (fileSize !== 0 && fileSize <= validFileSize) {
        isValidFile = true;
    }
    else {
        file.value = null;

        if (validFileSize == 1024000) {
            $('#MensajeGenerico').html("El archivo no puede ser mayor a 1MB.");
        }
        else if (validFileSize == 2048000) {
            $('#MensajeGenerico').html("El archivo no puede ser mayor a 2MB.");
        }
        else if (validFileSize == 4096000) {
            $('#MensajeGenerico').html("El archivo no puede ser mayor a 4MB.");
        }
        $('#MensajeGenerico').dialog('open');
    }
    return isValidFile;
}

function ValidarCampos() {
    if (validaFechaDDMMAAAA($("#txtFecha").val())) {
        $('#rqtxtFecha').css('visibility', 'hidden');
        return true;
    }
    else {
        $('#rqtxtFecha').css('visibility', 'visible');
        return false;
    }
}

//function ValidarCamposCond() {
//    if (validaFechaDDMMAAAA($("#txtFechaFin").val())) {
//        $('#rqtxtFechaFin').css('visibility', 'hidden');
//        return true;
//    }
//    else {
//        $('#rqtxtFechaFin').css('visibility', 'visible');
//        return false;
//    }
//}

function LimpiarControlesCond() {
    $("#txtVideoYoutube").val("");
    $("#fulCertifPermEstado").val("");
    $("#fulCertifPromNotas").val("");
    $("#fulCertifProgCursado").val("");
    $("#fulCertifDiploma").val("");
    $("#fulCertifSoporte").val("");
    $("#fulCertifFormato").val("");
    $("#fulCertifFinMaterias").val("");
    $("#fulCertifDocRequer").val("");
    $("#fulCertifDocSubsanacion").val("");
}