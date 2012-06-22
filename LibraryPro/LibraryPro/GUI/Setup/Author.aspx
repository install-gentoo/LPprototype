<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Author.aspx.cs" Inherits="LibraryPro.GUI.Setup.Author" %>

<%@ Register Src="../../CustomControls/Message_Box.ascx" TagName="Message_Box" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    Manage Author
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../../css/Site.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="../../css/smoothness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui-1.8.16.custom.min.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div class="option">
        <a href="Author.aspx?act=add">Add New Author</a> | 
        <a href="Author.aspx?act=list">Existing Authors</a>        
    </div>--%>
    <uc2:Message_Box ID="msgBox" runat="server" />
    <%
        string act = Request.QueryString["act"];
        string bookId = Request.QueryString["bookId"];
        if (act == "add" || act == "edit")
        { %>
    <%  if (act == "add")
        { %>
    <asp:HiddenField ID="hdnBookId" runat="server" />
    <h2>
        Book Author</h2>
    <asp:CheckBox ID="UseExistingAuthor" runat="server" Checked="false" AutoPostBack="true"
        OnCheckedChanged="UseExistingAuthor_CheckedChanged" />
    Use Existing Author
    <div id="divExistingAuthor" runat="server" style="display: none">
        <table>
            <tr>
                <td>
                    Authors:
                </td>
                <td>
                    <asp:DropDownList ID="ddlAuthor" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator InitialValue="0" ID="rfvAuthor" Display="Dynamic" runat="server"
                        ControlToValidate="ddlAuthor" ErrorMessage="Please select any one option."></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </div>
    <%} %>
    <div id="divNewAuthor" runat="server">
        <table>
            <%  
                string act = Request.QueryString["act"];
                if (act == "add")
                {
            %>
            <tr>
                <td colspan="2">
                    <h3>
                        New Author Details</h3>
                </td>
            </tr>
            <%}
    else
    { %>
            <%
        string view = Request.QueryString["view"];
        if (view == "true")
        {
            %>
            
            <tr>
                <td colspan="2">
                    <h2>
                        Author Details</h2>
                </td>
            </tr>
            <tr>
            <td colspan="2"><asp:CheckBox ID="editAuthor" runat="server" Text=" Edit This Author" 
                    oncheckedchanged="CheckBox2_CheckedChanged" Checked="false" AutoPostBack="true" /></td>
            </tr>
            <%}
        else
        {%>
            <tr>
                <td colspan="2">
                    <h2>
                        Edit Author Details</h2>
                </td>
            </tr>
            <%} %>
   <%} %>
            <tr>
                <td>
                    First Name
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                        Display="Dynamic" ErrorMessage="Please enter data."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Middle Name
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Last Name
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
                        Display="Dynamic" ErrorMessage="Please enter data."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Country Code
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtCountryCode" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCountryCode" runat="server" ControlToValidate="txtCountryCode"
                        Display="Dynamic" ErrorMessage="Please enter data."></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </div>
    <%
        string view = Request.QueryString["view"];
        if (act == "add" || (act == "edit" && view != "true"))
        {
        %>
          <asp:Button ID="Button1" runat="server" Text="Save" OnClick="btnSave_Click" />
        <%} %>
    <%
        if (act == "edit")
        {  %>
        <%
            
            if(view=="true")
            {
              %>
              <asp:Button ID="Button4" runat="server" Text="Ok" 
        onclick="Button4_Click" />
              <%} 
            else
            {
            %>
            <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="Button2_Click" />
            <%} %>
    <%} %>
    <% }
    else if (act == "list")
    { %>
    <h2>
        Showing avilable Authors</h2>
    Filter By: &nbsp;&nbsp;
    <asp:TextBox ID="txtFilterValue" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" /><br />
    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <asp:GridView ID="dgvSearchResult" runat="server" AllowPaging="true" AutoGenerateColumns="false"
        SkinID="gridviewSkin" OnPageIndexChanging="dgvSearchResult_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Code">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("AUTHOR_CODE")  %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Country">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("COUNTRY_CODE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <a href='Author.aspx?act=edit&code=<%# Eval("AUTHOR_CODE") %>'>Edit</a>
                    <%-- <a href='Author.aspx?act=del&code=<%# Eval("AUTHOR_CODE")  %>' onclick ="return confirm('Are you sure you want to delete this Record?');">Delete</a>  --%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <% } %>
</asp:Content>
