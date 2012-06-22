<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="LibraryPro.GUI.Setup.Category" %>
<%@ Register src="../../CustomControls/Message_Box.ascx" tagname="Message_Box" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../../css/Site.css" rel="stylesheet" type="text/css" />
	<link type="text/css" href= "../../css/smoothness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />	
	<script type="text/javascript" src="../../js/jquery-1.6.2.min.js"></script>
	<script type="text/javascript" src="../../js/jquery-ui-1.8.16.custom.min.js"></script> 
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="option">
        <a href="Category.aspx?act=add">Add New Category</a> | 
        <a href="Category.aspx?act=list">Available Category</a>        
    </div>
    <uc2:Message_Box ID="msgBox" runat="server" />
    <%
    string act = Request.QueryString["act"];
    if (act == "add" || act=="edit")
   { %>

<h2>Provide details to add/update category</h2>
<table>
    <tr>
        <td>Category Name</td>
        <td class="style1">
            <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCategoryName"  Display="Dynamic" ErrorMessage="Please enter data."></asp:RequiredFieldValidator>
        </td>
    </tr>  
    <tr>
        <td class="style2">Remarks</td>
        <td class="style3">
            <asp:TextBox ID="txtRemarks" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td></td>
        <td class="style1">
            <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" /></td>
    </tr>
</table>

<% }
    else if (act == "list")
    { %>
    <h2>Showing avilable catagories</h2>
    Filter By: &nbsp;&nbsp;
    <asp:TextBox ID="txtFilterValue" runat="server"></asp:TextBox> &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnFilter" runat="server" Text="Filter" 
        onclick="btnFilter_Click" /><br />
    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label> 
    <br />
    <br />
        
    <asp:GridView ID="dgvSearchResult" runat="server" AllowPaging="true" AutoGenerateColumns="false"
        SkinID="gridviewSkin" 
        onselectedindexchanged="dgvSearchResult_SelectedIndexChanged1" 
        onpageindexchanging="dgvSearchResult_PageIndexChanging"  >
        <Columns>
            <asp:TemplateField HeaderText="Code">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CATEGORY_CODE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CATEGORY_DESC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Remarks">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("REMARKS") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <a href='Category.aspx?act=edit&code=<%# Eval("CATEGORY_CODE") %>'>Edit</a>
                    <a href='Category.aspx?act=del&code=<%# Eval("CATEGORY_CODE") %>' onclick ="return confirm('Are you sure you want to delete this Record?');">Delete</a>                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>


<% } %>
</asp:Content>
