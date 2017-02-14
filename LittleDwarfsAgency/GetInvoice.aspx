<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetInvoice.aspx.cs" Inherits="LittleDwarfsAgency.GetInvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Invoice Handler</title>
</head>
<body>
    <h1>Little Dwarf Care Agency</h1>
    <h2>Invoice Handler</h2>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <h3>Search for Invoice:</h3>
        <asp:TextBox ID="txtInvoice" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click"  Text="Get Invoice" Width="252px" />
        <h4>Invoice:</h4>
        <asp:Table ID="tabInvoice" runat="server" Height="64px" Width="473px" BorderStyle="Solid" GridLines="Both">
            <asp:TableHeaderRow ID="tabInvoiceHeaderRow"
                runat="server">
                <asp:TableHeaderCell
                    Scope="Column"
                    Text="Invoice" />
                <asp:TableHeaderCell
                    Scope="Column"
                    Text="Account Ref" />
                <asp:TableHeaderCell
                    Scope="Column"
                    Text="Date" />
            </asp:TableHeaderRow>
            <asp:TableFooterRow runat="server">
                <asp:TableCell ID="footerTabInvoice" ColumnSpan="3">
                </asp:TableCell>
            </asp:TableFooterRow>
        </asp:Table>
        <h4>Time Sheet Summary:</h4>
        <asp:Table ID="tabInvoiceList" runat="server" Height="206px" Width="473px" BorderStyle="Solid" GridLines="Both">
            <asp:TableHeaderRow ID="tabInvoiceListHeaderRow"
                runat="server">
                <asp:TableHeaderCell
                    Scope="Column"
                    Text="Weekending" />
                <asp:TableHeaderCell
                    Scope="Column"
                    Text="Timesheet" />
                <asp:TableHeaderCell
                    Scope="Column"
                    Text="HoursWorked" />
                <asp:TableHeaderCell
                    Scope="Column"
                    Text="Rate" />
                <asp:TableHeaderCell
                    Scope="Column"
                    Text="Cost" />
            </asp:TableHeaderRow>
        </asp:Table>

    </form>
</body>
</html>
