<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="NewContactCustomer.aspx.cs" Inherits="MatoshreeProject.NewContactCustomer" EnableEventValidation="false" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script> 
        tinymce.init({
            // selector: 'textarea',
            //selector : "textarea.Editor"
            selector: ".EditorNote",
            //theme: "modern",
            //plugins: ["lists link image charmap print preview hr anchor pagebreak"],

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">

        <%-- BreadCrumbs --%>
        <h5 class="font-weight-medium mb-0">New Contact Customer</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Customer.aspx">Customer
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="EditCustomer.aspx">Edit Customer
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="NewContactCustomer.aspx">New Contact</li>
            </ol>
        </nav>
        <br />
        <%-- BreadCrumbs --%>




        <div class="row">
            <%-- <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">--%>

            <div class="col-md-2 col-sm-2 col-xl-2 col-lg-2"></div>

            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <div class="card">

                    <div class="card-body">
                        <asp:Label ID="lblCustID1" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblEmpNameEmail11" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblEmpName11" runat="server" Text="" Visible="false"></asp:Label>
                        <hr />

                        <div class="mb-2">
                            <asp:Label ID="lblfileupload" runat="server" Text="Profile Image" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000"></span>
                            <asp:FileUpload ID="FileUpload1" runat="server" name="fileupload" class="form-control" />
                        </div>


                        <div class="mb-2">
                            <asp:Label ID="lbl_First_Name" runat="server" Text="First Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                            <asp:TextBox ID="txtFirst_Name" runat="server" placeholder="Enter First Name" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldFirst_Name" runat="server" ErrorMessage="Enter First Name" ControlToValidate="txtFirst_Name" ForeColor="Red" Font-Bold="false" ValidationGroup="add" Font-Size="12px"></asp:RequiredFieldValidator>
                        </div>

                        <div class="mb-2">
                            <asp:Label ID="lbl_last_Name" runat="server" Text="Last Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                            <asp:TextBox ID="txt_Last_Name" runat="server" placeholder="Enter Last Name" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldLast_Name" runat="server" ErrorMessage="Enter Last Name" ControlToValidate="txt_Last_Name" ForeColor="Red" Font-Bold="false" ValidationGroup="add" Font-Size="12px"></asp:RequiredFieldValidator>
                        </div>


                        <div class="mb-2">
                            <asp:Label ID="lblPosition" runat="server" Text="Position" CssClass="form-label"></asp:Label>&nbsp; <span style="color: #FF0000">*</span>

                            <asp:TextBox ID="txt_Position" runat="server" Placeholder="Enter Position" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldPosition" runat="server" ErrorMessage="Enter Position" ValidationGroup="add" Display="Dynamic" ControlToValidate="txt_Position" ForeColor="Red" Font-Size="12px"></asp:RequiredFieldValidator>
                        </div>

                        <div class="mb-2">
                            <asp:Label ID="lbl_Email" runat="server" Text="Email" CssClass="form-label"></asp:Label>&nbsp;<span id="ct6_YourControl3" style="color: red;">*</span>
                            <asp:TextBox ID="txt_Email" runat="server" Placeholder="Enter E-mail" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter Email" ValidationGroup="add" Display="Dynamic" ControlToValidate="txt_Email" ForeColor="Red" Font-Size="12px"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="txt_Email" Font-Bold="false" ValidationGroup="add" ErrorMessage="Invalid E-mail" ValidationExpression="^\S+@\S+$" ForeColor="Red" Font-Size="12px"></asp:RegularExpressionValidator>
                        </div>
                        <div class="mb-2">
                            <asp:Label ID="Label2" runat="server" Text="Mobile No" CssClass="form-label"></asp:Label>&nbsp;<span style="color: red">*</span>
                            <asp:TextBox ID="txt_Phone" runat="server" TextMode="Number" Placeholder="Enter Mobile" CssClass="form-control" MaxLength="10"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldPhone" ValidationGroup="add" runat="server" Font-Bold="false" ErrorMessage="Enter Mobile No" ControlToValidate="txt_Phone" ForeColor="Red" Font-Size="12px"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="Phone" runat="server" ControlToValidate="txt_Phone" Font-Bold="false" ValidationGroup="add" ErrorMessage="Invalid Mobile No" ValidationExpression="^{1}[0-9]{10}$" ForeColor="Red" Font-Size="12px"></asp:RegularExpressionValidator>
                        </div>
                        <div class="mb-2">
                            <asp:Label ID="Label11" runat="server" CssClass="form-label" Text="Direction"></asp:Label>
                            <asp:DropDownList ID="ddlDirection" runat="server" CssClass="form-control form-select">
                                <asp:ListItem Selected="True">System Default</asp:ListItem>
                                <asp:ListItem Value="1" Text="LTR"></asp:ListItem>
                                <asp:ListItem Value="2" Text="RTL"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="row">
                          <div class="col-md-12 col-sm-12 col-ld-12">
                                <div class="mb-2">
                                    <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="form-label"></asp:Label>&nbsp;<span id="ctl_YourContro112" style="color: red;">*</span>
                                    <div class="input-group">
                                        <asp:TextBox ID="txt_Password" Placeholder="Enter Password" runat="server" CssClass="form-control" aria-describedby="basic-addon2 basic-addon3">
                                        </asp:TextBox>
                                        <div class="input-group-md">
                                            <span class="input-group-text" id="basic-addon2">
                                                <asp:LinkButton ID="LinkBtnEyesPassword" runat="server" ForeColor="Gray" Height="14px"><i class="ti ti-eye"></i></asp:LinkButton></span>
                                        </div>
                                        <div class="input-group-md">
                                            <span class="input-group-text" id="basic-addon3">
                                                <asp:LinkButton ID="LinkbtnResetPassword" runat="server" ForeColor="Gray" Height="14px" ValidationGroup="String" OnClick="LinkbtnResetPassword_Click"><i class="ti ti-refresh"></i></asp:LinkButton></span>
                                        </div>
                                    </div>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Password" ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Paasword." ValidationGroup="add" Font-Size="12px" />
                            </div>
                        </div>

                        <div class="row">
                           <div class="col-md-12 col-sm-12 col-ld-12">
                                <div class="mb-2">
                                    <asp:CheckBox ID="CheckBPrimary" runat="server" CssClass="form-check" Text="Primary contact" Checked="true" />

                                    <br />

                                    <asp:CheckBox ID="CheckBoxwelcome" runat="server" Text="Do not send welcome email" CssClass="form-check" AutoPostBack="true" OnCheckedChanged="CheckBoxwelcome_CheckedChanged" />

                                    <br />

                                    <asp:CheckBox ID="CheckBoxpassword" runat="server" CssClass="form-check" Text="Send SET password email" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-ld-12">
                                    <asp:TextBox ID="txtEmailDescription" runat="server" TextMode="MultiLine" class="EditorNote" Visible="false"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <hr />
                         <h5 class="font-weight-medium mb-0">Permissions</h5>
                        <p class="text-danger">Make sure to set appropriate permissions for this contact</p>

                        <div class="row">
                            <div class="col-md-4">

                                <asp:Label ID="lblInvoices" runat="server" CssClass="form-label" Text="Invoices"></asp:Label>
                            </div>
                            <div class="col-md-8">
                                <asp:CheckBox ID="chkInvoices" runat="server" Checked="true" CssClass=" font-bold" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-4">
                                <asp:Label ID="lblEstimate" runat="server" CssClass="form-label" Text="Estimate"></asp:Label>
                            </div>
                            <div class="col-md-8">
                                <asp:CheckBox ID="chkEstimate" runat="server" Checked="true" CssClass=" font-bold" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-4">
                                <asp:Label ID="lblContracts" runat="server" CssClass="form-label" Text="Contracts"></asp:Label>
                            </div>
                            <div class="col-md-8">
                                <asp:CheckBox ID="chkContracts" runat="server" Checked="true" CssClass=" font-bold" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-4">
                                <asp:Label ID="lblTender" runat="server" CssClass="form-label" Text="Tender"></asp:Label>
                            </div>
                            <div class="col-md-8">
                                <asp:CheckBox ID="chkTender" runat="server" Checked="true" CssClass=" font-bold" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-4">
                                <asp:Label ID="lblProjects" runat="server" CssClass="form-label" Text="Projects"></asp:Label>
                            </div>
                            <div class="col-md-8">
                                <asp:CheckBox ID="chkProjects" runat="server" Checked="true" CssClass=" font-bold" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-4">
                                <asp:Label ID="lblTickets" runat="server" CssClass="form-label" Text="Tickets"></asp:Label>
                            </div>
                            <div class="col-md-8">
                                <asp:CheckBox ID="chkTickets" runat="server" Checked="true" CssClass=" font-bold" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-4 ">
                                <asp:Label ID="lblAnnouncement" runat="server" CssClass="form-label" Text="Announcement"></asp:Label>
                            </div>
                            <div class="col-md-8">
                                <asp:CheckBox ID="chkAnnouncement" runat="server" Checked="true" CssClass=" font-bold" />
                            </div>
                        </div>
                        <br />
                        <hr />
                        <div class="row">
                            <div class="col-md-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblDefault" runat="server" Text="Granted Access" CssClass="form-label"></asp:Label>

                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" TabIndex="24" Font-Size="12px">
                                        <asp:ListItem Selected="True" Text="Active" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <div class="mb-2">
                            <asp:Button ID="btnSaveContacts" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="add" OnClick="btnSaveContacts_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnClearContacts" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" OnClick="btnClearContacts_Click" />
                        </div>
                    </div>

                </div>
            </div>
            <div class="col-md-2 col-sm-2 col-xl-2 col-lg-2"></div>


        </div>
    </div>

    <%-- Styles --%>
    <script type="text/javascript">
        var togglePassword = document.querySelector('#LinkBtnEyesPassword');
        var password = document.querySelector('#txt_Password');
        togglePassword.addEventListener('click', function (e) {
            const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
            password.setAttribute('type', type);
            this.classList.toggle('fa-eye-slash');
        });
    </script>
</asp:Content>
