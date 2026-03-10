<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="dangky.aspx.cs" Inherits="WebApplication1.dangky" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table class="table">
     <tr>
         <td class="auto-stylel">Username:</td>
         <td>
             <asp:TextBox ID="txtuser" runat="server" CssClass="form-cobtrol"></asp:TextBox>
         </td>
     </tr>

     <tr>
         <td class="auto-stylel">Password:</td>
         <td>
             <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
         </td>
     </tr>

     <tr>
        <td class="auto-stylel">Fullname:</td>
         <td>
             <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox>
         </td>
     </tr>

     <tr>
         <td class="auto-style1">Avatar:</td>
         <td>
             <asp:FileUpload ID="FileUpload1" runat="server"/>
         </td>
     </tr>

     <tr>
             <td colspan="2"> <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/>
         </td>
     </tr>
 </table>
</asp:Content>
