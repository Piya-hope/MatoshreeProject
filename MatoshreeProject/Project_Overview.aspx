<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Project_Overview.aspx.cs" Inherits="MatoshreeProject.WebForm1" EnableEventValidation="false" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridStaffMembers = $("#GridStaffMembers").prepend($("<thead></thead>").append($("#GridStaffMembers").find("tr:first"))).DataTable(
                {
                    columnDefs: [{
                        "defaultContent": "-",
                        "targets":"_all"
                    }],
                    bLengthChange: true,
                    bFilter: true,
                    bSort: true,
                    bPaginate: true,
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridTask1 = $("#GridTask1").prepend($("<thead></thead>").append($("#GridTask1").find("tr:first"))).DataTable(
                {
                    columnDefs: [{
                            "targets": 0,
                            "searchable": false
                        }],
                    bLengthChange: true,
                    bFilter: true,
                    bSort: true,
                    bPaginate: true,
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "180%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridFile1 = $("#GridFile1").prepend($("<thead></thead>").append($("#GridFile1").find("tr:first"))).DataTable(
                {
                    columnDefs: [{
                        "defaultContent": "-",
                        "targets": "_all"
                    }],
                    bLengthChange: true,
                    bFilter: true,
                    bSort: true,
                    bPaginate: true,
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "160%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridProjectPurchase = $("#GridProjectPurchase").prepend($("<thead></thead>").append($("#GridProjectPurchase").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridEstimate = $("#GridEstimate").prepend($("<thead></thead>").append($("#GridEstimate").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridInvoice = $("#GridInvoice").prepend($("<thead></thead>").append($("#GridInvoice").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridTender = $("#GridTender").prepend($("<thead></thead>").append($("#GridTender").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                }); 

            var GridViewAct = $("#GridViewAct").prepend($("<thead></thead>").append($("#GridViewAct").find("tr:first"))).DataTable(
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


    <script> 
        tinymce.init({
            // selector: 'textarea',
            //selector : "textarea.Editor"
            selector: ".EditorNote",
            //theme: "modern",
            //plugins: ["lists link image charmap print preview hr anchor pagebreak"],

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <%-- BreadCrumbs --%>
                <h5 class="font-weight-medium mb-0">Project</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item"><a class="text-muted text-decoration-none" href="Projects.aspx">Project</a></li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="#">Project Overview</li>
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
        <br />
        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                <div class="row">
                    <div class="col-md-8 col-sm-8 col-lg-8 col-xs-8">
                        <h3>
                              <asp:Label ID="lblStaffEmail" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lblStaffDesignation" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lblEmpName11" runat="server" Text="" Visible="false"></asp:Label>

                            <asp:Label ID="lblProjectID" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="lblTenderCost1" runat="server" Text="" Visible="false"></asp:Label>

                            <asp:Label ID="lbltotalprocurment" runat="server" Text="" Visible="false"></asp:Label>

                            <asp:Label ID="lbltotalservices" runat="server" Text="" Visible="false"></asp:Label>

                            <asp:Label ID="lblProjectCost1" runat="server" Text="" Visible="false"></asp:Label>

                            <asp:Label ID="lblExpensesCost1" runat="server" Text="" Visible="false"></asp:Label>


                            <asp:Label ID="lblEstimateCost1" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="lblInvoicCost1" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="lblProject_Overview" runat="server" Text="" Font-Bold="true" Font-Size="18px" ForeColor="Blue"></asp:Label>
                            &nbsp;
                             <asp:Label ID="lblProjectStatusoverview" runat="server" Text="" Font-Bold="false" Font-Size="12px" ForeColor="#0066ff" CssClass="btn btn-light Prounded-6" Style="border: 1px solid; background: local; padding: 4px;"></asp:Label>
                        </h3>
                    </div>
                    <div class="col-md-1 col-lg-1 col-sm-1 col-xs-1"></div>
                    <div class="col-md-3 col-lg-3 col-sm-3 col-xs-3">
                        <div class="d-sm-flex d-none gap-3 no-block justify-content-end align-items-center">
                            <asp:Button ID="btnInvoice_Project" runat="server" Text="Invoice Project" CssClass="btn btn-sm btn-primary Prounded-6" />
                            &nbsp;
                             <div class="btn-group">
                                 <button class="btn btn-sm btn-light dropdown-toggle" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">More</button>
                                 <div class="dropdown-menu">
                                     <asp:LinkButton ID="lnkbtnpinproject" Text="Pin Project" runat="server" CssClass="dropdown-item"></asp:LinkButton>
                                     <asp:LinkButton ID="lnkbtneditproject" Text="Edit Project" runat="server" CssClass="dropdown-item" OnClick="lnkbtneditproject_Click"></asp:LinkButton>
                                     <asp:LinkButton ID="LinkCopy" Text="Copy Project" runat="server" CssClass="dropdown-item" OnClick="LinkCopy_Click"></asp:LinkButton>
                                     <hr />
                                     <asp:LinkButton ID="LinkButtonInProgress" Text="Mark as In Progress" runat="server" CssClass="dropdown-item" OnClick="LinkButtonInProgress_Click"></asp:LinkButton>
                                     <asp:LinkButton ID="LinkButtonOnHold" Text="Mark as On Hold" runat="server" CssClass="dropdown-item" OnClick="LinkButtonOnHold_Click"></asp:LinkButton>
                                     <asp:LinkButton ID="LinkButtonCancelled" Text="Mark as Cancelled" runat="server" CssClass="dropdown-item" OnClick="LinkButtonCancelled_Click"></asp:LinkButton>
                                     <asp:LinkButton ID="LinkButtonFinished" Text="Mark as Finished" runat="server" CssClass="dropdown-item" OnClick="LinkButtonFinished_Click"></asp:LinkButton>
                                     <hr />
                                     <asp:LinkButton ID="LinkButtonExportproject" Text="Export project data" runat="server" CssClass="dropdown-item"></asp:LinkButton>
                                     <asp:LinkButton ID="LinkButtonViewprojectascustomer" Text="View project as customer" runat="server" CssClass="dropdown-item"></asp:LinkButton>
                                     <asp:LinkButton ID="LinkButtonDeleteProject" Text="Delete Project" runat="server" CssClass="dropdown-item" ForeColor="Red" OnClick="LinkButtonDeleteProject_Click"></asp:LinkButton>

                                 </div>
                             </div>
                        </div>

                    </div>

                </div>
                <br />
                <hr />
                <div class="card">
                    <div class="border-top">
                        <div class="card-body">
                            <ul class="nav nav-tabs">
                                <li class="nav-item">
                                    <asp:LinkButton ID="linkbtnProjectOverView" runat="server" CausesValidation="false" class="nav-link active " OnClick="linkbtnProjectOverView_Click">
                                       <span><i class="ti ti-briefcase fs-4"></i></span>Project Overview</asp:LinkButton>
                                </li>
                                <li class="nav-item">
                                    <asp:LinkButton ID="linkbtnDetaling" runat="server" CausesValidation="false" class="nav-link" OnClick="linkbtnDetaling_Click">
                                        <span><iconify-icon icon="icon-park-outline:box" class="aside-icon"></iconify-icon></span>Detailing</asp:LinkButton>

                                </li>
                                <li class="nav-item">
                                    <asp:LinkButton ID="linkbtnTasks" runat="server" CausesValidation="false" class="nav-link" OnClick="linkbtnTasks_Click">
                                         <span> <iconify-icon icon="solar:archive-minimalistic-linear" class="aside-icon"></iconify-icon></span>Tasks</asp:LinkButton>


                                </li>
                                <li class="nav-item">
                                    <asp:LinkButton ID="linkbtnFiles" runat="server" CausesValidation="false" class="nav-link" OnClick="linkbtnFiles_Click">
                                       <span><i class="ti ti-file fs-4"></i></span>Files</asp:LinkButton>

                                </li>
                                <li class="nav-item">
                                    <asp:LinkButton ID="linkbtnEstimate" runat="server" CausesValidation="false" class="nav-link" OnClick="linkbtnEstimate_Click">
                                       <span><iconify-icon icon="solar:file-smile-linear" class="aside-icon"></iconify-icon></span> Estimate</asp:LinkButton>

                                </li>
                                <li class="nav-item">
                                    <asp:LinkButton ID="linkbtnInvoice" runat="server" CausesValidation="false" class="nav-link" OnClick="linkbtnInvoice_Click">
                                        <span><iconify-icon icon="akar-icons:reciept" class="aside-icon"></iconify-icon></span>Invoices</asp:LinkButton>

                                </li>
                                <li class="nav-item">
                                    <asp:LinkButton ID="linkbtnExpenses" runat="server" CausesValidation="false" class="nav-link" OnClick="linkbtnExpenses_Click">
                                        <span><iconify-icon icon="bi:file-earmark-bar-graph" class="aside-icon"></iconify-icon></span>Expenses</asp:LinkButton>

                                </li>
                                <li class="nav-item">
                                    <asp:LinkButton ID="linkbtnNotes" runat="server" CausesValidation="false" class="nav-link" OnClick="linkbtnNotes_Click">
                                       <span><iconify-icon icon="iconoir:notes" class="aside-icon"></iconify-icon></span> Notes</asp:LinkButton>

                                </li>
                                <li class="nav-item">
                                    <asp:LinkButton ID="linkbtnActivity" runat="server" CausesValidation="false" class="nav-link" OnClick="linkbtnActivity_Click">
                                       <span><iconify-icon icon="mynaui:activity-square" class="nav-small-cap-icon fs-4"></iconify-icon></span> Activity</asp:LinkButton>
                                </li>
                                <li class="nav-item">
                                    <asp:LinkButton ID="linkbtnTender" runat="server" CausesValidation="false" class="nav-link" OnClick="linkbtnTender_Click">
                                        <span><iconify-icon icon="solar:layers-minimalistic-line-duotone" class="aside-icon"></iconify-icon></span> Tender</asp:LinkButton>

                                </li>
                            </ul>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                        <div class="alert alert-warning Prounded-6" role="alert" id="msgdiv" runat="server" visible="false">
                            <asp:Label ID="lblMsg1" runat="server" Text="test" Visible="false" Font-Bold="false" Font-Size="12px" ForeColor="Red" ValidateRequestMode="Disabled"></asp:Label>
                        </div>
                        <div class="alert alert-info Prounded-6" role="alert" id="SuccessDiv1" runat="server" visible="false">
                            <asp:Label ID="lblMsg" runat="server" Text="" Visible="false" Font-Bold="false" Font-Size="12px" ForeColor="Blue" ValidateRequestMode="Disabled"></asp:Label>
                        </div>
                        <div class="alert alert-success Prounded-6" role="alert" id="GreenDiv3" runat="server" visible="false">
                            <asp:Label ID="lblSmsg" runat="server" Text="" Visible="false" Font-Bold="false" Font-Size="12px" ForeColor="Blue" ValidateRequestMode="Disabled"></asp:Label>
                        </div>
                        <div class="alert alert-danger Prounded-6" role="alert" id="DangerDiv1" runat="server" visible="false">
                            <asp:Label ID="lblDanger" runat="server" Text="" Visible="false" Font-Bold="false" Font-Size="12px" ForeColor="Blue" ValidateRequestMode="Disabled"></asp:Label>
                        </div>
                    </div>
                </div>

                <%-- Tabs Designs--%>
                <div class="card">
                    <div class="card-body">
                        <div class="container">

                            <div id="projectoverview" runat="server">
                                <div class="p-20">
                                    <div class="row">
                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 mt-4">
                                          
                                                    <h6>Project Overview</h6>
                                                    <hr />
                                            <div class="table-responsive">
                                                <%--  <asp:Chart ID="Chart2" runat="server" Width="950px" Height="500px" ImageLocation="~/charts_2/chart_2_0.png" ImageStorageMode="UseImageLocation"> --%>
                                                    <!-- Chart-1 -->
                                                    <asp:Chart ID="Chart2" runat="server" Width="950px" Height="500px">
                                                    </asp:Chart>
                                                    <!-- End Chart-1 -->
                                                </div>
                                           </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6">
                                            <div class="card" style="border: solid">
                                                <div class="card-body">
                                                    <h5>Project Description</h5>
                                                    <hr />
                                                    <%-- Project Decsription --%>
                                                    <div class="row">
                                                        <div class="col-md-6 col-sm-6 col-xs-6 col-lg-6">

                                                            <div class="mb-2">
                                                                <asp:Label ID="lblProjectName" runat="server" Text="Project :" CssClass="form-label"></asp:Label>
                                                                &nbsp;
                                                                    <asp:Label ID="lblProjectName1" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </div>

                                                            <div class="mb-2">
                                                                <asp:Label ID="lblBillingType" runat="server" Text="BillingType :" CssClass="form-label"></asp:Label>
                                                                &nbsp;
                                                                   <asp:Label ID="lblBillingType1" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </div>

                                                            <div class="mb-2">
                                                                <asp:Label ID="lblProjectStatus" runat="server" Text="Status :" CssClass="form-label"></asp:Label>
                                                                &nbsp;
                                                                    <asp:Label ID="lblProjectStatus1" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </div>

                                                            <div class="mb-2">
                                                                <asp:Label ID="lblStartDate" runat="server" Text="Start Date :" CssClass="form-label"></asp:Label>
                                                                &nbsp;
                                                                    <asp:Label ID="lblStartDate1" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </div>

                                                            <div class="mb-2">
                                                                <asp:Label ID="lblTotalLoggedHr" runat="server" Text="Total Logged Hours :" CssClass="form-label"></asp:Label>
                                                                &nbsp;
                                                                    <asp:Label ID="lblTotalLoggedHr1" runat="server" Text="00:00" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </div>

                                                            <div class="mb-2">
                                                                <asp:Label ID="lblDescription" runat="server" Text="Description :" CssClass="form-label"></asp:Label>
                                                                &nbsp;
                                                                    <asp:Label ID="lblDescription1" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-6 col-sm-6 col-xs-6 col-lg-6">
                                                            <div class="mb-2">
                                                                <asp:Label ID="lblClient" runat="server" Text="Customer :" CssClass="form-label"></asp:Label>
                                                                &nbsp;
                                                                    <asp:Label ID="lblClient1" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </div>

                                                            <div class="mb-2">
                                                                <asp:Label ID="lblTotalRate" runat="server" Text="Total Rate :" CssClass="form-label"></asp:Label>
                                                                &nbsp;
                                                                    <asp:Label ID="lblTotalRate1" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </div>

                                                            <div class="mb-2">
                                                                <asp:Label ID="lblDateCreated" runat="server" Text="Date Created :" CssClass="form-label"></asp:Label>
                                                                &nbsp;
                                                                     <asp:Label ID="lblDateCreated1" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </div>

                                                            <div class="mb-2">
                                                                <asp:Label ID="lblDueDate" runat="server" Text="Deadline :" CssClass="form-label"></asp:Label>
                                                                &nbsp;
                                                                    <asp:Label ID="lblDueDate1" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </div>

                                                        </div>

                                                    </div>
                                                    <%-- Project Decsription --%>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                            <div class="card" style="border: solid">
                                                <div class="card-body">
                                                    <h5>Project Members</h5>
                                                    <hr />
                                                    <asp:Label ID="lblGridDisply" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false" ForeColor="Blue"></asp:Label>

                                                    <asp:GridView ID="GridStaffMembers" runat="server" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Visible="false" Style="width: 100%"
                                                        ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="Staff_ID" OnRowDataBound="GridStaffMembers_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="ID">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ID" SortExpression="Staff_ID" Visible="false">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("Staff_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblID1" runat="server" Text='<%# Bind("Staff_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Full_Name" SortExpression="FullName" HeaderStyle-Width="80px">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblFirst_Name" runat="server" Text='<%# Bind("First_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblFirst_Name1" runat="server" Text='<%# Bind("First_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Designation" SortExpression="Role">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblRole" runat="server" Text='<%# Bind("Role") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRole1" runat="server" Text='<%# Bind("Role") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Email" SortExpression="Email" HeaderStyle-Width="180px">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEmail1" runat="server" Text='<%# Bind("Email") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Last LogIn" SortExpression="Last_login" HeaderStyle-Width="80px">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblLast_login" runat="server" Text='<%# Bind("Last_login") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLast_login1" runat="server" Text='<%# Bind("Last_login") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Active" SortExpression="Statusactive" Visible="false">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblStatusShow" runat="server" Text='<%# Bind("Statusactive") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatusShow1" runat="server" Text='<%# Bind("Statusactive") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkEditStaff" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="LinkEditStaff_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Remove" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnRemoveStaff" runat="server" CommandName="Remove" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to Remove Member?')" OnClick="btnRemoveStaff_Click"><i class="ti ti-cut"></i></asp:LinkButton>
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
                                </div>
                            </div>
                            <%-- Project Detailing --%>
                            <div id="Detailing" runat="server" visible="false">
                                <div class="p-20">
                                    <div class="container-fluid">
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 col-lg-12">

                                                <h5>Project Procurement</h5>
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
                                                </div>
                                                <div class="row">
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="GridProcurement" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                            ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="true" OnRowDataBound="GridProcurement_RowDataBound" DataKeyNames="ID"
                                                            OnRowEditing="GridProcurement_RowEditing" OnRowUpdating="GridProcurement_RowUpdating" OnRowCancelingEdit="GridProcurement_RowCancelingEdit" OnRowDeleting="GridProcurement_RowDeleting" OnPageIndexChanging="GridProcurement_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField Visible="false">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblPID1" runat="server" Text="ID" CssClass="form-label"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblFID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
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
                                                                        <asp:RequiredFieldValidator ID="rfv_InvoiceItem" ControlToValidate="txtProduct" Display="Dynamic" runat="server" ErrorMessage="Enter Product" Font-Size="12px" ForeColor="Red" ValidationGroup="ProductItem"></asp:RequiredFieldValidator>
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
                                                                        <asp:TextBox ID="txtQty1" runat="server" Text='<%# Bind("Quantity") %>' CssClass="form-control" Placeholder="Quantity" TextMode="Number" Style="width: 60px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblQuantity1" runat="server" Text='<%# Bind("Quantity") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtQty" runat="server" Text="1" CssClass="form-control" Placeholder="Product Quantity" TextMode="Number" Style="width: 60px"></asp:TextBox>
                                                                        <br />
                                                                        <asp:RequiredFieldValidator ID="rfv_Qty" ControlToValidate="txtQty" Display="Dynamic" runat="server" ErrorMessage="Enter Product Quantity" ForeColor="Red" Font-Size="12px" ValidationGroup="ProductItem"></asp:RequiredFieldValidator>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="150px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblPrice" runat="server" Text="Price" CssClass="form-label"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtPrice1" runat="server" Text='<%# Bind("Price") %>' CssClass="form-control" Placeholder="Product Price" TextMode="Number" Style="width: 150px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPrice1" runat="server" Text='<%# Bind("Price") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtPrice" runat="server" Text="" CssClass="form-control" Placeholder="Product Price"></asp:TextBox>
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
                                                            <i class="ti ti-arrow-autofit-right text-info"></i>&nbsp;<asp:Label ID="lblTotalProcurement" runat="server" Text="Total Procurement Amount :" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp; &nbsp;
                                                                       <asp:Label ID="lblTotalAmountProcurement" runat="server" Text="" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <asp:Label ID="lblEdit" runat="server" Text="" Visible="false"></asp:Label>
                                                <h5>Project Services List</h5>
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
                                                                    data-bs-toggle="modal" data-bs-target="#ItemID">
                                                                    +
                                                                </button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="GridServicesList" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                            ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="true" OnRowDataBound="GridServicesList_RowDataBound" DataKeyNames="ID"
                                                            OnRowEditing="GridServicesList_RowEditing" OnRowUpdating="GridServicesList_RowUpdating" OnRowCancelingEdit="GridServicesList_RowCancelingEdit" OnRowDeleting="GridServicesList_RowDeleting" OnPageIndexChanging="GridServicesList_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField Visible="false">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblPID1" runat="server" Text="ID" CssClass="form-label"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblFID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
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
                                                                        <asp:RequiredFieldValidator ID="rfv_InvoiceItem" ControlToValidate="txtServices" Display="Dynamic" runat="server" ErrorMessage="Enter Services" Font-Size="12px" ForeColor="Red" ValidationGroup="Services"></asp:RequiredFieldValidator>
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
                                                                        <asp:RequiredFieldValidator ID="rfv_Duration" ControlToValidate="txtDuration" Display="Dynamic" runat="server" ErrorMessage="Enter Service Duration" ForeColor="Red" Font-Size="12px" ValidationGroup="Services"></asp:RequiredFieldValidator>
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
                                                                        <asp:TextBox ID="txtQty1" runat="server" Text='<%# Bind("Quantity") %>' CssClass="form-control" Placeholder="Quantity" TextMode="Number" Style="width: 60px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblQuantity1" runat="server" Text='<%# Bind("Quantity") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtQty" runat="server" Text="1" CssClass="form-control" Placeholder="Quantity" TextMode="Number" Style="width: 60px"></asp:TextBox>
                                                                        <br />
                                                                        <asp:RequiredFieldValidator ID="rfv_Qty" ControlToValidate="txtQty" Display="Dynamic" runat="server" ErrorMessage="Enter Quantity" ForeColor="Red" Font-Size="12px" ValidationGroup="Services"></asp:RequiredFieldValidator>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="150px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblPrice" runat="server" Text="Price" CssClass="form-label"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtPrice1" runat="server" Text='<%# Bind("Price") %>' CssClass="form-control" Placeholder="Service Price"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPrice1" runat="server" Text='<%# Bind("Price") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtPrice" runat="server" Text="" CssClass="form-control" Placeholder="Service Price"></asp:TextBox>
                                                                        <br />
                                                                        <asp:RequiredFieldValidator ID="rfv_Price" ControlToValidate="txtPrice" Display="Dynamic" runat="server" ErrorMessage="Enter Service Price" ForeColor="Red" Font-Size="12px" ValidationGroup="Services"></asp:RequiredFieldValidator>
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
                                                    <h5>Project Costing</h5>
                                                    <hr />
                                                    <div class="row">
                                                        <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6">
                                                            <i class="ti ti-star text-info"></i>&nbsp;<asp:Label ID="lblDuration" runat="server" Text="Project Complete Duration:" Font-Size="12px" Font-Bold="true" ForeColor="Blue"></asp:Label>&nbsp; &nbsp;
                                                                       <asp:Label ID="lblDurationDays" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                        </div>
                                                        <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6 text-end">
                                                            <i class="ti ti-star text-info"></i>&nbsp;<asp:Label ID="lblTotalcost" runat="server" Text="Project Cost :" Font-Size="12px" Font-Bold="true" ForeColor="Blue"></asp:Label>&nbsp; &nbsp;
                                                                       <asp:Label ID="lblTotalAmountProcu" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                            &nbsp;
                                                                    <asp:Label ID="lblServicelistTotal" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                            <br />
                                                            <i class="ti ti-star text-info"></i>&nbsp;<asp:Label ID="lblTotalCost5" runat="server" Text="Total Project Cost :" Font-Size="12px" Font-Bold="true" ForeColor="Blue"></asp:Label>&nbsp; &nbsp;
                                                                    <asp:Label ID="lblTotalProjectCost" runat="server" Text="" Font-Size="12px" ForeColor="Blue"></asp:Label>

                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <center>
                                                            <asp:LinkButton ID="linkbtnsInventory" runat="server" CssClass="btn btn-sm btn-primary" CausesValidation="false" Text="Send Prelist To Distribution" Font-Size="12px" OnClick="linkbtnsInventory_Click"></asp:LinkButton>
                                                        </center>
                                                    </div>

                                                </div>
                                                <br />
                                            </div>


                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%-- Project Detailing --%>
                            <div id="tasks" runat="server" visible="false">
                                <div class="p-20">
                                    <div class="container-fluid">
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 col-lg-12">

                                                <h5>Task</h5>
                                                <hr />
                                                <div class="row">
                                                    <div id="addnewTask" runat="server" class="col-md-2 col-sm-2 col-2 col-lg-2">
                                                        <asp:Button ID="btn_New_Task" runat="server" Text="New Task" CssClass="btn btn-sm btn-primary col-md-1" OnClick="btn_New_Task_Click" Style="width: 90px;" />&nbsp;
                                                    </div>
                                                    <div class="col-md-6 col-sm-6 col-lg-6  col-6"></div>
                                                    <div id="Div1" runat="server" class="col-md-4 col-sm-4 col-4 col-lg-4">
                                                        <asp:Button ID="btn_Task_Overview" runat="server" Text="Task Overview" CssClass="btn btn-sm btn-primary col-md-2" Width="170px" BackColor="ForestGreen" ForeColor="White" OnClick="btn_Task_Overview_Click" />&nbsp;
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                            </div>

                                        </div>
                                    </div>
                                    <div class="container-fluid">
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 col-lg-12">

                                                <h5>View Task Details</h5>
                                                <hr />
                                                <div class="col-md-6 col-sm-6 col-lg-6">
                                                    <div class="bd-example">
                                                        <div class="btn-group">
                                                            <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                                            <asp:Button ID="Button1" runat="server" Style="display: none" />
                                                            <div class="dropdown-menu">
                                                                <asp:LinkButton ID="lnkbtnExcelTask" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="lnkbtnExcelTask_Click"></asp:LinkButton>
                                                                <asp:LinkButton ID="linkbtnPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnPDF_Click"></asp:LinkButton>

                                                            </div>
                                                        </div>
                                                        <asp:Button ID="btn_Visibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" ValidationGroup="task12" OnClick="btn_Visibility_Click" />
                                                        <asp:Button ID="BtnReload" runat="server" Text="Reload" CssClass="btn btn-sm btn-sm btn-outline-info" ValidationGroup="task13" OnClick="BtnReload_Click" />
                                                    </div>
                                                </div>


                                                <br />
                                                <br />
                                                <div id="grd">
                                                    <asp:GridView ID="GridTask1" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-responsive table-hover text-nowrap align-content-center" Style="width: 150%" AutoGenerateColumns="false" CellPadding="4"
                                                        ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" OnRowDataBound="GridTask_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="ID">
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
                                                            <asp:TemplateField HeaderText="Start_Date" SortExpression="Start_Date" HeaderStyle-Font-Size="12px">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblStart_Date" runat="server" Text='<%#Bind("Start_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStart_Date1" runat="server" Text='<%#Bind("Start_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Due_Date" SortExpression="Due_Date" HeaderStyle-Font-Size="12px">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblDue_Date" runat="server" Text='<%#Bind("Due_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDue_Date1" runat="server" Text='<%#Bind("Due_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Assigned To" SortExpression="AssignTo" HeaderStyle-Font-Size="12px" HeaderStyle-Width="180px">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblReletd_To" runat="server" Text='<%# Bind("AssignTo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <div class="m-2">
                                                                        <asp:BulletedList ID="bulletlist1" runat="server" BulletStyle="Circle" CssClass="" Font-Size="12px">
                                                                        </asp:BulletedList>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Status" SortExpression="TaskStatus" HeaderStyle-Font-Size="12px" HeaderStyle-Width="160px">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblTaskStatus" runat="server" Text='<%#Bind("TaskStatus") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlTaskStatus" runat="server" CssClass="form-control " AutoPostBack="true" OnSelectedIndexChanged="ddlTaskStatus_SelectedIndexChanged" Font-Size="12px">
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
                                                                    <asp:Button ID="btnStatus" runat="server" Text='<%# Bind("Status") %>' CssClass="btn btn-info pull-left display-block mright5" TabIndex="126" />
                                                                    <asp:Label ID="lblstatus1" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false" Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Reapeted" SortExpression="Reapet_Every" HeaderStyle-Font-Size="12px" Visible="false">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblReapet_Every" runat="server" Text='<%# Bind("Reapet_Every") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblReapet_Every1" runat="server" Text='<%# Bind("Reapet_Every") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Priority" SortExpression="Priority" HeaderStyle-Font-Size="12px" HeaderStyle-Width="120px">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblPriority" runat="server" Text='<%# Bind("Priority") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form-control " AutoPostBack="true" OnSelectedIndexChanged="ddlPriority_SelectedIndexChanged" Style="width: 140px">
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
                                </div>
                            </div>

                            <div id="files" runat="server" visible="false">
                                <div class="p-20">
                                    <div class="container-fluid">
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 col-lg-12">

                                                <div class="row">
                                                    <h5>Project Files</h5>
                                                    <hr />
                                                    <div class="row">

                                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                                            <div class="mb-2">
                                                                <asp:Label ID="lblAttachment" runat="server" Text="Attachment" CssClass="form-label"></asp:Label>
                                                            </div>
                                                            <div class="mb-2">
                                                                <div class="input-group">
                                                                    <asp:FileUpload ID="FileUploadP" runat="server" Text="" CssClass="form-control" />
                                                                    <asp:Button ID="Btn_Upload" runat="server" Text="Upload" CssClass="btn btn-sm btn-primary" ValidationGroup="projectq" OnClick="Linkupload_Click" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <br />
                                                    <div class="row">
                                                        <h5>View File Details</h5>
                                                        <hr />
                                                        <div class="col-md-6 col-sm-6 col-lg-6">
                                                            <asp:Button ID="btnFileEXPORT" runat="server" Text="Export" CssClass="btn btn-sm btn-outline-success" ValidationGroup="fileExport" OnClick="btnFileEXPORT_Click" />&nbsp;
                                                                    <asp:Button ID="btnFileRELOAD" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-primary" ValidationGroup="fileReload" OnClick="btnFileRELOAD_Click" />&nbsp;     
                                                        </div>
                                                        <br />
                                                        <br />
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GridFile1" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover" Style="width: 100%" AutoGenerateColumns="false" CellPadding="4"
                                                                ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" OnRowDataBound="GridFile1_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px">
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Size="12px"></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="File_Name" SortExpression="File Name" HeaderStyle-Font-Size="12px" HeaderStyle-Width="200px">
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="lblFileName" runat="server" Text='<%# Bind("FileName") %>' Font-Size="12px"></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="ImgFileName" runat="server" CssClass="project-file-image" Visible="false" />&nbsp;&nbsp;
                                                                                <asp:Label ID="lblFileName1" runat="server" Text='<%# Bind("FileName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="File_Type" SortExpression="File Type" HeaderStyle-Font-Size="12px">
                                                                        <EditItemTemplate>
                                                                            <asp:Label ID="lblFile_Type" runat="server" Text='<%# Bind("FileExtension") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblFile_Type1" runat="server" Text='<%# Bind("FileExtension") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="FilePath" SortExpression="FilePath" HeaderStyle-Font-Size="12px" Visible="false">
                                                                        <EditItemTemplate>
                                                                            <asp:Label ID="lblFilePath" runat="server" Text='<%# Bind("FilePath") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblFilePath1" runat="server" Text='<%# Bind("FilePath") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Last_Activity" SortExpression="Last_Activity" HeaderStyle-Font-Size="12px">
                                                                        <EditItemTemplate>
                                                                            <asp:Label ID="lblLast_Activity" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblLast_Activity1" runat="server" Text="No Activity" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Visible_to_Customer" SortExpression="Visible_to_Customer" HeaderStyle-Font-Size="12px" HeaderStyle-Width="150px">
                                                                        <EditItemTemplate>
                                                                            <asp:Label ID="lblVisible_to_Customer" runat="server" Text="" TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkViewCustomer" runat="server" Font-Size="12px" AutoPostBack="true" OnCheckedChanged="chkViewCustomer_CheckedChanged" />

                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Uploaded_by" SortExpression="Uploaded_by" HeaderStyle-Font-Size="12px" HeaderStyle-Width="150px">
                                                                        <EditItemTemplate>
                                                                            <asp:Label ID="lblUploaded_by" runat="server" Text='<%# Bind("CreateBy") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblUploaded_by1" runat="server" Text='<%# Bind("CreateBy") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date_Uploaded" SortExpression="Date_Uploaded" HeaderStyle-Font-Size="12px" HeaderStyle-Width="150px">
                                                                        <EditItemTemplate>
                                                                            <asp:Label ID="lblDate_Uploaded" runat="server" Text='<%# Bind("CreateDate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDate_Uploaded1" runat="server" Text='<%# Bind("CreateDate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btnEmailFile" runat="server" CssClass="btn btn-sm btn-outline-info mb-3" OnClick="btnEmailFile_Click"><i class="ti  ti-inbox"></i></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                        </EditItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btnDeleteFile" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteFile_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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
                            <div id="estimate" runat="server" visible="false">
                                <div class="p-20">

                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-lg-12">

                                            <div id="addEstimate" runat="server">
                                                <h5>Estimate</h5>
                                                <hr />
                                                <asp:Button ID="btn_CreateEstimate" runat="server" Text="CREATE ESTIMATE" CssClass="btn btn-primary btn-sm" OnClick="btn_CreateEstimate_Click" />
                                            </div>
                                        </div>

                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-lg-12">

                                            <h5>View Estimate Details</h5>
                                            <hr />
                                            <asp:Button ID="btnEstimateExport" runat="server" Text="Export" CssClass="btn btn-sm  btn-outline-success" ValidationGroup="export" OnClick="btnEstimateExport_Click" />
                                            <asp:Button ID="btnEstimateReload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-primary" ValidationGroup="reload" OnClick="btnEstimateReload_Click" />
                                            <br />
                                            <br />
                                            <div class="table-responsive">
                                                <asp:GridView ID="GridEstimate" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                    ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridEstimate_RowDataBound">
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
                                                        <asp:TemplateField HeaderText="EstimateNumber" SortExpression="EstimateNo" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblEstimateNumber" runat="server" Text='<%# Bind("EstimateNo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEstimateNo1" runat="server" Text='<%# Bind("EstimateNo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                <asp:LinkButton ID="LinkEstimateNumber" runat="server" Text='<%# Bind("EstimateNo") %>' OnClick="LinkEstimateNumber_Click" Font-Size="12px"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Amount" SortExpression="Amount" HeaderStyle-Width="150px" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("InvoiceTotalAmont") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("InvoiceTotalAmont") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="EstimateDate" SortExpression="EstimateDate" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblEstimateDate" runat="server" Text='<%# Bind("EstimateDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEstimateDate1" runat="server" Text='<%# Bind("EstimateDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CustomerName" SortExpression="CustomerName" HeaderStyle-Width="130px" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblCustomerID" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCustomerID1" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ProjectName" SortExpression="ProjectName" HeaderStyle-Width="130px" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblProjectID" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProjectID1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Sales_Agent" SortExpression="Sales_Agent" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblSales_Agent" runat="server" Text='<%# Bind("Sales_Agent") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSales_Agent1" runat="server" Text='<%# Bind("Sales_Agent") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status" SortExpression="Status" HeaderStyle-Width="180px" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStatus1" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Expiry_Date" SortExpression="Expiry_Date" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblExpiry_Date" runat="server" Text='<%# Bind("Expiry_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblExpiry_Date1" runat="server" Text='<%# Bind("Expiry_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnEditEstimate" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditEstimate_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnDeleteEstimate" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteEstimate_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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
                            </div>

                            <div id="invoices" runat="server" visible="false">
                                <div class="p-20">

                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-lg-12">

                                            <div id="addInvoice" runat="server">
                                                <h5>New Invoice</h5>
                                                <hr />
                                                <asp:Button ID="btn_Create_New_Invoice" runat="server" Text="Create New Invoice" CssClass="btn btn-primary fa-pull-left" OnClick="btn_Create_New_Invoice_Click" />
                                            </div>
                                        </div>

                                    </div>

                                    <br />
                                    <br />

                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-lg-12">

                                            <h5>View Invoice Details</h5>
                                            <hr />
                                            <asp:Button ID="btnInvoiceExport" runat="server" Text="Export" CssClass="btn btn-sm btn-outline-success" OnClick="btnInvoiceExport_Click" />
                                            <asp:Button ID="btnInvoiceReload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-primary" OnClick="btnInvoiceReload_Click" />
                                        </div>

                                        <div class="card-body">

                                            <asp:GridView ID="GridInvoice" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4"
                                                ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridInvoice_RowDataBound">
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
                                                    <asp:TemplateField HeaderText="InvoiceNumber" SortExpression="Invoice" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblInvoice" runat="server" Text='<%# Bind("InvoiceNo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblInvoice1" runat="server" Text='<%# Bind("InvoiceNo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                            <asp:LinkButton ID="LinkInvoiceNumber" runat="server" Text='<%# Bind("InvoiceNo") %>' OnClick="LinkInvoiceNumber_Click" Font-Size="12px"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount" SortExpression="InvoiceTotalAmont" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("InvoiceTotalAmont") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("InvoiceTotalAmont") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Invoice_Date" SortExpression="InvoiceDate" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblDate" runat="server" Text='<%# Bind("InvoiceDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDate1" runat="server" Text='<%# Bind("InvoiceDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Customer" SortExpression="Cust_Name" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblCustomer" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCustomer1" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Project" SortExpression="ProjectName" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblProject" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblProject1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sales_Agent" SortExpression="Sales_Agent" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblSales_Agent" runat="server" Text='<%# Bind("Sales_Agent") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSales_Agent1" runat="server" Text='<%# Bind("Sales_Agent") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status" SortExpression="Status" HeaderStyle-Font-Size="12px" Visible="false">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblStats61" runat="server" Text=""></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStats6" runat="server" Text='<%# Bind("Status") %>'></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Due_Date" SortExpression="Expiry_Date" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblDue_Date" runat="server" Text='<%# Bind("Expiry_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDue_Date1" runat="server" Text='<%# Bind("Expiry_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnEditInvoice" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditInvoice_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnDeleteInvoice" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteInvoice_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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
                            <div id="expenses" runat="server" visible="false">
                                <div class="p-20">

                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-ld-12">

                                            <div id="addnewProjectExpenses" runat="server">
                                                <h5>Project Expense</h5>
                                                <hr />
                                                <div class="row">
                                                    <div class="col-md-2 col-sm-2 col-ld-2">
                                                        <asp:Button ID="btnRecordExpense" runat="server" Text="Record Product Purchase Expense" CssClass="btn btn-sm btn-primary" OnClick="btnRecordExpense_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <br />
                                    <div class="row">
                                        <h5>View Expenses Details</h5>
                                        <hr />
                                        <div class="row">
                                            <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                                                <div class="bd-example">
                                                    <div class="btn-group">
                                                        <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                                        <asp:Button ID="Button2" runat="server" Style="display: none" />
                                                        <div class="dropdown-menu">
                                                            <asp:LinkButton ID="lnkbtnExcelPurchase" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="lnkbtnExcelPurchase_Click"></asp:LinkButton>
                                                            <asp:LinkButton ID="linkbtnPdfPurchase" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnPdfPurchase_Click"></asp:LinkButton>

                                                        </div>
                                                    </div>
                                                    <asp:Button ID="btnProjectpVisibility" runat="server" Text="Visibilty" CssClass="btn btn-sm btn-outline-info" OnClick="btnProjectpVisibility_Click" />
                                                    <asp:Button ID="btnProjectpReload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="btnProjectpReload_Click" />
                                                </div>
                                            </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="table-responsive">
                                                <asp:GridView ID="GridProjectPurchase" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                    ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="Pur_id">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="ID">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Pur_id" SortExpression="Pur_id" Visible="false">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblPur_id" runat="server" Text='<%# Bind("Pur_id") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPur_id1" runat="server" Text='<%# Bind("Pur_id") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Purchase_Name" SortExpression="Pur_Name">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblPur_Name" runat="server" Text='<%# Bind("Pur_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPur_Name1" runat="server" Text='<%# Bind("Pur_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Amount" SortExpression="Pur_Amount">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblPur_Amount" runat="server" Text='<%# Bind("Pur_Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPur_Amount1" runat="server" Text='<%# Bind("Pur_Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Category" SortExpression="Pur_Category">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblPur_Category" runat="server" Text='<%# Bind("Pur_Category") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPur_Category1" runat="server" Text='<%# Bind("Pur_Category") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SubCategory" SortExpression="Pur_SubCategory">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblPur_SubCategory" runat="server" Text='<%# Bind("Pur_SubCategory") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPur_SubCategory1" runat="server" Text='<%# Bind("Pur_SubCategory") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Customer" SortExpression="Pur_Customer">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblPur_Customer" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPur_Customer1" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Project" SortExpression="Pur_Project">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblPur_Project" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPur_Project1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Purchase_Date" SortExpression="Pur_Date">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblPur_Date" runat="server" Text='<%# Bind("Pur_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPur_Date1" runat="server" Text='<%# Bind("Pur_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Reference" SortExpression="Pur_Reference">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblPur_Reference" runat="server" Text='<%# Bind("Pur_Reference") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPur_Reference1" runat="server" Text='<%# Bind("Pur_Reference") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Payment" SortExpression="Pur_Payment">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblPur_Payment" runat="server" Text='<%# Bind("Pur_Payment") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPur_Payment1" runat="server" Text='<%# Bind("Pur_Payment") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnEditProjectPurchase" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditProjectPurchase_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnDeleteProjectPurchase" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClick="btnDeleteProjectPurchase_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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
                                <div id="notes" runat="server" visible="false">
                                    <div class="p-20">
                                        <div class="container-fluid">
                                            <div class="row">
                                                <div class="col-md-12 col-sm-12 col-ld-12">

                                                    <h5>Personal notes</h5>
                                                    <hr />
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-ld-12">
                                                            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" class="EditorNote"></asp:TextBox>

                                                            <br />
                                                            <asp:Button ID="btnNotesSave" runat="server" Text="Save" CssClass="btn btn-sm btn-primary  fa-align-right" OnClick="btnNotesSave_Click" />&nbsp;&nbsp;
                                                                 <asp:Button ID="btnNoteClear" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger fa-align-right" OnClick="btnNoteClear_Click" />

                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="activity" runat="server" visible="false">
                                    <div class="p-20">

                                        <h5>Project Activity</h5>
                                        <hr />

                                        <div >
                                            <asp:GridView ID="GridViewAct" runat="server" ScrollBars="Both" CssClass="table table-bordered table-responsive table-hover" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%" ShowHeader="false"
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
                                                            <asp:Label ID="lblDifd" runat="server" Text='<%# Bind("Diff") %>' TabIndex="6" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                                            &nbsp;
                                                                 <asp:Label ID="lblAgo" runat="server" Text="MONTH  AGO" TabIndex="6" Font-Size="12px" ForeColor="Blue"></asp:Label>&nbsp;
                                                                 <asp:Label ID="lblDate" runat="server" Text='<%# Bind("ActivityDate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label>&nbsp;
                                                                 <br />
                                                            <asp:Label ID="Label1" runat="server" Text="---------------------------------------------------------------------" TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="LightGray"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblUserID1" runat="server" Text='<%# Bind("UserID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            <asp:Label ID="Designation1" runat="server" Text='<%# Bind("Designation") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>&nbsp;&nbsp;
                                                                 <asp:Label ID="lbldash" runat="server" Text="-" TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            <asp:Label ID="lblActivityType" runat="server" Text='<%# Bind("ActivityType") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>&nbsp;&nbsp;
                                                        </ItemTemplate>
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
                                <div id="tender" runat="server" visible="false">
                                    <div class="p-20">
                                        <div class="container-fluid">
                                            <div class="row">
                                                <div class="col-md-12 col-sm-12 col-lg-12">

                                                    <div id="addnew" runat="server">
                                                        <h5>Tender</h5>
                                                        <br />
                                                        <asp:Button ID="btn_CreateTender" runat="server" Text="New Tender" CssClass="btn btn-primary btn-sm" OnClick="btn_CreateTender_Click" />

                                                        <hr />
                                                    </div>
                                                </div>

                                                <h5>View Tender Details</h5>
                                                <hr />

                                                <div class="row">
                                                    <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                                                        <div class="bd-example">
                                                            <div class="btn-group">
                                                                <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                                                <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                                                <div class="dropdown-menu">
                                                                    <asp:LinkButton ID="lnkbtnExcelTender" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="lnkbtnExcelTender_Click"></asp:LinkButton>
                                                                    <asp:LinkButton ID="linkbtnPDFTender" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnPDFTender_Click"></asp:LinkButton>

                                                                </div>
                                                            </div>
                                                            <asp:Button ID="btnVisibilityTender" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="btnVisibilityTender_Click" />
                                                            <asp:Button ID="btnVisibilityReload" runat="server" Text="Reload" CssClass="btn btn-outline-info btn-sm" OnClick="btnVisibilityReload_Click" />
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
                                                        <asp:Label ID="lblcompanyaddCountry1" runat="server" Text="," CssClass="" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblpincode" runat="server" Text="PIN:" CssClass=" font-bold" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblphone" runat="server" Text="Phone:" CssClass=" font-bold" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblphoneNo1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblvat" runat="server" Text="VAT NO:" CssClass=" font-bold" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblVatNo1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" CssClass=" font-bold" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblGSTNo1A" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                                        <!------PDF code--------->

                                                    </div>
                                                </div>

                                                <br />
                                                <br />

                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
                                                        <asp:GridView ID="GridTender" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%" HeaderStyle-Font-Size="12px"
                                                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridTender_RowDataBound">
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

                                                                <asp:TemplateField HeaderText="TenderNumber" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblTenderno" runat="server" Text='<%# Bind("TenderNo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTenderno1" runat="server" Text='<%# Bind("TenderNo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                        <asp:LinkButton ID="LinkTenderNumber" runat="server" Text='<%# Bind("TenderNo") %>' OnClick="LinkTenderNumber_Click" Font-Size="12px"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="TenderName" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblTender" runat="server" Text='<%# Bind("TenderName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTender1" runat="server" Text='<%# Bind("TenderName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="TenderDate" SortExpression="TenderDate" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblTenderDate" runat="server" Text='<%# Bind("TenderDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTenderDate1" runat="server" Text='<%# Bind("TenderDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="BidEndDate" SortExpression="BiddingDate" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblDate" runat="server" Text='<%# Bind("BidEndDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDate1" runat="server" Text='<%# Bind("BidEndDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="PublishDate" SortExpression="PublishDate" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblpublishdate" runat="server" Text='<%# Bind("publishdate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblpublishdate1" runat="server" Text='<%# Bind("publishdate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Category" SortExpression="Sales_Agent" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("TenderBased") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCategory1" runat="server" Text='<%# Bind("TenderBased") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Publish" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>

                                                                        <asp:CheckBox ID="Chk_Pulish" runat="server" Font-Bold="true" Checked='<%# Bind("Publish") %>' OnCheckedChanged="Chk_Pulish_CheckedChanged" AutoPostBack="true" />

                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Status" SortExpression="Status" Visible="false">

                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status1") %>' Visible="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEditTender" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditTender_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDeleteTender" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteTender_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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
                                    </div>
                                </div>


                            </div>

                        </div>

                        <%-- Tabs Designs--%>

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
                                                <asp:UpdatePanel ID="UpdatePanelitem" runat="server">
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
            </div>
        </div>

        <!-- Enable the tab functionality -->
        <script>
            $(".nav li a").on("click", function () {
                $(".nav li a").removeClass("active");
                $(this).addClass("active");
            });
        </script>

        <!-- Drag Drop functionality -->
        <style>
            .uploadOuter {
                text-align: center;
                padding: 20px;
                /*  strong {
            padding: 0 10px
            }*/
            }

            .dragBox {
                width: 100%;
                height: 170px;
                margin: -22px 18px 11px -80px;
                position: relative;
                text-align: center;
                font-weight: bold;
                line-height: 95px;
                color: #999;
                border: 2px dashed #ccc;
                display: inline-block;
                transition: transform 0.3s;
            }

                .dragBox input[type="file"] {
                    /* position: absolute; */
                    opacity: 0; /* Hide the input element */
                    position: absolute;
                    top: 0;
                    left: 0;
                    width: 100%;
                    height: 100%;
                    cursor: pointer; /* Show pointer cursor when hovering over the dragBox */
                }

            .draging {
                transform: scale(1.1);
            }

            #preview {
                text-align: center;
            }


                #preview img {
                    height: 100px;
                    width: 150px;
                }

            #btndesgin {
                text-align: center;
            }
        </style>



        <script>
            "use strict";

            function dragNdrop(event) {
                var fileName = URL.createObjectURL(event.target.files[0]);
                var preview = document.getElementById("preview");
                var path = document.getElementById("lblpath");

                var previewImg = document.createElement("img");
                previewImg.setAttribute("src", fileName);
                preview.innerHTML = "";
                preview.appendChild(previewImg);
            }

            function drag() {
                document.getElementById('uploadFile').parentNode.className = 'dragging dragBox';
            }

            function drop() {
                document.getElementById('uploadFile').parentNode.className = 'dragBox';
            }
        </script>
</asp:Content>

