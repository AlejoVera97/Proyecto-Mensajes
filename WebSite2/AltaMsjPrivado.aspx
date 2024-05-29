<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AltaMsjPrivado.aspx.cs" Inherits="AltaMsjPrivado" %>

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
        .style2
        {
            width: 397px;
        }
        .style3
        {
            width: 397px;
            height: 48px;
        }
        .style4
        {
            height: 48px;
        }
        .style5
        {
            width: 397px;
            height: 38px;
        }
        .style6
        {
            height: 38px;
        }
        .style7
        {
            width: 397px;
            height: 35px;
        }
        .style8
        {
            height: 35px;
        }
        .style9
        {
            width: 397px;
            height: 42px;
        }
        .style10
        {
            height: 42px;
        }
        .style11
        {
            width: 549px;
        }
        .style12
        {
            height: 48px;
            width: 549px;
        }
        .style13
        {
            height: 38px;
            width: 549px;
        }
        .style14
        {
            height: 35px;
            width: 549px;
        }
        .style15
        {
            height: 42px;
            width: 549px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table class="style1">
        <tr>
            <td colspan="3" 
                style="text-align: center; text-decoration: underline; font-weight: 700; font-size: xx-large">
                Alta Mensaje Privado</td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Numero Interno</td>
            <td class="style11">
                <asp:TextBox ID="TxtNumeroInterno" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                Fecha y Hora</td>
            <td class="style12">
                <asp:TextBox ID="TxtFechaHora" runat="server"></asp:TextBox>
            </td>
            <td class="style4">
            </td>
        </tr>
        <tr>
            <td class="style5">
                Usuario Envia</td>
            <td class="style13">
                <asp:TextBox ID="TxtUsuEnvia" runat="server"></asp:TextBox>
            </td>
            <td class="style6">
                <asp:Button ID="BtnBuscarUsuEnv" runat="server" Text="Buscar" 
                    style="font-weight: 700" />
            </td>
        </tr>
        <tr>
            <td class="style7">
                Usuario Recibe</td>
            <td class="style14">
                <asp:TextBox ID="TxtUsuRecibe" runat="server"></asp:TextBox>
            </td>
            <td class="style8">
                <asp:Button ID="BtnBuscarUsuRecibe" runat="server" Text="Buscar" 
                    style="font-weight: 700" />
            </td>
        </tr>
        <tr>
            <td class="style9">
                Fecha Caducidad</td>
            <td class="style15">
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </td>
            <td class="style10">
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style11">
                <asp:Button ID="BtnAltaMsj" runat="server" Text="Enviar Mensaje" Width="195px" 
                    style="font-weight: 700" />
            &nbsp;&nbsp;
                <asp:Button ID="BtnLimpiarFormulario" runat="server" 
                    Text="Limpiar Formulario" onclick="BtnLimpiarFormulario_Click" 
                    style="font-weight: 700" Width="195px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style11">
                <asp:Label ID="LblError" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style11">
                <asp:LinkButton ID="LkBVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <div>
    
    </div>
    </form>
</body>
</html>