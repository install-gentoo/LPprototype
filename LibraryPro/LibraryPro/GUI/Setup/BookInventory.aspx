<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="BookInventory.aspx.cs" Inherits="LibraryPro.GUI.Setup.BookInventory" %>

<%@ Register Src="../../CustomControls/Message_Box.ascx" TagName="Message_Box" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../../css/Site.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="../../css/smoothness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui-1.8.16.custom.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div class="option">
        <a href="BookInventory.aspx?act=add">Add new inventory</a> 
        <a href="BookInventory.aspx?act=list">Available inventory </a>
    </div>--%>
    <uc2:Message_Box ID="msgBox" runat="server" />
    <%
    string act = Request.QueryString["act"];
    if (act == "add" || act == "edit")
    {  %>
    <h2>Provide details for inventory</h2>
    <table>
        <tr>
            <td>Book Name:</td>
            <td><asp:TextBox ID="txtBookName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBookName"  Display="Dynamic" ErrorMessage="Please enter data."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Publication:</td>
            <td>
                <asp:DropDownList ID="ddlPublication" runat="server" >
                </asp:DropDownList>
                <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ControlToValidate="ddlPublication"
ErrorMessage="Please select any one option."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Category:</td>
            <td>
                <asp:DropDownList ID="ddlCategory" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator3" Display="Dynamic" runat="server" ControlToValidate="ddlCategory"
ErrorMessage="Please select any one option."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Author:</td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox><asp:TextBox ID="txtMiddleName"
                    runat="server"></asp:TextBox><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
        <td></td>
        <td>  
            <asp:Button ID="btnSave" runat="server" Text="Save" /> 
        </td>
    </tr>
    </table>
    <% }
    else if (act == "list")
    { %>
    <h2>Showing avilable inventory</h2>
    <%--Filter By: &nbsp;&nbsp;
    <asp:TextBox ID="txtFilterValue" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" /><br />
    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
    <br />
    <br />--%>
    <asp:GridView ID="dgvSearchResult" runat="server" AllowPaging="true" AutoGenerateColumns="false"
        SkinID="gridviewSkin">
        <Columns>
            <asp:TemplateField HeaderText="Code">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("BOOK_SN") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Book Lot">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("BOOK_LOT_NO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Book Code">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("BOOK_CODE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Entry Date">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# ((DateTime)Eval("ENTRY_DATE")).ToLongDateString() %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Entered By">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("ENTERED_BY") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <a href='BookInventory.aspx?act=edit&code=<%# Eval("EDITION_CODE") %>'>Edit</a> 
                    <a href='BookInventory.aspx?act=del&code=<%# Eval("EDITION_CODE") %>' onclick ="return confirm('Are you sure you want to delete this Record?');">Delete</a>
                </ItemTemplate>
            </asp:TemplateField>--%>
        </Columns>
    </asp:GridView>
    <% } %>
</asp:Content>
