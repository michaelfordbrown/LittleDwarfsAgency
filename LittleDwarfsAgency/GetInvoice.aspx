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
        <asp:TextBox ID="txtInvoice" runat="server">499</asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Get Invoice" Width="252px" />
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

        <h3>Append New Invoice:</h3>
        <h4>Enter New Invoice Data</h4>
        <asp:TextBox ID="txtIdSub" runat="server">Id</asp:TextBox><br />
        <asp:TextBox ID="txtInvoiceSub" runat="server">Invoice</asp:TextBox><br />
        <asp:TextBox ID="txtAccountRefSub" runat="server">Account Reference</asp:TextBox><br />
        <asp:TextBox ID="txtInvoiceDateSub" runat="server">Invoice Date</asp:TextBox><br />
        <br />
        <asp:Button ID="btnSubInvoice" runat="server" OnClick="btnSubInvoice_Click" Text="Submit Invoice" Width="252px" />

        <h4>Enter New Time Sheet Summary For Invoice</h4>

        <asp:Label ID="Label1" runat="server" Text="Weekending Date" Width="240px"></asp:Label>&nbsp
        <asp:Label ID="Label2" runat="server" Text="Time Sheet Number" Width="240px"></asp:Label>&nbsp
        <asp:Label ID="Label4" runat="server" Text="Hours Worked" Width="240px"></asp:Label>&nbsp
        <asp:Label ID="Label5" runat="server" Text="Rate" Width="240px"></asp:Label>&nbsp
        <asp:Label ID="Label6" runat="server" Text="Cost" Width="240px"></asp:Label><br />

        <asp:TextBox ID="txtWeekendingSub" runat="server" Width="240px">yyyy/mm/dd</asp:TextBox>&nbsp
        <asp:TextBox ID="txtTimesheetSub" runat="server" Width="240px">nnnnnnnn</asp:TextBox>&nbsp
        <asp:TextBox ID="txtHoursWorkedSub" runat="server" Width="240px">££.pp</asp:TextBox>&nbsp
        <asp:TextBox ID="txtRateSub" runat="server" Width="240px">££.pp</asp:TextBox>&nbsp
        <asp:TextBox ID="txtCostSub" runat="server" Width="240px">££.pp</asp:TextBox>&nbsp
        <asp:Button ID="btnSubInvoiceList" runat="server" OnClick="btnSubInvoiceList_Click" Text="Submit Time Sheet Summary" Width="252px" />

    </form>
</body>
</html>
