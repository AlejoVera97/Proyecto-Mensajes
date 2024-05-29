<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MantenimientoTipoMsj.aspx.cs" Inherits="MantenimientoTipoMsj" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            border-style: solid;
            border-width: 2px;
        }
        .style2
        {
        }
        .style3
        {
            width: 589px;
        }
        .style4
        {
            height: 51px;
            width: 396px;
        }
        .style5
        {
            width: 589px;
            height: 51px;
        }
        .style6
        {
            height: 51px;
            width: 225px;
        }
        .style7
        {
            width: 225px;
        }
        .style8
        {
            width: 396px;
        }
        .style9
        {
            width: 225px;
            height: 26px;
        }
        .style10
        {
            width: 589px;
            height: 26px;
        }
        .style11
        {
            width: 396px;
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <table class="style1">
        <tr>
            <td colspan="3" 
                style="text-align: center; font-size: xx-large; font-weight: 700">
                Mantenimiento Tipo de Mensaje</td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                Código de tipo</td>
            <td class="style5">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TxtCodTipo" runat="server" Width="109px"></asp:TextBox>
            </td>
            <td class="style4">
                <asp:Button ID="BtnBuscar" runat="server" Text="Buscar Tipo" Width="195px" 
                    onclick="BtnBuscar_Click" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                Nombre de tipo</td>
            <td class="style2">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TxtNomTipo" runat="server" Width="189px"></asp:TextBox>
            </td>
            <td class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" colspan="3">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button 
                    ID="BtnModificar" runat="server" Text="Modificar Mensaje" Width="195px" 
                    onclick="BtnModificar_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnAlta" runat="server" Text="Alta Mensaje" Width="195px" 
                    onclick="BtnAlta_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnBaja" runat="server" Text="Eliminar Mensaje" Width="195px" 
                    onclick="BtnBaja_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnLimpiar" runat="server" Text="Limpiar Formulario" 
                    Width="195px" onclick="BtnLimpiar_Click" />
&nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style3">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="LblError" runat="server"></asp:Label>
            </td>
            <td class="style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                </td>
            <td class="style10">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LkBVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
            </td>
            <td class="style11">
                </td>
        </tr>
    </table>
    </form>
</body>
</html>