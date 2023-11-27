<%@ Page Title="Servicios" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Servicios.aspx.cs"  Inherits="CapaPresentacion.Mantenimiento.Servicios" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

          <div class="row">
        <div class="col-12">
            <h2>Mantenimiento Servicios</h2>

            <div class="row">
                <div class="col-12">
                    <asp:Button runat="server" OnClick="Nuevo_Servicio" Text="Nuevo Servicio" CssClass="btn btn-success" Style="float: right;" />
                </div>
            </div>

            <asp:GridView ID="GVServicioMantenmiento" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="NombreServicio" HeaderText="Servicio" />
                    <asp:BoundField DataField="DetalleServicio" HeaderText="Descripcion" />
                    <asp:BoundField DataField="TipoServicio.TipoServicio" HeaderText="Tipo Servicio" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:BoundField DataField="Activo" HeaderText="Activo" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CssClass="btn btn-primary" OnClick="Editar_Servicio" CommandArgument='<%# Eval("idServicio") %>'>Editar </asp:LinkButton>
                            <asp:LinkButton runat="server" CssClass="btn btn-danger" OnClick="Eliminar_Servicio" CommandArgument='<%# Eval("idServicio") %>' OnClientClick="return confirm('¿Está seguro de eliminar el registro')">Eliminar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

  </asp:Content>

