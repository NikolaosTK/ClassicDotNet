<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Inherits="FronEndClassicDev._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:SqlDataSource ID="productsDataSource" Runat="server" SelectCommand="SELECT [ProductID], [ProductName], [QuantityPerUnit], [UnitPrice], [UnitsInStock] FROM [Products]"
            ConnectionString="<%$ ConnectionStrings:NWConnectionString %>" DataSourceMode="DataReader">
        </asp:SqlDataSource>
        <asp:GridView ID="productGridView" Runat="server" DataSourceID="productsDataSource"
            DataKeyNames="ProductID" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField ReadOnly="True" HeaderText="ProductID" InsertVisible="False" DataField="ProductID"
                    SortExpression="ProductID"></asp:BoundField>
                <asp:BoundField HeaderText="ProductName" DataField="ProductName" SortExpression="ProductName"></asp:BoundField>
                <asp:BoundField HeaderText="QuantityPerUnit" DataField="QuantityPerUnit" SortExpression="QuantityPerUnit"></asp:BoundField>
                <asp:BoundField HeaderText="UnitPrice" DataField="UnitPrice" SortExpression="UnitPrice"></asp:BoundField>
                <asp:BoundField HeaderText="UnitsInStock" DataField="UnitsInStock" SortExpression="UnitsInStock"></asp:BoundField>
            </Columns>
        </asp:GridView>
    
    </div>
</asp:Content>
