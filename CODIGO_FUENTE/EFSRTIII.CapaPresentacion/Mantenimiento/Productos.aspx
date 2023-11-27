<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="CapaPresentacion.Mantenimiento.Productos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-12">
            <h2>Mantenimiento Producto</h2>

            <div class="row">
                <div class="col-12">
                    <asp:Button runat="server" OnClick="Nuevo_Producto" Text="Nuevo Producto" CssClass="btn btn-success" Style="float: right;" />
                </div>
            </div>
            <asp:GridView ID="GVProducto" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="NombreProducto" HeaderText="Producto" />
                    <asp:BoundField DataField="Proveedor.NombreProveedor" HeaderText="Proveedor" />
                    <asp:BoundField DataField="Categoria.NombreCategoria" HeaderText="Categoria" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:BoundField DataField="Stock" HeaderText="Stock" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CssClass="btn btn-primary" OnClick="Editar_Producto" CommandArgument='<%# Eval("IdProducto") %>'>Editar </asp:LinkButton>
                            <asp:LinkButton runat="server" CssClass="btn btn-danger" OnClick="Eliminar_Producto" CommandArgument='<%# Eval("IdProducto") %>' OnClientClick="return confirm('¿Está seguro de eliminar el registro')">Eiminar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>



</asp:Content>
