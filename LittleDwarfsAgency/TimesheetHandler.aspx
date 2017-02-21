<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimesheetHandler.aspx.cs" Inherits="LittleDwarfsAgency.TimesheetHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Timesheet Handler</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Little Dwarf Care Agency (Entity Framework)</h1>
            <p>Entity Framework is an object-relational mapping framework for ADO.NET.</p>
            <p>It enables development work with data in the form of domain-specific objects and properties without need to concern with the underlying database structure the storage location of the data.</p>
        </div>

        <div>
            <h2>Timesheet Handler</h2>

            <h3>Search for Timesheet:</h3>
            <asp:TextBox ID="txtTimesheet" runat="server">463609</asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Get Timesheet" Width="252px" />
            <h4>Timesheet:</h4>
            <asp:Table ID="tabTimesheet" runat="server" Height="64px" Width="473px" BorderStyle="Solid" GridLines="Both">
                <asp:TableHeaderRow ID="tabTimesheetHeaderRow"
                    runat="server">
                    <asp:TableHeaderCell
                        Scope="Column"
                        Text="Timesheet" />
                    <asp:TableHeaderCell
                        Scope="Column"
                        Text="Agency" />
                    <asp:TableHeaderCell
                        Scope="Column"
                        Text="Care Worker" />
                </asp:TableHeaderRow>
                <asp:TableFooterRow runat="server">
                    <asp:TableCell ID="footerTabTimesheet" ColumnSpan="3">
                    </asp:TableCell>
                </asp:TableFooterRow>
            </asp:Table>
            <h4>Work Period:</h4>
            <asp:Table ID="tabWorkPeriod" runat="server" Height="206px" Width="473px" BorderStyle="Solid" GridLines="Both">
                <asp:TableHeaderRow ID="tabWorkPeriodHeaderRow"
                    runat="server">
                    <asp:TableHeaderCell
                        Scope="Column"
                        Text="Period Date" />
                    <asp:TableHeaderCell
                        Scope="Column"
                        Text="Allocated Hours" />
                    <asp:TableHeaderCell
                        Scope="Column"
                        Text="Time In" />
                    <asp:TableHeaderCell
                        Scope="Column"
                        Text="Time Out" />
                    <asp:TableHeaderCell
                        Scope="Column"
                        Text="Actual Service" />
                </asp:TableHeaderRow>
            </asp:Table>

            <h3>Append New Timesheet:</h3>

            <h4>Enter New Timesheet Data:</h4>

            <asp:Label ID="Label3" runat="server" Text="Timesheet" Width="240px"></asp:Label><br />
            <asp:TextBox ID="TextBox1" runat="server" Width="240px"></asp:TextBox><br />

            <asp:Label ID="Label4" runat="server" Text="Agency" Width="240px"></asp:Label>&nbsp
        <asp:Label ID="Label5" runat="server" Text="Care Worker" Width="240px"></asp:Label><br />
            <asp:TextBox ID="TextBox2" runat="server" Width="240px"></asp:TextBox>&nbsp
        <asp:TextBox ID="TextBox3" runat="server" Width="240px"></asp:TextBox><br />

            <br />
            <asp:Button ID="btnSubTimesheet" runat="server" OnClick="btnSubTimesheet_Click" Text="Submit Timesheet" Width="260px" />

            <h4>Enter New Work Period Data:</h4>

            <asp:Label ID="Label7" runat="server" Text="Timesheet" Width="240px"></asp:Label><br />
            <asp:TextBox ID="txtTimesheetSub" runat="server" Width="240px"></asp:TextBox><br />

            <asp:Label ID="Label8" runat="server" Text="Period Date" Width="240px"></asp:Label>&nbsp
        <asp:Label ID="Label9" runat="server" Text="Allocated Hours" Width="240px"></asp:Label><br />
            <asp:TextBox ID="txtPeriodDateSub" runat="server" Width="240px"></asp:TextBox>&nbsp
        <asp:TextBox ID="txtAllocHoursSub" runat="server" Width="240px" OnTextChanged="txtAllocHoursSub_TextChanged"></asp:TextBox><br />

            <asp:Label ID="Label1" runat="server" Text="Time In" Width="240px"></asp:Label>&nbsp
        <asp:Label ID="Label2" runat="server" Text="Time Out" Width="240px" style="height: 27px"></asp:Label><br />
            <asp:TextBox ID="txtTimeIn" runat="server" Width="240px"></asp:TextBox>&nbsp
        <asp:TextBox ID="txtTimeExit" runat="server" Width="240px"></asp:TextBox><br />

                    <asp:Label ID="Label6" runat="server" Text="Actual Service" Width="240px" style="height: 27px"></asp:Label><br />
                    <asp:TextBox ID="txtActualService" runat="server" Width="240px"></asp:TextBox>&nbsp

            <asp:Button ID="Button1" runat="server" OnClick="btnSubWorkPeriod_Click" Text="Submit Work Period" Width="260px" />
            <h3>Delete Timesheet:</h3>
            <h4>Enter Timesheet To Be Deleted:</h4>
                    <asp:Label ID="Label10" runat="server" Text="Timesheet Number" Width="240px"></asp:Label><br />
        <asp:TextBox ID="txtTimesheetDelSub" runat="server" Width="240px"></asp:TextBox>&nbsp
        <asp:Button ID="btnSubTimesheetDelete" runat="server" OnClick="btnSubTimesheetDelete_Click" Text="Delete Timesheet" Width="260px" />
        </div>
    </form>
</body>
</html>
