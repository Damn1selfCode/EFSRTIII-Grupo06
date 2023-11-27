<%@ Page  Title="Clientes"  Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Venta.aspx.cs" Inherits="CapaPresentacion.Venta" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


        <div  class="container">
            <h2 style="text-align: center;">Venta</h2>

          
        <asp:UpdatePanel ID="updateClientePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            
            <p>RUC Cliente : 
                <asp:TextBox ID="txtBuscarCliente" runat="server" CssClass="form-control"  placeholder="Ingresar RUC"></asp:TextBox>
                <br/>
                <asp:Button ID="btnBuscarCliente" runat="server"  CssClass="btn btn-success"  Text="Buscar" OnClick="btnBuscarCliente_Click" />
                <asp:Button ID="btnProcesarVenta" runat="server" CssClass="btn btn-primary"  Text="Procesar Venta" OnClick="btnProcesarVenta_Click" />  
                <asp:Button ID="btnGenerarFactura" runat="server"  CssClass="btn btn-secondary"  Text="Generar Factura" OnClick="btnGenerarFactura_Click"  Visible="false"/>
                
            </p>
            <asp:GridView ID="gvClientes" runat="server"   AutoGenerateColumns="False" DataKeyNames="IdCliente" OnRowCommand="gvClientes_RowCommand" CssClass="table table-striped table-bordered">

                 <Columns>
                    <asp:BoundField DataField="Ruc" HeaderText="RUC" SortExpression="Ruc" ReadOnly="True" />
                    <asp:BoundField DataField="NombreCliente" HeaderText="Nombre" SortExpression="NombreCliente" ReadOnly="True" />
                    <asp:BoundField DataField="email" HeaderText="Correo" SortExpression="email" ReadOnly="True" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select" CommandArgument='<%# Eval("IdCliente") %>'>
                                <i class="fas fa-check"></i> Seleccionar
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="table-hover" />
                <HeaderStyle CssClass="thead-dark" />
            </asp:GridView>                
            </ContentTemplate>
        </asp:UpdatePanel>
            
            
            <asp:UpdatePanel ID="updateProductoPanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
            
                    <p>
                         <asp:RadioButton ID="rbProducto" runat="server"   Text="Producto" GroupName="TipoSeleccion" Checked="True" />
                        <asp:RadioButton ID="rbServicio" runat="server"   Text="Servicio" GroupName="TipoSeleccion" />

                        <asp:TextBox ID="txtBuscar" runat="server" placeholder="Ingresar datos de busqueda"></asp:TextBox>
                        
                        <asp:Button ID="BtnBuscar" runat="server"   Text="Buscar" CssClass="btn btn-success" OnClick="btnBuscar_Click" />
                        
                        <asp:Label ID="LblMensajeProcesar" runat="server" CssClass="text-danger"></asp:Label>
                    </p>
                    
                    <asp:GridView ID="GvProducto" runat="server" AutoGenerateColumns="False" DataKeyNames="IdProducto" OnRowCommand="GvProducto_RowCommand" CssClass="table table-striped table-bordered">

                        <Columns>
                            <asp:BoundField DataField="NombreProducto" HeaderText="NombreProducto" SortExpression="NombreProducto" ReadOnly="True" />
                            <asp:BoundField DataField="Proveedor.NombreProveedor" HeaderText="NombreProveedor" SortExpression="NombreProveedor" ReadOnly="True" />
                            <asp:BoundField DataField="Categoria.NombreCategoria" HeaderText="NombreCategoria" SortExpression="NombreCategoria" ReadOnly="True" />
                            <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" ReadOnly="True" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select" CommandArgument='<%# Eval("IdProducto") %>'>
                                        <i class="fas fa-check"></i> Seleccionar Producto
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="table-hover" />
                        <HeaderStyle CssClass="thead-dark" />
                    </asp:GridView>

                    <asp:GridView ID="GvServicio" runat="server" AutoGenerateColumns="False" DataKeyNames="IdServicio" 
                                  OnRowCommand="GvServicio_RowCommand" CssClass="table table-striped table-bordered">

                        <Columns>
                            <asp:BoundField DataField="NombreServicio" HeaderText="Nombre Servicio" SortExpression="Servicio" ReadOnly="True" />
                            <asp:BoundField DataField="DetalleServicio" HeaderText="Detalle del Servicio" SortExpression="Detalle" ReadOnly="True" />
                            <asp:BoundField DataField="TipoServicio.TipoServicio" HeaderText="Tipo Servicio" SortExpression="Tip.Servicio" ReadOnly="True" />
                            <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" ReadOnly="True" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select" CommandArgument='<%# Eval("IdServicio") %>'>
                                        <i class="fas fa-check"></i> Seleccionar Servicio
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="table-hover" />
                        <HeaderStyle CssClass="thead-dark" />
                    </asp:GridView>
                    
                    <p>
                        
                        <asp:TextBox ID="txtCantidad" runat="server"  CssClass="form-control" placeholder="Ingresar cantidad"></asp:TextBox>
                        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger"></asp:Label>

                    </p>
                    
                    <asp:GridView ID="gvDetalles" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" DataKeyNames="Codigo, Tipo" >
                        <Columns>
                            <asp:BoundField DataField="Codigo" HeaderText="Codigo" SortExpression="Codigo" />
                            <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                            <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
                            <asp:BoundField DataField="SubTotal" HeaderText="SubTotal" SortExpression="SubTotal" />
                        </Columns>
                        <RowStyle CssClass="table-hover" />
                        <HeaderStyle CssClass="thead-dark" />
                    </asp:GridView>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
            

  </asp:Content>
