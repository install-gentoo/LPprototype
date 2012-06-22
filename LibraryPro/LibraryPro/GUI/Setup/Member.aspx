<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="LibraryPro.GUI.Setup.Member" %>
<%@ Register src="../../CustomControls/Message_Box.ascx" tagname="Message_Box" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
Manage Member
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../../css/Site.css" rel="stylesheet" type="text/css" />
	<link type="text/css" href= "../../css/smoothness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />	
	<script type="text/javascript" src="../../js/jquery-1.6.2.min.js"></script>
	<script type="text/javascript" src="../../js/jquery-ui-1.8.16.custom.min.js"></script> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="option">
        <a href="Member.aspx?act=add">Add New Member</a> | 
        <a href="Member.aspx?act=list">Existing Members</a>        
    </div>
    <uc2:Message_Box ID="msgBox" runat="server" />
    <%
    string act = Request.QueryString["act"];
    if (act == "add" || act=="edit")
   { %>

<h2>Provide details to add/update Member</h2>
<table>
    <tr>
        <td>Member Type</td>
        <td class="style1">
            <asp:DropDownList ID="ddlMemberType" runat="server">
            </asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator3" Display="Dynamic" runat="server" ControlToValidate="ddlMemberType"
ErrorMessage="Please select any one option."></asp:RequiredFieldValidator>
        </td>
    </tr> 
    <tr>
        <td>First Name</td>
        <td class="style1">
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFirstName"  Display="Dynamic" ErrorMessage="Please enter data."></asp:RequiredFieldValidator>
        </td>
    </tr> 
     <tr>
        <td>Middle Name</td>
        <td class="style1">
            <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
        </td>
    </tr> 
     <tr>
        <td>Last Name</td>
        <td class="style1">
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLastName"  Display="Dynamic" ErrorMessage="Please enter data."></asp:RequiredFieldValidator>
        </td>
    </tr> 
     <tr>
        <td>City Code</td>
        <td class="style1">
            <asp:TextBox ID="txtCityCode" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCityCode"  Display="Dynamic" ErrorMessage="Please enter data."></asp:RequiredFieldValidator>
        </td>
    </tr> 
     <%--<tr>
        <td>Registered Date</td>
        <td class="style1">
            <asp:TextBox ID="txtRegisteredDate" runat="server"></asp:TextBox>
        </td>
    </tr> --%>
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
     <%--<tr>
        <td>Inactivated Date</td>
        <td class="style1">
            <asp:TextBox ID="txtInactivatedDate" runat="server"></asp:TextBox>
        </td>
    </tr> --%>
    <tr>
        <td></td>
        <td class="style1">
            <asp:Button ID="Button1" runat="server" Text="Save" onclick="btnSave_Click" /></td>
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
        onpageindexchanging="dgvSearchResult_PageIndexChanging" Height="149px" 
        Width="1066px"   >
        <Columns>
            <asp:TemplateField HeaderText="Code">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("MEMBER_CODE")  %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("TYPE_DESC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="City">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CITY_CODE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Registered Date">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# ((DateTime)Eval("REGISTERED_DATE")).ToLongDateString() %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Registered By">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("REGISTERED_BY") %>'></asp:Label>
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
            <asp:TemplateField HeaderText="Inactivated Date">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# ((DateTime)Eval("INACTIVE_DATE")).ToLongDateString() %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Inactivated By">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("INACTIVATED_BY") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <a href='Member.aspx?act=edit&code=<%# Eval("MEMBER_CODE") %>'>Edit</a>
                    <a href='Member.aspx?act=del&code=<%# Eval("MEMBER_CODE")  %>' onclick ="return confirm('Are you sure you want to delete this Record?');">Delete</a>                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>


<% } %>
</asp:Content>
