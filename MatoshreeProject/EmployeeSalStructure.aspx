<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeSalStructure.aspx.cs" Inherits="MatoshreeProject.EmployeeSalStructure" %>

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
    <style>
        .modal-content {
            position: relative;
            display: flex;
            flex-direction: column;
            width: 100%;
            color: var(--bs-modal-color);
            pointer-events: auto;
            background-color: var(--bs-modal-bg);
            background-clip: padding-box;
            border: var(--bs-modal-border-width) solid var(--bs-modal-border-color);
            border-radius: var(--bs-modal-border-radius);
            box-shadow: none !important;
            outline: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">

        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="card-title">Employee Salary Structure</h5>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

                <%-- BreadCrumbs --%>

                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="EmployeeSalDetails.aspx">Employee Salary Details
                            </a>
                        </li>

                        <li class="breadcrumb-item text-muted" aria-current="page" href="EmployeeSalStructure.aspx">Employee Salary Structure</li>
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

            <div class="card-title">
                <asp:Label ID="lblTittle" runat="server" Text="" Font-Bold="true" Font-Size="20px"></asp:Label>

                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Employee Details</h5>
                        <hr />
                        <%--   <div class="row">--%>
                        <div class="mb-2">
                            <asp:Label ID="Label5" runat="server" Text="Search Employee" Font-Size="14px" CssClass="form-label"></asp:Label>

                            <%--    <asp:Label ID="Label4" runat="server" Text="search" CssClass="form-label" Font-Size="12px"></asp:Label>--%>

                            <button type="button" id="btnmodalPopup" class="btn btn-success btn-sm FontBig" data-bs-toggle="modal"
                                data-bs-target="#ItemID">
                                <i class="ti ti-search">&nbsp;Search</i>
                            </button>
                        </div>
                        <!-- Modal for Components-->
                        <div class="modal fade" id="ItemID" data-bs-backdrop="static"
                            data-bs-keyboard="false" tabindex="-1" aria-labelledby="scroll-long-inner-modal"
                            aria-hidden="true">
                            <div class="modal-dialog modal-dialog-scrollable">
                                <div class="modal-content shadow-none" style="box-shadow: none">
                                    <div class="modal-header d-flex align-items-center">
                                        <h4 class="modal-title" id="myLargeModalLabel"></h4>
                                        <%--<button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>--%>
                                        <asp:Button ID="btnCloseModal" runat="server" Text="" CssClass="btn-close" data-bs-dismiss="modal" aria-label="Close" />

                                    </div>
                                    <div class="modal-body">
                                        <asp:UpdatePanel runat="server" ID="updatepnl">
                                            <ContentTemplate>
                                                <h5 class="card-title" style="color: blue">Search Staff</h5>
                                                <hr />
                                                <%-- <div class="col-md-6 col-sm-6 col-lg-6">--%>
                                                <div class="mb-2">
                                                    <asp:Label ID="lblID" runat="server" Text="Search Staff ID" CssClass="form-label"></asp:Label>
                                                    <asp:Label ID="lblStaffID1" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                                    <div class="modal-content rounded-1">
                                                        <div class="modal-header border-bottom">
                                                            <div class="input-group">
                                                                <asp:TextBox ID="txtempname" CssClass="form-control" placeholder="Search here" AutoCompleteType="Disabled"
                                                                    runat="server"></asp:TextBox>
                                                                <asp:LinkButton ID="btnSearch2" runat="server" CssClass="btn btn-sm btn-info" CausesValidation="false" OnClick="btnSearch2_Click" AutoPostBack="true"><i class="ti ti-search"></i></asp:LinkButton>
                                                            </div>
                                                        </div>
                                                        <div class="modal-body message-body" data-simplebar="">
                                                            <div id="Divshowdash" runat="server" visible="true">

                                                                <ul class="list mb-0 py-2">
                                                                    <li class="p-1 mb-1 px-2 rounded bg-hover-light-black">
                                                                        <a href="Dashboard.aspx">
                                                                            <span class="h6 mb-1"></span>
                                                                            <span class="fs-2 text-muted d-block"></span>
                                                                        </a>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                            <div id="BTNDIV" runat="server" visible="false">
                                                                <div class="row">
                                                                    <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                                                        <div class="table-responsive">
                                                                            <asp:GridView ID="GVEMpName" runat="server" CssClass="table" AutoGenerateColumns="false" CellPadding="4" BorderStyle="None"
                                                                                ClientIDMode="Static" ShowHeader="false" Style="width: 100%" EmptyDataText="No Records found" ShowHeaderWhenEmpty="False" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="Staff_ID">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblEmpID" runat="server" Text='<%# Bind("Staff_ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Name" SortExpression="name">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblEmpName" runat="server" Text='<%# Bind("Name") %>' Font-Size="12px" Visible="false" ForeColor="Black" CssClass="form-label"></asp:Label>
                                                                                            <asp:LinkButton ID="LnkEmpName" runat="server" Text='<%# Bind("Name") %>' OnClick="LnkEmpName_Click" Font-Size="12px"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <%--   <asp:HyperLink runat="server" ID="DASHBOARD" Text="DASHBOARD" NavigateUrl="https://newdesigncrm.lissomtech.in/Dashboard" />
                  <asp:HyperLink runat="server" ID="Customer" Text="Customer" NavigateUrl="https://newdesigncrm.lissomtech.in/Customer" />--%>
                                                            </div>
                                                        </div>
                                                    </div>


                                                </div>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <%--  </div>--%>
                                    </div>
                                    <br />
                                    <%--  <div class="modal-footer">
                                                <asp:Button ID="Button1" runat="server" Text="Save" CssClass="btn btn-sm btn-primary"  ValidationGroup="SaveITEM" />
                                                &nbsp;&nbsp;
                                              <button type="button" class="btn btn-sm btn-danger" data-bs-dismiss="modal">Close </button>
                                            </div>--%>
                                </div>
                            </div>
                        </div>
                        <!-- Modal for Components-->

                        <!-- Empolyee Details-->

                        <%--     <div class="row">
                             <div class="col-md-6 col-sm-6 col-lg-6">
                                  <div class="mb-2">
                                        <asp:Label ID="lblID" runat="server" Text="Search Staff ID" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblStaffID1" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                        <div class="modal-content rounded-1">
                                            <div class="modal-header border-bottom">
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtempname" CssClass="form-control" placeholder="Search here" AutoCompleteType="Disabled"
                                                        runat="server"></asp:TextBox>
                                                    <asp:LinkButton ID="btnSearch2" runat="server" CssClass="btn btn-sm btn-info" CausesValidation="false" OnClick="btnSearch2_Click"><i class="ti ti-search"></i></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="modal-body message-body" data-simplebar="">
                                                <div id="Divshowdash" runat="server" visible="true">

                                                    <ul class="list mb-0 py-2">
                                                        <li class="p-1 mb-1 px-2 rounded bg-hover-light-black">
                                                            <a href="Dashboard.aspx">
                                                                <span class="h6 mb-1"></span>
                                                                <span class="fs-2 text-muted d-block"></span>
                                                            </a>
                                                        </li>
                                                    </ul>
                                                </div>
                                                <div id="BTNDIV" runat="server" visible="false">
                                                    <div class="row">
                                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                                            <div class="table-responsive overflow-auto ">
                                                                <asp:GridView ID="GVEMpName" runat="server" CssClass="table table-hover " AutoGenerateColumns="false" CellPadding="4" BorderStyle="None"
                                                                    ClientIDMode="Static" ShowHeader="false" Style="width: 100%" EmptyDataText="No Records found" ShowHeaderWhenEmpty="False" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="Staff_ID">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblEmpID" runat="server" Text='<%# Bind("Staff_ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Name" SortExpression="name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblEmpName" runat="server" Text='<%# Bind("Name") %>' Font-Size="12px" Visible="false" ForeColor="Black" CssClass="form-label"></asp:Label>
                                                                                <asp:LinkButton ID="LnkEmpName" runat="server" Text='<%# Bind("Name") %>' OnClick="LnkEmpName_Click" Font-Size="12px"></asp:LinkButton>
                                                                            </ItemTemplate>
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
                        </div>--%>
                        <div class="row">

                            <div class="col-md-6 col-sm-6 col-lg-6">


                                <div class="mb-2">
                                    <asp:Label ID="lblName" runat="server" Text="Name" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtName" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                </div>

                                <div class="mb-2">
                                    <asp:Label ID="lblSelectClass" runat="server" Text="Select Class" CssClass="form-label"></asp:Label>
                                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control form-select" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    <asp:Label ID="lblshift" runat="server" Text="Shift" CssClass="form-label" Visible="false"></asp:Label>
                                    <asp:TextBox ID="txtShiftName" runat="server" class="form-control" ReadOnly="true" Visible="false"></asp:TextBox>

                                </div>
                                <div class="mb-2">
                                    <asp:Label ID="lblPackage" runat="server" Text="Package" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtPackage" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqPackage" runat="server" ErrorMessage="Package" ControlToValidate="txtPackage" ForeColor="Red" ValidationGroup="Structure" Font-Size="12px"></asp:RequiredFieldValidator>
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
                        <%-- </div>--%>
                    </div>
                </div>
                <div id="AllGrid" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">


                            <%--   <div class="row">--%>

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
                                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
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
                                                <asp:Label ID="lblPercentage2" runat="server" Text="0.0" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
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
                                                <asp:Label ID="lblAmount2" runat="server" Text="0" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
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
                                                <asp:Label ID="lblAmountYr2" runat="server" Text="0" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
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
                            <br />
                            <br />
                            <br />
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
                                                    <asp:Label ID="lblMonthlyAmounts" runat="server" Text="Monthly Amount" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <asp:Label ID="lblMonthlyAmounts1" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
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

                            <asp:Label ID="lblPFMonthly" runat="server" Text="" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                            <!-- Compansion Grid View -->
                            <div class="col-md-12 col-sm-12 col-lg-12">

                                <asp:GridView ID="GridViewDeduction" runat="server" OnRowDataBound="GridViewDeduction_RowDataBound" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                    ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" FooterStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="true" visible="false">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblCompnent" runat="server" Text="Compnent" Font-Size="12px" Font-Bold="true"></asp:Label>
                                            </HeaderTemplate>

                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                                <asp:Label ID="lblPerCateIDDed" runat="server" Text='<%# Bind("PertCate_ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                                <asp:Label ID="lblPerDed" runat="server" Text='<%# Bind("Perticular") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblComponentTotal" runat="server" Text="Total" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblPercentagesDed" runat="server" Text="Percentages" Font-Size="12px" Font-Bold="true"></asp:Label>
                                            </HeaderTemplate>

                                            <ItemTemplate>
                                                <asp:Label ID="lblPercentages1Ded" runat="server" Text='<%# Bind("Percentage") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>

                                            <FooterTemplate>
                                                <asp:Label ID="lblPercentages2Ded" runat="server" Text="" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                            </FooterTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblAmountsDed" runat="server" Text="Annual Amount" Font-Size="12px" Font-Bold="true"></asp:Label>
                                            </HeaderTemplate>

                                            <ItemTemplate>
                                                <asp:Label ID="lblAmountsDed1" runat="server" Text='<%# Bind("Amount") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblAmountsDed2" runat="server" Text="" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </div>
                            <!--  Compansion Grid View -->

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
                                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" OnClick="btnSave_Click" ValidationGroup="Structure" />
                                        &nbsp;&nbsp;
                                    <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-sm btn-danger" OnClick="btnClose_Click" />
                                    </center>
                                </div>
                            </div>
                            <!--End Save button -->
                            <%-- </div>--%>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
