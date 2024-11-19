<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="New_Tender.aspx.cs" Inherits="MatoshreeProject.New_Tender" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                    <h5 class="font-weight-medium mb-0">New Tender</h5>
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item">
                                <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                                </a>
                            </li>
                            <li class="breadcrumb-item">
                                <a class="text-muted text-decoration-none" href="Tender.aspx">Tender
                                </a>
                            </li>
                            <li class="breadcrumb-item text-muted" aria-current="page" href="#">New Tender</li>
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
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-lg-6 border-right">
                                <h6 class="text-purple">General Options </h6>
                                <hr />
                                <asp:UpdatePanel ID="UpdatePanelddlState" runat="server">
                                    <ContentTemplate>
                                        <div class="col-md-12 col-sm-12 col-lg-12">

                                            <div class="mb-2">
                                                <asp:Label ID="lnltenderid" runat="server" Text="" CssClass=" " Visible="false"></asp:Label>
                                                <asp:Label ID="lblCustomers" runat="server" Text="Customer" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                                <asp:DropDownList ID="ddlCustomers" runat="server" CssClass="form-control form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCustomers_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfv_Customer" runat="server" ControlToValidate="ddlCustomers" ErrorMessage="Select Customer" ForeColor="Red" InitialValue="0" Display="Dynamic" ValidationGroup="Tender1" Font-Size="12px"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lblProjects" runat="server" Text="Project" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                                <asp:DropDownList ID="ddlProjects" runat="server" CssClass="form-control form-select">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlProjects" ErrorMessage="Select Project" ForeColor="Red" Display="Dynamic" InitialValue="0" ValidationGroup="Tender1" Font-Size="12px"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlCustomers" EventName="SelectedIndexChanged" />

                                    </Triggers>
                                </asp:UpdatePanel>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="mb-2">
                                            <asp:Label runat="server" Text="Tender Number" Font-Bold="true" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:Label ID="lblInitialNumber" runat="server" Text="-" Font-Bold="true" CssClass="form-control text-purple" ReadOnly="true"></asp:Label>
                                            <asp:TextBox ID="txtTenderNumber" runat="server" CssClass="form-control text-purple" placeholder="Enter Tender Number"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_TenderNumber" ControlToValidate="txtTenderNumber" Display="Dynamic" runat="server" ErrorMessage="Enter Tender Number" ForeColor="Red" ValidationGroup="Tender1" Font-Size="12px"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="mb-2">
                                            <asp:Label runat="server" Text="Tender Name" Font-Bold="true" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:TextBox ID="txttendername" runat="server" CssClass="form-control" placeholder=" Enter Tender Name"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txttendername" Display="Dynamic" runat="server" ErrorMessage="Enter Tender Name" ForeColor="Red" ValidationGroup="Tender1" Font-Size="12px"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblTenderDate" runat="server" Text="Tender Date" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                    <asp:TextBox ID="txtTenderDate" CssClass="form-control" runat="server" type="date"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTenderDate" ErrorMessage="Enter Tender Date" ForeColor="Red" ValidationGroup="Tender1" Font-Size="12px" InitialValue="0"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="mb-2">
                                                    <asp:Label ID="lbliddingdate" runat="server" Text="Bid-End Date" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                    <asp:TextBox ID="txtExpiryDate" type="date" CssClass="form-control" Style="display: inline-block;" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredExpiryDate" ControlToValidate="txtExpiryDate" Display="Dynamic" runat="server" ErrorMessage="Enter Bidding Date" ForeColor="Red" ValidationGroup="Tender1" Font-Size="12px"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="mb-2">
                                            <asp:Label ID="lblEstimate" runat="server" Text="Tender Value" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:TextBox ID="txtestimate" CssClass="form-control" runat="server" Placeholder="Enter Tender Value" type="number"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtestimate" Display="Dynamic" runat="server" ErrorMessage="Enter Tender Value" ForeColor="Red" ValidationGroup="Tender1" Font-Size="12px"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblperiodofwork" runat="server" Text="Period Of Work" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                    <asp:TextBox ID="txtperiodofwork" CssClass="form-control" type="number" runat="server" Placeholder="Enter Period Of Work"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtperiodofwork" Display="Dynamic" runat="server" ErrorMessage="Enter Period Of Work" ForeColor="Red" ValidationGroup="Tender1" Font-Size="12px"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblpaymentmode" runat="server" Text="Payment Mode" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                                    <asp:DropDownList ID="ddlpaymentmode" runat="server" CssClass="form-select">
                                                        <asp:ListItem Value="0">Select Payment Mode</asp:ListItem>
                                                        <asp:ListItem Value="1">Bank</asp:ListItem>
                                                        <asp:ListItem Value="2">Cash</asp:ListItem>
                                                        <asp:ListItem Value="3">Online</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="ddlpaymentmode" Display="Dynamic" runat="server" ErrorMessage="Select Payment Mode" ForeColor="Red" ValidationGroup="Tender1" Font-Size="12px" InitialValue="0"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                        <div class="row">
                                            <div class="col-md-6 col-sm-6 col-lg-6">
                                                <div class="mb-2">
                                                    <h6>Location Address</h6>
                                                </div>
                                            </div>
                                            <div class="col-md-12 col-sm-12 col-lg-12">
                                                <div class="mb-2">
                                                    <asp:Label ID="lbladdressLine1" runat="server" Text="Address Line1" Font-Bold="true" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                                    <asp:TextBox ID="txtaddressLine1" runat="server" name="StreetLocation1" CssClass="form-control" placeholder="Address Line1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="txtaddressLine1" Display="Dynamic" runat="server" ErrorMessage="Enter Address Line1" ForeColor="Red" ValidationGroup="Tender1" Font-Size="12px"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>
                                            <div class="col-md-12 col-sm-12 col-lg-12">
                                                <div class="mb-2">
                                                    <asp:Label ID="lbladdress2" runat="server" Text="Address Line2" Font-Bold="true" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                                    <asp:TextBox ID="txtaddressline2" runat="server" name="StreetLocation2" CssClass="form-control" placeholder="Address Line2"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ControlToValidate="txtaddressline2" Display="Dynamic" runat="server" ErrorMessage="Enter Address Line2" ForeColor="Red" ValidationGroup="Tender1" Font-Size="12px"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>
                                            <div class="col-md-12 col-sm-12 col-lg-12">
                                                <div class="row">
                                                    <div class="col-md-6 col-sm-6 col-lg-6">
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblvillage" runat="server" Text="Village" Font-Bold="true" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                                            <asp:TextBox ID="txtvillage" runat="server" CssClass="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="txtvillage" Display="Dynamic" runat="server" ErrorMessage="Enter Village" ForeColor="Red" ValidationGroup="Tender1" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6 col-sm-6 col-lg-6">
                                                        <div class="mb-2">
                                                            <asp:Label ID="lbllocationcountry" runat="server" Text="Country" Font-Bold="true" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                                            <asp:DropDownList ID="ddllocationcountry" runat="server" CssClass="form-select" name="CountryBilling">
                                                                <asp:ListItem Value="0">Select Country</asp:ListItem>
                                                                <asp:ListItem Value="India">India</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ddllocationcountry" Display="Dynamic" runat="server" ErrorMessage="Select Country" ForeColor="Red" ValidationGroup="Tender1" Font-Size="12px" InitialValue="0"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 col-sm-12 col-lg-12">
                                                <asp:UpdatePanel ID="UpdatePanelAddress" runat="server">
                                                    <ContentTemplate>
                                                        <div class="row">
                                                            <div class="col-md-6 col-sm-6 col-lg-6">
                                                                <div class="mb-2">
                                                                    <asp:Label ID="lbllocationstate" runat="server" Text="State" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                                    <asp:DropDownList ID="ddllocationstate" runat="server" CssClass="form-control form-select" AutoPostBack="true" OnSelectedIndexChanged="ddllocationstate_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddllocationstate" Display="Dynamic" runat="server" ErrorMessage="Select State" ForeColor="Red" ValidationGroup="Tender1" Font-Size="12px" InitialValue="0"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 col-sm-6 col-lg-6">
                                                                <div class="mb-2">
                                                                    <asp:Label ID="lbllocationdistrict" runat="server" Text="District" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                                    <asp:DropDownList ID="ddllocationdistrict" runat="server" CssClass="form-control form-select" AutoPostBack="true" OnSelectedIndexChanged="ddllocationdistrict_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="ddllocationdistrict" Display="Dynamic" runat="server" ErrorMessage="Select District" ForeColor="Red" ValidationGroup="Tender1" Font-Size="12px"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                          <div class="row">
                                                    <div class="col-md-6 col-sm-6 col-lg-6">
                                                        <div class="mb-2">
                                                            <asp:Label ID="lbllocationcity" runat="server" Text="City/Taluka" CssClass="form-label"></asp:Label>
                                                            <asp:DropDownList ID="ddllocationcity" runat="server" CssClass="form-control form-select">
                                                            </asp:DropDownList>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-6 col-sm-6 col-lg-6">
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblflatno" runat="server" Text="Flat/Block/RoadNo" Font-Bold="true" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                                            <asp:TextBox ID="txtlocationflatno" runat="server" placeholder="Flat/Block/RoadNo" CssClass="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtlocationflatno" Display="Dynamic" runat="server" ErrorMessage="Enter Flat/Block/RoadNo" ForeColor="Red" ValidationGroup="Tender1" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddllocationstate" EventName="SelectedIndexChanged" />
                                                        <asp:AsyncPostBackTrigger ControlID="ddllocationdistrict" EventName="SelectedIndexChanged" />

                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                          
                                            <div class="col-md-6 col-sm-6 col-lg-6">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblpincode" runat="server" Text="Pin Code" Font-Bold="true" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                                    <asp:TextBox ID="txtlocationpincode" runat="server" placeholder="Pin Code" CssClass="form-control" MaxLength="6"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtlocationpincode" Display="Dynamic" runat="server" ErrorMessage="Enter Pincode" ForeColor="Red" ValidationGroup="Tender1" Font-Size="12px"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <h6 class="text-purple">Advanced Options</h6>
                                <hr />
                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="mb-2">
                                            <asp:Label ID="lblSalesAgent" runat="server" Text="Sales Agent" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                            <asp:DropDownList ID="ddlSalesAgent" runat="server" CssClass="form-control form-select">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="ddlSalesAgent" ErrorMessage="Select Sales Agent" ForeColor="Red" Display="Dynamic" InitialValue="0" ValidationGroup="Tender1" Font-Size="12px"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                        <div class="mb-2">
                                            <asp:Label ID="Lbldesc" runat="server" Text="Work Description" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                            <asp:TextBox ID="txtDescription1" runat="server" placeholder="Description" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtDescription1" ErrorMessage="Enter Description" ForeColor="Red" ValidationGroup="Tender1" Font-Size="12px"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblPublishDate" runat="server" Text="Publish Date" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                                    <asp:TextBox ID="txtpublishDate" CssClass="form-control" runat="server" Placeholder="Enter Publish Date" type="date"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtpublishDate" ErrorMessage="Enter Publish Date" ForeColor="Red" ValidationGroup="Tender1" Font-Size="12px"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblprebid" runat="server" Text="Pre-bid Meeting Date" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                                    <asp:TextBox ID="txtprebid" CssClass="form-control" runat="server" Placeholder="Enter pre-bid Meeting Date" type="date"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtprebid" ErrorMessage="Enter pre-bid Meeting Date" ForeColor="Red" ValidationGroup="Tender1" Font-Size="12px"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                        <div class="mb-2">
                                            <asp:Label ID="lblprebidMeetadd" runat="server" Text="Pre-bid Meeting Address" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                            <asp:TextBox ID="txtprebidMeetadd" runat="server" placeholder="Enter Bidding Meeting Address" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtprebidMeetadd" ErrorMessage="Enter pre-bid Meeting Address" ForeColor="Red" ValidationGroup="Tender1" Font-Size="12px"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <asp:UpdatePanel ID="UpdatePaneAuth" runat="server">
                                        <ContentTemplate>
                                            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblAuthorityname" runat="server" Text="Authority Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:DropDownList ID="ddlauthname" runat="server" CssClass="form-control form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlauthname_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="ddlauthname" ErrorMessage="Select Authority Name" ForeColor="Red" ValidationGroup="Tender1" Font-Size="12px" InitialValue="0" Display="dynamic"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblAuthposition" runat="server" Text="Authority Position" CssClass="form-label"></asp:Label>
                                                            <asp:TextBox ID="txtAuthposition1" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblAuthemail" runat="server" Text="Authority Email" CssClass="form-label"></asp:Label>
                                                            <asp:TextBox ID="txtAuthemail" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblAuthcontno" runat="server" Text="Authority Contact Number" CssClass="form-label"></asp:Label>
                                                            <asp:TextBox ID="txtAuthcontno" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblauthorityaddress" runat="server" Text="Authority Address" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                    <asp:TextBox ID="txtauthorityaddress" CssClass="form-control" runat="server" Placeholder="Enter Authority Address"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtauthorityaddress" ErrorMessage="Enter Authority Address" ForeColor="Red" ValidationGroup="Tender1" Font-Size="12px"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlauthname" EventName="SelectedIndexChanged" />

                                        </Triggers>
                                    </asp:UpdatePanel>

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

                                            <div class="input-group">
                                                <asp:FileUpload ID="FileUpload" runat="server" Text="" CssClass="form-control" />
                                                <asp:Button ID="Btn_Upload" runat="server" Text="Upload" CssClass="btn btn-primary btn-sm font-medium rounded-end" OnClick="Btn_Upload_Click" />
                                            </div>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="table-responsive">
                                                <asp:GridView ID="GridTenderFile" runat="server" ScrollBars="Both" CssClass="table border  table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                    ClientIDMode="Static" ShowHeader="false" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblTenderID" runat="server" Text="FileName" CssClass=" " Visible="false"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTenderID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Visible="false" CssClass="form-label"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblTenderFileName" runat="server" Text="FileName" CssClass="form-label"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTenderFileName1" runat="server" Text='<%# Bind("FileName") %>' Font-Bold="false" CssClass="form-label"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="DocumentType" runat="server" Text="Document_Type" CssClass="form-label"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDocument_Type" runat="server" Text='<%# Bind("DocumentType") %>' Font-Bold="false" CssClass="form-label"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnDeleteTender" runat="server" ForeColor="Red" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteTender_Click" CausesValidation="false" Visible="false"><i class="ti ti-trash"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                            </EditItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lblque" runat="server" Text="Tender Question" CssClass="form-label"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                            <div class="mb-2">
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtque" runat="server" placeholder="Enter Your Question" CssClass="form-control" Style="width: 390px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfv_Tender" ControlToValidate="txtque" Display="Dynamic" runat="server" ErrorMessage="Enter Your Question" ForeColor="Red" ValidationGroup="TenderAdd" Font-Size="12px"></asp:RequiredFieldValidator>
                                                    <asp:Button ID="Btn_TenderQue" runat="server" Text="Add" CssClass="btn btn-sm btn-primary" OnClick="Btn_TenderQue_Click" ValidationGroup="TenderAdd" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="table-responsive">
                                                <asp:GridView ID="GridTenderQue" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                    ClientIDMode="Static" ShowHeader="false" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblTenderQueID" runat="server" Text="FileName" CssClass="form-label" Visible="false"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTenderQueID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Visible="false" CssClass="form-label"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblTenderQueName" runat="server" Text="FileName" CssClass="form-label"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTenderQueName1" runat="server" Text='<%# Bind("Question") %>' Font-Bold="false" CssClass="form-label"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnDeleteTenderQue" runat="server" ForeColor="Red" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteTenderQue_Click" CausesValidation="false" Visible="true"><i class="ti ti-trash"></i></asp:LinkButton>
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



            <div class="row">
                <div class="card">
                    <div class="card-body">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="mb-2">
                                            <div class="input-group">
                                                <asp:Label ID="Label11" runat="server"></asp:Label>
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
                                    <div class="col-md-3">
                                        <div class="mb-2">
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-select form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3"></div>


                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="alert alert-warning" role="alert" id="msgdiv" runat="server" visible="false">
                                            <asp:Label ID="lblMsg1" runat="server" Text="" Visible="false" Font-Bold="false" ForeColor="Red" ValidateRequestMode="Disabled"></asp:Label>
                                        </div>
                                        <div class="alert alert-info" role="alert" id="SuccessDiv1" runat="server" visible="false">
                                            <asp:Label ID="lblMsg" runat="server" Text="" Visible="false" Font-Bold="false" ForeColor="Blue" ValidateRequestMode="Disabled"></asp:Label>
                                        </div>

                                    </div>
                                </div>
                                <br />
                                <!-- Table -->
                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="table-responsive">
                                        <asp:GridView ID="GridCalculate" runat="server" ScrollBars="Both" CssClass="table border table-bordered  table-hover" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                            ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" FooterStyle-BackColor="#f8f9fa" HeaderStyle-Font-Bold="true" ShowFooter="true" DataKeyNames="ID">
                                            <Columns>
                                                <asp:TemplateField Visible="false" HeaderStyle-Font-Size="12px">

                                                    <ItemTemplate>
                                                        <asp:Label ID="lblItemid" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Font-Size="12px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblItem" runat="server" Text="Item" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblItem1" runat="server" Text='<%# Bind("Item") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtItem" runat="server" TextMode="MultiLine" Text='<%# Bind("Description") %>' CssClass="form-control" Placeholder="Description" Style="width: auto"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_TenderItem" ControlToValidate="txtItem" Display="Dynamic" runat="server" ErrorMessage="Please Select Item" ForeColor="Red" ValidationGroup="ItemTender" Font-Size="12px"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Font-Size="12px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescription1" runat="server" Text='<%# Bind("Description") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Text='<%# Bind("Long_Description") %>' CssClass="form-control" Placeholder="Long Description" Style="width: auto"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="120px" HeaderStyle-Font-Size="12px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblQuantity" runat="server" Text="Quantity" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtQty1" runat="server" Text='<%# Bind("Qnty") %>' CssClass="form-control" Placeholder="Quantity" TextMode="Number" Style="width: 90px" Visible="false" OnTextChanged="txtQty1_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                        <asp:Label ID="lblQuantity1" runat="server" Text='<%# Bind("Qnty") %>' Font-Bold="false" Visible="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtQty" runat="server" Text="1" CssClass="form-control" Placeholder="Quantity" TextMode="Number" Style="width: 105px"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="50px" HeaderStyle-Font-Size="12px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblRate" runat="server" Text="Rate" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>

                                                        <asp:Label ID="lblRate1" runat="server" Text="" Font-Bold="false" Visible="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblRateF" runat="server" Text="" CssClass="form-label"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-Font-Size="12px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblAmontname" runat="server" Text="Amount" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAmont1" runat="server" Text='<%# Bind("TotalAmont") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Font-Size="12px">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="btnOption" runat="server" Text="" ValidationGroup="setting" CssClass=""><i class="ti ti-settings"></i></asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDeleteItemCal" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-rounded btn-danger" ValidationGroup="DelItemTender" Text="" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteItemCal_Click" CausesValidation="false" Visible="false"><i class="ti ti-trash"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:LinkButton ID="btnAddTenderItem" runat="server" CssClass="btn btn-sm btn-rounded btn-info" Text="" CausesValidation="false" OnClick="btnAddTenderItem_Click" TabIndex="9" ValidationGroup="ItemTender"><i class="ti ti-check"></i></asp:LinkButton>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                     </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlItem" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>



            <div class="row">
                <div class="card">
                    <div class="card-body">
                        <div class="col-md-12 col-sm-12 col-lg-12">
                            <div class="mb-2">
                                <asp:Label ID="lblClientNote" runat="server" Text="Client Note" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtClientNote" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-lg-12">
                            <div class="mb-2">
                                <asp:Label ID="lblTermsConditions" runat="server" Text="Terms & Conditions" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtTermsAndConditions" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-lg-12">

                            <div class="mb-2">
                                <asp:Button ID="btn_SubmitTender" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="Tender1" OnClick="btn_SubmitTender_Click" />
                                &nbsp;&nbsp;
                             
                               <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="Clear" OnClick="btnClear_Click" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>



            <!-- Modal -->
            <div class="row">
                <div class="col-md-6">
                    <!-- Modal -->
                    <div class="modal fade" id="ItemID" data-bs-backdrop="static"
                        data-bs-keyboard="false" tabindex="-1" aria-labelledby="scroll-long-inner-modal"
                        aria-hidden="true">
                        <div class="modal-dialog modal-dialog-scrollable">
                            <div class="modal-content">
                                <div class="modal-header d-flex align-items-center">
                                    <h4 class="modal-title" id="myLargeModalLabel"></h4>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">

                                    <h5 class="text-purple">Add Item</h5>
                                    <hr />
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="mb-2">
                                                <asp:Label ID="lbl_Description" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                <asp:TextBox ID="txt_Description" runat="server" Font-Size="12px" CssClass="form-control" placeholder="Enter Description"></asp:TextBox>
                                            </div>

                                            <div class="mb-2">
                                                <asp:Label ID="lbl_Rate" runat="server" Text="Rate" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                <asp:TextBox ID="txt_Rate" runat="server" CssClass="form-control" Font-Size="12px" placeholder="Enter Rate"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Rate" runat="server" ErrorMessage="Enter Rate" Display="Dynamic" ControlToValidate="txt_Rate" ForeColor="Red" ValidationGroup="SaveITEM" Font-Size="12px"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="mb-2">
                                                <asp:Label ID="lblHSNCode" runat="server" Text="HSNCode" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                <asp:TextBox ID="txtHSNCode" runat="server" CssClass="form-control" Font-Size="12px" placeholder="Enter HSNCode"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtHSNCode" ErrorMessage="Enter HSNCode" ForeColor="Red" ValidationGroup="SaveITEM" Font-Size="12px"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="mb-2">
                                                <asp:Label ID="lbl_LongDescription" runat="server" Text="Long Description" CssClass="form-label"></asp:Label>
                                                <asp:TextBox ID="txt_LongDescription" TextMode="MultiLine" runat="server" Font-Size="12px" CssClass="form-control" placeholder="Enter Long Description"></asp:TextBox>
                                            </div>

                                            <div class="mb-2">
                                                <asp:Label ID="lbl_Tax" runat="server" Text="Tax1" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                <asp:DropDownList ID="ddlTaxitem" runat="server" CssClass="form-control" Font-Size="12px" AutoPostBack="true" OnSelectedIndexChanged="ddlTaxitem_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblTaxValues1" runat="server" Font-Bold="true" Text="" Font-Size="12px" Visible="false"></asp:Label>


                                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlTaxitem" ErrorMessage="Select TAX1" InitialValue="0" ForeColor="Red" ValidationGroup="SaveITEM" Font-Size="12px"></asp:RequiredFieldValidator>

                                            </div>

                                            <div class="mb-2">
                                                <asp:Label ID="lbl_Tax2" runat="server" Text="Tax2" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                <asp:DropDownList ID="ddlTaxItem1" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTaxItem1_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblTaxValues2" runat="server" Font-Bold="true" Text="" Font-Size="12px" Visible="false"></asp:Label>

                                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlTaxItem1" ErrorMessage="Select TAX2" InitialValue="0" ForeColor="Red" ValidationGroup="SaveITEM" Font-Size="12px"></asp:RequiredFieldValidator>

                                            </div>



                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlTaxitem" EventName="SelectedIndexChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ddlTaxItem1" EventName="SelectedIndexChanged" />

                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <br />
                                <div class="modal-footer">
                                    <asp:Button ID="btnSaveItem" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="SaveITEM" OnClick="btnSaveItem_Click" />
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
                    <!-- Modal -->
                </div>
            </div>
            <!-- Modal -->
        </div>
    </div>
</asp:Content>
