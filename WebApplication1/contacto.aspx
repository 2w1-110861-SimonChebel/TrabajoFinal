<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="contacto.aspx.cs" Inherits="Easy_Stock.contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row col-12 alert alert-info">
        <h5>Contactenos</h5>
    </div>

    <ul>
        <li>Télefono: 231238438</li>
        <li>Email: easystockar@gmail.com</li>
    </ul>
    <div class="row col-6 col-sm-12 col-md-6" style="margin: 1%">
        <h6>O bien, visitenos en nuestras oficinas: </h6>
        <h5><strong>Maestro Marcelo López esq, Cruz Roja, Córdoba</strong> </h5> 
         <a id="btnVerMapa" href="https://www.google.com/maps/search/?api=1&query=Maestro Marcelo López esq, Cruz Roja,Córdoba" style="margin-left:1%" target="_blank">Ver en mapa</a>
        <%--<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d13566.89508901391!2d35.2354079!3d31.7780191!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0xe33f01a44e2808aa!2sMaestro+Marcelo+Lopez+esq,+Cruz+Roja,+Cordoba!5e0!3m2!1ses-419!2smx!4v1477799410016" width="600" height="450" frameborder="0" style="border: 0" allowfullscreen></iframe>--%>
    </div>

</asp:Content>
