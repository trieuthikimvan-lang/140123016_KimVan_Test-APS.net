<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QLDiem.aspx.cs" Inherits="WebApplication1.Admin.QLDiem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h2>Quản lý điểm học viên</h2>

<table>

<tr>
<td>Mã HV</td>
<td>
<asp:DropDownList ID="ddlHV" runat="server"></asp:DropDownList>
</td>
</tr>

<tr>
<td>Mã MH</td>
<td>
<asp:DropDownList ID="ddlMH" runat="server"></asp:DropDownList>
</td>
</tr>

<tr>
<td>Điểm</td>
<td>
<asp:TextBox ID="txtdiem" runat="server"></asp:TextBox>
</td>
</tr>

<tr>
<td>Username</td>
<td>
<asp:TextBox ID="txtusername" runat="server" ReadOnly="true"></asp:TextBox>
</td>
</tr>

<tr>
<td></td>
<td>
<asp:Button ID="btnThem" runat="server" Text="Thêm" OnClick="btnThem_Click"/>
<asp:Button ID="btnSua" runat="server" Text="Sửa" OnClick="btnSua_Click"/>
</td>
</tr>

</table>

<br />

Tìm kiếm
<asp:TextBox ID="txttim" runat="server"></asp:TextBox>
<asp:Button ID="btntim" runat="server" Text="Tìm" OnClick="btntim_Click"/>

<br /><br />

<h3>Danh sách điểm</h3>

<asp:GridView ID="gvDiem" runat="server"
AutoGenerateColumns="False"
OnSelectedIndexChanged="gvDiem_SelectedIndexChanged"
OnRowDeleting="gvDiem_RowDeleting"
DataKeyNames="MaHV,MaMH,Username">

<Columns>

<asp:CommandField ShowSelectButton="True"/>
<asp:CommandField ShowDeleteButton="True"/>

<asp:BoundField DataField="MaHV" HeaderText="MaHV"/>
<asp:BoundField DataField="MaMH" HeaderText="MaMH"/>
<asp:BoundField DataField="Diem" HeaderText="Diem"/>
<asp:BoundField DataField="Username" HeaderText="Username"/>

</Columns>

</asp:GridView>

</asp:Content>