<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FinePolicy.aspx.cs" Inherits="LibraryPro.GUI.Setup.FinePolicy" %>
<%@ Register src="../../CustomControls/Message_Box.ascx" tagname="Message_Box" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
Manage Fine Policy
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
 <link href="../../css/Site.css" rel="stylesheet" type="text/css" />
	<link type="text/css" href= "../../css/smoothness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />	
	<script type="text/javascript" src="../../js/jquery-1.6.2.min.js"></script>
	<script type="text/javascript" src="../../js/jquery-ui-1.8.16.custom.min.js"></script> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div class="option">
        <a href="FinePolicy.aspx?act=add">Add New Fine Policy</a> | 
        <a href="FinePolicy.aspx?act=list">Available Fine Policy</a>        
    </div>
    <uc2:Message_Box ID="msgBox" runat="server" />
    <%
    string act = Request.QueryString["act"];
    if (act == "add" || act=="edit")
   { %>

<h2>Provide details to add/update Fine Policy</h2>
<table>
    <tr>
        <td>Policy Name</td>
        <td class="style1">
            <asp:TextBox ID="txtTypeName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTypeName"  Display="Dynamic" ErrorMessage="Please enter data."></asp:RequiredFieldValidator>
        </td>
    </tr>  
    <tr>
        <td>From Days</td>
        <td class="style1">
            <asp:TextBox ID="txtFromDays" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFromDays"  Display="Dynamic" ErrorMessage="Please enter data."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator  Runat="server" ID="valNumbersOnly" ControlToValidate="txtFromDays" Display="Dynamic" ErrorMessage="Please enter numbers only." ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)">
</asp:RegularExpressionValidator>
        </td>
    </tr> 
    <tr>
        <td>To Days</td>
        <td class="style1">
            <asp:TextBox ID="txtToDays" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtToDays"  Display="Dynamic" ErrorMessage="Please enter data."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator  Runat="server" ID="RegularExpressionValidator1" ControlToValidate="txtToDays" Display="Dynamic" ErrorMessage="Please enter numbers only." ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)">
            </asp:RegularExpressionValidator>
        </td>
    </tr> 
    <tr>
        <td>Fine Per Day</td>
        <td class="style1">
            <asp:TextBox ID="txtFine" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFine"  Display="Dynamic" ErrorMessage="Please enter data."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator  Runat="server" ID="RegularExpressionValidator2" ControlToValidate="txtFine" Display="Dynamic" ErrorMessage="Please enter numbers only." ValidationExpression="(^[0-9]*(?:\.[0-9]*)?$)">
            </asp:RegularExpressionValidator>
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
            <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" /></td>
    </tr>
</table>

<% }
    else if (act == "list")
    { %>
    <h2>Showing avilable Fine Policy</h2>
    Filter By: &nbsp;&nbsp;
    <asp:TextBox ID="txtFilterValue" runat="server"></asp:TextBox> &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnFilter" runat="server" Text="Filter" 
        onclick="btnFilter_Click" /><br />
    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label> 
    <br />
    <br />
        
    <asp:GridView ID="dgvSearchResult" runat="server" AllowPaging="true" AutoGenerateColumns="false"
        SkinID="gridviewSkin" 
        onpageindexchanging="dgvSearchResult_PageIndexChanging"  >
        <Columns>
            <asp:TemplateField HeaderText="Code">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("FINE_CODE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("FINE_DESC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="From Days">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("FROM_DAYS") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="To Days">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("TO_DAYS") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fine Per Day">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("FINE_PER_DAY") %>'></asp:Label>
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
                    <a href='FinePolicy.aspx?act=edit&code=<%# Eval("FINE_CODE") %>'>Edit</a>
                    <a href='FinePolicy.aspx?act=del&code=<%# Eval("FINE_CODE") %>' onclick ="return confirm('Are you sure you want to delete this Record?');">Delete</a>                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>


<% } %>
</asp:Content>
