<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="principal.aspx.cs" Inherits="Easy_Stock.principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EasyStock :: Login</title>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
</head>
<body>
    <form id="frmLogin" runat="server">
        <div class="wrapper fadeInDown">
  <div id="formContent">

   <%-- <div class="fadeIn first">
      <img src="http://danielzawadzki.com/codepen/01/icon.svg" id="icon" alt="User Icon" />
    </div>--%>

      <asp:TextBox runat="server" type="text" id="txtEmail" class="fadeIn second" name="login" placeholder="E-mail"></asp:TextBox>
      <asp:TextBox runat="server" type="text" id="txtClave" class="fadeIn third" name="login" placeholder="Clave"></asp:TextBox>


    <%--<div id="formFooter">
      <a class="underlineHover" href="#">Forgot Password?</a>
    </div>--%>

      <asp:Button runat="server" ID="btnIngresar" type="submit" class="fadeIn fourth" value="Ingresar" OnClientClick="validarCampos();" OnClick="BtnIngresar_Click"></asp:Button>


  </div>
</div>
    </form>
 <!--------------------------SCRIPTS----------------------------------------------------------------------->
 <script type="text/javascript">

     function validarCampos() {
     var txtEmail = document.getElementById("txtEmail");
     var txtClave = document.getElementById("txtClave");

     if (txtEmail === null || txtClave === null) alert("Nulos");
     else {
         if (txtEmail.value == "" || txtClave == "") {
             alert("Debe ingresar email y clave");
             return false;
         }
     };
     }
 </script>

</body>

</html>

