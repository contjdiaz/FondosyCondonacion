<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeBehind="CalificarBeneficiario.aspx.cs" Inherits="FondosycCondonacion.UI.Administracion.CalificarBeneficiario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" ClientIDMode="Static" runat="Server">
    <link href="../Styles/StyleEspecializacion.css" rel="stylesheet" />
    <script src="../Script/Form/CalificarAval.js"></script>
    <script src="../Script/Utilitarios.js"></script>

    <div class="container" style="width: 90%;">
        <h3 class="h3Main" style="margin-bottom: 2px;">CONDONACIÓN - MODULO DE ADMINISTRACIÓN</h3>
        <h3 class="h3Nivel" style="margin-bottom: 2px;">
            <asp:Label ID="lblUsuario" runat="server" Text="USUARIO"></asp:Label>
        </h3>
        <ul class="nav nav-pills nav-justified">
            <li id="linkInscritos" runat="server" class="active"><a data-toggle="tab" href="#menuInscritos">CALIFICACIÓN</a></li>
            <li id="linkPuntaje" runat="server"><a data-toggle="tab" href="#menuPuntaje">CARGUE DE PUNTAJE</a></li>
        </ul>
        <div class="tab-content">
            <div id="menuInscritos" runat="server" class="tab-pane fade in active">
                <br />
                <div class="col-sm-6">
                    <asp:Label runat="server" ID="lblCalificacion" Text="1. Elija Tipo de Calificación:" Font-Bold="true" />
                    <asp:DropDownList runat="server" ID="ddlCalificacion" CssClass="form-control">
                        <asp:ListItem Text="Calificar Aval" Value="A"></asp:ListItem>
                        <asp:ListItem Text="Calificar Condonación" Value="C"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="col-sm-6">
                    <asp:Label runat="server" ID="lblConvocatoria" Text="2. Elija Convocatoria:" Font-Bold="true" />
                    <asp:DropDownList runat="server" ID="ddlConvocatoria" CssClass="form-control">
                        <asp:ListItem Text="Primera Convocatoria Gobierno Electrónico" Value="8809"></asp:ListItem>
                        <asp:ListItem Text="Segunda Convocatoria Gobierno Electrónico" Value="9084"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm-6" style="padding-top: 20px;">
                    <asp:Label runat="server" ID="lblListadoBeneficiarios" Text="3. Descargue Listado de Beneficiarios:" Font-Bold="true" />
                    <asp:LinkButton runat="server" ID="lnkDescargar" CssClass="button" Style="vertical-align: middle; color: #FFFFFF;" OnClick="lnkDescargar_Click">
                            <span>Descargar</span>
                    </asp:LinkButton>
                </div>
                <div class="col-sm-6" style="padding-top: 20px;">
                    <asp:Label runat="server" ID="lblListadoHistorico" Text="(Opcional) Descargue Histórico de calificaciones:" Font-Bold="true" />
                    <asp:LinkButton runat="server" ID="lnkDescargarHistorico" CssClass="button" Style="vertical-align: middle; color: #FFFFFF;" OnClick="lnkDescargarHistorico_Click">
                            <span>Descargar</span>
                    </asp:LinkButton>
                </div>
                <div class="col-sm-12" style="padding-top: 30px;">
                    <asp:Label runat="server" ID="lblCargueDocumento" Text="4. Cargue de Documento (Listado de Beneficiarios):" Font-Bold="true" />
                    <input type="file" id="fulDocumento" name="fulDocumento" accept="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel" onchange="return CheckFileWithSize(this,10000);" />
                    <span id="rqfulDocumento" class="requiredFieldValidator_css" style="visibility: hidden;">Debe seleccionar un archivo de Excel valido</span>
                    <asp:LinkButton runat="server" ID="lnkCargar" CssClass="button" Style="vertical-align: middle; color: #FFFFFF;" OnClick="lnkCargar_Click" OnClientClick="return verificar();">
                            <span>Cargar</span>
                    </asp:LinkButton>
                </div>
                <asp:HiddenField ID="resumen_activo" runat="server" Value="0" />
                <asp:HiddenField ID="resumen_archivo_valido" runat="server" />
                <div id="dv_resumen" style="float: left; visibility: hidden;">
                    <p class="success">
                        El archivo se proces&oacute; correctamente.
                    </p>
                </div>
                <div id="dv_archivoInvalido" style="float: left; visibility: hidden;">
                    <p>
                        <asp:Label ID="lb_err_detalle" runat="server" Text="Label"></asp:Label>
                    </p>
                </div>
            </div>
            <div id="menuPuntaje" runat="server" class="tab-pane fade">
                <div class="col-sm-6" style="padding-top: 20px;">
                    <asp:Label runat="server" ID="lblDescarguePuntaje" Text="1. Descargue Listado de Beneficiarios para asignación de puntaje:" Font-Bold="true" />
                    <br />
                    <asp:LinkButton runat="server" ID="lnkDescargarPuntaje" CssClass="button" Style="vertical-align: middle; color: #FFFFFF;" OnClick="lnkDescargarPuntaje_Click">
                            <span>Descargar</span>
                    </asp:LinkButton>
                </div>
                <div class="col-sm-6" style="padding-top: 20px;">
                    <asp:Label runat="server" ID="lblCarguePuntaje" Text="4. Cargue de Documento (Listado de Beneficiarios para asignación de puntaje):" Font-Bold="true" />
                    <input type="file" id="fulDocumentoPuntaje" name="fulDocumentoPuntaje" accept="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel" onchange="return CheckFileWithSize(this,1000);" />
                    <span id="rqfulDocumentoPuntaje" class="requiredFieldValidator_css" style="visibility: hidden;">Debe seleccionar un archivo de Excel valido</span>
                    <asp:LinkButton runat="server" ID="lnkCargarPuntaje" CssClass="button" Style="vertical-align: middle; color: #FFFFFF;" OnClick="lnkCargarPuntaje_Click" OnClientClick="return verificarPuntaje();">
                            <span>Cargar</span>
                    </asp:LinkButton>
                </div>
            </div>
            <div id="allScreen" class="LockOn form-group" style="visibility: hidden;">
                <asp:Label ID="lblLoading" runat="server" Text="Procesando Archivo" CssClass="info" />
                <img src="../Images/125.gif" />
            </div>
            <div id="divProceso" style="float: left; visibility: hidden;">
                <p>
                    <asp:Label ID="lblProceso" runat="server" Text="Procesando Archivo ..." CssClass="labeltablaformulario"
                        Style="color: #424040;"></asp:Label>
                </p>
            </div>
        </div>
        <div>
            <asp:Label ID="LbError" runat="server" Font-Bold="True" Font-Size="X-Small" ForeColor="Red"></asp:Label>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hdUsuario"></asp:HiddenField>
</asp:Content>
