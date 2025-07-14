<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="NewProposal.aspx.cs" Inherits="MatoshreeProject.NewProposal" %>

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
        <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="font-weight-medium mb-0">New Proposal</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Proposal.aspx">Proposal</a>
                        </li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="NewProposal.aspx">New Proposal</li>
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
                        <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6 border-right">

                            <%-- <asp:UpdatePanel ID="UpdatePanelddlState" runat="server">
                                <ContentTemplate>--%>
                            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">

                                <div class="mb-2">
                                    <asp:Label runat="server" Text="Proposal Number" Font-Bold="true" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:Label ID="lblInitialNumber" runat="server" Text="-" Font-Bold="true" CssClass="form-control text-purple"></asp:Label>
                                    <asp:TextBox ID="txtProposalNumber" runat="server" CssClass="form-control text-purple" ReadOnly="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_ProposalNumber" ControlToValidate="txtProposalNumber" Display="Dynamic" runat="server" ErrorMessage="Enter Proposal Number" ForeColor="Red" ValidationGroup="Proposal" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                                <div class="mb-2">
                                    <asp:Label ID="lblSubject" runat="server" Text="Subject" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                    <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control" placeholder="Enter Subject"></asp:TextBox>

                                </div>
                                <div class="mb-2">
                                    <asp:RequiredFieldValidator ID="rfv_Subject" runat="server" ControlToValidate="txtSubject" ErrorMessage="Enter Subject" ForeColor="Red" InitialValue="0" Display="Dynamic" ValidationGroup="Proposal" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                                <div class="mb-2">
                                    <asp:Label ID="lblRelated" runat="server" Text="Related" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:DropDownList ID="ddlRelated" runat="server" CssClass="form-control form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlRelated_SelectedIndexChanged">
                                        <asp:ListItem>Select Related</asp:ListItem>
                                        <asp:ListItem Text="Lead" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Customer" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="mb-2">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlRelated" ErrorMessage="Select Related" ForeColor="Red" Display="Dynamic" InitialValue="0" ValidationGroup="Proposal" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                                <div class="mb-2" id="LeadProposal" runat="server" visible="false">
                                    <asp:Label ID="lblLead" runat="server" Text="" CssClass="form-label"></asp:Label>
                                    <asp:DropDownList ID="ddlRelatedToCast" runat="server" CssClass="form-control form-select" OnSelectedIndexChanged="ddlRelatedToCast_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>

                                <div class="mb-2" id="projectProposal" runat="server" visible="false">
                                    <asp:Label ID="lblProject" runat="server" Text="Project" CssClass="form-label"></asp:Label>
                                    <asp:DropDownList ID="ddlProject" runat="server" CssClass="form-control form-select"></asp:DropDownList>
                                </div>
                            </div>

                            <%--  </ContentTemplate>

                            </asp:UpdatePanel>--%>

                            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                                <div class="row">
                                    <div class="col-md-6 col-xs-6 col-sm-6 col-lg-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblDate" runat="server" Text="Date" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:TextBox ID="txtDate" type="date" CssClass="form-control" Style="display: inline-block;" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rtxt_Date" ControlToValidate="txtDate" Display="Dynamic" runat="server" ErrorMessage="Select Proposal Date" ForeColor="Red" ValidationGroup="Proposal" Font-Size="12px"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-xs-6 col-sm-6 col-lg-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblOpenTill" runat="server" Text="Open Till" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txtOpenTill" type="date" CssClass="form-control" Style="display: inline-block;" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                                <div class="row">
                                    <div class="col-md-6 col-xs-6 col-sm-6 col-lg-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblCurrency" runat="server" Text="Currency" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:DropDownList ID="ddlCurrency" runat="server" CssClass="form-control form-select">
                                                <asp:ListItem>Select Currency</asp:ListItem>
                                                <asp:ListItem Text="INR" Value="INR"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlCurrency" Display="Dynamic" runat="server" ErrorMessage="Select Currency" ForeColor="Red" ValidationGroup="Proposal" Font-Size="12px"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-xs-6 col-sm-6 col-lg-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblDiscountType" runat="server" Text="Discount Type" CssClass="form-label"></asp:Label>
                                            <asp:DropDownList ID="ddlDiscountType" runat="server" CssClass="form-control form-select">
                                                <asp:ListItem>Select Discount Type</asp:ListItem>
                                                <asp:ListItem Text="No Discount" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Before Tax" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="After Tax" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="col-md-6 col-xs-6 col-sm-6 col-lg-6">

                            <div class="row">
                                <div class="col-md-6 col-xs-6 col-sm-6 col-lg-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblStatus" runat="server" Text="Status" CssClass="form-label"></asp:Label>
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control form-select">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="mb-2">
                                        <asp:RequiredFieldValidator ID="rfv_Status" runat="server" ControlToValidate="ddlStatus" ErrorMessage="Select Status" InitialValue="0" ForeColor="Red" Display="Dynamic" ValidationGroup="Proposal" Font-Size="12px"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-6 col-xs-6 col-sm-6 col-lg-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblAssigned" runat="server" Text="Assigned" CssClass="form-label"></asp:Label>
                                        <asp:DropDownList ID="ddlAssigned" runat="server" CssClass="form-control form-select">
                                        </asp:DropDownList>
                                    </div>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                                    <div class="mb-2">
                                        <asp:Label ID="lblTo" runat="server" Text="To" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <asp:TextBox ID="txtTo" CssClass="form-control" runat="server" placeholder="Enter Contact Person"></asp:TextBox>
                                    </div>
                                    <div class="mb-2">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTo" ErrorMessage="Enter To" InitialValue="0" ForeColor="Red" Display="Dynamic" ValidationGroup="Proposal" Font-Size="12px"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                                    <div class="mb-2">
                                        <asp:Label ID="lblAddress" runat="server" Text="Address" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" CssClass="form-control" placeholder="Enter Address"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-xs-6 col-sm-6 col-lg-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblCountry" runat="server" Text="Country" CssClass="form-label"></asp:Label>
                                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control form-select">
                                            <asp:ListItem runat="server" Text="Select Country" Value="0"></asp:ListItem>
                                            <asp:ListItem runat="server" Text="India" Value="1"></asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>

                                <div class="col-md-6 col-xs-6 col-sm-6 col-lg-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblState" runat="server" Text="State" CssClass="form-label"></asp:Label>
                                        <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control form-select"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-xs-6 col-sm-6 col-lg-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblDistrict" runat="server" Text="District" CssClass="form-label"></asp:Label>
                                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control form-select"></asp:DropDownList>

                                    </div>
                                </div>

                                <div class="col-md-6 col-xs-6 col-sm-6 col-lg-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblCity" runat="server" Text="City" CssClass="form-label"></asp:Label>
                                        <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control form-select"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-xs-6 col-sm-6 col-lg-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblZipCode" runat="server" Text="Zip Code" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="txtZipCode" CssClass="form-control" runat="server" placeholder="Enter ZipCode"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="col-md-6 col-xs-6 col-sm-6 col-lg-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblPhone" runat="server" Text="Phone" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server" placeholder="Enter Phone Number"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-xs-6 col-sm-6 col-lg-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="Enter Email"></asp:TextBox>
                                        <asp:Label ID="lblTAxCount" runat="server" Text="" Visible="false"></asp:Label>
                                        <asp:Label ID="lblTAXCount2" runat="server" Text="" Visible="false"></asp:Label>
                                    </div>
                                </div>
                            </div>


                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-4 col-xs-4 col-sm-4 col-lg-4">
                                    <div class="input-group">
                                        <asp:DropDownList ID="ddlItem" runat="server" CssClass="form-select form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <!-- Button trigger modal -->
                                        <button type="button" class="btn btn-info btn-sm font-medium"
                                            data-bs-toggle="modal" data-bs-target="#ItemID">
                                            +
                                        </button>
                                    </div>
                                </div>
                                <div class="col-md-5 col-xs-5 col-sm-5 col-lg-5">
                                </div>

                                <div class="col-md-3 col-xs-3 col-sm-3 col-lg-3">
                                    <div class="input-group">
                                        <asp:Label ID="Label12" runat="server" Text="Show Qty As: " CssClass="form-label"></asp:Label>
                                        <asp:RadioButtonList ID="RadioButtonListQty" runat="server" RepeatDirection="Horizontal" class="round" CssClass="ms-2">
                                            <asp:ListItem Text="Qty" Value="1" Selected="True"></asp:ListItem>
                                            <%--   <asp:ListItem Text="Hours" Value="2"></asp:ListItem>
                                  <asp:ListItem Text="Qty/hours" Value="3"></asp:ListItem>--%>
                                        </asp:RadioButtonList>

                                    </div>
                                </div>
                            </div>
                            <br />


                            <div class="row">
                                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                                    <div class="alert alert-warning" role="alert" id="msgdiv" runat="server" visible="false">
                                        <asp:Label ID="lblMsg1" runat="server" Text="" Visible="false" Font-Bold="false" Font-Size="12px" ForeColor="Red" ValidateRequestMode="Disabled"></asp:Label>
                                    </div>
                                    <div class="alert alert-info" role="alert" id="SuccessDiv1" runat="server" visible="false">
                                        <asp:Label ID="lblMsg" runat="server" Text="" Visible="false" Font-Bold="false" Font-Size="12px" ForeColor="Blue" ValidateRequestMode="Disabled"></asp:Label>
                                    </div>

                                </div>
                            </div>

                            <!-- Table -->

                            <div class="row">
                                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="GridProposal" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4"
                                            ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" FooterStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="true" OnRowDataBound="GridProposal_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-Width="130px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblItem" runat="server" Text="Item" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblItem1" runat="server" Text='<%# Bind("ProposalItem") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtItem" runat="server" TextMode="MultiLine" Text="" CssClass="form-control" Placeholder="Description" Width="130px" Font-Size="12px"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="180px" ItemStyle-Width="200px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescription1" runat="server" Text='<%# Bind("Description") %>' Font-Bold="false" Font-Size="12px" Width="180px" Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Text="" CssClass="form-control" Placeholder="Long Description" Font-Size="12px"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHSNname" runat="server" Text="HSN" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblHSN1" runat="server" Text='<%# Bind("HSN") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblHSN" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderStyle-Width="60px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblQuantity" runat="server" Text="Qnty" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtQty1" runat="server" Text='<%# Bind("Qnty") %>' AutoPostBack="true" OnTextChanged="txtQty1_TextChanged" CssClass="form-control" Placeholder="Quantity" TextMode="Number" Style="width: 60px" Visible="false" Font-Size="12px"></asp:TextBox>
                                                        <asp:Label ID="lblQuantity1" runat="server" Text='<%# Bind("Qnty") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtQty" runat="server" Text="1" CssClass="form-control" Placeholder="Quantity" TextMode="Number" Style="width: 60px" Font-Size="12px" AutoPostBack="true" OnTextChanged="txtQty_TextChanged"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="60px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblRate" runat="server" Text="Rate" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtRate1" runat="server" Text='<%# Bind("Rate") %>' CssClass="form-control" AutoPostBack="true" OnTextChanged="txtRate1_TextChanged" Placeholder="Rate" TextMode="Number" Style="width: 80px" Visible="false" Font-Size="12px"></asp:TextBox>
                                                        <asp:Label ID="lblRate1" runat="server" Text='<%# Bind("Rate") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtRate" runat="server" Text="" CssClass="form-control" Placeholder="Rate" Font-Size="12px" Width="80px" AutoPostBack="true" OnTextChanged="txtRate_TextChanged"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblSubAmont" runat="server" Text="SubTotal" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSubAmont1" runat="server" Text='<%# Bind("SubTotal") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblSubAmont1F" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-Width="120px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblTax" runat="server" Text="GST1" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTaxValees" runat="server" Text='<%# Bind("Tax1Rate") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblTax1" runat="server" Text='<%# Bind("Tax1Name") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                        <asp:DropDownList ID="ddlTaxCost" runat="server" CssClass="form-control" DataTextField="" AutoPostBack="true" OnSelectedIndexChanged="ddlTaxCost_SelectedIndexChanged" Visible="false" Font-Size="12px" Style="width: 120px">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblTaxValeesF" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblTax1F" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                                        <asp:DropDownList ID="ddlTax" runat="server" CssClass="form-control" AutoPostBack="true" Style="width: 120px" OnSelectedIndexChanged="ddlTax_SelectedIndexChanged" Font-Size="12px">
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="GSTAmt" SortExpression="Tax1Amount" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="true">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblTax1Rate" runat="server" Text='<%# Bind("Tax1Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTax1Rate1" runat="server" Text='<%# Bind("Tax1Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtTax1Rate1F" runat="server" Text="" CssClass="form-control" Placeholder="Rate" Font-Size="12px" AutoPostBack="true" OnTextChanged="txtTax1Rate1F_TextChanged"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-Width="120px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblTax1A" runat="server" Text="GST2" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTaxValees1A" runat="server" Text='<%# Bind("Tax2Rate") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblTax1A" runat="server" Text='<%# Bind("Tax2Name") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                        <asp:DropDownList ID="ddlTaxCost1A" runat="server" CssClass="form-control" DataTextField="" AutoPostBack="true" OnSelectedIndexChanged="ddlTaxCost1A_SelectedIndexChanged" Visible="false" Font-Size="12px" Style="width: 120px">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblTaxValees1AF" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblTax1AF" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                                        <asp:DropDownList ID="ddlTax1A" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTax1A_SelectedIndexChanged" Style="width: 120px" Font-Size="12px">
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="GST2Amt" SortExpression="Tax2Amount" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="true">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblTax2Rate" runat="server" Text='<%# Bind("Tax2Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTax2Rate1" runat="server" Text='<%# Bind("Tax2Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtTax2Rate1F" runat="server" Text="" CssClass="form-control" Placeholder="Rate" Font-Size="12px" AutoPostBack="true" OnTextChanged="txtTax2Rate1F_TextChanged"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblAmount" runat="server" Text="GrandAmount" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("TotalAmont") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblProposalAmont" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="btnOption" runat="server" Text="" CausesValidation="false" ValidationGroup="setting"><i class="ti ti-settings"></i></asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDeleteItemCal" runat="server" CommandName="Delete" CausesValidation="true" CssClass="btn btn-sm btn-rounded btn-danger" ValidationGroup="DelItemProposal" Text="" OnClientClick="return confirm('Are you sure you want to delete?')" Visible="false" OnClick="btnDeleteItemCal_Click" ><i class="ti ti-trash"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:LinkButton ID="btnAddProposalItem" runat="server" OnClick="btnAddProposalItem_Click" CssClass="btn btn-sm btn-rounded btn-info" Text="" CausesValidation="true" TabIndex="9" ValidationGroup="ItemProposal"><i class="ti ti-check"></i></asp:LinkButton>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>


                            <br />
                            <div class="row">
                                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                                    <div class="container-fluid">
                                        <div class="container-fluid ">
                                            <%-- subcost--%>
                                            <div class="row">
                                                <asp:Table ID="Table2" runat="server" CssClass="col-md-12 col-sm-12 col-lg-12">
                                                    <asp:TableRow ID="TableRow3" runat="server" class="mb-2">
                                                        <asp:TableCell CssClass="col-md-7 col-sm-7 col-lg-7">
                                                        </asp:TableCell>
                                                        <asp:TableCell CssClass="col-md-2 col-sm-2 col-lg-2">
                                                            <asp:Label ID="lblSubTotal" CssClass="form-label me-2 ms-2" runat="server" Text="Sub Total :"></asp:Label>
                                                        </asp:TableCell>
                                                        <asp:TableCell CssClass="col-md-3 col-sm-3 col-lg-3">
                                                            <asp:Label ID="lblSubTotalCost" runat="server" Text="₹ 0.00" CssClass="form-control ms-2" Font-Size="12px" Font-Bold="false"></asp:Label>
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                </asp:Table>
                                            </div>
                                        </div>

                                        <div class="container-fluid">
                                            <%-- Discount--%>
                                            <div class="row">
                                                <asp:Table ID="Table3" runat="server" CssClass="col-md-12 col-sm-12 col-lg-12">
                                                    <asp:TableRow ID="TableRow4" runat="server" class="mb-2">
                                                        <asp:TableCell CssClass="col-md-3 col-sm-3 col-lg-3">
                                                        </asp:TableCell>
                                                        <asp:TableCell CssClass="col-md-2 col-sm-2 col-lg-2">
                                                            <asp:Label ID="Label13" runat="server" Text="Discount :" CssClass="form-label me-2 ms-2"></asp:Label>
                                                        </asp:TableCell>
                                                        <asp:TableCell CssClass="col-md-2 col-sm-2 col-lg-2">
                                                         <asp:TextBox ID="txtDiscount1" Text="0.00" runat="server" AutoPostBack="true" OnTextChanged="txtDiscount1_TextChanged" TextMode="Number" CssClass="form-control" placeholder="0.00" BorderColor="Blue" ValidationGroup="di"></asp:TextBox>
                                                        </asp:TableCell>
                                                        <asp:TableCell CssClass="col-md-2 col-sm-2 col-lg-2">
                                                            <asp:DropDownList ID="ddlDiscountCost" runat="server" CssClass="form-control" Style="border-color: Blue" ValidationGroup="di2">
                                                                <asp:ListItem Text="%" Value="%" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Fixed Amount" Value="Fixed Amount"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </asp:TableCell>
                                                        <asp:TableCell CssClass="col-md-3 col-sm-3 col-lg-3">

                                                            <%--Labels--%>
                                                            <asp:Label ID="lblDiscountCost" runat="server" Text="₹ 0.00" CssClass="form-control ms-2" Font-Bold="false"></asp:Label>
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                </asp:Table>
                                            </div>
                                        </div>

                                        <div class="container-fluid">
                                            <%-- Tax list--%>
                                            <div class="row">
                                                <asp:Table ID="Table1" runat="server" CssClass="col-md-12 col-sm-12 col-lg-12">
                                                    <asp:TableRow ID="TableRow1" runat="server" class="mb-2">
                                                        <asp:TableCell CssClass="col-md-4 col-sm-4 col-lg-4">
                                                        </asp:TableCell>
                                                        <asp:TableCell CssClass="col-md-2 col-sm-2 col-lg-2">
                                                            <asp:Label ID="lblCostTaax" runat="server" Text="Tax :" CssClass="form-label" Visible="false"></asp:Label>
                                                        </asp:TableCell>
                                                        <asp:TableCell CssClass="col-md-3 col-sm-3 col-lg-3">
                                                            <asp:Label ID="lbltotaltaxPer" runat="server" Text="" Visible="false"></asp:Label>

                                                            <asp:Label ID="lbltotalcosttax" runat="server" Text="" Visible="false"></asp:Label>

                                                            <asp:Label ID="lblTaxRateTotal" runat="server" Text="" Visible="false"></asp:Label>
                                                            <asp:Label ID="lbltaxTotalAmont" runat="server" Text="" Visible="false"></asp:Label>
                                                            <%--Bullet List--%>
                                                            <asp:BulletedList ID="listTaxNames1" runat="server" Font-Size="12px" Font-Bold="false" BulletStyle="NotSet" CssClass="form-label"></asp:BulletedList>
                                                        </asp:TableCell>
                                                        <asp:TableCell CssClass="col-md-3 col-sm-3 col-lg-3">
                                                            <%--fas fa-rupee-sign--%>
                                                            <asp:BulletedList ID="listTaxValues1" runat="server" Font-Size="12px" Font-Bold="false" BulletStyle="CustomImage" BulletImageUrl="Image/indiCurrency10.png" Style="margin-left: 90px;"></asp:BulletedList>
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                </asp:Table>
                                            </div>
                                        </div>

                                        <div class="container-fluid">
                                            <%-- Adjustment--%>
                                            <div class="row">
                                                <asp:Table ID="Table4" runat="server" CssClass="col-md-12 col-sm-12 col-lg-12">
                                                    <asp:TableRow ID="TableRow5" runat="server" class="mb-2">
                                                        <asp:TableCell CssClass="col-md-4 col-sm-4 col-lg-4"> 
                                                        </asp:TableCell>
                                                        <asp:TableCell CssClass="col-md-2 col-sm-2 col-lg-2">
                                                            <asp:Label ID="lblAdjustment" runat="server" Text="RoundUp:" CssClass="form-label ms-2"></asp:Label>
                                                        </asp:TableCell>
                                                        <asp:TableCell CssClass="col-md-3 col-sm-3 col-lg-3">
                                                            <asp:TextBox ID="TxtAdjustment1" Text="" runat="server" AutoPostBack="true" OnTextChanged="TxtAdjustment1_TextChanged" TextMode="Number" CssClass="form-control ms-2" placeholder="₹0.00" BorderColor="Blue" ValidationGroup="ad"></asp:TextBox>
                                                        </asp:TableCell>
                                                        <asp:TableCell CssClass="col-md-3 col-sm-3 col-lg-3">
                                                            <%--Labels--%>
                                                            <asp:Label ID="lblAdjustmentCost" runat="server" Text="₹0.00" CssClass="form-control ms-2" Font-Size="12px" Font-Bold="false"></asp:Label>
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                </asp:Table>
                                            </div>
                                        </div>
                                        <div class="container-fluid">
                                            <%-- Total--%>
                                            <div class="row">
                                                <asp:Table ID="Table5" runat="server" CssClass="col-md-12 col-sm-12 col-lg-12">
                                                    <asp:TableRow ID="TableRow6" runat="server" class="mb-2">
                                                        <asp:TableCell CssClass="col-md-7 col-sm-7 col-lg-7"></asp:TableCell>
                                                        <asp:TableCell CssClass="col-md-2 col-sm-2 col-lg-2">
                                                            <asp:Label ID="lbltotal" CssClass="form-label marleft50" runat="server" Text="Total:"></asp:Label>
                                                        </asp:TableCell>
                                                        <asp:TableCell CssClass="col-md-3 col-sm-3 col-lg-3">
                                                            <%--Labels--%>
                                                            <asp:Label ID="lbltotalAmonutProposalCost" runat="server" Text="₹0.00" CssClass="form-control" Font-Size="12px" Font-Bold="false"></asp:Label>
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                </asp:Table>
                                            </div>
                                        </div>
                                        <br />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlItem" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <div class="row">
            <div class="card">
                <div class="card-body">
                    <div class="col-md-12 col-sm-12 col-lg-12">

                        <div class="mb-2">
                            <asp:Button ID="btn_SubmitProposal" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" OnClick="btn_SubmitProposal_Click" ValidationGroup="Proposal" />
                            &nbsp;&nbsp;
                             <asp:Button ID="btnClearProposal" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" OnClick="btnClearProposal_Click" ValidationGroup="Clear" />
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
                                            <asp:DropDownList ID="ddlTaxItem1" runat="server" CssClass="form-control" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlTaxItem1_SelectedIndexChanged1">
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
