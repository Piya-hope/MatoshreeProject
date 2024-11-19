<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="CandidateNewOfferLetter.aspx.cs" Inherits="MatoshreeProject.CandidateNewOfferLetter" EnableEventValidation="false" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var GridViewCompansion = $("#GridViewComponent").prepend($("<thead></thead>").append($("#GridViewComponent").find("tr:first"))).DataTable(
                {
                    "order": false,
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });
        });
        $(document).ready(function () {
            var GridViewCompansion = $("#GridViewEmpCompansion").prepend($("<thead></thead>").append($("#GridViewEmpCompansion").find("tr:first"))).DataTable(
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
        <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
            <h5 class="font-weight-medium mb-0">New Offer Letter</h5>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item">
                        <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard </a>
                    </li>
                    <li class="breadcrumb-item">
                        <a class="text-muted text-decoration-none" aria-current="page" href="OfferLetter.aspx">OfferLetter</a>
                    </li>
                    <li class="breadcrumb-item">
                        <a class="text-muted text-decoration-none" aria-current="page" href="NewOfferLetter.aspx">NewOfferLetter</a>
                    </li>
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
        <br />
        <%-- Candidate Details --%>
        <div class="card">
            <asp:Label ID="lblEmpID1" runat="server" Text="" CssClass="form-label" Visible="false"></asp:Label>
            <asp:Label ID="lblInitialNumber" Visible="false" runat="server" Text="-" Font-Bold="true" CssClass="form-control col-md-1" ReadOnly="true"></asp:Label>
            <div class="card-body">
                <h5 class="card-title">Candidates Details</h5>
                <hr />

                <div class="row">
                    <div class="col-md-6 col-sm-6 col-lg-6">
                        <div class="mb-2">
                            <asp:Label ID="lblcandid" runat="server" Text="Candidate Number" CssClass="form-label"></asp:Label>&nbsp;
                               <asp:TextBox ID="txtCandNumber" runat="server" CssClass="form-control form-control-sm" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6 col-sm-6 col-lg-6">
                        <div class="mb-2">
                            <asp:Label ID="lblDesignation" runat="server" Text="Designation" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                            <asp:DropDownList ID="ddldesignation1" runat="server" CssClass="form-control form-select"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="reqDesignation" runat="server" ErrorMessage="Select Designation" ControlToValidate="ddldesignation1" ForeColor="Red" Font-Bold="false" ValidationGroup="Structure" Font-Size="12px" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6 col-sm-6 col-lg-6">
                        <div class="mb-2">
                            <asp:Label ID="CandName" runat="server" Text="Candidate Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                            <asp:TextBox ID="txtCandName" runat="server" CssClass="form-control" placeholder="Enter Candidate Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqCandName" runat="server" ErrorMessage="Enter Candidate Name" ControlToValidate="txtCandName" ForeColor="Red" Font-Bold="false" ValidationGroup="Structure" Font-Size="12px"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-lg-6">
                        <div class="mb-2">
                            <asp:Label ID="lblCandEmailId" runat="server" Text="EmilID" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                            <asp:TextBox ID="txtCandEmail" runat="server" class="form-control" Placeholder="Enter EmailID"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="regCandEmail" runat="server" ControlToValidate="txtCandEmail" ErrorMessage="Invalid Email Format" ForeColor="Red" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" ValidationGroup="Structure"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="reqtxtCandEmail" runat="server" ErrorMessage="Enter EmailID" ControlToValidate="txtCandEmail" ForeColor="Red" Font-Bold="false" ValidationGroup="Structure" Font-Size="12px"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6 col-sm-6 col-lg-6">
                        <div class="mb-2">
                            <asp:Label ID="lblDepartment" runat="server" Text="Department" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                            <asp:DropDownList ID="ddlCanddepartement1" runat="server" CssClass="form-control form-select"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="ReqtxtCandDepartment" runat="server" ErrorMessage="Select Department" ControlToValidate="ddlCanddepartement1" ForeColor="Red" Font-Bold="false" ValidationGroup="Structure" Font-Size="12px" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="col-md-6 col-sm-6 col-lg-6">
                        <div class="mb-2">
                            <asp:Label ID="lblphoneNo" runat="server" Text="PhoneNo" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                            <asp:TextBox ID="txtCandphoneNo" runat="server" class="form-control" Placeholder="Enter Phone No"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_Phone" runat="server" Display="Dynamic" ControlToValidate="txtCandphoneNo" ErrorMessage="Enter 10 digit Phone Number" ForeColor="Red" ValidationGroup="Structure" Font-Size="12px"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="Regulexphone" runat="server" ControlToValidate="txtCandphoneNo" ErrorMessage="Phone Number Invalid." ForeColor="Red" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$" ValidationGroup="Structure" Font-Size="12px"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6 col-sm-6 col-lg-6">
                        <div class="mb-2">
                            <asp:Label ID="lblPackage" runat="server" Text="Package" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                            <asp:TextBox ID="txtCandPackage" runat="server" class="form-control" Placeholder="Package"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqCandPackage" runat="server" ErrorMessage="Package" ControlToValidate="txtCandPackage" ForeColor="Red" Font-Bold="false" ValidationGroup="Structure" Font-Size="12px"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="col-md-6 col-sm-6 col-lg-6">
                        <div class="mb-2">
                            <asp:Label ID="lblCandAddress" runat="server" Text="Address" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtCandAddress" runat="server" class="form-control" Placeholder="Enter Address" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                   
                </div>

                <div class="row">
                    <div class="col-md-4 col-lg-4 col-xs-4 col-sm-4">
                        <asp:Label ID="lblClass1" runat="server" Text="Class" CssClass="text-dark" Font-Bold="true" Font-Size="12px"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                        <asp:DropDownList ID="ddlClass1" runat="server" CssClass="form-control form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlClass1_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqvalclass" runat="server" ControlToValidate="ddlClass1" ForeColor="Red" Font-Size="12px" Font-Bold="false" InitialValue="0" Display="Dynamic" ValidationGroup="Structure" ErrorMessage="Select Class"></asp:RequiredFieldValidator>
                    </div>
               
                </div>
                <br />
                <div class="row">                   
                        <div class="mb-2">
                            <center>
                                <asp:Button ID="btncalpackage" runat="server" Text="Calculate" CssClass="btn btn-sm btn-primary" ValidationGroup="Structure" OnClick="btncalpackage_Click" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnclecandinfo" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" OnClick="btnclecandinfo_Click" />
                            </center>
                        </div>
                    </div>
                         
            </div>
        </div>

        <%-- Gridview Componentes --%>
        <div class="row">
            <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">A) Component</h5>
                        <hr />
                        <asp:GridView ID="GridViewCandComponent" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                            ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" FooterStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="true">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblCompHeader" runat="server" Text="Compnent" Font-Size="12px" Font-Bold="true"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCompPerCatId" runat="server" Text='<%# Bind("PertCate_ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                        <asp:Label ID="lblComppert" runat="server" Text='<%# Bind("Perticular") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblComptotal" runat="server" Text="Total" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblCompPerName" runat="server" Text="Percentage" Font-Size="12px" Font-Bold="true"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCompPercentage" runat="server" Text='<%# Bind("Percentage") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblPerComp" runat="server" Text="" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblCompMonthlyAmt" runat="server" Text="Monthly Amount" Font-Size="12px" Font-Bold="true"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblMonthlyAmtComp" runat="server" Text='<%# Bind("Amount") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblMntAmtCompFtr" runat="server" Text="" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblCompAnnAmt" runat="server" Text="Annual Amount" Font-Size="12px" Font-Bold="true"></asp:Label>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <asp:Label ID="lblCompAnnAmtComp" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblAnnAmtCompftr" runat="server" Text="" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                               
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

        <%-- Gridview Contribution --%>
        <div class="row">
            <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">B) Employeer Contribution</h5>
                        <hr />
                        <asp:GridView ID="GridViewCandContr" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                            ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" FooterStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="true">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblContr" runat="server" Text="Compnent" Font-Size="12px" Font-Bold="true"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblContrPerID" runat="server" Text='<%# Bind("PertCate_ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                        <asp:Label ID="lblContrPert" runat="server" Text='<%# Bind("Perticular") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblContrTotal" runat="server" Text="Total" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblContrPerHdr" runat="server" Text="Percentages" Font-Size="12px" Font-Bold="true"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblContrPer" runat="server" Text='<%# Bind("Percentage") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblContrPerftr" runat="server" Text="" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblContrAnn" runat="server" Text="Annual Amount" Font-Size="12px" Font-Bold="true"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblContrAnnAmt" runat="server" Text='<%# Bind("Amount") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblContrAnnAmtFtr" runat="server" Text="" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                               
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

        <%-- Grand Total --%>
        <div class="row">
            <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">D) Grand Total</h5>
                        <hr />
                        <table id="htmlgriandtotal" class="table table-bordered table-hover table-responsive" runat="server" style="width: 100%;">
                            <thead style="background-color: #f8f9fa;">
                                <tr>
                                    <th style="display: none;">
                                        <asp:Label runat="server" Style="font-weight: normal; font-size: 12px;">1</asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label runat="server" Style="font-weight: normal; font-size: 12px;">Salary Offered - Grand Total(A+B)</asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lblcandOfferedTotal" runat="server" Text="" Font-Bold="true" Font-Size="12px"></asp:Label>
                                    </th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
            </div>
        </div>

        <%-- Company Terms And Condition--%>
        <div class="row">
            <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12">
                <div class="card">
                    <div class="card-body">
                        <div class="col-md-12 col-sm-12 col-lg-12">
                            <div class="mb-2">
                                <asp:Label ID="lblClientNote" runat="server" Text="Note" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtClientNote" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-12 col-sm-12 col-lg-12">
                            <div class="mb-2">
                                <asp:Label ID="lblTermsConditions" runat="server" Text="Terms & Conditions" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtTermsAndConditions" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12">
                            <div class="mb-2 text-center">

                                <asp:Button ID="btnSavecanddetails" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" OnClick="btnSavecanddetails_Click" />
                                &nbsp;&nbsp;
                            <asp:Button ID="btnclosecanddetails" runat="server" Text="Close" CssClass="btn btn-sm btn-danger" OnClick="btnclosecanddetails_Click" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
