<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="TestLogXAF.Web.WebUserControl1" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<dx:ASPxGridView ID="grid" runat="server" DataSourceForceStandardPaging="True" AutoGenerateColumns="False"
                DataSourceID="ods" KeyFieldName="ContactID">
                <Columns>
        <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0">
        </dx:GridViewCommandColumn>
        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Oid" VisibleIndex="2" Visible="False">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataMemoColumn FieldName="Data" VisibleIndex="3">
        </dx:GridViewDataMemoColumn>
        <dx:GridViewDataTextColumn FieldName="ChangedBy" VisibleIndex="4">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="CategoryAudit" VisibleIndex="5">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ActionAudit" VisibleIndex="6">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataDateColumn FieldName="ChangedOn" VisibleIndex="7">
        </dx:GridViewDataDateColumn>
    </Columns>
    <SettingsPager AlwaysShowPager="True">
    </SettingsPager>
    <Settings ShowFilterRow="True" />
            </dx:ASPxGridView>
            <asp:ObjectDataSource ID="ods" runat="server" SortParameterName="sortColumns" EnablePaging="true"
                StartRowIndexParameterName="startRecord" MaximumRowsParameterName="maxRecords"
                SelectCountMethod="GetPeopleCount" SelectMethod="GetPeople" TypeName="People"></asp:ObjectDataSource>


<%--<asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>--%>




