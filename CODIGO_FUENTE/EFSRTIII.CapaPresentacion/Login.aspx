<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CapaPresentacion.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Sistema de Ventas</title>
    <!-- Agregar estilos de Bootstrap desde CDN -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <!-- Estilos adicionales para el formulario de inicio de sesión -->
    <style>
        body {
            background-color: #f8f9fa;
        }

        .login-container {
            max-width: 400px;
            margin: auto;
            margin-top: 100px;
        }

        .card {
            border: none;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .card-header {
            background-color: #6f42c1; /* Morado oscuro */
            color: #fff;
            text-align: center;
            padding: 15px;
            border-top-left-radius: 10px;
            border-top-right-radius: 10px;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .btn-primary {
            background-color: #9c27b0; /* Morado */
            border: none;
        }

        .btn-primary:hover {
            background-color: #7b1fa2; /* Morado oscuro al pasar el ratón */
        }

        .btn-cart {
            background-color: #e91e63; /* Rosa */
            border: none;
        }

        .btn-cart:hover {
            background-color: #d81b60; /* Rosa oscuro al pasar el ratón */
        }

        .img-cart {
            max-width: 100%;
            height: auto;
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container login-container">
            <div class="card">
                <div class="card-header">
                    <h2>Inicio de Sesión</h2>
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <label for="txtUsuario">Usuario</label>
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Ingrese su usuario"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtContraseña">Contraseña</label>
                        <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" CssClass="form-control" placeholder="Ingrese su contraseña"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnLogin" runat="server" Text="Iniciar sesión" CssClass="btn btn-primary btn-block" OnClick="btnLogin_Click" />
                    </div>
                   
                </div>
            </div>
        </div>


        <!-- Agregar scripts de Bootstrap desde CDN al final del cuerpo -->
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.3/dist/umd/popper.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    </form>
</body>
</html>