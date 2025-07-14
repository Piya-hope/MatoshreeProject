<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="NewPurchaseOrder.aspx.cs" Inherits="MatoshreeProject.NewPurchaseOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridWorkorderlist = $("#GridWorkorderlist").prepend($("<thead></thead>").append($("#GridWorkorderlist").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
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
                <h5 class="font-weight-medium mb-0">New PurchaseOrder</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="PurchaseOrder.aspx">PurchaseOrder
                            </a>
                        </li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="#">New PurchaseOrder</li>
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
            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">

                            <div class="col-md-6 col-sm-6 col-lg-6 border-right">
                                <asp:UpdatePanel ID="UpdatePanelddlState" runat="server">
                                    <ContentTemplate>
                                        <h6 class="text-purple">Purchase Order Details</h6>
                                        <%-- <h5>General Options </h5>--%>
                                        <asp:Label ID="lblabc" runat="server" Text="" CssClass=" font-bold" Visible="false"></asp:Label>

                                        <hr />
                                        <div class="col-md-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lblPONumber" runat="server" Text="PONumber" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>

                                                <asp:Label ID="lblInitialNumber" runat="server" Text="-" Font-Bold="true" CssClass="form-control col-1 col-md-1" ReadOnly="true"></asp:Label>
                                                <asp:TextBox ID="txtPONumber" runat="server" CssClass="form-control col-md-11" ReadOnly="true"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfv_PONumber" ControlToValidate="txtPONumber" Display="Dynamic" runat="server" ErrorMessage="Enter Purchase Number" ForeColor="Red" ValidationGroup="PurchaseOrder" Font-Size="12px"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>


                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lblPOName" runat="server" Text="Purchase Order Name" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                                <asp:TextBox ID="txtPOName" runat="server" CssClass="form-control col-md-11" placeholder="Enter Purchase Order Name"></asp:TextBox>
                                            </div>
                                            <div class="mb-2">
                                                <asp:RequiredFieldValidator ID="rfv_POName" ControlToValidate="txtPONumber" Display="Dynamic" runat="server" ErrorMessage="Enter PO Name" ForeColor="Red" ValidationGroup="PurchaseOrder" Font-Size="12px"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblPODate" runat="server" Text="Date" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                                        <asp:TextBox ID="txtPODate" CssClass="form-control" runat="server" Placeholder="Enter Date" type="date"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_PODate" runat="server" ControlToValidate="txtPODate" ErrorMessage="Enter PO Date" ForeColor="Red" ValidationGroup="PurchaseOrder" Font-Size="12px"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblPOExpireDate" runat="server" Text="Expire Date" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                                        <asp:TextBox ID="txtPOExpireDate" CssClass="form-control" runat="server" Placeholder="Enter Expire Date" type="date"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_POExpireDate" runat="server" ControlToValidate="txtPOExpireDate" ErrorMessage="Enter POExpire Date" ForeColor="Red" ValidationGroup="PurchaseOrder" Font-Size="12px"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lblAmount" runat="server" Text="Amount" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                                <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control col-md-11" placeholder="Enter Amount"></asp:TextBox>
                                            </div>
                                            <div class="mb-2">
                                                <asp:RequiredFieldValidator ID="rfv_txtAmount" ControlToValidate="txtAmount" Display="Dynamic" runat="server" ErrorMessage="Enter Amount" ForeColor="Red" ValidationGroup="PurchaseOrder" Font-Size="12px"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>


                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                            <asp:Label ID="lblCustomers" runat="server" Text="Customer" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                            <div class="mb-2">
                                                <div class="input-group">
                                                    <asp:DropDownList ID="ddlCustomers" runat="server" CssClass="form-control form-select" OnSelectedIndexChanged="ddlCustomers_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfv_Customer" runat="server" ControlToValidate="ddlCustomers" ErrorMessage="Select Customer" ForeColor="Red" InitialValue="0" Display="Dynamic" ValidationGroup="PurchaseOrder" Font-Size="12px"></asp:RequiredFieldValidator>
                                                    <asp:Button ID="btn_AddCustomer" runat="server" Text="Add Customer" CssClass="btn btn-primary btn-sm" OnClick="btn_AddCustomer_Click" />
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                            <asp:Label ID="lblProjects" runat="server" Text="Project" CssClass="form-label"></asp:Label><span class="text-danger">*</span>
                                            <div class="mb-2">
                                                <div class="input-group">
                                                    <asp:DropDownList ID="ddlProjects" runat="server" CssClass="form-control form-select" OnSelectedIndexChanged="ddlProjects_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlProjects" ErrorMessage="Select Project" ForeColor="Red" Display="Dynamic" InitialValue="0" ValidationGroup="PurchaseOrder" Font-Size="12px"></asp:RequiredFieldValidator>
                                                    <asp:Button ID="btn_AddProject" runat="server" Text="Add Project" CssClass="btn btn-primary btn-sm" OnClick="btn_AddProject_Click" />

                                                </div>
                                            </div>
                                        </div>

                                    </ContentTemplate>

                                </asp:UpdatePanel>
                            </div>

                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <asp:UpdatePanel ID="UpdatePanelbiing" runat="server">
                                    <ContentTemplate>
                                        <%--   <h6 style="color: blue;">Advanced Options</h6>--%>
                                        <h6 class="text-white">Advanced Options</h6>
                                        <hr />
                                        <div class="row">
                                            <div class="col-md-6  col-sm-6 col-lg-6">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblStatus" runat="server" Text="Status" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control form-select">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="ddlStatus" ErrorMessage="Select Status" ForeColor="Red" Display="Dynamic" ValidationGroup="PurchaseOrder" Font-Size="12px"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-sm-6 col-lg-6">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblSalesAgent" runat="server" Text="Sales Agent" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                                    <asp:DropDownList ID="ddlSalesAgent" runat="server" CssClass="form-control form-select">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="ddlSalesAgent" ErrorMessage="Select Sales Agent" ForeColor="Red" Display="Dynamic" ValidationGroup="PurchaseOrder" Font-Size="12px"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <hr />
                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                            <div class="row">
                                                <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                                    <div class="mb-2">
                                                        <h6>Shipping Address</h6>
                                                    </div>
                                                </div>


                                                <div class="col-md-6 col-sm-6 col-lg-6">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lbllocationcountry" runat="server" Text="Country" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                                        <asp:DropDownList ID="ddllocationcountry" runat="server" CssClass="form-select" name="CountryBilling">
                                                            <asp:ListItem Value="0">Select Country</asp:ListItem>
                                                            <asp:ListItem Value="India">India</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ddllocationcountry" Display="Dynamic" runat="server" ErrorMessage="Select Country" ForeColor="Red" ValidationGroup="PurchaseOrder" Font-Size="12px"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 col-sm-6 col-lg-6">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lbllocationstate" runat="server" Text="State" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                        <asp:DropDownList ID="ddllocationstate" runat="server" CssClass="form-control form-select" OnSelectedIndexChanged="ddllocationstate_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddllocationstate" Display="Dynamic" runat="server" ErrorMessage="Select State" ForeColor="Red" ValidationGroup="PurchaseOrder" Font-Size="12px"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <div class="col-md-6 col-sm-6 col-lg-6">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lbllocationdistrict" runat="server" Text="District" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                        <asp:DropDownList ID="ddllocationdistrict" runat="server" CssClass="form-control form-select" OnSelectedIndexChanged="ddllocationdistrict_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="ddllocationdistrict" Display="Dynamic" runat="server" ErrorMessage="Select District" ForeColor="Red" ValidationGroup="PurchaseOrder" Font-Size="12px"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 col-sm-6 col-lg-6">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lbllocationcity" runat="server" Text="City/Taluka" CssClass="form-label"></asp:Label>
                                                        <asp:DropDownList ID="ddllocationcity" runat="server" CssClass="form-control form-select">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>


                                                <div class="col-md-12 col-sm-12 col-lg-12">

                                                    <div class="mb-2">
                                                        <asp:Label ID="lbladdressLine1" runat="server" Text="Address Line1" CssClass="form-label"></asp:Label><%--<span class="text-danger"> *</span>--%>
                                                        <asp:TextBox ID="txtaddressLine1" runat="server" name="StreetLocation1" CssClass="form-control" Placeholder="Enter Address Line1"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="txtaddressLine1" Display="Dynamic" runat="server" ErrorMessage="Enter Address Line1" ForeColor="Red" ValidationGroup="PurchaseOrder" Font-Size="12px"></asp:RequiredFieldValidator>--%>
                                                    </div>

                                                </div>
                                                <div class="col-md-12 col-sm-12 col-lg-12">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lbladdress2" runat="server" Text="Address Line2" CssClass="form-label" Visible="false"></asp:Label><%--<span class="text-danger"> *</span>--%>
                                                        <asp:TextBox ID="txtaddressline2" runat="server" name="StreetLocation2" CssClass="form-control" Placeholder="Enter Address Line2" Visible="false"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator17" ControlToValidate="txtaddressline2" Display="Dynamic" runat="server" ErrorMessage="Enter Address Line2" ForeColor="Red" ValidationGroup="PurchaseOrder" Font-Size="12px"></asp:RequiredFieldValidator>--%>
                                                    </div>

                                                </div>
                                                <div class="col-md-6 col-sm-6 col-lg-6">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblflatno" runat="server" Text="Flat/Block/RoadNo" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                                        <asp:TextBox ID="txtlocationflatno" runat="server" name="flatLocation" CssClass="form-control" Placeholder="Enter Flat/Block/RoadNo"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtlocationflatno" Display="Dynamic" runat="server" ErrorMessage="Enter Flat/Block/RoadNo" ForeColor="Red" ValidationGroup="PurchaseOrder" Font-Size="12px"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 col-sm-6 col-lg-6">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblpincode" runat="server" Text="Pin Code" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                                        <asp:TextBox ID="txtlocationpincode" runat="server" name="PinLocation" CssClass="form-control" MaxLength="6" Placeholder="Enter Pin Code"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtlocationpincode" Display="Dynamic" runat="server" ErrorMessage="Enter Pincode" ForeColor="Red" ValidationGroup="WorkOrder" Font-Size="12px"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>

                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lblAttachment" runat="server" Text="Attachment" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                                <div class="input-group">
                                                    <asp:FileUpload ID="FileUpload" runat="server" Text="" CssClass="form-control" />

                                                    <asp:Button ID="Btn_Upload" runat="server" Text="Upload" CssClass="btn btn-primary btn-sm" OnClick="Btn_Upload_Click1" ValidationGroup="File" />
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtlocationpincode" Display="Dynamic" runat="server" ErrorMessage="Enter Pincode" ForeColor="Red" ValidationGroup="WorkOrder" Font-Size="12px"></asp:RequiredFieldValidator>--%>
                                                </div>

                                            </div>
                                            <div class="mb-2">
                                                <asp:Label ID="lblFileName" runat="server" Text="" CssClass="form-label text-info"></asp:Label>
                                                <asp:Label ID="lblFilePath" runat="server" Text="" CssClass="form-label" Visible="true"></asp:Label>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddllocationstate" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddllocationdistrict" EventName="SelectedIndexChanged" />
                                        <asp:PostBackTrigger ControlID="Btn_Upload" />
                                        <%-- <asp:AsyncPostBackTrigger ControlID="ddllocationcity" EventName="SelectedIndexChanged" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--  <div class="row">--%>

        <div class="row">
            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                <div class="card">
                    <div class="card-body">

                        <h5>Purchase Order Procurement</h5>
                        <hr />
                        <div class="row">
                            <div class="col-md-3">
                                <div class="mb-2">
                                    <div class="input-group">
                                        <asp:Label ID="lbltenid" runat="server" Visible="false"></asp:Label>

                                        <asp:DropDownList ID="ddlItem" runat="server" CssClass="form-select form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <!-- Button trigger modal -->
                                        <button type="button" class="btn btn-info btn-sm font-medium"
                                            data-bs-toggle="modal" data-bs-target="#ItemID">
                                            +
                                        </button>
                                    </div>
                                </div>
                            </div>

                            <!-- Modal for Item Start-->
                            <div class="modal fade" id="ItemID" data-bs-backdrop="static"
                                data-bs-keyboard="false" tabindex="-1" aria-labelledby="scroll-long-inner-modal"
                                aria-hidden="true">
                                <div class="modal-dialog modal-dialog-scrollable">
                                    <div class="modal-content">
                                        <div class="modal-header d-flex align-items-center">
                                            <h4 class="modal-title" id="myLargeModalLabel"></h4>
                                            <%--<button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>--%>
                                            <asp:Button ID="btnCloseModalItem" runat="server" Text="" CssClass="btn-close" OnClick="btnCloseModalItem_Click" data-bs-dismiss="modal" aria-label="Close" />

                                        </div>
                                        <div class="modal-body">
                                            <%--  <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                            <ContentTemplate>--%>
                                            <h6 class="text-purple">Add Item</h6>

                                            <hr />
                                            <div class="mb-2">
                                                <asp:Label ID="lbl_Description" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                <asp:TextBox ID="txt_Description" runat="server" CssClass="form-control" placeholder="Enter Description"></asp:TextBox>
                                            </div>
                                            <div class="mb-2">
                                                <asp:Label ID="lbl_Rate" runat="server" Text="Rate" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                <asp:TextBox ID="txt_Rate" runat="server" CssClass="form-control" placeholder="Enter Rate"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Rate" runat="server" ErrorMessage="Enter Rate" Display="Dynamic" ControlToValidate="txt_Rate" ForeColor="Red" ValidationGroup="SavePOItem" Font-Size="12px"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="mb-2">
                                                <asp:Label ID="lblHSNCode" runat="server" Text="HSNCode" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                <asp:TextBox ID="txtHSNCode" runat="server" CssClass="form-control" placeholder="Enter HSNCode"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtHSNCode" ErrorMessage="Enter HSNCode" ForeColor="Red" ValidationGroup="SavePOItem" Font-Size="12px"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="mb-2">
                                                <asp:Label ID="lbl_LongDescription" runat="server" Text="Long Description" CssClass="form-label"></asp:Label>
                                                <asp:TextBox ID="txt_LongDescription" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Enter Long Description"></asp:TextBox>
                                            </div>
                                            <div class="mb-2">
                                                <asp:Label ID="lbl_Tax" runat="server" Text="Tax1" CssClass="form-label"></asp:Label>
                                                <asp:DropDownList ID="ddlTax" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="mb-2">
                                                <asp:Label ID="lbl_Tax2" runat="server" Text="Tax2" CssClass="form-label"></asp:Label>
                                                <asp:DropDownList ID="ddlTax1" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>


                                            <%--                                            </ContentTemplate>
                                        </asp:UpdatePanel>--%>
                                        </div>

                                        <div class="modal-footer mb-2">
                                            <asp:Button ID="btnSaveModalItem" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" OnClick="btnSaveModalItem_Click" ValidationGroup="SavePOItem" />
                                            &nbsp;&nbsp;
                                              <button type="button" class="btn btn-sm btn-danger" data-bs-dismiss="modal">Close </button>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <!-- Modal for Item End-->
                        </div>
                        <div class="row">
                            <asp:Label ID="lblProjectName1" runat="server" Text="" CssClass="font-bold text-dark font-14" Visible="false"></asp:Label>
                            <asp:Label ID="lblPOID" runat="server" Text="" CssClass="font-bold text-dark font-14" Visible="false"></asp:Label>
                            <asp:Label ID="lblPONumber1" runat="server" Text="" CssClass="font-bold text-dark font-14" Visible="false"></asp:Label>
                            <asp:Label ID="lblProjectID" runat="server" Text="" CssClass="font-bold text-dark font-14" Visible="false"></asp:Label>
                            <asp:Label ID="txtPrice" runat="server" Text="" CssClass="font-bold text-dark font-14" Visible="false"></asp:Label>
                            <asp:Label ID="txtQty" runat="server" Text="" CssClass="font-bold text-dark font-14" Visible="false"></asp:Label>
                            <asp:Label ID="lblClient1" runat="server" Text="" CssClass="font-bold text-dark font-14" Visible="false"></asp:Label>

                            <div class="table-responsive">
                                <asp:GridView ID="GridProcurement" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                    ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="true" DataKeyNames="ID" OnRowDataBound="GridProcurement_RowDataBound" OnRowEditing="GridProcurement_RowEditing"
                                    OnRowCancelingEdit="GridProcurement_RowCancelingEdit" OnRowDeleting="GridProcurement_RowDeleting" OnPageIndexChanging="GridProcurement_PageIndexChanging" OnRowUpdating="GridProcurement_RowUpdating">
                                    <Columns>
                                        <asp:TemplateField Visible="false">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblPID1" runat="server" Text="ID" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblProdID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblProductID1" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblProduct" runat="server" Text="Product" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditProduct" runat="server" Text='<%# Bind("ProductName") %>' CssClass="form-control" Placeholder="Product"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductlist1" runat="server" Text='<%# Bind("ProductName") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtProduct" runat="server" Text="" CssClass="form-control" Placeholder="Product"></asp:TextBox>
                                                <br />
                                                <asp:RequiredFieldValidator ID="rfv_InvoiceItemPC1" ControlToValidate="txtProduct" Display="Dynamic" runat="server" ErrorMessage="Enter Product" Font-Size="12px" ForeColor="Red" ValidationGroup="ProductItem"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditDescription" runat="server" Text='<%# Bind("Description") %>' TextMode="MultiLine" CssClass="form-control" Placeholder="Description"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescription1" runat="server" Text='<%# Bind("Description") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Text="" CssClass="form-control" Placeholder="Description"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="60px">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblQuantity" runat="server" Text="Quantity" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtQty1" runat="server" Text='<%# Bind("Quantity") %>' CssClass="form-control" Placeholder="Quantity" TextMode="Number" Style="width: 60px" OnTextChanged="txtQty1_TextChanged1" AutoPostBack="true"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblQuantity1" runat="server" Text='<%# Bind("Quantity") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtQty" runat="server" Text="1" CssClass="form-control" Placeholder="Product Quantity" TextMode="Number" Style="width: 60px" AutoPostBack="true" OnTextChanged="txtQty_TextChanged"></asp:TextBox>
                                                <br />
                                                <asp:RequiredFieldValidator ID="rfv_QtyPC" ControlToValidate="txtQty" Display="Dynamic" runat="server" ErrorMessage="Enter Product Quantity" ForeColor="Red" Font-Size="12px" ValidationGroup="ProductItem"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="150px">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblPrice" runat="server" Text="Price" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtPrice1" runat="server" Text='<%# Bind("Price") %>' CssClass="form-control" Placeholder="Product Price" TextMode="Number" Style="width: 150px" OnTextChanged="txtPrice1_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrice1" runat="server" Text='<%# Bind("Price") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtPrice" runat="server" Text="" CssClass="form-control" Placeholder="Product Price" AutoPostBack="true" OnTextChanged="txtPrice_TextChanged"></asp:TextBox>
                                                <br />
                                                <asp:RequiredFieldValidator ID="rfv_Price" ControlToValidate="txtPrice" Display="Dynamic" runat="server" ErrorMessage="Enter Product Price" ForeColor="Red" Font-Size="12px" ValidationGroup="ProductItem"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblAmontname" runat="server" Text="Amount" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblEditAmont1" runat="server" Text='<%# Bind("TotalAmont") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmont1" runat="server" Text='<%# Bind("TotalAmont") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblHSN" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                                <asp:Label ID="lblAmontP" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="110px">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="btnOption" runat="server" Text="" ValidationGroup="setting"><i class="ti ti-settings"></i></asp:LinkButton>
                                            </HeaderTemplate>
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CausesValidation="false" CommandName="Update" TabIndex="18" Font-Size="12px"></asp:LinkButton>
                                                <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CausesValidation="false" CommandName="Cancel" TabIndex="19" Font-Size="12px"></asp:LinkButton>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEditProcurement" runat="server" CausesValidation="false" CommandName="Edit" CssClass="btn btn-sm btn-rounded btn-success" ValidationGroup="UpdateProductItem" Text="" Visible="false"><i class="ti ti-edit"></i></asp:LinkButton>
                                                &nbsp;&nbsp;&nbsp;
                                               <asp:LinkButton ID="btnDeleteProcurement" runat="server" CausesValidation="false" CommandName="Delete" CssClass="btn btn-sm btn-rounded btn-danger" ValidationGroup="DelProductItem" Text="" Visible="false"><i class="ti ti-trash"></i></asp:LinkButton>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:LinkButton ID="btnAddProcurement" runat="server" CausesValidation="false" CssClass="btn btn-sm btn-rounded btn-info" Text="" OnClick="btnAddProcurement_Click" TabIndex="9" ValidationGroup="ProductItem"><i class="ti ti-check fs-4"></i></asp:LinkButton>
                                                &nbsp;&nbsp;&nbsp;
                                                                            <asp:LinkButton ID="btnCancelProcurement" runat="server" CausesValidation="false" CssClass="btn btn-sm btn-rounded btn-danger" ValidationGroup="CanccelProductItem" Text="" OnClick="btnCancelProcurement_Click"><i class=" ti ti-clear-all"></i></asp:LinkButton>

                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6"></div>
                                <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6 text-end">
                                    <i class="ti ti-arrow-autofit-right text-info"></i>&nbsp;<asp:Label ID="lblTotalProcurement" runat="server" Text="Total Purchase Order Amount :" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp; &nbsp;
                                    <asp:Label ID="lblTotalAmountProcurement" runat="server" Text="" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <asp:Label ID="lblEdit" runat="server" Text="" Visible="false"></asp:Label>
                        <h5>Purchase Order Services List</h5>
                        <hr />
                        <div class="row">
                            <div class="col-md-3">
                                <div class="mb-2">
                                    <div class="input-group">
                                        <asp:Label ID="LBLITEN2" runat="server"></asp:Label>
                                        <asp:DropDownList ID="ddlItemServices" runat="server" CssClass="form-select form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlItemServices_SelectedIndexChanged" ValidationGroup="itefc">
                                        </asp:DropDownList>
                                        <!-- Button trigger modal -->
                                        <button type="button" class="btn btn-info btn-sm font-medium"
                                            data-bs-toggle="modal" data-bs-target="#ItemID1">
                                            +
                                        </button>
                                    </div>
                                </div>
                            </div>

                            <!-- Modal for Services Start-->
                            <div class="modal fade" id="ItemID1" data-bs-backdrop="static"
                                data-bs-keyboard="false" tabindex="-1" aria-labelledby="scroll-long-inner-modal"
                                aria-hidden="true">
                                <div class="modal-dialog modal-dialog-scrollable">
                                    <div class="modal-content">
                                        <div class="modal-header d-flex align-items-center">
                                            <h4 class="modal-title" id="myLargeModalLabel1"></h4>
                                            <%--<button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>--%>
                                            <asp:Button ID="btnCloseModalService" runat="server" Text="" CssClass="btn-close" OnClick="btnCloseModalService_Click" data-bs-dismiss="modal" aria-label="Close" />

                                        </div>
                                        <div class="modal-body">
                                            <%-- <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                            <ContentTemplate>--%>
                                            <h6 class="text-purple">Add Item</h6>

                                            <hr />
                                            <div class="mb-2">
                                                <asp:Label ID="lbl_Description1" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                <asp:TextBox ID="txt_Description1" runat="server" CssClass="form-control" placeholder="Enter Description"></asp:TextBox>
                                            </div>
                                            <div class="mb-2">
                                                <asp:Label ID="lbl_Rate1" runat="server" Text="Rate" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                <asp:TextBox ID="txt_Rate1" runat="server" CssClass="form-control" placeholder="Enter Rate"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Rate" Display="Dynamic" ControlToValidate="txt_Rate1" ForeColor="Red" ValidationGroup="SaveItem" Font-Size="12px"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="mb-2">
                                                <asp:Label ID="lblHSNCode1" runat="server" Text="HSNCode" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                <asp:TextBox ID="txtHSNCode1" runat="server" CssClass="form-control" placeholder="Enter HSNCode"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtHSNCode1" ErrorMessage="Enter HSNCode" ForeColor="Red" ValidationGroup="SaveItem" Font-Size="12px"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="mb-2">
                                                <asp:Label ID="lbl_LongDescription1" runat="server" Text="Long Description" CssClass="form-label"></asp:Label>
                                                <asp:TextBox ID="txt_LongDescription1" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Enter Long Description"></asp:TextBox>
                                            </div>
                                            <div class="mb-2">
                                                <asp:Label ID="lbl_Tax1" runat="server" Text="Tax1" CssClass="form-label"></asp:Label>
                                                <asp:DropDownList ID="ddlTax2" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="mb-2">
                                                <asp:Label ID="Label1" runat="server" Text="Tax2" CssClass="form-label"></asp:Label>
                                                <asp:DropDownList ID="ddlTax3" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>


                                            <%--</ContentTemplate>
                                        </asp:UpdatePanel>--%>
                                        </div>

                                        <div class="modal-footer mb-2">
                                            <asp:Button ID="btnSaveModalservice" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" OnClick="btnSaveModalservice_Click" ValidationGroup="SaveItem" />
                                            &nbsp;&nbsp;
                                              <button type="btnClose1" class="btn btn-sm btn-danger" data-bs-dismiss="modal">Close </button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- Modal for Services End-->
                        </div>

                        <div class="row">
                            <div class="table-responsive">
                                <asp:GridView ID="GridServicesList" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                    ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="true" DataKeyNames="ID" OnRowDataBound="GridServicesList_RowDataBound" OnRowEditing="GridServicesList_RowEditing" OnRowUpdating="GridServicesList_RowUpdating"
                                    OnRowCancelingEdit="GridServicesList_RowCancelingEdit" OnRowDeleting="GridServicesList_RowDeleting" OnPageIndexChanging="GridServicesList_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField Visible="false">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblPID1" runat="server" Text="ID" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblServiceID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblServiceID1" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblServices" runat="server" Text="Services" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditServices" runat="server" Text='<%# Bind("ServiceName") %>' CssClass="form-control" Placeholder="Services"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductServiceslist1" runat="server" Text='<%# Bind("ServiceName") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtServices" runat="server" Text="" CssClass="form-control" Placeholder="Services"></asp:TextBox>
                                                <br />
                                                <asp:RequiredFieldValidator ID="rfv_InvoiceItem3" ControlToValidate="txtServices" Display="Dynamic" runat="server" ErrorMessage="Enter Services" Font-Size="12px" ForeColor="Red" ValidationGroup="Services"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="60px">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblDuration" runat="server" Text="Duration/Day" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDuration1" runat="server" Text='<%# Bind("Duration") %>' CssClass="form-control" Placeholder="Quantity" TextMode="Number" Style="width: 60px"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDuration1" runat="server" Text='<%# Bind("Duration") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtDuration" runat="server" Text="1" CssClass="form-control" Placeholder="Duration" TextMode="Number" Style="width: 60px"></asp:TextBox>
                                                <br />
                                                <asp:RequiredFieldValidator ID="rfv_Duration23" ControlToValidate="txtDuration" Display="Dynamic" runat="server" ErrorMessage="Enter Service Duration" ForeColor="Red" Font-Size="12px" ValidationGroup="Services"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditDescription" runat="server" Text='<%# Bind("Description") %>' TextMode="MultiLine" CssClass="form-control" Placeholder="Description"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescription1" runat="server" Text='<%# Bind("Description") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Text="" CssClass="form-control" Placeholder="Description"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="60px">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblQuantity" runat="server" Text="Quantity" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtQty1" runat="server" Text='<%# Bind("Quantity") %>' CssClass="form-control" Placeholder="Quantity" TextMode="Number" Style="width: 60px" AutoPostBack="true" OnTextChanged="txtQty1_TextChanged2"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblQuantity1" runat="server" Text='<%# Bind("Quantity") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtServiceFoterrQty" runat="server" Text="1" CssClass="form-control" Placeholder="Quantity" TextMode="Number" Style="width: 60px" AutoPostBack="true" OnTextChanged="txtServiceFoterrQty_TextChanged"></asp:TextBox>
                                                <br />
                                                <asp:RequiredFieldValidator ID="rfv_Qty3" ControlToValidate="txtServiceFoterrQty" Display="Dynamic" runat="server" ErrorMessage="Enter Quantity" ForeColor="Red" Font-Size="12px" ValidationGroup="Services"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="150px">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblPrice" runat="server" Text="Price" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtPrice1" runat="server" Text='<%# Bind("Price") %>' CssClass="form-control" Placeholder="Service Price" AutoPostBack="true" OnTextChanged="txtPrice1_TextChanged1"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrice1" runat="server" Text='<%# Bind("Price") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtServicePrice" runat="server" Text="" CssClass="form-control" Placeholder="Service Price" AutoPostBack="true" OnTextChanged="txtServicePrice_TextChanged"></asp:TextBox>
                                                <br />
                                                <asp:RequiredFieldValidator ID="rfv_Price3" ControlToValidate="txtServicePrice" Display="Dynamic" runat="server" ErrorMessage="Enter Service Price" ForeColor="Red" Font-Size="12px" ValidationGroup="Services"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblAmontname" runat="server" Text="Amount" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblEditAmontService" runat="server" Text='<%# Bind("TotalAmont") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmont1" runat="server" Text='<%# Bind("TotalAmont") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblAmont" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="110px">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="btnOption" runat="server" Text="" ValidationGroup="setting"><i class="ti ti-settings"></i></asp:LinkButton>
                                            </HeaderTemplate>
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CausesValidation="false" CommandName="Update" TabIndex="18" Font-Size="12px"></asp:LinkButton>
                                                <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CausesValidation="false" CommandName="Cancel" TabIndex="19" Font-Size="12px"></asp:LinkButton>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEditServices" runat="server" CausesValidation="false" CommandName="Edit" CssClass="btn btn-sm btn-rounded btn-success" ValidationGroup="UpdateService" Text="" Visible="false"><i class="ti ti-edit"></i></asp:LinkButton>
                                                &nbsp;&nbsp;&nbsp;
                                                                            <asp:LinkButton ID="btnDeleteServices" runat="server" CausesValidation="false" CommandName="Delete" CssClass="btn btn-sm btn-rounded btn-danger" ValidationGroup="DelService" Text="" Visible="false"><i class="ti ti-trash"></i></asp:LinkButton>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:LinkButton ID="btnAddServices" runat="server" CausesValidation="false" CssClass="btn btn-sm btn-rounded btn-info" Text="" OnClick="btnAddServices_Click" TabIndex="9" ValidationGroup="Service"><i class="ti ti-check"></i></asp:LinkButton>
                                                &nbsp;&nbsp;&nbsp;
                                                                            <asp:LinkButton ID="btnCancelServices" runat="server" CausesValidation="false" CssClass="btn btn-sm btn-rounded btn-danger" ValidationGroup="CanccelService" Text="" OnClick="btnCancelServices_Click"><i class=" ti ti-clear-all"></i></asp:LinkButton>

                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6"></div>
                                <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6 text-end">
                                    <i class="ti ti-star text-info"></i>&nbsp;<asp:Label ID="lblServiceAmount" runat="server" Text="Total Services Amount :" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp; &nbsp;
                                                                       <asp:Label ID="lblTotalServiceAmount" runat="server" Text="" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />
                            <h5>Purchase Order Costing</h5>
                            <hr />
                            <div class="row">
                                <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6">
                                    <i class="ti ti-star text-info"></i>&nbsp;<asp:Label ID="lblDuration" runat="server" Text="Purchase Order Complete Duration:" Font-Size="12px" Font-Bold="true" ForeColor="Blue"></asp:Label>&nbsp; &nbsp;
                                                                       <asp:Label ID="lblDurationDays" runat="server" Text="" Font-Size="12px"></asp:Label>
                                </div>
                                <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6 text-end">
                                    <i class="ti ti-star text-info"></i>&nbsp;<asp:Label ID="lblTotalcost" runat="server" Text="Purchase Order Cost :" Font-Size="12px" Font-Bold="true" ForeColor="Blue"></asp:Label>&nbsp; &nbsp;
                                    <asp:Label ID="lblTotalAmountProcu" runat="server" Text="" Font-Size="12px"></asp:Label>

                                    &nbsp;
                                   <asp:Label ID="lblServicelistTotal" runat="server" Text="" Font-Size="12px"></asp:Label>

                                    <br />
                                    <i class="ti ti-star text-info"></i>&nbsp;<asp:Label ID="lblTotalCost5" runat="server" Text="Total Purchase Order Cost :" Font-Size="12px" Font-Bold="true" ForeColor="Blue"></asp:Label>&nbsp; &nbsp;
                                                                    <asp:Label ID="lblTotalProjectCost" runat="server" Text="" Font-Size="12px" ForeColor="Blue"></asp:Label>

                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <center>
                                    <%--<asp:LinkButton ID="linkbtnsInventory" runat="server" CssClass="btn btn-sm btn-primary" CausesValidation="false" Text="Send Prelist To Distribution" Font-Size="12px" OnClick="linkbtnsInventory_Click"></asp:LinkButton>--%>
                                </center>
                            </div>

                        </div>
                        <br />
                    </div>
                </div>

            </div>
        </div>


        <%--  </div>--%>


        <div class="row">
            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                <div class="card">
                    <div class="card-body">

                        <div class="col-md-12 col-sm-12 col-lg-12">
                            <div class="mb-2">
                                <asp:Label ID="lblClientNote" runat="server" Text="Client Note" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtClientNote" runat="server" TextMode="MultiLine" CssClass="form-control" Placeholder="Enter Client Note"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-lg-12">
                            <div class="mb-2">
                                <asp:Label ID="lblTermsConditions" runat="server" Text="Terms & Conditions" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtTermsAndConditions" runat="server" TextMode="MultiLine" CssClass="form-control" Placeholder="Enter Terms & Conditions"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-lg-12">

                            <div class="mb-2">
                                <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-sm btn-primary" ValidationGroup="PurchaseOrder" Text="Save" OnClick="Btn_Save_Click" />

                                &nbsp;&nbsp;                         
                            <asp:Button ID="Btn_Clear" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="Clear" OnClick="Btn_Clear_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
