﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="validar.aspx.cs" Inherits="Easy_Stock.validar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reestablecer clave</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <link href="Bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="Bootstrap/css/bootstrap.grid.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login col-md-6 col-xl-6">

            <div id="divMensaje" class="alert alert-warning" runat="server" style="display: none">
                <h6 id="hMensaje" runat="server">Las contraseñas deben coincidir</h6>
            </div>

             <div class="form-group">
                <asp:TextBox runat="server" type="text" ID="txtEmail" class="form-control" name="txtEmail" Enabled="false" Visible="true"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:TextBox runat="server" type="password" ID="txtClave1" class="form-control" name="login" placeholder="Nueva contraseña"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox runat="server" type="password" ID="txtClave2" class="form-control" name="login" placeholder="Confirme contraseña"></asp:TextBox>
            </div>

            <div class="form-group centrarItemsDiv">
                <asp:Button runat="server" ID="btnReestablecer" type="submit" class="btn btn-primary" Text="Reestablecer" OnClientClick="return validarCampos();" OnClick="btnReestablecer_Click"></asp:Button>
            </div>
        </div>



        <style>
            .centrarItemsDiv {
                display: flex;
                justify-content: center;
                align-items: center;
            }


            /* 'Open Sans' font from Google Fonts */
            @import url(https://fonts.googleapis.com/css?family=Open+Sans:400,700);

            body {
                background: #ebebeb;
                font-family: 'Open Sans', sans-serif;
            }

            .login {
                width: 400px;
                margin: 16px auto;
                font-size: 16px;
            }

                /* Reset top and bottom margins from certain elements */
                .login-header,
                .login p {
                    margin-top: 0;
                    margin-bottom: 0;
                }

            /* The triangle form is achieved by a CSS hack */
            .login-triangle {
                width: 0;
                margin-right: auto;
                margin-left: auto;
                border: 12px solid transparent;
                border-bottom-color: #28d;
            }

            .login-header {
                background: #28d;
                padding: 20px;
                font-size: 1.4em;
                font-weight: normal;
                text-align: center;
                text-transform: uppercase;
                color: #fff;
            }

            .login-container {
                background: #ebebeb;
                padding: 12px;
            }

            /* Every row inside .login-container is defined with p tags */
            .login p {
                padding: 12px;
            }

            .login input {
                box-sizing: border-box;
                display: block;
                width: 100%;
                border-width: 1px;
                border-style: solid;
                padding: 16px;
                outline: 0;
                font-family: inherit;
                font-size: 0.95em;
            }

                .login input[type="email"],
                .login input[type="password"] {
                    background: #fff;
                    border-color: #bbb;
                    color: #555;
                }

                    /* Text fields' focus effect */
                    .login input[type="email"]:focus,
                    .login input[type="password"]:focus {
                        border-color: #888;
                    }

                .login input[type="submit"] {
                    background: #28d;
                    border-color: transparent;
                    color: #fff;
                    cursor: pointer;
                }

                    .login input[type="submit"]:hover {
                        background: #17c;
                    }

                    /* Buttons' focus effect */
                    .login input[type="submit"]:focus {
                        border-color: #05a;
                    }
        </style>

        <script type="text/javascript">

            function validarCampos() {
                var txtClave1 = document.getElementById("txtClave1");
                var txtClave2 = document.getElementById("txtClave2");

                if (txtClave1.value == "" || txtClave2.value == "") {
                    alert("Complete ambos campos");
                    return false;
                };

                if (txtClave1.value !== txtClave2.value) {
                    document.getElementById("divMensaje").style.display = "block";
                    return false;
                };

                document.getElementById("divMensaje").style.display = "none";

            }
        </script>
    </form>
</body>
</html>