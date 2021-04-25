<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="principal.aspx.cs" Inherits="Easy_Stock.principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EasyStock :: Login</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <link href="Bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="Bootstrap/css/bootstrap.grid.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmLogin" runat="server">

        <div class="container login-container" style="display:block; justify-content:center;">
            <div class="row">
                <div class="col-md-6 login-form-1">
                    <h3>Ingresar</h3>

                    <div class="form-group">
                        <asp:TextBox runat="server" type="text" ID="txtEmail" class="form-control" name="login" placeholder="E-mail"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" type="text" ID="txtClave" class="form-control" name="login" placeholder="Clave"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button runat="server" ID="btnIngresar" type="submit" class="btn btn-primary" Text="Ingresar" OnClientClick="return validarCampos();" OnClick="BtnIngresar_Click"></asp:Button>
                    </div>
                    <div class="form-group">
                        <a href="#" class="btnForgetPwd">Olvide mi contraseña</a>
                    </div>

                </div>
    </form>
    </div>
            </div>
        </div>
    <!--------------------------SCRIPTS----------------------------------------------------------------------->
    <script type="text/javascript">

        function validarCampos() {
            var txtEmail = document.getElementById("txtEmail");
            var txtClave = document.getElementById("txtClave");

            if (txtEmail === null || txtClave === null) alert("Nulos");
            else {
                if (txtEmail.value == "" || txtClave.value == "") {
                    alert("Debe ingresar email y clave");
                    return false;
                }
            };
        }
    </script>

</body>

</html>

