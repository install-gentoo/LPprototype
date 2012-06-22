<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="LibraryPro._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
        <link href="css/Site.css" rel="stylesheet" type="text/css" />
        <link type="text/css" href="css/smoothness/jquery-ui-1.8.16.custom.css" rel="stylesheet" />
        <script type="text/javascript" src="js/jquery-1.6.2.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui-1.8.16.custom.min.js"></script>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <h2>
            Welcome to Library pro!
        </h2>
        <p>
            To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
            <a href="#" id="dialog_link" class="ui-state-default ui-corner-all">Open Dialog</a>
        </p>
		<div id="dialog" title="Dialog Title">
			<p>Check check</p>
		</div>
			
        <script type="text/javascript">
            $(function () {
                //  Dialog
                $('#dialog').dialogyt
                    autoOpen: false,
                    width: 600,
                    buttons: {
                        "Ok": function () {
                            $(this).dialog("close");
                        },
                        "Cancel": function () {
                            $(this).dialog("close");
                        }
                    }
                });
                // Dialog Link
                $('#dialog_link').click(function () {
                    $('#dialog').dialog('open');
                    return false;
                });
            });
		</script>    
    <p>
        &nbsp;</p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>
</asp:Content>
