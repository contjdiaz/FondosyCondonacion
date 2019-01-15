<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeBehind="PlataformaCondonacion.aspx.cs" Inherits="FondosycCondonacion.UI.Condonacion.PlataformaCondonacion" %>

<%@ Register Src="~/Condonacion/UcEspecializacion.ascx" TagName="UcEspecializacion" TagPrefix="uc1" %>
<%@ Register Src="~/Condonacion/UcMaestria.ascx" TagName="UcMaestria" TagPrefix="uc2" %>

<%@ Register Src="~/Condonacion/UcEspecializacion2.ascx" TagName="UcEspecializacion2" TagPrefix="uc3" %>
<%@ Register Src="~/Condonacion/UcMaestria2.ascx" TagName="UcMaestria2" TagPrefix="uc4" %>

<%@ Register Src="~/Controls/UcAval.ascx" TagPrefix="uc1" TagName="UcAval" %>
<%@ Register Src="~/Controls/UcCondonacion.ascx" TagPrefix="uc1" TagName="UcCondonacion" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" ClientIDMode="Static" runat="Server">
    <script src="../Script/Form/Condonacion.js"></script>
    <script src="../Script/Utilitarios.js"></script>

    <div class="container" style="width: 90%;">
        <h3 class="h3Main" style="margin-bottom: 2px;">
            <asp:Label ID="lblConvocatoria" runat="server"></asp:Label>
        </h3>
        <h3 class="h3Nivel" style="margin-bottom: 2px;">
            <asp:Label ID="lblNivel" runat="server"></asp:Label>
        </h3>
        <ul class="nav nav-pills nav-justified">
            <li class="active" id="linkTabCond" runat="server"><a data-toggle="tab" href="#menuCond">PROCEDIMIENTO DE CONDONACIÓN</a></li>
            <li id="linkTabAval" runat="server"><a data-toggle="tab" href="#menuAval">SOLICITUD DE AVAL</a></li>
            <li id="linkTabCondonacion" runat="server"><a data-toggle="tab" href="#menuCondonacion">SOLICITUD DE CONDONACIÓN</a></li>
        </ul>
        <div class="tab-content">
            <div id="menuCond" class="tab-pane fade in active" runat="server">
                <br />
                <a runat="server" id="urlExplicativoCondonacion" style="background-color: #fff; color: #0000EE; text-decoration: underline;" target="_blank" download href="../Plantillas/Explicativo Condonación Primera Convocatoria de Gobierno Electrónico">Descargar archivo "Explicativo Condonación Primera Convocatoria de Gobierno Electrónico.pdf"</a>
                <br />
                <uc1:UcEspecializacion ID="UcEspecializacion" runat="server" />
                <uc2:UcMaestria ID="UcMaestria" runat="server" />
                <uc3:UcEspecializacion2 ID="UcEspecializacion2" runat="server" />
                <uc4:UcMaestria2 ID="UcMaestria2" runat="server" />
            </div>
            <div id="menuAval" class="tab-pane fade" runat="server">
                <uc1:UcAval runat="server" ID="UcAval" />
            </div>
            <div id="menuCondonacion" class="tab-pane fade" runat="server">
                <uc1:UcCondonacion runat="server" ID="UcCondonacion" />
            </div>
        </div>
        <div>
            <asp:Label ID="LbError" runat="server" Font-Bold="True" Font-Size="X-Small" ForeColor="Red"></asp:Label>
        </div>
    </div>
</asp:Content>