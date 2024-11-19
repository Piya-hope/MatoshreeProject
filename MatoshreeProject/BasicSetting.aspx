<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="BasicSetting.aspx.cs" Inherits="MatoshreeProject.BasicSetting" EnableEventValidation="false" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            var GridStatus = $("#GridStatus").prepend($("<thead></thead>").append($("#GridStatus").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "350px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridBillingType = $("#GridBillingType").prepend($("<thead></thead>").append($("#GridBillingType").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridContractType = $("#GridContractType").prepend($("<thead></thead>").append($("#GridContractType").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "350px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridCategory = $("#GridCategory").prepend($("<thead></thead>").append($("#GridCategory").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridSubcategory = $("#GridSubcategory").prepend($("<thead></thead>").append($("#GridSubcategory").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridViewDiscount = $("#GridViewDiscount").prepend($("<thead></thead>").append($("#GridViewDiscount").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridViewReceipt = $("#GridViewReceipt").prepend($("<thead></thead>").append($("#GridViewReceipt").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridState = $("#GridState").prepend($("<thead></thead>").append($("#GridState").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridDistrict = $("#GridDistrict").prepend($("<thead></thead>").append($("#GridDistrict").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridCity1 = $("#GridCity1").prepend($("<thead></thead>").append($("#GridCity1").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridViewTaxDetails = $("#GridViewTaxDetails").prepend($("<thead></thead>").append($("#GridViewTaxDetails").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });


            var GridTenderCategory = $("#GridTenderCategory").prepend($("<thead></thead>").append($("#GridTenderCategory").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });


            var GridDepartment = $("#GridDepartment").prepend($("<thead></thead>").append($("#GridDepartment").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridViewPageName = $("#GridViewPageName").prepend($("<thead></thead>").append($("#GridViewPageName").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridMeasurmentProd = $("#GridMeasurmentProd").prepend($("<thead></thead>").append($("#GridMeasurmentProd").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });
            var GridViewProductType = $("#GridViewProductType").prepend($("<thead></thead>").append($("#GridViewProductType").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });


            var GridViewPolicy = $("#GridViewPolicy").prepend($("<thead></thead>").append($("#GridViewPolicy").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });
            var GridHoliday = $("#GridHoliday").prepend($("<thead></thead>").append($("#GridHoliday").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });
            var GridPerticular = $("#GridPerticular").prepend($("<thead></thead>").append($("#GridPerticular").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });
            var GridViewShift = $("#GridViewShift").prepend($("<thead></thead>").append($("#GridViewShift").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });
            var GridMark = $("#GridMark").prepend($("<thead></thead>").append($("#GridMark").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var Gridlogoimg = $("#Gridlogoimg").prepend($("<thead></thead>").append($("#Gridlogoimg").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });
            var GridControlPanel = $("#GridControlPanel").prepend($("<thead></thead>").append($("#GridControlPanel").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridViewClass = $("#GridViewClass").prepend($("<thead></thead>").append($("#GridViewClass").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GVDBSetting = $("#GVDBSetting").prepend($("<thead></thead>").append($("#GVDBSetting").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,


                });

            var GridLeave = $("#GridLeave").prepend($("<thead></thead>").append($("#GridLeave").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridViewTermAndCondition = $("#GridViewTermAndCondition").prepend($("<thead></thead>").append($("#GridViewTermAndCondition").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridField = $("#GridField").prepend($("<thead></thead>").append($("#GridField").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });


            tinymce.init({
                // selector: 'textarea',
                //selector : "textarea.Editor"
                selector: ".EditorNote",
                //theme: "modern",
                //plugins: ["lists link image charmap print preview hr anchor pagebreak"],

            });

        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h5 class="font-weight-medium mb-0">Basic Setting</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="#">SETUP
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="BasicSetting.aspx">Web Setting</li>
            </ol>
        </nav>
        <br />
        <div class="row">
            <div class="row">
                <div class="col-md-7 col-sm-7 col-xl-7 col-lg-7"></div>
                <%-- Toaster --%>
                <div class="col-md-5 col-sm-5 col-xl-5 col-lg-5">
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
                <div class="col-md-3 col-sm-3 col-lg-3  col-xl-3">
                    <table id="EmailTable" class="table table-bordered table-responsive table-hover" style="width: 100%">
                        <tbody style="background: white">
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkbtnDivStatusOptions" runat="server" OnClick="lnkbtnDivStatusOptions_Click" class="btn btn-link" Font-Size="12px" ForeColor="Blue">Status Options</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkbtnDivContractType" runat="server" OnClick="lnkbtnDivContractType_Click" class="btn btn-link" Font-Size="12px">Contract Type</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkbtnDivBillingOptions" runat="server" OnClick="lnkbtnDivBillingOptions_Click" CssClass="btn btn-link" Font-Size="12px">Billing Options</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkbtnDivDiscountOptions" runat="server" OnClick="lnkbtnDivDiscountOptions_Click" CssClass="btn btn-link" Font-Size="12px">Discount Options</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkbtnDivExpensesCategory" runat="server" OnClick="lnkbtnDivExpensesCategory_Click" CssClass="btn btn-link" Font-Size="12px">Expenses Category</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkbtnDivExpensesSubCategory" runat="server" OnClick="lnkbtnDivExpensesSubCategory_Click" CssClass="btn btn-link" Font-Size="12px">Expenses SubCategory</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lknbtnDivReceiptInitialDetails" runat="server" OnClick="lknbtnDivReceiptInitialDetails_Click" CssClass="btn btn-link" Font-Size="12px">Receipt Initial</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="linkbtnDivTenderCategory" runat="server" OnClick="linkbtnDivTenderCategory_Click" CssClass="btn btn-link" Font-Size="12px">Tender Category</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkbtnDivAddressStateDetails" runat="server" OnClick="lnkbtnDivAddressStateDetails_Click" CssClass="btn btn-link" Font-Size="12px">State</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkbtnDivAddressDistrictDetails" runat="server" OnClick="lnkbtnDivAddressDistrictDetails_Click" CssClass="btn btn-link" Font-Size="12px">District</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkbtnDivAddressCityTalukaDetails" runat="server" OnClick="lnkbtnDivAddressCityTalukaDetails_Click" CssClass="btn btn-link" Font-Size="12px">City</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkbtnDivTaxDetails" runat="server" OnClick="lnkbtnDivTaxDetails_Click" CssClass="btn btn-link" Font-Size="12px">Tax</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkbtnDivPagesOptions" runat="server" OnClick="lnkbtnDivPagesOptions_Click" CssClass="btn btn-link" Font-Size="12px">Pages Options</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkbtnDivDepartmentDetails" runat="server" OnClick="lnkbtnDivDepartmentDetails_Click" CssClass="btn btn-link" Font-Size="12px">Department</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkbtnDivMeasurementProductDetails" runat="server" OnClick="lnkbtnDivMeasurementProductDetails_Click" CssClass="btn btn-link" Font-Size="12px">Measurement Product</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="linkbtnDIVProductStoragetype" runat="server" OnClick="linkbtnDIVProductStoragetype_Click" CssClass="btn btn-link" Font-Size="12px">Product Storage Type</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="linkDIVbtnPolicy" runat="server" OnClick="linkDIVbtnPolicy_Click" CssClass="btn btn-link" Font-Size="12px">Policy Options</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="likDIVShift" runat="server" OnClick="likDIVShift_Click" CssClass="btn btn-link" Font-Size="12px">HRMS Shifts</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="linkDIVSalaryComponent" runat="server" OnClick="linkDIVSalaryComponent_Click" CssClass="btn btn-link" Font-Size="12px">Salary Component</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="linkDivHolidays" runat="server" OnClick="linkDivHolidays_Click" CssClass="btn btn-link" Font-Size="12px">Holidays</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="linkDivLeaveMark" runat="server" OnClick="linkDivLeaveMark_Click" CssClass="btn btn-link" Font-Size="12px">Leave Mark</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="linkControlPanel" runat="server" OnClick="linkControlPanel_Click" CssClass="btn btn-link" Font-Size="12px">Control Panel</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="linkMasterLogo" runat="server" OnClick="linkMasterLogo_Click" CssClass="btn btn-link" Font-Size="12px">Sidebar Logo</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="linkSalaryClass" runat="server" OnClick="linkSalaryClass_Click" CssClass="btn btn-link" Font-Size="12px">Salary Class</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="linkLeaveType" runat="server" OnClick="linkLeaveType_Click" CssClass="btn btn-link" Font-Size="12px">Leave Type</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="linkDashPermission" runat="server" OnClick="linkDashPermission_Click" CssClass="btn btn-link" Font-Size="12px">Dashboard Permission</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="linkCandidateTerms" runat="server" OnClick="linkCandidateTerms_Click" CssClass="btn btn-link" Font-Size="12px">Candidate Tems & Conditions</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="linkOfficialDocFiled" runat="server" OnClick="linkOfficialDocFiled_Click" CssClass="btn btn-link" Font-Size="12px">Document Fields</asp:LinkButton>
                                </td>
                            </tr>
                        </tbody>
                    </table>

                </div>

                <%-- Web Setting --%>
                <div class="col-md-9 col-sm-9 col-lg-9 col-xl-9">
                    <asp:UpdatePanel ID="UpdatePanelddlState" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <div class="row">
                                <div id="DivStatusOptions" runat="server" visible="true">
                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5 class="text-purple">Status Options</h5>
                                                        <hr />
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblStatusName" runat="server" Text="Status Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtStatus" runat="server" placeholder="Enter Status Name" class="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Status Name" ControlToValidate="txtStatus" ForeColor="Red" Font-Bold="false" ValidationGroup="Status" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblStatusBilng" runat="server" Text="Related To" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <div class="mb-2">
                                                                <asp:DropDownList ID="ddlRelatedTo" CssClass="form-control form-select" runat="server">
                                                                    <asp:ListItem Text="Select Related To" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Project" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Invoice" Value="2"> </asp:ListItem>
                                                                    <asp:ListItem Text="Customer" Value="3"></asp:ListItem>
                                                                    <asp:ListItem Text="Estimate" Value="4"></asp:ListItem>
                                                                    <asp:ListItem Text="Tender" Value="5"></asp:ListItem>
                                                                    <asp:ListItem Text="Task" Value="11"></asp:ListItem>
                                                                    <asp:ListItem Text="Contract" Value="6"></asp:ListItem>
                                                                    <asp:ListItem Text="Ticket" Value="7"></asp:ListItem>
                                                                    <asp:ListItem Text="Expenses" Value="8"></asp:ListItem>
                                                                    <asp:ListItem Text="Vendor" Value="9"></asp:ListItem>
                                                                    <asp:ListItem Text="Proposal" Value="10"></asp:ListItem>
                                                                    <asp:ListItem Text="Task" Value="11"></asp:ListItem>
                                                                    <asp:ListItem Text="PurchaseOrder" Value="12"></asp:ListItem>
                                                                    <asp:ListItem Text="WorkOrder" Value="13"></asp:ListItem>
                                                                    <asp:ListItem Text="Lead" Value="14"></asp:ListItem>
                                                                    <asp:ListItem Text="Challan" Value="15"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Select Related To" InitialValue="0" ControlToValidate="ddlRelatedTo" ForeColor="Red" Font-Bold="false" ValidationGroup="Status" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div id="addnew" runat="server">
                                                            <div class="mb-2">
                                                                <asp:Button ID="btnSaveStatus" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="Status" OnClick="btnSaveStatus_Click" />
                                                                &nbsp;&nbsp;
                                       <asp:Button ID="btnClearStatus" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger " ValidationGroup="Cancel" OnClick="btnClearStatus_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                        <h5>View Status Details</h5>
                                                        <hr />

                                                        <asp:GridView ID="GridStatus" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive table-responsive-md" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable" Style="width: 100%"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="Status_ID" OnRowDataBound="GridStatus_RowDataBound"
                                                            OnRowEditing="GridStatus_RowEditing" OnRowUpdating="GridStatus_RowUpdating" OnRowCancelingEdit="GridStatus_RowCancelingEdit" OnRowDeleting="GridStatus_RowDeleting" OnPageIndexChanging="GridStatus_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="Status_ID" Visible="false" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblStatus_ID" runat="server" Text='<%# Bind("Status_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStatus_ID1" runat="server" Text='<%# Bind("Status_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="StatusName" SortExpression="ProgessStatus" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtProgessStatus" runat="server" Text='<%# Bind("ProgessStatus") %>' Font-Size="12px" CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblProgessStatus1" runat="server" Text='<%# Bind("ProgessStatus") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="RelatedTo" SortExpression="RelatedTo" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblStatuspro" runat="server" Text='<%# Bind("BelongTo") %>' Visible="false" />
                                                                        <asp:DropDownList ID="ddlRelatedTo" CssClass="form-control form-select" runat="server">
                                                                            <asp:ListItem Text="Select Related To" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="Project" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Invoice" Value="2"> </asp:ListItem>
                                                                            <asp:ListItem Text="Customer" Value="3"></asp:ListItem>
                                                                            <asp:ListItem Text="Estimate" Value="4"></asp:ListItem>
                                                                            <asp:ListItem Text="Tender" Value="5"></asp:ListItem>
                                                                            <asp:ListItem Text="Contract" Value="6"></asp:ListItem>
                                                                            <asp:ListItem Text="Ticket" Value="7"></asp:ListItem>
                                                                            <asp:ListItem Text="Expenses" Value="8"></asp:ListItem>
                                                                            <asp:ListItem Text="Vendor" Value="9"></asp:ListItem>
                                                                            <asp:ListItem Text="Proposal" Value="10"></asp:ListItem>
                                                                            <asp:ListItem Text="Task" Value="11"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRelatedTo1" runat="server" Text='<%# Bind("BelongTo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreatedBy" SortExpression="CreatedBy" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreateBy" runat="server" Text='<%#Bind("CreateBy") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreateBy1" runat="server" Text='<%#Bind("CreateBy") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreatedDate" SortExpression="CreatedDate" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreatedDate" runat="server" Text='<%#Bind("CreateDate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>

                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreatedDate1" runat="server" Text='<%#Bind("CreateDate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update" CssClass="btn btn-sm " TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="Cancel" CssClass="btn btn-sm" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger"><i class="ti ti-trash"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <div align="center" style="color: red">
                                                                    <h6>
                                                                    No records found.</h5>
                                                                </div>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Status --%>
                                <%-- Contract Type --%>
                                <div id="DivContractType" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5 class="text-purple">Contract Type</h5>
                                                        <hr />
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblContrcttype" runat="server" Text="Contract Type" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtContractType" runat="server" placeholder="Enter Contract Type" class="form-control" AutoPostBack="false"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldContractType" runat="server" ErrorMessage="Enter Contract Type" ControlToValidate="txtContractType" ForeColor="Red" Font-Bold="false" ValidationGroup="Contract" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <br />
                                                        <div id="addnew1" runat="server">
                                                            <div class="mb-2">
                                                                <asp:Button ID="btnsaveContract" runat="server" Text="Save" CssClass="btn btn-primary  btn-sm" ValidationGroup="Contract" OnClick="btnsaveContract_Click" />
                                                                &nbsp;&nbsp;
                                          <asp:Button ID="btnClearContract" runat="server" Text="Clear" CssClass="btn btn-danger  btn-sm" ValidationGroup="Contract1" OnClick="btnClearContract_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                        <h5>View Contract Type Details</h5>
                                                        <hr />

                                                        <asp:GridView ID="GridContractType" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive table-responsive-md" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable" Style="width: 100%"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="id" OnRowDataBound="GridContractType_RowDataBound"
                                                            OnRowEditing="GridContractType_RowEditing" OnRowUpdating="GridContractType_RowUpdating" OnRowCancelingEdit="GridContractType_RowCancelingEdit" OnRowDeleting="GridContractType_RowDeleting" OnPageIndexChanging="GridContractType_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="id" Visible="false" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblContracttypeID" runat="server" Text='<%# Bind("id") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblContracttypeID1" runat="server" Text='<%# Bind("id") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ContracttypeName" SortExpression="contractype" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtContracttype" runat="server" Text='<%# Bind("contractype") %>' Font-Size="12px" CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcontracttype1" runat="server" Text='<%# Bind("contractype") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreatedBy" SortExpression="Createby" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreateBy" runat="server" Text='<%#Bind("Createby") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreateBy1" runat="server" Text='<%#Bind("Createby") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreatedDate" SortExpression="CreateDate" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreatedDate" runat="server" Text='<%#Bind("CreateDate","{0:dd/MM/yyyy}") %>' Font-Size="12px" Font-Bold="false"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreatedDate1" runat="server" Text='<%#Bind("CreateDate","{0:dd/MM/yyyy}") %>' Font-Size="12px" Font-Bold="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit1" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkUpdate1" runat="server" Text="Update" CssClass="btn btn-sm" CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkCancel1" runat="server" Text="Cancel" CssClass="btn btn-sm" CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete1" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger"><i class="ti ti-trash"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <div align="center" style="color: red">
                                                                    <h6>
                                                                    No records found.</h5>
                                                                </div>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Contract Type --%>
                            </div>


                            <div class="row">
                                <%--Billing Options --%>
                                <div id="DivBillingOptions" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5 class="text-purple">Billing Options</h5>
                                                        <hr />
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblBillingtype" runat="server" Text="BillingType" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtBillingType" runat="server" placeholder="Enter Billing Type" class="form-control" AutoPostBack="false"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredtxtBillingType" runat="server" ErrorMessage="Enter Billing Type" ControlToValidate="txtBillingType" ForeColor="Red" Font-Bold="false" ValidationGroup="BillingType" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="mb-2">
                                                            <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                            <asp:TextBox ID="txtDescription" runat="server" placeholder="Enter Description" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div id="addnew2" runat="server">
                                                        <div class="mb-2">
                                                            <asp:Button ID="btnSaveBillingType" runat="server" Text="Save" CssClass="btn btn-primary btn-sm" ValidationGroup="BillingType" OnClick="btnSaveBillingType_Click" />
                                                            &nbsp;&nbsp;
                                             <asp:Button ID="btnClearBillingType" runat="server" Text="Clear" CssClass="btn btn-danger btn-sm" ValidationGroup="Clear" OnClick="btnClearBillingType_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />

                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5>View Billing Types Details</h5>
                                                        <hr />

                                                        <asp:GridView ID="GridBillingType" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive table-responsive-md" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable" Style="width: 100%"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="Billing_Type_ID"
                                                            OnRowEditing="GridBillingType_RowEditing" OnRowUpdating="GridBillingType_RowUpdating" OnRowCancelingEdit="GridBillingType_RowCancelingEdit" OnRowDeleting="GridBillingType_RowDeleting" OnPageIndexChanging="GridBillingType_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" HeaderStyle-Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="Billing_Type_ID" Visible="false" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblBilling_ID" runat="server" Text='<%# Bind("Billing_Type_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblBilling_ID1" runat="server" Text='<%# Bind("Billing_Type_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="BillingType" SortExpression="BillingType" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtBillingType" runat="server" Text='<%# Bind("Billing_Type") %>' CssClass="form-control" Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblBillingType1" runat="server" Text='<%# Bind("Billing_Type") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>' CssClass="form-control" Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescription1" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreatedBY" SortExpression="CreatedBY" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreateBy" runat="server" Text='<%#Bind("CreatedBY") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreateBy1" runat="server" Text='<%#Bind("CreatedBY") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreatedDate" SortExpression="CreateDate" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreatedDate" runat="server" Text='<%#Bind("CreateDate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreatedDate1" runat="server" Text='<%#Bind("CreateDate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CssClass="btn btn-sm" CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CssClass="btn btn-sm" CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDeleteBilling" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
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
                                <%--Billing Options --%>

                                <%--Discount Options --%>
                                <div id="DivDiscountOptions" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5 class="text-purple">Discount Options</h5>
                                                        <hr />
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblDeicountName" runat="server" Text="Discount Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtDiscount" runat="server" placeholder="Enter Discount Name" class="form-control" AutoPostBack="false"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldDiscount" runat="server" ErrorMessage="Enter Discount Type" ControlToValidate="txtDiscount" ForeColor="Red" Font-Bold="false" ValidationGroup="Discount" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblDisper" runat="server" Text="Percentage" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtDiscper1" runat="server" placeholder="Enter Percentage" class="form-control" AutoPostBack="false" TextMode="Number" MaxLength="2"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredDiscount" runat="server" ErrorMessage="Enter Discount Type" ControlToValidate="txtDiscper1" ForeColor="Red" Font-Bold="false" ValidationGroup="Discount" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="mb-2">
                                                            <asp:Label ID="lblDecription" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                            <asp:TextBox ID="txtdicountDecription" runat="server" placeholder="Enter Description" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div id="addnew3" runat="server">
                                                        <div class="mb-2">
                                                            <asp:Button ID="btnSaveDiscount" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="Discount" OnClick="btnSaveDiscount_Click" />
                                                            &nbsp;&nbsp;
                                         <asp:Button ID="btnClearDiscount" runat="server" Text="Clear" CssClass="btn btn-danger btn-sm" ValidationGroup="Clear" OnClick="btnClearDiscount_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5>View Discount Details</h5>
                                                        <hr />

                                                        <asp:GridView ID="GridViewDiscount" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover  table-responsive" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable" Style="width: 100%"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="DiscID"
                                                            OnRowEditing="GridViewDiscount_RowEditing" OnRowUpdating="GridViewDiscount_RowUpdating" OnRowCancelingEdit="GridViewDiscount_RowCancelingEdit" OnRowDeleting="GridViewDiscount_RowDeleting" OnPageIndexChanging="GridViewDiscount_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="Disc_ID" Visible="false" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblDisc_ID" runat="server" Text='<%# Bind("DiscID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDisc_ID1" runat="server" Text='<%# Bind("DiscID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Discount" SortExpression="DiscName" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDiscName" runat="server" Text='<%# Bind("DiscName") %>' CssClass="form-control" Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbltDiscName" runat="server" Text='<%# Bind("DiscName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Percentage(%)" SortExpression="DiscParsnt" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDiscParsnt" runat="server" Text='<%# Bind("DiscPercentage") %>' CssClass="form-control" Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDiscParsnt" runat="server" Text='<%# Bind("DiscPercentage") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDescriptiondi" runat="server" Text='<%# Bind("Description") %>' CssClass="form-control" TextMode="MultiLine" Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescription1d" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreatedBY" SortExpression="CreatedBY" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreateBy" runat="server" Text='<%#Bind("Createby") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreateBy1" runat="server" Text='<%#Bind("Createby") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreatedDate" SortExpression="CreateDate" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreatedDate" runat="server" Text='<%#Bind("CreateDate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreatedDate1" runat="server" Text='<%#Bind("CreateDate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEditD" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CssClass="btn btn-sm " CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CssClass="btn btn-sm " CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDeleteDisc" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
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

                                <%--Discount Options --%>
                            </div>



                            <div class="row">
                                <%--Expenses Category--%>
                                <div id="DivExpensesCategory" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5 class="text-purple">Expenses Category</h5>
                                                        <hr />
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblCategory" runat="server" Text="Category Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtCategory" runat="server" placeholder="Enter Category Name" class="form-control" AutoPostBack="false"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValiCategory" runat="server" ErrorMessage="Enter Expenses Category Name" ControlToValidate="txtCategory" ForeColor="Red" Font-Bold="false" ValidationGroup="Category" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div id="addnew4" runat="server">
                                                        <div class="mb-2">
                                                            <asp:Button ID="btnSaveCategory" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="Category" OnClick="btnSaveCategory_Click" />
                                                            &nbsp;&nbsp;
                                             <asp:Button ID="btnClearCategory" runat="server" Text="Clear" CssClass="btn btn-danger  btn-sm" ValidationGroup="Cancel3" OnClick="btnClearCategory_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                        <h5>View Expenses Category Details</h5>
                                                        <hr />

                                                        <asp:GridView ID="GridCategory" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive table-responsive-md" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable" Style="width: 100%"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridCategory_RowDataBound"
                                                            OnRowEditing="GridCategory_RowEditing" OnRowUpdating="GridCategory_RowUpdating" OnRowCancelingEdit="GridCategory_RowCancelingEdit" OnRowDeleting="GridCategory_RowDeleting" OnPageIndexChanging="GridCategory_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Category_Name" SortExpression="Category_Name" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtCategory_Name" runat="server" Text='<%# Bind("Category_Name") %>' Font-Size="12px" CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCategory_Name1" runat="server" Text='<%# Bind("Category_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreateBy" SortExpression="CreateBy" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreateBy0" runat="server" Text='<%#Bind("CreateBy") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreateBy1" runat="server" Text='<%#Bind("CreateBy") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Create_Date" SortExpression="Create_Date" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreate_Date0" runat="server" Text='<%#Bind("Create_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreate_Date1" runat="server" Text='<%#Bind("Create_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm  btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CssClass="btn btn-sm " CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CssClass="btn btn-sm " CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger"><i class="ti ti-trash"></i></asp:LinkButton>
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

                                <%--Expenses Category--%>

                                <%--Expenses SubCategory--%>
                                <div id="DivExpensesSubCategory" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5 class="text-purple">Expenses SubCategory</h5>
                                                        <hr />
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblExpCategory1" runat="server" Text="Expenses Category " CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:DropDownList ID="ddlExpCategory2" runat="server" CssClass="form-control form-select">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFielddlExpcategory" runat="server" ErrorMessage="Select Expenses SubCustomer" ControlToValidate="ddlExpCategory2" ForeColor="Red" Font-Bold="false" ValidationGroup="SubCategory" InitialValue="0" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblExpcategory2" runat="server" Text="Expenses SubCategory " CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtSubcategory" runat="server" placeholder="Enter Expenses SubCategory " class="form-control" AutoPostBack="false"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequirdtxtExpcategory3" runat="server" ErrorMessage="Enter Expenses SubCategory Name" ControlToValidate="txtSubcategory" ForeColor="Red" Font-Bold="false" ValidationGroup="SubCategory" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div id="addnew5" runat="server">
                                                        <div class="mb-2">
                                                            <asp:Button ID="btnSaveSubcategory" runat="server" Text="Save" CssClass="btn btn-primary btn-sm" ValidationGroup="SubCategory" OnClick="btnSaveSubcategory_Click" />
                                                            &nbsp;&nbsp;
                                                <asp:Button ID="btnClearSubcategory" runat="server" Text="Clear" CssClass="btn btn-danger btn-sm" ValidationGroup="SubCategoryCancel4" OnClick="btnClearSubcategory_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                        <h5>View Expenses SubCategory Details</h5>
                                                        <hr />

                                                        <asp:GridView ID="GridSubcategory" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive table-responsive-md" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable" Style="width: 100%"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridSubcategory_RowDataBound"
                                                            OnRowEditing="GridSubcategory_RowEditing" OnRowUpdating="GridSubcategory_RowUpdating" OnRowCancelingEdit="GridSubcategory_RowCancelingEdit" OnRowDeleting="GridSubcategory_RowDeleting" OnPageIndexChanging="GridSubcategory_PageIndexChanging">

                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblsubcategoryID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblsubcategoryID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="SubCategory_Name" SortExpression="Sub_Category_Name" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtSubCategory_Name" runat="server" Text='<%# Bind("Sub_Category_Name") %>' Font-Size="12px" CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSubCategory_Name1" runat="server" Text='<%# Bind("Sub_Category_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Expenses_Category_Name" SortExpression="Sub_Category_Name" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList ID="ddlCategoryBind" runat="server" CssClass="form-control"></asp:DropDownList>

                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSubCategory_Name13" runat="server" Text='<%# Bind("Category_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreateBy" SortExpression="CreateBy" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblsubCreateby" runat="server" Text='<%#Bind("Createby") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblsubCreateby1" runat="server" Text='<%#Bind("Createby") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Create_Date" SortExpression="Create_Date" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblsubCreateDate" runat="server" Text='<%#Bind("CreateDate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblsubCreateDate1" runat="server" Text='<%#Bind("CreateDate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CssClass="btn btn-sm " CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CssClass="btn btn-sm " CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger"><i class="ti ti-trash"></i></asp:LinkButton>
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
                                <%--Expenses SubCategory--%>
                            </div>



                            <div class="row">
                                <%--Receipt Initial--%>
                                <div id="DivReceiptInitialDetails" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5 class="text-purple">Receipt Initial Details</h5>
                                                        <hr />
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblReceiptFor" runat="server" Text="ReceiptFor" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtReceiptFor" runat="server" placeholder="Enter Receipt For" class="form-control" AutoPostBack="false"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Enter ReceiptFor Initial" ControlToValidate="txtReceiptFor" ForeColor="Red" Font-Bold="false" ValidationGroup="ReceiptFor" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblInitial" runat="server" Text="Initial" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtInitial" runat="server" placeholder="Enter Initial Details" class="form-control" AutoPostBack="false"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Enter Initial Details" ControlToValidate="txtInitial" ForeColor="Red" Font-Bold="false" ValidationGroup="ReceiptFor" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblSize" runat="server" Text="Size" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtSize" runat="server" placeholder="Enter digit Size" class="form-control" AutoPostBack="false"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Enter receiept Initial Size Details " ControlToValidate="txtSize" ForeColor="Red" Font-Bold="false" ValidationGroup="ReceiptFor" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div id="addnew6" runat="server">
                                                        <div class="mb-2">
                                                            <asp:Button ID="btnsavereciptfor" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="ReceiptFor" OnClick="btnsavereciptfor_Click" />
                                                            &nbsp;&nbsp;
                                              <asp:Button ID="btnclrreciptfor" runat="server" Text="Clear" CssClass="btn btn-danger btn-sm" ValidationGroup="Cancel32" OnClick="btnclrreciptfor_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                        <h5>View Receipt Initial Details</h5>
                                                        <hr />

                                                        <asp:GridView ID="GridViewReceipt" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover  table-responsive" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable" Style="width: 100%"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridViewReceipt_RowDataBound"
                                                            OnRowEditing="GridViewReceipt_RowEditing" OnRowUpdating="GridViewReceipt_RowUpdating" OnRowCancelingEdit="GridViewReceipt_RowCancelingEdit" OnRowDeleting="GridViewReceipt_RowDeleting" OnPageIndexChanging="GridViewReceipt_PageIndexChanging">

                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ReceiptFor" SortExpression="ReceiptFor" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtReceiptFor" runat="server" Text='<%# Bind("ReceiptFor") %>' Font-Size="12px" CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblReceiptFor1" runat="server" Text='<%# Bind("ReceiptFor") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Initial" SortExpression="Initial" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtInitial" runat="server" Text='<%# Bind("Initial") %>' Font-Size="12px" CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblInitial1" runat="server" Text='<%# Bind("Initial") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Size" SortExpression="Size" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtSize" runat="server" Text='<%# Bind("Size") %>' Font-Size="12px" CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSize1" runat="server" Text='<%# Bind("Size") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Createby" SortExpression="Createby" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreateby0" runat="server" Text='<%#Bind("Createby") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreateby1" runat="server" Text='<%#Bind("Createby") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Create_Date" SortExpression="Create_Date" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreate_Date0" runat="server" Text='<%#Bind("Create_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreate_Date1" runat="server" Text='<%#Bind("Create_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CssClass="btn btn-sm " CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CssClass="btn btn-sm " CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger"><i class="ti ti-trash"></i></asp:LinkButton>
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
                                <%--Receipt Initial--%>

                                <%--State--%>
                                <div id="DivAddressStateDetails" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5 class="text-purple">Address State Details</h5>
                                                        <hr />
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblState" runat="server" Text="State" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtState" runat="server" placeholder="Enter State" class="form-control" AutoPostBack="false"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Address State Details " ControlToValidate="txtState" ForeColor="Red" Font-Bold="false" ValidationGroup="State" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div id="addnew7" runat="server">
                                                        <div class="mb-2">
                                                            <asp:Button ID="btnStateSave" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="State" OnClick="btnStateSave_Click" />
                                                            &nbsp;&nbsp;
                                                <asp:Button ID="btnStateclear" runat="server" Text="Clear" CssClass="btn btn-danger btn-sm" ValidationGroup="stateCancel3" OnClick="btnStateclear_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                        <h5>View Address State Details</h5>
                                                        <hr />

                                                        <asp:GridView ID="GridState" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive table-responsive-md" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable" Style="width: 100%"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridState_RowDataBound"
                                                            OnRowEditing="GridState_RowEditing" OnRowUpdating="GridState_RowUpdating" OnRowCancelingEdit="GridState_RowCancelingEdit" OnRowDeleting="GridState_RowDeleting" OnPageIndexChanging="GridState_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="State_Name" SortExpression="State_Name" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtState_Name" runat="server" Text='<%# Bind("State_Name") %>' Font-Size="12px" CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblState_Name1" runat="server" Text='<%# Bind("State_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Createby" SortExpression="Createby" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreateby" runat="server" Text='<%#Bind("Createby") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreateby1" runat="server" Text='<%#Bind("Createby") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Createdate" SortExpression="Createdate" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreatedate" runat="server" Text='<%#Bind("Createdate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreatedate1" runat="server" Text='<%#Bind("Createdate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update" CssClass="btn btn-sm " TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="Cancel" CssClass="btn btn-sm " TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger"><i class="ti ti-trash"></i></asp:LinkButton>
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
                                <%--State--%>
                            </div>

                            <div class="row">
                                <div id="DivAddressDistrictDetails" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5 class="text-purple">Address District Details</h5>
                                                        <hr />
                                                        <div class="mb-2">
                                                            <asp:Label ID="lbldisstate" runat="server" Text="State" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:DropDownList ID="ddlStatename" runat="server" CssClass="form-control form-select">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Select State Name" ControlToValidate="ddlStatename" ForeColor="Red" Font-Bold="false" ValidationGroup="city" InitialValue="0" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="mb-2">
                                                            <asp:Label ID="lbldistrict" runat="server" Text="Address District " CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtdistrict1" runat="server" placeholder="Enter Address District " class="form-control" AutoPostBack="false"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Address District Name" ControlToValidate="txtdistrict1" ForeColor="Red" Font-Bold="false" ValidationGroup="District" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div id="addnew8" runat="server">
                                                        <div class="mb-2">
                                                            <asp:Button ID="btnsavedistrict" runat="server" Text="Save" CssClass="btn btn-primary btn-sm" ValidationGroup="District" OnClick="btnsavedistrict_Click" />
                                                            &nbsp;&nbsp;
                                           <asp:Button ID="btndistrictclear" runat="server" Text="Clear" CssClass="btn btn-danger btn-sm" ValidationGroup="DistrictCancel4" OnClick="btndistrictclear_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                        <h5>View Address District Details</h5>
                                                        <hr />

                                                        <asp:GridView ID="GridDistrict" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive table-responsive-md" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable" Style="width: 100%"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="District_ID" OnRowDataBound="GridDistrict_RowDataBound"
                                                            OnRowEditing="GridDistrict_RowEditing" OnRowUpdating="GridDistrict_RowUpdating" OnRowCancelingEdit="GridDistrict_RowCancelingEdit" OnRowDeleting="GridDistrict_RowDeleting" OnPageIndexChanging="GridDistrict_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="District_ID" Visible="false" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblDistrict_ID" runat="server" Text='<%# Bind("District_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDistrict_ID1" runat="server" Text='<%# Bind("District_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Disttrict" SortExpression="Disttrict_Name" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDisttrict_Name" runat="server" Text='<%# Bind("Disttrict_Name") %>' Font-Size="12px" CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDisttrict_Name1" runat="server" Text='<%# Bind("Disttrict_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="State_Name" SortExpression="State_Name" ControlStyle-Width="100px" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList ID="ddlStateBind" runat="server" CssClass="form-control"></asp:DropDownList>

                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblState_Name13" runat="server" Text='<%# Bind("State_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Created_by" SortExpression="created_by" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblcreated_by" runat="server" Text='<%#Bind("created_by") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcreated_by1" runat="server" Text='<%#Bind("created_by") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Create_date" SortExpression="Create_date" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreate_date" runat="server" Text='<%#Bind("Create_date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreate_date1" runat="server" Text='<%#Bind("Create_date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CssClass="btn btn-sm " CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CssClass="btn btn-sm " CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger"><i class="ti ti-trash"></i></asp:LinkButton>
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
                                <div id="DivAddressCityTalukaDetails" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5 class="text-purple">Address City/Taluka Details</h5>
                                                        <hr />
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblState1" runat="server" Text="State" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:DropDownList ID="ddlState1" runat="server" CssClass="form-control form-select" OnSelectedIndexChanged="ddlState1_SelectedIndexChanged" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Address State" ControlToValidate="ddlState1" ForeColor="Red" Font-Bold="false" ValidationGroup="SaveCity" InitialValue="0" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="mb-2">
                                                            <asp:Label ID="lbldistrict1" runat="server" Text="District" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:DropDownList ID="ddldistrict1" runat="server" CssClass="form-control form-select">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Select State Name" ControlToValidate="ddldistrict1" ForeColor="Red" Font-Bold="false" ValidationGroup="SaveCity" InitialValue="0" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblCity" runat="server" Text="City" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtcity" runat="server" placeholder="Enter Address City " class="form-control" AutoPostBack="false"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter Address District Name" ControlToValidate="txtcity" ForeColor="Red" Font-Bold="false" ValidationGroup="SaveCity" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div id="addnew9" runat="server">
                                                        <div class="mb-2">
                                                            <asp:Button ID="btnsavecity" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="SaveCity" OnClick="btnsavecity_Click" />
                                                            &nbsp;&nbsp;
                            <asp:Button ID="btnclearcity" runat="server" Text="Clear" CssClass="btn btn-danger  btn-sm" ValidationGroup="cancelcity" OnClick="btnclearcity_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                        <h5>View Address city Details</h5>
                                                        <hr />

                                                        <asp:GridView ID="GridCity1" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive table-responsive-md" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable" Style="width: 100%"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridCity1_RowDataBound"
                                                            OnRowEditing="GridCity1_RowEditing" OnRowUpdating="GridCity1_RowUpdating" OnRowCancelingEdit="GridCity1_RowCancelingEdit" OnRowDeleting="GridCity1_RowDeleting" OnPageIndexChanging="GridCity1_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        <asp:LinkButton ID="linkID1" runat="server" Visible="false" Text='<%# Bind("ID") %>'></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Taluka/City" SortExpression="City" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtCity" runat="server" Text='<%# Bind("City") %>' Font-Size="12px" CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCity" runat="server" Text='<%# Bind("City") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="State_Name" SortExpression="State_Name" ControlStyle-Width="120px" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList ID="ddlStateBind" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlStateBind_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblState_Name13" runat="server" Text='<%# Bind("State_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Disttrict_Name" SortExpression="Disttrict_Name" ControlStyle-Width="120px" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList ID="ddldistrictBind" runat="server" CssClass="form-control"></asp:DropDownList>

                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDisttrict_Name13" runat="server" Text='<%# Bind("Disttrict_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="created_by" SortExpression="created_by" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblcreated_by0" runat="server" Text='<%#Bind("created_by") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcreated_by1" runat="server" Text='<%#Bind("created_by") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Create_date" SortExpression="Create_date" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreate_date0" runat="server" Text='<%#Bind("Create_date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreate_date1" runat="server" Text='<%#Bind("Create_date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CssClass="btn btn-sm" CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CssClass="btn btn-sm" CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger"><i class="ti ti-trash"></i></asp:LinkButton>
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


                            <div class="row">
                                <div id="DivTaxDetails" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5 class="text-purple">Tax Details</h5>
                                                        <hr />
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblTax_Name1" runat="server" Text="Tax Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtTax_Name" runat="server" placeholder="Enter Tax Name" CssClass="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredtxtTaxname" runat="server" ErrorMessage="Enter Tax Name" ControlToValidate="txtTax_Name" ForeColor="Red" Font-Bold="false" ValidationGroup="TaxName" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="mb-2">
                                                            <asp:Label ID="lblTax_Value1" runat="server" Text="Tax Rate (percent)" CssClass="form-label"></asp:Label>
                                                            <asp:TextBox ID="txtTax_Value" runat="server" placeholder="0.00" CssClass="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter Tax Percent" ControlToValidate="txtTax_Value" ForeColor="Red" Font-Bold="false" ValidationGroup="TaxName" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div id="addnew10" runat="server">
                                                        <div class="mb-2">
                                                            <asp:Button ID="btnSaveTax" runat="server" Text="Save" CssClass="btn btn-primary btn-sm" ValidationGroup="TaxName" OnClick="btnSaveTax_Click" />
                                                            &nbsp;&nbsp;
                                                <asp:Button ID="btnTaxClear" runat="server" Text="Clear" CssClass="btn btn-danger btn-sm" ValidationGroup="Clear" OnClick="btnTaxClear_Click" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5>View Tax Details</h5>
                                                        <hr />

                                                        <asp:GridView ID="GridViewTaxDetails" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive table-responsive-md" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable" Style="width: 100%"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="Tax_Id"
                                                            OnRowDeleting="GridViewTaxDetails_RowDeleting" OnRowEditing="GridViewTaxDetails_RowEditing" OnRowUpdating="GridViewTaxDetails_RowUpdating" OnRowCancelingEdit="GridViewTaxDetails_RowCancelingEdit">

                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="Tax_Id" Visible="false" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblTax_Id" runat="server" Text='<%# Bind("Tax_Id") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTax_Id1" runat="server" Text='<%# Bind("Tax_Id") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Tax_Name" SortExpression="Tax_Name" HeaderStyle-Width="60px" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtTax_Name" runat="server" Text='<%# Bind("Tax_Name") %>' CssClass="form-control" Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTax_Name1" runat="server" Text='<%# Bind("Tax_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Rate(%)" SortExpression="Tax_Rate" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtTax_Value" runat="server" Text='<%# Bind("Tax_Rate") %>' CssClass="form-control" Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTax_Value1" runat="server" Text='<%# Bind("Tax_Rate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreateBy" SortExpression="CreatedBY" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreateBy" runat="server" Text='<%#Bind("CreateBy") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreateBy1" runat="server" Text='<%#Bind("CreateBy") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Created Date" SortExpression="Tax_CreateDate" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblTax_CreateDate" runat="server" Text='<%#Bind("Tax_CreateDate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTax_CreateDate1" runat="server" Text='<%#Bind("Tax_CreateDate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update" CssClass="btn btn-sm" TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="Cancel" CssClass="btn btn-sm" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDeletePagename" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
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

                                <div id="DivTenderCategoryDetails" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5 class="text-purple">Tender Category Details</h5>
                                                        <hr />
                                                        <div class="mb-2">
                                                            <asp:Label ID="LabelTenderCategory" runat="server" Text="Tender Category Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtTenderCategory" runat="server" placeholder="Enter Category Name" class="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredddlCategory" runat="server" ErrorMessage="Enter Tender Category Name" ControlToValidate="txtTenderCategory" ForeColor="Red" Font-Bold="false" ValidationGroup="TEDCategory" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="mb-2">
                                                            <asp:Label ID="lbldesc" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                            <asp:TextBox ID="txtdesc" runat="server" placeholder="Enter Description" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div id="addnew11" runat="server">
                                                        <div class="mb-2">
                                                            <asp:Button ID="Btn_Saveted" runat="server" Text="Save" CssClass="btn btn-primary btn-sm" ValidationGroup="TEDCategory" OnClick="Btn_Saveted_Click" />
                                                            &nbsp;&nbsp;
                                    <asp:Button ID="Btn_Clearted" runat="server" Text="Clear" CssClass="btn btn-danger  btn-sm" ValidationGroup="TedClear" OnClick="Btn_Clearted_Click" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5>View Tender Category Details</h5>
                                                        <hr />
                                                        <asp:GridView ID="GridTenderCategory" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable" Style="width: 100%"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID"
                                                            OnRowDeleting="GridTenderCategory_RowDeleting" OnRowEditing="GridTenderCategory_RowEditing" OnRowUpdating="GridTenderCategory_RowUpdating" OnRowCancelingEdit="GridTenderCategory_RowCancelingEdit">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCategoryID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCategoryID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Tender Category" SortExpression="CategoryName" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtCategoryName" runat="server" Text='<%# Bind("CategoryName") %>' CssClass="form-control" Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCategoryName" runat="server" Text='<%# Bind("CategoryName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>' Font-Size="12px" CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update" CssClass="btn btn-sm" TabIndex="18" Font-Size="12px"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="Cancel" CssClass="btn btn-sm" TabIndex="19" Font-Size="12px"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDeletePagename" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" Font-Size="12px" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
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


                            <div class="row">
                                <%--Web Pages Options--%>
                                <div id="DivPagesOptions" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5 class="text-purple">Pages Options</h5>
                                                        <hr />
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblPagename" runat="server" Text="Page Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtPagename" runat="server" placeholder="Enter Webpage Name" class="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredtxtPagename" runat="server" ErrorMessage="Enter Webpage Name" ControlToValidate="txtPagename" ForeColor="Red" Font-Bold="false" ValidationGroup="Pagename" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblDescrip" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                            <asp:TextBox ID="txtDescripwebpage" runat="server" placeholder="Enter Description" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblModule" runat="server" Text="Module Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtModule" runat="server" placeholder="Enter Module Name" class="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Enter Module Name" ControlToValidate="txtModule" ForeColor="Red" Font-Bold="false" ValidationGroup="Pagename" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblSubModule" runat="server" Text="Sub Module Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtSubModule" runat="server" placeholder="Enter Sub Module Name" class="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredtxtSubModule" runat="server" ErrorMessage="Enter Sub Module Name" ControlToValidate="txtSubModule" ForeColor="Red" Font-Bold="false" ValidationGroup="Pagename" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblDesignpage" runat="server" Text="Design" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtDesignpage" runat="server" placeholder="Enter Design" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Enter Pages Design" ControlToValidate="txtDesignpage" ForeColor="Red" Font-Bold="false" ValidationGroup="Pagename" Font-Size="12px"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div id="addnew12" runat="server">
                                                    <div class="row">
                                                        <div class="mb-2">
                                                            <asp:Button ID="btnSavePagename" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="Pagename" OnClick="btnSavePagename_Click" />
                                                            &nbsp;&nbsp;
                                                     <asp:Button ID="btnSavePagesClear" runat="server" Text="Clear" CssClass="btn btn-danger btn-sm" ValidationGroup="ClearPagename" OnClick="btnSavePagesClear_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5>View PageName</h5>
                                                        <hr />
                                                        <asp:GridView ID="GridViewPageName" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable" Style="width: 100%"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID"
                                                            OnRowDeleting="GridViewPageName_RowDeleting" OnRowEditing="GridViewPageName_RowEditing" OnRowUpdating="GridViewPageName_RowUpdating" OnRowCancelingEdit="GridViewPageName_RowCancelingEdit">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblPage_ID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPage_ID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="PageName" SortExpression="PageName" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtPageName" runat="server" Text='<%# Bind("WebPageName") %>' CssClass="form-control" Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPageName1" runat="server" Text='<%# Bind("WebPageName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Module" SortExpression="Module" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtModule1" runat="server" Text='<%# Bind("Module") %>' CssClass="form-control" Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblModule1" runat="server" Text='<%# Bind("Module") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="SubModule" SortExpression="SubModule" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtSubModule" runat="server" Text='<%# Bind("SubModule") %>' CssClass="form-control" Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSubModule1" runat="server" Text='<%# Bind("SubModule") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Design" SortExpression="Design" HeaderStyle-Width="350px" ItemStyle-Width="350px" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDesign1" runat="server" Text='<%# Bind("Design") %>' TextMode="MultiLine" CssClass="form-control" Font-Size="12px" Width="200px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDesign1" runat="server" Text='<%# Bind("Design") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDescription1" runat="server" Text='<%# Bind("Description") %>' CssClass="form-control" Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescrip1" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreatedBY" SortExpression="CreatedBY" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreateby" runat="server" Text='<%#Bind("Createdby") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreateby1" runat="server" Text='<%#Bind("Createdby") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Created Date" SortExpression="CreateDate" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreateddate" runat="server" Text='<%#Bind("Createdate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreateddate1" runat="server" Text='<%#Bind("Createdate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info  "><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CssClass="btn btn-sm" CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CssClass="btn btn-sm" CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDeletePagename" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
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

                            <div class="row">
                                <div id="DivDepartmentDetails" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5 class="text-purple">Department Details</h5>
                                                        <hr />
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblDepartmentName" runat="server" Text="Department" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtDepartmentName" runat="server" placeholder="Enter Department" class="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequireDepartmentName" runat="server" ErrorMessage="Enter Department" ControlToValidate="txtDepartmentName" ForeColor="Red" Font-Bold="false" ValidationGroup="Department" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="mb-2">
                                                            <asp:Label ID="lblDepartDescription" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                            <asp:TextBox ID="txtDepartDescription" runat="server" placeholder="Enter Description" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div id="addnew13" runat="server">
                                                        <div class="mb-2">
                                                            <asp:Button ID="Btn_SaveDepart" runat="server" Text="Save" CssClass="btn btn-primary btn-sm" ValidationGroup="Department" OnClick="Btn_SaveDepart_Click" />
                                                            &nbsp;&nbsp;
               
                                    <asp:Button ID="Btn_ClearDepart" runat="server" Text="Clear" CssClass="btn btn-danger btn-sm" ValidationGroup="ClearDepartment" OnClick="Btn_ClearDepart_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />

                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5 class="font-weight-medium mb-0">View Department Details</h5>
                                                        <hr />
                                                        <asp:GridView ID="GridDepartment" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable" Style="width: 100%"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="Dept_ID"
                                                            OnRowDeleting="GridDepartment_RowDeleting" OnRowEditing="GridDepartment_RowEditing" OnRowUpdating="GridDepartment_RowUpdating" OnRowCancelingEdit="GridDepartment_RowCancelingEdit">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="Dept_ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblDepartmentID" runat="server" Text='<%# Bind("Dept_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDepartmentID1" runat="server" Text='<%# Bind("Dept_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Department" SortExpression="Dept_Name" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDepartmentName" runat="server" Text='<%# Bind("Dept_Name") %>' CssClass="form-control" Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDepartmentName" runat="server" Text='<%# Bind("Dept_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>' Font-Size="12px" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CssClass="btn btn-sm" CommandName="Update" TabIndex="18" Font-Size="12px"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CssClass="btn btn-sm" CommandName="Cancel" TabIndex="19" Font-Size="12px"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDeletePagename" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" Font-Size="12px" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
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
                                <div id="DivMeasurementProductDetails" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5 class="text-purple">Measurement Product Details</h5>
                                                        <hr />
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblMeasurement" runat="server" Text="Measurement" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtMeasurement" runat="server" placeholder="Enter Measurement" class="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Enter Measurement" ControlToValidate="txtMeasurement" ForeColor="Red" Font-Bold="false" ValidationGroup="Measurement" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="mb-2">
                                                            <asp:Label ID="lblUnit" runat="server" Text="Unit" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtUnit" runat="server" placeholder="Enter Unit" class="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Enter Unit" ControlToValidate="txtMeasurement" ForeColor="Red" Font-Bold="false" ValidationGroup="Measurement" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="mb-2">
                                                            <asp:Label ID="lblAbbreviations" runat="server" Text="Abbreviations" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtAbbreviations" runat="server" placeholder="Enter Abbreviations" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Enter Abbreviations" ControlToValidate="txtAbbreviations" ForeColor="Red" Font-Bold="false" ValidationGroup="Measurement" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="mb-2">
                                                            <asp:Label ID="Label1" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                            <asp:TextBox ID="TextBox1" runat="server" placeholder="Enter Description" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                        </div>

                                                    </div>
                                                    <br />
                                                    <div id="addnewMeasurement" runat="server">
                                                        <div class="mb-2">
                                                            <asp:Button ID="btnSaveMeasurement" runat="server" Text="Save" CssClass="btn btn-primary btn-sm" ValidationGroup="Measurement" OnClick="btnSaveMeasurement_Click" />
                                                            &nbsp;&nbsp;
               
                                          <asp:Button ID="btnClearMeasurement" runat="server" Text="Clear" CssClass="btn btn-danger btn-sm" ValidationGroup="Clear" OnClick="btnClearMeasurement_Click" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <br />
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5>View Measurement Product Details</h5>
                                                        <hr />
                                                        <asp:GridView ID="GridMeasurmentProd" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable" Style="width: 100%"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID"
                                                            OnRowDeleting="GridMeasurmentProd_RowDeleting" OnRowEditing="GridMeasurmentProd_RowEditing" OnRowUpdating="GridMeasurmentProd_RowUpdating" OnRowCancelingEdit="GridMeasurmentProd_RowCancelingEdit">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="true">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblMeasurmentID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMeasurmentID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Measurement" SortExpression="Measurement" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtMeasurement" runat="server" Text='<%# Bind("Measurement") %>' CssClass="form-control" Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMeasurement" runat="server" Text='<%# Bind("Measurement") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Unit" SortExpression="Unit" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtUnit" runat="server" Text='<%# Bind("Unit") %>' Font-Size="12px" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("Unit") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Abbreviations" SortExpression="Abbreviations" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtAbbreviations" runat="server" Text='<%# Bind("Abbreviations") %>' Font-Size="12px" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAbbreviations" runat="server" Text='<%# Bind("Abbreviations") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>' Font-Size="12px" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update" CssClass="btn btn-sm" TabIndex="18" Font-Size="12px"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="Cancel" CssClass="btn btn-sm" TabIndex="19" Font-Size="12px"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDeletePagename" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" Font-Size="12px" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
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

                            <div class="row">
                                <%-- Product Storage Type --%>
                                <div id="DivProductStorageType" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h6 class="text-purple">Product Storage Type</h6>
                                                        <hr />
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblproducttype" runat="server" Text="Storage Type" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtproductcategory" runat="server" placeholder="Enter Product Storage Type" class="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="Enter Storage Type" ControlToValidate="txtproductcategory" ForeColor="Red" Font-Bold="false" ValidationGroup="StorageCategory" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="mb-2">
                                                            <asp:Label ID="lblproductdesc" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                            <asp:TextBox ID="txtproductdesc" runat="server" placeholder="Enter Description" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div id="addStorage" runat="server">
                                                        <div class="mb-2">
                                                            <asp:Button ID="btn_saveStorageType" runat="server" Text="Save" CssClass="btn btn-sm btn-info" ValidationGroup="StorageCategory" OnClick="btn_saveStorageType_Click" />
                                                            &nbsp;&nbsp;
                                                           <asp:Button ID="Btn_ClearStorageType" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="Clear" OnClick="Btn_ClearStorageType_Click" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h6>View Product Storage Type</h6>
                                                        <hr />
                                                        <asp:GridView ID="GridViewProductType" runat="server" ScrollBars="Both" CssClass="table table-responsive table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID"
                                                            OnRowDeleting="GridViewProductType_RowDeleting" OnRowEditing="GridViewProductType_RowEditing" OnRowUpdating="GridViewProductType_RowUpdating" OnRowCancelingEdit="GridViewProductType_RowCancelingEdit">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblProduct_ID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblProduct_ID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="PageName" SortExpression="PageName" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtProductCategory" runat="server" Text='<%# Bind("ProductCategory") %>' CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblProductCategory" runat="server" Text='<%# Bind("ProductCategory") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDescrip" runat="server" Text='<%# Bind("Description") %>' CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescrip1" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreatedBY" SortExpression="CreatedBY" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreateby" runat="server" Text='<%#Bind("CreateBy") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreateby1" runat="server" Text='<%#Bind("CreateBy") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
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

                                <div id="DIVPOLICY" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h6 style="color: blue">Policy Options</h6>
                                                        <hr />
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblPolicyName" runat="server" Text="Policy Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtPolicyName" runat="server" placeholder="Enter Policy Name" class="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="Enter Policy Name" ControlToValidate="txtPolicyName" ForeColor="Red" Font-Bold="false" ValidationGroup="Policy" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="mb-2">
                                                            <asp:Label ID="Label2" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                            <asp:TextBox ID="txtPolicyDescrip" runat="server" placeholder="Enter Description" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div id="addPolicy" runat="server">
                                                        <div class="mb-2">
                                                            <asp:Button ID="btnSavePolicy" runat="server" Text="Save" CssClass="btn btn-sm btn-info" ValidationGroup="Policy" OnClick="btnSavePolicy_Click" />
                                                            &nbsp;&nbsp;
                                                       <asp:Button ID="btnPolicyClear" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="Clear" OnClick="btnPolicyClear_Click1" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5>View Policy</h5>
                                                        <hr />
                                                        <asp:GridView ID="GridViewPolicy" runat="server" ScrollBars="Both" CssClass="table table-responsive table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID"
                                                            OnRowDeleting="GridViewPolicy_RowDeleting" OnRowEditing="GridViewPolicy_RowEditing" OnRowUpdating="GridViewPolicy_RowUpdating" OnRowCancelingEdit="GridViewPolicy_RowCancelingEdit">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblPolicy_ID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPolicy_ID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="PolicyName" SortExpression="PageName" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtPolicyName" runat="server" Text='<%# Bind("PolicyName") %>' Font-Size="12px" CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPolicyName1" runat="server" Text='<%# Bind("PolicyName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtPolicyDescription" runat="server" Text='<%# Bind("Description") %>' Font-Size="12px" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPolicyDescrip1" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="AddedBy" SortExpression="CreatedBY" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblPolicyCreateby" runat="server" Text='<%#Bind("CreateBy") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPolicyCreateby1" runat="server" Text='<%#Bind("CreateBy") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Create Date" SortExpression="CreateDate" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreateddate" runat="server" Text='<%#Bind("Create_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreateddate1" runat="server" Text='<%#Bind("Create_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Status" SortExpression="PageName" Visible="false" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblPolicyStatus" runat="server" Text='<%#Bind("status") %>' Font-Bold="false" Visible="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPolicyStatus1" runat="server" Text='<%# Bind("status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnPolicyEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkPolicyUpdate" runat="server" Text="Update" CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkPolicyCancel" runat="server" Text="Cancel" CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnPolicyDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
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

                            <div class="row">
                                <div id="DivShift" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h6 class="text-purple">Shift Details</h6>
                                                        <hr />
                                                        <br />
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblShiftName" runat="server" Text="Shift Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtShiftName1" runat="server" placeholder="Enter Shift Name" class=" form-control"></asp:TextBox>

                                                            <asp:RequiredFieldValidator ID="reqShiftName" runat="server" ErrorMessage="Enter Shift Name" ControlToValidate="txtShiftName1" ForeColor="Red" Font-Bold="false" ValidationGroup="Shifts" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>


                                                        <div class="mb-2">
                                                            <asp:Label ID="lblShiftHour" runat="server" Text="Hour" Type="Number" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtShiftHour1" runat="server" placeholder="Enter Hour" class=" form-control" TextMode="MultiLine"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="reqshiftHour" runat="server" ErrorMessage="Enter Hour" ControlToValidate="txtShiftHour1" ForeColor="Red" Font-Bold="false" ValidationGroup="Shifts" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>

                                                    </div>
                                                    <br />
                                                    <div id="addshift" runat="server">
                                                        <div class="mb-2">
                                                            <asp:Button ID="Btn_SaveShift" runat="server" Text="Save" CssClass="btn btn-sm btn-info" ValidationGroup="Shifts" OnClick="Btn_SaveShift_Click" />
                                                            &nbsp;&nbsp;
             
                      <asp:Button ID="Btn_ClearShift" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="Clear" OnClick="Btn_ClearShift_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">

                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h6>View Shifts</h6>
                                                        <hr />
                                                        <asp:GridView ID="GridViewShift" runat="server" ScrollBars="Both" CssClass="table table-responsive table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID"
                                                            OnRowDeleting="GridViewShift_RowDeleting" OnRowEditing="GridViewShift_RowEditing" OnRowUpdating="GridViewShift_RowUpdating" OnRowCancelingEdit="GridViewShift_RowCancelingEdit">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblShiftID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblShift_ID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ShiftName" SortExpression="ShiftName" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtShiftName" runat="server" class=" form-control" Text='<%# Bind("ShiftName") %>' Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblShiftName" runat="server" Text='<%# Bind("ShiftName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Hours" SortExpression="Hours" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtHours" runat="server" class=" form-control" Text='<%# Bind("Hours") %>' Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblHours" runat="server" Text='<%# Bind("Hours") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreateBy" SortExpression="CreateBy" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblShiftCreateby" runat="server" Text='<%#Bind("CreateBy") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblShiftCreateby1" runat="server" Text='<%#Bind("CreateBy") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreateDate" SortExpression="Create_Date" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblShiftyCreateddate" runat="server" Text='<%#Bind("CreateDate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblShiftCreateddate1" runat="server" Text='<%#Bind("CreateDate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Status" SortExpression="status" Visible="false" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblShiftStatus" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false" Visible="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblShiftStatus1" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnShiftEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkShiftUpdate" runat="server" Text="Update" CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkShiftCancel" runat="server" Text="Cancel" CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnShiftDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
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

                                <div id="DIVParticular" runat="server" visible="false">
                                    <%--Salary Component--%>
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-md-12 col-sm-12 col-lg-12">
                                                    <h6 class="text-purple">Salary Component/Perticulars</h6>
                                                    <hr />

                                                    <div class="mb-2">
                                                        <asp:Label ID="lblPerticulars" runat="server" Text="Perticulars" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                        <asp:TextBox ID="txtPerticular1" runat="server" placeholder="Enter Perticulars" class=" form-control"></asp:TextBox>

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="Enter Shift Name" ControlToValidate="txtPerticular1" ForeColor="Red" Font-Bold="false" ValidationGroup="SalaryComponent" Font-Size="12px"></asp:RequiredFieldValidator>
                                                    </div>

                                                    <div class="mb-2">
                                                        <asp:Label ID="lblPercentage" runat="server" Text="Percentage" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                        <asp:TextBox ID="txtPercentage1" runat="server" TextMode="Number" placeholder="Enter Percentage" class="required form-control"></asp:TextBox>

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="Enter Percentage Name" ControlToValidate="txtPercentage1" ForeColor="Red" Font-Bold="false" ValidationGroup="SalaryComponent" Font-Size="12px"></asp:RequiredFieldValidator>
                                                    </div>

                                                    <div class="mb-2">
                                                        <asp:Label ID="lblPerticularType" runat="server" Text="PerticularType" CssClass="form-label"></asp:Label>
                                                        <asp:DropDownList ID="ddlPerticularType1" runat="server" class=" form-control">
                                                            <asp:ListItem Text="Select an option" Value="" />
                                                            <asp:ListItem Text="Addition" Value="1" />
                                                            <asp:ListItem Text="Dedution" Value="2" />
                                                        </asp:DropDownList>

                                                    </div>

                                                    <div class="mb-2">
                                                        <asp:Label ID="lblDescriptionParticular" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                        <asp:TextBox ID="txtDescriptionParticular1" runat="server" TextMode="MultiLine" placeholder="Enter Descriptions" class=" form-control"></asp:TextBox>

                                                    </div>

                                                </div>
                                                <br />
                                                <div id="addparticular" runat="server">
                                                    <div class="mb-2">
                                                        <asp:Button ID="btnSaveParticular" runat="server" Text="Save" CssClass="btn btn-sm btn-info" ValidationGroup="SalaryComponent" OnClick="btnSaveParticular_Click" />
                                                        &nbsp;&nbsp;
        
                                   <asp:Button ID="btnClearParticular" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="Clear" OnClick="btnClearParticular_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12 col-sm-12 col-lg-12">
                                                    <h6 class="text-purple">View Salary Component</h6>
                                                    <hr />
                                                    <asp:GridView ID="GridPerticular" runat="server" ScrollBars="Both" CssClass="table table-responsive table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable"
                                                        EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID"
                                                        OnRowDeleting="GridPerticular_RowDeleting" OnRowEditing="GridPerticular_RowEditing" OnRowUpdating="GridPerticular_RowUpdating" OnRowCancelingEdit="GridPerticular_RowCancelingEdit">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false" HeaderStyle-Font-Size="12px">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblPerticulars_ID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPerticulars_ID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Perticulars" SortExpression="Perticular" HeaderStyle-Font-Size="12px">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtPerticular" runat="server" class=" form-control" Text='<%# Bind("Perticular") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPerticular" runat="server" Text='<%# Bind("Perticular") %>' TabIndex="6" Font-Bold="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PerticularType" SortExpression="PerticularType" HeaderStyle-Font-Size="12px">
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="ddlPerticularType" runat="server" class=" form-control">
                                                                        <asp:ListItem Text="Select an option" Value="" />
                                                                        <asp:ListItem Text="Addition" Value="1" />
                                                                        <asp:ListItem Text="Dedution" Value="2" />
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPerticularType" runat="server" Text='<%# Bind("PerticularType") %>' TabIndex="6" Font-Bold="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Percentage" SortExpression="Percentage" HeaderStyle-Font-Size="12px">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtPercentage" class="required form-control" runat="server" Text='<%# Bind("Percentage") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPercentage" runat="server" Text='<%# Bind("Percentage") %>' TabIndex="6" Font-Bold="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Font-Size="12px">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtDescriptionPerticular" class=" form-control" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDescriptionPerticular" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                </EditItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
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

                            <div class="row">
                                <div id="DIVHoliday" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h6 class="text-purple">Holiday Name</h6>
                                                        <hr />

                                                        <div class="mb-2">
                                                            <asp:Label ID="lblHolidayNm" runat="server" Text="Holiday Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtHolidayNm" runat="server" placeholder="Enter Holiday Name" class="required form-control"></asp:TextBox>

                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="Enter Holiday Name" ControlToValidate="txtHolidayNm" ForeColor="Red" Font-Bold="false" ValidationGroup="Holidayname"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="mb-2">
                                                            <div class="row">

                                                                <div class="col-md-6 col-sm-6 col-lg-6">
                                                                    <asp:Label ID="lblStartdate" Text="StartDate" runat="server" CssClass="form-label"></asp:Label>
                                                                    <asp:TextBox ID="txtStartDate" type="date" CssClass="form-control" runat="server" placeholder="StartDate(mm/dd/yyyy)"></asp:TextBox>

                                                                </div>
                                                                <div class="col-md-6 col-sm-6 col-lg-6">
                                                                    <asp:Label ID="lblEndDate" Text="EndDate" runat="server" CssClass="form-label"></asp:Label>
                                                                    <asp:TextBox ID="txtEndDate" type="date" CssClass="form-control" runat="server" placeholder="EndDate(mm/dd/yyyy)"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="mb-2">
                                                            <asp:Label ID="Label3" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                            <asp:TextBox ID="txtDescriptionH" runat="server" placeholder="Enter Description" class="required form-control" TextMode="MultiLine"></asp:TextBox>
                                                        </div>

                                                    </div>
                                                    <br />
                                                    <div id="addHoliday" runat="server">
                                                        <div class="mb-2">
                                                            <asp:Button ID="btnSaveHoliday" runat="server" Text="Save" CssClass="btn btn-sm btn-info" ValidationGroup="Holidayname" OnClick="btnSaveHoliday_Click" />
                                                            &nbsp;&nbsp;
                           
                                    <asp:Button ID="btnClearHoliday" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="ClearJ" OnClick="btnClearHoliday_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <hr />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h6>View Holiday</h6>
                                                        <div class="row">
                                                            <div class="col-md-2">
                                                                <div class="bd-example">
                                                                    <div class="btn-group">
                                                                        <button class="btn btn-sm btn-success  dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                                                        <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                                                        <div class="dropdown-menu">
                                                                            <asp:LinkButton ID="lnkbtnExcelHoliday" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="lnkbtnExcelHoliday_Click"></asp:LinkButton>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <asp:GridView ID="GridHoliday" runat="server" ScrollBars="Both" CssClass="table table-responsive table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID"
                                                            OnRowDeleting="GridHoliday_RowDeleting" OnRowEditing="GridHoliday_RowEditing" OnRowUpdating="GridHoliday_RowUpdating" OnRowCancelingEdit="GridHoliday_RowCancelingEdit">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblHoliday_ID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblHoliday_ID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="HolidayName" SortExpression="HolidayName" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtHolidayName" runat="server" Text='<%# Bind("HolidayName") %>' CssClass="form-control" Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblHolidayName1" runat="server" Text='<%# Bind("HolidayName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtHolidayDescription" runat="server" Text='<%# Bind("Description") %>' CssClass="form-control" Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblHolidayDescrip1" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="StartDate" SortExpression="StartDate" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblHolidayStartDate" runat="server" Text='<%#Bind("StartDate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblHolidayStartDate1" runat="server" Text='<%#Bind("StartDate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="EndDate" SortExpression="EndDate" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblHolidayEndDate" runat="server" Text='<%#Bind("EndDate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblHolidayEndDate1" runat="server" Text='<%#Bind("EndDate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="AddedBy" SortExpression="CreateBy" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblHolidayCreateby" runat="server" Text='<%#Bind("CreateBy") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblHolidayCreateby1" runat="server" Text='<%#Bind("CreateBy") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreateDate" SortExpression="Create_Date" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblHolidayCreateddate" runat="server" Text='<%#Bind("Create_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblHolidayCreateddate1" runat="server" Text='<%#Bind("Create_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Status" SortExpression="status" Visible="false" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblHolidayStatus" runat="server" Text='<%#Bind("status") %>' Font-Bold="false" Visible="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblHolidayStatus1" runat="server" Text='<%# Bind("status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnHolidayEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkHolidayUpdate" runat="server" Text="Update" CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkHolidayCancel" runat="server" Text="Cancel" CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnHolidayDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
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

                                <%-- LeaveMark --%>
                                <div id="DIVLeaveMark" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h6 class="text-purple">HRMS Leave Marking</h6>
                                                        <hr />

                                                        <div class="mb-2">
                                                            <asp:Label ID="lblmark" runat="server" Text="Mark Count " CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtmark" runat="server" placeholder="Enter Mark Count " class="form-control" AutoPostBack="false" TextMode="Number"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="Requiredmark21" runat="server" ErrorMessage="Enter Mark Count" ControlToValidate="txtmark" ForeColor="Red" Font-Bold="false" ValidationGroup="Mark"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblhrms" runat="server" Text=" Mark Name " CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txthrms" runat="server" placeholder="Enter Mark Name" class=" form-control" AutoPostBack="false"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="Requiredmark1" runat="server" ErrorMessage="Enter Mark Name" ControlToValidate="txthrms" ForeColor="Red" Font-Bold="false" ValidationGroup="Mark"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div id="addMarkleave" runat="server">
                                                        <div class="mb-2">
                                                            <asp:Button ID="btnMarksave" runat="server" Text="Save" CssClass="btn btn-sm btn-info" ValidationGroup="Mark" OnClick="btnMarksave_Click" />
                                                            &nbsp;&nbsp;
                                                        <asp:Button ID="btnMarkclear" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="MarkClose" OnClick="btnMarkclear_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                        <h6>View Mark Name Details</h6>
                                                        <hr />
                                                        <asp:GridView ID="GridMark" runat="server" ScrollBars="Both" CssClass="table table-responsive table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable" Style="width: 100%"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridMark_RowDataBound"
                                                            OnRowEditing="GridMark_RowEditing" OnRowUpdating="GridMark_RowUpdating" OnRowCancelingEdit="GridMark_RowCancelingEdit" OnRowDeleting="GridMark_RowDeleting" OnPageIndexChanging="GridMark_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="MarkName" SortExpression="MarkName" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txthrms" runat="server" Text='<%# Bind("MarkName") %>' Font-Size="12px" CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblhrms1" runat="server" Text='<%#Bind("MarkName") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="MarkCount" SortExpression="MarkCount" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtmark" runat="server" Text='<%# Bind("MarkCount") %>' Font-Size="12px" CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblmark1" runat="server" Text='<%# Bind("MarkCount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Createby" SortExpression="Createby" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblcreated_by" runat="server" Text='<%#Bind("Createby") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcreated_by1" runat="server" Text='<%#Bind("Createby") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Createdate" SortExpression="Createdate" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreate_date" runat="server" Text='<%#Bind("Createdate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreate_date1" runat="server" Text='<%#Bind("Createdate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger"><i class="ti ti-trash"></i></asp:LinkButton>
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

                            <div class="row">
                                <div id="DIVControlPanel" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h6 class="text-purple">Control Panal</h6>
                                                        <hr />

                                                        <div class="mb-2">
                                                            <asp:Label ID="lbluserName" runat="server" Text="User Name " CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtname" runat="server" placeholder="Enter User Name " class=" form-control" AutoPostBack="false"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ErrorMessage="Enter User Name" ControlToValidate="txtname" ForeColor="Red" Font-Bold="false" ValidationGroup="ControlPanel"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblEmail" runat="server" Text=" Email " CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter User Email" class=" form-control" AutoPostBack="false"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ErrorMessage="Enter User Email" ControlToValidate="txtEmail" ForeColor="Red" Font-Bold="false" ValidationGroup="ControlPanel"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="Regulexemail1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Address Invalid" ForeColor="Red" ValidationGroup="ControlPanel" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"></asp:RegularExpressionValidator>
                                                        </div>
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblpassword" runat="server" Text="Password" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtpassword" runat="server" placeholder="Enter User Password " class=" form-control" AutoPostBack="false"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ErrorMessage="Enter User Password" ControlToValidate="txtpassword" ForeColor="Red" Font-Bold="false" ValidationGroup="ControlPanel"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblDescrpt" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                            <asp:TextBox ID="txtdescript" runat="server" placeholder="Enter Description" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div id="addControlPanel" runat="server">
                                                        <div class="mb-2">
                                                            <asp:Button ID="BtnControlSave1" runat="server" Text="Save" CssClass="btn btn-sm btn-info" ValidationGroup="ControlPanel" OnClick="BtnControlSave1_Click" />
                                                            &nbsp;&nbsp;
                                                         <asp:Button ID="BtnControlclear1" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="ControlPanelClose" OnClick="BtnControlclear1_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                        <h6>View Control Panel Details</h6>
                                                        <hr />
                                                        <asp:GridView ID="GridControlPanel" runat="server" ScrollBars="Both" CssClass="table table-responsive table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable" Style="width: 100%"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="UserId" OnRowDataBound="GridControlPanel_RowDataBound"
                                                            OnRowEditing="GridControlPanel_RowEditing" OnRowUpdating="GridControlPanel_RowUpdating" OnRowCancelingEdit="GridControlPanel_RowCancelingEdit" OnRowDeleting="GridControlPanel_RowDeleting" OnPageIndexChanging="GridControlPanel_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="UserId" SortExpression="UserId" Visible="false" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("UserId") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("UserId") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Name" SortExpression="name" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtname" runat="server" Text='<%# Bind("name") %>' Font-Size="12px" CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblname1" runat="server" Text='<%# Bind("name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="EmailID" SortExpression="Email" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>' Font-Size="12px" CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEmail1" runat="server" Text='<%#Bind("Email") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Password" SortExpression="Password" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtPassword" runat="server" Text='<%# Bind("Password") %>' Font-Size="12px" CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPassword1" runat="server" Text='<%# Bind("Password") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Createby" SortExpression="Createby" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblcreated_by" runat="server" Text='<%#Bind("Createby") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcreated_by1" runat="server" Text='<%#Bind("Createby") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger"><i class="ti ti-trash"></i></asp:LinkButton>
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

                                <div id="DIVMaterLOGO" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="col-md-12 col-sm-12 col-lg-12">
                                                    <h6 class="text-purple">Company Logo</h6>
                                                    <hr />
                                                    <div class="row">
                                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                                            <div class="input-group">
                                                                <asp:FileUpload ID="FileUpload1" runat="server" name="fileupload" class="form-control" />

                                                                <asp:Button ID="ImgBtn_Upload" runat="server" Text="Upload" CssClass="btn btn-primary btn-sm" ValidationGroup="up1" OnClick="ImgBtn_Upload_Click" />
                                                            </div>

                                                            <br />
                                                            <asp:Image ID="Image1" runat="server" Height="100" Width="233" Visible="false" />
                                                            <br />
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblimg" runat="server" Text=" Image Name " CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtimg" runat="server" placeholder="Enter Image Name" class=" form-control" AutoPostBack="false"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ErrorMessage="Enter Image Name" ControlToValidate="txtimg" ForeColor="Red" Font-Bold="false" ValidationGroup="uploadfile"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblextion" runat="server" Text="Image Extension " CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtextion" runat="server" placeholder="Enter Image Extension " class=" form-control" AutoPostBack="false"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ErrorMessage="Enter Image Extension" ControlToValidate="txtextion" ForeColor="Red" Font-Bold="false" ValidationGroup="uploadfile"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblfileimg" runat="server" Text="Image For" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:DropDownList ID="ddlfileimg" runat="server" CssClass="form-control form-select">
                                                                <asp:ListItem Text="Select_an_option" Value="" />
                                                                <asp:ListItem Text="SmallIconLogo" Value="1" />
                                                                <asp:ListItem Text="SidebarLogo" Value="2" />
                                                                <asp:ListItem Text="TextLogo" Value="3" />
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ErrorMessage="Select Uploade File" ControlToValidate="ddlfileimg" ForeColor="Red" Font-Bold="false" ValidationGroup="uploadfile" InitialValue="0" Display="Static"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div id="addSavefileImg" runat="server">
                                                        <div class="mb-2">
                                                            <asp:Button ID="btnSavefileImg" runat="server" Text="Save" CssClass="btn btn-sm btn-info" ValidationGroup="uploadfile" OnClick="btnSavefileImg_Click" />
                                                            &nbsp;&nbsp;
                            <asp:Button ID="btnClosefileImg" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="uploadfileClose" OnClick="btnClosefileImg_Click" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                        <h6>View Logo Image Details</h6>
                                                        <hr />
                                                        <asp:GridView ID="Gridlogoimg" runat="server" ScrollBars="Both" CssClass="table table-responsive table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable" Style="width: 100%"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="Gridlogoimg_RowDataBound"
                                                            OnRowEditing="Gridlogoimg_RowEditing" OnRowUpdating="Gridlogoimg_RowUpdating" OnRowCancelingEdit="Gridlogoimg_RowCancelingEdit" OnRowDeleting="Gridlogoimg_RowDeleting" OnPageIndexChanging="Gridlogoimg_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ImageFilePath" SortExpression="ImageFilePath" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Image ID="Image" runat="server" ImageUrl='<%# Bind("ImageFilePath") %>' Font-Bold="false" Font-Size="12px" Width="90px" /></asp.Image>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("ImageFilePath") %>' Font-Bold="false" Font-Size="12px" Width="90px" /></asp.Image>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ImageName" SortExpression="ImageName" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtIname" runat="server" Text='<%# Bind("ImageName") %>' Font-Size="12px" CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIname1" runat="server" Text='<%#Bind("ImageName") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="ImageFor" SortExpression="ImageFor" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList ID="ddlfileimgeditor" runat="server" CssClass="form-control form-select" SelectedValue='<%# Bind("ImageFor") %>'>
                                                                            <asp:ListItem Text="Select_an_option" Value="Select_an_option" />
                                                                            <asp:ListItem Text="SmallIconLogo" Value="SmallIconLogo" />
                                                                            <asp:ListItem Text="SidebarLogo" Value="SidebarLogo" />
                                                                            <asp:ListItem Text="TextLogo" Value="TextLogo" />
                                                                        </asp:DropDownList>
                                                                        <asp:TextBox ID="txtimgfor" runat="server" Text='<%# Bind("ImageFor") %>' Font-Size="12px" CssClass="form-control" Visible="false"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblimgfor1" runat="server" Text='<%# Bind("ImageFor") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Extension" SortExpression="Extension" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblExtensionE" runat="server" Text='<%#Bind("Extension") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblExtension1" runat="server" Text='<%#Bind("Extension") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Createby" SortExpression="Createby" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblcreated_by" runat="server" Text='<%#Bind("Createby") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcreated_by1" runat="server" Text='<%#Bind("Createby") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="CreateDate" SortExpression="CreateDate" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreateDate" runat="server" Text='<%#Bind("CreateDate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreateDate1" runat="server" Text='<%#Bind("CreateDate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger"><i class="ti ti-trash"></i></asp:LinkButton>
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
                            <div class="row">
                                <div id="DIVSalaryClass" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h6 style="color: blue">Salary Structure Class</h6>
                                                        <hr />
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblClass" runat="server" Text="Class" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtClass" runat="server" placeholder="Enter Class" class="form-control"></asp:TextBox>

                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtClass" ForeColor="Red" Font-Size="12px" Font-Bold="false" InitialValue="0" Display="Dynamic" ValidationGroup="Class" ErrorMessage="Enter Class"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <br />

                                                        <div class="mb-2">
                                                            <asp:Label ID="Label4" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                            <asp:TextBox ID="txtClassDescription" runat="server" placeholder="Enter Description" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                        </div>
                                                        <br />
                                                        <div id="addNewClass" runat="server">
                                                            <div class="mb-2">

                                                                <asp:Button ID="btnSaveClass" runat="server" Text="Save" CssClass="btn btn-sm btn-info" OnClick="btnSaveClass_Click" ValidationGroup="Class" />
                                                                &nbsp;&nbsp;
                                                            <asp:Button ID="btnClearClass" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="ClassClear" OnClick="btnClearClass_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5 class="card-title">View Stcture Class</h5>
                                                        <hr />
                                                        <asp:GridView ID="GridViewClass" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID"
                                                            OnRowDeleting="GridViewClass_RowDeleting" OnRowDataBound="GridViewClass_RowDataBound" OnRowEditing="GridViewClass_RowEditing" OnRowUpdating="GridViewClass_RowUpdating" OnRowCancelingEdit="GridViewClass_RowCancelingEdit">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblClassID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblClassID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Class" SortExpression="Class" HeaderStyle-Font-Size="12px" HeaderStyle-Width="80px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtClassName" runat="server" Text='<%# Bind("ClassName") %>' Font-Size="12px" CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblClassName" runat="server" Text='<%# Bind("ClassName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Font-Size="12px" HeaderStyle-Width="130px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtclassDescription1" runat="server" Text='<%# Bind("Description") %>' Font-Size="12px" CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Width="80px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnClassEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkClassUpdate" runat="server" Text="Update" CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkClassCancel" runat="server" Text="Cancel" CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnClassDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
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

                                <div id="DIVLeaveType" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h6 style="color: blue">Leave Type</h6>
                                                        <hr />
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblLeaveType" runat="server" Text="Leave Type" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtLeaveType" runat="server" placeholder="Enter Leave Type" class="required form-control"></asp:TextBox>

                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ErrorMessage="Enter Leave Type" ControlToValidate="txtLeaveType" ForeColor="Red" Font-Bold="false" ValidationGroup="Leavename"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="mb-2">
                                                            <asp:Label ID="lblNoOfleave" runat="server" Text="No Of Leave" CssClass="form-label"></asp:Label>
                                                            <asp:TextBox ID="txtNoOfleave" runat="server" placeholder="Enter No Of Leave" class="required form-control" TextMode="Number"></asp:TextBox>
                                                        </div>
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblDescLeave" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                            <asp:TextBox ID="txtDescLeave" runat="server" placeholder="Enter Description" class="required form-control" TextMode="MultiLine"></asp:TextBox>
                                                        </div>

                                                    </div>
                                                    <br />
                                                    <div id="addleadetype" runat="server">
                                                        <div class="mb-2">
                                                            <asp:Button ID="btnSaveLeave" runat="server" Text="Save" CssClass="btn btn-sm btn-info" ValidationGroup="Leavename" OnClick="btnSaveLeave_Click" />
                                                            &nbsp;&nbsp;
                            <asp:Button ID="btnClearLeave" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="Clear" OnClick="btnClearLeave_Click" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <br />


                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5 class="card-title">View Leave Type</h5>
                                                        <hr />

                                                        <asp:GridView ID="GridLeave" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID"
                                                            OnRowDeleting="GridLeave_RowDeleting" OnRowEditing="GridLeave_RowEditing" OnRowUpdating="GridLeave_RowUpdating" OnRowCancelingEdit="GridLeave_RowCancelingEdit">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblLeaveType_ID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblLeaveType_ID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="LeaveType" SortExpression="LeaveType">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtLeaveType" runat="server" Text='<%# Bind("LeaveType") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblLeaveType1" runat="server" Text='<%# Bind("LeaveType") %>' TabIndex="6" Font-Bold="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="NoOfLeave" SortExpression="NoOfLeave">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtNoOfLeave" runat="server" Text='<%# Bind("NoOfLeave") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNoOfLeave1" runat="server" Text='<%# Bind("NoOfLeave") %>' TabIndex="6" Font-Bold="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDescript" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescript1" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreatedBY" SortExpression="CreatedBY">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreateby" runat="server" Text='<%#Bind("CreateBy") %>' Font-Bold="false"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreateby1" runat="server" Text='<%#Bind("CreateBy") %>' Font-Bold="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Created Date" SortExpression="CreateDate">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreateddate" runat="server" Text='<%#Bind("Create_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreateddate1" runat="server" Text='<%#Bind("Create_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDeletePagename" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
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

                            <div class="row">
                                <div id="DIVDashboardPermission" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h5 class="text-info">DasBoard Setting</h5>

                                                        <hr />
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblDivid" runat="server" Text="DivID" Font-Size="12px" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtDivID" runat="server" placeholder="Enter DivID" Font-Size="12px" class="required form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" Font-Size="12px" runat="server" ErrorMessage="Enter DivID" ControlToValidate="txtDivID" ForeColor="Red" Font-Bold="false" ValidationGroup="DashboardSettin"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="mb-2">
                                                            <asp:Label ID="lblDivName" runat="server" Text="DivName" Font-Size="12px" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtDivName" runat="server" placeholder="Enter DivName" Font-Size="12px" class="required form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator31" Font-Size="12px" runat="server" ErrorMessage="Enter DivName" ControlToValidate="txtDivName" ForeColor="Red" Font-Bold="false" ValidationGroup="DashboardSettin"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblRole" runat="server" Text="Select Role" Font-Size="12px" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                        <asp:DropDownList ID="ddlRole" runat="server" Font-Size="12px" CssClass="form-control form-select">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="ddlRole" ForeColor="Red" Font-Size="12px" Font-Bold="false" InitialValue="0" Display="Dynamic" ValidationGroup="DashboardSettin" ErrorMessage="Select Role"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <br />
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblDepartment" runat="server" Font-Size="12px" Text="Select Department" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                        <asp:DropDownList ID="ddlDepartment" runat="server" Font-Size="12px" CssClass="form-control form-select">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator33" Font-Size="12px" runat="server" ControlToValidate="ddlDepartment" ForeColor="Red" Font-Bold="false" InitialValue="0" Display="Dynamic" ValidationGroup="DashboardSettin" ErrorMessage="Select Category"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <br />
                                                    <div class="mb-2">
                                                        <asp:Label ID="Label5" runat="server" Text="Description" Font-Size="12px" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                        <asp:TextBox ID="txtDasDescription" runat="server" Font-Size="12px" placeholder="Enter Description" class="required form-control" TextMode="MultiLine"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator34" Font-Size="12px" runat="server" ErrorMessage="Enter Description" ControlToValidate="txtDasDescription" ForeColor="Red" Font-Bold="false" ValidationGroup="DashboardSettin"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div id="addDashsetting" runat="server">
                                                        <div class="mb-2">
                                                            <%--<asp:Button ID="btnSaveSalCategory1" runat="server" Text="Save" CssClass="btn btn-sm btn-info" ValidationGroup="Category" OnClick="btnSaveSalCategory1_Click" />--%>
                                                            <asp:Button ID="btnDashsettingSave" runat="server" Text="Save" CssClass="btn btn-sm btn-info" OnClick="btnDashsettingSave_Click" ValidationGroup="DashboardSettin" />
                                                            &nbsp;&nbsp;
                                 <asp:Button ID="btndashSettingclear" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="Clear" OnClick="btndashSettingclear_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />

                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h6>View DashBoard Setting</h6>
                                                        <hr />
                                                        <asp:GridView ID="GVDBSetting" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false"
                                                            OnRowDeleting="GVDBSetting_RowDeleting" OnRowEditing="GVDBSetting_RowEditing" OnRowDataBound="GVDBSetting_RowDataBound" OnRowUpdating="GVDBSetting_RowUpdating" OnRowCancelingEdit="GVDBSetting_RowCancelingEdit">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="DivID" SortExpression="DivID" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDivID1" runat="server" CssClass="form-control" Text='<%# Bind("DivID") %>' Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDivID1" runat="server" Text='<%# Bind("DivID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Div Name" SortExpression="DivName" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDivName1" runat="server" CssClass="form-control" Text='<%# Bind("DivName") %>' Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDivName1" runat="server" Text='<%# Bind("DivName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Role Name" SortExpression="RoleName" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList ID="ddlRoleName" CssClass="form-control form-select" runat="server" Font-Size="12px"></asp:DropDownList>

                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRoleName1" runat="server" Text='<%# Bind("RoleName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Deparment" SortExpression="PageName" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList ID="ddlDeptName" CssClass="form-control form-select" runat="server" Font-Size="12px"></asp:DropDownList>

                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDeptName1" runat="server" Text='<%# Bind("DeptName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                        <asp:Label ID="lbldepid" runat="server" Text='<%# Bind("DeptID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description" SortExpression="DivID" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDasDescription1" runat="server" CssClass="form-control" Text='<%# Bind("Description") %>' Font-Size="12px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbDescription1" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="AddedBy" SortExpression="CreatedBY" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblDBCreateby" runat="server" Text='<%#Bind("CreateBy") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDBCreateby1" runat="server" Text='<%#Bind("CreateBy") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreateDate" SortExpression="CreateDate" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblDBCreateddate" runat="server" Text='<%#Bind("CreateDate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDBCreateddate1" runat="server" Text='<%#Bind("CreateDate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Status" SortExpression="PageName" Visible="false" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblDBStatus" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false" Visible="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDBStatus1" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDBSettingEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkDBSettingUpdate" runat="server" Text="Update" CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkDBSettingCancel" runat="server" Text="Cancel" CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDBSettingDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
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

                                <div id="DivCanTermCondi" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h6 class="text-purple">Company Terms and Condition Options</h6>
                                                        <hr />
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblTermAndCond" runat="server" Text="Term And Condition" CssClass="text-dark" Font-Bold="true" Font-Size="14px"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtTermAndCond" runat="server" placeholder="Enter Term And Condition" class="form-control EditorNote"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ErrorMessage="Enter Term And Condition" ControlToValidate="txtTermAndCond" ForeColor="Red" Font-Bold="false" ValidationGroup="TermAndCondition"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="mb-2">
                                                            <asp:Label ID="lblNote" runat="server" Text="Note" Font-Bold="true" Font-Size="14px"></asp:Label>
                                                            <asp:TextBox ID="txtNote" runat="server" placeholder="Enter Note" class="form-control EditorNote" TextMode="MultiLine"></asp:TextBox>
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter Note" ControlToValidate="txtNote" ForeColor="Red" Font-Bold="false" ValidationGroup="TermAndCondition"></asp:RequiredFieldValidator>--%>
                                                        </div>

                                                        <div class="mb-2">
                                                            <asp:Label ID="lblParagraph1" runat="server" Text="Paragraph1" Font-Bold="true" Font-Size="14px"></asp:Label>
                                                            <asp:TextBox ID="txtParagraph1" runat="server" placeholder="Enter Paragraph1" class="form-control EditorNote" TextMode="MultiLine"></asp:TextBox>
                                                        </div>
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblParagraph2" runat="server" Text="Paragraph2" Font-Bold="true" Font-Size="14px"></asp:Label>
                                                            <asp:TextBox ID="txtParagraph2" runat="server" placeholder="Enter Paragraph2" class="form-control EditorNote" TextMode="MultiLine"></asp:TextBox>
                                                        </div>
                                                        <div id="addterms" runat="server">
                                                            <div class="mb-2">
                                                                <asp:Button ID="btnSaveTemsConditions" runat="server" Text="Save" CssClass="btn btn-sm btn-info" ValidationGroup="TermAndCondition" OnClick="btnSaveTemsConditions_Click" />
                                                                &nbsp;&nbsp;
                                                             <asp:Button ID="btnClearTemsConditions" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="TermAndClear" OnClick="btnClearTemsConditions_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h6 class="card-title">View Company Terms and Condition</h6>
                                                        <hr />
                                                        <asp:GridView ID="GridViewTermAndCondition" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID"
                                                            OnRowDeleting="GridViewTermAndCondition_RowDeleting" OnRowEditing="GridViewTermAndCondition_RowEditing" OnRowUpdating="GridViewTermAndCondition_RowUpdating" OnRowCancelingEdit="GridViewTermAndCondition_RowCancelingEdit">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lbTermAndCondition_ID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTermAndCondition_ID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="TermsAndCondition" SortExpression="TermsAndCondition">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtTermsAndCondition" runat="server" Text='<%# Bind("TermsAndCondition") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTermsAndCondition" runat="server" Text='<%# Bind("TermsAndCondition") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Note" SortExpression="Note">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtNote" runat="server" Text='<%# Bind("Note") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNote1" runat="server" Text='<%# Bind("Note") %>' TabIndex="6" Font-Bold="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Paragraph1" SortExpression="Paragraph1">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtParagraph1" runat="server" Text='<%# Bind("Paragraph1") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblParagraph1" runat="server" Text='<%# Bind("Paragraph1") %>' TabIndex="6"  Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Paragraph2" SortExpression="Paragraph2">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtParagraph2" runat="server" Text='<%# Bind("Paragraph2") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblParagraph2" runat="server" Text='<%# Bind("Paragraph2") %>' TabIndex="6"  Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreateBy" SortExpression="CreateBy">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblCreateBy" runat="server" Text='<%#Bind("CreateBy") %>' Font-Bold="false"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCreateBy1" runat="server" Text='<%#Bind("CreateBy") %>'  Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
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

                                <div id="DivOfficialFields" runat="server" visible="false">
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <h6 class="text-purple">Official Document Fields</h6>
                                                        <hr />
                                                        <div class="row">
                                                            <div class="mb-2">
                                                                <asp:Label ID="lblfield" runat="server" Text="Document Field" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                                <asp:TextBox ID="txtfield" runat="server" CssClass="form-control" placeholder="Enter Document Fields"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="Requiredfield" runat="server" ErrorMessage="Enter Document Field" ControlToValidate="txtfield" ForeColor="Red" Font-Bold="false" ValidationGroup="Fields"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="mb-2">
                                                                <asp:Label ID="lbldis" runat="server" Text="Description " CssClass="form-label"></asp:Label>
                                                                <asp:TextBox ID="txtdisc" runat="server" CssClass="form-control" placeholder="Enter Description"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                        <div id="addnewDocument" runat="server" visible="true">
                                                            <div class="row">
                                                                <div class="mb-2">
                                                                    <asp:Button ID="btnsaveDocument" runat="server" Text="Save" CssClass="btn btn-sm btn-info" ValidationGroup="Fields" OnClick="btnsaveDocument_Click" />
                                                                    &nbsp;&nbsp;
                                                              <asp:Button ID="btnclearDocument" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="ClraeFields" OnClick="btnclearDocument_Click" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                        <h6>View Document Fields Details</h6>
                                                        <hr />
                                                        <asp:GridView ID="GridField" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable"
                                                            EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridField_RowDataBound"
                                                            OnRowEditing="GridField_RowEditing" OnRowUpdating="GridField_RowUpdating" OnRowCancelingEdit="GridField_RowCancelingEdit" OnRowDeleting="GridField_RowDeleting" OnPageIndexChanging="GridField_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server"  Font-Bold="false" Font-Size="12px"/>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>'  Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="DocumentField" SortExpression="DocumentField">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtField" runat="server" Text='<%# Bind("DocumentField") %>' CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblfield1" runat="server" Text='<%# Bind("DocumentField") %>' TabIndex="6"  Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtDesc" runat="server" Text='<%# Bind("Description") %>' CssClass="form-control"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDesc1" runat="server" Text='<%#Bind("Description") %>'  Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Createby" SortExpression="Createby">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblcreated_by" runat="server" Text='<%#Bind("Createby") %>' CssClass="form-label" Font-Bold="false"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcreated_by1" runat="server" Text='<%#Bind("Createby") %>'  Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger"><i class="ti ti-trash"></i></asp:LinkButton>
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
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlState1" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="ddldistrict1" EventName="SelectedIndexChanged" />
                            <asp:PostBackTrigger ControlID="ImgBtn_Upload" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
