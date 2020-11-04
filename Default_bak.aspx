<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default_bak.aspx.cs" Inherits="ShaneSampleApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">

    <div class="jumbotron">
        <h1>Shane-Exameron</h1>
        <p class="lead">Bootstrap is a free UI framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="#" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

      <h3>DataGrid Example</h3>
 
      <b>Product List</b>
 
      <asp:DataGrid id="PatientsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           AutoGenerateColumns="true"
           runat="server">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle> 
 
      </asp:DataGrid>
    
    
</asp:Content>