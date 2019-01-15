<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeBehind="NivelFormacion.aspx.cs" Inherits="FondosycCondonacion.UI.NivelFormacion.NivelFormacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" ClientIDMode="Static" runat="Server">
    <div class="container" style="text-align: center;">
        <img id="imgBanner" runat="server" style="text-align: center;" />
        <h1>ELIJA SU NIVEL DE FORMACION</h1>
        <div class="form-group">
            <asp:ImageButton ID="imgEspecializacion" runat="server" ImageUrl="~/Images/boton_especializacion.jpg" OnClick="imgEspecializacion_Click" />
            <asp:ImageButton ID="imgMaestria" runat="server" ImageUrl="~/Images/boton_maestria.jpg" OnClick="imgMaestria_Click" />
        </div>
    </div>
</asp:Content>
