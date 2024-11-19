<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="MatoshreeProject.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridTask = $("#GridTask").prepend($("<thead></thead>").append($("#GridTask").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true
                });

            var GridProject = $("#GridProject").prepend($("<thead></thead>").append($("#GridProject").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true
                });

            var GridWorkorderlist = $("#GridWorkorderlist").prepend($("<thead></thead>").append($("#GridWorkorderlist").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true
                });

            var Gridticket = $("#Gridticket").prepend($("<thead></thead>").append($("#Gridticket").find("tr:first"))).DataTable(
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
    <!-- Container fluid  -->

    <div class="container-fluid">
        <div id="showdashboard" runat="server" visible="true">
            <div class="row">
                <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                    <!-- -------------------------------------------------------------- -->
                    <!-- Breadcrumb -->
                    <!-- -------------------------------------------------------------- -->
                    <div class="font-weight-medium shadow-none position-relative overflow-hidden mb-7">
                        <div class="card-body px-0">
                            <div class="d-flex justify-content-between align-items-center">
                                <div>
                                    <h5 class="font-weight-medium mb-0">Dashboard</h5>
                                    <nav aria-label="breadcrumb">
                                        <ol class="breadcrumb">
                                            <li class="breadcrumb-item">
                                                <a class="text-muted text-decoration-none" href="Dashboard.aspx">Home
                                                </a>
                                            </li>
                                            <li class="breadcrumb-item text-muted" aria-current="page">Dashboard</li>
                                        </ol>
                                    </nav>
                                </div>
                                <div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- -------------------------------------------------------------- -->
                    <!-- Breadcrumb End -->
                    <!-- -------------------------------------------------------------- -->
                </div>
                <div class="col-md-4 col-sm-4 col-xl-4 col-lg-4 text-end">
                    <!-- -------------------------------------------------------------- -->
                    <!-- Dashboard Setting Button
                    <!-- -------------------------------------------------------------- -->
                    <asp:LinkButton ID="btnDashBoardSetting" runat="server" CommandName="DashBoardSetting" CssClass="btn btn-sm btn-outline-info btnmodalPopup" data-bs-toggle="modal" data-bs-target="#AddDashBoadSetting"><i class="ti ti-settings">DashBoard Setting</i></asp:LinkButton>
                </div>

            </div>
            <br />
            <%-- Modal Popup --%>
            <div class="row">
                <div class="col-md-12 col-sm-12 col-lg-12  col-xs-12">
                    <div class="modal fade" id="AddDashBoadSetting" data-bs-backdrop="static"
                        data-bs-keyboard="false" tabindex="-1" aria-labelledby="scroll-long-inner-modal"
                        aria-hidden="true">
                        <div class="modal-dialog modal-dialog-scrollable" style="width: 50%; height: 70%">
                            <div class="modal-content">
                                <div class="modal-header d-flex align-items-center">
                                    <h4 class="modal-title" id="myLargeModalLabel1">Dashbord Setting</h4>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">
                                    <asp:UpdatePanel runat="server" ID="updatepnl">
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="col-md-12 col-sm-12 col-lg-12  col-xs-12">
                                                    <div id="ExpDiv" runat="server" visible="true">
                                                        <div class="row">
                                                            <div class="col-md-12 col-sm-12 col-lg-12  col-xs-12">
                                                                <div class="mb-2">
                                                                    <asp:Label ID="lblvisibilityWgv" runat="server" Text="" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblDepID" runat="server" Font-Size="12px" Text="" Visible="false" CssClass="form-label"></asp:Label>
                                                                    <asp:Label ID="lblDeptName11" runat="server" Font-Size="12px" Text="" Visible="false" CssClass="form-label"></asp:Label>
                                                                    <asp:Label ID="lblDepartment" runat="server" Font-Size="12px" Text="Department" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                                    <asp:DropDownList ID="ddlDepartment" runat="server" Font-Size="12px" CssClass="form-control form-select" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Font-Size="12px" runat="server" ControlToValidate="ddlDepartment" ForeColor="Red" Font-Bold="false" InitialValue="0" Display="Dynamic" ValidationGroup="DashboardSettin" ErrorMessage="Select Department"></asp:RequiredFieldValidator>
                                                                </div>
                                                                <br />
                                                            </div>

                                                        </div>

                                                        <div class="row">
                                                            <div class="col-md-12 col-sm-12 col-lg-12">
                                                                <h5>View DashBoard Setting</h5>

                                                                <hr />
                                                                <asp:GridView ID="GVDBSetting" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable"
                                                                    EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" OnRowDataBound="GVDBSetting_RowDataBound" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                                                                    <Columns>

                                                                        <asp:TemplateField HeaderText="DivID" SortExpression="DivID" HeaderStyle-Font-Size="12px" Visible="false">

                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDivID1" runat="server" Text='<%# Bind("DivID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Name" SortExpression="DivName" HeaderStyle-Font-Size="12px">

                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDivName1" runat="server" Text='<%# Bind("DivName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Font-Size="12px">

                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbDescription1" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Role" SortExpression="RoleName" HeaderStyle-Font-Size="12px">


                                                                            <ItemTemplate>

                                                                                <asp:CheckBoxList ID="cHkListRole" runat="server" Font-Bold="false" Font-Size="12px" CssClass="list-group text-dark" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Status" SortExpression="PageName" Visible="false" HeaderStyle-Font-Size="12px">

                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDBStatus1" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                    </Columns>
                                                                </asp:GridView>

                                                            </div>

                                                        </div>

                                                        <div class="row">
                                                            <div class="col-md-12 col-sm-12 col-lg-12">
                                                                <div class="mb-2 text-center">
                                                                    <asp:Button ID="btnPermission" runat="server" Text="Set Permission" CssClass="btn btn-sm btn-info" OnClick="btnPermission_Click" />
                                                                    &nbsp;&nbsp;
                                                                <asp:Button ID="btnGVClear" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" OnClick="btnGVClear_Click" />
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>

                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="modal-footer">
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <%-- Modal Popup --%>

            <!-- -------------------------------------------------------------- -->
            <!-- Dashboard Setting Button
            <!-- -------------------------------------------------------------- -->

            <!-- Top Cards  -->
            <!-- New Row -->
            <div id="DivCountdata" runat="server" visible="true">
                <div class="row">
                    <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
                        <div class="card">
                            <a href="Chart_List_Invoice.aspx" class="stretched-link"></a>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-4">
                                        <div class="bg-warning-subtle text-warning rounded d-flex align-items-center p-8 justify-content-center">
                                            <i class="ti ti-receipt fs-8"></i>
                                        </div>
                                    </div>
                                    <div class="col-8 d-flex align-items-center justify-content-end text-end">
                                        <div>
                                            <asp:Label ID="Label3" runat="server" Text="" Visible="false" CssClass="text-success"></asp:Label>

                                            <asp:Label ID="lblinvWatingCont" runat="server" Text="0/0" Font-Size="12px" CssClass="text-info" Visible="false"></asp:Label>

                                            <h4 class="card-title">

                                                <asp:Label ID="lblinvWatingPer" runat="server" Text="0%" CssClass="text-dark"></asp:Label></h4>
                                            <h6 class="card-subtitle mb-0">INVOICES PAYMENT</h6>
                                        </div>
                                    </div>
                                </div>
                                <div class="progress mt-3 text-bg-light">
                                    <div id="DivInvoiceWati" runat="server" class="progress-bar text-bg-warning" role="progressbar" style="width: 26%; height: 6px;"
                                        aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
                        <div class="card">
                            <a href="WorkOrder.aspx" class="stretched-link"></a>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-4">
                                        <div class="bg-primary-subtle text-primary rounded d-flex align-items-center p-8 justify-content-center">
                                            <i class="ti ti-chart-pie fs-8"></i>
                                        </div>
                                    </div>
                                    <div class="col-8 d-flex align-items-center justify-content-end text-end">
                                        <div>
                                            <asp:Label ID="lblTotalWorkOrderAccepted" runat="server" Text="" Visible="false" CssClass="text-success" Font-Size="12px"></asp:Label>

                                            <asp:Label ID="lblWorkOrderAccepted" runat="server" Text="0/0" CssClass="text-info" Font-Size="12px" Visible="false"></asp:Label>

                                            <h4 class="card-title">
                                                <asp:Label ID="lblPercentWorkOrderAccepted" runat="server" Text="0%" CssClass="text-dark"></asp:Label>
                                            </h4>
                                            <h6 class="card-subtitle mb-0">WORK ORDER ACCEPTED</h6>
                                        </div>
                                    </div>
                                </div>
                                <div class="progress mt-3 text-bg-light">
                                    <div id="ProgressWorkOrderAccepted" class="progress-bar text-bg-primary" role="progressbar" style="width: 26%; height: 6px;"
                                        aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" runat="server">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
                        <div class="card">
                            <a href="Projects.aspx" class="stretched-link"></a>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-4">
                                        <div class="bg-danger-subtle text-danger rounded d-flex align-items-center p-8 justify-content-center">
                                            <i class="ti ti-briefcase fs-8"></i>
                                        </div>
                                    </div>
                                    <div class="col-8 d-flex align-items-center justify-content-end text-end">
                                        <div>
                                            <asp:Label ID="lblTotalProjectCount" runat="server" Text="" Visible="false" ForeColor="Blue" Font-Size="12px"></asp:Label>

                                            <asp:Label ID="lblInprogress" runat="server" Text="0/0" ForeColor="Blue" Font-Size="12px" Visible="false"></asp:Label>


                                            <h4 class="card-title">
                                                <asp:Label ID="lblPercentInprogress" runat="server" Text="0"></asp:Label>
                                            </h4>
                                            <h6 class="card-subtitle mb-0">PROJECTS IN PROGRESS </h6>
                                        </div>
                                    </div>
                                </div>
                                <div class="progress mt-3 text-bg-light">
                                    <div id="ProgressInProgress" class="progress-bar text-bg-danger" role="progressbar" style="width: 26%; height: 6px;"
                                        aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" runat="server">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
                        <div class="card">
                            <a href="TaskDetailsStaff.aspx" class="stretched-link"></a>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-4">
                                        <div class="bg-success-subtle text-success rounded d-flex align-items-center p-8 justify-content-center">
                                            <i class="ti ti-checks fs-8"></i>
                                        </div>
                                    </div>
                                    <div class="col-8 d-flex align-items-center justify-content-end text-end">
                                        <div>
                                            <asp:Label ID="lblTotalTask" runat="server" Text="" Visible="false" ForeColor="Blue" Font-Size="12px"></asp:Label>

                                            <asp:Label ID="lblNotFinishedtask" runat="server" Text="0/0" ForeColor="Blue" Font-Size="12px" Visible="false"></asp:Label>

                                            <h4 class="card-title">

                                                <asp:Label ID="lblPercentTask" runat="server" Text="0"></asp:Label>
                                            </h4>
                                            <h6 class="card-subtitle mb-0">TASKS IN PROGRESS
                                            </h6>
                                        </div>
                                    </div>
                                </div>
                                <div class="progress mt-3 text-bg-light">
                                    <div id="ProgressNotFinished" class="progress-bar text-bg-success" role="progressbar" style="width: 26%; height: 6px;"
                                        aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" runat="server">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- End Row -->


            <!-- ESTIMATES AND TODO BOX -->
            <div class="row">
                <!-- ESTIMATES OVERVIEW -->
                <div class="col-md-8 col-sm-8 col-lg-8 col-xs-8">
                    <div id="DivINVOICEOVERVIEW" runat="server" visible="true">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-6 col-lg-4 col-sm-6">
                                        <h6>INVOICE OVERVIEW
                                        </h6>
                                        <hr />
                                        <%-- UNPAID --%>
                                        <div>
                                            <h6>UNPAID</h6>
                                            <div class="col-md-8 ">
                                                <asp:Label ID="lblTotalInvoiceCount" runat="server" Text="" Visible="false" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                                <div class="text-right">
                                                    <asp:Label ID="lblUnpaid" runat="server" Text="0/0" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                                    <asp:Label ID="lblPercentUnpaid" runat="server" Text="0" CssClass="marleft50" Font-Size="12px"></asp:Label>
                                                </div>
                                                <div class="progress">
                                                    <div id="ProgressUnpaid" runat="server" class="progress-bar progress-bar-striped bg-danger" role="progressbar" style="width: 85%" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <%-- PAID --%>
                                        <div>
                                            <h6>PAID</h6>
                                            <div class="col-md-8 ">
                                                <div class="text-right">
                                                    <asp:Label ID="lblPaid" runat="server" Text="0/0" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                                    <asp:Label ID="lblPercentPaid" runat="server" Text="0" CssClass="marleft50" Font-Size="12px"></asp:Label>
                                                </div>
                                                <div class="progress">
                                                    <div id="ProgressPaid" runat="server" class="progress-bar progress-bar-striped bg-success" role="progressbar" style="width: 18%" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <%-- PARTAILLY PAID --%>
                                        <div>
                                            <h6>PARTAILLY PAID </h6>
                                            <div class="col-md-8 ">

                                                <div class="text-right">
                                                    <asp:Label ID="lblPartiallyPaid" runat="server" Text="0/0" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                                    <asp:Label ID="lblPercentPartiallyPaid" runat="server" Text="0" CssClass="marleft50" Font-Size="12px"></asp:Label>
                                                </div>
                                                <div class="progress">
                                                    <div id="ProgressPartiallyPaid" runat="server" class="progress-bar progress-bar-striped bg-cyan" role="progressbar" style="width: 56%" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <%-- CANCELED --%>
                                        <div>
                                            <h6>CANCELED</h6>
                                            <div class="col-md-8 ">
                                                <div class="text-right">
                                                    <asp:Label ID="lblInvoiceCancele" runat="server" Text="0/0" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                                    <asp:Label ID="lblPercentInvoiceCancele" runat="server" Text="0" CssClass="marleft50" Font-Size="12px"></asp:Label>
                                                </div>
                                                <div class="progress">
                                                    <div id="ProgressInvoiceCancele" runat="server" class="progress-bar progress-bar-striped" role="progressbar" style="width: 50%" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <%-- DRAFT --%>
                                        <div>
                                            <h6>DRAFT</h6>
                                            <div class="col-md-8 ">
                                                <div class="text-right">
                                                    <asp:Label ID="lblInvoiceDraft" runat="server" Text="0/0" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                                    <asp:Label ID="lblInvoicePercentDraft" runat="server" Text="0" CssClass="marleft50" Font-Size="12px"></asp:Label>
                                                </div>
                                                <div class="progress">
                                                    <div id="ProgressInvoiceDraft" runat="server" class="progress-bar progress-bar-striped bg-dark" role="progressbar" style="width: 38%" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <%--OVERDUE--%>
                                        <div>
                                            <h6>OVERDUE</h6>
                                            <div class="col-md-8 ">
                                                <div class="text-right">
                                                    <asp:Label ID="lblInvoiceOverdue" runat="server" Text="0/0" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                                    <asp:Label ID="lblPercentOverdue" runat="server" Text="0" CssClass="marleft50" Font-Size="12px"></asp:Label>
                                                </div>
                                                <div class="progress">
                                                    <div id="ProgressOverdue" runat="server" class="progress-bar progress-bar-striped bg-warning" role="progressbar" style="width: 83%" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-6 col-lg-4 col-sm-6">
                                        <h6>ESTIMATE OVERVIEW</h6>
                                        <hr />
                                        <%-- hide notsend--%>
                                        <div id="notsend" runat="server" visible="false">
                                            <h6>NOT SEND</h6>
                                            <div class="col-md-8 ">
                                                <asp:Label ID="lblTotalEstimateCount" runat="server" Text="" Visible="false" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                                <div class="text-right">
                                                    <asp:Label ID="lblNotsend" runat="server" Text="0/0" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                                    <asp:Label ID="lblPersentNotSend" runat="server" Text="0" CssClass="marleft50" Font-Size="12px"></asp:Label>
                                                </div>
                                                <div class="progress">
                                                    <div id="ProgressNotSend" runat="server" class="progress-bar progress-bar-striped bg-light" role="progressbar" style="width: 85%" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <%-- hide notsend--%>
                                        <div>
                                            <h6>INVOICED</h6>
                                            <div class="col-md-8 ">
                                                <div class="text-right">
                                                    <asp:Label ID="lblInvoiced" runat="server" Text="0/0" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                                    <asp:Label ID="lblpercentInvoiced" runat="server" Text="0" CssClass="marleft50" Font-Size="12px"></asp:Label>
                                                </div>
                                                <div class="progress">
                                                    <div id="ProgressInvoiced" runat="server" class="progress-bar progress-bar-striped bg-megna" role="progressbar" style="width: 18%" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <%-- hide notINVOICED--%>
                                        <div id="notINVOICED" runat="server" visible="false">
                                            <h6>NOT INVOICED</h6>
                                            <div class="col-md-8 ">

                                                <div class="text-right">
                                                    <asp:Label ID="lblNotInvoiced" runat="server" Text="0/0" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                                    <asp:Label ID="lblPersentNotInvoiced" runat="server" Text="0" CssClass="marleft50" Font-Size="12px"></asp:Label>
                                                </div>
                                                <div class="progress">
                                                    <div id="ProgressNotInvoiced" runat="server" class="progress-bar progress-bar-striped bg-body" role="progressbar" style="width: 56%" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <%-- hide notINVOICED--%>
                                        <div>
                                            <h6>DRAFT</h6>
                                            <div class="col-md-8 ">

                                                <div class="text-right">
                                                    <asp:Label ID="lblDraft" runat="server" Text="0/0" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                                    <asp:Label ID="lblPersentDraft" runat="server" Text="0" CssClass="marleft50" Font-Size="12px"></asp:Label>
                                                </div>
                                                <div class="progress">
                                                    <div id="ProgressDraft" runat="server" class="progress-bar progress-bar-striped bg-dark" role="progressbar" style="width: 50%" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div>
                                            <h6>SEND</h6>
                                            <div class="col-md-8 ">

                                                <div class="text-right">
                                                    <asp:Label ID="lblSend" runat="server" Text="0/0" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                                    <asp:Label ID="lblPersentSend" runat="server" Text="0" CssClass="marleft50" Font-Size="12px"></asp:Label>
                                                </div>
                                                <div class="progress">
                                                    <div id="ProgressSend" runat="server" class="progress-bar progress-bar-striped bg-cyan" role="progressbar" style="width: 38%" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div>
                                            <h6>EXPIRED</h6>
                                            <div class="col-md-8 ">
                                                <div class="text-right">
                                                    <asp:Label ID="lblExpired" runat="server" Text="0/0" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                                    <asp:Label ID="lblPercentExpired" runat="server" Text="0" CssClass="marleft50" Font-Size="12px"></asp:Label>
                                                </div>
                                                <div class="progress">
                                                    <div id="ProgressExpired" runat="server" class="progress-bar progress-bar-striped bg-danger" role="progressbar" style="width: 83%" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div>
                                            <h6>ACCEPTED</h6>
                                            <div class="col-md-8 ">
                                                <div class="text-right">
                                                    <asp:Label ID="lblEstimateAccepted" runat="server" Text="0/0" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                                    <asp:Label ID="lblPercentEstimateAccepted" runat="server" Text="0" CssClass="marleft50" Font-Size="12px"></asp:Label>
                                                </div>
                                                <div class="progress">
                                                    <div id="ProgressEstimateAccepted" runat="server" class="progress-bar progress-bar-striped bg-success" role="progressbar" style="width: 83%" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div>
                                            <h6>DECLINED</h6>
                                            <div class="col-md-8 ">
                                                <div class="text-right">
                                                    <asp:Label ID="lblEstimateDeclined" runat="server" Text="0/0" ForeColor="Orange" Font-Size="12px"></asp:Label>
                                                    <asp:Label ID="lblPercentEstimateDecline" runat="server" Text="0" CssClass="marleft50" Font-Size="12px"></asp:Label>
                                                </div>
                                                <div class="progress">
                                                    <div id="ProgressEstimateDecline" runat="server" class="progress-bar progress-bar-striped bg-warning" role="progressbar" style="width: 83%" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-6 col-lg-4 col-sm-6">
                                        <h6>WORK ORDER OVERVIEW</h6>
                                        <hr />
                                        <div>
                                            <h6>WORKORDER</h6>
                                            <div class="col-md-8 ">
                                                <asp:Label ID="lbltotatWorkOrdercount" runat="server" Text="" Visible="false" Font-Size="12px"></asp:Label>
                                                <div class="text-right">
                                                    <asp:Label ID="lblWorkOrder" runat="server" Text="0/0" CssClass="text-purple" Font-Size="12px"></asp:Label>
                                                    <asp:Label ID="lblPercentWorkOrder" runat="server" Text="0" CssClass="marleft50" Font-Size="12px"></asp:Label>
                                                </div>
                                                <div class="progress">
                                                    <div id="TotalProgressWorkOrderNumber" runat="server" class="progress-bar progress-bar-striped bg-primary" role="progressbar" style="width: 81%" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div>
                                            <h6>DECLINED</h6>
                                            <div class="col-md-8 ">
                                                <div class="text-right">
                                                    <asp:Label ID="lblWorkOrderdeclined" runat="server" Text="0/0" CssClass="text-danger" Font-Size="12px"></asp:Label>
                                                    <asp:Label ID="lblPercentDeclined" runat="server" Text="0" CssClass="marleft50" Font-Size="12px"></asp:Label>
                                                </div>
                                                <div class="progress">
                                                    <div id="ProgressDeclined" runat="server" class="progress-bar progress-bar-striped bg-danger" role="progressbar" style="width: 81%" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div>
                                            <h6>ACCEPTED</h6>
                                            <div class="col-md-8 ">
                                                <div class="text-right">
                                                    <asp:Label ID="lblWorkOrderaccept" runat="server" Text="0/0" CssClass="text-success" Font-Size="12px"></asp:Label>
                                                    <asp:Label ID="lblWorkOrderPercentAccept" runat="server" Text="0" CssClass="marleft50" Font-Size="12px"></asp:Label>
                                                </div>
                                                <div class="progress">
                                                    <div id="ProgressAccepted" runat="server" class="progress-bar progress-bar-striped bg-success" role="progressbar" style="width: 81%" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div>
                                            <h6>CANCELED</h6>
                                            <div class="col-md-8 ">
                                                <div class="text-right">
                                                    <asp:Label ID="lblcanceled" runat="server" Text="0/0" CssClass="text-danger" Font-Size="12px"></asp:Label>

                                                    <asp:Label ID="lblPercentagecanceled" runat="server" Text="0" CssClass="marleft50" Font-Size="12px"></asp:Label>
                                                </div>
                                                <div class="progress">
                                                    <div id="ProgressCanceled" runat="server" class="progress-bar progress-bar-striped bg-danger" role="progressbar" style="width: 81%" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />

                                        <div>
                                            <h6>PUBLISHED</h6>
                                            <div class="col-md-8 ">
                                                <div class="text-right">
                                                    <asp:Label ID="lblWorkOrderPublished" runat="server" Text="0/0" CssClass="text-success" Font-Size="12px"></asp:Label>

                                                    <asp:Label ID="lblPercentWorkOrderPublished" runat="server" Text="0" CssClass="marleft50" Font-Size="12px"></asp:Label>
                                                </div>
                                                <div class="progress">
                                                    <div id="ProgressWorkOrderPublished" runat="server" class="progress-bar progress-bar-striped bg-success" role="progressbar" style="width: 81%" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div>
                                            <h6>NOT PUBLISHED</h6>
                                            <div class="col-md-8 ">
                                                <div class="text-right">
                                                    <asp:Label ID="lblWorkOrderNotPublished" runat="server" Text="0/0" CssClass="text-warning" Font-Size="12px"></asp:Label>
                                                    <asp:Label ID="lblPercentWorkOrderNotPublished" runat="server" Text="0" CssClass="marleft50" Font-Size="12px"></asp:Label>
                                                </div>
                                                <div class="progress">
                                                    <div id="ProgressWorkOrderNotPublished" runat="server" class="progress-bar progress-bar-striped bg-warning" role="progressbar" style="width: 81%" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>


                                </div>
                            </div>
                            <hr />
                            <div class="container-fluid">
                                <div class="row">
                                    <div class="col-md-3 col-sm-12 col-lg-3 col-xs-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="mb-2">
                                                    <asp:DropDownList ID="ddlPriceCurrency" runat="server" CssClass="form-control form-select" Font-Size="12px">
                                                        <asp:ListItem>INR</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="mb-2">
                                                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" Font-Size="12px">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3 col-sm-12 col-lg-3 col-xs-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <asp:Label ID="lbl_Outstanding_Invoice" CssClass="text-center" runat="server" Font-Size="12px" Text="0"></asp:Label>
                                                </div>
                                                <div class="mb-2">
                                                    <asp:Label ID="ct6YourControl1" runat="server" CssClass="text-center" Font-Size="12px" Font-Bold="true" Text="Outstanding Invoice" ForeColor="Orange"></asp:Label>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3 col-sm-12 col-lg-3 col-xs-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="mb-2">
                                                    <div class="row">
                                                        <asp:Label ID="lbl_Past_Due_Invoice" CssClass="text-center" Font-Size="12px" Font-Bold="true" runat="server" Text="0.00"></asp:Label>
                                                    </div>
                                                    <div class="mb-2">
                                                        <asp:Label ID="pastDueInvoice" runat="server" CssClass="text-center" Font-Size="12px" Font-Bold="true" Text="Past Due Invoice" ForeColor="Black"></asp:Label>

                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3 col-sm-12 col-lg-3 col-xs-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <asp:Label ID="lbl_Paid_Invoice" CssClass="text-center" runat="server" Font-Size="12px" Text="0.0"></asp:Label>
                                                </div>
                                                <div class="mb-2">
                                                    <asp:Label ID="paidInvoice" runat="server" CssClass="text-center" Font-Size="12px" Font-Bold="true" Text="Paid Invoice" ForeColor="Green"></asp:Label>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- ESTIMATES OVERVIEW -->
                <!-- TODO LIST -->
                <div class="col-md-4 col-sm-4 col-lg-4 col-xs-4">
                    <div id="DivToDoList" runat="server" visible="true">
                        <div class="card">
                            <div class="card-body">
                                <h6>To Do List</h6>
                                <hr />
                                <h8><a href="ViewToDo.aspx">&nbsp; View All | </a>&nbsp; <a href="NewToDo.aspx">New Todo</a></h8>
                                <br />
                                <br />
                                <div class="table-responsive" style="height: 150px">
                                    <asp:GridView ID="GridTododash" runat="server" ScrollBars="Both" CssClass="table border table-bordered display text-nowrap" AutoGenerateColumns="false" CellPadding="4"
                                        ClientIDMode="Static" EmptyDataText="No Records found" Style="width: 100%" ShowHeader="false" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="todo_items_id">
                                        <Columns>
                                            <asp:TemplateField HeaderText="todo_items_id" SortExpression="todo_items_id" Visible="false">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lbltodo_items_id2" runat="server" Text='<%# Bind("todo_items_id") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltodo_items_id1" runat="server" Text='<%# Bind("todo_items_id") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Unfinshed" SortExpression="Unfinshed" HeaderStyle-Width="290px">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChBoxfinished" runat="server" Checked="false" Font-Bold="true" Font-Size="12px" AutoPostBack="true" OnCheckedChanged="ChBoxfinished_CheckedChanged" />&nbsp;&nbsp;
                                                 <asp:Label ID="lbltasks" runat="server" Text='<%#Bind("description") %>' Font-Bold="true" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lbltimetodo" runat="server" Text='<%#Bind("date_added","{0:dd-MM-yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lblCreated_by1" runat="server" Text='<%#Bind("Created_by") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label1" runat="server" Text='<%#Bind("Diff") %>' Font-Bold="false" Font-Size="12px" ForeColor="Purple"></asp:Label>&nbsp;<asp:Label ID="Label2" runat="server" Text="Week" Font-Bold="false" Font-Size="12px" ForeColor="Purple"></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- Project Invoice --%>
                    <div id="hide" runat="server" visible="false">
                        <div class="card">
                            <div class="card-body">
                                <div class="table-responsive">
                                    <h6>Project Invoice</h6>
                                    <hr />
                                    <%-- <asp:Chart ID="ChartProjectInvoice" runat="server" Height="300px" Width="280px" Palette="Pastel" BorderlineWidth="9" IsSoftShadows="False" ImageLocation="~/charts_1/chart_6_0.png" ImageStorageMode="UseImageLocation">--%>
                                    <asp:Chart ID="ChartProjectInvoice" runat="server" Height="300px" Width="280px" Palette="Pastel" BorderlineWidth="9" IsSoftShadows="False">
                                        <Titles>
                                            <asp:Title ShadowOffset="10" Name="Items" />
                                        </Titles>
                                        <Legends>
                                            <asp:Legend Alignment="Center" IsTextAutoFit="False" IsDockedInsideChartArea="False" />
                                        </Legends>
                                        <Series>
                                            <asp:Series Name="Default" ChartType="Doughnut" IsVisibleInLegend="false" BackImageAlignment="Center" ToolTip="#LABEL" />
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1" BorderWidth="10" ShadowColor="Black">

                                                <Area3DStyle Enable3D="True" Inclination="0" Rotation="0" LightStyle="Simplistic" WallWidth="0" />
                                            </asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </div>

                            </div>
                        </div>
                    </div>
                    <%--Task Count Chart--%>
                    <div id="DivTaskStatistics" runat="server" visible="true">
                        <div class="card">
                            <div class="card-body">
                                <h6>Task Statistics</h6>
                                <hr />
                                <div class="table-responsive">
                                    <%-- <asp:Chart ID="ChartTask" runat="server" Height="280px" Width="280px" BorderlineWidth="9" IsSoftShadows="False" Palette="Pastel" ImageLocation="~/charts_1/chart_7_0.png" ImageStorageMode="UseImageLocation">  --%>
                                    <asp:Chart ID="ChartTask" runat="server" Height="280px" Width="280px" BorderlineWidth="9" IsSoftShadows="False" Palette="Pastel">
                                        <Titles>
                                            <asp:Title ShadowOffset="10" Name="Items" />
                                        </Titles>
                                        <Legends>
                                            <asp:Legend Alignment="Center" IsTextAutoFit="False" IsDockedInsideChartArea="False" />
                                        </Legends>
                                        <Series>
                                            <asp:Series Name="Default" ChartType="Doughnut" IsVisibleInLegend="false" BackImageAlignment="Center" ToolTip="#LABEL" />
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1" BorderWidth="10" ShadowColor="Black">
                                                <Area3DStyle Enable3D="True" Inclination="0" Rotation="0" LightStyle="Simplistic" WallWidth="0" />
                                            </asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- TODO LIST -->
            </div>

            <!-- ESTIMATES AND Calender BOX END -->


            <!-- TRACKING CHART -->
            <div class="row">

                <div class="col-md-8 col-sm-8 col-lg-8 col-xs-8">
                    <div id="DivProjectOverview" runat="server" visible="true">
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-md-8 col-sm-8 col-8 col-xs-8 col-lg-8">
                                                <h6>Project Overview</h6>
                                            </div>
                                            <div class="col-md-4 col-sm-4 col-4 col-xs-4 col-lg-4">
                                                <div class="form-group text-end">
                                                    <asp:Label ID="lblProjects" runat="server" Text="Project" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                    <asp:DropDownList ID="ddlProjects" runat="server" CssClass="form-control form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlProjects_SelectedIndexChanged" Font-Size="12px">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                        </div>
                                        <hr />
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                <div class="table-responsive">
                                                    <!-- Chart-1 -->
                                                    <%-- <asp:Chart ID="Chart2" runat="server" Width="680px" Height="400px" ImageLocation="~/charts_2/chart_1_0.png" ImageStorageMode="UseImageLocation"> --%>

                                                    <asp:Chart ID="Chart2" runat="server" Width="680px" Height="400px">
                                                    </asp:Chart>
                                                    <!-- End Chart-1 -->
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div id="Divtabslist" runat="server" visible="true">
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                <div class="card">
                                    <div class="card-body">
                                        <!-- Nav tabs -->
                                        <ul class="nav nav-tabs" role="tablist">
                                            <li class="nav-item">
                                                <a class="nav-link active" data-bs-toggle="tab" href="#home" role="tab"><span class="hidden-sm-up"></span>
                                                    <span class="hidden-xs-down">My Tasks</span></a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link" data-bs-toggle="tab" href="#profile" role="tab"><span class="hidden-sm-up"></span>
                                                    <span class="hidden-xs-down">My Projects</span></a>
                                            </li>

                                            <li class="nav-item">
                                                <a class="nav-link" data-bs-toggle="tab" href="#Workorder" role="tab"><span class="hidden-sm-up"></span>
                                                    <span class="hidden-xs-down">WorkOrder</span></a>
                                            </li>

                                            <li class="nav-item">
                                                <a class="nav-link" data-bs-toggle="tab" href="#Ticketts" role="tab"><span class="hidden-sm-up"></span>
                                                    <span class="hidden-xs-down">Tickets</span></a>
                                            </li>
                                        </ul>
                                        <!-- Tab panes -->
                                        <div class="tab-content tabcontent-border">
                                            <%--  <asp:ScriptManager runat="server" EnablePartialRendering="true" ID="ScriptManager2" />--%>
                                            <div class="tab-pane active" id="home" role="tabpanel">

                                                <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div class="container-fluid">
                                                            <div class="row">
                                                                <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                                    <br />
                                                                    <h5>View Task Details</h5>
                                                                    <hr />
                                                                    <div class="col-md-6 col-sm-6 col-lg-6">
                                                                        <div class="bd-example">
                                                                            <div class="btn-group">
                                                                                <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                                                                <asp:Button ID="Button2" runat="server" Style="display: none" />
                                                                                <div class="dropdown-menu">
                                                                                    <asp:LinkButton ID="linkbtnExcelTask" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="linkbtnExcelTask_Click"></asp:LinkButton>
                                                                                    <asp:LinkButton ID="linkbtnPDFTask" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnPDFTask_Click"></asp:LinkButton>

                                                                                </div>
                                                                            </div>
                                                                            <asp:Button ID="btnVisibilityTask" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="btnVisibilityTask_Click" />
                                                                            <asp:Button ID="btnReloadTask" runat="server" Text="Reload" CssClass="btn btn-sm btn-sm btn-outline-info" OnClick="btnReloadTask_Click1" />
                                                                        </div>
                                                                    </div>

                                                                    <br />
                                                                    <br />
                                                                    <div id="grd" style="width: 100%">
                                                                        <asp:GridView ID="GridTask" runat="server" ScrollBars="Both" CssClass="table table-bordered table-responsive table-hover" AutoGenerateColumns="false" CellPadding="4"
                                                                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" OnRowDataBound="GridTask_RowDataBound1">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Name" SortExpression="Subject" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:TextBox ID="txttaskName" runat="server" Text='<%# Bind("Subject") %>' Font-Size="12px"></asp:TextBox>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbltaskName1" runat="server" Text='<%# Bind("Subject") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="StartDate" SortExpression="Start_Date" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblStart_Date" runat="server" Text='<%#Bind("Start_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblStart_Date1" runat="server" Text='<%#Bind("Start_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="DueDate" SortExpression="Due_Date" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblDue_Date" runat="server" Text='<%#Bind("Due_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblDue_Date1" runat="server" Text='<%#Bind("Due_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="AssignedTo" SortExpression="AssignTo" HeaderStyle-Font-Size="12px" HeaderStyle-Width="150px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblReletd_To" runat="server" Text='<%# Bind("AssignTo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <div class="m-2">
                                                                                            <asp:BulletedList ID="bulletlist1" runat="server" BulletStyle="Circle" Font-Size="12px">
                                                                                            </asp:BulletedList>
                                                                                        </div>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Status" SortExpression="TaskStatus" HeaderStyle-Font-Size="12px" HeaderStyle-Width="180px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblTaskStatus" runat="server" Text='<%#Bind("TaskStatus") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlTaskStatus" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTaskStatus_SelectedIndexChanged" Font-Size="12px">
                                                                                            <asp:ListItem Text="In Progress" Value="In Progress"></asp:ListItem>
                                                                                            <asp:ListItem Text="Mark as Not Started" Value="Mark as Not Started"></asp:ListItem>
                                                                                            <asp:ListItem Text="Mark as Testing" Value="Mark as Testing"></asp:ListItem>
                                                                                            <asp:ListItem Text="Mark as Awaiting Feedback" Value="Mark as Awaiting Feedback"></asp:ListItem>
                                                                                            <asp:ListItem Text="Mark as Complete" Value="Mark as Complete"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                        <asp:Label ID="lblTaskStatus1" runat="server" Text='<%#Bind("TaskStatus") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Status" SortExpression="Status" Visible="false">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Button ID="btnStatus" runat="server" Text='<%# Bind("Status") %>' CssClass="btn btn-info pull-left display-block mright5" TabIndex="126" Font-Size="12px" />
                                                                                        <asp:Label ID="lblstatus1" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false" Visible="false"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Repeated" SortExpression="Reapet_Every" HeaderStyle-Font-Size="12px" Visible="false">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblReapet_Every" runat="server" Text='<%# Bind("Reapet_Every") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblReapet_Every1" runat="server" Text='<%# Bind("Reapet_Every") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Priority" SortExpression="Priority" HeaderStyle-Font-Size="12px" HeaderStyle-Width="100px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblPriority" runat="server" Text='<%# Bind("Priority") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form-control" Font-Size="12px" AutoPostBack="true" OnSelectedIndexChanged="ddlPriority_SelectedIndexChanged">
                                                                                            <asp:ListItem Text="Medium" Value="Medium"></asp:ListItem>
                                                                                            <asp:ListItem Text="High" Value="High"></asp:ListItem>
                                                                                            <asp:ListItem Text="Low" Value="Low"></asp:ListItem>
                                                                                            <asp:ListItem Text="Urgent" Value="Urgent"></asp:ListItem>
                                                                                        </asp:DropDownList>

                                                                                        <asp:Label ID="lblPriority1" runat="server" Text='<%# Bind("Priority") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Billable" SortExpression="Billable" Visible="false">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblBillable" runat="server" Text='<%# Bind("Billable") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Button ID="btnBillable" runat="server" Text='<%# Bind("Billable") %>' CssClass="btn btn-info pull-left display-block mright5" TabIndex="126" />
                                                                                        <asp:Label ID="lblBillable1" runat="server" Text='<%# Bind("Billable") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="btnEditTask" runat="server" CssClass="btn btn-sm btn-outline-info mb-3" OnClick="btnEditTask_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                    </EditItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="btnDeleteTask" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteTask_Click"><i class="ti ti-trash"></i></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                    </EditItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <EmptyDataTemplate>
                                                                                <div align="center" style="color: red">
                                                                                    <h6>No records found.</h6>
                                                                                </div>
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="tab-pane p-20" id="profile" role="tabpanel">

                                                <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div class="container-fluid">
                                                            <div class="row">
                                                                <div class="col-md-12 col-sm-12 col-lg-12">
                                                                    <br />
                                                                    <h8 class="card-title">View Project Details</h8>
                                                                    <hr />
                                                                    <div class="row">
                                                                        <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6">
                                                                            <div class="bd-example">
                                                                                <div class="btn-group">
                                                                                    <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                                                                    <asp:Button ID="Button3" runat="server" Style="display: none" />
                                                                                    <div class="dropdown-menu">
                                                                                        <asp:LinkButton ID="linkbtnProjectExcel" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="linkbtnProjectExcel_Click"></asp:LinkButton>
                                                                                        <asp:LinkButton ID="linkbtnProjectPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnProjectPDF_Click"></asp:LinkButton>

                                                                                    </div>
                                                                                </div>

                                                                                <asp:Button ID="btn_VisibilityProject" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="btn_VisibilityProject_Click" />
                                                                                <asp:Button ID="BtnReloadProject" runat="server" Text="Reload" CssClass="btn btn-sm btn-sm btn-outline-info" OnClick="BtnReloadProject_Click" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-4">
                                                                        </div>
                                                                    </div>

                                                                    <br />
                                                                    <br />
                                                                    <div class="row">
                                                                        <asp:GridView ID="GridProject" runat="server" ScrollBars="Both" CssClass="table border table-bordered text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridProject_RowDataBound">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="ProjectName" SortExpression="ProjectName" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblProjectName" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblProjectName1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                                        <asp:LinkButton ID="LinkbtnProjectName1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" CssClass="link-info" OnClick="LinkbtnProjectName1_Click"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Customer" SortExpression="Customer" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblClientName" runat="server" Text='<%# Bind("ClientName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblSClientName1" runat="server" Text='<%# Bind("ClientName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="StartDate" SortExpression="Start_Date" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblStart_Date" runat="server" Text='<%# Bind("Start_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblStart_Date1" runat="server" Text='<%# Bind("Start_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Deadline" SortExpression="Deadline" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblDeadline" runat="server" Text='<%# Bind("Deadline","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblDeadline1" runat="server" Text='<%# Bind("Deadline","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Status" SortExpression="StatusProject" Visible="false" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("StatusProject") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblstatus1" runat="server" Text='<%#Bind("StatusProject") %>' Font-Bold="false" Visible="false" Font-Size="12px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Members" SortExpression="Member" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblTagsName" runat="server" Text="" TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <div class="m-2">
                                                                                            <asp:BulletedList ID="bulletlistMember" runat="server" BulletStyle="Circle" Font-Size="12px">
                                                                                            </asp:BulletedList>
                                                                                        </div>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="btnEditProject" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditProject_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="btnDeleteProjetct" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteProjetct_Click"><i class="ti ti-trash"></i></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                    </EditItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <EmptyDataTemplate>
                                                                                <div align="center" style="color: red">
                                                                                    <h6>No records found.</h6>
                                                                                </div>
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="tab-pane p-20" id="Workorder" role="tabpanel">
                                                <asp:UpdatePanel runat="server" ID="UpdatePanel4" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div class="container-fluid">
                                                            <div class="row">
                                                                <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                                    <br />
                                                                    <h8 class="card-title">View Work Order Details</h8>
                                                                    <hr />
                                                                    <div class="row">
                                                                        <div class="col-md-8 col-lg-8 col-sm-8 col-xs-8">
                                                                            <div class="bd-example">
                                                                                <div class="btn-group">
                                                                                    <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                                                                    <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                                                                    <div class="dropdown-menu">
                                                                                        <asp:LinkButton ID="lnkbtnExcel" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="lnkbtnExcel_Click"></asp:LinkButton>
                                                                                        <asp:LinkButton ID="linkbtnPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnPDF_Click"></asp:LinkButton>

                                                                                    </div>
                                                                                </div>

                                                                                <asp:Button ID="BTN_Visibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="BTN_Visibility_Click" />
                                                                                <asp:Button ID="Btn_Reload" runat="server" Text="Reload" CssClass="btn btn-outline-info btn-sm" OnClick="Btn_Reload_Click" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-4">
                                                                            <!------PDF code--------->

                                                                            <asp:Image ID="Image1" runat="server" Style="display: none; border: 1px solid #ccc" />

                                                                            <asp:Label ID="lbladdCompany11" runat="server" Text="" CssClass="font-bold text-dark " Visible="false"></asp:Label>
                                                                            <asp:Label ID="lbladdress11" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblcompanyaddCity1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblcompanyaddState1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblcompanyaddCountry1" runat="server" Text="," Font-Size="12px" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblpincode" runat="server" Text="PIN:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblphone" runat="server" Text="Phone:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblphoneNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblvat" runat="server" Text="VAT NO:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblVatNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblGSTNo1A" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                                                            <!------PDF code--------->

                                                                        </div>
                                                                    </div>
                                                                    <br />
                                                                    <br />
                                                                    <div class="row">
                                                                        <asp:GridView ID="GridWorkorderlist" runat="server" ScrollBars="Both" CssClass="table border table-responsive table-hover table-bordered text-nowrap" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%" HeaderStyle-Font-Size="12px"
                                                                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridWorkorderlist_RowDataBound">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="WorkOrderNumber" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblWorkOrderno" runat="server" Text='<%# Bind("WorkOrderNumber") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblWorkOrderno1" runat="server" Text='<%# Bind("WorkOrderNumber") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                                        <asp:LinkButton ID="LinkWorkOrderno" runat="server" Text='<%# Bind("WorkOrderNumber") %>' Font-Size="12px" OnClick="LinkWorkOrderno_Click"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="TenderNumber" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblTenderno" runat="server" Text='<%# Bind("TenderNumber") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblTenderno1" runat="server" Text='<%# Bind("TenderNumber") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="VendorName" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblVender" runat="server" Text='<%# Bind("Vend_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblVender1" runat="server" Text='<%# Bind("Vend_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="ContactPerson" SortExpression="ContactVender" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblContactPerson" runat="server" Text='<%# Bind("ContactVender") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblContactPerson1" runat="server" Text='<%# Bind("ContactVender") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="ProjectName" SortExpression="BiddingDate" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblProjectName" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblProjectName1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Status" SortExpression="BiddingDate" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblStatusName" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblStatusbit" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                                                                        <asp:Label ID="lblStatusName1" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Total" SortExpression="TotalAmountTender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblTotalAmountTender" runat="server" Text='<%# Bind("TotalAmountTender") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblTotalAmountTender1" runat="server" Text='<%# Bind("TotalAmountTender") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Publish" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                                    <ItemTemplate>

                                                                                        <asp:CheckBox ID="Chk_Pulish" runat="server" Font-Bold="true" Checked='<%# Bind("OrderPublish") %>' OnCheckedChanged="Chk_Pulish_CheckedChanged" AutoPostBack="true" />

                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="btnEditWorkOrder" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditWorkOrder_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="btnDeleteWorkOrder" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteWorkOrder_Click"><i class="ti ti-trash"></i></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                    </EditItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                </asp:TemplateField>

                                                                            </Columns>
                                                                            <EmptyDataTemplate>
                                                                                <div align="center" style="color: red">
                                                                                    <h6>No records found.</h6>
                                                                                </div>
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="tab-pane p-20" id="Ticketts" role="tabpanel">
                                                <asp:UpdatePanel runat="server" ID="UpdatePanel5" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div class="container-fluid">
                                                            <div class="row">
                                                                <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                                    <br />
                                                                    <h8 class="card-title">View Ticket Details</h8>
                                                                    <hr />
                                                                    <div class="row">
                                                                        <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                                                            <div class="bd-example">
                                                                                <div class="btn-group">
                                                                                    <button class="btn btn-sm btn-outline-success dropdown-toggle" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                                                                    <asp:Button ID="Button1" runat="server" Style="display: none" />
                                                                                    <div class="dropdown-menu">
                                                                                        <asp:Button ID="btn_ExportTicket" runat="server" Text="Excel" OnClick="btn_ExportTicket_Click" CssClass=" dropdown-item" />
                                                                                        <asp:LinkButton ID="linkPTicket" runat="server" Text="PDF" OnClick="linkPTicket_Click" CssClass="dropdown-item"></asp:LinkButton>
                                                                                    </div>
                                                                                </div>

                                                                                <asp:Button ID="btnTicketVisibility" runat="server" Text="Visibility" OnClick="btnTicketVisibility_Click" CssClass="btn btn-sm  btn btn-sm btn-outline-info" />
                                                                                <asp:Button ID="btnTicketReload" runat="server" Text="Reload" CssClass="btn btn-sm btn-sm btn btn-sm btn-outline-info" OnClick="btnTicketReload_Click" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <br />
                                                                    <div class="row">
                                                                        <asp:GridView ID="Gridticket" runat="server" ScrollBars="Both" CssClass="table border table-responsive table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Width="100%" OnRowDataBound="Gridticket_RowDataBound"
                                                                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnSelectedIndexChanged="Gridticket_SelectedIndexChanged">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="ID">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Subject" SortExpression="Subject" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblSubject" runat="server" Text='<%# Bind("Subject") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblSubject1" runat="server" Text='<%# Bind("Subject") %>' Visible="false" TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                        <asp:LinkButton ID="btnSubject1" runat="server" Text='<%# Bind("Subject") %>' CssClass="btn btn-sm text-info" OnClick="btnSubject1_Click"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Department" SortExpression="Department" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblDepartment" runat="server" Text='<%# Bind("Department") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblDepartment1" runat="server" Text='<%# Bind("Department") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Services" SortExpression="Services" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblServices" runat="server" Text='<%# Bind("Services") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblServices1" runat="server" Text='<%# Bind("Services") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Priority" SortExpression="Priority" Visible="false" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblPriority" runat="server" Text='<%# Bind("Priority") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblPriority1" runat="server" Text='<%# Bind("Priority") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="AssignTo" SortExpression="AssignTo" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lbAssignTo" runat="server" Text='<%# Bind("AssignTo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblAssignTo1" runat="server" Text='<%# Bind("AssignTo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="RaiseBy" SortExpression="RaiseBy" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblRaiseBy" runat="server" Text='<%# Bind("Raise_By") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRaiseBy1" runat="server" Text='<%# Bind("Raise_By") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Status" SortExpression="StatusName" HeaderStyle-Font-Size="12px">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblStatusNamee" runat="server" Text='<%# Bind("StatusName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblStatusNamee1" runat="server" Text='<%# Bind("StatusName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Status1" SortExpression="StatusName" HeaderStyle-Font-Size="12px" Visible="false">
                                                                                    <EditItemTemplate>
                                                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblStatus1" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="btnEditticket" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditticket_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="btnDeleteticket" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteticket_Click"><i class="ti ti-trash"></i></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                    </EditItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <EmptyDataTemplate>
                                                                                <div align="center" style="color: red">
                                                                                    <h6>No records found.</h6>
                                                                                </div>
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>

                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Announcement LIST -->
                <div class="col-md-4 col-sm-4 col-lg-4 col-xs-4">
                    <div id="DivAnnouncement" runat="server" visible="true">
                        <div class="card">
                            <div class="card-body">
                                <h6>Announcement </h6>
                                <hr />
                                <h8>
                                    <asp:LinkButton ID="lnkviewAll" Text="View All " runat="server" OnClick="lnkviewAll_Click"></asp:LinkButton>
                                    &nbsp; |  &nbsp;
                            <asp:LinkButton ID="lnkNewAnnoucement" Text="New Announcement" runat="server" OnClick="lnkNewAnnoucement_Click"></asp:LinkButton></h8>
                                <br />
                                <br />
                                <div class="table-responsive" style="height: 200px">
                                    <asp:GridView ID="GridAnnouncement" runat="server" CssClass="table border table-bordered display text-nowrap" AutoGenerateColumns="false" CellPadding="4"
                                        ClientIDMode="Static" ShowHeader="false" Style="width: 100%" EmptyDataText="No Records found" ShowHeaderWhenEmpty="False" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="announcement_id">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false">
                                                <EditItemTemplate>
                                                    <asp:Label ID="txtAnnouncementID" runat="server" Text='<%# Bind("announcement_id") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAnnouncementID" runat="server" Text='<%# Bind("announcement_id") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name" HeaderStyle-Width="250px" SortExpression="ID">
                                                <EditItemTemplate>
                                                    <asp:Label ID="txtname" runat="server" Text='<%# Bind("name") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <icon class="fab fa-pagelines" style="width: 15px"></icon>
                                                    &nbsp;  &nbsp;
                                            <asp:Label ID="lblname1" runat="server" Text='<%# Bind("name") %>' Font-Bold="false" Visible="false" Font-Size="12px"></asp:Label>
                                                    <asp:LinkButton ID="lnkbtnname" runat="server" Text='<%# Bind("name") %>' TabIndex="6" OnClick="lnkbtnname_Click" Font-Size="12px"></asp:LinkButton>
                                                    &nbsp;  &nbsp;  &nbsp;&nbsp;
                                            <br />
                                                    <asp:Label ID="lblname" runat="server" Text='<%# Bind("date_added","{0:dd-MMM-yyyy}") %>' Font-Bold="false" Font-Size="12px" ForeColor="Black"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label1diff" runat="server" Text='<%#Bind("Diff") %>' Font-Bold="false" Font-Size="12px" ForeColor="Purple"></asp:Label>&nbsp;<asp:Label ID="Label2diff" runat="server" Text="Week" Font-Bold="false" Font-Size="12px" ForeColor="Purple"></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date" HeaderStyle-Width="250px" SortExpression="ID" Visible="false">
                                                <EditItemTemplate>
                                                    <asp:Label ID="txtname" runat="server" Text='<%# Bind("date_added") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldatename1" runat="server" Text='<%# Bind("date_added","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>

                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--Payment Chart--%>
                    <div id="DivPaymentChart" runat="server" visible="true">
                        <div class="card">
                            <div class="card-body">
                                <div class="table-responsive">
                                    <h6>Payment Analysis</h6>
                                    <hr />
                                    <%-- <asp:Chart ID="ChartPayment" runat="server"  Height="340px" Width="300px" BorderlineWidth="9" IsSoftShadows="False" Palette="SemiTransparent" BackImageWrapMode="TileFlipXY" BorderlineColor="Transparent" CssClass="align-content-xxl-end" ImageLocation="~/charts_1/chart_9_0.png" ImageStorageMode="UseImageLocation"> --%>
                                    <asp:Chart ID="ChartPayment" runat="server" Height="340px" Width="300px" BorderlineWidth="9" IsSoftShadows="False" Palette="SemiTransparent" BackImageWrapMode="TileFlipXY" BorderlineColor="Transparent" CssClass="align-content-xxl-end">
                                        <Series>
                                            <asp:Series BackImageAlignment="Center" ChartArea="ChartArea1" ChartType="Pyramid" IsVisibleInLegend="False" Legend="Legend1" Name="Default" ToolTip="#LABEL">
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea BorderWidth="10" Name="ChartArea1" ShadowColor="Black">
                                                <Area3DStyle Enable3D="True" Inclination="0" Rotation="0" WallWidth="0" />
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <asp:Legend Alignment="Center" IsDockedInsideChartArea="False" IsTextAutoFit="False" Name="Legend1">
                                            </asp:Legend>
                                        </Legends>

                                        <Titles>
                                            <asp:Title ShadowOffset="10" Name="Items" />
                                        </Titles>
                                    </asp:Chart>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- Work ORder Chart--%>
                    <div id="DivWorkOrderChart" runat="server" visible="true">
                        <div class="card">
                            <div class="card-body">
                                <div class="table-responsive">
                                    <h6>Work Order Inferential </h6>
                                    <hr />
                                    <%--   <asp:Chart ID="ChartWorkOrder" runat="server" Height="340px" Width="300px" BorderlineWidth="9" IsSoftShadows="False" ImageLocation="~/charts_1/chart_11_0.png" ImageStorageMode="UseImageLocation">  --%>

                                    <asp:Chart ID="ChartWorkOrder" runat="server" Height="340px" Width="300px" BorderlineWidth="9" IsSoftShadows="False">

                                        <Titles>
                                            <asp:Title ShadowOffset="10" Name="Items" />
                                        </Titles>
                                        <Legends>
                                            <asp:Legend Alignment="Center" IsTextAutoFit="False" IsDockedInsideChartArea="False" />

                                        </Legends>
                                        <Series>
                                            <asp:Series Name="Default" ChartType="Doughnut" IsVisibleInLegend="false" BackImageAlignment="Center" ToolTip="#LABEL" />
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1" BorderWidth="10" ShadowColor="Black">

                                                <Area3DStyle Enable3D="True" Inclination="0" Rotation="0" LightStyle="Simplistic" WallWidth="0" />
                                            </asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </div>
                            </div>
                        </div>
                        </
                    </div>
                    <!-- Announcement LIST -->
                </div>
                <!-- TRACKING CHART END -->
                  </div>
                <!-- PROJECT ACTIVITY TRACKING -->
                <div class="row">
                    <!-- Project Activity Tracking -->
                    <div class="col-md-8 col-sm-8 col-lg-8 col-xs-8">
                        <div id="DivProjectStatuschart" runat="server" visible="true">
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                    <div class="card">
                                        <div class="card-body">
                                            <h6>Statistics by Project Status</h6>
                                            <hr />
                                            <div class="row">
                                                <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                    <div class="table-responsive">
                                                        <!-- Chart-2 -->
                                                        <%--   <asp:Chart ID="Chart1" runat="server" Width="500px" Height="550px" ImageLocation="~/charts_1/chart_1_0.png" ImageStorageMode="UseImageLocation"> --%>

                                                        <asp:Chart ID="Chart1" runat="server" Width="500px" Height="550px" CssClass="chart-bar-basic">
                                                            <Series>
                                                                <asp:Series Name="Series1" XValueMember="ProjectName" YValueMembers="TotalProjectCost">
                                                                </asp:Series>
                                                            </Series>
                                                            <Legends>
                                                                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                                                                    LegendStyle="Row" />
                                                            </Legends>
                                                            <ChartAreas>
                                                                <asp:ChartArea Name="ChartArea1" BorderWidth="0">
                                                                </asp:ChartArea>
                                                            </ChartAreas>
                                                        </asp:Chart>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <!-- End Chart-2 -->
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Project Activity Tracking -->
                    <!-- Project Activity Track -->
                    <div class="col-md-4 col-sm-4 col-lg-4 col-xs-4">
                        <div id="DivActivityLog" runat="server" visible="true">
                            <div class="card">
                                <div class="card-body">
                                    <h6>Activity Log</h6>
                                    <hr />
                                    <br />
                                    <div class="table-responsive" style="height: 510px">
                                        <asp:GridView ID="GridViewAct" runat="server" ScrollBars="Both" CssClass="table border table-bordered display text-nowrap" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%" ShowHeader="false"
                                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID">
                                            <Columns>
                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Project Activity" SortExpression="Activity">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblUserID11" runat="server" Text='<%# Bind("UserID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <i class="mdi mdi-leaf fs-4 w-30px mt-1"></i>
                                                        <asp:Label ID="lblActivityType" runat="server" Text='<%# Bind("ActivityType") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label>&nbsp;&nbsp;
                                          <br />


                                                        <asp:Label ID="lblDifd" runat="server" Text='<%# Bind("Diff") %>' TabIndex="6" Font-Size="12px" ForeColor="Purple"></asp:Label>
                                                        &nbsp;
                                                                 <asp:Label ID="lblAgo" runat="server" Text="MONTH  AGO" TabIndex="6" Font-Size="12px" ForeColor="Purple"></asp:Label>&nbsp;
                                            <br />
                                                        <asp:Label ID="lblDate" runat="server" Text='<%# Bind("ActivityDate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Black"></asp:Label>&nbsp;
                                                                 <br />
                                                        <asp:Label ID="Label1" runat="server" Text="----------------------------------------" TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="LightGray"></asp:Label>
                                                        <br />
                                                        <asp:Label ID="lblUserID1" runat="server" Text='<%# Bind("UserID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>&nbsp;&nbsp;
                                            <asp:Label ID="Designation1" runat="server" Text='<%# Bind("Designation") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>&nbsp;&nbsp;
                                                             
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <!-- Project Activity Track End-->
                </div>
                <!-- PROJECT ACTIVITY TRACKING END -->


          
        </div>



        <div id="NotSHowPages" runat="server" visible="false">

            <div class="container-fluid">
                <div class="row">
                    <div class="card">
                        <div class="card-body" style="height: 500px">
                            <!-- Top Cards  -->
                            <div class="row">
                                <!-- Column -->
                                <div class="col-xs-12 col-md-12 col-sm-12 col-lg-12">
                                    <div class="card">
                                        <div class="card-body">
                                            <h4 class="card-title" style="color: red">You do not have permission to access!</h4>
                                            <hr />
                                            <h6 class="text-purple">please check your web pages permission !</h6>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Container fluid  -->
    </div>
</asp:Content>
