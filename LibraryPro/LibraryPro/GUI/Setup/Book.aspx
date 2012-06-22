<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="LibraryPro.GUI.Setup.Book" %>
<%@ Register src="../../CustomControls/Message_Box.ascx" tagname="Message_Box" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
Manage Books
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
<link href="../../css/Site.css" rel="stylesheet" type="text/css" />
	<link type="text/css" href= "../../css/smoothness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />	
	<script type="text/javascript" src="../../js/jquery-1.6.2.min.js"></script>
	<script type="text/javascript" src="../../js/jquery-ui-1.8.16.custom.min.js"></script> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div class="option">
        <a href="Book.aspx?act=add">Add New Book</a> | 
        <a href="Book.aspx?act=list">Existing Books</a>        
    </div>
    <uc2:Message_Box ID="msgBox" runat="server" />
    <%
    string act = Request.QueryString["act"];
    if (act == "add" || act=="edit")
   { %>

<h2>Provide details to add/update Book</h2>
<table>
    <tr>
        <td>Book Name</td>
        <td class="style1">
            <asp:TextBox ID="txtBookName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtBookName"  Display="Dynamic" ErrorMessage="Please enter data."></asp:RequiredFieldValidator>
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
    <td>Status</td>
    <td>
        <asp:DropDownList ID="ddlStatus" runat="server">
        </asp:DropDownList></td>
    </tr>
    <tr>
        <td class="style2">Inactive Reason</td>
        <td class="style3">
            <asp:TextBox ID="txtReason" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td></td>
        <td class="style1">
            <asp:Button ID="Button1" runat="server" Text="Save" onclick="btnSave_Click" UseSubmitBehavior="True" /></td>
    </tr>
    
</table>

<% }
    else if (act == "list")
    { %>
    <h2>Showing avilable books</h2>
    Filter By: &nbsp;&nbsp;
    <asp:TextBox ID="txtFilterValue" runat="server"></asp:TextBox> &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnFilter" runat="server" Text="Filter" 
        onclick="btnFilter_Click" /><br />
    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label> 
    <br />
    <br />
        
    <asp:GridView ID="dgvSearchResult" runat="server" AllowPaging="true" AutoGenerateColumns="false"
        SkinID="gridviewSkin" 
        onpageindexchanging="dgvSearchResult_PageIndexChanging" Width="1071px" >
        <Columns>
            <asp:TemplateField HeaderText="Code">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("BOOK_CODE")  %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Book Name">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("BOOK_DESC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Lot">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Bind("BOOK_LOT_NO") %>' NavigateUrl='<%# "BookLot.aspx?act=edit&code="+Eval("BOOK_LOT_NO")+"&view=true" %>'  />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Publication">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("PUBLICATION_DESC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CATEGORY_DESC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Author">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Bind("AUTHORNAME") %>' NavigateUrl='<%# "Author.aspx?act=edit&code="+Eval("AUTHOR_CODE")+"&view=true" %>'  />
                    <%--<asp:Label ID="Label1" runat="server" Text='<%# Bind("AUTHORNAME") %>'></asp:Label>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Source">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("SOURCE_DESC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# string.Compare((string)Eval("ACTIVE_FLAG"), "I", false) == 0 ? "InActive" :
"Active" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Reason">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("REASON_FOR_INACTIVE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <a href='Book.aspx?act=edit&code=<%# Eval("BOOK_CODE") %>'>Edit</a>
                    <a href='Book.aspx?act=del&code=<%# Eval("BOOK_CODE")  %>' onclick ="return confirm('Are you sure you want to delete this Record?');">Delete</a>                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>


<% }  %>
    
</asp:Content>
