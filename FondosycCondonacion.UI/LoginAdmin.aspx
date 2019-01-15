<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginAdmin.aspx.cs" Inherits="FondosycCondonacion.UI.LoginAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/main.min.css" rel="stylesheet" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="js/jquery-ui-1.11.4/jquery-ui.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <link href="Styles/StyleLogin.css" rel="stylesheet" />

    <script src="js/jquery-2.2.3.min.js"></script>
    <script src="js/bootstrap-3.3.6-dist/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#error").empty();
        });

        $('#txtPassword').bind('keyup', function (e) {
            var key = e.keyCode || e.which;
            if (key === 13) {
                $('#btnLogIn').click();
            };
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <img src="Images/banner_login.jpg" />
        <div id="logInMainForm" clientidmode="Static" runat="server" class="col-xs-7 log-virtual student">
            <div class="icon-box">
                <div class="icon icon-hand">
                    <img src="App_Themes/Imagenes/hand-icon.png" alt="login" runat="server" />
                </div>
            </div>
            <div class="login-form">
                <asp:Login ID="LoginMain" runat="server" OnAuthenticate="LoginMain_Authenticate" on Width="500px">
                    <LayoutTemplate>
                        <h2>
                            <asp:Label runat="server" ID="lblOficinaVirtual">Ingreso de funcionarios</asp:Label></h2>
                        <p>
                            <asp:Label runat="server" ID="lblLoginBoxMessage"> Ingrese al modulo de condonaciones con su usuario y contraseña para realizar operaciones referentes a la condonacion de créditos.</asp:Label>

                        </p>
                        <fieldset class="box-field">
                            <label for="txtUserName" class="hide">Usuario</label>
                            <asp:TextBox ID="UserName" ClientIDMode="Static" placeholder="Usuario" runat="server" MaxLength="50" autocomplete="off"
                                required type="text"></asp:TextBox>
                        </fieldset>
                        <fieldset class="box-field">
                            <label for="txtPassword" class="hide">Contraseña</label>
                            <asp:TextBox ID="Password" ClientIDMode="Static" TextMode="Password" placeholder="Contraseña" runat="server" autocomplete="off"
                                required></asp:TextBox>
                        </fieldset>
                        <fieldset class="box-field">
                            <label for="txtCapcha" class="hide">Digite el código de seguridad:</label>
                            <asp:TextBox ID="txtCapcha" runat="server" ClientIDMode="Static" placeholder="Digite el código de seguridad:" required></asp:TextBox>
                            <iframe id="Iframe1" runat="server" src="ShowCaptcha.htm" style="width: 140px; height: 60px; margin: 0px; padding: 0px;" frameborder="0" scrolling="no"></iframe>
                            <asp:LinkButton ID="REFRESCAR" runat="server" ToolTip="Cambiar Imagen" TabIndex="-1" OnClientClick="location.reload();">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Refresh.png" />
                            </asp:LinkButton>
                        </fieldset>
                        <div>
                            <asp:Button ID="btnLogIn" Text="LogIn" CommandName="Login" OnClientClick="return validateRegisterStudent()" runat="server" class="txt-center button" />
                        </div>
                        <div id="error">
                            <asp:Label ID="FailureText" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                        </td></div>
                    </LayoutTemplate>
                </asp:Login>
            </div>
        </div>
    </form>
</body>
</html>
