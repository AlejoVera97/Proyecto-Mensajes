<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AltaMsjComun.aspx.cs" Inherits="AltaMsjComun" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            border: 2px solid #c0c0c0;
        }
        .style3
        {
            height: 38px;
        }
        .style4
        {
            height: 36px;
        }
        .style5
        {
            height: 30px;
        }
        .style6
        {
            height: 50px;
            width: 400px;
        }
        .style7
        {
            width: 400px;
        }
        .style8
        {
            height: 38px;
            width: 400px;
        }
        .style9
        {
            height: 36px;
            width: 400px;
        }
        .style10
        {
            height: 30px;
            width: 400px;
        }
        .style11
        {
            height: 50px;
            width: 587px;
        }
        .style12
        {
            width: 587px;
        }
        .style13
        {
            height: 38px;
            width: 587px;
        }
        .style14
        {
            height: 36px;
            width: 587px;
        }
        .style15
        {
            height: 30px;
            width: 587px;
        }
        .style16
        {
            height: 42px;
        }
        .style17
        {
            height: 34px;
        }
        .style18
        {
            height: 50px;
        }
        .style19
        {
            height: 48px;
            width: 400px;
        }
        .style20
        {
            height: 48px;
            width: 587px;
        }
        .style21
        {
            height: 48px;
        }
        .style22
        {
            height: 57px;
            width: 400px;
        }
        .style23
        {
            height: 57px;
            width: 587px;
        }
        .style24
        {
            height: 57px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table class="style1">
        <tr>
            <td colspan="3" 
                style="text-align: center; font-size: xx-large; font-weight: 700; text-decoration: underline">
                Alta Mensaje Comun</td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style16">
                Número Interno</td>
            <td class="style16">
                <asp:TextBox ID="TxtNumeroInterno" runat="server"></asp:TextBox>
            </td>
            <td class="style16">
            </td>
        </tr>
        <tr>
            <td class="style17">
                Fecha y Hora</td>
            <td class="style17">
                <asp:TextBox ID="TxtFechaHora" runat="server"></asp:TextBox>
            </td>
            <td class="style17">
            </td>
        </tr>
        <tr>
            <td class="style6">
                Usuario Envía</td>
            <td class="style11">
                <asp:TextBox ID="TxtUsuEnvia" runat="server"></asp:TextBox>
            </td>
            <td class="style18">
&nbsp;&nbsp;
                <asp:Button ID="BtnBuscarUsuEnvia" runat="server" Text="Buscar" />
            </td>
        </tr>
        <tr>
            <td class="style19">
                Usuario Recibe</td>
            <td class="style20">
                <asp:TextBox ID="TxtUsuRecibe" runat="server"></asp:TextBox>
            </td>
            <td class="style21">
&nbsp;&nbsp;
                <asp:Button ID="BtnUsuRecibe" runat="server" Text="Buscar" />
            </td>
        </tr>
        <tr>
            <td class="style8">
                Codigo Tipo de Mensaje</td>
            <td class="style13">
                <asp:TextBox ID="TxtCodTipoMsj" runat="server"></asp:TextBox>
            </td>
            <td class="style3">
&nbsp;&nbsp;
                <asp:Button ID="BtnCodTipoMsj" runat="server" Text="Buscar" />
            </td>
        </tr>
        <tr>
            <td class="style22">
                Asunto</td>
            <td class="style23">
                <asp:TextBox ID="TxtAsunto" runat="server" Height="40px" Width="513px"></asp:TextBox>
            </td>
            <td class="style24">
            </td>
        </tr>
        <tr>
            <td class="style9">
                Texto Mensaje</td>
            <td class="style14">
                <asp:TextBox ID="TxtTextoMsj" runat="server" Height="103px" Width="561px"></asp:TextBox>
            </td>
            <td class="style4">
            </td>
        </tr>
        <tr>
            <td class="style10">
            </td>
            <td class="style15">
            </td>
            <td class="style5">
            </td>
        </tr>
        <tr>
            <td class="style9">
            </td>
            <td class="style14">
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnAltaMsjComun" runat="server" Text="Enviar Mensaje" 
                    style="font-weight: 700" Width="195px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnLimpiarFormulario" runat="server" 
                    Text="Limpiar Formulario" style="font-weight: 700" Width="195px" />
            </td>
            <td class="style4">
            </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style12">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style12">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="LblError" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <div>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LkBVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>