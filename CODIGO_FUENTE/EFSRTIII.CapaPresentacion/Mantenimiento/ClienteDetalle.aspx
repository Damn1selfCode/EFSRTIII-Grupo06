<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClienteDetalle.aspx.cs" Inherits="CapaPresentacion.ClienteDetalle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <asp:Label ID="lblTitulo" runat="server" CssClass="fs-4 fw-bold"></asp:Label>
    <div class="mb-3">
        <label class="form-label">Cliente</label>
        <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="mb-3">
        <label class="form-label">RUC</label>
        <asp:TextBox ID="txtRUC" runat="server" CssClass="form-control" ></asp:TextBox>
    </div>

    <div class="mb-3">
        <label class="form-label">Telefono</label>
        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
    </div>
      <div class="mb-3">
       <label class="form-label">Direccion</label>
       <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" ></asp:TextBox>
   </div>
          <div class="mb-3">
       <label class="form-label">Correo Electronico</label>
       <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
   </div>
    <asp:Button ID="btnSubmit" runat="server" Text="Enviar" CssClass="btn btn-primary" onClick="btnCliente"/>
    <asp:LinkButton runat="server" PostBackUrl="~/Inicio.aspx" CssClass="btn btn-warning">Volver</asp:LinkButton>

</asp:Content>
