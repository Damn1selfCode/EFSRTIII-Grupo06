<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoDetalle.aspx.cs" Inherits="CapaPresentacion.ProductoDetalle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <asp:Label ID="lblTitulo" runat="server" CssClass="fs-4 fw-bold"></asp:Label>
    <div class="mb-3">
        <label class="form-label">Producto</label>
        <asp:TextBox ID="txtNombreProducto" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="mb-3">
        <label class="form-label">Categoria</label>
        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
        <div class="mb-3">
        <label class="form-label">Proveedor</label>
        <asp:DropDownList ID="ddlProveedor" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="mb-3">
        <label class="form-label">Precio</label>
        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" ></asp:TextBox>
    </div>
        <div class="mb-3">
        <label class="form-label">Stock</label>
        <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
    </div>
    <asp:Button ID="btnSubmit" runat="server" Text="Enviar" CssClass="btn btn-primary" onClick="btnProducto"/>
    <asp:LinkButton runat="server" PostBackUrl="~/Inicio.aspx" CssClass="btn btn-warning">Volver</asp:LinkButton>

</asp:Content>
