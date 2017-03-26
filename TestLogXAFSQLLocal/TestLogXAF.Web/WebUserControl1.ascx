<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="TestLogXAF.Web.WebUserControl1" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" KeyFieldName="Id">
    <Columns>
        <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" VisibleIndex="0">
        </dx:GridViewCommandColumn>
        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1" ShowInCustomizationForm="True">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Oid" VisibleIndex="2" ShowInCustomizationForm="True">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Data" VisibleIndex="3" ShowInCustomizationForm="True">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ChangedBy" VisibleIndex="4" ShowInCustomizationForm="True">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Category" VisibleIndex="5" ShowInCustomizationForm="True">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Action" VisibleIndex="6" ShowInCustomizationForm="True">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataDateColumn FieldName="ChangedOn" VisibleIndex="7" ShowInCustomizationForm="True">
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataCheckColumn FieldName="IsValid" ReadOnly="True" VisibleIndex="8" ShowInCustomizationForm="True">
        </dx:GridViewDataCheckColumn>
    </Columns>
    <Settings ShowFilterRow="True" />
</dx:ASPxGridView>



