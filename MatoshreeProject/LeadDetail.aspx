<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="LeadDetail.aspx.cs" Inherits="MatoshreeProject.LeadDetail" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="text/css" href="https://cdn.datatabls.net/responsive/1.0.7/js/dataTabls.responsive.min.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatabls.net/responsive/1.10.9/js/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatabls.net/responsive/1.0.7/js/dataTabls.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatabls.net/1.10.9/js/dataTabls.bootstrap.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>



    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">


        $(document).ready(function () {

            $(document).ready(function () {
                var GridPropsal = $("#GridPropsal").prepend($("<thead></thead>").append($("#GridPropsal").find("tr:first"))).DataTable(
                    {
                        "responsive": true,
                        "scrollY": "300px",
                        "scrollX": "80%",
                        "scrollCollapse": true,
                        "searching": true,
                        "paging": true,
                    });

            });
            var GridTask1 = $("#GridTask1").prepend($("<thead></thead>").append($("#GridTask1").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridLeadReminder = $("#GridLeadReminder").prepend($("<thead></thead>").append($("#GridLeadReminder").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });
            var GridViewAct1 = $("#GridViewAct1").prepend($("<thead></thead>").append($("#GridViewAct1").find("tr:first"))).DataTable(
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
                <h5 class="font-weight-medium mb-0">Lead Details</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="ViewLead.aspx">Lead
                            </a>
                        </li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="LeadDetail.aspx">Lead Detail </li>
                    </ol>
                </nav>
                <%-- BreadCrumbs --%>
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
            <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-ld-6 col-xs-6">
                                <asp:Label ID="lblMainname" runat="server" Text="" CssClass="form-label"></asp:Label>
                            </div>
                            <div class="col-md-6 col-sm-6 col-ld-6 col-xs-6 text-end">
                                <asp:LinkButton ID="Linkclose" runat="server" CausesValidation="false" CssClass="btn btn-sm btn-close">
                                    <i class="ti ti-close"></i>
                                </asp:LinkButton>
                            </div>

                        </div>
                        <hr />

                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                <ul class="nav nav-tabs" role="tablist">

                                    <li class="nav-item">
                                        <h6><a class="nav-link active" data-bs-toggle="tab" href="#Profile" role="tab"><span class="hidden-sm-up"></span>
                                            <span><i class="ti ti-users fs-4"></i>Profile</span></a></h6>
                                        <asp:Label ID="Label6" runat="server" Text="" Visible="false"></asp:Label>
                                    </li>
                                    <li class="nav-item">
                                        <h6><a class="nav-link" data-bs-toggle="tab" href="#Proposals" role="tab"><span class="hidden-sm-up"></span>
                                            <span>
                                                <iconify-icon icon="cib:hackhands"></iconify-icon>
                                                Proposal</span></a></h6>
                                    </li>
                                    <li class="nav-item">
                                        <h6><a class="nav-link" data-bs-toggle="tab" href="#Tasks" role="tab"><span class="hidden-sm-up"></span>
                                            <span>
                                                <iconify-icon icon="solar:archive-minimalistic-linear" class="aside-icon"></iconify-icon>
                                                Tasks</span></a></h6>
                                    </li>
                                    <li class="nav-item">
                                        <h6><a class="nav-link" data-bs-toggle="tab" href="#Attachments" role="tab"><span class="hidden-sm-up"></span>
                                            <span>
                                                <iconify-icon icon="et:attachments"></iconify-icon>
                                                Attachments</span></a></h6>
                                    </li>
                                    <li class="nav-item">
                                        <h6><a class="nav-link" data-bs-toggle="tab" href="#Reminder" role="tab"><span class="hidden-sm-up"></span>
                                            <span>
                                                <iconify-icon icon="arcticons:hourlyreminder"></iconify-icon>
                                                Reminders</span></a></h6>
                                    </li>
                                    <li class="nav-item">
                                        <h6><a class="nav-link" data-bs-toggle="tab" href="#Notes" role="tab"><span class="hidden-sm-up"></span>
                                            <span>
                                                <iconify-icon icon="iconoir:notes" class="aside-icon"></iconify-icon>
                                                Note</span></a></h6>
                                    </li>
                                    <li class="nav-item">
                                        <h6><a class="nav-link" data-bs-toggle="tab" href="#ActivityLog" role="tab"><span class="hidden-sm-up"></span>
                                            <span><i class="ti ti-address-book fs-4"></i>Activity Log</span></a></h6>
                                    </li>
                                </ul>

                            </div>
                        </div>
                        <hr />
                        <div class="tab-content tabcontent-border">

                            <div class="tab-pane active" id="Profile" role="tabpanel">

                                <div class="p-20">
                                    <div class="row">
                                        <div class="col-md-12  col-sm-12 col-ld-12 col-xs-12">
                                            <div class="d-flex justify-content-end align-items-center">
                                                <asp:LinkButton ID="LinkbtnConvToCust" runat="server" ControlToValidate="Linkbtnlist1" CssClass="btn btn-sm btn-success btnmodalPopup" data-bs-toggle="modal"
                                                    data-bs-target="#convertToCustID">  <i class="ti ti-user"></i>Convert to Customer
                                                </asp:LinkButton>

                                                <div class="modal fade" id="convertToCustID" data-bs-backdrop="static"
                                                    data-bs-keyboard="false" tabindex="-1" aria-labelledby="scroll-long-inner-modal"
                                                    aria-hidden="true">
                                                    <div class="modal-dialog modal-dialog-scrollable   modal-lg">
                                                        <div class="modal-content">
                                                            <div class="modal-header d-flex align-items-center">
                                                                <h4 class="modal-title" id="myLargeModalLabelCust"></h4>
                                                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                                            </div>
                                                            <div class="modal-body">

                                                                <h5 style="color: blue; align-items: center">Convert To Customer</h5>
                                                                <hr />

                                                                <div id="divCust" runat="server" visible="true">


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
                                                                                            <asp:Label ID="Label9" runat="server" Text="Company Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                                                            <asp:TextBox ID="txtCompanyCust" runat="server" CssClass="form-control" placeholder="Enter Company Name"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtCompanyCust" ErrorMessage="Enter Company Name" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="col-md-6 col-sm-6 col-lg-6">
                                                                                        <div class="mb-2">
                                                                                            <asp:Label ID="Label10" for="Phone" runat="server" Text="Phone" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                                                            <asp:TextBox ID="txtPhoneCust" runat="server" name="phone" CssClass="form-control" placeholder="Enter Phone Number" MaxLength="10" TextMode="Phone"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="rfv_Phone" runat="server" Display="Dynamic" ControlToValidate="txtPhoneCust" ErrorMessage="Enter 10 digit Phone Number" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="Regulexphone" runat="server" ControlToValidate="txtPhoneCust" ErrorMessage="Phone Number Invalid." ForeColor="Red" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RegularExpressionValidator>
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
                                                                                            <asp:TextBox ID="txtEmailCust" runat="server" name="email" CssClass="form-control" placeholder="Enter Email Address"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="rvfEmail" runat="server" Display="Dynamic" ControlToValidate="txtEmailCust" ErrorMessage="Enter Email Address" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="Regulexemail" runat="server" ControlToValidate="txtEmailCust" ErrorMessage="Email Address Invalid." ForeColor="Red" ValidationGroup="SaveValidate" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" Font-Size="12px"></asp:RegularExpressionValidator>

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
                                                                                        <asp:Label ID="Label13" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                                                        <asp:TextBox ID="txtcDescription" runat="server" placeholder="Description" class="form-control" TextMode="MultiLine" Height="150px"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-6 col-sm-6 col-lg-6">
                                                                                        <div class="mb-2">
                                                                                            <asp:Label ID="Label14" runat="server"  CssClass="form-label" Text="Name"></asp:Label>
                                                                                                <asp:Label ID="lblcontName" runat="server" Text=""></asp:Label>
                                                                                            </div>
                                                                                    </div>

                                                                                    <div class="col-md-6 col-sm-6 col-lg-6">
                                                                                        <div class="mb-2">
                                                                                            <asp:Label ID="Label15" runat="server" CssClass="form-label" Text="Position:"></asp:Label>
    
                                                                                            <asp:Label ID="lblcontPosition" runat="server" Text=""></asp:Label>
                                                                                        </div>

                                                                                    </div>

                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                        <div class="tab-pane p-20" id="profile" role="tabpanel">
                                                                            <div class="p-20">
                                                                                <div class="row">
                                                                                    <div class="col-md-6 col-sm-6 col-lg-6">
                                                                                        <%--  <asp:UpdatePanel ID="UpdatePanelddlState" runat="server">
                                                                                                    <ContentTemplate>--%>
                                                                                        <h6>Billing Address&nbsp;&nbsp;<asp:Button ID="btnCopyCustomerInfo" runat="server" Text="Same as Customer" CssClass="btn btn-outline-info btn-sm" OnClick="btnCopyCustomerInfo_Click" ValidationGroup="Copy" /></h6>
                                                                                        <hr />
                                                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                                                            <div class="mb-1">
                                                                                                <asp:Label ID="lblBillingCountry" runat="server" Text="Country" CssClass="form-label"></asp:Label>
                                                                                                <asp:DropDownList ID="ddlCountryBilling" runat="server" CssClass="form-select" name="CountryBilling">
                                                                                                    <asp:ListItem Value="0">Select Country</asp:ListItem>
                                                                                                    <asp:ListItem Value="India" Selected="True" Text="India"></asp:ListItem>
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
                                                                                        <%--     </ContentTemplate>
                                                                                                    <Triggers>
                                                                                                        <asp:AsyncPostBackTrigger ControlID="ddlBilingState" EventName="SelectedIndexChanged" />
                                                                                                        <asp:AsyncPostBackTrigger ControlID="ddlBillingdistrict" EventName="SelectedIndexChanged" />

                                                                                                    </Triggers>
                                                                                                </asp:UpdatePanel>--%>
                                                                                    </div>
                                                                                    <div class="col-md-6 col-sm-6 col-lg-6">
                                                                                        <%-- <asp:UpdatePanel ID="UpdatePanelbiing" runat="server">
                                                                                                    <ContentTemplate>--%>
                                                                                        <h6>Shipping Address&nbsp;&nbsp;<asp:Button ID="btnCopyBillingInfo" runat="server" Text="Copy Billing Address" CssClass="btn btn-outline-info btn-sm" OnClick="btnCopyBillingInfo_Click" ValidationGroup="Copyas" /></h6>
                                                                                        <hr />
                                                                                        <div class="col-md-12 col-sm-12 col-lg-12">

                                                                                            <div class="mb-2">
                                                                                                <asp:Label ID="lblCountryShipping" runat="server" Text="Country" CssClass="form-label"></asp:Label>
                                                                                                <asp:DropDownList ID="ddlCountryShipping" name="CountryShipping" runat="server" CssClass="form-control form-select">
                                                                                                    <asp:ListItem Value="0">Select Country</asp:ListItem>
                                                                                                    <asp:ListItem Value="India" Selected="True" Text="India"></asp:ListItem>
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
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddldistrictShipping" ForeColor="Red" Font-Bold="false" InitialValue="0" Display="Dynamic" ValidationGroup="SaveValidate1" ErrorMessage="Select District" Font-Size="12px"></asp:RequiredFieldValidator>
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

                                                                                        <%--    </ContentTemplate>
                                                                                                    <Triggers>
                                                                                                        <asp:AsyncPostBackTrigger ControlID="ddlstateShipping1" EventName="SelectedIndexChanged" />
                                                                                                        <asp:AsyncPostBackTrigger ControlID="ddlcityShipping1" EventName="SelectedIndexChanged" />

                                                                                                    </Triggers>
                                                                                                </asp:UpdatePanel>--%>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                    <div class="mb-2">
                                                                        <asp:Button ID="btnSaveCovertToCust" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="SaveValidate" OnClick="btnSaveCovertToCust_Click" />
                                                                        <asp:Button ID="btnClearCovertToCust" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="Validateclear" OnClick="btnClearCovertToCust_Click" />
                                                                    </div>

                                                                </div>

                                                            </div>
                                                            <br />
                                                            <div class="modal-footer">

                                                                <%--<button type="btnClose" class="btn btn-sm btn-danger" data-bs-dismiss="modal" Visible="false" >Close</button>--%>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                &nbsp
                                              <asp:LinkButton ID="btnEditLead" runat="server" CausesValidation="false" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditLead_Click">
                                                  <i class="ti ti-edit"></i>
                                              </asp:LinkButton>
                                                &nbsp
                                              <asp:LinkButton ID="lnkBtnPDF" runat="server" CausesValidation="false" CssClass="btn btn-sm btn-outline-danger" OnClick="lnkBtnPDF_Click">
                                                  <i class="ti ti-printer"></i>
                                              </asp:LinkButton>
                                                &nbsp
                                              <div class="btn-group">
                                                  <button class="btn btn-sm btn-outline-info dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">More</button>
                                                  <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                                  <div class="dropdown-menu">
                                                      <asp:LinkButton ID="lnkbtnLost" Text="Mark as Lost" runat="server" OnClick="lnkbtnLost_Click" CssClass="dropdown-item text-warning"></asp:LinkButton>
                                                      <asp:LinkButton ID="linkbtnJunk" runat="server" Text="Mark as Junk" OnClick="linkbtnJunk_Click" CssClass="dropdown-item text-info"></asp:LinkButton>
                                                      <asp:LinkButton ID="linkbtnDelete" runat="server" Text="Delete Lead" OnClick="linkbtnDelete_Click" CssClass="dropdown-item text-danger "></asp:LinkButton>
                                                  </div>
                                              </div>
                                            </div>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-md-1  col-sm-1 col-ld-1 col-xs-1">
                                        </div>
                                        <div class="col-md-5  col-sm-5 col-ld-5 col-xs-5">

                                            <div class="row">
                                                <div class="col-md-12  col-sm-12 col-ld-12 col-xs-12 " style="background-color: lightgray">
                                                    <asp:Label ID="Label1" runat="server" CssClass="form-label" Text="Lead Information"></asp:Label>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblLeadIdd" runat="server" Text="" CssClass="form-label" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblstatusidd" runat="server" Text="" CssClass="form-label" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblstatusnamee" runat="server" Text="" CssClass="form-label" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblName1" runat="server" Text="Name:" CssClass="form-label"></asp:Label>
                                                </div>
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblNameLead" runat="server" Text=""></asp:Label>
                                                    <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblPosition" runat="server" CssClass="form-label" Text="Position:"></asp:Label>
                                                </div>
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblPositionop" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblwebsite" runat="server" CssClass="form-label" Text="Website:"></asp:Label>
                                                    <br />
                                                </div>
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblWebsiteop" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblemailadd" runat="server" CssClass="form-label" Text="Email Address:"></asp:Label>
                                                    <br />
                                                </div>
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblEmailOP" runat="server" CssClass="text-info" Text=""></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblPhone" runat="server" CssClass="form-label" Text="Phone:"></asp:Label>
                                                </div>
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblPhoneop" runat="server" Text="" CssClass="text-info"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblLeadvalue" runat="server" CssClass="form-label" Text="Lead Value:"></asp:Label>
                                                    <br />
                                                </div>
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblLeadvalueop" runat="server" Text=""></asp:Label>
                                                    <br />
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblCompany" runat="server" CssClass="form-label" Text="Company:"></asp:Label>
                                                    <br />
                                                </div>
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblCompanyop" runat="server" Text=""></asp:Label>
                                                    <br />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblAddress" runat="server" CssClass="form-label" Text="Address:"></asp:Label>
                                                    <br />
                                                </div>
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblAddressop" runat="server" Text=""></asp:Label>
                                                    <br />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblCity" runat="server" Text="City:" CssClass="form-label"></asp:Label>
                                                    <br />
                                                </div>
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblCityop" runat="server" Text=""></asp:Label>
                                                    <br />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lbldistrict" runat="server" Text="District:" CssClass="form-label"></asp:Label>
                                                    <br />
                                                </div>
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lbldistrict1" runat="server" Text=""></asp:Label>
                                                    <br />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblState" runat="server" Text="State:" CssClass="form-label"></asp:Label>
                                                    <br />
                                                </div>
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblStateop" runat="server" Text=""></asp:Label>
                                                    <br />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblCountry" runat="server" Text="Country:" CssClass="form-label"></asp:Label>
                                                    <br />
                                                </div>
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblCountryop" runat="server" Text=""></asp:Label>
                                                    <br />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblZipcode" runat="server" Text="Zip Code:" CssClass="form-label"></asp:Label>
                                                    <br />
                                                </div>
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblZipcodeop" runat="server" Text=""></asp:Label>
                                                </div>

                                            </div>

                                            <div class="row">
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblDescription" runat="server" CssClass="form-label" Text="Description"></asp:Label>
                                                </div>
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblDescriptionop" runat="server" Text=""></asp:Label>
                                                </div>

                                            </div>

                                            <br />

                                        </div>
                                        <br />
                                        <div class="col-md-1  col-sm-1 col-ld-1 col-xs-1">
                                        </div>
                                        <div class="col-md-4  col-sm-4 col-ld-4 col-xs-4">
                                            <div class="row">
                                                <div class="col-md-12  col-sm-12 col-ld-12 col-xs-12 " style="background-color: lightgrey">
                                                    <asp:Label ID="lblGeneral" runat="server" CssClass="form-label" Text="General Information"></asp:Label>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblStatus" runat="server" CssClass="form-label" Text="Status:"></asp:Label>
                                                    <br />
                                                </div>
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:DropDownList ID="ddlStatus" runat="server" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="true" CssClass="form-select form-control">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lbSourcel" runat="server" CssClass="form-label" Text="Source:"></asp:Label>
                                                    <br />
                                                </div>
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblSourceop" runat="server" Text=""></asp:Label>
                                                    <br />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblLanguage" runat="server" CssClass="form-label" Text="Default Language:"></asp:Label>
                                                    <br />
                                                </div>
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblLanguageop" runat="server" Text=""></asp:Label>
                                                    <br />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblAssigned" runat="server" CssClass="form-label" Text="Assigned:"></asp:Label>
                                                    <br />
                                                </div>
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblAssignedop" runat="server" Text=""></asp:Label>
                                                    <br />
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblPublic" runat="server" CssClass="form-label" Text="Public:"></asp:Label>
                                                    <br />
                                                </div>
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <asp:Label ID="lblPublicop" runat="server" Text="No"></asp:Label>
                                                    <asp:CheckBox ID="chkPublic" runat="server" Text="Public" Visible="false" />
                                                    &nbsp;&nbsp;
                                                      <asp:CheckBox ID="chkContracted" runat="server" Text="Contracted Today" Visible="false" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-1  col-sm-1 col-ld-1 col-xs-1">
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-md-1  col-sm-1 col-ld-1 col-xs-1">
                                        </div>
                                        <div class="col-md-10  col-sm-10 col-ld-10 col-xs-10" style="background-color: lightgray">

                                            <asp:Label ID="Label2" runat="server" CssClass="form-label" Text="Latest Activity"></asp:Label>
                                            <br />

                                        </div>
                                        <div class="col-md-1  col-sm-1 col-ld-1 col-xs-1">
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-1  col-sm-1 col-ld-1 col-xs-1">
                                        </div>
                                        <div class="col-md-10  col-sm-10 col-ld-10 col-xs-10">
                                            <asp:LinkButton ID="LinkButton2" runat="server" ControlToValidate="Linkbtnlist1" CssClass="btn btn-sm">
                                                <i class="ti ti-user"></i>
                                            </asp:LinkButton>
                                            <asp:Label ID="lblNameFinal3" runat="server" Text="" CssClass="form-label"></asp:Label>
                                            <asp:Label ID="lblNameFinal" runat="server" Text="-"></asp:Label>
                                            <asp:Label ID="lblnamecontlead" runat="server" Text=""></asp:Label>
                                            <asp:Label ID="lblcontlead" runat="server" Text="contacted this lead on"></asp:Label>
                                            <asp:Label ID="lblcontactDate11" type="DateTime-Local"  runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-md-1  col-sm-1 col-ld-1 col-xs-1">
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="tab-pane " id="Proposals" role="tabpanel">

                                <div class="p-20">
                                    <div class="row">
                                        <div class="col-md-12  col-sm-12 col-ld-12 col-xs-12">
                                            <asp:LinkButton ID="btnNewProposal" runat="server" ControlToValidate="LnkBtnproposal" CssClass="btn btn-sm btn-info" OnClick="btnNewProposal_Click">
                                                New Proposal 
                                            </asp:LinkButton>
                                            <br />
                                            <br />
                                            <%--gridview--%>
                                            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">

                                                <h5 class="font-weight-medium mt-3 mb-3">View Proposal Details</h5>
                                                <hr />

                                                <div class="row">
                                                    <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                                                        <div class="bd-example">
                                                            <div class="btn-group">
                                                                <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                                                <asp:Button ID="Button3" runat="server" Style="display: none" />
                                                                <div class="dropdown-menu">
                                                                    <asp:LinkButton ID="lnkbtnProposalExcel" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="lnkbtnProposalExcel_Click"></asp:LinkButton>
                                                                    <asp:LinkButton ID="linkbtnProposalPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnProposalPDF_Click"></asp:LinkButton>

                                                                </div>
                                                            </div>
                                                            <asp:Button ID="BTN_VisibilityProposal" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="BTN_VisibilityProposal_Click" />

                                                            <asp:Button ID="Btn_ReloadProposal" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="Btn_ReloadProposal_Click" />


                                                        </div>
                                                    </div>

                                                </div>

                                                <br />
                                                <br />

                                                <asp:GridView ID="GridPropsal" runat="server" ScrollBars="Both" CssClass="table border table-hover table-bordered text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%" OnRowDataBound="GridPropsal_RowDataBound"
                                                    ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ID1" SortExpression="ID1" HeaderStyle-Font-Size="14px" Visible="false">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Visible="false" Font-Size="14px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="14px" Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Proposal" SortExpression="Proposal" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblProposal" runat="server" Text='<%# Bind("ProposalNO") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProposalNo1" runat="server" Text='<%# Bind("ProposalNO") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Subject" SortExpression="Subject" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblSubject" runat="server" Text='<%# Bind("Subject") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSubject1" runat="server" Text='<%# Bind("Subject") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="To" SortExpression="To" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblTo" runat="server" Text='<%# Bind("To") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTo1" runat="server" Text='<%# Bind("To") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total" SortExpression="Total" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("GrandTotal") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotal1" runat="server" Text='<%# Bind("GrandTotal") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date" SortExpression="Date" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblDate" runat="server" Text='<%# Bind("ProDate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDate1" runat="server" Text='<%# Bind("ProDate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="OpenTill" SortExpression="Open_Till" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblOpenTill1" runat="server" Text='<%# Bind("ProOpenTillDate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblOpenTill" runat="server" Text='<%# Bind("ProOpenTillDate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Project" SortExpression="Project" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblProject" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProject1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="RealetedTo" SortExpression="RealetedTo" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblRealetedTo" runat="server" Text='<%# Bind("RelatedTo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRealetedTo1" runat="server" Text='<%# Bind("RelatedTo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CreateDate" SortExpression="Create_Date" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblCreateDate" runat="server" Text='<%# Bind("CreateDate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCreateDate1" runat="server" Text='<%# Bind("CreateDate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status" SortExpression="Status" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblStatus1" runat="server" Text=""></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("StatusName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnEditProposal" runat="server" CausesValidation="false" OnClick="btnEditProposal_Click" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"  ></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnDeleteProposal" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteProposal_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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

                            <div class="tab-pane " id="Tasks" role="tabpanel">

                                <%--  <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updatePanel1">
                                    <ContentTemplate>--%>
                                <div class="row">
                                    <div class="col-md-12  col-sm-12 col-ld-12 col-xs-12">
                                        <asp:LinkButton ID="LnkBtnTask" runat="server" ControlToValidate="LnkBtnTask" CssClass="btn btn-sm btn-info" OnClick="LnkBtnTask_Click">
                                                    New Task
                                        </asp:LinkButton>
                                        <%--gridview--%>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                                        <%--    <div class="card">
                                        <div class="card-body">--%>
                                        <h5 class="mb-3">View Task Details</h5>

                                        <hr />

                                        <div class="row">
                                            <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                                                <div class="bd-example">
                                                    <div class="btn-group">
                                                        <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                                        <asp:Button ID="Button1" runat="server" Style="display: none" />
                                                        <div class="dropdown-menu">
                                                            <asp:LinkButton ID="lnkbtnLeadTaskExcel" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="lnkbtnLeadTaskExcel_Click"></asp:LinkButton>
                                                            <asp:LinkButton ID="linkbtnLeadTaskPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnLeadTaskPDF_Click"></asp:LinkButton>

                                                        </div>
                                                    </div>
                                                    <asp:Button ID="lnkbtnLeadTaskVisibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="lnkbtnLeadTaskVisibility_Click" />

                                                    <asp:Button ID="lnkbtnLeadTaskReload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="lnkbtnLeadTaskReload_Click" />


                                                </div>
                                            </div>
                                            <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                                            </div>
                                        </div>

                                        <br />
                                        <br />

                                        <asp:GridView ID="GridTask1" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-responsive table-hover text-nowrap align-content-center" Style="width: 150%" AutoGenerateColumns="false" CellPadding="4"
                                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" OnRowDataBound="GridTask1_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
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
                                                <asp:TemplateField HeaderText="Start_Date" SortExpression="Start_Date" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblStart_Date" runat="server" Text='<%#Bind("Start_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStart_Date1" runat="server" Text='<%#Bind("Start_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Due_Date" SortExpression="Due_Date" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblDue_Date" runat="server" Text='<%#Bind("Due_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDue_Date1" runat="server" Text='<%#Bind("Due_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Assigned To" SortExpression="AssignTo" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblReletd_To" runat="server" Text='<%# Bind("AssignTo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <div class="m-2">
                                                            <asp:BulletedList ID="bulletlist1" runat="server" BulletStyle="Circle" CssClass="" Font-Size="12px">
                                                            </asp:BulletedList>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" SortExpression="TaskStatus" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblTaskStatus" runat="server" Text='<%#Bind("TaskStatus") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlTaskStatus" runat="server" CssClass="form-control " AutoPostBack="true" OnSelectedIndexChanged="ddlTaskStatus_SelectedIndexChanged" Font-Size="12px">
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
                                                <asp:TemplateField HeaderText="Priority" SortExpression="Priority" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblPriority" runat="server" Text='<%# Bind("Priority") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form-control " AutoPostBack="true" OnSelectedIndexChanged="ddlPriority_SelectedIndexChanged">
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
                                                        <asp:LinkButton ID="btnDeleteTask" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClick="btnDeleteTask_Click" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
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

                                        <%-- </div>


                                          </div>--%>
                                    </div>
                                </div>
                                <%--     </ContentTemplate>
                                    <triggers>--%>
                                <%-- <asp:AsyncPostBackTrigger ControlID="LnkBtnTask" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkbtnLeadTaskExcel" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="linkbtnLeadTaskPDF" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkbtnLeadTaskVisibility" EventName="Click" />

                                        <asp:AsyncPostBackTrigger ControlID="lnkbtnLeadTaskReload" EventName="Click" />
                                        <%-- <asp:AsyncPostBackTrigger ControlID="btnEditTask" EventName="Click" />
                                          <asp:AsyncPostBackTrigger ControlID="btnDeleteTask" EventName="Click" />--%>
                                <%-- <asp:AsyncPostBackTrigger ControlID="ddlPriority" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlTaskStatus" EventName="SelectedIndexChanged" />
                                    </triggers>
                                </asp:UpdatePanel>--%>
                            </div>
                            <div class="tab-pane" id="Attachments" role="tabpanel">
                                <asp:UpdatePanel runat="server" UpdateMode="Always" ID="upAttachments">
                                    <ContentTemplate>
                                        <div class="p-20">
                                            <div class="row">
                                                <div class="col-md-8 col-sm-8 col-lg-8  col-xs-8">

                                                    <div class="mb-2">
                                                        <asp:Label ID="lblAttachment" runat="server" Text="Attachment" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label>


                                                        <div class="input-group">
                                                            <asp:FileUpload ID="FileUpload" runat="server" Text="" CssClass="form-control mdi-file-import" />
                                                            <asp:Button ID="Btn_Upload" runat="server" Text="Upload" CssClass="btn btn-primary btn-sm " OnClick="Btn_Upload_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4 col-sm-4 col-lg-4  col-xs-4">
                                                </div>

                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12 col-sm-12 col-lg-12">
                                                    <asp:Label ID="lbdLeaveMID" runat="server" Text="" Font-Size="12px" Font-Bold="false" Visible="true"></asp:Label>

                                                    <asp:GridView ID="GridLeadFile" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%" OnRowDataBound="GridLeadFile_RowDataBound"
                                                        ClientIDMode="Static" ShowHeader="false" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" on EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                                                        <Columns>
                                                            <asp:TemplateField Visible="false">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblLeadFileId" runat="server" Text="FileName" Font-Size="12px" Font-Bold="false" Visible="false"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblfileid" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblLeadFileName" runat="server" Font-Size="12px" Text="FileName" Font-Bold="false"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLeadFileName1" runat="server" Text='<%# Bind("FileName") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField Visible="false">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblLeadFileStatus" runat="server" Font-Size="12px" Text='<%# Bind("Status") %>' Font-Bold="false"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLeadFileStatus1" runat="server" Text='<%# Bind("Status") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Download" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnDownload" runat="server" CausesValidation="false" CommandName="Delete" CssClass="btn btn-sm btn-success " OnClick="btnDownload_Click" Visible="false"><i class="ti ti-download"></i></asp:LinkButton>
                                                                </ItemTemplate>

                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnDeleteLeadFile" runat="server" CausesValidation="false" CommandName="Delete" OnClick="btnDeleteLeadFile_Click" CssClass="btn btn-sm btn-danger" Visible="false" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
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
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="Btn_Upload" />
                                        <%-- <asp:AsyncPostBackTrigger ControlID="Btn_Upload" EventName="Click" />--%>
                                        <%-- <asp:AsyncPostBackTrigger ControlID="btnDownload" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="btnDeleteLeadFile" EventName="Click" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="tab-pane" id="Reminder" role="tabpanel">
                                <%--  <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="upReminder">
                                    <ContentTemplate>--%>
                                <div class="p-20">
                                    <div class="row">
                                        <div class="col-md-12  col-sm-12 col-ld-12 col-xs-12">
                                            <asp:LinkButton ID="lnkbtnCreateRemainder" runat="server" ValidationGroup="btn14" OnClick="lnkbtnCreateRemainder_Click" CssClass="btn btn-sm font-medium btnmodalPopup btn-outline-info btn-sm " data-bs-toggle="modal"
                                                data-bs-target="#ReminderID">
                                                <i class="ti ti-bell"></i>Set Lead Reminder</asp:LinkButton>

                                            <div class="modal fade" id="ReminderID" data-bs-backdrop="static"
                                                data-bs-keyboard="false" tabindex="-1" aria-labelledby="scroll-long-inner-modal"
                                                aria-hidden="true">
                                                <div class="modal-dialog modal-dialog-scrollable">
                                                    <div class="modal-content">
                                                        <div class="modal-header d-flex align-items-center">
                                                            <h4 class="modal-title" id="myLargeModalLabel"></h4>
                                                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                                        </div>
                                                        <div class="modal-body">

                                                            <h5 class="card-title" style="color: blue">Add Reminder</h5>
                                                            <hr />

                                                            <div id="craeteButton" runat="server" visible="true">

                                                                <div class="mb-2">

                                                                    <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                                        <asp:Label ID="lblDateNotified" runat="server" CssClass="form-label" Text="Date To be Notified"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="lblRID" runat="server" Text="" Visible="false"></asp:Label>
                                                                        <asp:TextBox ID="txtDateNotified" type="DateTime-Local" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="Enter Date"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtDateNotified" Display="Dynamic" runat="server" ErrorMessage="Enter Date" ForeColor="Red" ValidationGroup="RemainderLeads" Font-Size="12px"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="mb-2">

                                                                    <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                                        <asp:Label ID="lblSetRemainder" runat="server" CssClass="form-label" Text="Set To Remainder"></asp:Label>
                                                                        <br />

                                                                        <asp:DropDownList ID="ddlreminderMember" runat="server" CssClass="form-control">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="ddlreminderMember" Display="Dynamic" runat="server" ErrorMessage="Select Member" ForeColor="Red" ValidationGroup="RemainderLeads" Font-Size="12px"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="mb-2">


                                                                    <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                                        <asp:Label ID="Label7" runat="server" CssClass="form-label" Text="Description"></asp:Label>
                                                                        <br />

                                                                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" CssClass="form-control border" Style="display: inline-block;" runat="server" placeholder="Enter Description"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <div class="mb-2">

                                                                    <div class="checkbox checkbox-primary">
                                                                        <asp:CheckBox ID="chksetRemainderforEmail" runat="server" CssClass="w-50 h-50" />
                                                                        <asp:Label ID="lblsetRemainderforEmail" runat="server" Text="Send also an email for this reminder"></asp:Label>

                                                                    </div>
                                                                </div>

                                                                <div class="mb-2">

                                                                    <div class="row">

                                                                        <div class="col-md-6 col-sm-6 col-ld-6 col-xs-6 text-left">
                                                                            <asp:Button ID="btnCreateRemainder" runat="server" CssClass="btn btn-info btn-sm " Text="Create Reminder" OnClick="btnCreateRemainder_Click1" />
                                                                            &nbsp
                                                                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" OnClick="btnClear_Click" />

                                                                        </div>
                                                                        <div class="col-md-6 col-sm-6 col-ld-6 col-xs-6"></div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <div class="modal-footer">

                                                            <%--<button type="btnClose" class="btn btn-sm btn-danger" data-bs-dismiss="modal" Visible="false" >Close</button>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div id="myModal" class="modal">
                                                <%-- style="display: none; opacity: 38; justify-content: center; align-content: center; background-color: rgba(0, 0, 0, 0.5);"--%>
                                                <div class="modal-dialog">

                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                        </div>
                                                        <div class="modal-body">

                                                            <div class="row">
                                                                <div class="col-md-12 col-sm-12 col-lg-12">
                                                                    <h5 class="card-title" style="color: blue">Update Reminder</h5>
                                                                    <hr />

                                                                    <div id="Div1" runat="server" visible="true">

                                                                        <div class="mb-2">

                                                                            <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                                                <asp:Label ID="lblDateNotified1" runat="server" CssClass="form-label" Text="Date To be Notified"></asp:Label>
                                                                                <br />
                                                                                <asp:Label ID="lblRID1" runat="server" Text="" Visible="false"></asp:Label>
                                                                                <asp:TextBox ID="txtDateNotified1" type="DateTime-Local" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="Enter Date"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDateNotified1" Display="Dynamic" runat="server" ErrorMessage="Enter Date" ForeColor="Red" ValidationGroup="RemainderLeads" Font-Size="12px"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                        </div>
                                                                        <br />
                                                                        <div class="mb-2">

                                                                            <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                                                <asp:Label ID="lblSetRemainder1" runat="server" CssClass="form-label" Text="Set To Remainder"></asp:Label>


                                                                                <asp:DropDownList ID="ddlreminderMember1" runat="server" CssClass="form-control">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlreminderMember1" Display="Dynamic" runat="server" ErrorMessage="Select Member" ForeColor="Red" ValidationGroup="RemainderLeads" Font-Size="12px"></asp:RequiredFieldValidator>
                                                                            </div>
                                                                        </div>
                                                                        <br />
                                                                        <div class="mb-2">


                                                                            <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                                                <asp:Label ID="Label12" runat="server" CssClass="form-label" Text="Description"></asp:Label>
                                                                                <br />

                                                                                <asp:TextBox ID="txtDescription1" TextMode="MultiLine" CssClass="form-control border" Style="display: inline-block;" runat="server" placeholder="Enter Description"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <br />
                                                                        <div class="mb-2">

                                                                            <div class="checkbox checkbox-primary">
                                                                                <asp:CheckBox ID="chksetRemainderforEmail1" runat="server" CssClass="w-50 h-50" />
                                                                                <asp:Label ID="lblsetRemainderforEmail1" runat="server" Text="Send also an email for this reminder"></asp:Label>

                                                                            </div>
                                                                        </div>
                                                                        <br />

                                                                        <div class="mb-2">

                                                                            <div class="row">

                                                                                <div class="col-md-6 col-sm-6 col-ld-6 col-xs-6 text-left">
                                                                                    <asp:Button ID="btnupdateLeadReminder" runat="server" Text="Update" CssClass="btn btn-sm btn-success" OnClick="btnupdateLeadReminder_Click" />
                                                                                    &nbsp
                                                                                      
                                                                                      <button type="button" id="btnCloseModalFooter" class="btn btn-danger btn-sm">Close</button>

                                                                                </div>
                                                                                <div class="col-md-6 col-sm-6 col-ld-6 col-xs-6"></div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                        </div>
                                                        <div class="modal-footer">

                                                            <%-- <button type="button" id="btnCloseModalFooter" class="btn btn-danger btn-sm">Close</button>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>



                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-lg-12 col-12 col-xs-12">
                                            <h5 class="mb-3">View Reminders Details</h5>

                                            <hr />

                                            <div class="row">
                                                <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                                                    <div class="bd-example">
                                                        <div class="btn-group">
                                                            <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                                            <asp:Button ID="Button2" runat="server" Style="display: none" />
                                                            <div class="dropdown-menu">
                                                                <asp:LinkButton ID="LnkBtnReminderExcel" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="LnkBtnReminderExcel_Click"></asp:LinkButton>
                                                                <asp:LinkButton ID="LnkBtnReminderPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="LnkBtnReminderPDF_Click"></asp:LinkButton>

                                                            </div>
                                                        </div>
                                                        <asp:Button ID="LnkBtnReminderVisibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="LnkBtnReminderVisibility_Click" />

                                                        <asp:Button ID="LnkBtnReminderReload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="LnkBtnReminderReload_Click" />


                                                    </div>
                                                </div>
                                                <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">

                                                    <div class="mb-2">
                                                        <asp:Label ID="lblInitialLeave" runat="server" Text="" Visible="false" ForeColor="Black"></asp:Label>
                                                        <asp:Label ID="lblInitialNumber" runat="server" Text="" Visible="false" ForeColor="Black"></asp:Label>
                                                        <asp:Label ID="lblStaffEmail" runat="server" Text="" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblStaffDesignation" runat="server" Text="" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblEmpName11" runat="server" Text="" Visible="false"></asp:Label>
                                                        <asp:Label ID="Label8" runat="server" Text="" Font-Size="13.5px" Visible="false" ForeColor="Black"></asp:Label>
                                                        <asp:Label ID="lblLeaveID" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblStaffName" runat="server" Text="Staff Name" CssClass="form-label" Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                                        <asp:TextBox ID="txtStaffName" runat="server" Font-Size="12px" ReadOnly="true" placeholder="Enter Staff Name" class="form-control" Visible="false"></asp:TextBox>
                                                    </div>

                                                </div>
                                            </div>

                                            <br />
                                            <br />
                                            <asp:GridView ID="GridLeadReminder" runat="server" ScrollBars="Both" CssClass="table border table-hover table-bordered text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="R_ID" OnRowDataBound="GridLeadReminder_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("R_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblID1" runat="server" Text='<%# Bind("R_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDescription1" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="NotifyDate" SortExpression="NotifyDate" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblnotifyDate" runat="server" Text='<%# Bind("NotifyDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblnotifyDate1" runat="server" Text='<%# Bind("NotifyDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Remainder" SortExpression="SetToReminder" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblSetToReminder" runat="server" Text='<%# Bind("SetToReminder") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSetToReminder1" runat="server" Text='<%# Bind("SetToReminder") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="status" SortExpression="status" HeaderStyle-Font-Size="12px" Visible="false">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblStatuse" runat="server" Text='<%# Bind("status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatuse1" runat="server" Text='<%# Bind("status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnEditReminder" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditReminder_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnDeleteReminder" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteReminder_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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
                                <%--   </ContentTemplate>
                                    <Triggers>

                                        <asp:AsyncPostBackTrigger ControlID="lnkbtnCreateRemainder" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="btnCreateRemainder" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="btnupdateLeadReminder" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="btnClose" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="LnkBtnReminderExcel" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="LnkBtnReminderPDF" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="LnkBtnReminderVisibility" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="LnkBtnReminderReload" EventName="Click" />
                                   <%--     <asp:AsyncPostBackTrigger ControlID="btnEditReminder" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="btnDeleteReminder" EventName="Click" />--%>
                                <%--   </Triggers>
                                </asp:UpdatePanel>--%>
                            </div>
                            <div class="tab-pane" id="Notes" role="tabpanel">
                              <%--  <asp:UpdatePanel runat="server" UpdateMode="Always" ID="upNotes">
                                    <ContentTemplate>--%>
                                        <div class="p-20">
                                            <div class="row">
                                                <div class="col-md-12  col-sm-12 col-ld-12 col-xs-12">
                                                    <div class="mb-2">
                                                        <asp:Label ID="Label3" runat="server" Text="Note" CssClass="form-label"></asp:Label>
                                                        <asp:TextBox ID="txttypeNotes" CssClass="form-control same-width" runat="server" placeholder="Enter Note" TextMode="MultiLine"></asp:TextBox>
                                                        <div id="DateNote" runat="server" visible="false">
                                                            <asp:Label ID="Label4" runat="server" Text="Date Contacted" CssClass="form-label"></asp:Label>
                                                            <asp:TextBox ID="txtDateNote" type="DateTime-Local" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="Enter Date"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                    <div class="mb-2">
                                                        <asp:RadioButton ID="RadioBtnNote1" runat="server" GroupName="RadiobtnNotes" AutoPostBack="true" OnCheckedChanged="RadioBtnNote1_CheckedChanged" />
                                                        <asp:Label ID="lblnotemsg1" runat="server" Text="I got in touch with this lead"></asp:Label>
                                                        <br />
                                                        <asp:RadioButton ID="RadioBtnNote2" runat="server" GroupName="RadiobtnNotes" OnCheckedChanged="RadioBtnNote2_CheckedChanged" AutoPostBack="true" />
                                                        <asp:Label ID="lblnotemsg2" runat="server" Text="I have not Contacted this lead"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-6  col-sm-6 col-ld-6 col-xs-6">
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">

                                                <div class="col-md-12  col-sm-12 col-ld-12 col-xs-12 text-left">

                                                    <div class="mb-2">
                                                        <asp:Button ID="btnSaveNote" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="NewLead11" OnClick="btnSaveNote_Click" />
                                                        <asp:Button ID="btnClearNote" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="Validateclear" OnClick="btnClearNote_Click" />
                                                    </div>

                                                </div>

                                            </div>
                                            <hr />
                                            <div class="row">
                                                <div class="col-md-12  col-sm-12 col-ld-12 col-xs-12 ">
                                                    <asp:LinkButton ID="LinkButton4" runat="server" ControlToValidate="Linkbtnlist1" CssClass="btn btn-sm">
                                                <i class="ti ti-user"></i>
                                                    </asp:LinkButton>
                                                    <asp:Label ID="lblfinalname2" runat="server" Text="-" CssClass="form-label"></asp:Label>
                                                    <asp:Label ID="lbldas" runat="server" Text="-"></asp:Label>
                                                    <asp:Label ID="lblfinalname1" runat="server" Text=""></asp:Label>
                                                    <asp:Label ID="lblcontactedtilead" runat="server" Text="contacted this lead on"></asp:Label>
                                                    <asp:Label ID="lblContactedDate" type="DateTime-Local"  runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                  <%--  </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="RadioBtnNote1" EventName="CheckedChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="RadioBtnNote2" EventName="CheckedChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="btnSaveNote" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="btnClearNote" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>--%>
                            </div>
                            <div class="tab-pane" id="ActivityLog" role="tabpanel">

                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-lg-12 col-12 col-xs-12">
                                        <h5 class="mb-3">View Activity Details</h5>

                                        <hr />

                                        <div class="todo-widget scrollable" style="height: 600px">
                                            <asp:GridView ID="GridViewAct1" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" Style="width: 100%" AutoGenerateColumns="false" CellPadding="4"
                                                ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRowNumAct" Text='<%# Container.DataItemIndex + 1 %>' Font-Size="12px" runat="server" />
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
                                                    <asp:TemplateField HeaderText="Leads Activity" SortExpression="Activity" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblUserID11" runat="server" Text='<%# Bind("UserID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <%--<i class="mdi mdi-leaf fs-4 w-30px mt-1"></i>--%>
                                                            <asp:Label ID="lblDifd" runat="server" Text='<%# Bind("Diff")%>' TabIndex="6" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                            &nbsp;
                                                                 <asp:Label ID="lblAgo" runat="server" Text="MONTH  AGO" TabIndex="6" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                            &nbsp;
                                                                 <asp:Label ID="lblDate" runat="server" Text='<%# Bind("ActivityDate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                            &nbsp;
                                                               <%--  <br />
                                                            <asp:Label ID="Label1" runat="server" Text="---------------------------------------------------------------------" TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="LightGray"></asp:Label>
                                                            <br />--%>
                                                            <asp:Label ID="lblUserID1" runat="server" Text='<%# Bind("UserID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            <asp:Label ID="Designation1" runat="server" Text='<%# Bind("Designation") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            &nbsp;&nbsp;
                                                                 <asp:Label ID="lbldash" runat="server" Text="-" TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            <asp:Label ID="lblActivityType" runat="server" Text='<%# Bind("ActivityType") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            &nbsp;&nbsp;
                                                        </ItemTemplate>
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
       <div class="row">
        <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
            <asp:Image ID="Image1" runat="server" Style="display: none; border: 1px solid #ccc" />
            <asp:Image ID="Image2" runat="server" Style="display: none; border: 1px solid #ccc" />
            <asp:Label ID="lbladdCompany11" runat="server" Text="" CssClass="font-bold text-dark " Visible="false"></asp:Label>
            <asp:Label ID="lbladdress11" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
            <asp:Label ID="lblcompanyaddCity1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
            <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
            <asp:Label ID="lblcompanyaddState1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
            <asp:Label ID="lblcompanyaddCountry1" runat="server" Text="," CssClass="" Visible="false"></asp:Label>
            <asp:Label ID="lblpincode" runat="server" Text="PIN:" CssClass="" Visible="false"></asp:Label>
            <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
            <asp:Label ID="Label5" runat="server" Text="Phone:" CssClass="" Font-Bold="true" Visible="false"></asp:Label>
            <asp:Label ID="lblphoneNo1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
            <asp:Label ID="lblvat" runat="server" Text="VAT NO:" CssClass="" Font-Bold="true" Visible="false"></asp:Label>
            <asp:Label ID="lblVatNo1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
            <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" CssClass="" Font-Bold="true" Visible="false"></asp:Label>
            <asp:Label ID="lblGSTNo1A" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
        </div>
    </div>
    </div>
     <script type="text/javascript">
         function openModal() {
             document.getElementById("myModal").style.display = "block";
         }

         function closeModal() {
             document.getElementById("myModal").style.display = "none";
         }


     </script>
 <script>
     document.addEventListener('DOMContentLoaded', function () {
         var closeModalButton = document.getElementById('btnCloseModalFooter');
         var modal = document.getElementById('myModal');

         closeModalButton.addEventListener('click', function () {
             modal.style.display = 'none';
         });
     });
 </script>


</asp:Content>

