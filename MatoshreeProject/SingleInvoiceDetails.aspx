<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="SingleInvoiceDetails.aspx.cs" Inherits="MatoshreeProject.SingleInvoiceDetails" EnableEventValidation="false" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridSingleInvoiceDetail = $("#GridSingleInvoiceDetail").prepend($("<thead></thead>").append($("#GridSingleInvoiceDetail").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridTask1 = $("#GridTask1").prepend($("<thead></thead>").append($("#GridTask1").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "180%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var Gridpayment = $("#Gridpayment").prepend($("<thead></thead>").append($("#Gridpayment").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "180%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridViewAct1 = $("#GridViewAct1").prepend($("<thead></thead>").append($("#GridViewAct1").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "310px",
                    "scrollX": "150%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridviewRemainder1 = $("#GridviewRemainder1").prepend($("<thead></thead>").append($("#GridviewRemainder1").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "180%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridInvoicePayments = $("#GridInvoicePayments").prepend($("<thead></thead>").append($("#GridInvoicePayments").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "180%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });
        });
    </script>

    <%-- Module Popup --%>

    <style>
        .Background {
            background-color: Black;
            /*  filter: alpha(opacity=90);*/
            opacity: 0.8;
        }

        .Popup {
            background-color: #FFFFFF;
            border-width: 2px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 300px;
            height: 150px;
        }

        .lbl {
            font-size: 16px;
            font-style: italic;
            font-weight: bold;
        }
    </style>

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
                <h5 class="font-weight-medium mb-0">Invoice Details</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item"><a class="text-muted text-decoration-none" href="Chart_List_Invoice.aspx">Invoice</a></li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="#">Invoice Details</li>
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
            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <div class="d-flex justify-content-between align-items-center">
                            <asp:Button ID="btn_CreateInvoice" runat="server" Text="New Invoice" CssClass="btn btn-primary btn-sm" OnClick="btn_CreateInvoice_Click" />
                            <div>
                                <div class="bd-example">
                                    <div class="btn-group">
                                        <button class="btn btn-sm btn-primary" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="ti ti-filter"></i></button>
                                        <div class="dropdown-menu">
                                            <asp:LinkButton ID="lnkbtnALL" Text="ALL" runat="server" CssClass="dropdown-item" OnClick="lnkbtnALL_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkViewNotsend" Text="Not send" runat="server" CssClass="dropdown-item" OnClick="LinkViewNotsend_Click"></asp:LinkButton>

                                            <asp:LinkButton ID="linkbtnInvoicewithoutpay" Text="Invoice with no payment records" runat="server" CssClass="dropdown-item" OnClick="linkbtnInvoicewithoutpay_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="lnkbtnRecurringInvoices" runat="server" Text="Recurring Invoices" CssClass="dropdown-item" OnClick="lnkbtnRecurringInvoices_Click"></asp:LinkButton>
                                            <hr />
                                            <asp:LinkButton ID="LinkViewUnpaid" runat="server" Text="Unpaid" CssClass="dropdown-item" OnClick="LinkViewUnpaid_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkViewPaid" runat="server" Text="Paid" CssClass="dropdown-item" OnClick="LinkViewPaid_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkViewPartiallyPaid" runat="server" Text="Partially Paid" CssClass="dropdown-item" OnClick="LinkViewPartiallyPaid_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkViewOverdue" runat="server" Text="Overdue" CssClass="dropdown-item" OnClick="LinkViewOverdue_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkViewCancelled" runat="server" Text="Cancelled" CssClass="dropdown-item" OnClick="LinkViewCancelled_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkViewDraft" runat="server" Text="Draft" CssClass="dropdown-item" OnClick="LinkViewDraft_Click"></asp:LinkButton>

                                            <hr />
                                            <asp:RadioButtonList ID="radiolistInvoiceYear" runat="server" CssClass="dropdown-item" AutoPostBack="true" OnSelectedIndexChanged="radiolistInvoiceYear_SelectedIndexChanged"></asp:RadioButtonList>
                                            <hr />

                                            <asp:RadioButtonList ID="radioSaleAgent" runat="server" CssClass="dropdown-item" AutoPostBack="true"></asp:RadioButtonList>

                                            <hr />
                                            <asp:LinkButton ID="linkbtnMakebyBank" runat="server" Text="Make Payment by Bank" CssClass="dropdown-item" OnClick="linkbtnMakebyBank_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="linkbtnMakebyCash" runat="server" Text="Make Payment by Cash" CssClass="dropdown-item" OnClick="linkbtnMakebyCash_Click"></asp:LinkButton>

                                        </div>
                                    </div>
                                </div>



                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-5 col-sm-5 col-lg-5 col-xs-5 ">
                <div class="card">
                    <div class="card-body">
                        <h5>View Invoice Details</h5>
                        <hr />
                        <div class="row">
                            <div class="col-md-8 col-lg-8 col-sm-8 col-xs-8">
                                <div class="bd-example">
                                    <div class="btn-group">
                                        <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                        <asp:Button ID="Button1" runat="server" Style="display: none" />
                                        <div class="dropdown-menu">
                                            <asp:LinkButton ID="lnkbtnExcel" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="lnkbtnExcel_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="linkbtnPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnPDF_Click"></asp:LinkButton>

                                        </div>
                                    </div>

                                    <asp:Button ID="btn_Reload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="Btn_Reload_Click" />
                                    <asp:Button ID="Btn_Visibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="Btn_Visibility_Click" />
                                </div>
                            </div>
                            <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
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
                                <asp:Label ID="Label2" runat="server" Text="Phone:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblphoneNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="Label3" runat="server" Text="VAT NO:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblVatNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblGSTNo1A" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <!------PDF code--------->

                            </div>

                        </div>
                        <br />
                        <br />
                        <asp:GridView ID="GridSingleInvoiceDetail" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridSingleInvoiceDetail_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false">
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
                                        <asp:LinkButton ID="LinkInvoiceNumber" runat="server" Text='<%# Bind("InvoiceNo") %>' Font-Size="12px" CssClass="text-info" OnClick="LinkInvoiceNumber_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount" SortExpression="InvoiceTotalAmont" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("InvoiceTotalAmont") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("InvoiceTotalAmont") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Invoice_Date" SortExpression="InvoiceDate" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%# Bind("InvoiceDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate1" runat="server" Text='<%# Bind("InvoiceDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
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
                                        <asp:Label ID="lblProject1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" SortExpression="Status" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblStats61" runat="server" Text=""></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStats6" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
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
            <br />

            <%--Add  New Div--%>
            <div class="col-md-7 col-sm-12 col-lg-7 col-xs-12">
                <div id="SingINV" runat="server">
                    <div class="card">
                        <div class="card-body">
                            <ul class="nav nav-tabs" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" data-bs-toggle="tab" href="#InvoiceNo" role="tab"><span class="hidden-sm-up"></span>
                                        <span class="hidden-xs-down fs-6px">Invoice</span></a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" data-bs-toggle="tab" href="#File" role="tab"><span class="hidden-sm-up"></span>
                                        <span class="hidden-xs-down fs-3px">File</span></a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" data-bs-toggle="tab" href="#Payment" role="tab"><span class="hidden-sm-up"></span>
                                        <span class="hidden-xs-down fs-3px">Payment</span></a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" data-bs-toggle="tab" href="#Task" role="tab"><span class="hidden-sm-up"></span>
                                        <span class="hidden-xs-down fs-3px">Task</span></a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" data-bs-toggle="tab" href="#ActivityLogs" role="tab"><span class="hidden-sm-up"></span>
                                        <span class="hidden-xs-down fs-3px">ActivityLogs</span></a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" data-bs-toggle="tab" href="#Reminder" role="tab"><span class="hidden-sm-up"></span>
                                        <span class="hidden-xs-down fs-3px">Reminder</span></a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" data-bs-toggle="tab" href="#Notes" role="tab"><span class="hidden-sm-up"></span>
                                        <span class="hidden-xs-down fs-3px">Notes</span></a>
                                </li>
                            </ul>
                            <br />
                            <div class="tab-content tabcontent-border">
                                <div id="InvoiceNo" class="tab-pane active" role="tabpanel">
                                    <div class="container">
                                        <div class="row">
                                            <div class="col-md-3 col-lg-3 col-sm-3 col-xs-3" style="margin-left: -21px">
                                                <asp:Label ID="lblStatus" runat="server" Text="" CssClass="btn btn-sm btn-light text-info"></asp:Label>
                                                <asp:Label ID="lblstatus1" runat="server" Text="" CssClass="text-danger" Visible="false"></asp:Label>
                                            </div>
                                            <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2">
                                            </div>
                                            <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4" style="margin-right: -22px">
                                                <asp:LinkButton ID="Linkbtnedit" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="Linkbtnedit_Click"><i class="ti ti-edit"></i></asp:LinkButton>&nbsp;

                                            <asp:LinkButton ID="lnkbtnpdf" runat="server" CssClass="btn btn-sm btn-outline-danger" OnClick="lnkbtnpdf_Click"><iconify-icon icon="ph:file-pdf"></iconify-icon></asp:LinkButton>
                                                &nbsp;

                                            <asp:LinkButton ID="LinkbtnMessage" runat="server" CssClass="btn btn-sm btn-outline-primary"><iconify-icon icon="solar:letter-unread-linear" class="aside-icon"></iconify-icon></asp:LinkButton>
                                            </div>


                                            <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2" style="margin-left: -16px">
                                                <div class="bd-example">
                                                    <div class="btn-group">
                                                        <button class="btn btn-sm btn-light dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">More</button>
                                                        <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                                        <div class="dropdown-menu">
                                                            <asp:LinkButton ID="lnkbtnviewascustmer" Text="View Invoice As Customer" runat="server" CssClass="dropdown-item" OnClick="lnkbtnviewascustmer_Click"></asp:LinkButton>
                                                            <asp:LinkButton ID="linkbtnSendOverDue" runat="server" Text="Sent Overdue Notice" CssClass="dropdown-item" OnClick="linkbtnSendOverDue_Click"></asp:LinkButton>
                                                            <asp:LinkButton ID="lnkbtnsent" runat="server" Text="Mark as Sent" CssClass="dropdown-item" OnClick="lnkbtnsent_Click"></asp:LinkButton>
                                                            <asp:LinkButton ID="lnkbtnNotsend" Text="Not send" runat="server" CssClass="dropdown-item" OnClick="lnkbtnNotsend_Click"></asp:LinkButton>

                                                            <hr />
                                                            <asp:LinkButton ID="LinkStatusUnpaid" runat="server" Text="Unpaid" CssClass="dropdown-item" OnClick="LinkStatusUnpaid_Click"></asp:LinkButton>
                                                            <asp:LinkButton ID="LinkStatusPaid" runat="server" Text="Paid" CssClass="dropdown-item" OnClick="LinkStatusPaid_Click"></asp:LinkButton>
                                                            <asp:LinkButton ID="LinkStatusPartiallyPaid" runat="server" Text="Partially Paid" CssClass="dropdown-item" OnClick="LinkStatusPartiallyPaid_Click"></asp:LinkButton>
                                                            <asp:LinkButton ID="LinkStatusOverdue" runat="server" Text="Overdue" CssClass="dropdown-item" OnClick="LinkStatusOverdue_Click"></asp:LinkButton>
                                                            <asp:LinkButton ID="LinkStatusCancelled" runat="server" Text="Cancelled" CssClass="dropdown-item" OnClick="LinkStatusCancelled_Click"></asp:LinkButton>
                                                            <asp:LinkButton ID="LinkStatusDraft" runat="server" Text="Draft" CssClass="dropdown-item" OnClick="LinkStatusDraft_Click"></asp:LinkButton>
                                                            <hr />
                                                            <asp:LinkButton ID="lnkbtnInvoiceswithnopayment" runat="server" Text="Invoices with no payment records" CssClass="dropdown-item" OnClick="lnkbtnInvoiceswithnopayment_Click"></asp:LinkButton>
                                                            <asp:LinkButton ID="lnkbtncopyestimate" runat="server" Text="Copy Invoice" CssClass="dropdown-item" OnClick="lnkbtncopyestimate_Click"></asp:LinkButton>
                                                            <asp:LinkButton ID="lnkbtndelInvoice" runat="server" Text="Delete Invoice" CssClass="dropdown-item text-danger" OnClick="lnkbtndelInvoice_Click"></asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-2 col-lg-2 col-sm-2 col-xs-3" style="margin-left: -20px">
                                                <asp:LinkButton ID="linkbtnPaid" runat="server" CssClass="btn btn-sm btn-success text-white" Font-Size="12px" OnClick="linkbtnPaid_Click"><i class="ti ti-square-plus"></i>&nbsp;&nbsp;Paid</asp:LinkButton>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-8 col-lg-8 col-sm-8 col-xs-8" style="margin-left: -21px">
                                                <asp:Label ID="lblMsg1" runat="server" Text="test" Visible="false" Font-Bold="false" Font-Size="12px" ForeColor="Red"></asp:Label>
                                            </div>
                                            <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4"></div>
                                        </div>
                                        <div class="row">
                                            <div id="Emailmodal1">
                                                <%-- Msg DIV popup for save --%>
                                                <asp:Label ID="lblStaffEmail" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:Label ID="lblStaffDesignation" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:Label ID="lblEmpName11" runat="server" Text="" Visible="false"></asp:Label>


                                                <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="LinkbtnMessage"
                                                    CancelControlID="btnCloseemail" BackgroundCssClass="Background">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="Panl1" runat="server" CssClass="Popup table-responsive table-responsive-md" align="left" Style="display: none; width: 330px; height: 600px; top: 40px;">

                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <div class="card">

                                                                <div class="card-body">
                                                                    <h5 class="text-purple">Send Invoice Email To Client</h5>
                                                                    <hr />

                                                                    <div class="mb-2">
                                                                        <asp:Label ID="lblEmailTo" runat="server" Text="Email to" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                                        <asp:TextBox ID="txtEmailto" runat="server" placeholder="Enter Email to" CssClass="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldFirst_Name" runat="server" ErrorMessage="Enter Email To Send" ControlToValidate="txtEmailto" ForeColor="Red" Font-Bold="false" ValidationGroup="sendemail" Font-Size="12px"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <div class="mb-2">
                                                                        <asp:Label ID="lblCC" runat="server" Text="CC" CssClass="form-label"></asp:Label>
                                                                        <asp:TextBox ID="txtCC" runat="server" placeholder="Enter CC" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="mb-2">
                                                                        <asp:Label ID="lblEmailEditor" runat="server" Text="Preview Email Template" CssClass="form-label"></asp:Label>
                                                                        <asp:TextBox ID="txtEmailEditor" runat="server" placeholder="Email Template" CssClass="EditorNote" TextMode="MultiLine"></asp:TextBox>

                                                                    </div>

                                                                    <div class="mb-2">
                                                                        <asp:Button ID="btnSendEmail" runat="server" Text="Send Email" CssClass="btn btn-sm btn-primary" ValidationGroup="sendemail" OnClick="btnSendEmail_Click" />
                                                                        &nbsp;&nbsp;
                                                                        <asp:Button ID="btnCloseemail" runat="server" Text="Close" ValidationGroup="closee" CssClass="btn btn-sm btn-danger " />
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>

                                                </asp:Panel>

                                            </div>
                                        </div>
                                    </div>
                                    <hr class="my-4" />
                                    <div class="container">
                                        <div class="row">
                                            <div>
                                                <asp:Label ID="lblInvoiceTotalAMT" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label><br />

                                                <asp:Label ID="lblURLname" runat="server" Text="This Invoice related to project:" Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblURLname1" runat="server" Text="" CssClass="text-info " Font-Size="13px"></asp:Label>
                                            </div>
                                            <br />
                                            <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6 text-start ml-3 p-2">
                                                <asp:Label ID="lblid1" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:Label ID="lblCustID" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:Label ID="lblContactID" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:Label ID="lblFitstName" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:Label ID="lblContactPosition" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:Label ID="lblContactPhone" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:Label ID="lblContactEmail" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:Label ID="lblProjectID" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:Label ID="lblSaleAjentID" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:Label ID="TAXCount" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:Label ID="TAXCount2" runat="server" Text="" Visible="false"></asp:Label>

                                                <asp:Label ID="lblImgPath" runat="server" Text="" Visible="false"></asp:Label>

                                                <asp:Label ID="lblInvoiceno" runat="server" Text="" CssClass="form-label text-info" Font-Size="12px"></asp:Label><br />
                                                <%-- Company Address --%>
                                                <asp:Label ID="lbladdCompany1" runat="server" Text="" CssClass="form-label" Font-Size="12px"></asp:Label><br />
                                                <asp:Label ID="lbladdress1" runat="server" Text=" " Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblcompanyaddCity" runat="server" Text=" " Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblcompanyaddDistrict" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                                <asp:Label ID="lblcompanyaddState" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblcompanyaddCountry" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                                <asp:Label ID="lblcompanyaddZIPCode" runat="server" Text="PIN :" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblcompanyaddZIPCode1" runat="server" Text="" Font-Size="12px"></asp:Label><br />

                                                <asp:Label ID="lblphone" runat="server" Text="Phone:" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblphoneNo" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label><br />
                                                <asp:Label ID="lblVat" runat="server" Text="VAT NO:" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblVatNo" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label><br />
                                                <asp:Label ID="lblGST" runat="server" Text="GST NO:" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblGSTNo" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                <%-- Company Address --%>
                                            </div>
                                            <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6  text-end">
                                                <asp:Label ID="lblspace" runat="server" Text=""></asp:Label><br />
                                                <asp:Label ID="lblspace1" runat="server" Text=""></asp:Label><br />
                                                <asp:Label ID="lbladdcust1" runat="server" Text="To," CssClass="form-label "></asp:Label><br />
                                                <asp:Label ID="lblcustname" runat="server" Text="" CssClass="form-label text-info "></asp:Label><br />
                                                <%-- Client billing  Address --%>
                                                <asp:Label ID="lblblock" runat="server" Text="" Font-Size="12px"></asp:Label>


                                                <br />
                                                <%-- Client billing  Address --%>

                                                <%-- Client shipping  Address --%>
                                                <asp:Label ID="lblShipp" runat="server" Text="Shipping To:" CssClass="form-label" Visible="false"></asp:Label><br />

                                                <asp:Label ID="lblShipTo" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblShipTo1" runat="server" Text="" Font-Size="12px"></asp:Label>


                                                <%-- Client shipping  Address --%>
                                                <br />
                                                <asp:Label ID="lblgstnoA" runat="server" Text="GST No:" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblgstno1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                               
                                                <asp:Label ID="lblInvoicedate" runat="server" Text="Invoice Date:" CssClass="form-label" Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblInvoicedate1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                                <asp:Label ID="lblExpiry_Date" runat="server" Text="Expiry Date:" CssClass="form-label" Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblExpiry_Date1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                                <asp:Label ID="lblsaleagent" runat="server" Text="Sale Agent:" CssClass="form-label" Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblsaleagent1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                                <asp:Label ID="lblprojectname" runat="server" Text="Project Name:" CssClass="form-label" Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblprojectname1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="container">
                                        <div class='row'>
                                            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 p-2">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="GridCalculate" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                        ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true">
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-Width="150px">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblItem" runat="server" Text="Item" CssClass="form-label"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblItem1" runat="server" Text='<%# Bind("InvoiceItem") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Width="180px" ItemStyle-Width="200px">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDescription1" runat="server" Text='<%# Bind("Description") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHSNname" runat="server" Text="HSN" CssClass="form-label"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblHSN1" runat="server" Text='<%# Bind("HSN") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblQuantity" runat="server" Text="Qnty" CssClass="form-label"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblQuantity1" runat="server" Text='<%# Bind("Qnty") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblRate" runat="server" Text="Rate" CssClass="form-label"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRate1" runat="server" Text='<%# Bind("Rate") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblSubAmont" runat="server" Text="Amount" CssClass="form-label"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSubAmont1" runat="server" Text='<%# Bind("SubTotal") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Width="160px">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblTax" runat="server" Text="GST1" CssClass="form-label"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTaxValees" runat="server" Text='<%# Bind("Tax1Rate") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblTax1" runat="server" Text='<%# Bind("Tax1Name") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="GSTAmt" SortExpression="Tax1Amount" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="true">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblTax1Rate" runat="server" Text='<%# Bind("Tax1Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTax1Rate1" runat="server" Text='<%# Bind("Tax1Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Width="160px">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblTax1A" runat="server" Text="GST2" CssClass="form-label"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTaxValees1A" runat="server" Text='<%# Bind("Tax2Rate") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblTax1A" runat="server" Text='<%# Bind("Tax2Name") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="GST2Amt" SortExpression="Tax2Amount" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="true">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblTax2Rate" runat="server" Text='<%# Bind("Tax2Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTax2Rate1" runat="server" Text='<%# Bind("Tax2Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblAmontname" runat="server" Text="Total" CssClass="form-label"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAmont1" runat="server" Text='<%# Bind("TotalAmont") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="container">
                                        <div class="row">
                                            <div class="col-md-3 col-lg-3 col-sm-3 col-xs-3  text-left ml-3 p-2">
                                            </div>

                                            <div class="col-md-5 col-lg-5 col-sm-5 col-xs-5 text-end">
                                                <asp:Label ID="lblsubtotalname" runat="server" Text="Sub Total :" CssClass="form-label"></asp:Label><br />
                                                &nbsp;
                                            <asp:Label ID="lblDiscount1" runat="server" Text="Discount :" CssClass="form-label"></asp:Label><br />
                                                &nbsp;

                                            <%--TAX Bullet List--%>
                                                <asp:BulletedList ID="listTaxNames1" runat="server" Font-Size="12px" CssClass="form-label" Font-Bold="true" BulletStyle="NotSet" Style="margin-left: 60px"></asp:BulletedList>
                                                <br />
                                                &nbsp;
                                            <asp:Label ID="lblTotalTax" runat="server" Text="Total Tax Amount :" CssClass="form-label"></asp:Label><br />
                                                &nbsp; 
                                            <asp:Label ID="lblAdjustment" runat="server" Text="Roundup :" CssClass="form-label"></asp:Label><br />
                                                &nbsp; 
                                            <asp:Label ID="lblTotalInvCost" runat="server" Text="Total Amount:" CssClass="form-label"></asp:Label><br />
                                                &nbsp;
                                            </div>

                                            <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4 text-end">
                                                <asp:Label ID="lblSubTotalCost" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                                &nbsp; 
                                            <asp:Label ID="lblDiscountCost" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                                &nbsp;
                                             <%--TAX Bullet List--%>
                                                <asp:BulletedList ID="listTaxValues1" runat="server" Font-Size="12px" Font-Bold="false" BulletStyle="CustomImage" BulletImageUrl="Image/indiCurrency10.png" Style="margin-left: 50px"></asp:BulletedList>
                                                <br />
                                                &nbsp;
                                           <asp:Label ID="lblTotalTaxCost1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                                &nbsp; 
                                           <asp:Label ID="lblAdjustmentCost" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                                &nbsp; 
                                              <asp:Label ID="lbltotalAmonutInvoiceCost" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                                &nbsp; 
                                            </div>

                                        </div>

                                    </div>
                                    <br />

                                    <div class="container">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:Label ID="lblNote" runat="server" Text="Note :" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblclientnote" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                <br />
                                                <br />
                                                <asp:Label ID="lblTermsCondition1" runat="server" Text="Terms & Condition :" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lbltermsandcodition" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- tab one end --%>
                                <div id="File" class="tab-pane p-20" role="tabpanel">
                                    <div class="container">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-6 col-sm-6 col-lg-6">
                                                        <asp:Label ID="lblAttachment" runat="server" Text="Attachment:" CssClass="form-label" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblAttachment1" runat="server" Text="" Font-Size="12px" Font-Bold="false" ForeColor="Blue" Visible="false"></asp:Label>
                                                    </div>
                                                    <div class="col-md-6 col-sm-6 col-lg-6"></div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                                        <div class="uploadOuter">
                                                            <span class="dragBox" style="">Darg and Drop image here
                                                       <input type="file" runat="server" onchange="dragNdrop(event)" ondragover="drag()" ondrop="drop()" id="uploadFile1" />
                                                            </span>
                                                        </div>
                                                        <br />
                                                        <div id="preview"></div>
                                                        <br />
                                                        <br />
                                                        <center>
                                                            <asp:LinkButton ID="LinkBtnupdate" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="LinkBtnupdate_Click"><i class="ti ti-upload"></i></asp:LinkButton>
                                                            <asp:LinkButton ID="lnkclear" runat="server" Text="Delete" CssClass="btn btn-sm btn-outline-danger ml-4" OnClick="lnkclear_Click"><i class="ti ti-cut"></i></asp:LinkButton>

                                                        </center>
                                                        <br />
                                                        <br />
                                                        <center>
                                                            <asp:Button ID="btnclose" runat="server" CssClass="btn btn-sm btn-light" Text="Close" />
                                                        </center>
                                                    </div>
                                                    <br />
                                                    <br />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div id="Payment" class="tab-pane p-20" role="tabpanel">
                                    <asp:Label ID="lblPaymentID1" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="lblTrancationID1" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="lblPaymentAmount1" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="lblPaymentDate1" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="lblPaymentMode1" runat="server" Text="" Visible="false"></asp:Label>
                                    <div class="container-fluid">

                                        <h5>View Payment Details</h5>
                                        <hr />
                                        <asp:Button ID="btnExportPayment1" runat="server" Text="Export" CssClass="btn btn-sm  btn-outline-success" OnClick="btnExportPayment_Click1" />
                                        <asp:Button ID="btnPaymentVisibility1" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="btnVISIBILITYPayment_Click1" />
                                        <asp:Button ID="btnPaymentReload1" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="btnRELOADPayment_Click1" />
                                        <br />
                                        <br />

                                        <asp:GridView ID="GridInvoicePayments" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover table-responsive text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID">
                                            <Columns>
                                                <asp:TemplateField HeaderText="ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ID" SortExpression="Exp_id" HeaderStyle-Font-Size="12px" Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="PaymentMode" SortExpression="Payment_Mode" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblPaymentMode" runat="server" Text='<%# Bind("Payment_Mode") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPaymentMode1" runat="server" Text='<%# Bind("Payment_Mode") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Transaction_ID" SortExpression="Transaction_ID" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblTransaction_ID" runat="server" Text='<%# Bind("Transation_ID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTransaction_ID1" runat="server" Text='<%# Bind("Transation_ID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Customer" SortExpression="Customer" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblCustomer" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCustomer1" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Amount" SortExpression="Amount" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount_Recived") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("Amount_Recived") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date" SortExpression="Date" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Payment_date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDate1" runat="server" Text='<%# Bind("Payment_date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" SortExpression="Status" Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblStatus1" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnView1" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnView1_Click"><i class="ti ti-eye"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDeletep" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClick="btnDeletep_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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

                                <div id="Task" class="tab-pane p-20" role="tabpanel">
                                    <div class="container-fluid">
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 col-lg-12 col-12 col-xl-12">

                                                <h5 class="font-weight-medium mb-0">Task</h5>
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

                                            </div>

                                        </div>
                                    </div>
                                    <div class="container-fluid">
                                        <div class='row'>
                                            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 p-2">

                                                <h5>View Task Details</h5>
                                                <hr />
                                                <div class='row'>
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
                                                            <asp:Button ID="btnReloadTask" runat="server" Text="Reload" CssClass="btn btn-sm btn-sm btn-outline-info" OnClick="BtnReloadTask_Click" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6 col-sm-6 col-lg-6"></div>
                                                </div>
                                                <br />
                                                <br />
                                                <div id="grd" style="width: 100%">
                                                    <asp:GridView ID="GridTask1" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" Style="width: 100%" AutoGenerateColumns="false" CellPadding="4"
                                                        ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" OnRowDataBound="GridTask1_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="ID">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRowNumTask" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
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
                                                            <asp:TemplateField HeaderText="AssignedTo" SortExpression="AssignTo" HeaderStyle-Font-Size="12px" HeaderStyle-Width="180px">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblReletd_To" runat="server" Text='<%# Bind("AssignTo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:BulletedList ID="bulletlist1" runat="server" BulletStyle="Circle" CssClass="" Width="170px">
                                                                    </asp:BulletedList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Status" SortExpression="TaskStatus" HeaderStyle-Font-Size="12px" HeaderStyle-Width="160px">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblTaskStatus" runat="server" Text='<%#Bind("TaskStatus") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlTaskStatus" runat="server" CssClass="form-control " AutoPostBack="true" OnSelectedIndexChanged="ddlTaskStatus_SelectedIndexChanged" Style="width: 160px">
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

                                <div id="ActivityLogs" class="tab-pane p-20" role="tabpanel">

                                    <h5>Activity Log</h5>
                                    <hr />

                                    <div class="todo-widget scrollable" style="height: 600px">
                                        <asp:GridView ID="GridViewAct1" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" Style="width: 100%" AutoGenerateColumns="false" CellPadding="4"
                                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" OnRowDataBound="GridTask1_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRowNumAct" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Project Activity" SortExpression="Activity" HeaderStyle-Font-Size="12px">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblUserID11" runat="server" Text='<%# Bind("UserID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <i class="mdi mdi-leaf fs-4 w-30px mt-1"></i>
                                                        <asp:Label ID="lblDifd" runat="server" Text='<%# Bind("Diff")%>' TabIndex="6" Font-Size="12px" ForeColor="Blue"></asp:Label>
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

                                <div id="Reminder" class="tab-pane p-20" role="tabpanel">
                                    <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                        <div id="remainderFormtable">
                                            <div class="mb-2">
                                                <div id="divbtnsetRemider" runat="server">
                                                    <button id="btn_expenseRemainder" class="btn btn-sm btn-outline-info btn-lg" type="button" onclick="toggleForm()">
                                                        <i class="far fa-bell"></i>&nbsp;&nbsp;Set Invoice Reminder
                                                    </button>
                                                </div>
                                            </div>
                                            <br />

                                            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                                <div id="addexpenseRemainder" class="row" style="display: none;">

                                                    <asp:Label ID="lblRemainderForm" runat="server" Text="" Font-Bold="false" Visible="false" Font-Size="12px"></asp:Label>
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblDateNotified" runat="server" Text="Date to be notified" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                        <asp:TextBox ID="txtDateNotified" type="date" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="Enter Date"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredNotifiedDate" runat="server" ErrorMessage="Enter Notified Date" ControlToValidate="txtDateNotified" ForeColor="Red" Font-Bold="false" ValidationGroup="Remainder" Font-Size="12px"></asp:RequiredFieldValidator>
                                                    </div>

                                                    <div class="mb-2">
                                                        <asp:Label ID="lblSetReminder" runat="server" Text="Set reminder to" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                        <asp:DropDownList ID="ddlSetReminderStaff" runat="server" CssClass="form-control form-select" Placeholder="Nothing Selected">
                                                        </asp:DropDownList>
                                                    </div>

                                                    <div class="mb-2">
                                                        <asp:Label ID="lblDescription" runat="server" Text="Description" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp; <%--<span style="color: #FF0000">*</span>--%>
                                                        <asp:TextBox ID="txtDescriptionReminder" runat="server" placeholder="Enter Description" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldNote" runat="server" ErrorMessage="Enter Description" ControlToValidate="txtDescription" ForeColor="Red" Font-Bold="false" ValidationGroup="Purchase"  Font-Size="12px"></asp:RequiredFieldValidator>--%>
                                                        <br />
                                                        <asp:CheckBox ID="Chkboxformail" runat="server" Checked="false" Text="Send also an email for this remainder" Font-Bold="true" Font-Size="12px" />

                                                    </div>

                                                    <div class="mb-2">
                                                        <asp:Button ID="btnSaveRemainder" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="Remainder" OnClick="btnSaveRemainder_Click" />
                                                        &nbsp;&nbsp;
                                                    <asp:Button ID="btnClearRemainder" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" OnClick="btnClearRemainder_Click" ValidationGroup="Remainder1" />

                                                        <asp:Button ID="btnUpdateReminder" runat="server" Text="Update" CssClass="btn btn-sm btn-success" ValidationGroup="updateRemainder" OnClick="btnUpdateReminder_Click" Visible="false" />
                                                        &nbsp;&nbsp;
                                                    <asp:Button ID="btnCancelReminder" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" ValidationGroup="cacelRemainder" OnClick="btnCancelReminder_Click" Visible="false" />
                                                    </div>
                                                </div>
                                            </div>

                                            <%-- <hr />--%>
                                            <div id="Timesheet" runat="server" visible="true">
                                                <asp:Label ID="lblRemainderInfoWGV" runat="server" Text="" Visible="false"></asp:Label>
                                                <br />
                                                <h5 class="font-weight-medium mb-0">View Reminder Details</h5>
                                                <hr />
                                                <asp:Button ID="btnexport" runat="server" Text="Export" CssClass="btn btn-sm btn-outline-success" OnClick="btnexport_Click" />
                                                <asp:Button ID="btnVisibilityRemainder" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="btnVisibilityRemainder_Click" />

                                                <asp:Button ID="btnReload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="btnReload_Click" />
                                                <br />
                                                <br />
                                                <asp:GridView ID="GridviewRemainder1" runat="server" CssClass="table border table-bordered table-hover text-nowrap align-content-center" ScrollBars="Both" OnRowDataBound="GridviewRemainder1_RowDataBound" AutoGenerateColumns="false" CellPadding="4"
                                                    ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="R_ID">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="ID">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRowNumTask" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status" SortExpression="Order" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="ID" SortExpression="R_ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblR_ID" runat="server" Text='<%# Bind("R_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblR_ID1" runat="server" Text='<%# Bind("R_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Font-Size="12px" HeaderStyle-Width="180px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblDescription" runat="server" Text='<%#Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDescription1" runat="server" Text='<%#Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="NotifyDate" SortExpression="NotifyDate" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblNotifyDate" runat="server" Text='<%#Bind("NotifyDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNotifyDate1" runat="server" Text='<%#Bind("NotifyDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Remainder" SortExpression="SetToReminder" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblSetToReminder" runat="server" Text='<%#Bind("SetToReminder") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSetToReminder1" runat="server" Text='<%#Bind("SetToReminder") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkEditRemainder" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="LinkEditRemainder_Click" TabIndex="6" Font-Bold="false" Font-Size="12px"><i class="ti ti-edit"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnDeleteRemainder" runat="server" CssClass="btn btn-sm btn-outline-danger" OnClick="btnDeleteRemainder_Click" TabIndex="6" Font-Bold="false" Font-Size="12px"><i class="ti ti-trash"></i></asp:LinkButton>
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

                                <div id="Notes" class="tab-pane p-20" role="tabpanel">
                                    <div class="container-fluid">
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 col-ld-12">

                                                <h5 class="font-weight-medium mb-0">Note</h5>
                                                <hr />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-ld-12">
                                                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>

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
                        </div>
                    </div>
                </div>

                <%-- Payment CRUD --%>
                <div id="PaymentCrudDiv" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">

                                <div class="card-title">
                                    <asp:Label ID="lblpayid" runat="server" Text="" Font-Bold="true" Font-Size="12px" ForeColor="Blue" Visible="false"></asp:Label>
                                    <asp:Label ID="lblTittle" runat="server" Text="Record Payment For" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblinvoice" runat="server" Text="" Font-Bold="true" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                    <asp:Label ID="iblinvoiceid" runat="server" Text="" Font-Bold="true" Font-Size="20px" Visible="false"></asp:Label>
                                </div>
                                <hr />
                                <div class="col-md-6 col-sm-6 col-lg-6">

                                    <div class="mb-2">

                                        <asp:Label ID="lblAmount" runat="server" Text="Amount Received" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <asp:TextBox ID="txtAmount" runat="server" placeholder="Amount Received" TextMode="Number" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Amount" ControlToValidate="txtAmount" ForeColor="Red" Font-Bold="false" ValidationGroup="Amount" Font-Size="12px"></asp:RequiredFieldValidator>

                                    </div>
                                    <div class="mb-2">
                                        <asp:Label ID="lblpaymentDate" runat="server" Text="Payment Date" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <asp:TextBox ID="txtpaymentDate" type="date" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="Enter Payment Date(mm/dd/yyyy)"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredpaymentDate" runat="server" ControlToValidate="txtpaymentDate" ForeColor="Red" Font-Bold="false" ValidationGroup="Amount" ErrorMessage="Enter Payment Date" Font-Size="12px"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="mb-2">
                                        <asp:Label ID="lblpaymentType" runat="server" Text="Payment Mode" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <asp:DropDownList ID="ddlpaymentType" runat="server" CssClass="form-control form-select" Placeholder="Select Payment">
                                            <asp:ListItem Value="0" Text="Nothing Selected"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Bank"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Cash"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldpaymentType" runat="server" ErrorMessage="Select Payment Mode" ControlToValidate="ddlpaymentType" ForeColor="Red" Font-Bold="false" ValidationGroup="Amount" InitialValue="0" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>
                                    </div>

                                </div>


                                <div class="col-md-6 col-sm-6 col-lg-6">

                                    <div class="mb-2">
                                        <asp:Label ID="lblAmountDue" runat="server" Text="" Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>

                                        <asp:Label ID="lbltransationid" runat="server" Text="Transaction ID" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="txttransationid" runat="server" placeholder="Enter Teansation ID" class="form-control"></asp:TextBox>

                                    </div>
                                    <div class="mb-2">
                                        <asp:Label ID="Label1" runat="server" Text="Leave a Note" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="txtnote" runat="server" CssClass="form-control" placeholder="Admin Note" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                        <asp:CheckBox ID="ChBoxEmail" runat="server" Checked="false" Text="Do Not Send Invoice Payment Recorded Email to Customer Contacts" Font-Bold="true" Font-Size="12px" AutoPostBack="true" />
                                    </div>
                                </div>
                                <hr />
                                <div class="mb-2">
                                    <asp:Button ID="btnSavePayment" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="Amount" OnClick="btnSavePayment_Click" Visible="true" />
                                    &nbsp;&nbsp;
                                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="Clear" OnClick="btnClear_Click" Visible="true" />
                                </div>
                                <div class="row">
                                    <div class="mb-2">
                                        <asp:Button ID="btnupdate" runat="server" Text="Update" CssClass="btn btn-sm btn-success" ValidationGroup="upAmount" OnClick="btnupdate_Click" Visible="false" />
                                        &nbsp;&nbsp;
                                        <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" ValidationGroup="DeleteAmount" OnClick="btncancel_Click" Visible="false" />
                                    </div>
                                </div>

                            </div>

                            <div class="row">

                                <h5>View Record Payment Details</h5>
                                <hr />
                                <div class="row">
                                    <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6">
                                        <asp:Button ID="btnEXPORTPayment" runat="server" Text="Export" CssClass="btn btn-sm btn-outline-success" OnClick="btnEXPORTPayment_Click" />
                                        <asp:Button ID="btnRELOADPayment" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="btnRELOADPayment_Click" />
                                        <asp:Button ID="btnVISIBILITYPayment" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="btnVISIBILITYPayment_Click" />
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="row">
                                    <asp:GridView ID="Gridpayment" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" ClientIDMode="Static" data-plugin="dataTable" Width="100%" Style="width: 100%"
                                        EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="Gridpayment_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Payment_Mode" SortExpression="Payment_Mode">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblPayment_Mode" runat="server" Text='<%# Bind("Payment_Mode") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPayment_Mode1" runat="server" Text='<%# Bind("Payment_Mode") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    <asp:Label ID="lblpayment2" runat="server" Text="Bank NEFT" CssClass="form-label"></asp:Label><br />
                                                    <asp:Label ID="lblpayment4" runat="server" Text="Transation ID:" CssClass="form-label"></asp:Label>
                                                    <asp:Label ID="lblpayment44" runat="server" Text='<%# Bind("Transation_ID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Payment_Date" SortExpression="Payment_date">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblPayment_date" runat="server" Text='<%# Bind("Payment_date") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPayment_date1" runat="server" Text='<%# Bind("Payment_date") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount_Recived" SortExpression="Amount_Recived">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblAmount_Recived" runat="server" Text='<%# Bind("Amount_Recived") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmount_Recived1" runat="server" Text='<%# Bind("Amount_Recived") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" SortExpression="Status" Visible="false">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstatus1" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEdit1" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEdit1_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                                </ItemTemplate>

                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDelete1" runat="server" CssClass="btn btn-sm btn-outline-danger" OnClick="btnDelete1_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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

    <style>
        .uploadOuter {
            text-align: center;
            padding: 20px;
            /*  strong {
            padding: 0 10px
            }*/
        }

        .dragBox {
            width: 350px;
            height: 150px;
            margin-left: -50px;
            margin-right: -36px;
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
                height: 51px;
                width: 62px;
                margin-bottom: 27px;
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
            var previewImg = document.createElement("img");
            previewImg.setAttribute("src", fileName);
            preview.innerHTML = "";
            preview.appendChild(previewImg);
        }
        function drag() {
            document.getElementById('uploadFile11').parentNode.className = 'dragging dragBox';
        }

        function drop() {
            document.getElementById('uploadFile11').parentNode.className = 'dragBox';
        }
    </script>
    <script>
        function toggleForm() {
            var AddReminder = document.getElementById('addexpenseRemainder');

            if (AddReminder.style.display === 'none') {
                AddReminder.style.display = 'block';
            } else {
                AddReminder.style.display = 'none';
            }
        }
    </script>
</asp:Content>
