<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="PreSalaryStructure.aspx.cs" Inherits="MatoshreeProject.PreSalaryStructure" EnableEventValidation="false" %>

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

            var EmpContributionGridView = $("#EmpContributionGridView").prepend($("<thead></thead>").append($("#EmpContributionGridView").find("tr:first"))).DataTable(
                {
                    "order": false,
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

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
                <h5 class="font-weight-medium">View Salary Pre Structure</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="ViewPreSalStructure.aspx">ViewPreSalStructure
                            </a>
                        </li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="PreSalaryStructure.aspx">Pre Salary Structure</li>
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

        <div class="card">
            <div class="card-body">
                <h5 class="card-title">Salary Pre Structure</h5>
                <hr />
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-lg-12">
                        <div class="col-md-4 col-sm-4 col-lg-4">
                            <div class="form-group">
                                <asp:Label ID="lblClass" runat="server" Text="Class" Font-Bold="true" Font-Size="12px"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlClass" ForeColor="Red" Font-Size="12px" Font-Bold="false" InitialValue="0" Display="Dynamic" ValidationGroup="SaveValidate" ErrorMessage="Select Class"></asp:RequiredFieldValidator>--%>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlClass"
                                    ForeColor="Red" Font-Size="12px" Font-Bold="false"
                                    InitialValue="0" Display="Dynamic"
                                    ValidationGroup="SaveValidate"
                                    ErrorMessage="Please select a class."></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                </div>
                <br />
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-lg-12">
                        <asp:CheckBox ID="chkEmp" runat="server" OnCheckedChanged="chkEmp_CheckedChanged" AutoPostBack="true" />
                        <asp:Label ID="Label2" runat="server" Text="Label" Font-Size="Smaller">
                            Do you want to add employor contribution base on Basic Salary
                        </asp:Label>
                    </div>
                </div>
                <br />
                <div class="row">

                    <div class="row">
                        <%--   <br />--%>
                        <div class="col-md-9 col-xs-9 col-sm-9 col-lg-9">
                            <h5 class="card-title">A) Component</h5>
                        </div>

                        <%--<div class="col-md-4 col-sm-4 col-lg-4"><asp:Label ID="lblResult" runat="server" Text="Remaining Percentage" visible="true"></asp:Label></div>--%>

                        <div class="col-md-3 col-xs-3 col-sm-3 col-lg-3">
                            <asp:Label ID="lblResult" runat="server" Text="Remaining Percentage : " Visible="true" Font-Size="Smaller" CssClass="text-end"></asp:Label>

                        </div>

                    </div>

                    <div class="row mt-3">

                        <div class="col-md-4 col-xs-4 col-sm-4 col-lg-4">
                            <div class="input-group">
                                <asp:DropDownList ID="ddlComponents" runat="server" OnSelectedIndexChanged="ddlComponents_SelectedIndexChanged" AutoPostBack="true" CssClass="form-select form-control" Font-Size="12px">
                                </asp:DropDownList>
                                <!-- Button trigger modal -->

                                <button type="button" id="btnmodalPopup" class="btn btn-info btn-sm font-medium" data-bs-toggle="modal"
                                    data-bs-target="#ItemID">
                                    +
                                </button>
                            </div>
                        </div>

                        <!-- Modal for Components-->
                        <div class="modal fade" id="ItemID" data-bs-backdrop="static"
                            data-bs-keyboard="false" tabindex="-1" aria-labelledby="scroll-long-inner-modal"
                            aria-hidden="true">
                            <div class="modal-dialog modal-dialog-scrollable">
                                <div class="modal-content">
                                    <div class="modal-header d-flex align-items-center">
                                        <h4 class="modal-title" id="myLargeModalLabel"></h4>
                                        <%--<button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>--%>
                                        <asp:Button ID="btnCloseModal" runat="server" Text="" CssClass="btn-close" OnClick="btnCloseModal_Click" data-bs-dismiss="modal" aria-label="Close" />

                                    </div>
                                    <div class="modal-body">
                                        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                            <ContentTemplate>
                                                <h5 class="card-title" style="color: blue">Add Component</h5>
                                                <hr />
                                                <div class="mb-2">
                                                    <asp:Label ID="lblClass1" runat="server" Text="Class" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                    <asp:DropDownList ID="ddlClass1" runat="server" CssClass="form-control form-select" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="ddlClass1" ForeColor="Red" Font-Size="12px" Font-Bold="false" InitialValue="0" Display="Dynamic" ValidationGroup="SaveValidate" ErrorMessage="Select Class"></asp:RequiredFieldValidator>
                                                </div>

                                                <div class="mb-2">
                                                    <asp:Label ID="lblComponentCat" runat="server" Text="Type" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                    <asp:DropDownList ID="ddlComponentCat" runat="server" CssClass="form-control form-select" Font-Size="12px">
                                                        <%--  <asp:ListItem Value="0" Text="Select Type"></asp:ListItem>--%>
                                                        <asp:ListItem Value="1" Text="Component" Selected="True"></asp:ListItem>
                                                        <%-- <asp:ListItem Value="2" Text="Employer Contribution"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Employee Deduction"></asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </div>



                                                <div class="mb-2">
                                                    <asp:Label ID="lblComponent" runat="server" Text="Component" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                    <asp:Label ID="lblEmpContriResult" runat="server" Text="" Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                                    <asp:TextBox ID="txtComponentModal" runat="server" Font-Size="12px" CssClass="form-control" placeholder="Enter Component Name"></asp:TextBox>
                                                </div>

                                                <div class="mb-2">
                                                    <asp:Label ID="lblPercentage" runat="server" Text="Percentage" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                    <asp:TextBox ID="txtPercentageModal" runat="server" CssClass="form-control" Font-Size="12px" placeholder="Enter Percentage"></asp:TextBox>

                                                </div>

                                                <div class="mb-2">
                                                    <asp:Label ID="lblAmount" runat="server" Text="Amount" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                    <asp:TextBox ID="txtAmountModal" runat="server" Text="0" CssClass="form-control" Font-Size="12px" placeholder="Enter Amount" TextMode="Number"></asp:TextBox>

                                                </div>

                                                <div class="mb-2">
                                                    <asp:Label ID="lblCategory" runat="server" Text="Category Type" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                    <asp:DropDownList ID="ddlCatTypeModal" runat="server" CssClass="form-control form-select" Font-Size="12px">
                                                        <%--  <asp:ListItem Text="Select Type" Value="0" ></asp:ListItem>--%>
                                                        <asp:ListItem Text="Addition" Value="1" Selected="True"></asp:ListItem>
                                                        <%--  <asp:ListItem Text="Deduction" Value="2"></asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </div>


                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                    <div class="modal-footer mb-2">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" OnClick="btnSave_Click" ValidationGroup="SaveITEM" />
                                        &nbsp;&nbsp;
                                              <button type="button" class="btn btn-sm btn-danger" data-bs-dismiss="modal">Close </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Modal for Components-->


                        <div class="col-md-7 col-xs-7 col-sm-7 col-lg-7"></div>

                        <div class="col-md-1 col-xs-1 col-sm-1 col-lg-1">
                            <div class="input-group">
                                <%--<asp:Button ID="btnTest" runat="server" Text="Test" CssClass="btn btn-sm btn-primary font-medium" OnClick="btnTest_Click1" />--%>

                                <!-- Button trigger modal -->

                                <button type="button" id="btnmodalPopupTest" class="btn btn-sm btn-success font-medium" data-bs-toggle="modal"
                                    data-bs-target="#TestID">
                                    Test
                                </button>
                            </div>
                        </div>

                        <!-- Modal for Test-->
                        <div class="modal fade" id="TestID" data-bs-backdrop="static"
                            data-bs-keyboard="true" tabindex="-1" aria-labelledby="scroll-long-inner-modal"
                            aria-hidden="true">
                            <div class="modal-dialog modal-lg modal-dialog-scrollable">
                                <div class="modal-content">
                                    <div class="modal-header d-flex align-items-center">
                                        <h4 class="modal-title" id="myLargeModalLabelTest"></h4>
                                        <%--<button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>--%>
                                    </div>
                                    <div class="modal-body">
                                        <asp:UpdatePanel runat="server" ID="updatepnl">
                                            <ContentTemplate>
                                                <div class="row">
                                                    <div class="card-title">
                                                        <asp:Label ID="Label1" runat="server" Text="" Font-Bold="true" Font-Size="20px"></asp:Label>
                                                        <div class="card">
                                                            <div class="card-body">
                                                                <h5 class="card-title">Test Pre Salary Structure</h5>
                                                                <hr />
                                                                <div class="row">
                                                                    <div class="col-md-4 col-sm-4 col-lg-4">
                                                                        <div class="form-group">
                                                                            <asp:Label ID="lblTestClass" runat="server" Text="Class" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                                            <asp:DropDownList ID="ddlTestClass" runat="server" CssClass="form-control form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlTestClass_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlTestClass" ForeColor="Red" Font-Size="12px" Font-Bold="false" InitialValue="0" Display="Dynamic" ValidationGroup="SaveValidate" ErrorMessage="Select Class"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4 col-sm-4 col-lg-4">
                                                                        <asp:Label ID="lblPackage" runat="server" Text="Package" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                                        <asp:TextBox ID="txtPackage" runat="server" class="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="reqPackage" runat="server" ErrorMessage="Package" ControlToValidate="txtPackage" ForeColor="Red" Font-Bold="false" ValidationGroup="Structure"></asp:RequiredFieldValidator>

                                                                    </div>
                                                                    <div class="col-md-3 col-sm-3 col-lg-3">
                                                                        <br />
                                                                        <asp:Button ID="btnCalculate" runat="server" Text="Calculate" CssClass="btn btn-sm btn-primary" ValidationGroup="Structure" OnClick="btnCalculate_Click" />
                                                                    </div>
                                                                </div>
                                                                <br />
                                                                <h5 class="card-title">Component</h5>
                                                                <hr />

                                                                <div class="col-md-12 col-sm-12 col-lg-12">
                                                                    <!-- Grid View Component -->
                                                                    <asp:GridView ID="GridViewComponentModal" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
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
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField>
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblPercentage" runat="server" Text="Percentage" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                                                </HeaderTemplate>

                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblPercentage1" runat="server" Text='<%# Bind("Percentage") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField>
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblAmount" runat="server" Text="Monthly Amount" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                                                </HeaderTemplate>

                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtAmount1" runat="server" Text='<%# Bind("Amount") %>' Font-Size="12px" CssClass="form-control" Placeholder="Monthly Amount" TextMode="Number" Style="width: 150px" Visible="false" ValidationGroup="R"></asp:TextBox>
                                                                                    <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("Amount") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField>
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblAmountYr" runat="server" Text="Annual Amount" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                                                </HeaderTemplate>

                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblAmountYr1" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField>
                                                                                <HeaderTemplate>
                                                                                    <asp:LinkButton ID="btnOption" runat="server" Text="" ValidationGroup="setting"><i class="fas fa-cog"></i></asp:LinkButton>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="btnDeleteAnnualSal" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-rounded btn-danger" ValidationGroup="DelItemTender" Text="" OnClientClick="return confirm('Are you sure you want to delete?')" Visible="false"><i class="ti ti-trash"></i></asp:LinkButton>
                                                                                </ItemTemplate>

                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>

                                                                    <!-- End Grid View Component -->
                                                                </div>

                                                                <br />
                                                                <div id="Div1" runat="server" visible="true">
                                                                    <h5 class="card-title">Employeer Contribution</h5>
                                                                    <hr />
                                                                    <asp:Label ID="lblpcatid" runat="server" Text="" Visible="false"></asp:Label>
                                                                    <!-- Compansion Grid View -->
                                                                    <div class="col-md-12 col-sm-12 col-lg-12">

                                                                        <asp:GridView ID="GridViewEmpCompansionModal" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
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
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField>
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblPercentages" runat="server" Text="Percentages" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                                                    </HeaderTemplate>

                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblPercentages1" runat="server" Text='<%# Bind("Percentage") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField>
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblAmounts" runat="server" Text="Annual Amount" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                                                    </HeaderTemplate>

                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblAmounts1" runat="server" Text='<%# Bind("Amount") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField>
                                                                                    <HeaderTemplate>
                                                                                        <asp:LinkButton ID="btnOption" runat="server" Text="" ValidationGroup="setting"><i class="fas fa-cog"></i></asp:LinkButton>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="btnDeleteAnnualComp" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-rounded btn-danger" ValidationGroup="DeleteComp" Text="" OnClientClick="return confirm('Are you sure you want to delete?')" Visible="false"><i class="ti ti-trash"></i></asp:LinkButton>
                                                                                    </ItemTemplate>

                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                    <!--  Compansion Grid View -->
                                                                    <br />
                                                                    <br />
                                                                    <!-- Compansion Calculation -->
                                                                    <div class="row">
                                                                        <div class="col-md-4 col-sm-4 col-lg-4">

                                                                            <asp:Label ID="lblContributionPer" runat="server" Text="Contribution Percentage" CssClass="form-label"></asp:Label>
                                                                        </div>
                                                                        <div class="col-md-2 col-sm-2 col-lg-2">
                                                                            <asp:TextBox ID="txtContributionPer" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                                        </div>

                                                                        <div class="col-md-2 col-sm-2 col-lg-2">
                                                                            <asp:Label ID="lblContributionTotal" runat="server" Text="Yearly Total" CssClass="form-label"></asp:Label>
                                                                        </div>
                                                                        <div class="col-md-2 col-sm-2 col-lg-2">
                                                                            <asp:TextBox ID="txtContributionTotal" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                                                        </div>
                                                                        <%-- <div class="col-md-3 col-sm-3 col-lg-3">
                                                                            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                                                        </div>--%>
                                                                    </div>

                                                                    <!-- End Compansion Calculation -->
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                    </div>
                                    <br />
                                    <div class="modal-footer">
                                        <%--<asp:Button ID="Button1" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" OnClick="btnSave_Click" ValidationGroup="SaveITEM" />--%>
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnFetchValue" runat="server" Text="Close" CssClass="btn btn-sm btn-danger" OnClick="btnFetchValue_Click1" ValidationGroup="SaveITEM" />

                                        <%--<button type="button" class="btn btn-sm btn-danger" data-bs-dismiss="modal">Close </button>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Modal for Test-->

                    </div>
                    <br />
                    <br />
                    <br />
                    <hr />

                    <div class="row">
                        <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                            <div class="bd-example">
                                <div class="btn-group">
                                    <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                    <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                    <div class="dropdown-menu">
                                        <%--<asp:LinkButton ID="lnkbtnExcelSalary" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="lnkbtnExcelSalary_Click"></asp:LinkButton>--%>
                                        <asp:LinkButton ID="linkbtnPDFSalary" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnPDFSalary_Click"></asp:LinkButton>

                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>


                </div>

                <div class="row">
                    <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                          <asp:Label ID="lblClassSalaryId" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="prtIdnono" runat="server" Text="" CssClass="font-bold text-info" Font-Size="16px" Visible="false"></asp:Label><br />
                        <asp:Label ID="prtIdno2" runat="server" Text="" CssClass="font-bold text-info" Font-Size="16px" Visible="false"></asp:Label><br />

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
                        <asp:Label ID="lblphone" runat="server" Text="Phone:" CssClass="" Font-Bold="true" Visible="false"></asp:Label>
                        <asp:Label ID="lblphoneNo1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                        <asp:Label ID="lblvat" runat="server" Text="VAT NO:" CssClass="" Font-Bold="true" Visible="false"></asp:Label>
                        <asp:Label ID="lblVatNo1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                        <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" CssClass="" Font-Bold="true" Visible="false"></asp:Label>
                        <asp:Label ID="lblGSTNo1A" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12 col-sm-12 col-lg-12">
                        <!-- Grid View Component -->
                        <asp:GridView ID="GridViewComponent" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                            ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" FooterStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="true" OnRowDataBound="GridViewComponent_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblCompnent" runat="server" Text="Compnent" Font-Size="12px" Font-Bold="true"></asp:Label>
                                    </HeaderTemplate>
                                    <FooterTemplate>
                                        <%--<asp:TextBox ID="txtItem" runat="server" Text="" CssClass="form-control" Placeholder="Description"></asp:TextBox>--%>
                                        <asp:TextBox ID="txtCompnent" runat="server" TextMode="MultiLine" Text="" CssClass="form-control" Font-Size="12px" Placeholder="Compnent Name"></asp:TextBox>

                                    </FooterTemplate>
                                  <%--  <EditItemTemplate>
                                        <asp:TextBox ID="txtCompnentEditName" runat="server" placeholder="Enter Name Please" Text='<%# Eval("Perticular")%>' />
                                    </EditItemTemplate>--%>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCompnentID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                        <asp:Label ID="lblCompnentClassID" runat="server" Text='<%# Bind("ClassID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                        <asp:Label ID="lblComponentPertCateID" runat="server" Text='<%# Bind("PertCate_ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>

                                        <asp:Label ID="lblCompnent1" runat="server" Text='<%# Bind("Perticular") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblPercentage" runat="server" Text="Percentage" Font-Size="12px" Font-Bold="true"></asp:Label>
                                    </HeaderTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtPercentage" runat="server" TextMode="MultiLine" Font-Size="12px" Text="" CssClass="form-control" Placeholder="Percentage" OnTextChanged="txtPercentage_TextChanged"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPercentage1" runat="server" Text='<%# Bind("Percentage") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text="Amount" Font-Size="12px" Font-Bold="true"></asp:Label>
                                    </HeaderTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtAmount" runat="server" Text="0" Font-Size="12px" CssClass="form-control" AutoPostBack="true" Placeholder="Amount"></asp:TextBox>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtAmount1" runat="server" Text='<%# Bind("Amount") %>' Font-Size="12px" CssClass="form-control" Placeholder="Amount" TextMode="Number" Style="width: 150px" Visible="false" ValidationGroup="R"></asp:TextBox>
                                        <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("Amount") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblCatType" runat="server" Text="Catgory Type" Font-Size="12px" Font-Bold="true"></asp:Label>
                                    </HeaderTemplate>
                                    <FooterTemplate>
                                        <asp:DropDownList ID="ddlCatType1" runat="server" CssClass="form-control form-select" Font-Size="12px" Placeholder="Select Type">
                                            <%-- <asp:ListItem Text="Select Option" Value="0"></asp:ListItem>--%>
                                            <asp:ListItem Text="Addition" Value="Addition" Selected="True"></asp:ListItem>
                                            <%-- <asp:ListItem Text="Deduction" Value="Deduction"></asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCatType" runat="server" Text='<%# Bind("PerticularType") %>' Font-Size="12px" CssClass="form-control" Placeholder="Select Type" TextMode="Number" Style="width: 150px" Visible="false" ValidationGroup="R"></asp:TextBox>
                                        <asp:Label ID="lblCatType1" runat="server" Text='<%# Bind("PerticularType") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField Visible="false">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblPartCat" runat="server" Text="Category" Font-Size="12px" Font-Bold="true"></asp:Label>
                                    </HeaderTemplate>
                                    <FooterTemplate>
                                        <asp:DropDownList ID="ddlComponentCat1" runat="server" CssClass="form-control" Font-Size="12px">
                                            <asp:ListItem Value="0" Text="Select Type"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Component" Selected="True"></asp:ListItem>
                                            <%--  <asp:ListItem Value="2" Text="Employee Contribution"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Employee Deduction"></asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPertCateID" runat="server" Text='<%# Bind("PertCate_ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                        <asp:TextBox ID="txtPartCat1" runat="server" Text='<%# Bind("PertCategory") %>' Font-Size="12px" CssClass="form-control" Placeholder="Amount" TextMode="Number" Style="width: 150px" Visible="false" ValidationGroup="R"></asp:TextBox>
                                        <asp:Label ID="lblPartCat1" runat="server" Text='<%# Bind("PertCategory") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>
                              <%--  <asp:TemplateField>
                                    <HeaderTemplate>
                                          <asp:LinkButton ID="btnOption1" runat="server" Text="" ValidationGroup="setting"><i class="fas fa-cog"></i></asp:LinkButton>
                                        <asp:Label ID="btnOption2" runat="server" Text="Edit" Font-Size="12px" Font-Bold="true"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditComponent" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditComponent_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>--%>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="btnOption" runat="server" Text="" ValidationGroup="setting"><i class="fas fa-cog"></i></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDeleteComponent" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-rounded btn-danger" ValidationGroup="DelItemTender" Text="" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteComponent_Click" Visible="false"><i class="ti ti-trash"></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="btnAddComponent" runat="server" CssClass="btn btn-sm btn-rounded btn-info" Text="" TabIndex="9" OnClick="btnAddComponent_Click" ValidationGroup="ItemTender"><i class="ti ti-check"></i></asp:LinkButton>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                        <!-- End Grid View Component -->

                    </div>

                </div>

            </div>
        </div>



        <div id="EmpCompansion" runat="server" visible="false">
            <div class="card">
                <div class="card-body">

                    <div class="row">
                        <div class="col-md-8 col-xs-8 col-sm-8 col-lg-8">
                            <h5 class="card-title">B) Statutory Employer Contribution</h5>
                        </div>

                        <div class="col-md-4 col-xs-4 col-sm-4 col-lg-4">
                            <asp:Label ID="lblEmpContriPer" runat="server" Text="Employers Contribution Percentage : " Visible="true" Font-Size="Smaller" CssClass="text-end"></asp:Label>
                        </div>
                    </div>
                    <hr />

                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-4 col-xs-4 col-sm-4 col-lg-4">
                                <div class="input-group">
                                    <asp:DropDownList ID="ddlEmpCompansion" runat="server" OnSelectedIndexChanged="ddlEmpCompansion_SelectedIndexChanged" CssClass="form-select form-control" Font-Size="12px" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <!-- Button trigger modal -->

                                    <button type="button" id="btnmodalPopup1" class="btn btn-info btn-sm font-medium" data-bs-toggle="modal"
                                        data-bs-target="#CompansionID">
                                        +
                                    </button>
                                </div>
                            </div>
                            <!-- Button trigger modal -->

                            <!-- Compansion Modal -->
                            <div class="modal fade" id="CompansionID" data-bs-backdrop="static"
                                data-bs-keyboard="false" tabindex="-1" aria-labelledby="scroll-long-inner-modal"
                                aria-hidden="true">
                                <div class="modal-dialog modal-dialog-scrollable">
                                    <div class="modal-content">
                                        <div class="modal-header d-flex align-items-center">
                                            <h4 class="modal-title" id="myLargeModalLabel1"></h4>
                                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                        </div>
                                        <div class="modal-body">
                                            <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                                <ContentTemplate>
                                                    <h5 class="card-title" style="color: blue">Add Contribution</h5>
                                                    <hr />
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblClass2" runat="server" Text="Class" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                        <asp:DropDownList ID="ddlClass2" runat="server" CssClass="form-control form-select" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlClass2" ForeColor="Red" Font-Size="12px" Font-Bold="false" InitialValue="0" Display="Dynamic" ValidationGroup="SaveValidate" ErrorMessage="Select Class"></asp:RequiredFieldValidator>
                                                    </div>

                                                    <div class="mb-2">
                                                        <asp:Label ID="lblCompensionCat" runat="server" Text="Category" Font-Bold="true" Font-Size="12px" Visible="True"></asp:Label>
                                                        <asp:DropDownList ID="ddlCompensionCat" runat="server" CssClass="form-control form-select" Font-Size="12px" Readonly="true">

                                                            <%--  <asp:ListItem Value="0" Text="Select Type" ></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Component"></asp:ListItem>--%>
                                                            <asp:ListItem Value="2" Text="Employer Contribution"></asp:ListItem>
                                                            <%-- <asp:ListItem Value="3" Text="Employee Deduction" Selected="True" ></asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                    </div>


                                                    <div class="mb-2">
                                                        <asp:Label ID="lblComponentModComp" runat="server" Text="Component" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                        <asp:TextBox ID="txtComponentModComp" runat="server" Font-Size="12px" CssClass="form-control" placeholder="Enter Component Name"></asp:TextBox>
                                                    </div>

                                                    <div class="mb-2">
                                                        <asp:Label ID="lblPercentageModComp" runat="server" Text="Percentage" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                        <asp:TextBox ID="txtPercentageModComp" runat="server" CssClass="form-control" Font-Size="12px" placeholder="Enter Percentage"></asp:TextBox>

                                                    </div>

                                                    <div class="mb-2">
                                                        <asp:Label ID="lblAmountModComp" runat="server" Text="Amount" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                        <asp:TextBox ID="txtAmountModComp" runat="server" Text="0" CssClass="form-control" Font-Size="12px" placeholder="Enter Amount" TextMode="Number"></asp:TextBox>

                                                    </div>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>

                                        <div class="modal-footer">
                                            <asp:Button ID="btnSaveModalComp" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" OnClick="btnSaveModalComp_Click" ValidationGroup="SaveITEM" />
                                            &nbsp;&nbsp;
                                            <button type="button" class="btn btn-sm btn-danger" data-bs-dismiss="modal">Close </button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- Compansion Modal -->
                        </div>
                        <br />
                        <!-- Compansion Grid View -->
                        <div class="col-md-12 col-sm-12 col-lg-12">

                            <asp:GridView ID="GridViewEmpCompansion" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" FooterStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="true">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblCompnent" runat="server" Text="Compnent" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <FooterTemplate>
                                            <%--<asp:TextBox ID="txtItem" runat="server" Text="" CssClass="form-control" Placeholder="Description"></asp:TextBox>--%>
                                            <asp:TextBox ID="txtCompnents" runat="server" TextMode="MultiLine" Text="" CssClass="form-control" Font-Size="12px" Placeholder="Compnent Name"></asp:TextBox>

                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCompnentsID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                            <asp:Label ID="lblEmplyrCobtriPertCatID" runat="server" Text='<%# Bind("PertCate_ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                            <asp:Label ID="lblCompnentsClassID1" runat="server" Text='<%# Bind("ClassID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                            <asp:Label ID="lblCompnentsID1" runat="server" Text='<%# Bind("Perticular") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblPercentages" runat="server" Text="Percentages" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtPercentages" runat="server" TextMode="MultiLine" Font-Size="12px" Text="" CssClass="form-control" Placeholder="Percentages"></asp:TextBox>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPercentages1" runat="server" Text='<%# Bind("Percentage") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblAmounts" runat="server" Text="Amount" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtAmounts" runat="server" Text="0" Font-Size="12px" CssClass="form-control" AutoPostBack="true" Placeholder="Amounts"></asp:TextBox>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmounts1" runat="server" Text='<%# Bind("Amount") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="false">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblPartCat" runat="server" Text="Category" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="ddlCompasionCat" runat="server" CssClass="form-control" Font-Size="12px">
                                                <%--  <asp:ListItem Value="0" Text="Select Type" Selected="True"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Component"></asp:ListItem>--%>
                                                <asp:ListItem Value="2" Text=" Employer Contribution"></asp:ListItem>
                                                <%--  <asp:ListItem Value="3" Text="Employee Deduction"></asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPartCat" runat="server" Text='<%# Bind("PertCategory") %>' Font-Size="12px" CssClass="form-control" Placeholder="Amount" TextMode="Number" Style="width: 150px" Visible="false" ValidationGroup="R"></asp:TextBox>
                                            <asp:Label ID="lblPartCat1" runat="server" Text='<%# Bind("PertCategory") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="btnOption" runat="server" Text="" ValidationGroup="setting"><i class="fas fa-cog"></i></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDeleteComp" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-rounded btn-danger" ValidationGroup="DeleteComp" Text="" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteComp_Click" Visible="false"><i class="ti ti-trash"></i></asp:LinkButton>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="btnAddComp" runat="server" OnClick="btnAddComp_Click" CssClass="btn btn-sm btn-rounded btn-info" Text="" TabIndex="9" ValidationGroup="Comp"><i class="ti ti-check"></i></asp:LinkButton>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>



                        </div>
                        <!--  Compansion Grid View -->
                    </div>
                </div>
            </div>
        </div>


        <div id="EmployeeContribution" runat="server" visible="false">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-8 col-xs-8 col-sm-8 col-lg-8">
                            <h5 class="card-title">C) Employee Deduction</h5>

                        </div>
                        <div class="col-md-4 col-xs-4 col-sm-4 col-lg-4"></div>
                    </div>
                    <hr />
                    <div class="row">
                        <!-- Button trigger Start -->
                        <div class="col-md-4 col-xs-4 col-sm-4 col-lg-4">
                            <div class="input-group">
                                <asp:DropDownList ID="ddlEmpContribution" runat="server" OnSelectedIndexChanged="ddlEmpContribution_SelectedIndexChanged" CssClass="form-select form-control" Font-Size="12px" AutoPostBack="true">
                                </asp:DropDownList>
                                <!-- Button trigger modal -->

                                <button type="button" id="btnmodalPopup2" class="btn btn-info btn-sm font-medium" data-bs-toggle="modal"
                                    data-bs-target="#EmpContributionID">
                                    +
                                </button>
                            </div>
                        </div>
                        <!-- Button trigger End -->

                        <div class="col-md-8 col-xs-8 col-sm-8 col-lg-8"></div>
                    </div>

                    <div class="col-md-12 col-sm-12 col-lg-12">
                        <div class="row">
                            <!-- EmpContribution Modal Start-->
                            <div class="modal fade" id="EmpContributionID" data-bs-backdrop="static"
                                data-bs-keyboard="false" tabindex="-1" aria-labelledby="scroll-long-inner-modal"
                                aria-hidden="true">

                                <div class="modal-dialog modal-dialog-scrollable">
                                    <div class="modal-content">
                                        <div class="modal-header d-flex align-items-center">
                                            <h4 class="modal-title" id="myLargeModalLabel2"></h4>
                                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                        </div>

                                        <div class="modal-body">
                                            <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                                                <ContentTemplate>
                                                    <h5 class="card-title" style="color: blue">Add Employee Deduction</h5>
                                                    <hr />
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblEmpDeduction" runat="server" Text="Class" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                        <asp:DropDownList ID="ddlEmpDeduction" runat="server" CssClass="form-control form-select" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlEmpDeduction" ForeColor="Red" Font-Size="12px" Font-Bold="false" InitialValue="0" Display="Dynamic" ValidationGroup="SaveValidate" ErrorMessage="Select Class"></asp:RequiredFieldValidator>
                                                    </div>

                                                    <div class="mb-2">
                                                        <asp:Label ID="lblDeductin" runat="server" Text="Category" Font-Bold="true" Font-Size="12px" Visible="True"></asp:Label>
                                                        <asp:DropDownList ID="ddlDeductin" runat="server" CssClass="form-control" Font-Size="12px">
                                                            <%-- <asp:ListItem Value="0" Text="Select Type"></asp:ListItem>--%>
                                                            <%--  <asp:ListItem Value="0" Text="Select Type" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Component"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Employer Contribution"></asp:ListItem>--%>
                                                            <asp:ListItem Value="3" Text="Employee Deduction" Selected="True"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                    <div class="mb-2">
                                                        <asp:Label ID="lblDeductionComp" runat="server" Text="Component" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                        <asp:TextBox ID="txtDeductionComp" runat="server" Font-Size="12px" CssClass="form-control" placeholder="Enter Component Name"></asp:TextBox>
                                                    </div>

                                                    <div class="mb-2">
                                                        <asp:Label ID="lblDeductionPerccentage" runat="server" Text="Percentage" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                        <asp:TextBox ID="txtDeductionPerccentage" runat="server" CssClass="form-control" Font-Size="12px" placeholder="Enter Percentage"></asp:TextBox>

                                                    </div>

                                                    <div class="mb-2">
                                                        <asp:Label ID="lblDeductionAmount" runat="server" Text="Amount" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                        <asp:TextBox ID="txtDeductionAmount" runat="server" Text="0" CssClass="form-control" Font-Size="12px" placeholder="Enter Amount" TextMode="Number"></asp:TextBox>

                                                    </div>

                                                    <div class="mb-2">
                                                        <asp:Label ID="lblDeductionType" runat="server" Text="Category Type" Font-Bold="true" Font-Size="12px"></asp:Label>
                                                        <asp:DropDownList ID="ddlDeductionType" runat="server" CssClass="form-control" Font-Size="12px">
                                                            <%--  <asp:ListItem Text="Select Type" Value="0" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Addition" Value="1"></asp:ListItem>--%>
                                                            <asp:ListItem Text="Deduction" Value="2" Selected="True"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                </ContentTemplate>

                                            </asp:UpdatePanel>
                                        </div>

                                        <div class="modal-footer mb-2">

                                            <asp:Button ID="btnSaveEmpDeductionModal" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" OnClick="btnSaveEmpDeductionModal_Click" ValidationGroup="SaveITEM2" />
                                            &nbsp;&nbsp;
                                            <button type="button" class="btn btn-sm btn-danger" data-bs-dismiss="modal" id="btnClose">Close </button>

                                        </div>
                                    </div>
                                </div>



                                <!-- EmpContribution Modal END-->



                                <%-- <hr />--%>
                                <%--  <div class="modal-footer">--%>
                            </div>



                        </div>

                    </div>
                </div>
                <!-- EmpContribution Modal Start-->
            </div>


            <div class="card shadow-none">
                <div class="card-body shadow-none">

                    <div class="row">

                        <div class="col-md-12 col-sm-12 col-lg-12">

                            <!-- EmpContribution Grid View -->
                            <asp:GridView ID="EmpContributionGridView" runat="server" ScrollBars="Both" CssClass="table table-bordered" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" FooterStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="true">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblDeduction" runat="server" Text="Compnent" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <FooterTemplate>

                                            <asp:TextBox ID="txtDeductionComp" runat="server" TextMode="MultiLine" Text="" CssClass="form-control" Font-Size="12px" Placeholder="Compnent Name"></asp:TextBox>

                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDeductionCompID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                            <asp:Label ID="lblDeductionPertCatID" runat="server" Text='<%# Bind("PertCate_ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                            <asp:Label ID="lblClassID" runat="server" Text='<%# Bind("ClassID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                            <asp:Label ID="lblDeductionCompID1" runat="server" Text='<%# Bind("Perticular") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblDeductionPercentages" runat="server" Text="Percentages" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtDeductionPercentages" runat="server" TextMode="MultiLine" Font-Size="12px" Text="" CssClass="form-control" Placeholder="Percentages"></asp:TextBox>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDeductionPercentages1" runat="server" Text='<%# Bind("Percentage") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblDeductionAmounts" runat="server" Text="Amount" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtDeductionAmounts" runat="server" Text="0" Font-Size="12px" CssClass="form-control" AutoPostBack="true" Placeholder="Amounts"></asp:TextBox>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDeductionAmounts1" runat="server" Text='<%# Bind("Amount") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="false">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblPartCat" runat="server" Text="Category" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="ddlDeductionCat" runat="server" CssClass="form-control" Font-Size="12px">
                                                <%-- <asp:ListItem Value="0" Text="Select Type" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Component"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Employee Contribution"></asp:ListItem>--%>
                                                <asp:ListItem Value="3" Text="Employee Deduction"></asp:ListItem>
                                            </asp:DropDownList>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDeductionCat" runat="server" Text='<%# Bind("PertCategory") %>' Font-Size="12px" CssClass="form-control" Placeholder="Amount" TextMode="Number" Style="width: 150px" Visible="false" ValidationGroup="R"></asp:TextBox>
                                            <asp:Label ID="lblDeductionCat1" runat="server" Text='<%# Bind("PertCategory") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="btnOption" runat="server" Text="" ValidationGroup="setting"><i class="fas fa-cog"></i></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDeleteEmpDeduction" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-rounded btn-danger" ValidationGroup="DeleteComp" Text="" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteEmpDeduction_Click" Visible="false"><i class="ti ti-trash"></i></asp:LinkButton>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="btnAddEmpDeduction" runat="server" OnClick="btnAddEmpDeduction_Click" CssClass="btn btn-sm btn-rounded btn-info" Text="" TabIndex="9" ValidationGroup="Comp"><i class="ti ti-check"></i></asp:LinkButton>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                            <!--  EmpContribution Grid View -->
                        </div>
                    </div>


                </div>




            </div>

        </div>
    </div>

    <style>
        .text-right {
            text-align: right;
        }
    </style>
</asp:Content>

