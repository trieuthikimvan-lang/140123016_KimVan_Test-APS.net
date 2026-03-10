<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
<br />
<h3>Đăng nhập</h3>
<table class="table">
        <tr>
            <td>Username</td>
            <td><asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Nhập vào Username"></asp:TextBox></td>
        </tr>

         <tr>
     <td>Password</td>
     <td>  <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox></td>
     </tr>
         <tr>
     
     <td colspan="2" align ="center"><asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click1"/></td>
        </tr>


        </table>
    
  
<br  />
</asp:Content>