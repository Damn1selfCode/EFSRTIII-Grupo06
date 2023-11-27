<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ServicioDetalle.aspx.cs" Inherits="CapaPresentacion.ServicioDetalle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <asp:Label ID="lblTitulo" runat="server" CssClass="fs-4 fw-bold"></asp:Label>
    <div class="mb-3">
        <label class="form-label">Servicio</label>
        <asp:TextBox ID="txtNombreServicio" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
        <div class="mb-3">
        <label class="form-label">Descripcion</label>
        <asp:TextBox ID="txtDetalleServicio" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="mb-3">
        <label class="form-label">Tipo Servicio</label>
        <asp:DropDownList ID="ddlTipoServicio" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
      

    <div class="mb-3">
        <label class="form-label">Precio</label>
        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" ></asp:TextBox>
    </div>

    <asp:Button ID="btnSubmit" runat="server" Text="Enviar" CssClass="btn btn-primary" onClick="btnServicio"/>
    <asp:LinkButton runat="server" PostBackUrl="~/Inicio.aspx" CssClass="btn btn-warning">Volver</asp:LinkButton>

</asp:Content>
