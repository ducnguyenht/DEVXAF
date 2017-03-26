<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
      <form id="form1" runat="server">
    <dx:ASPxGridView ID="grid" runat="server" DataSourceForceStandardPaging="True" AutoGenerateColumns="False"
                DataSourceID="ods">
        <Columns>
        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="0">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Oid" VisibleIndex="1">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Data" VisibleIndex="2">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ChangedBy" VisibleIndex="3">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Category" VisibleIndex="4">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Action" VisibleIndex="5">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataDateColumn FieldName="ChangedOn" VisibleIndex="6">
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataCheckColumn FieldName="IsValid" ReadOnly="True" VisibleIndex="7">
        </dx:GridViewDataCheckColumn>
    </Columns>
    </dx:ASPxGridView>
     <asp:ObjectDataSource ID="ods" runat="server" SortParameterName="sortColumns" EnablePaging="true"
                StartRowIndexParameterName="startRecord" MaximumRowsParameterName="maxRecords"
                SelectCountMethod="Total" SelectMethod="GetAuditTrail" TypeName="WebApplication1.Models.AuditTrailViewModel"></asp:ObjectDataSource>
</form>
</body>

</html>
