<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcEspecializacion2.ascx.cs" Inherits="FondosycCondonacion.UI.Condonacion.UcEspecializacion2" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Explicacion de Condonacion - Especialización</title>
    <script>
        $(function () {
            $("#accordion").accordion(
                {
                    heightStyle: "content",
                    active: false, collapsible: true
                });
        });

        function FindSection(valor) {
            $("#accordion").accordion({
                active: valor,
                activate: function (event, ui) {
                    var scrollTop = $("#accordion").scrollTop();
                    if (!ui.newHeader.length) { return };
                    var top = $(ui.newHeader).offset().top;
                    $("html,body").animate({
                        scrollTop: scrollTop + top - 35
                    }, "fast" /*slow*/);
                }
            });
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            font-weight: normal;
        }

        p.MsoNormal {
            margin-top: 0cm;
            margin-right: 0cm;
            margin-bottom: 10.0pt;
            margin-left: 0cm;
            line-height: 115%;
            font-size: 11.0pt;
            font-family: "Calibri",sans-serif;
        }
    </style>
</head>
<body>
    <br />
    <div style="text-align: center;">
        <img src="../Images/ExplicativoCondonacionEspecializacion.png" usemap="#mapImgEsp1">
        <map name="mapImgEsp1">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="245,145,368,191" shape="rect" onclick="FindSection(0)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="243,212,369,259" shape="rect" onclick="FindSection(1)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="9,288,85,334" shape="rect" onclick="FindSection(2)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="89,288,166,333" shape="rect" onclick="FindSection(3)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="170,288,261,334" shape="rect" onclick="FindSection(4)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="266,288,357,333" shape="rect" onclick="FindSection(5)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="361,288,481,334" shape="rect" onclick="FindSection(6)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="486,288,605,334" shape="rect" onclick="FindSection(7)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="239,446,372,527" shape="rect" onclick="FindSection(8)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="306,539,228,573,305,611,385,574" shape="poly" onclick="FindSection(9)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="61,548,158,605" shape="rect" onclick="FindSection(10)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="239,631,363,676" shape="rect" onclick="FindSection(11)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="132,730,471,775" shape="rect" onclick="FindSection(12)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="8,805,85,851" shape="rect" onclick="FindSection(13)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="89,804,166,851" shape="rect" onclick="FindSection(14)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="171,806,261,851" shape="rect" onclick="FindSection(15)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="266,805,356,851" shape="rect" onclick="FindSection(16)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="361,805,481,851" shape="rect" onclick="FindSection(17)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="485,805,605,851" shape="rect" onclick="FindSection(18)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="132,974,472,1020" shape="rect" onclick="FindSection(19)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="9,1042,81,1088" shape="rect" onclick="FindSection(20)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="85,1043,157,1087" shape="rect" onclick="FindSection(21)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="162,1043,245,1087" shape="rect" onclick="FindSection(22)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="251,1043,335,1087" shape="rect" onclick="FindSection(23)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="341,1043,425,1087" shape="rect" onclick="FindSection(24)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="430,1042,515,1087" shape="rect" onclick="FindSection(25)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="521,1043,605,1088" shape="rect" onclick="FindSection(26)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="239,1109,372,1189" shape="rect" onclick="FindSection(27)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="307,1206,385,1243,305,1280,227,1242" shape="poly" onclick="FindSection(28)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="61,1214,159,1272" shape="rect" onclick="FindSection(29)">
            <area target="_self" alt="Ver información" title="Ver información" style="cursor: pointer;" coords="239,1310,364,1359" shape="rect" onclick="FindSection(30)">
        </map>
    </div>
    <br />
    <div id="accordion">
        <h3><b>1. Ingresar a la Plataforma de Condonación del ICETEX</b></h3>
        <div align="left">
            <p>
                El ingreso a la plataforma web dispuesta por el ICETEX para atender los temas de condonación de la Convocatoria, requiere para acceder, el mismo usuario y contraseña registrados ante el ICETEX para todos los trámites de su crédito condonable, Estados de Cuenta, Renovaciones, etc. En caso de no tener un usuario registrado deberá hacerlo a través de la opción "¿No se ha registrado? Hágalo aquí".
                El link a través del cual podrá acceder a la plataforma es:
            </p>
            <p>
                <a style="background-color: #fff; color: #0000EE; text-decoration: underline;" target="_blank" href="http://www.icetex.gov.co/dnnpro5/es-co/fondos/fondosparaeldesarrollodeti/segundaconvocatoriadegobiernoelectr%c3%b3nico.aspx">http://www.icetex.gov.co/dnnpro5/es-co/fondos/fondosparaeldesarrollodeti/segundaconvocatoriadegobiernoelectr%c3%b3nico.aspx</a>
            </p>
        </div>
        <h3><b>2. Seleccionar la Opción de condonación</b></h3>
        <div align="left">
            <p>
                Cada beneficiario que haya cursado una <b>especialización</b> debe obligatoriamente cumplir <b>solo con UNO (1) de los requisitos que se listan a continuación</b>:
            </p>
            <p style="margin-left: 40px">
                2.1 Documentar dos (2) experiencias de Innovación en Gobierno Electrónico con su respectivo análisis<br />
                2.2 Documentar tres (3) experiencias de Innovación en Gobierno Electrónico (No requieren análisis).<br />
                2.3 Realizar y acreditar horas de práctica en una Entidad del Estado.<br />
                2.4 Impartir y acreditar horas de capacitación en una Entidad del Estado.<br />
                2.5 Realizar proyecto de grado dirigido por la Institución Universitaria que aplique a una Entidad del Estado.<br />
                2.6 Realizar proyecto, estudio, investigación o desarrollo que aplique a una Entidad del Estado.<br />
            </p>
        </div>
        <h3 class="auto-style1"><strong>2.1 Documentar dos (2) experiencias de Innovación en Gobierno Electrónico con su respectivo análisis.</strong></h3>
        <div align="left">
            <p>
                <b>Documentar</b> dos (2) experiencias de Innovación en Gobierno Electrónico, cada una de ellas debe contar con su respectivo <b>análisis</b>, bajo la metodología del Centro de Innovación Pública Digital del Ministerio de TIC (o quien haga sus veces) de acuerdo con los documentos específicos presentados en el Anexo 2A - Guía para la Elaboración de Videos, Anexo 2B - Formato para la Documentación de Experiencias  y Anexo 2C – Formato para el Análisis de Experiencias, y que fueron proporcionados en los términos de la Segunda Convocatoria de Gobierno Electrónico .

                <br />
                <br />
                <b>•	Condiciones, evidencias y documentos previos para iniciar el desarrollo del requisito:</b>

                <br />
                <br />
                1)	Contando con la autorización por parte del Centro de Innovación Pública Digital (o quien haga sus veces) del Ministerio TIC, a través del Anexo No. 05: "AUTORIZACIÓN EXPEDIDA POR EL CENTRO DE INNOVACIÓN PÚBLICA DIGITAL PARA INICIAR CON EL DESARROLLO DEL REQUISITO ADICIONAL (EXPERIENCIAS) QUE PERMITIRÁ EL CUMPLIMIENTO DE UN REQUISITO DE CONDONACIÓN DE LA SEGUNDA CONVOCATORIA DE GOBIERNO ELECTRÓNICO". El citado anexo deberá incluir los siguientes datos:
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(a)	Nombre de la experiencia
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(b)	Ciudad y país de la experiencia
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(c)	Entidad que desarrolla la experiencia
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(d)	Experiencia relacionada con: 
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;•	Prestación de servicios digitales: Si ___	No ___
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;•	Gestión interna de una entidad del estado con uso de las TIC: Si __No _
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;•	Gobierno abierto digital: Si ___	No ___
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;•	Respuesta a problemáticas públicas con uso de las TIC: Si __No ___
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(e)	Descripción de la experiencia: 
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(f)	Fecha de inicio de implementación de la Experiencia (Día/Mes/Año): 
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(g)	Relación de la Experiencia con innovación pública digital
                <br />
                2)	Teniendo el aval aprobado a través de la plataforma web de Condonación del ICETEX. El aval es otorgado por la Junta Administradora del Fondo de Promoción de Gobierno y Empresa TI previa verificación del diligenciamiento y firma del anexo citado en el numeral anterior.
                <br />
                3)	Asegurándose de prever oportunamente las condiciones requeridas para la entrega y uso (financieras, legales, de uso, etc.) de la totalidad del proyecto.
            </p>
        </div>
        <h3><b>2.2 Documentar tres (3) experiencias de Innovación en Gobierno Electrónico.</b></h3>
        <div align="left">
            <p>
                Documentar tres (3) experiencias de Innovación en Gobierno Electrónico, bajo la metodología del Centro de Innovación Pública Digital, y empleando los formatos Anexo 2A - Guía para la Elaboración de Videos y Anexo 2B - Formato para la Documentación de Experiencias. <b>Esta opción NO incluye elaboración de análisis.</b>

                <br />
                <br />
                <b>•	Condiciones, evidencias y documentos previos para iniciar el desarrollo del requisito:</b>

                <br />
                <br />
                1)	Contando con la autorización por parte del Centro de Innovación Pública Digital (o quien haga sus veces) del Ministerio TIC, a través del Anexo No. 05: "AUTORIZACIÓN EXPEDIDA POR EL CENTRO DE INNOVACIÓN PÚBLICA DIGITAL PARA INICIAR CON EL DESARROLLO DEL REQUISITO ADICIONAL (EXPERIENCIAS) QUE PERMITIRÁ EL CUMPLIMIENTO DE UN REQUISITO DE CONDONACIÓN DE LA SEGUNDA CONVOCATORIA DE GOBIERNO ELECTRÓNICO". El citado anexo deberá incluir los siguientes datos:
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(a)	Nombre de la experiencia
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(b)	Ciudad y país de la experiencia
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(c)	Entidad que desarrolla la experiencia
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(d)	Experiencia relacionada con: 
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;•	Prestación de servicios digitales: Si ___	No ___
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;•	Gestión interna de una entidad del estado con uso de las TIC: Si __No _
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;•	Gobierno abierto digital: Si ___	No ___
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;•	Respuesta a problemáticas públicas con uso de las TIC: Si __No ___
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(e)	Descripción de la experiencia: 
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(f)	Fecha de inicio de implementación de la Experiencia (Día/Mes/Año): 
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(g)	Relación de la Experiencia con innovación pública digital
                <br />
                2)	Teniendo la aprobación del aval a través de la plataforma web de Condonación del ICETEX. El aval es otorgado por la Junta Administradora del Fondo de Promoción de Gobierno y Empresa TI previa verificación del diligenciamiento y firma del anexo citado en el numeral anterior.
                <br />
                3)	Asegurándose de prever oportunamente las condiciones requeridas para la entrega y uso (financieras, legales, de uso, etc.) de la totalidad del proyecto.
                
            </p>
        </div>
        <h3><b>2.3 Realizar y acreditar horas de práctica en una Entidad del Estado.</b></h3>
        <div align="left">
            <p>
                El beneficiario del crédito condonable debe cumplir con 220 horas en desarrollo de actividades de asesoría, acompañamiento o sensibilización, para transferencia de conocimiento y mejora de competencias, en temas relacionados con el Programa Académico cursado y en relación con la Estrategia de Gobierno en Línea o TI, diferentes de las responsabilidades propias del cargo o contrato.<br />
                <br />

                En todos los casos la temática debe estar debidamente aceptada por la Entidad del Estado beneficiaria, por lo que debe articularse desde un principio con las instancias del caso en la Entidad.<br />
                <br />

                <b>•	Condiciones, evidencias y documentos previos para iniciar el desarrollo del requisito:</b><br />
                <br />

                1)	Contando con la autorización por parte de la Entidad en donde se revierte el conocimiento adquirido en desarrollo del programa académico. Lo anterior, a través del Anexo No. 03: “AUTORIZACIÓN EXPEDIDA POR ENTIDAD DEL ESTADO PARA INICIAR CON EL DESARROLLO DEL REQUISITO ADICIONAL QUE PERMITIRÁ EL CUMPLIMIENTO DE UN REQUISITO DE CONDONACIÓN DE LA SEGUNDA CONVOCATORIA DE GOBIERNO ELECTRÓNICO”. El citado anexo deberá incluir los siguientes datos:<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(a)	Descripción del tema de la asesoría, acompañamiento o sensibilización.<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(b)	Justificación de la asesoría, acompañamiento o sensibilización (razón de ser).<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(c)	Pertinencia del tema (asesoría, acompañamiento o sensibilización) en relación con la Estrategia de Gobierno en Línea.<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(d)	Objetivo general y objetivos específicos.<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(e)	Alcance, enfoque y actores implicados.<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(f)	Metodología.<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(g)	Fuentes de información.<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(h)	Actividades o tareas a realizar.<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(i)	Productos e informes a entregar a la Entidad.<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(j)	Recursos y facilidades a ser provistos por los actores.<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(k)	Cronograma planeado.<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(l)	Fecha planeada de finalización (Día/Mes/Año).<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(m)	Bibliografía.<br />
                2)	Teniendo la aprobación del aval a través de la plataforma web de Condonación del ICETEX. El aval es otorgado por la Junta Administradora del Fondo de Promoción de Gobierno y Empresa TI previa verificación del diligenciamiento y firma del anexo citado en el numeral anterior.<br />
                3)	Asegurándose de prever oportunamente las condiciones requeridas para la entrega y uso (financieras, legales, de uso, etc.) de la totalidad del proyecto.
            </p>
        </div>
        <h3><b>2.4 Impartir y acreditar horas de capacitación en una Entidad del Estado.</b></h3>
        <div align="left">
            <p>
                El beneficiario del crédito condonable debe cumplir con 220 horas en desarrollo de capacitaciones a por lo menos quince (15) personas de una Entidad del Estado, en temas del Programa Académico cursado y en relación con la Estrategia de Gobierno en Línea o TI.<br />
                <br />
                En todos los casos la temática debe estar debidamente aceptada por la Entidad del Estado beneficiaria, por lo que debe articularse desde un principio con las instancias del caso en la Entidad.<br />
                <br />
                <b>•	Condiciones, evidencias y documentos previos para iniciar el desarrollo del requisito:</b><br />
                <br />
                1)	Contando con la autorización por parte de la Entidad en donde se revierte el conocimiento adquirido en desarrollo del programa académico. Lo anterior, a través del Anexo No. 03: “AUTORIZACIÓN EXPEDIDA POR ENTIDAD DEL ESTADO PARA INICIAR CON EL DESARROLLO DEL REQUISITO ADICIONAL QUE PERMITIRÁ EL CUMPLIMIENTO DE UN REQUISITO DE CONDONACIÓN DE LA SEGUNDA CONVOCATORIA DE GOBIERNO ELECTRÓNICO”. El citado anexo deberá incluir los siguientes datos:
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(a)	Descripción del tema de la capacitación.<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(b)	Justificación de la capacitación (razón de ser de la capacitación).<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(c)	Pertinencia del tema de la capacitación en relación con la Estrategia de Gobierno en Línea.<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(d)	Preguntas problémicas de la capacitación (las preguntas que deben quedar resueltas y tratadas durante la capacitación).<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(e)	Descripción del público objetivo que se planea capacitar.<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(f)	Tabla de contenido o temario de la capacitación.<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(g)	Cronograma planeado de acuerdo con el contenido o temario.<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(h)	Fecha planeada de finalización (Día/Mes/Año).<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(i)	Estrategias metodológicas (Clases magistrales, consultas, lecturas, proyectos, estudios de casos, seguimiento a noticias relacionadas, trabajos dirigidos, ensayos, mapas &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;conceptuales, exposiciones, puestas en común, participación en clase, entre otros).<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(j)	Seguimiento y evaluación (Control de lecturas, participación en clase, seguimiento a noticias, trabajos / tareas, exposiciones, pruebas escritas u orales, entre otras).<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(k)	Productos e informes a entregar a la Entidad beneficiaria.<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(l)	Bibliografía.<br />
                2)	Contando con la autorización por parte del Ministerio de TIC - Dirección de Gobierno en Línea (o quien haga sus veces), en relación con la temática acorde con la Estrategia de Gobierno en Línea. En este caso, la Dirección de Gobierno en Línea podrá poner a disposición de los beneficiarios la posibilidad de impartir capacitaciones requeridas por diversas Entidades del Estado y que son lideradas por la Coordinación de Apropiación de la citada Dirección. Para tal efecto se realizarán convocatorias específicas y con cupos limitados, que serán públicas para los beneficiarios, de acuerdo con perfiles, requerimientos y condiciones especiales. Esta autorización reemplazaría la descrita en el ítem No. 1.<br />
                3)	Teniendo la aprobación del aval a través de la plataforma web de Condonación del ICETEX. El aval es otorgado por la Junta Administradora del Fondo de Promoción de Gobierno y Empresa TI previa verificación del diligenciamiento y firma del anexo citado en el numeral anterior.<br />
                4)	Asegurándose de prever oportunamente las condiciones requeridas para la entrega y uso (financieras, legales, de uso, etc.) de la totalidad del proyecto.<br />
            </p>
        </div>
        <h3><b>2.5 Realizar proyecto de grado dirigido por la Institución Universitaria que aplique a una Entidad del Estado.</b></h3>
        <div align="left">
            <p>
                El beneficiario del crédito condonable debe realizar un Proyecto de Grado – el que le permite optar por el título en la Institución Universitaria: Tesis, Monografía, Proyecto Aplicado, entre otros, dirigido, guiado y avalado por la misma Institución, en temas con enfoque práctico o de investigación en Gobierno Electrónico o Gobierno en Línea, el cual pueda ser aplicado o sirva como aporte a una Entidad del Estado.<br />
                <br />
                En todos los casos la temática debe estar debidamente aceptada por la Entidad del Estado beneficiaria, por lo que debe articularse desde un principio con las instancias del caso en la Entidad. También desde un principio debe estar debidamente aceptada por la Universidad.<br />
                <br />
                <b>•	Condiciones, evidencias y documentos previos para iniciar el desarrollo del requisito:</b><br />
                <br />
                1)	Contando con la autorización por parte de la Entidad en donde se revierte el conocimiento adquirido en desarrollo del programa académico. Lo anterior, a través del Anexo No. 04: “AUTORIZACIÓN EXPEDIDA POR INSTITUCIÓN EDUCATIVA Y ENTIDAD DEL ESTADO PARA INICIAR CON EL PROYECTO DE GRADO QUE PERMITIRÁ EL CUMPLIMIENTO DE UN REQUISITO DE CONDONACIÓN DE LA SEGUNDA CONVOCATORIA DE GOBIERNO ELECTRÓNICO”. El citado anexo deberá incluir los siguientes datos:<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(a)	Tipo de Proyecto de Grado a realizar (Tesis, Monografía, Proyecto, Aplicación u otro).
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(b)	Nombre propuesto para el Proyecto de Grado.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(c)	Descripción (síntesis) del Proyecto de Grado.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(d)	Objetivo general y objetivos específicos.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(e)	Entidad del Estado que se beneficiará con el Proyecto.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(f)	Área de la Entidad del Estado que se beneficiará con el Proyecto.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(g)	Productos a entregar, con sus características, a la Entidad beneficiaria.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(h)	Pertinencia del proyecto en relación con la Estrategia de Gobierno en Línea.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(i)	Fecha planeada de finalización (Día/Mes/Año).
                    <br />
                2)	Teniendo la aprobación del aval a través de la plataforma web de Condonación del ICETEX.  El aval es otorgado por la Junta Administradora del Fondo de Promoción de Gobierno y Empresa TI previa verificación del diligenciamiento y firma del anexo citado en el numeral anterior. 
                    <br />
                3)	Asegurándose de prever oportunamente las condiciones requeridas para la entrega y uso (financieras, legales, de uso, etc.) de la totalidad del proyecto.
            </p>
        </div>
        <h3><b>2.6 Realizar proyecto, estudio, investigación o desarrollo que aplique a una Entidad del Estado.</b></h3>
        <div align="left">
            <p>
                El beneficiario del crédito condonable debe realizar un proyecto, estudio, investigación o desarrollo en temáticas de Gobierno Electrónico o Gobierno en Línea, dirigido por una Entidad del Estado y que sea aplicado o aporte a la misma Entidad.<br />
                <br />
                En todos los casos la temática debe estar debidamente aceptada por la Entidad del Estado beneficiaria, por lo que debe articularse desde un principio con las instancias del caso en la Entidad.<br />
                <br />
                <b>•	Condiciones, evidencias y documentos previos para iniciar el desarrollo del requisito:</b><br />
                <br />
                1)	Contando con la autorización por parte de la Entidad en donde se revierte el conocimiento adquirido en desarrollo del programa académico. Lo anterior, a través del Anexo No. 03: “AUTORIZACIÓN EXPEDIDA POR ENTIDAD DEL ESTADO PARA INICIAR CON EL DESARROLLO DEL REQUISITO ADICIONAL QUE PERMITIRÁ EL CUMPLIMIENTO DE UN REQUISITO DE CONDONACIÓN DE LA SEGUNDA CONVOCATORIA DE GOBIERNO ELECTRÓNICO”. El citado anexo deberá incluir los siguientes datos: 
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(a)	Tipo de trabajo a realizar (proyecto, estudio, investigación o desarrollo).
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(b)	Nombre propuesto del proyecto, estudio, investigación o desarrollo a realizar.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(c)	Descripción (síntesis) del proyecto, estudio, investigación o desarrollo a realizar.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(d)	Objetivo general y objetivos específicos.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(e)	Entidad del Estado que se beneficiará con el Proyecto.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(f)	Área de la Entidad del Estado que se beneficiará con el Proyecto.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(g)	Productos a entregar, con sus características, a la Entidad beneficiaria.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(h)	Pertinencia del proyecto, estudio, investigación o desarrollo en relación con la Estrategia de Gobierno en Línea.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(i)	Fecha planeada de finalización (Día/Mes/Año).
                    <br />
                2)	Teniendo la aprobación del aval a través de la plataforma web de Condonación del ICETEX. El aval es otorgado por la Junta Administradora del Fondo de Promoción de Gobierno y Empresa TI previa verificación del diligenciamiento y firma del anexo citado en el numeral anterior.
                    <br />
                3)	Asegurándose de prever oportunamente las condiciones requeridas para la entrega y uso (financieras, legales, de uso, etc.) de la totalidad del proyecto.
            </p>
        </div>
        <h3><b>3. En la plataforma cargar Anexo y Radicar solicitud de Aval</b></h3>
        <div align="left">
            <p>
                El aval descrito en este documento es obligatorio para dar inicio al desarrollo del requisito adicional de condonación y tiene como finalidad articular al Beneficiario con la Entidad del Estado donde revertirá el conocimiento, además de articular con la Universidad, el Centro de Innovación Pública Digital y el Ministerio de TIC, según sea la opción escogida. Es necesario que todos los actores interesados / involucrados tengan conocimiento y definiciones sobre el alcance que tendrá el proyecto o los entregables, cronogramas y responsables, entre otros.<br />
                <br />
                En la solicitud de aval es requisito contar la autorización que emiten las partes que intervienen en la opción elegida por el beneficiario dentro de los requisitos dispuestos como Adicionales para la condonación. Lo anterior se establece a través del diligenciamiento y firma de un anexo (formato) definido como autorización de acuerdo con la opción de condonación seleccionada. Esto se encuentra definido de la siguiente manera:<br />
                <br />
                <b>En Especializaciones: </b>
                <br />
                <%--<br />--%>
                <center>
                    <table border="1" cellpadding="0" cellspacing="0" class="MsoTableGrid" style="width: 441.4pt; border-collapse: collapse; border: none; mso-border-alt: solid black .5pt; mso-yfti-tbllook: 1184; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt;"
                        width="589" align="center">
                        <tr style="mso-yfti-irow: 0; mso-yfti-firstrow: yes; height: 19.05pt">
                            <td style="width: 134.45pt; border: solid black 1.0pt; mso-border-alt: solid black .5pt; background: #FABF8F; mso-background-themecolor: accent6; mso-background-themetint: 153; padding: 0cm 5.4pt 0cm 5.4pt; height: 19.05pt" width="179">
                                <p class="MsoNormal" style="margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 14.2pt; margin-bottom: .0001pt; text-align: justify; line-height: normal">
                                    <span style="font-size: 10.0pt; font-family: &quot; century gothic&quot; ,sans-serif; mso-fareast-language: ES-CO"><span style="mso-spacerun: yes">&nbsp;</span><b style="mso-bidi-font-weight: normal">Requisito Adicional
                                        <o:p></o:p>
                                    </b></span>
                                </p>
                            </td>
                            <td style="width: 306.95pt; border: solid black 1.0pt; border-left: none; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; background: #FABF8F; mso-background-themecolor: accent6; mso-background-themetint: 153; padding: 0cm 5.4pt 0cm 5.4pt; height: 19.05pt" width="409">
                                <p align="center" class="MsoNormal" style="margin-bottom: 0cm; margin-bottom: .0001pt; text-align: center; line-height: normal">
                                    <b style="mso-bidi-font-weight: normal"><span style="font-size: 10.0pt; font-family: &quot; century gothic&quot; ,sans-serif; mso-fareast-language: ES-CO">Diligenciar<o:p></o:p></span></b>
                                </p>
                            </td>
                        </tr>
                        <tr style="mso-yfti-irow: 1; height: 17.0pt">
                            <td style="width: 134.45pt; border: solid black 1.0pt; border-top: none; mso-border-top-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 17.0pt"
                                width="179">
                                <p class="MsoNormal" style="margin-bottom: 0cm; margin-bottom: .0001pt; line-height: normal">
                                    <span style="font-size: 10.0pt; font-family: &quot; century gothic&quot; ,sans-serif; mso-fareast-language: ES-CO" class="auto-style1">2.1 Documentar Experiencias con Análisis<o:p></o:p></span>
                                </p>
                            </td>
                            <td style="width: 306.95pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 17.0pt"
                                width="409">
                                <p class="MsoNormal" style="margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 1.75pt; margin-bottom: .0001pt; text-align: justify; line-height: normal">
                                    <span lang="ES-MX" style="font-size: 10.0pt; font-family: &quot; century gothic&quot; ,sans-serif; mso-bidi-font-family: Arial; mso-ansi-language: ES-MX; mso-fareast-language: ES-CO; mso-bidi-font-weight: bold" class="auto-style1">Anexo No. 05: &quot;AUTORIZACIÓN PARA EXPERIENCIAS EXPEDIDA POR EL CENTRO DE INNOVACIÓN PÚBLICA DIGITAL”</span><b style="mso-bidi-font-weight: normal"><span style="font-size: 10.0pt; font-family: &quot; century gothic&quot; ,sans-serif; mso-fareast-language: ES-CO"><o:p></o:p></span></b><span class="auto-style1"> </span>
                                </p>
                            </td>
                        </tr>
                        <tr style="mso-yfti-irow: 2; height: 17.0pt">
                            <td style="width: 134.45pt; border: solid black 1.0pt; border-top: none; mso-border-top-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 17.0pt"
                                width="179">
                                <p class="MsoNormal" style="margin-bottom: 0cm; margin-bottom: .0001pt; line-height: normal">
                                    <span style="font-size: 10.0pt; font-family: &quot; century gothic&quot; ,sans-serif; mso-fareast-language: ES-CO"><span class="auto-style1">2.2 Documentar Experiencias sin Análisis</span><b style="mso-bidi-font-weight: normal"><o:p></o:p></b></span>
                                </p>
                            </td>
                            <td style="width: 306.95pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 17.0pt"
                                width="409">
                                <p class="MsoNormal" style="margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 1.75pt; margin-bottom: .0001pt; text-align: justify; line-height: normal">
                                    <span lang="ES-MX" style="font-size: 10.0pt; font-family: &quot; century gothic&quot; ,sans-serif; mso-bidi-font-family: Arial; mso-ansi-language: ES-MX; mso-fareast-language: ES-CO; mso-bidi-font-weight: bold" class="auto-style1">Anexo No. 05: &quot;AUTORIZACIÓN PARA EXPERIENCIAS EXPEDIDA POR EL CENTRO DE INNOVACIÓN PÚBLICA DIGITAL”</span><b style="mso-bidi-font-weight: normal"><span lang="ES-MX" style="font-size: 10.0pt; font-family: &quot; century gothic&quot; ,sans-serif; mso-ansi-language: ES-MX; mso-fareast-language: ES-CO"><o:p></o:p></span></b><span class="auto-style1"> </span>
                                </p>
                            </td>
                        </tr>
                        <tr style="mso-yfti-irow: 3; height: 17.0pt">
                            <td style="width: 134.45pt; border: solid black 1.0pt; border-top: none; mso-border-top-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 17.0pt"
                                width="179">
                                <p class="MsoNormal" style="margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 1.1pt; margin-bottom: .0001pt; line-height: normal">
                                    <span style="font-size: 10.0pt; font-family: &quot; century gothic&quot; ,sans-serif; mso-fareast-language: ES-CO"><span class="auto-style1">2.3 Asesoría</span><b style="mso-bidi-font-weight: normal"><o:p></o:p></b></span>
                                </p>
                            </td>
                            <td style="width: 306.95pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 17.0pt"
                                width="409">
                                <p class="MsoNormal" style="margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 1.75pt; margin-bottom: .0001pt; text-align: justify; line-height: normal">
                                    <span lang="ES-MX" style="font-size: 10.0pt; font-family: &quot; century gothic&quot; ,sans-serif; mso-bidi-font-family: Arial; mso-ansi-language: ES-MX; mso-fareast-language: ES-CO; mso-bidi-font-weight: bold" class="auto-style1">Anexo No. 03: “AUTORIZACIÓN EXPEDIDA POR ENTIDAD DEL ESTADO”</span><b style="mso-bidi-font-weight: normal"><span style="font-size: 10.0pt; font-family: &quot; century gothic&quot; ,sans-serif; mso-fareast-language: ES-CO"><o:p></o:p></span></b><span class="auto-style1"> </span>
                                </p>
                            </td>
                        </tr>
                        <tr style="mso-yfti-irow: 4; height: 17.0pt">
                            <td style="width: 134.45pt; border: solid black 1.0pt; border-top: none; mso-border-top-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 17.0pt"
                                width="179">
                                <p class="MsoNormal" style="margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: -6.0pt; margin-bottom: .0001pt; text-indent: 7.1pt; line-height: normal">
                                    <span style="font-size: 10.0pt; font-family: &quot; century gothic&quot; ,sans-serif; mso-fareast-language: ES-CO"><span class="auto-style1">2.4 Capacitación</span><b style="mso-bidi-font-weight: normal"><o:p></o:p></b></span>
                                </p>
                            </td>
                            <td style="width: 306.95pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 17.0pt"
                                width="409">
                                <p class="MsoNormal" style="margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 1.75pt; margin-bottom: .0001pt; text-align: justify; line-height: normal">
                                    <span lang="ES-MX" style="font-size: 10.0pt; font-family: &quot; century gothic&quot; ,sans-serif; mso-bidi-font-family: Arial; mso-ansi-language: ES-MX; mso-fareast-language: ES-CO; mso-bidi-font-weight: bold" class="auto-style1">Anexo No. 03: “AUTORIZACIÓN EXPEDIDA POR ENTIDAD DEL ESTADO”</span><b style="mso-bidi-font-weight: normal"><span style="font-size: 10.0pt; font-family: &quot; century gothic&quot; ,sans-serif; mso-fareast-language: ES-CO"><o:p></o:p></span></b><span class="auto-style1"> </span>
                                </p>
                            </td>
                        </tr>
                        <tr style="mso-yfti-irow: 5; height: 17.0pt">
                            <td style="width: 134.45pt; border: solid black 1.0pt; border-top: none; mso-border-top-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 17.0pt"
                                width="179">
                                <p class="MsoNormal" style="margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 1.1pt; margin-bottom: .0001pt; text-indent: -1.1pt; line-height: normal">
                                    <span style="font-size: 10.0pt; font-family: &quot; century gothic&quot; ,sans-serif; mso-fareast-language: ES-CO" class="auto-style1">2.5 Proyecto dirigido por la Universidad - Entidad<o:p></o:p></span>
                                </p>
                            </td>
                            <td style="width: 306.95pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 17.0pt"
                                width="409">
                                <p class="MsoNormal" style="margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 1.75pt; margin-bottom: .0001pt; text-align: justify; line-height: normal">
                                    <span lang="ES-MX" style="font-size: 10.0pt; font-family: &quot; century gothic&quot; ,sans-serif; mso-bidi-font-family: Arial; mso-ansi-language: ES-MX; mso-fareast-language: ES-CO; mso-bidi-font-weight: bold" class="auto-style1">Anexo No. 04: “AUTORIZACIÓN EXPEDIDA POR INSTITUCIÓN EDUCATIVA Y ENTIDAD DEL ESTADO</span><b style="mso-bidi-font-weight: normal"><span style="font-size: 10.0pt; font-family: &quot; century gothic&quot; ,sans-serif; mso-fareast-language: ES-CO"><o:p></o:p></span></b><span class="auto-style1"> </span>
                                </p>
                            </td>
                        </tr>
                        <tr style="mso-yfti-irow: 6; mso-yfti-lastrow: yes; height: 17.0pt">
                            <td style="width: 134.45pt; border: solid black 1.0pt; border-top: none; mso-border-top-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 17.0pt"
                                width="179">
                                <p class="MsoNormal" style="margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 1.1pt; margin-bottom: .0001pt; line-height: normal">
                                    <span style="font-size: 10.0pt; font-family: &quot; century gothic&quot; ,sans-serif; mso-fareast-language: ES-CO"><span class="auto-style1">2.6 Proyecto dirigido y aplicado en la Entidad del Estado</span><b style="mso-bidi-font-weight: normal"><o:p></o:p></b></span>
                                </p>
                            </td>
                            <td style="width: 306.95pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 17.0pt"
                                width="409">
                                <p class="MsoNormal" style="margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 1.75pt; margin-bottom: .0001pt; text-align: justify; line-height: normal">
                                    <span lang="ES-MX" style="font-size: 10.0pt; font-family: &quot; century gothic&quot; ,sans-serif; mso-bidi-font-family: Arial; mso-ansi-language: ES-MX; mso-fareast-language: ES-CO; mso-bidi-font-weight: bold" class="auto-style1">Anexo No. 03: “AUTORIZACIÓN EXPEDIDA POR ENTIDAD DEL ESTADO”</span><b style="mso-bidi-font-weight: normal"><span style="font-size: 10.0pt; font-family: &quot; century gothic&quot; ,sans-serif; mso-fareast-language: ES-CO"><o:p></o:p></span></b><span class="auto-style1"> </span>
                                </p>
                            </td>
                        </tr>
                    </table>
                        </center>
                <br />
                Los anexos, deberán ser descargados de la plataforma web del ICETEX dispuesta para atender los temas de condonación de la Convocatoria. Dependiendo de la opción escogida, se descarga y diligencia el formato el cual deberá ser firmado tal y como se establece en cada uno de ellos, y luego escaneados en formato *.pdf, para ser cargados en la plataforma de condonación de la web del ICETEX. En la citada plataforma encontrará una pestaña llamada “AVAL”, en la cual podrá cargar sus documentos y radicar la solicitud de aval. Es necesario tomar nota del número de radicado con el fin de garantizar que la solicitud de aval se ha sido realizado correctamente.
            </p>
        </div>
        <h3><b>3.1 Notificación ¿Aval Aprobado?</b></h3>
        <div align="left">
            <p>
                La revisión de los documentos presentados, es realizado por la JUNTA ADMINISTRADORA del FONDO y consiste en la verificación del diligenciamiento y firma de los anexos de autorización que reflejan la articulación entre las diferentes partes involucradas en el desarrollo de la opción escogida. Así mismo, se tendrá en cuenta las Áreas de Estudio previstas en la convocatoria, el manual y las normas relacionadas con Gobierno en Línea y las necesidades de cada Entidad en dónde se revertirá el conocimiento.
                    <br />
                Las sesiones de la JUNTA se llevarán a cabo, según calendario que será publicado en la plataforma de condonación de la Segunda Convocatoria de Gobierno Electrónico en la web del ICETEX. A las sesiones de JUNTA podrán asistir los funcionarios o expertos del Ministerio de TIC que las partes (ICETEX y Ministerio de TIC), consideren necesarios para atender la revisión de la pertinencia de los temas propuestos por el beneficiario del crédito condonable.<br />
                <br />
                Para que una solicitud sea llevada a la JUNTA, deberá radicar sus documentos en la plataforma de condonación mínimo cuatro (4) días calendario antes de la fecha de la sesión de JUNTA. La respuesta sobre la pertinencia será informada al beneficiario a través de la misma plataforma de condonación, cuatro (4) días hábiles después de la sesión de la JUNTA. 
            </p>
        </div>
        <h3><b>3.2 Realizar Modificaciones y Ajustes </b></h3>
        <div align="left">
            <p>
                Cuando el aval de negado, el beneficiario deberá atender las recomendaciones realizadas por la Junta Administradora y deberá iniciar el proceso de esta etapa nuevamente generando una nueva solicitud y numero de radicado, adjuntando la documentación completa y cumpliendo con las recomendaciones efectuadas. Así mismo, la nueva solicitud estará sujeta a las fechas definidas en el calendario de las sesiones de Junta. 
            </p>
        </div>
        <h3><b>3.3 Ejecución del proyecto, asesoría u otra</b></h3>
        <div align="left">
            <p>
                Contando con el aval aprobado el Beneficiario podrá dar inicio al desarrollo de su requisito adicional de condonación. Es necesario tener la evidencia de la aprobación del aval y garantizar el cumplimiento de los ítems definidos en el Anexo de Autorización otorgado por la entidad del Estado, Institución Educativa o Centro de Innovación con el fin de evitar inconvenientes tanto en la condonación del crédito, como en la respectiva entrega que se deberá realizar a las partes que intervienen en la ejecución del proyecto y/o actividad.
                    <br />
                En caso de que se requiera realizar cambio de la opción escogida o modificación de alguna de las condiciones avaladas, el beneficiario deberá informarlo a través de los mecanismos dispuestos en la plataforma de condonación del ICETEX, planteando los motivos y las nuevas condiciones, de manera clara y completa, para revisión y decisión de la JUNTA ADMINISTRADORA del FONDO, según sea el caso.
                    <br />
                <br />
                Lo anterior, incluyendo, si es del caso, el diligenciamiento de los Anexos de este documento explicativo y la debida articulación y actualización con los actores participes en la opción adicional de condonación.
            </p>
        </div>
        <h3><b>4. Finalizada la ejecución del proyecto, asesoría u otra, gestionar el Recibido y Aceptación</b></h3>
        <div align="left">
            <p>
                Una vez desarrollada la opción adicional de condonación el Beneficiario deberá gestionar la entrega, recibo y aceptación en la Entidad del Estado, Institución Educativa y/o Centro de Innovación Pública Digital según sea el caso. Lo anterior se formaliza a través del diligenciamiento de los anexos 7, 8 o 9.
            </p>
        </div>
        <h3><b>4.1 Documentar dos (2) experiencias de Innovación en Gobierno Electrónico con su respectivo análisis.</b></h3>
        <div align="left">
            <p>
                <b>Condiciones, evidencias y documentos finales que acreditan el cumplimiento del requisito:</b><br />
                <br />
                Certificación de cumplimiento y entrega a satisfacción expedida por el Ministerio TIC -Centro de Innovación Pública Digital (o quien haga sus veces) Lo anterior, a través del Anexo No. 09: “CONSTANCIA DE RECIBO Y ACEPTACIÓN PARA EXPERIENCIAS EXPEDIDA POR EL CENTRO DE INNOVACIÓN PÚBLICA DIGITAL PARA LA CONDONACIÓN DE LA SEGUNDA CONVOCATORIA DE GOBIERNO ELECTRÓNICO”.
            </p>
        </div>
        <h3><b>4.2 Documentar tres (3) experiencias de Innovación en Gobierno Electrónico.</b></h3>
        <div align="left">
            <p>
                <b>Condiciones, evidencias y documentos finales que acreditan el cumplimiento del requisito:</b><br />
                <br />
                Certificación de cumplimiento y entrega a satisfacción expedida por el Ministerio TIC -Centro de Innovación Pública Digital (o quien haga sus veces) Lo anterior, a través del Anexo No. 09: “CONSTANCIA DE RECIBO Y ACEPTACIÓN PARA EXPERIENCIAS EXPEDIDA POR EL CENTRO DE INNOVACIÓN PÚBLICA DIGITAL PARA LA CONDONACIÓN DE LA SEGUNDA CONVOCATORIA DE GOBIERNO ELECTRÓNICO”.
            </p>
        </div>
        <h3><b>4.3 Realizar y acreditar horas de práctica en una Entidad del Estado.</b></h3>
        <div align="left">
            <p>
                <b>Condiciones, evidencias y documentos finales que acreditan el cumplimiento del requisito:</b><br />
                <br />
                Certificación de cumplimiento y entrega a satisfacción expedida por el área donde se desarrolló la asesoría, acompañamiento o sensibilización, de la Entidad beneficiaria. Lo anterior a través del Anexo No. 07: “CONSTANCIA DE RECIBO Y ACEPTACIÓN EXPEDIDA POR ENTIDAD DEL ESTADO PARA LA CONDONACIÓN DE LA SEGUNDA CONVOCATORIA DE GOBIERNO ELECTRÓNICO”. El citado anexo deberá incluir los datos que evidencien el cumplimiento de la totalidad de las condiciones y actividades de la asesoría, acompañamiento o sensibilización, siendo necesaria la siguiente información:<br />
                <br />
                o	Nombre del beneficiario del crédito condonable y número de identificación.
                    <br />
                o	Número de horas cumplidas en las actividades de asesoría, acompañamiento o sensibilización.
                    <br />
                o	Datos del tema de la asesoría, acompañamiento o sensibilización, agenda, cronograma, sustentación, relación de entregables, resumen del informe final.
                    <br />
                o	Constancia de recibo y aceptación.
                    <br />
                o	Pertinencia de la asesoría, acompañamiento o sensibilización en relación con la Estrategia de Gobierno en Línea.
                    <br />
                o	Fecha de finalización (Día/Mes/Año).
            </p>
        </div>
        <h3><b>4.4 Impartir y acreditar horas de capacitación en una Entidad del Estado.</b></h3>
        <div align="left">
            <p>
                <b>Condiciones, evidencias y documentos finales que acreditan el cumplimiento del requisito:</b><br />
                <br />
                Certificación de cumplimiento expedida por el área donde se desarrolló e impartió la capacitación, de la Entidad beneficiaria. Lo anterior a través del Anexo No. 07: “CONSTANCIA DE RECIBO Y ACEPTACIÓN EXPEDIDA POR ENTIDAD DEL ESTADO PARA LA CONDONACIÓN DE LA SEGUNDA CONVOCATORIA DE GOBIERNO ELECTRÓNICO”. El citado anexo deberá incluir los datos que evidencien el cumplimiento de la totalidad de las condiciones y actividades de capacitación impartidas, siendo necesaria la siguiente información:<br />

                <br />
                o	Nombre del beneficiario del crédito condonable y número de identificación.
                    <br />
                o	Número de horas impartidas de capacitación.
                    <br />
                o	Datos del tema de la capacitación, agenda / cronograma cumplido, descripción del público objetivo, tabla de contenido de material didáctico y/o de apoyo, listado de asistencia y evidencias fotográficas.
                    <br />
                o	Pertinencia de la capacitación en relación con la Estrategia de Gobierno en Línea. 
                    <br />
                o	Fecha de finalización (Día/Mes/Año).
            </p>
        </div>
        <h3><b>4.5 Realizar proyecto de grado dirigido por la Institución Universitaria que aplique a una Entidad del Estado.</b></h3>
        <div align="left">
            <p>
                <b>Condiciones, evidencias y documentos finales que acreditan el cumplimiento del requisito:</b><br />
                <br />
                Certificación de cumplimiento y entrega a satisfacción del Proyecto de Grado de conformidad por la Entidad del Estado y la Institución Educativa / Universitaria. Lo anterior a través del Anexo No. 08: “CONSTANCIA DE RECIBO Y ACEPTACIÓN EXPEDIDA POR LA INSTITUCIÓN EDUCATIVA Y ENTIDAD DEL ESTADO PARA LA CONDONACIÓN DE LA SEGUNDA CONVOCATORIA DE GOBIERNO ELECTRÓNICO”. El citado anexo deberá incluir los datos que evidencien el cumplimiento de la totalidad de las condiciones definidas en el proyecto de grado, siendo necesaria la siguiente información:<br />

                <br />
                o	Nombre del beneficiario del crédito condonable y número de identificación.
                    <br />
                o	Tipo de Proyecto de Grado realizado (Tesis, Monografía, Proyecto, Aplicación u otro).
                    <br />
                o	Nombre final del Proyecto de Grado.
                    <br />
                o	Descripción (síntesis) del Proyecto de Grado.
                    <br />
                o	Objetivo general y objetivos específicos.
                    <br />
                o	Nombre de la Entidad del Estado que se benefició con el Proyecto.
                    <br />
                o	Nombre del área de la Entidad del Estado que se benefició con el Proyecto, datos de contacto.
                    <br />
                o	Productos entregados, con sus características, a la Entidad beneficiaria.
                    <br />
                o	Pertinencia del proyecto en relación con la Estrategia de Gobierno en Línea.
                    <br />
                o	Fecha de finalización (Día/Mes/Año).
            </p>
        </div>
        <h3><b>4.6 Realizar proyecto, estudio, investigación o desarrollo que aplique a una Entidad del Estado.</b></h3>
        <div align="left">
            <p>
                <b>Condiciones, evidencias y documentos finales que acreditan el cumplimiento del requisito:</b><br />
                <br />
                Certificación de cumplimiento y entrega a satisfacción del Proyecto, estudio, investigación o desarrollo, a la Entidad del Estado. Lo anterior a través del Anexo No. 07: “CONSTANCIA DE RECIBO Y ACEPTACIÓN EXPEDIDA POR ENTIDAD DEL ESTADO PARA LA CONDONACIÓN DE LA SEGUNDA CONVOCATORIA DE GOBIERNO ELECTRÓNICO”. El citado anexo deberá incluir los datos que evidencien el cumplimiento de la totalidad de las condiciones y actividades del proyecto, estudio, investigación o desarrollo realizado, siendo necesaria la siguiente información:<br />

                <br />
                o	Nombre del beneficiario del crédito condonable y número de identificación.
                    <br />
                o	Tipo de trabajo realizado: proyecto, estudio, investigación o desarrollo.
                    <br />
                o	Nombre final del proyecto, estudio, investigación o desarrollo realizado.
                    <br />
                o	Descripción (síntesis) del proyecto, estudio, investigación o desarrollo realizado.
                    <br />
                o	Objetivo general y objetivos específicos.
                    <br />
                o	Nombre de la Entidad del Estado que se benefició con el Proyecto.
                    <br />
                o	Nombre del área de la Entidad del Estado que se benefició con el Proyecto, datos de contacto.
                    <br />
                o	Productos entregados, con sus características, a la Entidad beneficiaria.
                    <br />
                o	Pertinencia del proyecto en relación con la Estrategia de Gobierno en Línea.
                    <br />
                o	Fecha de finalización (Día/Mes/Año).
            </p>
        </div>
        <h3><b>5. Preparar la Documentación para la Condonación</b></h3>
        <div align="left">
            <p>
                Cada beneficiario que haya cursado una especialización debe obligatoriamente <b>cumplir con todos los requisitos</b> que se definen a continuación:
                    <br />
                <br />
                5.1 Acreditar tiempo de permanencia o vinculación laboral / contractual con Entidad (es) del Estado.
                    <br />
                5.2 Acreditar promedio de notas
                    <br />
                5.3 Acreditar que se cursó el Programa Académico aprobado para la obtención del beneficio.
                    <br />
                5.4 Obtener el título o grado del Programa Académico.
                    <br />
                5.5 Hacer parte de la Comunidad de la Práctica (CoP).
                    <br />
                5.6 Entregar video testimonial.
            </p>
        </div>
        <h3><b>5.1 Acreditar tiempo de permanencia o vinculación laboral / contractual con Entidad (es) del Estado.</b></h3>
        <div align="left">
            <p>
                El beneficiario debe demostrar vinculación con una o varias entidades del Estado, en las áreas relacionadas con la implementación o desarrollo de la Estrategia de Gobierno en Línea.
                    <br />
                <br />
                Para efectos del tiempo mínimo de permanencia se debe considerar la siguiente formula:<br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b> Tiempo de Permanencia = (Fecha de Terminación - Fecha de Inicio) * 70%</b>
                <br />
                <br />
                Fecha de Inicio:  Fecha en la cual inició el primer periodo financiado<br />
                Fecha de Terminación: Fecha en la cual terminó el último periodo financiado<br />
                <br />
                Lo anterior de acuerdo con los semestres reportados y aprobados por la JUNTA ADMINISTRADORA del FONDO  para la obtención del beneficio, de acuerdo con la información oficial registrada en el SNIES para cada Programa Académico y la reportada por las Instituciones Universitarias. Debe corresponder también con los desembolsos realizados por el ICETEX, de acuerdo con las renovaciones realizadas por el beneficiario.
                    <br />
                <br />
                Para el cálculo del tiempo mínimo de vinculación en entidades del Estado, se entiende que dicha vinculación es simultánea al desarrollo de los estudios del Programa Académico elegido. Así mismo, la contratación podrá ser discontinua y/o en diferentes entidades del estado, sin embargo, debe garantizar que la sumatoria de los contratos le permitan el cumplimiento del requisito, no obstante, no podrán ser simultáneos entre sí.
                    <br />
                <br />
                El periodo en el cual podrá acreditar el tiempo mínimo de vinculación directa con una Entidad del Estado se cuenta, desde la fecha de inicio de clases del programa académico elegido y de manera continua hasta un término máximo doce (12) meses contados a partir de la fecha de terminación de los estudios, es decir las materias, del programa académico financiado . Estas fechas e información relevante las obtiene el ICETEX de manera oficial con cada Institución Educativa. 
                    <br />
                <br />
                Nota: En caso de suspensión o aplazamiento de periodo(s) académicos(s), reportados oficialmente ante el ICETEX, ese tiempo no se tendrá en cuenta para ningún efecto, ni como semestre financiado, ni para el tiempo mínimo de vinculación.
                    <br />
                <br />
                <b>•	Condiciones, evidencias y documentos finales que acreditan el cumplimiento del requisito:</b>
                <br />
                <br />
                Certificación laboral, en original o copia, con máximo treinta (30) días de expedición, previos a la fecha de radicación de los documentos o, certificación de contratos de prestación de servicios, suscrita por área competente de la Entidad.
                    <br />
                <br />
                Tal(es) documento(s) debe(n) indicar como mínimo: 
                    <br />
                o	Nombre del titular y datos de identificación.
                    <br />
                o	Nombre de la Entidad del Estado.
                    <br />
                o	Nombre del área de desempeño, funciones y objeto.
                    <br />
                o	Tiempo de servicio (fechas exactas).
                    <br />
                o	Información sobre la culminación a satisfacción de los contratos (si los hay).
                    <br />
                o	Teléfonos de contacto para verificación.
            </p>
        </div>
        <h3><b>5.2 Acreditar promedio de notas.</b></h3>
        <div align="left">
            <p>
                Acreditar que en el último semestre o periodo cursado obtuvo un PROMEDIO mínimo en el SEMESTRE O PERIODO de tres punto cuatro (3.4) sobre cinco punto cero (5.0), o su equivalente, o que en el desarrollo total de su programa académico haya obtenido un PROMEDIO ACUMULADO mínimo de tres punto cuatro (3.4) sobre cinco punto cero (5.0), o su equivalente.<br />
                <br />
                <b>•	Condiciones, evidencias y documentos finales que acreditan el cumplimiento del requisito:</b><br />

                <br />
                Original de certificación expedida por la Institución Universitaria donde conste: 
                    <br />
                o	Nombre de la Institución.
                    <br />
                o	Programa Académico cursado (debe ser el mismo que fue aprobado para el otorgamiento del crédito condonable).
                    <br />
                o	Nombre del estudiante y datos de identificación. 
                    <br />
                o	Promedio del último semestre o periodo cursado.
                    <br />
                o	Promedio acumulado final.
            </p>
        </div>
        <h3><b>5.3 Acreditar que se cursó el Programa Académico aprobado para la obtención del beneficio.</b></h3>
        <div align="left">
            <p>
                Cursar y aprobar todo el programa académico cumpliendo con todas las condiciones establecidas por la INSTITUCIÓN, el Reglamento Operativo  y la Convocatoria específica. Esto incluye la aprobación de todas las materias definidas en el pensum, trabajos finales o cantidad de créditos indicados por la Institución, conducentes a la obtención del título.<br />
                <br />

                <b>•	Condiciones, evidencias y documentos finales que acreditan el cumplimiento del requisito:</b><br />
                <br />

                Original de certificación expedida por la Institución Universitaria donde conste:
                    <br />
                <br />
                o	Nombre de la Institución.
                    <br />
                o	Programa Académico cursado (debe ser el mismo que fue aprobado para el otorgamiento del crédito condonable).
                    <br />
                o	Nombre del estudiante y datos de identificación.
                    <br />
                o	Información sobre el cumplimiento de todos los requisitos establecidos por la Universidad para la culminación satisfactoria del programa.
                    <br />
                Nota: Puede ser la misma certificación del numeral anterior Incluyendo adicionalmente todos los datos solicitados en este numeral.
            </p>
        </div>
        <h3><b>5.4 Obtener el título o grado del Programa Académico. </b></h3>
        <div align="left">
            <p>
                Obtener el título o grado respectivo para el programa que se financió, expedido por la INSTITUCIÓN EDUCATIVA, de acuerdo con lo aprobado para la obtención del beneficio.<br />
                <br />

                <b>•	Condiciones, evidencias y documentos finales que acreditan el cumplimiento del requisito:</b><br />

                <br />
                Copia del título y acta de grado expedido por la Institución Universitaria donde conste:
                    <br />
                o	Nombre de la Institución.
                    <br />
                o	Programa Académico cursado (debe ser el mismo que fue aprobado para el otorgamiento del crédito condonable).
                    <br />
                o	Fecha de grado.
                    <br />
                o	Nombre del estudiante y número de identificación. 
            </p>
        </div>
        <h3><b>5.5 Hacer parte de la Comunidad de la Práctica (CoP). </b></h3>
        <div align="left">
            <p>
                El Programa para la Excelencia en Gobierno Electrónico promueve el desarrollo de una Comunidad de Práctica – CoP para contar con un espacio virtual de interés común con todas las personas que han sido partícipes del componente de formación en Gobierno Electrónico.<br />
                <br />
                Es un espacio para interactuar, compartir experiencias, conocimiento y lecciones aprendidas, así como para participar en encuentros virtuales y presenciales, que permitan continuar fortaleciendo las capacidades en Gobierno Electrónico. Por lo tanto, se refuerza el espacio pedagógico, colectivo y de práctica que les permite a sus miembros ser parte de una red de profesionales del sector público, líderes y expertos en Gobierno Electrónico de diferentes sectores, para:<br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;o	Desarrollar conocimientos especializados en Gobierno Electrónico.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;o	Participar de actividades que promuevan el intercambio de experiencias y buenas prácticas.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;o	Ser un espacio de encuentro que permita aportar saberes, capacidades y habilidades favoreciendo el conocimiento.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;o	Promover el desarrollo de competencias en Gobierno Digital e Innovación Pública Digital.
                    <br />
                <br />
                Para hacer parte de la comunidad de practica es necesario registrarse oficialmente en la CoP y participar de las actividades propuestas en la Comunidad para obtener mínimo 500 puntos en los casos de especializaciones y 1500 puntos para las maestrías. 
                    <br />
                <br />
                <b>•	Registrarse en la CoP: </b>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;o	Diligenciar el formulario de inscripción que está publicado en:<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a style="background-color: #fff; color: #0000EE; text-decoration: underline;" target="_blank" href="http://escuelapnud.org/iniciativas/gelmintic/">http://escuelapnud.org/iniciativas/gelmintic/</a>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a style="background-color: #fff; color: #0000EE; text-decoration: underline;" target="_blank" href="http://estrategia.gobiernoenlinea.gov.co/623/w3-channel.html">http://estrategia.gobiernoenlinea.gov.co/623/w3-channel.html</a>
                <br />
                <br />
                <b>•	Proceso de participación y obtención de puntos:</b>
                <br />
                <br />
                La Comunidad de Práctica tiene dos grandes espacios de participación y trabajo, entre los cuales se encuentran servicios actualmente activos y otros que serán habilitados posteriormente. Dichos espacios de participación están definidos de la siguiente manera: 
                    <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;o	Para profundizar sus conocimientos en Gobierno Digital desarrolla Cursos virtuales, Boletines informativos y Blogs.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;o	Para interactuar y compartir con otras personas y expertos en temas de Gobierno Digital desarrolla Webinars Temáticos, Foros, Tours de innovación y eventos con participación de expertos &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nacionales o internacionales.
                    <br />
                <br />
                Cada actividad realizada por el beneficiario del crédito condonable en la Comunidad de Práctica le otorgará un puntaje, le permitirá acumular puntos y ser participante activo de la misma. Es posible que el beneficiario pueda combinar varias actividades o ser partícipe de algunas específicas, todo depende del interés en las temáticas que se estén trabajando y del aporte que pueda realizar en cada una. El puntaje que se otorga por participar en cada una de las actividades es dinámico y depende exclusivamente de la Comunidad de Practica. 
                    <br />
                <br />
                Para participar de cada actividad, y obtener los puntos respectivos, el beneficiario debe registrarse formalmente en cada una de ellas, teniendo en cuenta la disponibilidad de cupos, la forma puntual de registro de cada actividad, el tiempo requerido y la participación activa en cada espacio, según las instrucciones que se brinden en el mismo. Tenga en cuenta que las actividades son acumulativas desde el inicio de la Convocatoria en la que usted ha participado y hasta un plazo máximo de 12 meses posterior a la terminación de materias. La acumulación de puntos no es de carácter retroactivo; la retroactividad hace referencia a los casos en que el beneficiario haya finalizado exitosamente algunas de las actividades de la Comunidad, previo a la fecha de aprobación del crédito condonable, según acta de la JUNTA ADMINISTRADORA del FONDO.
                    <br />
                <br />
                A medida que el beneficiario del crédito condonable participe, el Programa para la Excelencia actualizará en la plataforma de condonación, en la web del ICETEX, el puntaje obtenido hasta la fecha, el que podrá ser consultado por el beneficiario en cualquier momento. Este servicio de consulta estará disponible a partir del mes de septiembre de 2016. 
                    <br />
                <br />
                <b>•	Condiciones, evidencias y documentos finales que acreditan el cumplimiento del requisito:</b>
                <br />
                <br />
                Certificación de pertenecer a la Comunidad de Práctica CoP, la cual será consultada internamente por el Ministerio de TIC e ICETEX, en donde conste:
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;o	Nombre del beneficiario del crédito condonable y número de identificación. 
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;o	Vinculación a la Comunidad.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;o	Actividades realizadas y puntaje acumulado dentro de la Comunidad.
            </p>
        </div>
        <h3><b>5.6 Entregar video testimonial.</b></h3>
        <div align="left">
            <p>
                Entregar un video testimonial y creativo de la experiencia como beneficiario de la Segunda Convocatoria de Gobierno Electrónico del FONDO DE PROMOCIÓN DE GOBIERNO Y EMPRESA TI.<br />
                <br />
                Las características técnicas del video son:<br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1)	Tener mínimo dos (2) minutos de testimonio.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2)	Debe ser grabado en formato HD (1080 x 720 pixeles).
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3)	La calidad de audio deber ser óptima, nítida y clara (grabado con micrófono externo).
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;4)	Las condiciones de iluminación deben ser adecuadas. Que no esté subexpuesto o sobreexpuesto.
                    <br />
                <br />
                Las condiciones del testimonio son:
                    <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1)	Realice su presentación personal: nombre, título obtenido y citar SEGUNDA CONVOCATORIA DE GOBIERNO ELECTRÓNICO.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2)	Opinar sobre el proceso de vinculación y condonación.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3)	Porqué es útil haber cursado el programa elegido.
                    <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;4)	Cómo aporta Ud. a la Estrategia de Gobierno en Línea en sus actividades y en su Entidad. Citar la Entidad beneficiaria .
                    <br />
                <br />
                <b>•	Condiciones, evidencias y documentos finales que acreditan el cumplimiento del requisito:</b>
                <br />
                <br />
                Vía web: Se habilita esta nueva opción, que se considera PREFERIBLE, por ser más sencilla y haciendo uso de las TIC. El video debe ser publicado en YouTube y el beneficiario debe informar el enlace web del caso. El citado enlace debe estar vigente por seis (6) meses, contados a partir de la radicación de la solicitud de condonación en la plataforma de condonación de ICETEX. En el sitio del enlace debe citarse el Nombre del beneficiario, Institución, Programa Cursado y nombre de la Convocatoria: SEGUNDA CONVOCATORIA DE GOBIERNO ELECTRÓNICO, cumpliendo con las condiciones solicitadas.
                    <br />
                <br />
                En medio magnético o discos ópticos: memoria externa USB, CD o DVD, debidamente marcado con el Nombre del beneficiario, Institución, Programa Cursado y nombre de la Convocatoria: SEGUNDA CONVOCATORIA DE GOBIERNO ELECTRÓNICO, cumpliendo con las condiciones solicitadas. Debe ser radicado en el Ministerio de TIC a nombre de la Segunda Convocatoria de Gobierno Electrónico, Programa para la Excelencia en Gobierno Electrónico – Dirección de Gobierno en Línea.
                    <br />
                <br />
                Documento adicional para ambas opciones (web o medio magnético): comunicación suscrita por parte del beneficiario, en donde conste que el Ministerio de TIC cuenta con su autorización para hacer uso del video en temas institucionales, promoción y divulgación. El documento debe incluir el enlace web en dónde el beneficiario ha publicado el video. Se plantea un modelo básico del citado documento en el Anexo No. 11: "Modelo de autorización para uso, promoción y divulgación del video testimonial por parte del Ministerio de TIC”.
            </p>
        </div>
        <h3><b>5.7 Soporte de Recibo y Aceptación</b></h3>
        <div align="left">
            <p>
                Este documento hace referencia al Anexo 07, 08, 09 o 10, según sea el caso, de Constancia de Recibo y Aceptación expedida por el Centro de Innovación Pública Digital, Entidad del Estado y/o Institución Educativa.  La información se encuentra ampliada en el capítulo 4 de este documento.
            </p>
        </div>
        <h3><b>6. En la plataforma cargar Soportes y Radicar solicitud de Condonación</b></h3>
        <div align="left">
            <p>
                La condonación es el procedimiento a través del cual se extingue la obligación adquirida por el beneficiario del crédito, liberándolo del pago del mismo, a cambio del cumplimiento de las obligaciones previamente estipuladas en la Convocatoria.
                    <br />
                <br />
                Una vez haya finalizado los estudios, obtenido el título, cumplidos los requisitos obligatorios para condonación y culminado la opción elegida y avalada como requisito adicional, deberá presentar ante el ICETEX la solicitud de condonación, soportada con los documentos y evidencias pertinentes, que se han presentado en este documento explicativo.
                    <br />
                <br />
                Para solicitar la condonación el beneficiario deberá ingresar a la plataforma web de condonación dispuesta por ICETEX y cargar en la pestaña “Condonación” todos los documentos soportes enunciados en el capítulo No. 5 y radicar la solicitud. Es necesario tomar nota del número de radicado con el fin de garantizar que la solicitud de condonación se ha sido realizado correctamente.
                    <br />
                <br />
                Considere que, para el cumplimiento de los requisitos de condonación, el beneficiario deberá presentar la documentación académica y demás soportes exigidos para la condonación, en un término máximo de doce (12) meses, contados a partir de la fecha de terminación de los estudios. Lo anterior de acuerdo con la duración oficial del Programa Académico reportada en el SNIES.
                    <br />
                <br />
                En el caso en el que el beneficiario solo haya recibido financiación para algunos periodos del programa académico, y no para su totalidad, el proceso de condonación y los requisitos a cumplir son todos los estipulados en este documento.
                    <br />
                <br />
                Es de resaltar que el incumplimiento de alguno o varios de los requisitos obligatorios o del requisito adicional, dentro del tiempo establecido, conlleva a la NO condonación del crédito y al cobro del mismo por parte del ICETEX hacia el beneficiario.
            </p>
        </div>
        <h3><b>6.1 Notificación ¿Condonación Aprobada?</b></h3>
        <div align="left">
            <p>
                La revisión de los documentos presentados, es realizado por la JUNTA ADMINISTRADORA del FONDO y consiste en la verificación del cumplimiento de todos los requisitos de condonación conforme a las especificaciones dadas en los términos de la convocatoria y ampliados en el explicativo de condonación. Así mismo, se verificará la coherencia entre el aval otorgado para el desarrollo de Requisito Adicional y el documento de recibo y aceptación otorgado por el Centro de Innovación Publica Digital, Entidad del Estado y/o Institución Educativa, según sea el caso.
                    <br />
                <br />
                De igual manera, la condonación será autorizada por la JUNTA ADMINISTRADORA del FONDO quedando como constancia de ello, un acta. Una vez autorizado por la JUNTA, el ICETEX, basado en dicha acta, emitirá un Acto Administrativo con la relación del beneficiario y valor a condonar, para que esta entidad en su calidad de administrador financiero del FONDO, proceda a realizar las condonaciones en los aplicativos de cartera.
                    <br />
                <br />
                Las sesiones de la JUNTA se llevarán a cabo, según calendario que será publicado en la plataforma de condonación de la Segunda Convocatoria de Gobierno Electrónico en la web del ICETEX. A las sesiones de JUNTA podrán asistir los funcionarios o expertos del Ministerio de TIC que las partes (ICETEX y Ministerio de TIC), consideren necesarios para atender la revisión de la documentación.
                    <br />
                <br />
                Para que una solicitud sea llevada a la JUNTA, deberá radicar sus documentos en la plataforma de condonación mínimo cuatro (4) días calendario antes de la fecha de la sesión de JUNTA. La respuesta al beneficiario se dará a través de la misma plataforma de condonación, cuatro (4) días hábiles después de la sesión de la JUNTA.
            </p>
        </div>
        <h3><b>6.2 Completar Documentación Solicitada</b></h3>
        <div align="left">
            <p>
                Cuando la condonación sea negada, el beneficiario deberá atender las recomendaciones realizadas por la Junta Administradora y deberá iniciar el proceso de esta etapa nuevamente generando una nueva solicitud y numero de radicado, adjuntando la documentación completa y cumpliendo con las recomendaciones efectuadas. Así mismo, la nueva solicitud estará sujeta a las fechas definidas en el calendario de las sesiones de Junta. En los casos donde el incumplimiento de un requisito no sea subsanable, se notificará al beneficiario que su crédito pasará a cobro de cartera para lo cual deberá definir con el ICETEX la modalidad de pago y demás aspectos necesarios para esta etapa. 
            </p>
        </div>
        <h3><b>7. Solicitar al ICETEX la devolución de las garantías</b></h3>
        <div align="left">
            <p>
                A través de los canales de atención dispuestos por el ICETEX el beneficiario deberá solicitar la devolución de las garantías, atendiendo los procedimientos definidos en su momento por dicha entidad para tales fines.
            </p>
        </div>
        <h3><b>ANEXOS ESPECÍFICOS PARA CONDONACIÓN.</b></h3>
        <div align="left">
            <p>
                Los anexos citados son archivos descargables que están en la sección Fondos en Administración, según la ruta:
                <br />
                <a style="background-color: #fff; color: #0000EE; text-decoration: underline;" target="_blank" href="http://www.icetex.gov.co/dnnpro5/es-co/fondos/fondosparaeldesarrollodeti/segundaconvocatoriadegobiernoelectr%c3%b3nico.aspx">http://www.icetex.gov.co/dnnpro5/es-co/fondos/fondosparaeldesarrollodeti/segundaconvocatoriadegobiernoelectr%c3%b3nico.aspx</a><br />
                <br />
                <b>•	Anexo No. 02:</b> “Instructivo de la Condonación por medio de las Opciones del Centro de Innovación de Gobierno en Línea” en tres secciones: 
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1. Anexo 2A - Guía para la Elaboración de Videos  <a style="background-color: #fff; color: #0000EE; text-decoration: underline;" target="_blank" download href="../Plantillas/Anexos/9084_Anexo 2A  Guia para la Elaboración de Videos.pdf">Descargar Anexo 2A</a>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2. Anexo 2B - Formato para la Documentación de Experiencias  <a style="background-color: #fff; color: #0000EE; text-decoration: underline;" target="_blank" download href="../Plantillas/Anexos/9084_Anexo 2B Formato para la Documentación de Experiencias.docx">Descargar Anexo 2B</a>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3. Anexo 2C – Formato para el Análisis de Experiencias.  <a style="background-color: #fff; color: #0000EE; text-decoration: underline;" target="_blank" download href="../Plantillas/Anexos/9084_Anexo 2C Formato para el Analisis de Experiencias.docx">Descargar Anexo 2C</a>
                <br />
                <br />
                <b>•	Anexo No. 03:</b> “AUTORIZACIÓN EXPEDIDA POR ENTIDAD DEL ESTADO PARA INICIAR CON EL DESARROLLO DEL REQUISITO ADICIONAL QUE PERMITIRÁ EL CUMPLIMIENTO DE UN REQUISITO DE CONDONACIÓN DE LA SEGUNDA CONVOCATORIA DE GOBIERNO ELECTRÓNICO”.
                <br />
                <a style="background-color: #fff; color: #0000EE; text-decoration: underline;" target="_blank" download href="../Plantillas/Anexos/9084_Anexo 03 Autorización Entidades del Estado.docx">Descargar Anexo No. 03</a>
                <br />
                <br />
                <b>•	Anexo No. 04:</b> “AUTORIZACIÓN EXPEDIDA POR INSTITUCIÓN EDUCATIVA Y ENTIDAD DEL ESTADO PARA INICIAR CON EL PROYECTO DE GRADO QUE PERMITIRÁ EL CUMPLIMIENTO DE UN REQUISITO DE CONDONACIÓN DE LA SEGUNDA CONVOCATORIA DE GOBIERNO ELECTRÓNICO”.
                <br />
                <a style="background-color: #fff; color: #0000EE; text-decoration: underline;" target="_blank" download href="../Plantillas/Anexos/9084_Anexo 04 Autorización InstituciónEducativa y EntidadEstado.docx">Descargar Anexo No. 04</a>
                <br />
                <br />
                <b>•	Anexo No. 05:</b> “AUTORIZACIÓN EXPEDIDA POR EL CENTRO DE INNOVACIÓN PÚBLICA DIGITAL PARA INICIAR CON EL DESARROLLO DEL REQUISITO ADICIONAL (EXPERIENCIAS) QUE PERMITIRÁ EL CUMPLIMIENTO DE UN REQUISITO DE CONDONACIÓN DE LA SEGUNDA CONVOCATORIA DE GOBIERNO ELECTRÓNICO”.
                <br />
                <a style="background-color: #fff; color: #0000EE; text-decoration: underline;" target="_blank" download href="../Plantillas/Anexos/9084_Anexo 05 Autorización Centro de Innovación Experiencias.docx">Descargar Anexo No. 05</a>
                <br />
                <br />
                <b>•	Anexo No. 07:</b> “CONSTANCIA DE RECIBO Y ACEPTACIÓN EXPEDIDA POR ENTIDAD DEL ESTADO PARA LA CONDONACIÓN DE LA SEGUNDA CONVOCATORIA DE GOBIERNO ELECTRÓNICO”.
                <br />
                <a style="background-color: #fff; color: #0000EE; text-decoration: underline;" target="_blank" download href="../Plantillas/Anexos/9084_Anexo 07 Constancia de Recibo y Aceptación Entidades del Estado.docx">Descargar Anexo No. 07</a>
                <br />
                <br />
                <b>•	Anexo No. 08:</b> “CONSTANCIA DE RECIBO Y ACEPTACIÓN EXPEDIDA POR INSTITUCIÓN EDUCATIVA Y ENTIDAD DEL ESTADO PARA LA CONDONACIÓN DE LA SEGUNDA CONVOCATORIA DE GOBIERNO ELECTRÓNICO”.
                <br />
                <a style="background-color: #fff; color: #0000EE; text-decoration: underline;" target="_blank" download href="../Plantillas/Anexos/9084_Anexo 08 Constancia de Recibo y Aceptación InstituciónEducativa y EntidadEstado.docx">Descargar Anexo No. 08</a>
                <br />
                <br />
                <b>•	Anexo No. 09:</b> “CONSTANCIA DE RECIBO Y ACEPTACIÓN PARA EXPERIENCIAS EXPEDIDA POR EL CENTRO DE INNOVACIÓN PÚBLICA DIGITAL PARA LA CONDONACIÓN DE LA SEGUNDA CONVOCATORIA DE GOBIERNO ELECTRÓNICO”.
                <br />
                <a style="background-color: #fff; color: #0000EE; text-decoration: underline;" target="_blank" download href="../Plantillas/Anexos/9084_Anexo 09 Constancia Recibo y Aceptación Centro de Innovación Experiencias.docx">Descargar Anexo No. 09</a>
                <br />
                <br />
                <b>•	Anexo No. 11:</b> "Modelo de autorización para uso, promoción y divulgación del video testimonial por parte del Ministerio de TIC"
                <br />
                <a style="background-color: #fff; color: #0000EE; text-decoration: underline;" target="_blank" download href="../Plantillas/Anexos/9084_Anexo 11 Modelo de Autorización para Uso Promoción y Divulgación del Video SCGE.docx">Descargar Anexo No. 11</a>
            </p>
        </div>

    </div>
</body>
</html>
