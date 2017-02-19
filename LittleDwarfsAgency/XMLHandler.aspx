<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMLHandler.aspx.cs" Inherits="LittleDwarfsAgency.XMLHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <!--  ASP.NET controls are objects on web pages that run when the page is requested and that render markup to a browser. 
              Microsoft's web server controls resemble familiar HTML elements, such as buttons and text boxes. 
              Other controls encompass complex behavior, such as a calendar controls, and controls that manage data connections. -->
        <h1>Little Dwarfs Agency: XML File Handler (ASP.NET Controls Example)</h1>
        <a href="https://github.com/michaelfordbrown/LittleDwarfsAgency/blob/master/LittleDwarfsAgency/XMLHandler.aspx">XML Handler Page File</a><br />
        <a href="https://github.com/michaelfordbrown/LittleDwarfsAgency/blob/master/LittleDwarfsAgency/XMLHandler.aspx.cs">XML Handler Code Behind File</a>
        <p>This page houses a series of ASP.NET controls that allow the user to manage the Little Dwarf Agency database:</p>
        <h2>Load Default Table Data</h2>
        <p>These controls use XML data files to reload the original test data that has been transfered from the spreadsheet implementation:</p>
        <!-- The Button control can create a push button on the page that lets users to post a page to the server. 
               It triggers an event in server code that can be handled to respond to the postback (page is submitted to itself). 
               Also raise an event in client script that can be handled before the page is posted. -->
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
            <asp:Button ID="Button1" runat="server" Text="Load All Default Tables" OnClick="LoadAllDefaultData_Click" Width="300px" />
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Load Default Invoice Table" Width="300px" />
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="Button1_Click" Text="Load Default Timesheet Table" Width="300px" />
        </div>
        <br />
        <!-- Label controls are used to display text in a set location on the page. 
               These controls can be customize the displayed text through the Text property. -->
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
            <asp:Label ID="Label1" runat="server" Text="Load Status" Width="300px"></asp:Label>
        </div>
        <br />
        <h2>Delete Table Data</h2>
        <p>These controls truncate table data in the Little Dwarf Agency:</p>
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
            <asp:Button ID="Button4" runat="server" OnClick="DeleteAllData_Click" Text="Delete All Data" Width="300px" />
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button5" runat="server" OnClick="DeleteAllInvoiceData_Click" Text="Delete All Invoice Data" Width="300px" />
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button6" runat="server" OnClick="DeleteAllTimesheetData_Click" Text="Delete All Timesheet Data" Width="300px" />
        </div>
        <br />
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
            <asp:Label ID="DeleteStatus" runat="server" Text="Delete Status"></asp:Label>
        </div>
        <br />
        <h2>Check Size Table Data</h2>
        <p>These controls measure the size of the table data in the Little Dwarf Agency:</p>
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
            <asp:Button ID="Button7" runat="server" OnClick="CheckSizeofAllTables_Click" Text="Check Size of All Tables" Width="300px" />
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button8" runat="server" OnClick="CheckSizeofInvoiceData_Click" Text="Check Size of Invoice Data" Width="300px" />
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button9" runat="server" OnClick="CheckSizeofTimesheetData_Click" Text="Check Size of Timesheet Data" Width="300px" />
        </div>
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
            <asp:Label ID="Label2" runat="server" Text="Size Status"></asp:Label>
        </div>
        <br />
        <h2>Display Tables</h2>
        <p>These controls display content data from Tables:</p>
        <h3>Invoice Tables:</h3>
        <asp:Button ID="Button11" runat="server" Text="Load Invoice Tables" OnClick="LoadInvoiceTables_Click" Width="300px" />
        <br />
        <h4>Invoice Table</h4>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <h4>Timesheet Summary Table</h4>
        <asp:GridView ID="GridView3" runat="server">
        </asp:GridView>
        <br />
        <h3>Timesheet Tables:</h3>
        <asp:Button ID="Button13" runat="server" Text="Load Timesheet Tables" OnClick="LoadTimesheetTables_Click" Width="300px" />
        <br />
        <h4>Timesheet Table</h4>
        <asp:GridView ID="GridView4" runat="server">
        </asp:GridView>
        <br />
        <h4>Workload Table</h4>
        <asp:GridView ID="GridView7" runat="server">
        </asp:GridView>
        <br />

        <h2>Load All Views:</h2>
        <asp:Button ID="Button12" runat="server" Text="Load All Views" OnClick="LoadAllViews_Click" Width="300px" />
        <br />
        <h3>Daily Charges view</h3>
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
        <br />
        <h3>Daily Rates View:</h3>
        <asp:GridView ID="GridView5" runat="server">
        </asp:GridView>
        <br />
        <h3>Period Rates View:</h3>
        <asp:GridView ID="GridView6" runat="server">
        </asp:GridView>
        <br />
    </form>
</body>
</html>
