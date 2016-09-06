<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/SiteInnovaSchool.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="InnovaSchool.UserLayer.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row-fluid">
        <div class="span6" ontablet="span7" ondesktop="span6">
            <h1 class="bienvenido"><asp:Label ID="lblTitulo" runat="server" Text="lblTitulo"></asp:Label></h1>
            <br />
            <h2 class="titulo"><asp:Label ID="lblSubTitulo" runat="server" Text="lblSubTitulo"></asp:Label></h2>
        </div>
        <div class="span6 bg-index" ontablet="span7" ondesktop="span6">
        </div>
    </div>
</asp:Content>
