<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="MatoshreeProject.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <link rel="icon" type="image/png" sizes="50x50" href="Img_logo/M.png" />
    <title>Matoshree Interior | Log in</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />

    <!-- Core Css -->
    <link rel="stylesheet" href="AMatrixLatest/dist/assets/css/styles.css" />

</head>
<body>
    <div class="toast toast-onload align-items-center text-bg-secondary border-0" role="alert" aria-live="assertive" aria-atomic="true">
        <div class="toast-body hstack align-items-start gap-6">
            <i class="ti ti-alert-circle fs-6"></i>
            <div>
                <h5 class="text-white fs-3 mb-1">Welcome to Matoshree Interior</h5>
            </div>
            <button type="button" class="btn-close btn-close-white fs-2 m-0 ms-auto shadow-none" data-bs-dismiss="toast" aria-label="Close"></button>
        </div>
    </div>
    <!-- Preloader -->
    <div class="preloader">
        <%--<img src="Img_logo/M.png" alt="loader" class="lds-ripple img-fluid" width="50px"/>--%>

        <img src="" id="preloaderImg" runat="server" alt="loader" class="lds-ripple img-fluid" width="100" />
    </div>
    <div id="main-wrapper">
        <div class="position-relative overflow-hidden radial-gradient min-vh-100 w-100 d-flex align-items-center justify-content-center">
            <div class="d-flex align-items-center justify-content-center w-100">
                <div class="row justify-content-center w-100">
                    <div class="col-md-8 col-lg-6 col-xxl-3">
                        <div class="card mb-0">
                            <div class="card-body">
                                <a href="#" class="text-nowrap logo-img text-center d-block mb-5 w-100">
                                    <b class="logo-icon">
                                        <!--You can put here icon as well // <i class="wi wi-sunset"></i> //-->
                                        <!-- Dark Logo icon -->
                                      <%--  <img src="Img_logo/M.png" alt="homepage" width="120px" />--%>
                                        <img id="smlogo1" runat="server"  alt="homepage" width="120" />
                                    </b>
                                    <!--End Logo icon -->
                                    <!-- Logo text -->
                                    <span class="logo-text">

                                        <!-- dark Logo text -->
                                      <%--  <img src="Img_logo/MI%20Logo.png" alt="homepage" class="dark-logo" width="140px" />
                                        <!-- Light Logo text -->
                                        <img src="Img_logo/MI%20Logo.png" class="light-logo" alt="homepage" width="140px" />--%>

                                         <!-- dark Logo text -->
                                       <img id="textlogo1" runat="server" alt="homepage" class="dark-logo" width="140" />
                                        <!-- Light Logo text -->
                                        <img id="textlogo2" runat="server" class="light-logo" alt="homepage" width="140" />

                                    </span>
                                </a>
                                <div class="position-relative text-center my-4">
                                    <p class="mb-0 fs-4 px-3 d-inline-block bg-white text-dark z-index-5 position-relative">
                                        <asp:Label ID="lblTitle" runat="server" Text="Sign In" ForeColor="Black"></asp:Label>
                                    </p>
                                    <span class="border-top w-100 position-absolute top-50 start-50 translate-middle"></span>
                                </div>
                                <form id="form1" runat="server">
                                  
                                        <div class="mb-2">
                                            <asp:Label ID="lblEmail" runat="server" Text="Email Address" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txtEmailAddress" runat="server" placeholder="Enter Email Address" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequEmailAddress" runat="server" ErrorMessage="Enter Email Address" ControlToValidate="txtEmailAddress" ForeColor="Red" Font-Bold="false" Font-Size="12px" ValidationGroup="LogIn"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegexEmail" runat="server" ControlToValidate="txtEmailAddress" ValidationGroup="LogIn" ErrorMessage="Enter Valid Email" Font-Bold="false" Font-Size="12px" ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" Font-Italic="true"></asp:RegularExpressionValidator>
                                        </div>
                                  
                                        <div class="mb-2">
                                            <asp:Label ID="lblPassword" runat="server" Text="Password"  CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txtPassword" runat="server" placeholder="Enter Password" CssClass="form-control" TabIndex="27" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiPassword" runat="server" ErrorMessage="Enter Password" ControlToValidate="txtPassword" ForeColor="Red" ValidationGroup="LogIn" Font-Size="12px"></asp:RequiredFieldValidator>

                                        </div>
                                   
                                  
                                    <div class="d-flex align-items-center justify-content-between mb-4">
                                        <div class="form-check">
                                           <input id="ChkRemberMe1" type="checkbox" runat="server" class="form-check-input primary" checked="checked"/>
                                            <label class="form-check-label text-dark" for="ChkRemberMe1">
                                                Remeber this Device
                                            </label>
                                        </div>
                                        <asp:LinkButton ID="LinkbtnForgetPassWord" runat="server" CssClass="text-primary fw-medium" CausesValidation="false" ValidationGroup="Forget" OnClick="btnForgetPassWord_Click">Forgot Password ?</asp:LinkButton>

                                    </div>
                                    <asp:Button ID="btnLogIn" runat="server" Text="Sign In" CssClass="btn btn-primary btn-sm w-100 py-8 mb-4 rounded-2" ValidationGroup="LogIn" OnClick="btnLogIn_Click" />
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="dark-transparent sidebartoggler"></div>
    <!-- Import Js Files -->

    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/js/app.min.js"></script>
    <script src="AMatrixLatest/dist/assets/js/app.init.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/simplebar/dist/simplebar.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/iconify-icon@1.0.8/dist/iconify-icon.min.js"></script>
    <script src="AMatrixLatest/dist/assets/js/sidebarmenu.js"></script>
    <script src="AMatrixLatest/dist/assets/js/theme.js"></script>
    <script src="AMatrixLatest/dist/assets/js/feather.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/apexcharts/dist/apexcharts.min.js"></script>
</body>
</html>
