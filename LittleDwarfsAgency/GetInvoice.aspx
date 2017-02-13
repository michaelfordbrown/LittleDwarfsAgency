<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetInvoice.aspx.cs" Inherits="LittleDwarfsAgency.GetInvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:TextBox ID="txtInvoice" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click"  Text="Get Invoice" Width="252px" />
        
        <asp:Table ID="tabInvoice" runat="server" Height="206px" Width="473px">
            <asp:TableHeaderRow ID="tabInvoiceHeaderRow"
                runat="server">
                <asp:TableHeaderCell
                    Scope="Column"
                    Text="Id" />
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
        </asp:Table>
    </form>
</body>
</html>
