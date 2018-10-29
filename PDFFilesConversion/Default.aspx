<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PDFFilesConversion._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="row">
            <div class="col-md-5">
                <h2>Source Files</h2>
                <asp:ListBox ID="lbSourceFiles" runat="server" Style="height: 250px;" class="form-control col-md-5"></asp:ListBox>

            </div>

            <div class="col-md-2">
                <h2></h2>
                <asp:Button ID="btnConvert" runat="server" Text="Convert" OnClick="btnConvert_Click" CssClass="btn btn-primary" Style="margin-top: 150px; margin-left: 0px" />
            </div>
            <div class="col-md-5">
                <h2>Destination Files</h2>
                <asp:ListBox ID="lbDestinationFiles" runat="server" Style="height: 250px;" class="form-control col-md-5"></asp:ListBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblStatus" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
