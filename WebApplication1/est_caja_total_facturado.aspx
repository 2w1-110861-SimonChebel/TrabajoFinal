<%@ Page Title="" Language="C#" MasterPageFile="~/Estadisticas.master" AutoEventWireup="true" CodeBehind="est_caja_total_facturado.aspx.cs" Inherits="Easy_Stock.est_caja_total_facturado" %>

<%@ Import Namespace="Easy_Stock.Entidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login col-md-12 col-xl-12">
        <div id="divTotal" runat="server" class="alert alert-info" style="padding-top: 2%">
            <h3 id="hTotal" runat="server"></h3>
        </div>
    </div>

    <div class="row col-12">



        <div class="col-sm-12 col-xs-12 col-md-6 col-xl-6">

            <div class="row col-12" style="padding-left: 4%">

                <div class="row col-12" style="padding-left: 2%">
                    <h5>Total facturado por dia</h5>
                </div>
                <div class="form-group col-12">
                    <label for="txtFechaDias" class="control-label">Filtrar por fecha especifica</label>
                    <asp:TextBox ID="txtFechaDias" class="form-control" runat="server" TextMode="Date" AutoPostBack="true" OnTextChanged="txtFechaDias_TextChanged">

                    </asp:TextBox>
                </div>
                <div div="divTiempoPorDefecto" class="col-12 alert alert-secondary" runat="server" style="padding-left: 2%">
                    <h6 id="h1" runat="server">(Por defecto hoy)</h6>
                </div>
            </div>


            <div class="row col-12">

                <div class="col-12 alert alert-warning" id="divMensajeNoEncontradoFecha" runat="server" visible="false">
                    <h6 id="hMensajeNoEncontradoFecha" runat="server">No se encontraron resultados para la fecha especificada</h6>
                </div>

                <div id="div1" runat="server" class="col-12">
                    <asp:Chart ID="crtFacturacionPorDia" runat="server" CssClass="table table-bordered table-condensed table-responsive"  Width="380px">
                        <Series>
                            <asp:Series Name="Series">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea">
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>

            </div>

        </div>



        <div class="col-sm-12 col-xs-12 col-md-6 col-xl-6">
            <div class="row col-12" style="padding-left: 4%">

                <div class="row col-12" style="padding-left: 2%">
                    <h5>Total facturado por meses</h5>
                </div>

                <div class="form-group col-12">
                    <label for="cboMeses" class="control-label">Rango de meses</label>
                    <asp:DropDownList class="form-control" ID="cboMeses" name="cboMeses" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cboMeses_SelectedIndexChanged">
                        <asp:ListItem Value="0">- Ultimos 2 meses -</asp:ListItem>
                        <asp:ListItem Value="1">Mes actual</asp:ListItem>
                        <asp:ListItem Value="3">Ultimos 3 meses</asp:ListItem>
                        <asp:ListItem Value="6">Ultimos 6 meses</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div div="divTiempoPorDefecto" class="col-12 alert alert-secondary" runat="server" style="padding-left: 2%">
                    <h6 id="hTiempoPorDefecto" runat="server">(2 últimos meses por defecto)</h6>
                </div>

            </div>

            <div class="col-12 alert alert-warnig" id="divNoEncontradoMes" runat="server" visible="false">
                <h6 id="hMesajeNoEcontradoMes" runat="server">No se encontraron resultados en los meses especificados</h6>
            </div>

            <div class="row col-12">


                <div id="divChartTotalPorMes" runat="server"  class="col-12">
                    <asp:Chart ID="crtFacturacionPorMes" CssClass="table table-bordered table-condensed table-responsive" runat="server" Width="400px">
                        <Series>
                            <asp:Series Name="Series">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea">
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>

            </div>
        </div>




    </div>
    <!-------------------------------------------------------->
    <div class="dropdown-divider"></div>
    <div class="dropdown-divider"></div>
    <div class="row col-12">

        <div class="row col-12" style="padding-left: 4%">
          
            <div class="row col-12" style="padding-left: 2%">
                <h5>Total facturado por año</h5>
            </div>

            <div class="form-group col-12">
                <label for="cboAnios" class="control-label">Por año</label>
                <asp:DropDownList class="form-control" ID="cboAnios" name="cboAnios" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cboAnios_SelectedIndexChanged">
                    <asp:ListItem Value="0">- Año actual -</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div div="divTiempoPorDefecto" class="col-12 alert alert-secondary" runat="server" style="padding-left: 2%">
                <h6 id="h2" runat="server">Año actual por defecto</h6>
            </div>

        </div>

        <div class="col-12 alert alert-warning" id="divMensajeNoEcontradoAnio" runat="server" visible="false">
            <h6 id="hMensajeNoEcontradoAnio" runat="server">No se encontraron resultados para el año especificado</h6>
        </div>

        <div id="divChartAnios" runat="server" class="col-12">

            <asp:Chart ID="crtFacturacionAnio" runat="server" CssClass="table table-bordered table-condensed table-responsive"  Width="900px">
                <Series>
                    <asp:Series Name="Series">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
    </div>



</asp:Content>


