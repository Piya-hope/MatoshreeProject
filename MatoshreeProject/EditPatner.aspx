<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="EditPatner.aspx.cs" Inherits="MatoshreeProject.EditPatner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="font-weight-medium mb-0">Edit Patner</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Patner.aspx">Patner
                            </a>
                        </li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="EditPatner.aspx">Edit Patner</li>
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
            <div class="col-md-2 col-sm-2 col-lg-2">
                <%--<div class="card">
                    <div class="card-body">
                        <h5>Add New Partner</h5>
                        <hr />
                        <a class="sidebar-link" href="NewCustomer.aspx">Profile</a>
                    </div>
                </div>--%>
            </div>

            <div class="col-md-9 col-sm-9 col-lg-9">
                <div class="card">
                    <div class="card-body">
                        <h6 class="text-purple">Profile</h6>
                        <hr />
                        <ul class="nav nav-tabs" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link active" data-bs-toggle="tab" href="#home" role="tab"><span class="hidden-sm-up"></span>
                                    <span class="hidden-sm-down">Customer Details</span></a>
                                <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" data-bs-toggle="tab" href="#profile" role="tab"><span class="hidden-sm-up"></span>
                                    <span class="hidden-sm-down">Address</span></a>
                            </li>
                        </ul>
                        <br />
                        <div class="tab-content tabcontent-border">
                            <div class="tab-pane active" id="home" role="tabpanel">

                                <div class="p-20">
                                    <div class="row">
                                        <div class="col-md-6 col-sm-6 col-lg-6">
                                            <div class="mb-2">
                                                <asp:Label ID="lblCompany" runat="server" Text="Partner Name" Font-Bold="true" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                <asp:TextBox ID="txtCompany" runat="server" CssClass="form-control" placeholder="Enter Patner Name"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtCompany" ErrorMessage="Enter Patner Name" ForeColor="Red" ValidationGroup="Validate" Font-Size="12px"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="mb-2">
                                                <asp:Label ID="lblPhone" for="Phone" runat="server" Text="Phone" Font-Bold="true" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                <asp:TextBox ID="txtPhone" runat="server" name="phone" CssClass="form-control" placeholder="Enter Phone Number" MaxLength="10"></asp:TextBox>
                                                <div class="validate">
                                                    <asp:RequiredFieldValidator ID="rfv_Phone" runat="server" Display="Dynamic" ControlToValidate="txtPhone" ErrorMessage="Enter 10 digit Phone Number" ForeColor="Red" ValidationGroup="Validate" Font-Size="12px"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="Regulexphone" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone Number Invalid" ForeColor="Red" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$" ValidationGroup="Validate"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="mb-2">
                                                <asp:Label ID="lblGSTNumber" for="GSTNumber" runat="server" Text="GST Number" Font-Bold="true" CssClass="form-label"></asp:Label>
                                                <asp:TextBox ID="txtGSTNumber" runat="server" name="gstnumber" CssClass="form-control" placeholder="Enter GST Number" MaxLength="15" ValidateRequestMode="Enabled"></asp:TextBox>
                                                <%--  <asp:RequiredFieldValidator ID="rfv_GSTNumber" runat="server" Display="Dynamic" ControlToValidate="txtGSTNumber" ValidationExpression="^ ([a-zA-Z0-9_.-])+@ (([a-zA-Z0-9-])+.)+ ([a-zA-Z0-9] {2,4}‌​)+$" ErrorMessage="Enter Alphanumeric GST Number.." ForeColor="Red" ValidationGroup="Validate"  Font-Size="12px"></asp:RequiredFieldValidator> --%>
                                                <%--<asp:RegularExpressionValidator ID="Reg_Exp_Val_GST" ControlToValidate="txtGSTNumber" Display="Dynamic" ValidationExpression="^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$" runat="server" ErrorMessage="Enter only Alphanumeric Charecter" ForeColor="Red" ValidationGroup="Validate"></asp:RegularExpressionValidator>--%>
                                            </div>
                                            <div class="mb-2">
                                                <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                <asp:TextBox ID="txtDescription" runat="server" placeholder="Enter Description" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                            </div>



                                        </div>
                                        <div class="col-md-6 col-sm-6 col-lg-6">
                                            <div class="mb-2">
                                                <asp:Label ID="lblEmail" for="Email" runat="server" Text="Email" Font-Bold="true" CssClass="form-label"></asp:Label>
                                                <asp:TextBox ID="txtEmail" runat="server" name="Email" CssClass="form-control" placeholder="Please enter Email.."></asp:TextBox>
                                            </div>
                                            <div class="mb-2">
                                                <asp:Label ID="lblAltphone" for="AlternativePhone" runat="server" Text="Alternative Phone" Font-Bold="true" CssClass="form-label"></asp:Label>
                                                <asp:TextBox ID="txtAltphone" runat="server" name="Altphone" CssClass="form-control" placeholder="Enter AlternativePhone Number" MaxLength="10"></asp:TextBox>
                                                <div class="validate">

                                                    <asp:RegularExpressionValidator ID="Altphone" runat="server" ControlToValidate="txtAltphone" ErrorMessage="Phone Number Invalid " ForeColor="Red" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$" ValidationGroup="Validate"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <%--<div class="form-group">
                                                <asp:Label ID="lblState" runat="server" Text="State" Font-Bold="true" CssClass="form-label"></asp:Label>
                                                <asp:TextBox ID="txtState" runat="server" CssClass="form-control" placeholder="Please enter State.."></asp:TextBox>
                                            </div>--%>
                                            <%-- <div class="mb-2">
                                                <asp:Label ID="lblPinCode" for="PinCode" runat="server" Text="Zip Code" Font-Bold="true" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                <asp:TextBox ID="txtPinCode" runat="server" name="pincode" CssClass="form-control" placeholder="Please enter Zip Code.." MaxLength="6"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfv_PinCode" runat="server" Display="Dynamic" ControlToValidate="txtPinCode"  ErrorMessage="Enter 6 digit Pin Code." ForeColor="Red" ValidationGroup="Validate"  Font-Size="12px"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RerExprPinCode" runat="server" ControlToValidate="txtPinCode"  ErrorMessage="Enter 6 digit Pin Code." ForeColor="Red" ValidationExpression="[1-9][0-9]{5}" ValidationGroup="Validate"></asp:RegularExpressionValidator>
                                            </div>--%>
                                            <div class="mb-2">
                                                <asp:Label ID="lblpartner" runat="server" Text="Type of Patner" Font-Bold="true" CssClass="form-label"></asp:Label>
                                                <asp:DropDownList ID="ddlpartner" runat="server" CssClass="form-select">
                                                    <asp:ListItem Selected="True" Text="Select Type Of Partner" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Active Patner" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Secret Partner" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Minor Partner" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="Normal Partner" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="Sleeping Partner" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="Partner by Estoppel" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="Partner in Profits only" Value="7"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                            <div class="mb-2">
                                                <asp:Label ID="lblStatus" runat="server" Text="Status" CssClass="form-label"></asp:Label>

                                                <asp:RadioButtonList ID="RadioButtonListPatner" runat="server" TabIndex="24" Font-Size="12px">
                                                    <asp:ListItem Text="Active" Value="1" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
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
                                                    <h6>Local Address&nbsp;&nbsp;<asp:Button ID="btnCopyCustomerInfo" runat="server" Text="Same as Customer Info" CssClass="btn btn-outline-info btn-sm" OnClick="btnCopyCustomerInfo_Click" ValidationGroup="Copy" /></h6>
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
                                                    <h6>Correspond Address&nbsp;&nbsp;<asp:Button ID="btnCopyBillingInfo" runat="server" Text="Same as Billing Info" CssClass="btn btn-outline-info btn-sm" OnClick="btnCopyBillingInfo_Click" ValidationGroup="Copyas" /></h6>
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

                            <div class="mb-2">
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-sm btn-success" ValidationGroup="Validate" OnClick="btnUpdate_Click" />
                                &nbsp;&nbsp;
                            <asp:Button ID="btnClear" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" OnClick="btnClear_Click" />

                            </div>
                        </div>

                    </div>
                </div>
            </div>

            <div class="col-md-1 col-sm-1 col-lg-1">
            </div>
        </div>

    </div>
</asp:Content>
