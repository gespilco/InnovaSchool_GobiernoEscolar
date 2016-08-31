<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InnovaSchool.UserLayer.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<!-- start: Meta -->
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="autor" content="Jaime Acuña" />
	<title>Innova Schools - Login</title>
	<!-- end: Meta -->
	<!-- start: Mobile Specific -->
	<meta name="viewport" content="width=device-width, initial-scale=1" />
	<!-- end: Mobile Specific -->
    <!-- start: Favicon -->
    <link rel="shortcut icon" href="../img/favicon.png" />
	<!-- end: Favicon -->
    <!-- start: JavaScript-->
    <script src="../Scripts/jquery-1.9.1.min.js"></script>
    <script src="../Scripts/jquery-migrate-1.0.0.min.js"></script>
    <script src="../Scripts/jquery-ui-1.10.0.custom.min.js"></script>
    <script src="../Scripts/jquery.ui.touch-punch.js"></script>
    <script src="../Scripts/modernizr.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery.cookie.js"></script>
    <script src='../Scripts/fullcalendar.min.js'></script>
    <script src='../Scripts/jquery.dataTables.min.js'></script>
    <script src="../Scripts/excanvas.js"></script>
    <script src="../Scripts/jquery.flot.js"></script>
    <script src="../Scripts/jquery.flot.pie.js"></script>
    <script src="../Scripts/jquery.flot.stack.js"></script>
    <script src="../Scripts/jquery.flot.resize.min.js"></script>
    <script src="../Scripts/jquery.chosen.min.js"></script>
    <script src="../Scripts/jquery.uniform.min.js"></script>
    <script src="../Scripts/jquery.cleditor.min.js"></script>
    <script src="../Scripts/jquery.noty.js"></script>
    <script src="../Scripts/jquery.elfinder.min.js"></script>
    <script src="../Scripts/jquery.raty.min.js"></script>
    <script src="../Scripts/jquery.iphone.toggle.js"></script>
    <script src="../Scripts/jquery.uploadify-3.1.min.js"></script>
    <script src="../Scripts/jquery.gritter.min.js"></script>
    <script src="../Scripts/jquery.imagesloaded.js"></script>
    <script src="../Scripts/jquery.masonry.min.js"></script>
    <script src="../Scripts/jquery.knob.modified.js"></script>
    <script src="../Scripts/jquery.sparkline.min.js"></script>
    <script src="../Scripts/counter.js"></script>
    <script src="../Scripts/retina.js"></script>
    <script src="../Scripts/custom.js"></script>
    <script src="../Scripts/mensaje.js"></script>
    <!-- end: JavaScript-->
	<!-- start: CSS -->
	<link href="../css/bootstrap.min.css" rel="stylesheet" />
	<link href="../css/bootstrap-responsive.min.css" rel="stylesheet" />
	<link href="../css/style.css" rel="stylesheet" />
	<link href="../css/style-responsive.css" rel="stylesheet" />
	<link href="http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800&subset=latin,cyrillic-ext,latin-ext" rel="stylesheet" type="text/css" />
	<!-- end: CSS -->
</head>
<body class="background-body">
    <div class="container-fluid-full">
        <div class="row-fluid">
            <div class="row-fluid">
                <div class="login-box">
                    <div style="position: relative; margin-left: 60px; margin-bottom: 20px; margin-top: 10px;" class="center">
                        <img id="logo" class="img-responsive" src="../Img/logo/innova_schools.png" />
                    </div>
                    <h2>Ingrese a su cuenta</h2>
                    <form id="form" class="form-horizontal" runat="server">
                        <div class="input-prepend" title="Username">
                            <span class="add-on"><i class="halflings-icon user"></i></span>
                            <asp:TextBox ID="username" runat="server" class="input-large span10" type="text" placeholder="Usuario" name="username"
                                    title="Se requiere un usuario" required autofocus></asp:TextBox>
                        </div>
                        <div class="clearfix"></div>
                        <div class="input-prepend" title="Password">
                            <span class="add-on"><i class="halflings-icon lock"></i></span>
                            <asp:TextBox ID="password" runat="server" class="input-large span10" type="password" placeholder="Contraseña" name="password"
                                    title="Se requiere una contraseña" required></asp:TextBox>
                        </div>
                        <div class="clearfix"></div>
                        <label class="remember" for="remember">
                            <input type="checkbox" id="remember" />Recuérdame</label>
                        <div class="button-login">
                            <asp:Button ID="btnIniciarSesion" runat="server" type="submit" Text="Iniciar Sesión" class="btn btn-primary" OnClick="btnIniciarSesion_Click"/>
                        </div>
                        <div class="clearfix"></div>
                        <!-- Mensaje de Alerta -->
	                    <div id="mensaje"></div>
                        <!-- Fin de Mensaje -->
                    </form>
                    <h3>¿Se te olvidó tu contraseña?</h3>
                    <p>No hay problema, haga <a href="#">clic aquí</a>.</p>
                </div>
                <!--/span-->
            </div>
            <!--/row-->
        </div>
        <!--/.fluid-container-->
    </div>
    <!--/fluid-row-->
</body>
</html>
