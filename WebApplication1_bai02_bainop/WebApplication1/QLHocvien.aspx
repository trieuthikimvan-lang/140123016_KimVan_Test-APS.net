<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QLHocvien.aspx.cs" Inherits="WebApplication1.QLHocvien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script>
$(document).ready(function(){
  $("#myInput").on("keyup", function() {
    var value = $(this).val().toLowerCase();
    $("#myTable tr").filter(function() {
      $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
  });
});
      </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <table class="table">
       <tr>
           <td class="auto-style1">Mã HV:</td>
           <td><asp:TextBox ID="txtmahv" runat="server" CssClass="form-control"></asp:TextBox></td>
       </tr>
       <tr>
            <td class="auto-style1">Họ HV:</td>
            <td><asp:TextBox ID="txtHohv" runat="server"  CssClass="form-control"></asp:TextBox></td>
       </tr>
       <tr>
           <td class="auto-style1">Tên HV:</td>
           <td><asp:TextBox ID="txtTenhv" runat="server" CssClass="form-control"></asp:TextBox></td>
       </tr>
        <tr>
           <td class="auto-style1">Địa chỉ:</td>
           <td><asp:TextBox ID="txtDiachi" runat="server" CssClass="form-control"></asp:TextBox></td>
</tr>
       <tr>
  
           <td colspan="2"><asp:Button ID="btnThem" runat="server" Text="Thêm học viên"/></td>
       </tr>
   </table>
    <input class="form-control" id="myInput" type="text" placeholder="Tìm kiếm..">
    
<br>
<asp:Repeater runat="server" id="rpHV">
<HeaderTemplate>
<table class="table table-bordered table-striped">
<thead>
    <tr>
        <th>Mã số học viên</th>
        <th>Họ học viên</th>
        <th>Tên số học viên</th>
        <th>Địa chỉ học viên</th>
    </tr>
</thead>

    <tbody id="myTable">
        </HeaderTemplate>
    <ItemTemplate>
        <tr>
        <td><%#Eval("MaHV")%></td>
        <td><%#Eval("HoHV")%></td>
        <td><%#Eval("TenHV")%></td>
        <td><%#Eval("Diachi")%></td>
        <td><a href="QLHocvien.aspx?mahvs=<%#Eval("MaHV")%>">Sửa</a> &nbsp; <a href="QLHocvien.aspx?mahvx=<%#Eval("MaHV")%>">Xóa</a></td>
</tr>
    </ItemTemplate>
    <FooterTemplate>
        
</tbody>
</table>
</FooterTemplate>
</asp:Repeater>

</asp:Content>

  
