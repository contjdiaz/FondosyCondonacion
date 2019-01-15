<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcAval.ascx.cs" Inherits="FondosycCondonacion.UI.Controls.UcAval" %>

<div class="col-sm-6" style="margin-bottom: 0px; padding-bottom: 10px; padding-top: 0px;">
    <asp:Label runat="server" ID="lblNombre" Text="Nombre:" Font-Bold="true" />
    <asp:TextBox runat="server" ID="txtNombre" class="form-control" disabled></asp:TextBox>
</div>
<div class="col-sm-6" style="margin-bottom: 0px; padding-bottom: 10px; padding-top: 0px;">
    <asp:Label runat="server" ID="lblIdentificacion" Text="Identificacion:" Font-Bold="true" />
    <asp:TextBox runat="server" ID="txtIdentificacion" class="form-control" disabled></asp:TextBox>
</div>
<div class="col-sm-6" style="margin-bottom: 0px; padding-bottom: 0px; padding-top: 0px;">
    <asp:Label runat="server" ID="lblDepartamento" Text="Departamento IES:" Font-Bold="false" Style="font-size: 10px; height: auto;" />
    <asp:DropDownList runat="server" ID="ddlDepartamento" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" CssClass="form-control" Style="font-size: 10px; height: auto;">
        <asp:ListItem Value="" Text=" Seleccione..."></asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="rqddlDepartamento" ValidationGroup="RadicarF" runat="server" ErrorMessage="Debe ingresar el departamento de la Institución" ControlToValidate="ddlDepartamento"></asp:RequiredFieldValidator>
</div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" style="padding: 0px 0px 0px 0px; border: none;">
    <ContentTemplate>
        <div class="col-sm-6" style="margin-bottom: 0px; padding-bottom: 0px; padding-top: 0px;">
            <asp:Label runat="server" ID="lblCiudad" Text="Ciudad IES:" Font-Bold="false" Style="font-size: 10px; height: auto;" />
            <asp:DropDownList runat="server" ID="ddlCiudad" AutoPostBack="True" OnSelectedIndexChanged="ddlCiudad_SelectedIndexChanged" CssClass="form-control" Style="font-size: 10px; height: auto;">
                <asp:ListItem Value="" Text=" Seleccione..."></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rqddlCiudad" ValidationGroup="RadicarF" runat="server" ErrorMessage="Debe ingresar el municipio de la Institución" ControlToValidate="ddlCiudad"></asp:RequiredFieldValidator>
        </div>
        <div class="col-sm-6" style="margin-bottom: 0px; padding-bottom: 0px; padding-top: 0px;">
            <asp:Label runat="server" ID="lblUniversidad" Text="IES:" Font-Bold="false" Style="font-size: 10px; height: auto;" />
            <asp:DropDownList runat="server" ID="ddlUniversidad" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlUniversidad_SelectedIndexChanged" Style="font-size: 10px; height: auto;">
                <asp:ListItem Value="" Text=" Seleccione..."></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rqddlUniversidad" ValidationGroup="RadicarF" runat="server" ErrorMessage="Debe ingresar la Institución" ControlToValidate="ddlCiudad"></asp:RequiredFieldValidator>
        </div>
        <div class="col-sm-6" style="margin-bottom: 0px; padding-bottom: 0px; padding-top: 0px;">
            <asp:Label runat="server" ID="lblPrograma" Text="Programa:" Font-Bold="false" Style="font-size: 10px; height: auto;" />
            <asp:DropDownList runat="server" ID="ddlPrograma" CssClass="form-control" Style="font-size: 10px; height: auto;">
                <asp:ListItem Value="" Text=" Seleccione..."></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rqddlPrograma" ValidationGroup="RadicarF" runat="server" ErrorMessage="Debe ingresar Programa" ControlToValidate="ddlPrograma"></asp:RequiredFieldValidator>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlDepartamento" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlCiudad" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlUniversidad" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>

<div class="col-sm-6" style="margin-bottom: 0px; padding-bottom: 0px; padding-top: 0px;">
    <asp:Label runat="server" ID="lblFecha" Text="Fecha prevista de finalización de materias:" Font-Bold="false" Style="font-size: 10px; height: auto;" />
    <asp:TextBox runat="server" ID="txtFecha" class="form-control" MaxLength="10" Style="font-size: 10px; height: auto;" PlaceHolder="DD/MM/YYYY" size="10"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rqtxtFecha" ValidationGroup="RadicarF" runat="server" ErrorMessage="Debe ingresar Fecha en formato correcto" ControlToValidate="txtFecha"></asp:RequiredFieldValidator>
