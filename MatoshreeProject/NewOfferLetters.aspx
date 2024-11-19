<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="NewOfferLetters.aspx.cs" Inherits="MatoshreeProject.NewOfferLetters" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var GridViewCompansion = $("#GridViewComponent").prepend($("<thead></thead>").append($("#GridViewComponent").find("tr:first"))).DataTable(
            {
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
        <br />
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
        <div class="row">
            <div class="card-title">
                <asp:Label ID="lblTittle" runat="server" Text="" Font-Bold="true" Font-Size="20px"></asp:Label>

                <div class="card">
                    <asp:Label ID="lblEmpID1" runat="server" Text="" CssClass="form-label" Visible="false"></asp:Label>
                    <asp:Label ID="lblInitialNumber" Visible="false" runat="server" Text="-" Font-Bold="true" CssClass="form-control col-1 col-md-1" ReadOnly="true"></asp:Label>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblcandid" runat="server" Text="Candidate Number" CssClass="form-label"></asp:Label>&nbsp;
                                    <asp:TextBox ID="txtCandNumber" runat="server" CssClass="form-control form-control-sm" ReadOnly="false"></asp:TextBox>
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
                                    <asp:Label ID="EmpName" runat="server" Text="Candidate Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtEmpName" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqEmpName" runat="server" ErrorMessage="Enter Candidate Name" ControlToValidate="txtEmpName" ForeColor="Red" Font-Bold="false" ValidationGroup="Structure" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblEmpEmailId" runat="server" Text="EmilID" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" Placeholder="Enter EmailID"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="regEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" ForeColor="Red" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" ValidationGroup="Structure"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="reqtxtEmail" runat="server" ErrorMessage="Enter EmailID" ControlToValidate="txtEmail" ForeColor="Red" Font-Bold="false" ValidationGroup="Structure" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblDepartment" runat="server" Text="Department" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:DropDownList ID="ddldepartement1" runat="server" CssClass="form-control form-select"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="ReqtxtDepartment" runat="server" ErrorMessage="Select Department" ControlToValidate="ddldepartement1" ForeColor="Red" Font-Bold="false" ValidationGroup="Structure" Font-Size="12px" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblphoneNo" runat="server" Text="PhoneNo" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtphoneNo" runat="server" class="form-control" Placeholder="Enter Phone No"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqCandPhoneNumber" runat="server" ErrorMessage="Enter Phone No" ControlToValidate="txtphoneNo" ForeColor="Red" Font-Bold="false" ValidationGroup="Structure" Font-Size="12px"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regPhone" runat="server" ControlToValidate="txtphoneNo" ErrorMessage="Invalid Phone Number Format" ForeColor="Red" ValidationExpression="^\+?\d{0,3}?[- .]?\(?\d{1,4}?\)?[- .]?\d{1,4}[- .]?\d{1,9}$" ValidationGroup="Structure"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblPackage" runat="server" Text="Package" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtPackage" runat="server" class="form-control" Placeholder="Package"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqPackage" runat="server" ErrorMessage="Package" ControlToValidate="txtPackage" ForeColor="Red" Font-Bold="false" ValidationGroup="Structure" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>

                            </div>

                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblAddress" runat="server" Text="Address" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtAddress" runat="server" class="form-control" Placeholder="Enter Address" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

                <div class="col-md-12 col-sm-12 col-lg-12">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">A) Component</h5>
                            <hr />
                            <asp:GridView ID="GridViewComponent" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" FooterStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="true">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblCompnent" runat="server" Text="Compnent" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>

                                        <ItemTemplate>
                                            <asp:Label ID="lblComponentID" runat="server" Text='<%# Bind("PertCate_ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                            <asp:Label ID="lblCompnent1" runat="server" Text='<%# Bind("Perticular") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblCompnent2" runat="server" Text="Total" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblPercentage" runat="server" Text="Percentage" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPercentage1" runat="server" Text='<%# Bind("Percentage") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblPercentage2" runat="server" Text="" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblAmount" runat="server" Text="Monthly Amount" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtAmount1" runat="server" Text='<%# Bind("Amount") %>' Font-Size="12px" CssClass="form-control" Placeholder="Monthly Amount" TextMode="Number" Style="width: 150px" Visible="false" ValidationGroup="R"></asp:TextBox>
                                            <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("Amount") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblAmount2" runat="server" Text="" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblAmountYr" runat="server" Text="Annual Amount" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>

                                        <ItemTemplate>
                                            <asp:Label ID="lblAmountYr1" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblAmountYr2" runat="server" Text="" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="btnOption" runat="server" Text="" ValidationGroup="setting"><i class="fas fa-cog"></i></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDeleteAnnualSal" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-rounded btn-danger" ValidationGroup="DelItemTender" Text="" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteAnnualSal_Click" Visible="false"><i class="ti ti-trash"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>

                <div class="col-md-12 col-sm-12 col-lg-12">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">B) Employeer Contribution</h5>
                            <hr />
                            <asp:GridView ID="GridViewEmpCompansion" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" FooterStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="true">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblCompnent" runat="server" Text="Compnent" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                            <asp:Label ID="lblComponentsID1" runat="server" Text='<%# Bind("PertCate_ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                            <asp:Label ID="lblCompnents1" runat="server" Text='<%# Bind("Perticular") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblCompnents2" runat="server" Text="Total" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblPercentages" runat="server" Text="Percentages" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPercentages1" runat="server" Text='<%# Bind("Percentage") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblPercentages2" runat="server" Text="" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblAmounts" runat="server" Text="Annual Amount" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmounts1" runat="server" Text='<%# Bind("Amount") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblAmounts2" runat="server" Text="" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="btnOption" runat="server" Text="" ValidationGroup="setting"><i class="fas fa-cog"></i></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDeleteAnnualComp" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-rounded btn-danger" ValidationGroup="DeleteComp" Text="" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteAnnualComp_Click" Visible="false"><i class="ti ti-trash"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                </div>

                <div id="Div1">
                    <h5 class="card-title">C) Grand Total</h5>
                    <hr />
                    <div class="card">
                        <div class="card-body">
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
                                            <asp:Label ID="lblOfferedTotal" runat="server" Text="" Font-Bold="true" Font-Size="12px"></asp:Label>
                                        </th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="card">
                        <div class="card-body">
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <div class="form-group">
                                    <asp:Label ID="lblClientNote" runat="server" Text="Note" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtClientNote" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <div class="form-group">
                                    <asp:Label ID="lblTermsConditions" runat="server" Text="Terms & Conditions" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtTermsAndConditions" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

            </div>
        </div>
      
    </div>
</asp:Content>
