<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoiceHandler.aspx.cs" Inherits="LittleDwarfsAgency.GetInvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Invoice Handler</title>
</head>
<body>
    <h1>Little Dwarf Care Agency (3 Tier Architecture Model)</h1>
    <p>I have developed a 3 tier architecture model (3TA Model) to work with my Little Dwarf Agency database.</p>
    <p>This is an experiment for me to experience working with the 3TA model. I view a 3TA model as a multi-tier/multi-layered architecture with a client–server architecture in which presentation, application processing, and data management functions are physically separated. </p>
    <p>
        The 3TA  provides a model by which developers can create flexible and reusable applications. 
        Applications are segregated into tiers acquires the option of modifying or adding a specific layer, instead of reworking the entire application.
    </p>
    <p>It is typically composed of a Presentation tier, a Application tier, and a Data tier:</p>

    <ul>
        <li>
            <h3>Presentation tier</h3>
            <p>This is the topmost level of the application. The presentation tier displays information related to such services as browsing merchandise, purchasing and shopping cart contents. It communicates with other tiers by which it puts out the results to the browser/client tier and all other tiers in the network. In simple terms, it is a layer which users can access directly (such as a web page, or an operating system's GUI).</p>
            <a href="https://github.com/michaelfordbrown/LittleDwarfsAgency/blob/master/LittleDwarfsAgency/GetInvoice.aspx.cs">Invoice Handler Code (Presentation Tier)</a>
        </li>
        <li>
            <h3>Application tier (business logic, logic tier, or middle tier)</h3>
            <p>The logical tier is pulled out from the presentation tier and, as its own layer, it controls an application’s functionality by performing detailed processing.</p>
            <a href="https://github.com/michaelfordbrown/LittleDwarfsAgency/blob/master/LittleDwarfsAgency/InvoiceDAO.cs">Invoice Data Access Object (Application Tier)</a><br />
            <a href="https://github.com/michaelfordbrown/LittleDwarfsAgency/blob/master/LittleDwarfsAgency/InvoiceBUS.cs">Invoice Business Logic (Application Tier)</a>
        </li>
        <li>
            <h3>Data tier</h3>
            <p>The data tier includes the data persistence mechanisms (database servers, file shares, etc.) and the data access layer that encapsulates the persistence mechanisms and exposes the data. The data access layer should provide an API to the application tier that exposes methods of managing the stored data without exposing or creating dependencies on the data storage mechanisms. Avoiding dependencies on the storage mechanisms allows for updates or changes without the application tier clients being affected by or even aware of the change. As with the separation of any tier, there are costs for implementation and often costs to performance in exchange for improved scalability and maintainability.</p>
            <a href="https://github.com/michaelfordbrown/LittleDwarfsAgency/blob/master/LittleDwarfsAgency/dbConnection.cs">Database Connection Code (Data Tier)</a>
        </li>
    </ul>

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
        <asp:Label ID="Label7" runat="server" Text="Invoice" Width="240px"></asp:Label><br />
        <asp:TextBox ID="txtInvoiceSub" runat="server" Width="240px">"number"</asp:TextBox><br />

        <asp:Label ID="Label8" runat="server" Text="Account Reference" Width="240px"></asp:Label>&nbsp
        <asp:Label ID="Label9" runat="server" Text="Invoice Date" Width="240px"></asp:Label><br />
        <asp:TextBox ID="txtAccountRefSub" runat="server" Width="240px">"string"</asp:TextBox>&nbsp
        <asp:TextBox ID="txtInvoiceDateSub" runat="server" Width="240px">"date"</asp:TextBox><br />
        <br />
        <asp:Button ID="btnSubInvoice" runat="server" OnClick="btnSubInvoice_Click" Text="Submit Invoice" Width="260px" />

        <h4>Enter New Time Sheet Summary For Invoice</h4>

        <asp:Label ID="Label6" runat="server" Text="Invoice" Width="240px"></asp:Label><br />
        <asp:TextBox ID="txtWeekendingInvoiceSub" runat="server" Width="240px">"number"</asp:TextBox><br />
        <asp:Label ID="Label1" runat="server" Text="Weekending Date" Width="240px"></asp:Label>&nbsp
        <asp:Label ID="Label2" runat="server" Text="Time Sheet Number" Width="240px"></asp:Label><br />
        <asp:TextBox ID="txtWeekendingSub" runat="server" Width="240px">"yyyy/mm/dd"</asp:TextBox>&nbsp
        <asp:TextBox ID="txtTimesheetSub" runat="server" Width="240px">"number"</asp:TextBox><br />

        <asp:Label ID="Label3" runat="server" Text="Hours Worked" Width="240px"></asp:Label>&nbsp
        <asp:Label ID="Label4" runat="server" Text="Rate" Width="240px"></asp:Label><br />
        <asp:TextBox ID="txtHoursWorkedSub" runat="server" Width="240px">"££.pp"</asp:TextBox>&nbsp
        <asp:TextBox ID="txtRateSub" runat="server" Width="240px">"££.pp"</asp:TextBox><br />

        <asp:Label ID="Label5" runat="server" Text="Cost" Width="240px"></asp:Label><br />
        <asp:TextBox ID="txtCostSub" runat="server" Width="240px">"££.pp"</asp:TextBox>&nbsp
        <asp:Button ID="btnSubInvoiceList" runat="server" OnClick="btnSubInvoiceList_Click" Text="Submit Time Sheet Summary" Width="260px" />

        <h3>Delete Invoice:</h3>
        <h4>Enter Invoice To Be Deleted:</h4>
        <asp:Label ID="Label10" runat="server" Text="Invoice Number" Width="240px"></asp:Label><br />
        <asp:TextBox ID="txtInvoiceDelSub" runat="server" Width="240px">"number"</asp:TextBox>&nbsp
        <asp:Button ID="btnSubInvoiceDelete" runat="server" OnClick="btnSubInvoiceDelete_Click" Text="Delete Invoice" Width="260px" />

    </form>
</body>
</html>
