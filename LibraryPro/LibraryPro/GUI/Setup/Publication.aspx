<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Publication.aspx.cs" Inherits="LibraryPro.GUI.Setup.Publication" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="../../CustomControls/Message_Box.ascx" tagname="Message_Box" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link href="../../css/Site.css" rel="stylesheet" type="text/css" />
	<link type="text/css" href= "../../css/smoothness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />	
	<script type="text/javascript" src="../../js/jquery-1.6.2.min.js"></script>
	<script type="text/javascript" src="../../js/jquery-ui-1.8.16.custom.min.js"></script> 
    
    <style type="text/css">
        .style1
        {
            width: 127px;
        }
        .style2
        {
            width: 361px;
        }
        .style3
        {
            width: 462px;
        }
    </style>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
 <div class="option">
<a href="Publication.aspx?act=add">Add New Publication</a>
        <a href="Publication.aspx?act=list">Avilable Publication</a>  
 </div>   
  <uc2:Message_Box ID="msgBox" runat="server" />
  <%
    string act = Request.QueryString["act"];
    if (act == "add" || act=="edit")
   { %>

   <h2>Provide details for book publication</h2>
    <table>
    <tr>
    <td>Publication name:</td>
    <td> 
    <asp:TextBox ID="txtPublicationName" runat="server"></asp:TextBox> 
    <asp:RequiredFieldValidator
                ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPublicationName"  Display="Dynamic" ErrorMessage="Please enter data."></asp:RequiredFieldValidator>
    </td>
    </tr>
    <tr>
    <td>Countrycode:</td>
    <td> <asp:TextBox ID="txtCountryCode" runat="server"></asp:TextBox>  </td>
    </tr>
    <tr>
    <td>Established date:</td>
    <td> 
        <asp:TextBox ID="txtEstDate" runat="server"></asp:TextBox>
        <asp:CalendarExtender ID="txtEstDate_CalendarExtender" runat="server" 
            Enabled="True" TargetControlID="txtEstDate" Format="MM/dd/yyyy">
        </asp:CalendarExtender>
                
    </td>
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
    <h2>Showing avilable publications</h2>
    Filter By: &nbsp;&nbsp;
    <asp:TextBox ID="txtFilterValue" runat="server"></asp:TextBox> &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnFilter" runat="server" Text="Filter" 
        onclick="btnFilter_Click" /><br />
    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label> 
    <br />
    <br />
        
    <asp:GridView ID="dgvPublicationResult"  runat="server" AllowPaging="true" AutoGenerateColumns="false"
        SkinID="gridviewSkin" 
        onpageindexchanging="dgvPublicationResult_PageIndexChanging" PageSize="5">
        <Columns>
        <asp:TemplateField HeaderText="code">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("PUBLICATION_CODE") %>'></asp:Label>
               </ItemTemplate>
            </asp:TemplateField>
        <asp:TemplateField HeaderText="Publication name">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("PUBLICATION_DESC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Countrycode">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("COUNTRY_CODE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Established date">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("ESTABLISHED_DATE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <a href='Publication.aspx?act=edit&code=<%# Eval("PUBLICATION_CODE") %>'>Edit</a>
                    <a href='Publication.aspx?act=del&code=<%# Eval("PUBLICATION_CODE") %>' onclick ="return confirm('Are you sure you want to delete this Record?');">Delete</a>                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <% } %>
</asp:Content>
