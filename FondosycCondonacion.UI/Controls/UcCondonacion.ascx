<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcCondonacion.ascx.cs" Inherits="FondosycCondonacion.UI.Controls.UcCondonacion" %>

<br />
<div class="col-sm-6" style="margin-bottom: 0px; padding-bottom: 10px; padding-top: 0px;">
    <asp:Label runat="server" ID="lblCertifPermEstado" Text="1. Acreditar permanencia en el Estado" Font-Bold="true" />
    <asp:FileUpload runat="server" ID="fulCertifPermEstado" onchange="return CheckFileWithSize(this,2000);" accept="application/pdf" />
    <asp:RequiredFieldValidator ID="rqfulCertifPermEstado" ValidationGroup="Radicar" runat="server" ErrorMessage="Debe cargar documento para Acreditar permanencia en el Estado" ControlToValidate="fulCertifPermEstado"></asp:RequiredFieldValidator>
</div>
<div class="col-sm-6" style="margin-bottom: 0px; padding-bottom: 10px; padding-top: 0px;">
    <asp:Label runat="server" ID="lblCertifPromNotas" Text="2. Certificado del promedio de notas" Font-Bold="true" />
    <asp:FileUpload runat="server" ID="fulCertifPromNotas" onchange="return CheckFileWithSize(this,1000);" accept="application/pdf" />
    <asp:RequiredFieldValidator ID="rqfulCertifPromNotas" ValidationGroup="Radicar" runat="server" ErrorMessage="Debe cargar documento de Certificado del promedio de notas" ControlToValidate="fulCertifPromNotas"></asp:RequiredFieldValidator>
</div>
<div class="col-sm-6" style="margin-bottom: 0px; padding-bottom: 10px; padding-top: 0px;">
    <asp:Label runat="server" ID="lblCertifProgCursado" Text="3. Certificado del programa cursado" Font-Bold="true" />
    <asp:FileUpload runat="server" ID="fulCertifProgCursado" onchange="return CheckFileWithSize(this,1000);" accept="application/pdf" />
    <asp:RequiredFieldValidator ID="rqfulCertifProgCursado" ValidationGroup="Radicar" runat="server" ErrorMessage="Debe cargar documento de Certificado del programa cursado" ControlToValidate="fulCertifProgCursado"></asp:RequiredFieldValidator>
</div>
<div class="col-sm-6" style="margin-bottom: 0px; padding-bottom: 10px; padding-top: 0px;">
    <asp:Label runat="server" ID="lblCertifDiploma" Text="4. Diploma y Acta de grado" Font-Bold="true" />
    <asp:FileUpload runat="server" ID="fulCertifDiploma" onchange="return CheckFileWithSize(this,1000);" accept="application/pdf" />
    <asp:RequiredFieldValidator ID="rqfulCertifDiploma" ValidationGroup="Radicar" runat="server" ErrorMessage="Debe cargar documento de Diploma y Acta de grado" ControlToValidate="fulCertifDiploma"></asp:RequiredFieldValidator>
</div>
<div class="col-sm-6" style="margin-bottom: 0px; padding-bottom: 10px; padding-top: 0px;">
    <asp:Label runat="server" ID="lblCertifParticipacion" Text="5. Participación en comunidad de práctica" Font-Bold="true" />
    <div class="row">
        <div class="col-sm-2">
            <asp:TextBox runat="server" ID="txtPuntajeComunidad" class="form-control" disabled Style="width: 90px; height: auto;"></asp:TextBox>
        </div>
        <div class="col-sm-6">
            <div runat="server" id="divPuntaje"></div>
        </div>
    </div>
</div>
<div class="col-sm-6" style="margin-bottom: 0px; padding-bottom: 10px; padding-top: 0px;">
    <asp:Label runat="server" ID="lblVideoYoutube" Text="6. Digitar url o enlace Youtube de video testimonial" Font-Bold="true" />
    <asp:TextBox runat="server" ID="txtVideoYoutube" class="form-control" MaxLength="300" Style="font-size: 10px; height: auto;" PlaceHolder="Ejemplo: https://www.youtube.com/?gl=CO&hl=es-419" size="300"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rqtxtVideoYoutube" ValidationGroup="Radicar" runat="server" ErrorMessage="Debe digitar url o enlace Youtube de video institucional" ControlToValidate="txtVideoYoutube"></asp:RequiredFieldValidator>
</div>
<div class="col-sm-6" style="margin-bottom: 0px; padding-bottom: 10px; padding-top: 0px;">
    <asp:Label runat="server" ID="lblSoporteCondonacion" Text="7. Descargar Soporte y recibo de aceptación:" Font-Bold="true" />
    <br />
    <a runat="server" id="linkSoporte" style="color: #0000EE; background-color: #fff;" visible="false"></a>
    <br />
    <br />
    <asp:Label runat="server" ID="lblSoporte" Text="A continuación cargue soporte y recibo de aceptación diligenciado:" Font-Bold="true" />
    <asp:FileUpload runat="server" ID="fulCertifSoporte" onchange="return CheckFileWithSize(this,1000);" accept="application/pdf" />
    <asp:RequiredFieldValidator ID="rqfulCertifSoporte" ValidationGroup="Radicar" runat="server" ErrorMessage="Debe cargar documento de Soporte y recibo de aceptación" ControlToValidate="fulCertifSoporte"></asp:RequiredFieldValidator>
