<%@ Page Title="Order Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="FronEndClassicDev.Orders" %>

<asp:Content ID="OrdersContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
   <!--
       <asp:ObjectDataSource ID="ordersDataSource"
            runat="server" TypeName="FronEndClassicDev.Models.OrderDetailDAL"
            SortParameterName="SortExpression"
            SelectMethod="GetOrders"            
            EnablePaging="True">
        </asp:ObjectDataSource>
        <asp:GridView ID="ordersGridView" runat="server"
            DataSourceID="ordersDataSource" AllowSorting="True"
            AutoGenerateColumns="False" AllowPaging="True">
            <Columns>
                <asp:BoundField HeaderText="OrderID" DataField="OrderID"
                    SortExpression="OrderID"></asp:BoundField>
                <asp:BoundField HeaderText="ProductID" DataField="ProductID" SortExpression="ProductID"></asp:BoundField>
                <asp:BoundField HeaderText="Quantity" DataField="Quantity" SortExpression="Quantity"></asp:BoundField>
                <asp:BoundField HeaderText="UnitPrice" DataField="UnitPrice" SortExpression="UnitPrice"></asp:BoundField>
            </Columns>
        </asp:GridView>
    -->

        <asp:SqlDataSource ID="ordersDataSource1" runat="server" SelectCommand="SELECT [OrderID], [ProductID], [Quantity], [UnitPrice] FROM [Order Details]"
            ConnectionString="<%$ ConnectionStrings:NWConnectionString %>" DataSourceMode="DataReader"></asp:SqlDataSource>
        <asp:GridView ID="ordersGridView1" runat="server" DataSourceID="ordersDataSource1"
            DataKeyNames="OrderID" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField ReadOnly="True" HeaderText="OrderID" InsertVisible="False" DataField="OrderID"
                    SortExpression="OrderID"></asp:BoundField>
                <asp:BoundField HeaderText="ProductID" DataField="ProductID" SortExpression="ProductID"></asp:BoundField>
                <asp:BoundField HeaderText="Quantity" DataField="Quantity" SortExpression="Quantity"></asp:BoundField>
                <asp:BoundField HeaderText="UnitPrice" DataField="UnitPrice" SortExpression="UnitPrice"></asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
