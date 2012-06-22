<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Issue.aspx.cs" Inherits="LibraryPro.GUI.Setup.Issue" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
  Issue
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../../css/Site.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="../../css/smoothness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui-1.8.16.custom.min.js"></script>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
       </asp:ScriptManager>
    <div class="issueForm">
        <h2>Enter details of book to be issued</h2>
        <table>
            <tr>
                <td>Issue Code:</td>
                <td>
                    <asp:TextBox ID="txtIssueCode" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator0" runat="server" ControlToValidate="txtIssueCode" Display="Dynamic" ErrorMessage="Please enter data."></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td>Member Card Code</td>
                <td class="style1">
                    <asp:DropDownList ID="ddlMemberCardCode" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlMemberCardCode" Display="Dynamic" ErrorMessage="Please select any one option."></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td>Book Serial No.</td>
                <td>
                    <asp:DropDownList ID="ddlBookSN" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlBookSN" Display="Dynamic" ErrorMessage="Please select any one option"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Issued By</td>
                <td>
                    <asp:TextBox ID="txtIB" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtIB" Display="Dynamic" ErrorMessage="Please enter Issuer's name."></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td>Issued Date</td>
                <td>
                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="txtDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtDate" Format="MM/dd/yyyy">
                    </asp:CalendarExtender>

                </td>
            </tr>
            <tr>
                <td>Due Date</td>
                <td>
                    <asp:TextBox ID="txtDueDate" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="txtDueDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtDueDate" Format="MM/dd/yyyy">
                    </asp:CalendarExtender>

                </td>
            </tr>
            <tr>
                <td>Returned</td>
                <td>
                    <asp:DropDownList ID="ddlReturned" runat="server">
                        <asp:ListItem>No</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlReturned" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Lost</td>
                <td>
                    <asp:DropDownList ID="ddlLost" runat="server">
                        <asp:ListItem>No</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlLost" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Returned Date</td>
                <td>
                    <asp:TextBox ID="txtReturnedDate" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="txtReturnedDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtReturnedDate" Format="MM/dd/yyyy"></asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td>Returned By</td>
                <td>
                    <asp:TextBox ID="txtReturnedBy" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Fine Amount</td>
                <td>
                    <asp:TextBox ID="txtFineAmount" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnIssueSubmit" runat="server" Text="Submit" onclick="btnIssueSubmit_Click"></asp:Button>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
