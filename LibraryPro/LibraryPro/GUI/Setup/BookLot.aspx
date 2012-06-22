<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookLot.aspx.cs" Inherits="LibraryPro.GUI.Setup.BookLot" %>
<%@ Register src="../../CustomControls/Message_Box.ascx" tagname="Message_Box" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
Manage Book Lot
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
<link href="../../css/Site.css" rel="stylesheet" type="text/css" />
	<link type="text/css" href= "../../css/smoothness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />	
	<script type="text/javascript" src="../../js/jquery-1.6.2.min.js"></script>
	<script type="text/javascript" src="../../js/jquery-ui-1.8.16.custom.min.js"></script> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<%--<div class="option">
        <a href="BookLot.aspx?act=add">Add New Book Lot</a> | 
        <a href="BookLot.aspx?act=list">Existing Book Lots</a>        
    </div>--%>
    <uc2:Message_Box ID="msgBox" runat="server" />
    <%
        string view = Request.QueryString["view"];
    string act = Request.QueryString["act"];
    string bookId = Request.QueryString["bookId"];
    string authorId = Request.QueryString["AuthorId"];
    if (act == "add" || act=="edit")
   { %>
   <input type="hidden" id="BookId" name="BookId" value="<%= bookId %>" />
   <input type="hidden" id="AuthorId" name="AuthorId" value="<%= authorId %>" />
   <%
       if (act == "add")
       { %>
<h2>Provide details to add Book Lot</h2>
<%}
       else if (act == "edit")
       { %>
       <%
        
        if (view == "true")
        {
            %>
            <h2>
                Book Lot Details</h2>
                <asp:CheckBox ID="editBookLot" runat="server" Text=" Edit This Book Lot" 
        Checked="false" AutoPostBack="true" 
        oncheckedchanged="editBookLot_CheckedChanged"  />

            <%}
        else
        {%>
            <h2>Edit Book Lot Details</h2>
            <%} %>
       <%} %>
<table>
    <tr>
            <td>Book:</td>
            <td>
                <asp:DropDownList ID="ddlBookCode" runat="server" >
                </asp:DropDownList>
                <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ControlToValidate="ddlBookCode"
ErrorMessage="Please select any one option."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Edition:</td>
            <td>
                <asp:DropDownList ID="ddlEdition" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator3" Display="Dynamic" runat="server" ControlToValidate="ddlEdition"
ErrorMessage="Please select any one option."></asp:RequiredFieldValidator>
            </td>
        </tr>
    <tr>
        <td class="style2">Year Of Publication</td>
        <td class="style3">
            <asp:TextBox ID="txtYearOfPublication" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtYearOfPublication"  Display="Dynamic" ErrorMessage="Please enter data."></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator  Runat="server" ID="valNumbersOnly" ControlToValidate="txtYearOfPublication" Display="Dynamic" ErrorMessage="Please enter numbers only." ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="style2">ISBN</td>
        <td class="style3">
            <asp:TextBox ID="txtIsbn" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtIsbn"  Display="Dynamic" ErrorMessage="Please enter data."></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style2">Price</td>
        <td class="style3">
            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPrice"  Display="Dynamic" ErrorMessage="Please enter data."></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator  Runat="server" ID="RegularExpressionValidator2" ControlToValidate="txtPrice" Display="Dynamic" ErrorMessage="Please enter numbers only." ValidationExpression="(^[0-9]*(?:\.[0-9]*)?$)">
            </asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="style2">Number Of Pages</td>
        <td class="style3">
            <asp:TextBox ID="txtPages" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPages"  Display="Dynamic" ErrorMessage="Please enter data."></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator  Runat="server" ID="RegularExpressionValidator1" ControlToValidate="txtPages" Display="Dynamic" ErrorMessage="Please enter numbers only." ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
            <td>Source:</td>
            <td>
                <asp:DropDownList ID="ddlSource" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ControlToValidate="ddlSource"
ErrorMessage="Please select any one option."></asp:RequiredFieldValidator>
            </td>
        </tr>
    <tr>
        <td class="style2">Number Of Books</td>
        <td class="style3">
            <asp:TextBox ID="txtNoOfBooks" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtNoOfBooks"  Display="Dynamic" ErrorMessage="Please enter data."></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator  Runat="server" ID="RegularExpressionValidator3" ControlToValidate="txtNoOfBooks" Display="Dynamic" ErrorMessage="Please enter numbers only." ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td></td>
        <td class="style1">
     <%
        if (act == "add" || (act == "edit" && view != "true"))
        {
        %>
          
            <asp:Button ID="Button1" runat="server" Text="Save" onclick="btnSave_Click" />
        <%} %>
    <%
        if (act == "edit")
        {  %>
        <%
            
            if(view=="true")
            {
              %>
              <asp:Button ID="Button4" runat="server" Text="Ok" onclick="Button4_Click"  />
              <%} 
            else
            {
            %>
            <asp:Button ID="Button3" runat="server" Text="Cancel" onclick="Button3_Click" />
            <%} %>
    <%} %>
    
    </td>
    </tr>
</table>

<% }
    else if (act == "list")
    { %>
    <h2>Showing available book lots</h2>
   <%-- Filter By: &nbsp;&nbsp;
    <asp:TextBox ID="txtFilterValue" runat="server"></asp:TextBox> &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnFilter" runat="server" Text="Filter" 
        onclick="btnFilter_Click" /><br />
    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label> 
    <br />
    <br />--%>
        
    <asp:GridView ID="dgvSearchResult" runat="server" AllowPaging="true" AutoGenerateColumns="false"
        SkinID="gridviewSkin" 
        onpageindexchanging="dgvSearchResult_PageIndexChanging" Width="1028px"  >
        <Columns>
            <asp:TemplateField HeaderText="Code">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("BOOK_LOT_NO")  %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Book">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("BOOK_DESC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edition">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("EDITION_DESC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Publication Year">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("YEAR_OF_PUBLICATION") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ISBN">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("ISBN") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("PRICE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pages">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("NO_OF_PAGES") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Source">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("SOURCE_DESC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Received On">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# ((DateTime)Eval("RECEIVED_ON")).ToLongDateString() %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="No. Of Book">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("NO_OF_BOOKS") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <a href='BookLot.aspx?act=edit&code=<%# Eval("BOOK_LOT_NO") %>'>Edit</a>
                    <%--<a href='BookLot.aspx?act=del&code=<%# Eval("BOOK_LOT_NO")  %>' onclick ="return confirm('Are you sure you want to delete this Record?');">Delete</a>--%>                
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>


<% } %>
</asp:Content>
