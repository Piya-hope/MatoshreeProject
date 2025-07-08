<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="EditLead.aspx.cs" Inherits="MatoshreeProject.EditLead" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <style type="text/css">
        #leftPanel {
            width: 600px;
            float: left;
            position: relative;
        }

        #rightPanel {
            width: 600px;
            float: right;
            position: relative;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="font-weight-medium mb-0">Edit Lead</h5>
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
                        <li class="breadcrumb-item text-muted" aria-current="page" href="EditLead.aspx">Edit Lead</li>
                    </ol>
                </nav>
                <%-- BreadCrumbs --%>
            </div>
            <%-- Toaster --%>
            <div class="col-md-4 col-sm-4 col-xl-4 col-lg-4">
                <div id="Toasteralert1" runat="server" visible="false">
                    <div class="toast" role="alert" aria-live="assertive" aria-atomic="true">
                        <div class="d-flex">
                            <div class="toast-body">
                                <asp:Label ID="lblMessage" runat="server" Text="" Font-Size="13.5px" ForeColor="Black"></asp:Label>
                            </div>
                            <button type="button" class="btn-close me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
                        </div>
                    </div>
                </div>

                <div id="deleteToaster1" runat="server" visible="false">
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
        <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
            <div class="card">
                <div class="card-body">
                    <h5></h5>
                    <hr />
                    <div class="row">
                        <div class="col-md-4 col-sm-4 col-xl-4 col-lg-4">
                            <asp:Label ID="lblStatus" runat="server" Text="Status" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span><br>
                            <div class="input-group">
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-select form-control">
                                </asp:DropDownList>
                                <!-- Button trigger modal -->

                                <button type="button" id="btnStatus" class="btn btn-info btn-sm font-medium btnmodalPopup" data-bs-toggle="modal"
                                    data-bs-target="#StatusID">
                                    +
                                </button>
                                <div class="modal fade" id="StatusID" data-bs-backdrop="static"
                                    data-bs-keyboard="false" tabindex="-1" aria-labelledby="scroll-long-inner-modal"
                                    aria-hidden="true">
                                    <div class="modal-dialog modal-dialog-scrollable">
                                        <div class="modal-content">
                                            <div class="modal-header d-flex align-items-center">
                                                <h4 class="modal-title" id="myLargeModalLabel"></h4>
                                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                            </div>
                                            <div class="modal-body">

                                                <h5 class="card-title" style="color: blue">Add Status</h5>
                                                <hr />
                                                <div class="mb-2">

                                                    <asp:Label ID="lblStatusName" runat="server" Text="StatusName" Font-Bold="true" Font-Size="12px"></asp:Label>

                                                    <asp:TextBox ID="txtStatusName" runat="server" Font-Size="12px" CssClass="form-control" placeholder="Enter Status Name"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Status Name" ControlToValidate="txtStatusName" ForeColor="Red" Font-Bold="false" ValidationGroup="SaveStatus"></asp:RequiredFieldValidator>
                                                </div>


                                            </div>
                                            <br />
                                            <div class="modal-footer">
                                                <asp:Button ID="btnSaveStatus" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="SaveStatus" OnClick="btnSaveStatus_Click" />
                                                &nbsp;&nbsp;
                                        <button type="button"
                                            class="btn btn-sm btn-danger"
                                            data-bs-dismiss="modal">
                                            Close
                                        </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="col-md-4 col-sm-4 col-xl-4 col-lg-4">
                            <asp:Label ID="lblSorce" runat="server" Text="Source" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span><br>
                            <div class="input-group">
                                <asp:DropDownList ID="ddlSource" runat="server" CssClass="form-select form-control">
                                </asp:DropDownList>
                                <!-- Button trigger modal -->

                                <button type="button" id="btnSource" class="btn btn-info btn-sm font-medium btnmodalPopup" data-bs-toggle="modal"
                                    data-bs-target="#SourceID">
                                    +
                                </button>
                                <div class="modal fade" id="SourceID" data-bs-backdrop="static"
                                    data-bs-keyboard="false" tabindex="-1" aria-labelledby="scroll-long-inner-modal"
                                    aria-hidden="true">
                                    <div class="modal-dialog modal-dialog-scrollable">
                                        <div class="modal-content">
                                            <div class="modal-header d-flex align-items-center">
                                                <h4 class="modal-title" id="myLargeModalLabel1"></h4>
                                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                            </div>
                                            <div class="modal-body">

                                                <h5 class="card-title" style="color: blue">Add Source</h5>
                                                <hr />
                                                <div class="mb-2">
                                                    <asp:Label ID="Label2" runat="server" Text="SourceName" CssClass="form-label"></asp:Label>
                                                    <asp:TextBox ID="txtSourcename" runat="server" CssClass="form-control" placeholder="Enter Source Name"></asp:TextBox>

                                                    <asp:RequiredFieldValidator ID="RequiredSourcename" runat="server" ErrorMessage="Enter Source Name" ControlToValidate="txtSourcename" ForeColor="Red" Font-Bold="false" ValidationGroup="savesource"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>

                                            <br />
                                            <div class="modal-footer">
                                                <asp:Button ID="btnsavesource" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" OnClick="btnsavesource_Click" ValidationGroup="savesource" />
                                                &nbsp;&nbsp;
                                             <button type="Button" class="btn btn-sm btn-danger" data-bs-dismiss="modal">Close</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="col-md-4 col-sm-4 col-xl-4 col-lg-4">
                            <asp:Label ID="lblAssigned" runat="server" Text="Assigned" Font-Bold="true" CssClass="form-label"></asp:Label>
                            <div class="input-group">
                                <asp:DropDownList ID="ddlAssigned" runat="server" CssClass="form-select form-control">
                                </asp:DropDownList>
                            </div>

                        </div>
                        <hr />
                        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updatePanel1">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-6 col-sm-6 col-xl-6 col-lg-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblLeadIdd" runat="server" Text="Country" CssClass="form-label" Visible="false"></asp:Label>

                                            <asp:Label ID="lblName" runat="server" Text="Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span><br>
                                            <asp:TextBox ID="txtName" runat="server" placeholder="Enter Name" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Name" ControlToValidate="txtName" ForeColor="Red" Font-Bold="false" ValidationGroup="NewLed"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-md-6 col-sm-6 col-xl-6 col-lg-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblCountry" runat="server" Text="Country" CssClass="form-label"></asp:Label>

                                            <asp:DropDownList ID="ddlCountry" name="Country" runat="server" CssClass="form-control form-select">
                                                <asp:ListItem Value="0">Select Country</asp:ListItem>
                                                <asp:ListItem Value="India">India</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-6 col-sm-6 col-xl-6 col-lg-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblPosition" runat="server" Text="Position" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txtPosition" runat="server" placeholder="Enter Position" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-6 col-sm-6 col-xl-6 col-lg-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblState" runat="server" Text="State" CssClass="form-label"></asp:Label>
                                            <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control form-select" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlState" ForeColor="Red" Font-Size="12px" Font-Bold="false" InitialValue="0" Display="Dynamic" ValidationGroup="NewLead" ErrorMessage="Select State"></asp:RequiredFieldValidator>
                                        </div>

                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="col-md-6 col-sm-6 col-xl-6 col-lg-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter Email" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-6 col-sm-6 col-xl-6 col-lg-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblDistrict" runat="server" Text="District" CssClass="form-label"></asp:Label>

                                            <asp:DropDownList ID="ddldistrict" runat="server" CssClass="form-control form-select" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddldistrict" ForeColor="Red" Font-Size="12px" Font-Bold="false" InitialValue="0" Display="Dynamic" ValidationGroup="NewLead" ErrorMessage="Select district"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="col-md-6 col-sm-6 col-xl-6 col-lg-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblWebsite" runat="server" Text="Website" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txtWebsite" runat="server" placeholder="Enter Website" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-6 col-sm-6 col-xl-6 col-lg-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblCity1" runat="server" Text="City/Taluka" CssClass="form-label"></asp:Label>
                                            <asp:DropDownList ID="ddlcity" runat="server" CssClass="form-control form-select">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="col-md-6 col-sm-6 col-xl-6 col-lg-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblPhone" runat="server" Text="Phone" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txtPhone" runat="server" placeholder="Enter Phone" class=" form-control" TextMode="Phone"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-6 col-sm-6 col-xl-6 col-lg-6">

                                        <div class="mb-2">
                                            <asp:Label ID="lblAddress" runat="server" Text="Address" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txtAddress" runat="server" placeholder="Enter Address" class="form-control"></asp:TextBox>
                                        </div>

                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="col-md-6 col-sm-6 col-xl-6 col-lg-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblLeadValue" runat="server" Text="Lead Value" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txtLeadValue" runat="server" placeholder="Enter Lead Value" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xl-6 col-lg-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblZipCode" runat="server" Text="Zip Code" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txtZipCode" runat="server" name="ZipCode" placeholder="Enter Zipcode" CssClass="form-control" MaxLength="6"></asp:TextBox>
                                        </div>

                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="col-md-6 col-sm-6 col-xl-6 col-lg-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblCompany" runat="server" Text="Company" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txtCompany" runat="server" placeholder="Company" class=" form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xl-6 col-lg-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblDefaultLanguage" runat="server" Text="Default Language" CssClass="form-label"></asp:Label>
                                            <asp:DropDownList ID="ddlDefaultLanguage" name="ddlDefaultLanguage" runat="server" CssClass="form-control form-select">
                                                <asp:ListItem Value="NA" Text="NA"></asp:ListItem>
                                                <asp:ListItem Value="Marathi" Text="Marathi"></asp:ListItem>
                                                <asp:ListItem Value="English" Text="English" ></asp:ListItem>
                                                <asp:ListItem Value="Hindi" Text="Hindi"></asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="col-md-6 col-sm-6 col-xl-6 col-lg-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txtDescription" runat="server" placeholder="Description" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xl-6 col-lg-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblDateContact" runat="server" Text="Date Contact" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txtDateContact" runat="server" placeholder="Date Contact" class=" form-control" type="date"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="mb-2">
                                    <asp:CheckBox ID="chkPublic" runat="server" Text="Public" />&nbsp;&nbsp;
                            <asp:CheckBox ID="chkContracted" runat="server" Text="Contracted Today" />
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="mb-2">
                                        <asp:Button ID="btnUpdateLead" runat="server" Text="Update" CssClass="btn btn-sm btn-success" ValidationGroup="UpdateLead" OnClick="btnUpdateLead_Click" />
                                        <asp:Button ID="btnClose" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" OnClick="btnClose_Click" />
                                    </div>
                                </div>

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlState" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddldistrict" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="btnUpdateLead" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btnClose" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>


                </div>
            </div>
        </div>
    </div>
</asp:Content>
