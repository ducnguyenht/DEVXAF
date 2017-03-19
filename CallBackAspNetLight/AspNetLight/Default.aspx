<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AspNetLight._Default" EnableEventValidation ="false" ValidateRequest ="false" ViewStateEncryptionMode="Never"    %>

<%@ Register Assembly="WebGui" Namespace="WebGui.AEDropDownList" TagPrefix="cc1" %>
<%@ Register Assembly="WebGui" Namespace="WebGui.AEButton" TagPrefix="cc2" %>
<%@ Register Assembly="WebGui" Namespace="WebGui.AECheckBox" TagPrefix="cc3" %>
<%@ Register Assembly="WebGui" Namespace="WebGui.AETextBox" TagPrefix="cc4" %>







<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script language=javascript >   
    //Must Be Auto Generate into the page
    function GetReponse(argument)
    {
        var elementId;
        var innerHtmlStr;      
         if (argument != null & argument != "")
          {
             var tableauM=argument.split("§");         
             //document.getElementById("__VIEWSTATE").value=tableauM[0];
             document.getElementById("__VIEWSTATE").setAttribute("value",tableauM[0]);
             var tableau=tableauM[1].split("|");
             elementId=tableau[0] ;
             innerHtmlStr=tableau[1] ;
             document.getElementById(elementId).outerHTML=innerHtmlStr;
             
            
          }
    }
    
 
   
    </script>

  
</head>
<body >
    <form id="form1" runat="server">
        &nbsp;<table style="width: 325px; height: 135px" border="dotted">
            <tr>
                <td style="width: 185px">
                    <asp:Label ID="Label1" runat="server" Text="AE Controls"></asp:Label></td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Asp.net Controls"></asp:Label></td>
                
            </tr>
            <tr>
                <td style="width: 185px">
                    <cc1:aedropdownlist id="AEDropDownList1" runat="server" isrendercontrol="True" onselectedindexchanged="AEDropDownList1_SelectedIndexChanged"
                        width="122px"><asp:ListItem>Blue</asp:ListItem>
<asp:ListItem>Red</asp:ListItem>
<asp:ListItem>Green</asp:ListItem>
</cc1:aedropdownlist>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Change my Color!" Width="122px" /></td>
                
            </tr>
            <tr>
                <td style="width: 185px">
                    <cc2:aebutton id="AEButton1" runat="server" isrendercontrol="True" onclick="AEButton1_Click"></cc2:aebutton>
                </td>
                <td>
                    <asp:CheckBox ID="CheckBox1" runat="server" /></td>
            
            </tr>
             <tr>
                <td style="width: 185px">
                    <cc3:aecheckbox id="AECheckBox1" runat="server" isrendercontrol="True" oncheckedchanged="AECheckBox1_CheckedChanged"
                        text="Make Textbox Readonly" width="160px"></cc3:aecheckbox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            
            </tr>
             <tr>
                <td style="width: 185px">
                    <cc4:aetextbox id="AETextBox1" runat="server" isrendercontrol="True" ontextchanged="AETextBox1_TextChanged"></cc4:aetextbox>
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Change my Text!" /></td>
            
            </tr>
        </table>

    </form>
    
    
</body>
</html>