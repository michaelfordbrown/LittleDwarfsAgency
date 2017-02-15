<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMLHandler.aspx.cs" Inherits="LittleDwarfsAgency.XMLHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <h1>Little Dwarfs Agency: XML File Handler (ASP.NET Controls Example)</h1>
        <h2>Load XML Files</h2>
        <p>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Load All Default Database" OnClick="LoadAllDefaultData_Click" Width="262px" />
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Load Default Invoice Data" Width="245px" />
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="Button1_Click" Text="Load Default Timesheet Data" Width="289px" />
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Load Status"></asp:Label>
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" OnClick="DeleteAllData_Click" Text="Delete All Data"  Width="261px" />
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button5" runat="server" OnClick="Button1_Click" Text="Delete All Invoice Data" Width="245px" />
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button6" runat="server" OnClick="Button1_Click" Text="Delete All Timesheet Data" Width="289px" />
        </p>
        <p>
            <asp:Label ID="DeleteStatus" runat="server" Text="Delete Status"></asp:Label>
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button7" runat="server" OnClick="CheckSizeofAllTables_Click" Text="Check Size of All Tables"  Width="261px" />
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button8" runat="server" OnClick="CheckSizeofInvoiceData_Click" Text="Check Size of Invoice Data" Width="245px" />
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button9" runat="server" OnClick="CheckSizeofTimesheetData_Click" Text="Check Size of Timesheet Data" Width="289px" />
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Size Status"></asp:Label>
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button10" runat="server" OnClick="Button1_Click" Text="Display All Table and Views"  Width="261px" />
        </p>

        <h2>Tables</h2>
        <h3>Invoice Table:</h3>
        <asp:Button ID="Button11" runat="server" Text="Load Invoice Table" OnClick="LoadInvoiceTable_Click" />
        <p>&nbsp;</p>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <h3>Daily Charges View:</h3>
        <asp:Button ID="Button12" runat="server" Text="Load Daily Charges View" OnClick="LoadDailyChargesView_Click" />
        <p>&nbsp;</p>
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>

    </form>
</body>
</html>
