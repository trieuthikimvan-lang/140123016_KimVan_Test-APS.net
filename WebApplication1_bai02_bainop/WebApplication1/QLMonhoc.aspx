﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QLMonhoc.aspx.cs" Inherits="WebApplication1.QLMonhoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <style>
.auto-style1{
    width:200px;
}
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <br />
        <table class="table">
    <tr>
        <td class="auto-style1">Mã Môn học:</td>
        <td><asp:TextBox ID="txtMaMH" runat="server" CssClass="form-control" required="required"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="auto-style1">Tên môn:</td>
        <td><asp:TextBox ID="txtTenmon" runat="server" CssClass="form-control"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="auto-style1">Số tiết:</td>
        <td>  <asp:TextBox ID="txtSotiet" runat="server" CssClass="form-control"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="auto-style1">Học phí:</td>
        <td><asp:TextBox ID="txtHocphi" runat="server" CssClass="form-control"></asp:TextBox></td>
    </tr>
    <tr>
       
        <td colspan="2"> <asp:Button ID="btnThem" runat="server" Text="Thêm" OnClick="btnThem_Click"  />
            &nbsp;<asp:Button ID="btnsua" runat="server" Text="Sửa" OnClick="btnsua_Click" />
        </td>
    </tr>
</table>
   
<input class="form-control" id="myInput" type="text" placeholder="Search..">
<br>
    
    <asp:Repeater runat="server" id="rpMH">
        <HeaderTemplate>
        <table class="table table-bordered table-striped">
    <thead>
      <tr>
        <th>Mã Môn học</th>
        <th>Tên môn học</th>
        <th>Số tiết</th>
          <th>Học phí</th>
      </tr>
    </thead>
            
    <tbody id="myTable">
        </HeaderTemplate>
        <ItemTemplate>
      <tr>
        <td><%#Eval("MaMH")%></td>
        <td><%#Eval("TenMH")%></td>
        <td><%#Eval("Sotiet")%></td>
          <td><%#Eval("Hocphi")%></td>
          <td><a href="QLMonhoc.aspx?mamhs=<%#Eval("MaMH")%>">Sửa</a> &nbsp; <a href="QLMonhoc.aspx?mamhx=<%#Eval("MaMH")%>" onclick="return confirm('Xoa?');">Xóa</a></td>
      </tr>
            </ItemTemplate>
      <FooterTemplate>
    </tbody>
  </table>
          </FooterTemplate>
 </asp:Repeater>
</asp:Content>