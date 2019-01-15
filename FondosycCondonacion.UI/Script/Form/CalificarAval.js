$(function () {
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

    if ($('#resumen_activo').val() == "1") {
        if ($('#resumen_archivo_valido').val() == "1") {
            $('#resumen_archivo_valido').val("");
        }
        else if ($('#resumen_archivo_valido').val() == "0") {
            $('#resumen_archivo_valido').val("");
        }
    }
});

var validFilesTypes = ["xls", "xlsx"];
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
        $('#MensajeGenerico').html("El formato del documento no es xls o xlsx.");
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
        $('#MensajeGenerico').html("El archivo no puede ser mayor a 10MB.");
        $('#MensajeGenerico').dialog('open');
    }
    return isValidFile;
}

function verificar() {
    var validador = false;

    if ($('#fulDocumento').val() != "") {
        $('#rqfulDocumento').css('visibility', 'hidden');
        validador = true;
    }
    else {
        $('#rqfulDocumento').css('visibility', 'visible');
        validador = false;
    }

    if (validador == true) {
        $('#lnkCargar').hide();
        $("#allScreen").css('visibility', 'visible');
        $("#divProceso").css('visibility', 'visible');
        return true;
    }
    else {
        $("#allScreen").css('visibility', 'hidden');
        $("#divProceso").css('visibility', 'hidden');
        return false;
    }
}

function verificarPuntaje() {
    var validador = false;

    if ($('#fulDocumentoPuntaje').val() != "") {
        $('#rqfulDocumentoPuntaje').css('visibility', 'hidden');
        validador = true;
    }
    else {
        $('#rqfulDocumentoPuntaje').css('visibility', 'visible');
        validador = false;
    }

    if (validador == true) {
        $('#lnkCargarPuntaje').hide();
        $("#allScreen").css('visibility', 'visible');
        $("#divProceso").css('visibility', 'visible');
        return true;
    }
    else {
        $("#allScreen").css('visibility', 'hidden');
        $("#divProceso").css('visibility', 'hidden');
        return false;
    }
}