</div>
<div class="col-sm-6" style="margin-bottom: 0px; padding-bottom: 10px; padding-top: 0px;">
    <asp:Label runat="server" ID="lblFormatoCondonacion" Text="Descargar Formato:" Font-Bold="true" />
    <br />
    <a runat="server" id="linkCertifFormato" style="color: #0000EE; background-color: #fff;" visible="false"></a>
    <br />
    <br />
    <asp:Label runat="server" ID="lblCertifFormato" Text="A continuación cargue formato diligenciado:" Font-Bold="true" />
    <asp:FileUpload runat="server" ID="fulCertifFormato" onchange="return CheckFileWithSize(this,1000);" accept="application/pdf" />
    <asp:RequiredFieldValidator ID="rqfulCertifFormato" ValidationGroup="Radicar" runat="server" ErrorMessage="Debe cargar Formato" ControlToValidate="fulCertifFormato"></asp:RequiredFieldValidator>
</div>
<div class="col-sm-12" style="margin-bottom: 0px; padding-bottom: 10px; padding-top: 0px;">
    <asp:Label runat="server" ID="lblCertifFinMaterias" Text="8. Certificado con fecha de Inicio y Terminación de Materias:" Font-Bold="true" />
    <asp:FileUpload runat="server" ID="fulCertifFinMaterias" onchange="return CheckFileWithSize(this,1000);" accept="application/pdf" />
    <asp:RequiredFieldValidator ID="rqfulCertifFinMaterias" ValidationGroup="Radicar" runat="server" ErrorMessage="Debe cargar Certificado con fecha de Inicio y Terminación de Materias" ControlToValidate="fulCertifFinMaterias"></asp:RequiredFieldValidator>
</div>
<div runat="server" id="divCondonacionEstado" class="col-sm-12" style="background-color: #0073e6; color: white;">
    <asp:Label runat="server" ID="lblCondonacionEstado" Font-Bold="true" Text="Estado solicitud: Documentación Incompleta" />
</div>

<div class="col-sm-6" style="margin-bottom: 0px; padding-bottom: 10px; padding-top: 0px;">
    <asp:Label runat="server" ID="lblCertifDocRequer" Text="Adjuntar documentos requeridos:" Font-Bold="true" />
    <asp:FileUpload runat="server" ID="fulCertifDocRequer" onchange="return CheckFileWithSize(this,4000);" accept="application/pdf" />
    <asp:RequiredFieldValidator ID="rqfulCertifDocRequer" ValidationGroup="Radicar" runat="server" ErrorMessage="Debe adjuntar documentos requeridos" ControlToValidate="fulCertifDocRequer"></asp:RequiredFieldValidator>

    <asp:Label runat="server" ID="lblCertifDocSubsanacion" Text="Adjuntar Documento Subsanación:" Font-Bold="true" />
    <asp:FileUpload runat="server" ID="fulCertifDocSubsanacion" onchange="return CheckFileWithSize(this,4000);" accept="application/pdf" />
    <asp:RequiredFieldValidator ID="rqfulCertifDocSubsanacion" ValidationGroup="Radicar" runat="server" ErrorMessage="Debe adjuntar documento de subsanación" ControlToValidate="fulCertifDocSubsanacion"></asp:RequiredFieldValidator>
</div>
<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" style="padding: 0px 0px 0px 0px; border: none;">
    <ContentTemplate>
        <div class="col-sm-12" style="width: 100%; margin-bottom: 0px; padding-bottom: 0px; padding-top: 0px;">
            <asp:LinkButton runat="server" ID="btnRadicar" CssClass="button" Style="vertical-align: middle; color: #FFFFFF;" ValidationGroup="Radicar" OnClick="btnRadicar_Click">
            <span>Radicar</span>
            </asp:LinkButton>
            <asp:LinkButton runat="server" ID="btnCancelar" CssClass="buttonBack" Style="vertical-align: middle; color: #FFFFFF;" OnClientClick="LimpiarControlesCond();" OnClick="btnCancelar_Click">
            <span>Cancelar</span>
            </asp:LinkButton>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnCancelar" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
<h5 class="h3Nivel" style="background-color: #1B80C1; width: 100%;">
    <asp:Label ID="lblEstadoBeneficiario" runat="server"></asp:Label>
</h5>
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>
        <asp:GridView ID="gvBeneficiario" runat="server" CellPadding="2" BorderStyle="None"
            AutoGenerateColumns="False" Width="100%" AllowPaging="True" PageSize="20" OnPageIndexChanging="gvBeneficiario_PageIndexChanging" OnRowDataBound="gvBeneficiario_RowDataBound">
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
