<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookEdition.aspx.cs" Inherits="LibraryPro.GUI.Setup.BookEdition" %>
<%@ Register src="../../CustomControls/Message_Box.ascx" tagname="Message_Box" tagprefix="uc2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../../css/Site.css" rel="stylesheet" type="text/css" />
	<link type="text/css" href= "../../css/smoothness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />	
	<script type="text/javascript" src="../../js/jquery-1.6.2.min.js"></script>
	<script type="text/javascript" src="../../js/jquery-ui-1.8.16.custom.min.js"></script> 
 
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div  class="option">
<a href ="BookEdition.aspx?act=add">Add new book edition</a>
<a href="BookEdition.aspx?act=list">Available editions </a>
</div>
<uc2:Message_Box ID="msgBox" runat="server" />

    <%
    string act = Request.QueryString["act"];
    if (act == "add" || act == "edit")
    {  %>

    <h2>Provide details for book edition</h2>
    <table>
        <tr>
        <td class="style1">Edition name:</td>
        
        <td>  
        <asp:TextBox ID="txtEditionName" runat="server"></asp:TextBox> 
        <asp:RequiredFieldValidator
                ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEditionName"  Display="Dynamic" ErrorMessage="Please enter data."></asp:RequiredFieldValidator>
        </td>
         </tr>
         <tr>
         <td class="style1">Remarks:</td>
         <td>  <asp:TextBox ID="txtRemarks" runat="server" style="margin-left: 0px"></asp:TextBox> </td>
         </tr>
         <tr>
         <td></td>
         <td> 
             <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" /> </td>
         </tr>

     </table>
     <% }
    else if (act == "list")
    { %>
    <h2>Showing avilable book edition</h2>
    Filter By: &nbsp;&nbsp;
     <asp:TextBox ID="txtFilterValue" runat="server"></asp:TextBox> &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnFilter" runat="server" Text="Filter" onclick="btnFilter_Click" /><br />
    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label> 
    <br />
    <br />
     <asp:GridView ID="dgvSearchResult" runat="server" AllowPaging="true" AutoGenerateColumns="false"
        SkinID="gridviewSkin" 
        onpageindexchanging="dgvSearchResult_PageIndexChanging" >
        <Columns>
      <asp:TemplateField HeaderText="Code">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("EDITION_CODE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("EDITION_DESC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Remarks">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("REMARKS") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <a href='BookEdition.aspx?act=edit&code=<%# Eval("EDITION_CODE") %>'>Edit</a>
                    <a href='BookEdition.aspx?act=del&code=<%# Eval("EDITION_CODE") %>' onclick ="return confirm('Are you sure you want to delete this Record?');">Delete</a>                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
  <% }  %>
</asp:Content>

