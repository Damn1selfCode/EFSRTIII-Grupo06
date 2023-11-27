<%@ Page  Title="Clientes"  Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="CapaPresentacion.Mantenimiento.Clientes" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


          <div class="row">
        <div class="col-12">
            <h2>Mantenimiento Cliente</h2>

            <div class="row">
                <div class="col-12">
                    <asp:Button runat="server" OnClick="Nuevo_Cliente" Text="Nuevo Cliente" CssClass="btn btn-success" Style="float: right;" />
                </div>
            </div>
            <asp:GridView ID="GVClienteMantenmiento" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" />
                    <asp:BoundField DataField="Ruc" HeaderText="Ruc" />
                    <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                    <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                    <asp:BoundField DataField="email" HeaderText="Correo Electronico" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CssClass="btn btn-primary" OnClick="Editar_Cliente" CommandArgument='<%# Eval("IdCliente") %>'>Editar </asp:LinkButton>
                            <asp:LinkButton runat="server" CssClass="btn btn-danger" OnClick="Eliminar_Cliente" CommandArgument='<%# Eval("IdCliente") %>' OnClientClick="return confirm('¿Está seguro de eliminar el registro')">Eliminar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

  </asp:Content>