</div>
<div class="col-sm-6" style="width: 60%; margin-bottom: 0px; padding-bottom: 10px; padding-top: 0px;">
</div>
<br />
<div class="col-sm-12" style="width: 70%;">
    <asp:Label runat="server" ID="lblTipoAval" Text="Opción de Condonación:" Font-Bold="true" />
    <asp:DropDownList runat="server" ID="ddlTipoAval" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoAval_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="rqddlTipoAval" ValidationGroup="RadicarF" runat="server" ErrorMessage="Debe ingresar Aval" ControlToValidate="ddlTipoAval"></asp:RequiredFieldValidator>
</div>
<asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" style="padding: 0px 0px 0px 0px; border: none;">
    <ContentTemplate>
        <div class="col-sm-6" style="width: 60%; margin-bottom: 0px; padding-bottom: 0px; padding-top: 0px;">
        </div>
        <div class="col-sm-6">
            <asp:Label runat="server" ID="lblDocumentoAval" Text="Descargar Formato:" Font-Bold="true" />
            <br />
            <a runat="server" id="linkFormato" style="color: #0000EE; background-color: #fff;" visible="false"></a>
            <br />
            <br />
            <asp:Label runat="server" ID="Label1" Text="A continuación cargue anexo diligenciado:" Font-Bold="true" />
            <asp:FileUpload runat="server" ID="fulDocumentoAval" onchange="return CheckFileWithSize(this,1000);" accept="application/pdf" />
            <asp:RequiredFieldValidator ID="rqfulDocumentoAval" ValidationGroup="RadicarF" runat="server" ErrorMessage="Debe cargar documento de Aval # 1" ControlToValidate="fulDocumentoAval"></asp:RequiredFieldValidator>
        </div>
        <div class="col-sm-12" style="width: 100%; margin-bottom: 0px; padding-bottom: 0px; padding-top: 0px;">
            <asp:LinkButton runat="server" ID="btnRadicar" CssClass="button" Style="vertical-align: middle; color: #FFFFFF;" ValidationGroup="RadicarF" OnClick="btnRadicar_Click" OnClientClick="return ValidarCampos();">
            <span>Radicar</span>
            </asp:LinkButton>
            <asp:LinkButton runat="server" ID="btnCancelar" CssClass="buttonBack" Style="vertical-align: middle; color: #FFFFFF;" OnClick="btnCancelar_Click" OnClientClick="LimpiarControles();">
            <span>Cancelar</span>
            </asp:LinkButton>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlTipoAval" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="btnCancelar" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
<h5 class="h3Nivel" style="background-color: #1B80C1; width: 100%;">
    <asp:Label ID="lblEstadoBeneficiario" runat="server"></asp:Label>
</h5>
<asp:HiddenField runat="server" ID="IdSolicitante" />
<asp:UpdatePanel ID="UpdatePanel5" runat="server">
    <ContentTemplate>
        <asp:GridView ID="gvBeneficiario" runat="server" CellPadding="2" BorderStyle="None"
            AutoGenerateColumns="False" Width="100%" AllowPaging="True" PageSize="20" OnPageIndexChanging="gvBeneficiario_PageIndexChanging">
            <AlternatingRowStyle BackColor="#F2F7FF" />
            <Columns>
                <asp:TemplateField HeaderText="# Radicado">
                    <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#1251A3" Font-Size="10px" />
                    <ItemTemplate>
                        <asp:Label ID="lblEditRadicado" runat="server" Text='<% #Eval("IDRADICADO")%>' Font-Size="10px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="Izquierda" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha Registro">
                    <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#1251A3" Font-Size="10px" />
                    <ItemTemplate>
                        <asp:Label ID="lblEditFechaRegistro" runat="server" Text='<% #Eval("FECHA_REGISTRO")%>' Font-Size="10px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="Izquierda" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Resultado">
                    <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#1251A3" Font-Size="10px" />
                    <ItemTemplate>
                        <asp:Label ID="lblEditResultado" runat="server" Text='<% #Eval("NOMBREESTADO")%>' Font-Size="10px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="Izquierda" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Observaciones">
                    <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#1251A3" Font-Size="10px" />
                    <ItemTemplate>
                        <asp:Label ID="lblEditObservaciones" runat="server" Text='<% #Eval("OBSERVACION")%>' Font-Size="10px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="Izquierda" />
                </asp:TemplateField>
            </Columns>
            <PagerSettings Mode="NumericFirstLast" Position="Bottom" FirstPageText="&lt;" LastPageText="&gt;" />
            <PagerStyle HorizontalAlign="Center" CssClass="fila" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#FFFFCC" Font-Bold="True" ForeColor="#0066FF" />
        </asp:GridView>
    </ContentTemplate>
</asp:UpdatePanel>