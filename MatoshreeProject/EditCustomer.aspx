<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="EditCustomer.aspx.cs" Inherits="MatoshreeProject.EditCustomer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            var GriExitingContact = $("#GriExitingContact").prepend($("<thead></the ad>").append($("#GriExitingContact").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridTask1 = $("#GridTask1").prepend($("<thead></thead>").append($("#GridTask1").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "140%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridInvoice = $("#GridInvoice").prepend($("<thead></thead>").append($("#GridInvoice").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "140%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridProject = $("#GridProject").prepend($("<thead></thead>").append($("#GridProject").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

           

            var GridviewRemainder1 = $("#GridviewRemainder1").prepend($("<thead></thead>").append($("#GridviewRemainder1").find("tr:first"))).DataTable(
                {                  
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "180%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                    "bPaginate": true,
                    "columnDefs": [
                        {
                            "targets": [0, 1],
                            "visible": true
                        },
                        {
                            "targets": '_all',
                            "visible": false
                        }
                    ]
                    
                });

            var GridFile = $("#GridFile").prepend($("<thead></thead>").append($("#GridFile").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });


            var GridviewContract1 = $("#GridviewContract1").prepend($("<thead></thead>").append($("#GridviewContract1").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var Gridticket = $("#Gridticket").prepend($("<thead></thead>").append($("#Gridticket").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridPayments = $("#GridPayments").prepend($("<thead></thead>").append($("#GridPayments").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });
        });

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="font-weight-medium mb-0">Edit Customer</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Customer.aspx">Customer
                            </a>
                        </li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="EditCustomer.aspx">Edit Customer</li>
                    </ol>
                </nav>
            </div>
            <%-- Toaster --%>
            <div class="col-md-4 col-sm-4 col-xl-4 col-lg-4">
                <div id="Toasteralert" runat="server" visible="false">
                    <div class="toast" role="alert" aria-live="assertive" aria-atomic="true">
                        <div class="d-flex">
                            <div class="toast-body">
                                <asp:Label ID="lblMessage" runat="server" Text="" Font-Size="13.5px" ForeColor="Black"></asp:Label>
                            </div>
                            <button type="button" class="btn-close me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
                        </div>
                    </div>
                </div>

                <div id="deleteToaster" runat="server" visible="false">
                    <div class="toast" role="alert" aria-live="assertive" aria-atomic="true">
                        <div class="d-flex">
                            <div class="toast-body">
                                <asp:Label ID="lblMesDelete" runat="server" Text="" Font-Size="13.5px" ForeColor="Black"></asp:Label>
                            </div>
                            <button type="button" class="btn-close me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
                        </div>
                    </div>
                </div>
            </div>
            <%-- Toaster --%>
        </div>
        <br />


        <div class="row">
            <div class="col-md-3 col-sm-3 col-lg-3">
                <div class="card">
                    <div class="card-body">
                        <h5 class="text-purple">Edit Customer</h5>
                        <hr />

                        <table class="table table-responsive-sm table-responsive-md table-responsive-lg table-hover" style="width: 100%;">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonProfile" runat="server" CssClass="" ForeColor="Black" ValidationGroup="Profile" OnClick="LinkButtonProfile_Click">Profile</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonContact" runat="server" CssClass="" ForeColor="Black" ValidationGroup="Contact" OnClick="LinkButtonContact_Click">Contact</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonInvoice" runat="server" CssClass="" ForeColor="Black" ValidationGroup="Invoice" OnClick="LinkButtonInvoice_Click">Invoice</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonPayments" runat="server" CssClass="" ForeColor="Black" ValidationGroup="Payments" OnClick="LinkButtonPayments_Click">Payments</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonContracts" runat="server" CssClass="" ForeColor="Black" ValidationGroup="Contracts" OnClick="LinkButtonContracts_Click">Contracts</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonProjects" runat="server" CssClass="" ForeColor="Black" ValidationGroup="Projects" OnClick="LinkButtonProjects_Click">Projects</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonTickets" runat="server" CssClass="" ForeColor="Black" ValidationGroup="Tickets" OnClick="LinkButtonTickets_Click">Tickets</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonTasks" runat="server" CssClass="" ForeColor="Black" ValidationGroup="Tasks" OnClick="LinkButtonTasks_Click">Tasks</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonFiles" runat="server" CssClass="" ForeColor="Black" ValidationGroup="Files" OnClick="LinkButtonFiles_Click">Files</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonReminders" runat="server" CssClass="" ForeColor="Black" ValidationGroup="Reminders" OnClick="LinkButtonReminders_Click">Reminders</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonNotes" runat="server" CssClass="" ForeColor="Black" ValidationGroup="Notes" OnClick="LinkButtonNotes_Click">Notes</asp:LinkButton>
                                    </td>
                                </tr>
                            </tbody>
                        </table>

                    </div>
                </div>
            </div>
            <div class="col-md-9 col-sm-9 col-lg-9">
                <div id="ProfileDiv" visible="true" runat="server">
                    <div class="card">
                        <div class="card-body">
                            <h6 class="text-purple">Profile</h6>
                            <hr />
                            <ul class="nav nav-tabs" role="tablist">
                                <li class="nav-item">
                                    <h6><a class="nav-link active" data-bs-toggle="tab" href="#home" role="tab"><span class="hidden-sm-up"></span>
                                        <span><i class="ti ti-users fs-4"></i>Customer Details</span></a></h6>
                                    <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
                                </li>
                                <li class="nav-item">
                                    <h6><a class="nav-link" data-bs-toggle="tab" href="#profile" role="tab"><span class="hidden-sm-up"></span>
                                        <span><i class="ti ti-address-book fs-4"></i>Address</span></a></h6>
                                </li>
                            </ul>
                            <br />
                            <div class="tab-content tabcontent-border">
                                <div class="tab-pane active" id="home" role="tabpanel">
                                    <div class="p-20">
                                        <div class="row">
                                            <div class="col-md-6 col-sm-6 col-lg-6">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblCompany" runat="server" Text="Company Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                    <asp:TextBox ID="txtCompany" runat="server" CssClass="form-control" placeholder="Enter Company Name"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtCompany" ErrorMessage="Enter Company Name" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-sm-6 col-lg-6">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblPhone" for="Phone" runat="server" Text="Phone" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                    <asp:TextBox ID="txtPhone" runat="server" name="phone" CssClass="form-control" placeholder="Enter Phone Number" MaxLength="10" TextMode="Phone"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfv_Phone" runat="server" Display="Dynamic" ControlToValidate="txtPhone" ErrorMessage="Enter 10 digit Phone Number" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="Regulexphone" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone Number Invalid." ForeColor="Red" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6 col-sm-6 col-lg-6">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblGSTNumber" for="GSTNumber" runat="server" Text="GST Number" CssClass="form-label"></asp:Label>
                                                    <asp:TextBox ID="txtGSTNumber" runat="server" name="gstnumber" CssClass="form-control" placeholder="Enter GST Number" MaxLength="15" ValidateRequestMode="Enabled"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="col-md-6 col-sm-6 col-lg-6">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblEmail" for="Phone" runat="server" Text="Email" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                    <asp:TextBox ID="txtEmail" runat="server" name="email" CssClass="form-control" placeholder="Enter Email Address"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rvfEmail" runat="server" Display="Dynamic" ControlToValidate="txtEmail" ErrorMessage="Enter Email Address" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="Regulexemail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Address Invalid." ForeColor="Red" ValidationGroup="SaveValidate" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" Font-Size="12px"></asp:RegularExpressionValidator>

                                                </div>

                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="col-md-6 col-sm-6 col-lg-6">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblAltphone" for="AlternativePhone" runat="server" Text="Alternative Phone" CssClass="form-label"></asp:Label>
                                                    <asp:TextBox ID="txtAltphone" runat="server" name="Altphone" CssClass="form-control" MaxLength="10" TextMode="Phone" placeholder="Enter Alternative Phone Number"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="Altphone" runat="server" ControlToValidate="txtAltphone" ErrorMessage="Phone Number Invalid." ForeColor="Red" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RegularExpressionValidator>

                                                </div>
                                            </div>

                                            <div class="col-md-6 col-sm-6 col-lg-6">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblCustname1" runat="server" Text="" Visible="false"></asp:Label>

                                                    <asp:Label ID="lblcustomer" runat="server" Text="Type of Customer" CssClass="form-label"></asp:Label>
                                                    <asp:DropDownList ID="ddlcustomer" runat="server" CssClass="form-select">
                                                        <asp:ListItem>Select Type Of Customer</asp:ListItem>
                                                        <asp:ListItem>Personal</asp:ListItem>
                                                        <asp:ListItem>Office</asp:ListItem>
                                                        <asp:ListItem>Shop</asp:ListItem>
                                                        <asp:ListItem>Building/Constructure</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="row">
                                            <div class="mb-2">
                                                <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                <asp:TextBox ID="txtDescription" runat="server" placeholder="Description" class="form-control" TextMode="MultiLine" Height="150px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="mb-2">
                                                <asp:Label ID="lblStatus" runat="server" Text="Status" CssClass="form-label"></asp:Label>

                                                <asp:RadioButtonList ID="RadioButtonListCustomer" runat="server" TabIndex="24" Font-Size="13.5px">
                                                    <asp:ListItem Text="Active" Value="1" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>


                                    </div>
                                </div>

                                <div class="tab-pane p-20" id="profile" role="tabpanel">
                                    <div class="p-20">
                                        <div class="row">
                                            <div class="col-md-6 col-sm-6 col-lg-6">
                                                <asp:UpdatePanel ID="UpdatePanelddlState" runat="server">
                                                    <ContentTemplate>
                                                        <h6>Billing Address&nbsp;&nbsp;<asp:Button ID="btnCopyCustomerInfo" runat="server" Text="Same as Customer Info" CssClass="btn btn-outline-info btn-sm" OnClick="btnCopyCustomerInfo_Click" ValidationGroup="Copy" /></h6>
                                                        <hr />
                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <div class="mb-2">
                                                                <asp:Label ID="lblBillingCountry" runat="server" Text="Country" CssClass="form-label"></asp:Label>
                                                                <asp:DropDownList ID="ddlCountryBilling" runat="server" CssClass="form-select" name="CountryBilling">
                                                                    <asp:ListItem Value="0">Select Country</asp:ListItem>
                                                                    <asp:ListItem Value="India">India</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <div class="mb-2">
                                                                <asp:Label ID="lblBilingState" runat="server" Text="State" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                                <asp:DropDownList ID="ddlBilingState" runat="server" CssClass="form-control form-select" OnSelectedIndexChanged="ddlBilingState_SelectedIndexChanged" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlBilingState" ForeColor="Red" Font-Size="12px" Font-Bold="false" InitialValue="0" Display="Dynamic" ValidationGroup="SaveValidate" ErrorMessage="Select State"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <div class="mb-2">
                                                                <asp:Label ID="lblBillingDistrict" runat="server" Text="District" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                                <asp:DropDownList ID="ddlBillingdistrict" runat="server" CssClass="form-control form-select" OnSelectedIndexChanged="ddlBillingdistrict_SelectedIndexChanged" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlBillingdistrict" ForeColor="Red" Font-Bold="false" InitialValue="0" Display="Dynamic" ValidationGroup="SaveValidate" ErrorMessage="Select District" Font-Size="12px"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <div class="mb-2">
                                                                <asp:Label ID="lblBillingCity1" runat="server" Text="City/Taluka" CssClass="form-label"></asp:Label>
                                                                <asp:DropDownList ID="ddlBillingcity" runat="server" CssClass="form-control form-select">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <div class="mb-2">
                                                                <asp:Label ID="lblBillingflat" runat="server" Text="Flat/Block/RoadNo" CssClass="form-label"></asp:Label>
                                                                <asp:TextBox ID="txtflatBilling" runat="server" name="flatBilling" CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <div class="mb-2">
                                                                <asp:Label ID="lblStreetShipping1" runat="server" Text="Address" CssClass="form-label"></asp:Label>
                                                                <asp:TextBox ID="txtStreetBilling" runat="server" name="StreetShipping1" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <div class="mb-2">
                                                                <asp:Label ID="lblBillingPinCode" runat="server" Text="Pin Code" CssClass="form-label"></asp:Label>
                                                                <asp:TextBox ID="txtPinBilling" runat="server" name="PinBilling" CssClass="form-control" MaxLength="6"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlBilingState" EventName="SelectedIndexChanged" />
                                                        <asp:AsyncPostBackTrigger ControlID="ddlBillingdistrict" EventName="SelectedIndexChanged" />

                                                    </Triggers>
                                                </asp:UpdatePanel>

                                            </div>
                                            <div class="col-md-6 col-sm-6 col-lg-6">
                                                <asp:UpdatePanel ID="UpdatePanelbiing" runat="server">
                                                    <ContentTemplate>
                                                        <h6>Shipping Address&nbsp;&nbsp;<asp:Button ID="btnCopyBillingInfo" runat="server" Text="Copy Billing Address" CssClass="btn btn-outline-info btn-sm" OnClick="btnCopyBillingInfo_Click" ValidationGroup="Copyas" /></h6>
                                                        <hr />
                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <div class="mb-2">
                                                                <asp:Label ID="lblCountryShipping" runat="server" Text="Country" CssClass="form-label"></asp:Label>
                                                                <asp:DropDownList ID="ddlCountryShipping" name="CountryShipping" runat="server" CssClass="form-control form-select">
                                                                    <asp:ListItem Value="0">Select Country</asp:ListItem>
                                                                    <asp:ListItem Value="India">India</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <div class="mb-2">
                                                                <asp:Label ID="lblstateShipping1" runat="server" Text="State" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                                <asp:DropDownList ID="ddlstateShipping1" runat="server" CssClass="form-control form-select" OnSelectedIndexChanged="ddlstateShipping1_SelectedIndexChanged" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlstateShipping1" ForeColor="Red" Font-Bold="false" InitialValue="0" Display="Dynamic" ValidationGroup="SaveValidate1" ErrorMessage="Select State" Font-Size="12px"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <div class="mb-2">
                                                                <asp:Label ID="lbldistrictShipping" runat="server" Text="District" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                                <asp:DropDownList ID="ddldistrictShipping" runat="server" CssClass="form-control form-select" OnSelectedIndexChanged="ddldistrictShipping_SelectedIndexChanged" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddldistrictShipping" ForeColor="Red" Font-Bold="false" InitialValue="0" Display="Dynamic" ValidationGroup="SaveValidate1" ErrorMessage="Select District" Font-Size="12px"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <div class="mb-2">
                                                                <asp:Label ID="lblcityShipping1" runat="server" Text="City/Taluka" CssClass="form-label"></asp:Label>
                                                                <asp:DropDownList ID="ddlcityShipping1" runat="server" CssClass="form-control form-select">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <div class="mb-2">
                                                                <asp:Label ID="lblStreetShipping" runat="server" Text="Flat/Block/RoadNo" CssClass="form-label"></asp:Label>
                                                                <asp:TextBox ID="txtFlatSfipping" runat="server" name="StreetShipping" CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <div class="mb-2">
                                                                <asp:Label ID="lblStreetShipping2" runat="server" Text="Address" CssClass="form-label"></asp:Label>
                                                                <asp:TextBox ID="txtStreetShipping2" runat="server" name="StreetShipping" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <div class="mb-2">
                                                                <asp:Label ID="lblPinShipping" runat="server" Text="Pin Code" CssClass="form-label"></asp:Label>
                                                                <asp:TextBox ID="txtPinShipping" runat="server" name="PinShipping" CssClass="form-control" MaxLength="6"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlstateShipping1" EventName="SelectedIndexChanged" />
                                                        <asp:AsyncPostBackTrigger ControlID="ddlcityShipping1" EventName="SelectedIndexChanged" />

                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                            </div>


                            <div class="mb-2">
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-sm btn-success" ValidationGroup="Validate" OnClick="btnUpdate_Click" />
                                &nbsp;&nbsp;
                            <asp:Button ID="btnClear" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" OnClick="btnClear_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <div id="ContactDiv" visible="false" runat="server">
                    <div class="container-fluid">
                        <div class="row">

                            <div class="card">
                                <div class="card-body">
                                    <h5 class="font-weight-medium mb-0">Contact</h5>
                                    <hr />
                                    <div id="addnew" runat="server">
                                        <div class="Col-md-2 col-sm-2 col-lg-2">
                                            <asp:Button ID="btnNewContact" runat="server" Text="New Contact" CssClass="btn btn-sm btn-primary" OnClick="btnNewContact_Click" />
                                            <%-- Msg DIV popup for save --%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="card">
                                <div class="card-body">
                                    <h6 class="card-title">View Contact Details</h6>
                                    <hr />
                                    <asp:GridView ID="GriExitingContact" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" Font-Size="12px" AutoGenerateColumns="false" CellPadding="4"
                                        ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="id">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact_Id" SortExpression="id" Visible="false" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblContact_id" runat="server" Text='<%# Bind("id") %>' Font-Bold="false" Visible="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContact_id1" runat="server" Text='<%# Bind("id") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Full_Name" SortExpression="Full Name" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblFullName" runat="server" Text='<%# Bind("FullName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFullName1" runat="server" Text='<%# Bind("FullName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Email" SortExpression="email" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("email") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail1" runat="server" Text='<%# Bind("email") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Direction" SortExpression="direction" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lbldirection" runat="server" Text='<%# Bind("direction") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldirection" runat="server" Text='<%# Bind("direction") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Position" SortExpression="position" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblPosition" runat="server" Text='<%# Bind("position") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPosition1" runat="server" Text='<%# Bind("position") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Phone" SortExpression="phonenumber" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblPhone" runat="server" Text='<%# Bind("phonenumber") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPhone1" runat="server" Text='<%# Bind("phonenumber") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Status" Visible="false" SortExpression="Status" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblStatus1" runat="server" Text='<%#Bind("active_status") %>' Font-Bold="false"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("active_status") %>' Font-Bold="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEditContacts11" runat="server" OnClick="btnEditContacts11_Click" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"  ></i></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDeleteContacts" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClick="btnDeleteContacts_Click"><i class="ti ti-trash"></i></asp:LinkButton>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                </EditItemTemplate>
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>

                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div align="center" style="color: red">
                                                <h6>No records found.</h6>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>


                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="InvoiceDiv" runat="server" visible="false">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="card">
                                <div class="card-body">
                                    <div id="addnewinvoice" runat="server">
                                        <h5 class="font-weight-medium mb-0">Add  New Invoice Details</h5>
                                        <hr />
                                        <div class="mb-2">
                                            <asp:Button ID="btn_Create_New_Invoice" runat="server" Text="Create New Invoice" CssClass="btn btn-sm btn-primary fa-pull-left" OnClick="btn_Create_New_Invoice_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="card">
                                <div class="card-body">
                                    <h5 class="font-weight-medium mb-0">View Invoice Details</h5>
                                    <hr />
                                    <asp:Button ID="btn_Export" runat="server" Text="Export" CssClass="btn btn-sm btn-outline-success" OnClick="btn_Export_Click" />
                                    <asp:Button ID="btn_Reload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="btn_Reload_Click" />
                                    <asp:Button ID="Btn_Visibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="Btn_Visibility_Click" />
                            <br />
                                    <asp:GridView ID="GridInvoice" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover table-responsive text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%" HeaderStyle-Font-Size="12px"
                                        ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridInvoice_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="InvoiceNumber" SortExpression="Invoice" HeaderStyle-Width="90px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblInvoice" runat="server" Text='<%# Bind("InvoiceNo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInvoice1" runat="server" Text='<%# Bind("InvoiceNo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                    <asp:LinkButton ID="LinkInvoiceNumber" runat="server" Text='<%# Bind("InvoiceNo") %>' Font-Size="12px" OnClick="LinkInvoiceNumber_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount" SortExpression="InvoiceTotalAmont" HeaderStyle-Width="90px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("InvoiceTotalAmont") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("InvoiceTotalAmont") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="InvoiceDate" SortExpression="InvoiceDate">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblDate" runat="server" Text='<%# Bind("InvoiceDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDate1" runat="server" Text='<%# Bind("InvoiceDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Customer" SortExpression="Cust_Name" HeaderStyle-Width="90px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblCustomer" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCustomer1" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Project" SortExpression="ProjectName" HeaderStyle-Width="90px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblProject" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProject1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SalesAgent" SortExpression="Sales_Agent" HeaderStyle-Width="90px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblSales_Agent" runat="server" Text='<%# Bind("Sales_Agent") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSales_Agent1" runat="server" Text='<%# Bind("Sales_Agent") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="InvoiceStatus" SortExpression="Status">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblStats61" runat="server" Text=""></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStats6" runat="server" Text='<%# Bind("Status") %>' Visible="false"></asp:Label>
                                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" DataTextField='<%# Bind("Status") %>' DataValueField='<%# Bind("Status") %>' AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                                        <asp:ListItem Text="Unpaid" Value="Unpaid"></asp:ListItem>
                                                        <asp:ListItem Text="Paid" Value="Paid"></asp:ListItem>
                                                        <asp:ListItem Text="Partially Paid" Value="Partially Paid"></asp:ListItem>
                                                        <asp:ListItem Text="Overdue" Value="Overdue"></asp:ListItem>
                                                        <asp:ListItem Text="Cancelled" Value="Cancelled"></asp:ListItem>
                                                        <asp:ListItem Text="Draft" Value="Draft"></asp:ListItem>
                                                        <asp:ListItem Text="Send" Value="Send"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DueDate" SortExpression="Expiry_Date">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblDue_Date" runat="server" Text='<%# Bind("Expiry_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDue_Date1" runat="server" Text='<%# Bind("Expiry_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEditInvoice" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditInvoice_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDeleteInvoice" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteInvoice_Click"><i class="ti ti-trash"></i></asp:LinkButton>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                </EditItemTemplate>
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div align="center" style="color: red">
                                                <h6>No records found.</h6>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="TasksDiv" runat="server" visible="false">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-lg-12 col-12 col-xl-12">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="font-weight-medium mb-0">Task</h5>
                                        <hr />
                                        <div class="row">

                                            <div id="addnewTask" runat="server" class="col-md-2 col-sm-2 col-2 col-lg-2">
                                                <asp:Button ID="btn_New_Task" runat="server" Text="New Task" CssClass="btn btn-sm btn-primary col-md-1" OnClick="btn_New_Task_Click" Style="width: 90px;" />&nbsp;
                                            </div>
                                            <div class="col-md-6 col-sm-6 col-lg-6  col-6"></div>
                                            <div id="Div1" runat="server" class="col-md-4 col-sm-4 col-4 col-lg-4">
                                                <asp:Button ID="btn_Task_Overview" runat="server" Text="Task Overview" CssClass="btn btn-sm btn-primary col-md-2" Width="170px" BackColor="ForestGreen" ForeColor="White" OnClick="btn_Task_Overview_Click" />&nbsp;
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="container-fluid">
                        <div class='row'>
                            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 p-2">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="font-weight-medium mb-0">View Task Details</h5>
                                        <hr />
                                        <asp:Button ID="BtnExporttask" runat="server" Text="Export" CssClass="btn btn-sm btn-outline-success" ValidationGroup="task1" OnClick="BtnExporttask_Click" />
                                        <asp:Button ID="btnVisibilityTask" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" ValidationGroup="task12" OnClick="btnVisibilityTask_Click" />
                                        <asp:Button ID="BtnReloadTask" runat="server" Text="Reload" CssClass="btn btn-sm btn-sm btn-outline-info" ValidationGroup="task13" OnClick="BtnReloadTask_Click" />
                                        <br />
                                        <br />
                                        <div id="grd" style="width: 100%">
                                            <asp:GridView ID="GridTask1" runat="server" ScrollBars="Both" CssClass="table border table-responsive table-bordered table-hover text-nowrap align-content-center" Style="width: 100%" AutoGenerateColumns="false" CellPadding="4"
                                                ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" OnRowDataBound="GridTask1_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="ID">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRowNumTask" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name" SortExpression="Subject" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txttaskName" runat="server" Text='<%# Bind("Subject") %>' Font-Size="12px"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltaskName1" runat="server" Text='<%# Bind("Subject") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="StartDate" SortExpression="Start_Date" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblStart_Date" runat="server" Text='<%#Bind("Start_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStart_Date1" runat="server" Text='<%#Bind("Start_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="DueDate" SortExpression="Due_Date" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblDue_Date" runat="server" Text='<%#Bind("Due_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDue_Date1" runat="server" Text='<%#Bind("Due_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="AssignedTo" SortExpression="AssignTo" HeaderStyle-Font-Size="12px" HeaderStyle-Width="180px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblReletd_To" runat="server" Text='<%# Bind("AssignTo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:BulletedList ID="bulletlist1" runat="server" BulletStyle="Circle" CssClass="" Width="170px">
                                                            </asp:BulletedList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status" SortExpression="TaskStatus" HeaderStyle-Font-Size="12px" HeaderStyle-Width="160px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblTaskStatus" runat="server" Text='<%#Bind("TaskStatus") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlTaskStatus" runat="server" CssClass="form-control " AutoPostBack="true" OnSelectedIndexChanged="ddlTaskStatus_SelectedIndexChanged" Style="width: 160px">
                                                                <asp:ListItem Text="In Progress" Value="In Progress"></asp:ListItem>
                                                                <asp:ListItem Text="Mark as Not Started" Value="Mark as Not Started"></asp:ListItem>
                                                                <asp:ListItem Text="Mark as Testing" Value="Mark as Testing"></asp:ListItem>
                                                                <asp:ListItem Text="Mark as Awaiting Feedback" Value="Mark as Awaiting Feedback"></asp:ListItem>
                                                                <asp:ListItem Text="Mark as Complete" Value="Mark as Complete"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Label ID="lblTaskStatus1" runat="server" Text='<%#Bind("TaskStatus") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Status" SortExpression="Status" Visible="false">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnStatus" runat="server" Text='<%# Bind("Status") %>' CssClass="btn btn-info pull-left display-block mright5" TabIndex="126" />
                                                            <asp:Label ID="lblstatus1" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false" Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Reapeted" SortExpression="Reapet_Every" HeaderStyle-Font-Size="12px" Visible="false">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblReapet_Every" runat="server" Text='<%# Bind("Reapet_Every") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblReapet_Every1" runat="server" Text='<%# Bind("Reapet_Every") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Priority" SortExpression="Priority" HeaderStyle-Font-Size="12px" HeaderStyle-Width="120px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblPriority" runat="server" Text='<%# Bind("Priority") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form-control " AutoPostBack="true" OnSelectedIndexChanged="ddlPriority_SelectedIndexChanged" Style="width: 140px">
                                                                <asp:ListItem Text="Medium" Value="Medium"></asp:ListItem>
                                                                <asp:ListItem Text="High" Value="High"></asp:ListItem>
                                                                <asp:ListItem Text="Low" Value="Low"></asp:ListItem>
                                                                <asp:ListItem Text="Urgent" Value="Urgent"></asp:ListItem>
                                                            </asp:DropDownList>

                                                            <asp:Label ID="lblPriority1" runat="server" Text='<%# Bind("Priority") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Billable" SortExpression="Billable" Visible="false">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblBillable" runat="server" Text='<%# Bind("Billable") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnBillable" runat="server" Text='<%# Bind("Billable") %>' CssClass="btn btn-info pull-left display-block mright5" TabIndex="126" />
                                                            <asp:Label ID="lblBillable1" runat="server" Text='<%# Bind("Billable") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnEditTask" runat="server" CssClass="btn btn-sm btn-outline-info mb-3" OnClick="btnEditTask_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                        </EditItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnDeleteTask" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteTask_Click"><i class="ti ti-trash"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                        </EditItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:TemplateField>

                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <div align="center" style="color: red">
                                                        <h6>No records found.</h6>
                                                    </div>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="ProjectDiv" runat="server" visible="false">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <div class="card">
                                    <div class="border-top">
                                        <div class="card-body">
                                            <div id="addNewProject" runat="server">
                                                <h5 class="font-weight-medium mb-0">Project</h5>
                                                <br />
                                                <div class="row">
                                                    <div class="Col-md-2 col-sm-2 col-lg-2">
                                                        <asp:Button ID="btnAddProject" runat="server" Text="New Project" CssClass="btn btn-sm btn-primary" OnClick="btnAddProject_Click" />
                                                    </div>

                                                </div>
                                                <hr />
                                            </div>

                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="font-weight-medium mb-0">View Project Details</h5>
                                        <hr />
                                        <div class="row">
                                            <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                                                <div class="bd-example">
                                                    <div class="btn-group">
                                                        <button class="btn btn-sm btn-outline-success dropdown-toggle" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                                        <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                                        <div class="dropdown-menu">
                                                            <asp:LinkButton ID="lnkbtnExcel" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="lnkbtnExcel_Click"></asp:LinkButton>
                                                            <asp:LinkButton ID="linkbtnPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnPDF_Click"></asp:LinkButton>

                                                        </div>
                                                    </div>

                                                    <asp:Button ID="btn_VisibilityProject" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="btn_VisibilityProject_Click" />
                                                    <asp:Button ID="BtnReloadProject" runat="server" Text="Reload" CssClass="btn btn-sm btn-sm btn-outline-info" OnClick="BtnReloadProject_Click" />
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <!------PDF code--------->

                                                <asp:Image ID="Image1" runat="server" Style="display: none; border: 1px solid #ccc" />

                                                <asp:Label ID="lbladdCompany11" runat="server" Text="" CssClass="font-bold text-dark " Visible="false"></asp:Label>
                                                <asp:Label ID="lbladdress11" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                                <asp:Label ID="lblcompanyaddCity1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                                <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                                <asp:Label ID="lblcompanyaddState1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                                <asp:Label ID="lblcompanyaddCountry1" runat="server" Text="," Font-Size="12px" Visible="false"></asp:Label>
                                                <asp:Label ID="lblpincode" runat="server" Text="PIN:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                                <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                                <asp:Label ID="Label1" runat="server" Text="Phone:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                                <asp:Label ID="lblphoneNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                                <asp:Label ID="lblvat" runat="server" Text="VAT NO:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                                <asp:Label ID="lblVatNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                                <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                                <asp:Label ID="lblGSTNo1A" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                                <!------PDF code--------->

                                            </div>
                                        </div>

                                        <br />
                                        <br />

                                        <asp:GridView ID="GridProject" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover table-responsive text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridProject_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ProjectName" SortExpression="ProjectName" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblProjectName" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProjectName1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                        <asp:LinkButton ID="LinkbtnProjectName1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" CssClass="link-info" OnClick="LinkbtnProjectName1_Click"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Customer" SortExpression="Customer" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblClientName" runat="server" Text='<%# Bind("ClientName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSClientName1" runat="server" Text='<%# Bind("ClientName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="StartDate" SortExpression="Start_Date" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblStart_Date" runat="server" Text='<%# Bind("Start_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStart_Date1" runat="server" Text='<%# Bind("Start_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Deadline" SortExpression="Deadline" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblDeadline" runat="server" Text='<%# Bind("Deadline","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDeadline1" runat="server" Text='<%# Bind("Deadline","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" SortExpression="StatusProject" Visible="false" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("StatusProject") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblstatus1" runat="server" Text='<%#Bind("StatusProject") %>' Font-Bold="false" Visible="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Members" SortExpression="Member" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblTagsName" runat="server" Text="" TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:BulletedList ID="bulletlistMember" runat="server" BulletStyle="Circle" Font-Size="12px">
                                                        </asp:BulletedList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditProject" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditProject_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDeleteProjetct" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteProjetct_Click"><i class="ti ti-trash"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                    </EditItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div align="center" style="color: red">
                                                    <h6>No records found.</h6>
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="PaymentsDiv" runat="server" visible="false">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                <div class="card">
                                    <div class="card-body">
                                        <h5>View Payment Details</h5>
                                        <hr />
                                        <div class="row">
                                            <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6">
                                                <div class="bd-example">
                                                    <div class="btn-group">
                                                        <button class="btn btn-sm btn-outline-success dropdown-toggle" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                                        <asp:Button ID="Button3" runat="server" Style="display: none" />
                                                        <div class="dropdown-menu">
                                                            <asp:LinkButton ID="linkPaymentExcel" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="linkPaymentExcel_Click"></asp:LinkButton>
                                                            <asp:LinkButton ID="linkPaymentPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkPaymentPDF_Click"></asp:LinkButton>
                                                        </div>
                                                    </div>

                                                    <asp:Button ID="btnPaymentVisibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="btnPaymentVisibility_Click" />
                                                    <asp:Button ID="btnPaymentReload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="btnPaymentReload_Click" />
                                                </div>
                                            </div>
                                                 <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6"></div>
                                        </div>
                                        <br />
                                        <asp:GridView ID="GridPayments" runat="server" ScrollBars="Both" OnRowDataBound="GridPayments_RowDataBound" CssClass="table border table-bordered table-hover table-responsive text-nowrap align-content-center" AutoGenerateColumns="false" Width="100%" CellPadding="4"
                                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID">
                                            <Columns>
                                                <asp:TemplateField HeaderText="ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ID" SortExpression="Exp_id" HeaderStyle-Font-Size="12px" Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="PaymentMode" SortExpression="Payment_Mode" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblPaymentMode" runat="server" Text='<%# Bind("Payment_Mode") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPaymentMode1" runat="server" Text='<%# Bind("Payment_Mode") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Transaction_ID" SortExpression="Transaction_ID" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblTransaction_ID" runat="server" Text='<%# Bind("Transation_ID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTransaction_ID1" runat="server" Text='<%# Bind("Transation_ID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Customer" SortExpression="Customer" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblCustomer" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCustomer1" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Amount" SortExpression="Amount" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount_Recived") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("Amount_Recived") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date" SortExpression="Date" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Payment_date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDate1" runat="server" Text='<%# Bind("Payment_date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" SortExpression="Status" Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblStatus1" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnView" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnView_Click"><i class="ti ti-eye"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClick="btnDelete_Click"><i class="ti ti-trash"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                    </EditItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div align="center" style="color: red">
                                                    <h6>No records found.</h6>
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="ContractsDiv" runat="server" visible="false">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                <div class="row">
                                    <div class="card">
                                        <div class="card-body">
                                            <div id="divcontractbtn" runat="server">
                                                <div class="row">
                                                    <div class="Col-md-2 col-lg-2 col-sm-2 col-xs-2">
                                                        <asp:Button ID="btnNewContract" runat="server" Text="New Contract Customer" CssClass="btn btn-sm btn-primary" OnClick="btnNewContract_Click" />
                                                    </div>
                                                </div>
                                                <hr />
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <br />
                                <div class="row">
                                    <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <h5>View Contract Customer Details</h5>
                                                <hr />
                                                <div class="row">
                                                    <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                                                        <div class="bd-example">
                                                            <div class="btn-group">
                                                                <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                                                <asp:Button ID="Button1" runat="server" Style="display: none" />
                                                                <div class="dropdown-menu">
                                                                    <asp:LinkButton ID="linkbtnContacrExcel" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="linkbtnContacrExcel_Click"></asp:LinkButton>
                                                                    <asp:LinkButton ID="linkContractPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkContractPDF_Click"></asp:LinkButton>

                                                                </div>
                                                            </div>
                                                            <%-- <asp:Button ID="btn_Export" runat="server" Text="Export" CssClass="btn btn-sm btn-outline-success" OnClick="btn_Export_Click" />--%>
                                                            <asp:Button ID="btnVISIBLITYCONTRACT" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="btnVISIBLITYCONTRACT_Click" />
                                                            <asp:Button ID="btnCONTRACTREALOD" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="btnCONTRACTREALOD_Click" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-xs-12 col-lg-12 col-sm-12">
                                                        <asp:GridView ID="GridviewContract1" runat="server" ScrollBars="Both" CssClass="table border table-responsive table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4"
                                                            ClientIDMode="Static" EmptyDataText="No Records Found" OnRowDataBound="GridviewContract1_RowDataBound" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="id">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="id" HeaderStyle-Font-Size="12px" Visible="false">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblContracttypeID" runat="server" Text='<%# Bind("id") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblContracttypeID1" runat="server" Text='<%# Bind("id") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Subject" SortExpression="subject" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtContractsubject" runat="server" Text='<%# Bind("subject") %>' Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcontractsubject1" runat="server" Text='<%# Bind("subject") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ContractValue" SortExpression="Contract_value" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtContract_value" runat="server" Text='<%# Bind("contract_value") %>' Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblContract_value1" runat="server" Text='<%# Bind("contract_value") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="StartDate" SortExpression="datestart" HeaderStyle-Font-Size="12px" HeaderStyle-Width="100px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lbldatestart" runat="server" Text='<%#Bind("datestart","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbldatestart1" runat="server" Text='<%#Bind("datestart","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="EndDate" SortExpression="dateend" HeaderStyle-Font-Size="12px" HeaderStyle-Width="120px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lbldateend" runat="server" Text='<%#Bind("dateend","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbldateend1" runat="server" Text='<%#Bind("dateend","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Customer" SortExpression="Cust_Name" HeaderStyle-Font-Size="12px" HeaderStyle-Width="200px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCustomer" runat="server" Text='<%#Bind("Cust_Name") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCustomer1" runat="server" Text='<%#Bind("Cust_Name") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ContractType" SortExpression="Contractype" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblcontract_type" runat="server" Text='<%#Bind("Contractype") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcontract_type1" runat="server" Text='<%#Bind("Contractype") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Status" SortExpression="Status" Visible="false">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblstatus1" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkEditContract" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="LinkEditContract_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDeleteContract" runat="server" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteContract_Click"><i class="ti ti-trash"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <div align="center" style="color: red">
                                                                    <h6>No records found.</h6>
                                                                </div>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

                <div id="TicketsDiv" runat="server" visible="false">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-lg-12 col-xl-12">
                                <div id="addNewTickiet" runat="server">
                                    <asp:Button ID="btnNewticket" runat="server" Text="New Ticket" CssClass="btn btn-sm btn-primary" OnClick="btnNewticket_Click" />
                                    <hr />
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="card">
                                <div class="card-body">
                                    <h5>View Ticket Details</h5>
                                    <hr />
                                    <div class="bd-example">
                                        <div class="btn-group">
                                            <button class="btn btn-sm btn-outline-success dropdown-toggle" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                            <asp:Button ID="Button2" runat="server" Style="display: none" />
                                            <div class="dropdown-menu">
                                                <asp:Button ID="LinkbtnTicketExcel" runat="server" Text="Excel" OnClick="LinkbtnTicketExcel_Click" CssClass="dropdown-item" />
                                                <asp:LinkButton ID="LinkbtnTicketPDF" runat="server" Text="PDF" OnClick="LinkbtnTicketPDF_Click" CssClass="dropdown-item"></asp:LinkButton>

                                            </div>
                                        </div>
                                        <asp:Button ID="btnVisibilityTickit" runat="server" Text="Visibility" OnClick="btnVisibilityTickit_Click" CssClass="btn btn-sm btn-outline-info" />
                                        <asp:Button ID="btnTickitReload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="btnTickitReload_Click" />
                                    </div>
                                    <br />


                                    <br />
                                    <asp:GridView ID="Gridticket" runat="server" ScrollBars="Both" CssClass="table border table-responsive table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Width="100%" OnRowDataBound="Gridticket_RowDataBound"
                                        ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnSelectedIndexChanged="Gridticket_SelectedIndexChanged">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Subject" SortExpression="Subject" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblSubject" runat="server" Text='<%# Bind("Subject") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubject1" runat="server" Text='<%# Bind("Subject") %>' Visible="false" TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    <asp:LinkButton ID="btnSubject1" runat="server" Text='<%# Bind("Subject") %>' CssClass="btn btn-sm text-info" OnClick="btnSubject1_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department" SortExpression="Department" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblDepartment" runat="server" Text='<%# Bind("Department") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDepartment1" runat="server" Text='<%# Bind("Department") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Services" SortExpression="Services" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblServices" runat="server" Text='<%# Bind("Services") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblServices1" runat="server" Text='<%# Bind("Services") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Priority" SortExpression="Priority" Visible="false" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblPriority" runat="server" Text='<%# Bind("Priority") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPriority1" runat="server" Text='<%# Bind("Priority") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="AssignTo" SortExpression="AssignTo" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lbAssignTo" runat="server" Text='<%# Bind("AssignTo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAssignTo1" runat="server" Text='<%# Bind("AssignTo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="RaiseBy" SortExpression="RaiseBy" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblRaiseBy" runat="server" Text='<%# Bind("Raise_By") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRaiseBy1" runat="server" Text='<%# Bind("Raise_By") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" SortExpression="StatusName" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblStatusNamee" runat="server" Text='<%# Bind("StatusName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatusNamee1" runat="server" Text='<%# Bind("StatusName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status1" SortExpression="StatusName" HeaderStyle-Font-Size="12px" Visible="false">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus1" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEditticket" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditticket_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDeleteticket" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteticket_Click"><i class="ti ti-trash"></i></asp:LinkButton>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                </EditItemTemplate>
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div align="center" style="color: red">
                                                <h6>No records found.</h6>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>

                                </div>
                            </div>
                        </div>
                    </div>

                </div>

                <div id="RemindersDiv" runat="server" visible="false">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-ld-12">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="font-weight-medium mb-0">Reminder</h5>
                                        <hr />
                                        <div class="row">
                                            <asp:Label ID="lblContactID" runat="server" Text="" Visible="false"></asp:Label>
                                            <asp:Label ID="lblFitstName" runat="server" Text="" Visible="false"></asp:Label>
                                            <asp:Label ID="lblContactPosition" runat="server" Text="" Visible="false"></asp:Label>
                                            <asp:Label ID="lblContactPhone" runat="server" Text="" Visible="false"></asp:Label>
                                            <asp:Label ID="lblContactEmail" runat="server" Text="" Visible="false"></asp:Label>

                                            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                                <div id="remainderFormtable">
                                                    <div class="mb-2">
                                                        <div id="divbtnsetRemider" runat="server">
                                                            <button id="btn_expenseRemainder" class="btn btn-sm btn-outline-info btn-lg" type="button" onclick="toggleForm()">
                                                                <i class="far fa-bell"></i>&nbsp;&nbsp;Set Reminder
                                                            </button>
                                                        </div>
                                                    </div>
                                                    <br />

                                                    <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                                        <div id="addexpenseRemainder" class="row" style="display: none;">

                                                            <asp:Label ID="lblRemainderForm" runat="server" Text="" Font-Bold="false" Visible="false" Font-Size="12px"></asp:Label>
                                                            <div class="mb-2">
                                                                <asp:Label ID="lblDateNotified" runat="server" Text="Date to be notified" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                                <asp:TextBox ID="txtDateNotified" type="date" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="Enter Date"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredNotifiedDate" runat="server" ErrorMessage="Enter Notified Date" ControlToValidate="txtDateNotified" ForeColor="Red" Font-Bold="false" ValidationGroup="Remainder" Font-Size="12px"></asp:RequiredFieldValidator>
                                                            </div>

                                                            <div class="mb-2">
                                                                <asp:Label ID="lblSetReminder" runat="server" Text="Set reminder to" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                                <asp:DropDownList ID="ddlSetReminderStaff" runat="server" CssClass="form-control form-select" Placeholder="Nothing Selected">
                                                                </asp:DropDownList>
                                                            </div>

                                                            <div class="mb-2">
                                                                <asp:Label ID="Label2" runat="server" Text="Description" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp; <%--<span style="color: #FF0000">*</span>--%>
                                                                <asp:TextBox ID="txtDescriptionReminder" runat="server" placeholder="Enter Description" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldNote" runat="server" ErrorMessage="Enter Description" ControlToValidate="txtDescription" ForeColor="Red" Font-Bold="false" ValidationGroup="Purchase"  Font-Size="12px"></asp:RequiredFieldValidator>--%>
                                                                <br />
                                                                <asp:CheckBox ID="Chkboxformail" runat="server" Checked="false" Text="Send also an email for this remainder" Font-Bold="true" Font-Size="12px" />

                                                            </div>

                                                            <div class="mb-2">
                                                                <asp:Button ID="btnSaveRemainder" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="Remainder" OnClick="btnSaveRemainder_Click" />
                                                                &nbsp;&nbsp;
                                                    <asp:Button ID="btnClearRemainder" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" OnClick="btnClearRemainder_Click" ValidationGroup="Remainder1" />

                                                                <asp:Button ID="btnUpdateReminder" runat="server" Text="Update" CssClass="btn btn-sm btn-success" ValidationGroup="updateRemainder" OnClick="btnUpdateReminder_Click" Visible="false" />
                                                                &nbsp;&nbsp;
                                                    <asp:Button ID="btnCancelReminder" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" ValidationGroup="cacelRemainder" OnClick="btnCancelReminder_Click" Visible="false" />
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <%-- <hr />--%>
                                                    <div id="Timesheet" runat="server" visible="true">
                                                        <asp:Label ID="lblRemainderInfoWGV" runat="server" Text="" Visible="false"></asp:Label>
                                                        <br />
                                                        <h5 class="font-weight-medium mb-0">View Reminder Details</h5>
                                                        <hr />
                                                        <asp:Button ID="btnexport" runat="server" Text="Export" CssClass="btn btn-sm btn-outline-success" OnClick="btnexport_Click" />
                                                        <asp:Button ID="btnVisibilityRemainder" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="btnVisibilityRemainder_Click" />

                                                        <asp:Button ID="btnReload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="btnReload_Click" />
                                                        <br />
                                                        <br />
                                                        <asp:GridView ID="GridviewRemainder1" runat="server" CssClass="table border table-bordered table-responsive table-hover text-nowrap align-content-center" ScrollBars="Both" OnRowDataBound="GridviewRemainder1_RowDataBound" AutoGenerateColumns="false" CellPadding="4"
                                                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="R_ID">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumTask" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Status" SortExpression="Order" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="ID" SortExpression="R_ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblR_ID" runat="server" Text='<%# Bind("R_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblR_ID1" runat="server" Text='<%# Bind("R_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Font-Size="12px" HeaderStyle-Width="180px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblDescription" runat="server" Text='<%#Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescription1" runat="server" Text='<%#Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="NotifyDate" SortExpression="NotifyDate" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblNotifyDate" runat="server" Text='<%#Bind("NotifyDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNotifyDate1" runat="server" Text='<%#Bind("NotifyDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Remainder" SortExpression="SetToReminder" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblSetToReminder" runat="server" Text='<%#Bind("SetToReminder") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSetToReminder1" runat="server" Text='<%#Bind("SetToReminder") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkEditRemainder" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="LinkEditRemainder_Click" TabIndex="6" Font-Bold="false" Font-Size="12px"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDeleteRemainder" runat="server" CssClass="btn btn-sm btn-outline-danger" OnClick="btnDeleteRemainder_Click" TabIndex="6" Font-Bold="false" Font-Size="12px"><i class="ti ti-trash"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <div align="center" style="color: red">
                                                                    <h6>No records found.</h6>
                                                                </div>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>

                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

                <div id="FilesDiv" runat="server" visible="false">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-ld-12">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="font-weight-medium mb-0">Files</h5>
                                        <hr />
                                        <div class="row">
                                            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                                <div class="mb-2">
                                                    <asp:Label ID="lbldocumenttype" runat="server" Text="Document Type" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                    <asp:TextBox ID="txtdocumenttype" CssClass="form-control" runat="server" Placeholder="Enter Document Type"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtdocumenttype" ErrorMessage="Enter Document Type" ForeColor="Red" ValidationGroup="Tender1" Font-Size="12px"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblAttachment" runat="server" Text="Attachment" CssClass="form-label"></asp:Label>
                                                    <asp:FileUpload ID="FileUpload" runat="server" Text="" CssClass="form-control mdi-file-import" Style="width: 140%" />
                                                </div>

                                                <div class="col-md-1 col-lg-1 col-sm-1 col-xs-1">
                                                </div>

                                                <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2">
                                                    <asp:Button ID="Btn_Upload" runat="server" Text="Upload" CssClass="btn btn-primary" ValidationGroup="Tender1" OnClick="Btn_Upload_Click" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 col-lg-12">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <asp:GridView ID="GridFile" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover table-responsive text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                            ClientIDMode="Static" ShowHeader="false" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField Visible="false">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblID" runat="server" Text="FileName" CssClass=" font-bold" Visible="false"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" CssClass="font-12" Visible="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblTenderFileName" runat="server" Text="FileName" CssClass="form-label"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFileName1" runat="server" Text='<%# Bind("FileName") %>' Font-Bold="false" CssClass="font-12"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblExtension" runat="server" Text="Extension" CssClass="form-label"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExtension1" runat="server" Text='<%# Bind("FileExtension") %>' Font-Bold="false" CssClass="font-12"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="DocumentType" runat="server" Text="Document_Type" CssClass="form-label"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDocument_Type" runat="server" Text='<%# Bind("DocumentType") %>' Font-Bold="false" CssClass="font-12"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDeleteFile" runat="server" ForeColor="Red" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteFile_Click" Visible="false"><i class="ti ti-trash"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="NotesDiv" runat="server" visible="false">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-ld-12">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="font-weight-medium mb-0">Note</h5>
                                        <hr />
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 col-ld-12">
                                                <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>

                                                <br />
                                                <asp:Button ID="btnNotesSave" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" OnClick="btnNotesSave_Click" />&nbsp;&nbsp;
                                                   <asp:Button ID="btnNoteClear" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" OnClick="btnNoteClear_Click" />

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>

        </div>
        <%-- Module Popup --%>

        <style>
            .Background {
                background-color: Black;
                /*  filter: alpha(opacity=90);*/
                opacity: 0.8;
            }

            .Popup {
                background-color: #FFFFFF;
                border-width: 3px;
                border-style: solid;
                border-color: black;
                padding-top: 10px;
                padding-left: 10px;
                width: 1000px;
                height: 950px;
            }

            .lbl {
                font-size: 16px;
                font-style: italic;
                font-weight: bold;
            }
        </style>
        <script>
            function toggleForm() {
                var AddReminder = document.getElementById('addexpenseRemainder');

                if (AddReminder.style.display === 'none') {
                    AddReminder.style.display = 'block';
                } else {
                    AddReminder.style.display = 'none';
                }
            }
        </script>
</asp:Content>
