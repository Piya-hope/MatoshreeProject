<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="EditEmpSalStructure.aspx.cs" Inherits="MatoshreeProject.EditEmpSalStructure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridViewComponent = $("#GridViewComponent").prepend($("<thead></thead>").append($("#GridViewComponent").find("tr:first"))).DataTable(
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
                    "order": false,
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
        <h5 class="card-title">Edit Employee Salary Structure</h5>
        <%-- BreadCrumbs --%>

        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
              <li class="breadcrumb-item">
                     <a class="text-muted text-decoration-none" href="Dashboard.aspx">Employee Salary Details
                    </a></li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="EditEmpSalStructure.aspx">Edit Employee Salary Structure</li>
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
        <br>
        <div class="row">
            <div class="card-title">
                <asp:Label ID="lblTittle" runat="server" Text="" Font-Bold="true" Font-Size="20px"></asp:Label>
                <div class="card">
                    <div class="card-body">
                        <!-- Empolyee Details-->
                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-lg-6">

                                <div class="mb-2">
                                    <asp:Label ID="lblEmpID1" runat="server" Text="" CssClass="form-label" Visible="false"></asp:Label>
                                    <asp:Label ID="lblName" runat="server" Text="Name" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtName" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                </div>

                                <div class="mb-2">
                                    <asp:Label ID="lblshift" runat="server" Text="ShiftName" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtShiftName" runat="server" class="form-control"></asp:TextBox>

                                </div>
                                <div class="mb-2">
                                    <asp:Label ID="lblPackage" runat="server" Text="Package" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtPackage" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqPackage" runat="server" ErrorMessage="Package" ControlToValidate="txtPackage" ForeColor="Red" Font-Bold="false" ValidationGroup="Structure"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblDesignation" runat="server" Text="Designation" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtDesignation" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                </div>

                                <div class="mb-2">
                                    <asp:Label ID="lblDepartment" runat="server" Text="Department" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtDepartment" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                </div>

                                <div class="mb-2">
                                    <asp:Label ID="lblEmpEmailId" runat="server" Text="EmilID" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="mb-2">
                                <center>
                                    <asp:Button ID="btnCalculateStructure" runat="server" Text="Calculate" CssClass="btn btn-sm btn-primary" ValidationGroup="Structure" OnClick="btnCalculateStructure_Click" />
                                    &nbsp;&nbsp;
     
                                 <asp:Button ID="btnClearStructure" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="Clear" OnClick="btnClearStructure_Click" />
                                </center>
                            </div>
                        </div>
                        <!-- End Empolyee Details-->
                        </div>
                    </div>
                         <div class="card">
                    <div class="card-body">
                        <br />

                        <h5 class="card-title">A) Component</h5>
                        <hr />

                        <div class="col-md-12 col-sm-12 col-lg-12">
                            <!-- Grid View Component -->
                            <asp:GridView ID="GridViewComponent" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" FooterStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="true">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblCompnent" runat="server" Text="Compnent" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>

                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("StaffID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                            <asp:Label ID="lblComponentID" runat="server" Text='<%# Bind("PertCate_ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                            <asp:Label ID="lblCompnent1" runat="server" Text='<%# Bind("Category") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
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
                                            <asp:TextBox ID="txtAmount1" runat="server" Text='<%# Bind("MonthlyAmount") %>' Font-Size="12px" CssClass="form-control" Placeholder="Monthly Amount" TextMode="Number" Style="width: 150px" Visible="false" ValidationGroup="R"></asp:TextBox>
                                            <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("MonthlyAmount") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
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
                                            <asp:Label ID="lblAmountYr1" runat="server" Text='<%# Bind("AnnualAmount") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
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

                            <!-- End Grid View Component -->

                        </div>
                        </div>
                             </div>
                     
                         <div class="card">
                    <div class="card-body">
                        <div id="EmpCompansion" runat="server" visible="true">
                            <h5 class="card-title">B) Employeer Contribution</h5>
                            <hr />

                            <!-- Compansion Grid View -->
                            <div class="col-md-12 col-sm-12 col-lg-12">

                                <asp:GridView ID="GridViewEmpCompansion" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                    ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" FooterStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="true">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblCompnent" runat="server" Text="Compnent" Font-Size="12px" Font-Bold="true"></asp:Label>
                                            </HeaderTemplate>

                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("StaffID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                                <asp:Label ID="lblComponentsID1" runat="server" Text='<%# Bind("PertCate_ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                                <asp:Label ID="lblCompnents1" runat="server" Text='<%# Bind("Category") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
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
                                                <asp:Label ID="lblAmounts1" runat="server" Text='<%# Bind("AnnualAmount") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblAmounts2" runat="server" Text="" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblMonthlyAmounts" runat="server" Text="Monthly Amount" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                            </HeaderTemplate>

                                            <ItemTemplate>
                                                <asp:Label ID="lblMonthlyAmounts1" runat="server" Text='<%# Bind("MonthlyAmount") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblMonthlyAmounts2" runat="server" Text="" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
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
                            <!--  Compansion Grid View -->
                            <br />
                            <br />

                        </div>
                        <br />
                        <!-- Salary offered -->


                        <div id="Div1">
                            <h5 class="card-title">C) Grand Total</h5>
                            <hr />
                            <table class="table table-bordered table-hover table-responsive" style="width: 100%;">
                                <thead style="background-color: #f8f9fa;">
                                    <tr>
                                        <th style="display: none;">
                                            <label style="font-weight: normal; font-size: 12px;">1</label>
                                        </th>
                                        <th>
                                            <label style="font-weight: normal; font-size: 12px;">Salary Offered - Grand Total(A+B)</label>
                                        </th>
                                        <th>
                                            <asp:Label ID="lblOfferedTotal" runat="server" Text="" Font-Bold="true" Font-Size="12px"></asp:Label>
                                        </th>
                                    </tr>
                                </thead>

                            </table>
                        </div>


                        <!-- End Salary offered -->
                        <br />
                        <!-- Save button -->
                        <div class="row">
                            <div class="mb-2">
                                <center>
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-sm btn-success" OnClick="btnUpdate_Click" />
                                    &nbsp;&nbsp;
                                 <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-sm btn-danger" OnClick="btnClose_Click" />
                                </center>
                            </div>
                        </div>
                        <!--End Save button -->
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
