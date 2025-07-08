<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="PurchaseOrderDetails.aspx.cs" Inherits="MatoshreeProject.PurchaseOrderDetails" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridSinglePurchaseOrderlist = $("#GridSinglePurchaseOrderlist").prepend($("<thead></thead>").append($("#GridSinglePurchaseOrderlist").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });
        });

        $(document).ready(function () {
            var GridViewAct1 = $("#GridViewAct1").prepend($("<thead></thead>").append($("#GridViewAct1").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });
        });

        $(document).ready(function () {
            var GridTask1 = $("#GridTask1").prepend($("<thead></thead>").append($("#GridTask1").find("tr:first"))).DataTable(
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
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="font-weight-medium mb-0">PurchaseOrder Details</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="PurchaseOrder.aspx">PurchaseOrder
                            </a>
                        </li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="#">PurchaseOrder Details</li>
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
            <div class="col-md-12 col-sm-12 col-lg-12">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="card">
                            <div class="card-body">
                                <div class="d-flex justify-content-between align-items-center">
                                    <asp:Button ID="btn_CreatePurchaseOrder" runat="server" Text="New Purchase Order" CssClass="btn btn-primary btn-sm" OnClick="btn_CreatePurchaseOrder_Click" />
                                    <div>
                                        <div class="bd-example">
                                            <div class="btn-group">
                                                <button class="btn btn-sm btn-primary" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="ti ti-filter"></i></button>
                                                <div class="dropdown-menu">
                                                    <asp:LinkButton ID="lnkbtnALL" Text="ALL" runat="server" CssClass="dropdown-item" OnClick="lnkbtnALL_Click"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkViewNotsend" Text="Not send" runat="server" CssClass="dropdown-item" OnClick="LinkViewNotsend_Click"></asp:LinkButton>

                                                    <%-- <asp:LinkButton ID="linkbtnInvoicewithoutpay" Text="Invoice with no payment records" runat="server" CssClass="dropdown-item" OnClick="linkbtnInvoicewithoutpay_Click"></asp:LinkButton>
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
                                            <asp:LinkButton ID="linkbtnMakebyCash" runat="server" Text="Make Payment by Cash" CssClass="dropdown-item" OnClick="linkbtnMakebyCash_Click"></asp:LinkButton>--%>
                                                </div>
                                            </div>
                                        </div>



                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>

                </asp:UpdatePanel>
            </div>
        </div>


        <div class="row">

            <div class="col-md-5 col-sm-5 col-xl-5 col-lg-5">

                <div class="card">
                    <div class="card-body">
                        <h5 class="font-weight-medium mt-3 mb-3">View Purchase Order Details</h5>
                        <hr />
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
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
                            <%-- <div class="col-md-4">
                                <!------PDF code--------->

                                <asp:Image ID="Image1" runat="server" Style="display: none; border: 1px solid #ccc" />

                                <asp:Label ID="lbladdCompany11" runat="server" Text="" CssClass="font-bold text-dark " Visible="false"></asp:Label>
                                <asp:Label ID="lbladdress11" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddCity1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddState1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddCountry1" runat="server" Text="," Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="Label2" runat="server" Text="PIN:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblphone" runat="server" Text="Phone:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblphoneNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblvat" runat="server" Text="VAT NO:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblVatNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblGSTNo1A" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <!------PDF code--------->

                            </div>--%>
                        </div>
                        <br />
                        <br />
                        <asp:GridView ID="GridSinglePurchaseOrderlist" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%" HeaderStyle-Font-Size="12px"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridSinglePurchaseOrderlist_RowDataBound">
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
                                <asp:TemplateField HeaderText="PONumber" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblPONumber" runat="server" Text='<%# Bind("PONumber") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPONumber1" runat="server" Text='<%# Bind("PONumber") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                        <asp:LinkButton ID="LinkPONumber" runat="server" Text='<%# Bind("PONumber") %>' Font-Size="12px" CssClass="text-info"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="POName" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblPOName" runat="server" Text='<%# Bind("POName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPOName1" runat="server" Text='<%# Bind("POName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount" SortExpression="Amount" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" SortExpression="Start_Date" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblPODate" runat="server" Text='<%# Bind("PODate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPODate1" runat="server" Text='<%# Bind("PODate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer" SortExpression="ContactVender" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblContactPerson" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblContactPerson1" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Project" SortExpression="BiddingDate" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblProjectName" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblProjectName1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ExpiryDate" SortExpression="POExpireDate" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblPOExpireDate" runat="server" Text='<%# Bind("POExpireDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPOExpireDate1" runat="server" Text='<%# Bind("POExpireDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>



                                <%--     <asp:TemplateField HeaderText="Status" SortExpression="BiddingDate" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblStatusNm" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatusbit" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                        <asp:Label ID="lblStatusbit1" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="StatusName" SortExpression="StatusName" HeaderStyle-Font-Size="12px" HeaderStyle-Width="200px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblStatusName" runat="server" Text='<%# Bind("StatusName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatusbit" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                        <asp:Label ID="lblStatusName1" runat="server" Text='<%# Bind("StatusName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control form-select" AutoPostBack="true" Font-Bold="false" Font-Size="12px" Style="width: 160px;"></asp:DropDownList>
                                        <%--  <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control form-select">
                                                    </asp:DropDownList>--%>
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


                <%--  </div>--%>
            </div>


            <div class="col-md-7 col-sm-7 col-xl-7 col-lg-7">
                <div id="SingINV" runat="server">
                    <div class="card">
                        <div class="card-body">
                            <ul class="nav nav-tabs" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" data-bs-toggle="tab" href="#PurchaseOrder" role="tab"><span class="hidden-sm-up"></span>
                                        <span class="hidden-xs-down fs-6px">PurchaseOrder</span></a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" data-bs-toggle="tab" href="#File" role="tab"><span class="hidden-sm-up"></span>
                                        <span class="hidden-xs-down fs-3px">File</span></a>
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
                                <%-- tab PurchaseOrder Start --%>
                                <div id="PurchaseOrder" class="tab-pane active" role="tabpanel">
                                    <div class="container">
                                        <div class="row">
                                            <div class="col-md-3 col-lg-3 col-sm-3 col-xs-3" style="margin-left: -21px">
                                              <asp:Button ID="btnStatus" runat="server" Text="" />
                                            </div>
                                            <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2">
                                            </div>
                                            <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4" style="margin-right: -22px">
                                                <asp:LinkButton ID="Linkbtnedit" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="Linkbtnedit_Click"><i class="ti ti-edit"></i></asp:LinkButton>&nbsp;

                                            <asp:LinkButton ID="lnkbtnpdf" runat="server" CssClass="btn btn-sm btn-outline-danger" OnClick="lnkbtnpdf_Click"><iconify-icon icon="ph:file-pdf"></iconify-icon></asp:LinkButton>
                                                &nbsp;

                                            <asp:LinkButton ID="LinkbtnMessage" runat="server" CssClass="btn btn-sm btn-outline-primary" data-bs-toggle="modal" data-bs-target="#ItemID"><iconify-icon icon="solar:letter-unread-linear" class="aside-icon"></iconify-icon></asp:LinkButton>
                                                <!-- Modal for Components-->

                                                <div class="modal fade" id="ItemID" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="scroll-long-inner-modal" aria-hidden="true">
                                                    <div class="modal-dialog modal-dialog-scrollable modal-lg">
                                                        <div class="modal-content shadow-none" style="box-shadow: none">
                                                            <div class="modal-header d-flex align-items-center">
                                                                <h4 class="modal-title" id="myLargeModalLabel">Send Email</h4>
                                                                <asp:Button ID="btnCloseModal" runat="server" Text="" CssClass="btn-close" data-bs-dismiss="modal" aria-label="Close" />
                                                            </div>
                                                            <div class="modal-body">
                                                                <div class="mb-2">
                                                                    <!-- CC Email Field -->
                                                                    <asp:Label ID="Label4" runat="server" Text="CC" CssClass="form-label"></asp:Label>
                                                                    <asp:TextBox ID="txtemailID" runat="server" CssClass="form-control" placeholder="Enter CC email" AutoCompleteType="Disabled" />

                                                                    <hr />

                                                                    <!-- Email Body Field -->
                                                                    <asp:Label ID="lblPreview" runat="server" Text="Preview Template" CssClass="form-label"></asp:Label>
                                                                    <asp:TextBox ID="txtEmailWrite" runat="server" CssClass="form-control"
                                                                        Text="I hope  you're doing well.
                                                                              I am writing to formally  confirm a purchase order.Please find the attached purchase order [PO Number] for your reference.
                                                                              Kindly review the details and confirm receipt of this order.
                                                                              If there are any discrepancies or additional information required, do not hesitate to contact me. 
                                                                              We look forward to your prompt confirmation and timely delivery.
                                                                              Thank you for your support and cooperation."
                                                                        TextMode="MultiLine" class="EditorNote" Rows="6" placeholder="Write your email here..." AutoCompleteType="Disabled" />

                                                                </div>
                                                            </div>
                                                            <div class="modal-footer">
                                                                <!-- Send Button -->
                                                                <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" CssClass="btn btn-sm btn-primary" />
                                                                &nbsp;&nbsp;
                                                                <!-- Close Button -->
                                                                <asp:Button ID="btnCloseModal1" runat="server" Text="Close" CssClass="btn btn-sm btn-danger" data-bs-dismiss="modal" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>


                                                <!-- Modal for Components-->
                                            </div>


                                            <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2" style="margin-left: -16px">
                                                <div class="bd-example">
                                                    <div class="btn-group">
                                                        <button class="btn btn-sm btn-light dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">More</button>
                                                        <asp:Button ID="Button1" runat="server" Style="display: none" />
                                                        <div class="dropdown-menu">
                                                            <asp:LinkButton ID="lnkbtnviewascustmer" Text="View Invoice As Customer" runat="server" CssClass="dropdown-item" OnClick="lnkbtnviewascustmer_Click"></asp:LinkButton>
                                                            <asp:LinkButton ID="linkbtnSendOverDue" runat="server" Text="Sent Overdue Notice" CssClass="dropdown-item" OnClick="linkbtnSendOverDue_Click"></asp:LinkButton>
                                                            <asp:LinkButton ID="lnkbtnsent" runat="server" Text="Mark as Sent" CssClass="dropdown-item" OnClick="lnkbtnsent_Click"></asp:LinkButton>
                                                            <asp:LinkButton ID="lnkbtnNotsend" Text="Not send" runat="server" CssClass="dropdown-item" OnClick="lnkbtnNotsend_Click"></asp:LinkButton>

                                                            <hr />
                                                            <asp:LinkButton ID="LinkStatusUnpaid" runat="server" Text="Unpaid" CssClass="dropdown-item" OnClick="LinkStatusUnpaid_Click"></asp:LinkButton>
                                                            <asp:LinkButton ID="LinkStatusPaid" runat="server" Text="Paid" CssClass="dropdown-item" OnClick="LinkStatusPaid_Click"></asp:LinkButton>
                                                            <asp:LinkButton ID="LinkStatusPartiallyPaid" runat="server" Text="Partially Paid" CssClass="dropdown-item btn btn-sm btn-success text-white" OnClick="LinkStatusPartiallyPaid_Click"></asp:LinkButton>
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


                                                <%--   <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="LinkbtnMessage"
                                                    CancelControlID="btnCloseemail" BackgroundCssClass="Background">
                                                </cc1:ModalPopupExtender>--%>

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

                                                                    <%--  <div class="mb-2">
                                                                        <asp:Button ID="btnSendEmail" runat="server" Text="Send Email" CssClass="btn btn-sm btn-primary" ValidationGroup="sendemail" OnClick="btnSendEmail_Click" />
                                                                        &nbsp;&nbsp;
                                                                        <asp:Button ID="btnCloseemail" runat="server" Text="Close" ValidationGroup="closee" CssClass="btn btn-sm btn-danger " />
                                                                    </div>--%>
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

                                                <asp:Label ID="lblURLname" runat="server" Text="This Invoice related to project:" Font-Size="12px" Visible="true"></asp:Label>
                                                <asp:Label ID="lblProjectNamenamee" runat="server" Text="" CssClass="text-info " Font-Size="13px"></asp:Label>
                                                <asp:Label ID="lblProjectNameId" runat="server" Text="" CssClass="text-info " Font-Size="13px" Visible="false"></asp:Label>
                                                <asp:Label ID="lblPoName" runat="server" Text="" CssClass="text-info " Font-Size="13px" Visible="false"></asp:Label>
                                                <asp:Label ID="lblPurchaseID" runat="server" Text="" CssClass="text-info " Font-Size="13px" Visible="false"></asp:Label>
                                            </div>
                                            <br />
                                            <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6 text-start ml-3 p-2">
                                                <asp:Label ID="lblid1" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:Label ID="Label3" runat="server" Text="" CssClass="text-info" Font-Size="12px"></asp:Label><br />
                                                <asp:Label ID="lblPurchaseOrderidNO" runat="server" Text="" CssClass="text-info" Font-Size="12px" Visible="false"></asp:Label><br />
                                                <asp:Label ID="lblPurchaseOrderid" runat="server" Text="" CssClass="text-info" Font-Size="12px"></asp:Label><br />

                                                <%-- <div class="col-md-4">--%>
                                                <%-- Company Address --%>

                                                <asp:Image ID="Image1" runat="server" Style="display: none; border: 1px solid #ccc" />

                                                <asp:Label ID="lbladdCompany11" runat="server" Text="" CssClass="form-label" Font-Size="12px"></asp:Label><br />
                                                <asp:Label ID="lbladdress11" runat="server" Text="" CssClass="" Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblcompanyaddCity1" runat="server" Text="" CssClass="" Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text="" CssClass="" Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblcompanyaddState1" runat="server" Text="" CssClass="" Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblcompanyaddCountry1" runat="server" Text="," Font-Size="12px"></asp:Label><br />
                                                <asp:Label ID="Label2" runat="server" Text="PIN:" Font-Size="12px" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                                <asp:Label ID="lblphone" runat="server" Text="Phone:" Font-Size="12px" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblphoneNo1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                                <asp:Label ID="lblvat" runat="server" Text="VAT NO:" Font-Size="12px" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblVatNo1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                                <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" Font-Size="12px" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblGSTNo1A" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                <%-- Company Address --%>

                                                <asp:Label ID="lblImgPath" runat="server" Text="" Visible="false"></asp:Label>

                                                <asp:Label ID="lblInvoiceno" runat="server" Text="" CssClass="form-label text-info" Font-Size="12px"></asp:Label><br />

                                            </div>
                                            <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6  text-end">
                                                <asp:Label ID="lblspace" runat="server" Text=""></asp:Label><br />
                                                <asp:Label ID="lblspace1" runat="server" Text=""></asp:Label><br />
                                                <asp:Label ID="lbladdcust1" runat="server" Text="To," CssClass="form-label "></asp:Label><br />
                                                <asp:Label ID="lblcustname" runat="server" Text="" CssClass="form-label text-info"></asp:Label><br />
                                                <%-- Client billing  Address --%>
                                                <asp:Label ID="lblblock" runat="server" Text="" Font-Size="12px"></asp:Label>


                                                <asp:Label ID="lbladdressLine1" runat="server" Text="" Font-Size="12px"></asp:Label>

                                                <asp:Label ID="lblcompanyaddCity" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                                <asp:Label ID="lblcompanyaddDistrict" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblcompanyaddState" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblcompanyaddZIPCode1" runat="server" Text="PIN :" Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblcompanyaddZIPCode" runat="server" Text="" Font-Size="12px"></asp:Label><br />


                                                <br />
                                                <%--  <asp:Label ID="lblgstnoA" runat="server" Text="GST No:" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblgstno1" runat="server" Text="" Font-Size="12px"></asp:Label><br />--%>

                                                <asp:Label ID="lblPOdate" runat="server" Text="PO Date:" CssClass="form-label" Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblPOdate1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                                <asp:Label ID="lblPOExpiry_Date" runat="server" Text="Expiry Date:" CssClass="form-label" Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblPOExpiry_Date1" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                                <asp:Label ID="lblsaleagent" runat="server" Text="Sale Agent:" CssClass="form-label" Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblsaleagentName" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                                <asp:Label ID="lblprojectname" runat="server" Text="Project Name:" CssClass="form-label" Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblPOprojectname" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                <asp:Label ID="lblEmailPO" runat="server" Text="" Visible="false"></asp:Label><br />
                                                <asp:Label ID="lblsaleagent1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="container">
                                        <div class='row'>
                                            <h5>Purchase Order Procurement List</h5>
                                            <hr />
                                            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 p-2">
                                                <!-- PurchaseOrder Procurement Gridview Start-->

                                                <div class="table-responsive">
                                                    <asp:GridView ID="GridProcurement" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                        ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="false" DataKeyNames="ID">
                                                        <Columns>
                                                            <asp:TemplateField Visible="false">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblPID1" runat="server" Text="ID" CssClass="form-label"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblProdID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblProductID1" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
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
                                                                <%--   <FooterTemplate>
                                                                    <asp:TextBox ID="txtProduct" runat="server" Text="" CssClass="form-control" Placeholder="Product"></asp:TextBox>
                                                                    <br />
                                                                    <asp:RequiredFieldValidator ID="rfv_InvoiceItemPC1" ControlToValidate="txtProduct" Display="Dynamic" runat="server" ErrorMessage="Enter Product" Font-Size="12px" ForeColor="Red" ValidationGroup="ProductItem"></asp:RequiredFieldValidator>
                                                                </FooterTemplate>--%>
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
                                                                <%--  <FooterTemplate>
                                                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Text="" CssClass="form-control" Placeholder="Description"></asp:TextBox>
                                                                </FooterTemplate>--%>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Width="60px">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblQuantity" runat="server" Text="Quantity" CssClass="form-label"></asp:Label>
                                                                </HeaderTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtQty1" runat="server" Text='<%# Bind("Quantity") %>' CssClass="form-control" Placeholder="Quantity" TextMode="Number" Style="width: 60px" AutoPostBack="true"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblQuantity1" runat="server" Text='<%# Bind("Quantity") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                                <%-- <FooterTemplate>
                                                                    <asp:TextBox ID="txtQty" runat="server" Text="1" CssClass="form-control" Placeholder="Product Quantity" TextMode="Number" Style="width: 60px" AutoPostBack="true"></asp:TextBox>
                                                                    <br />
                                                                    <asp:RequiredFieldValidator ID="rfv_QtyPC" ControlToValidate="txtQty" Display="Dynamic" runat="server" ErrorMessage="Enter Product Quantity" ForeColor="Red" Font-Size="12px" ValidationGroup="ProductItem"></asp:RequiredFieldValidator>
                                                                </FooterTemplate>--%>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Width="150px">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblPrice" runat="server" Text="Price" CssClass="form-label"></asp:Label>
                                                                </HeaderTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtPrice1" runat="server" Text='<%# Bind("Price") %>' CssClass="form-control" Placeholder="Product Price" TextMode="Number" Style="width: 150px" AutoPostBack="true"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPrice1" runat="server" Text='<%# Bind("Price") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                                <%--   <FooterTemplate>
                                                                    <asp:TextBox ID="txtPrice" runat="server" Text="" CssClass="form-control" Placeholder="Product Price" AutoPostBack="true"></asp:TextBox>
                                                                    <br />
                                                                    <asp:RequiredFieldValidator ID="rfv_Price" ControlToValidate="txtPrice" Display="Dynamic" runat="server" ErrorMessage="Enter Product Price" ForeColor="Red" Font-Size="12px" ValidationGroup="ProductItem"></asp:RequiredFieldValidator>
                                                                </FooterTemplate>--%>
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
                                                                <%--  <FooterTemplate>
                                                                    <asp:Label ID="lblHSN" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                                                    <asp:Label ID="lblAmontP" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </FooterTemplate>--%>
                                                            </asp:TemplateField>
                                                            <%--     <asp:TemplateField HeaderStyle-Width="110px">
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
                                                                    <asp:LinkButton ID="btnAddProcurement" runat="server" CausesValidation="false" CssClass="btn btn-sm btn-rounded btn-info" Text="" TabIndex="9" ValidationGroup="ProductItem"><i class="ti ti-check fs-4"></i></asp:LinkButton>
                                                                    &nbsp;&nbsp;&nbsp;
                                                                            <asp:LinkButton ID="btnCancelProcurement" runat="server" CausesValidation="false" CssClass="btn btn-sm btn-rounded btn-danger" ValidationGroup="CanccelProductItem" Text=""><i class=" ti ti-clear-all"></i></asp:LinkButton>

                                                                </FooterTemplate>
                                                            </asp:TemplateField>--%>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>

                                                <!-- PurchaseOrder Procurement Gridview End-->
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6"></div>
                                                <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6 text-end">
                                                    <i class="ti ti-arrow-autofit-right text-info"></i>&nbsp;<asp:Label ID="lblTotalProcurement" runat="server" Text="Total Purchase Order Amount :" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp; &nbsp;
                                    <asp:Label ID="lblTotalAmountProcurement" runat="server" Text="" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <br />
                                    <div class="container">
                                        <div class='row'>
                                            <h5>Purchase Order Services List
                                            </h5>
                                            <hr />
                                            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 p-2">
                                                <!-- PurchaseOrder Service Gridview Start-->
                                                <div class="row">
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="GridServicesList" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                            ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="false" DataKeyNames="ID">

                                                            <Columns>
                                                                <asp:TemplateField Visible="false">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblPID1" runat="server" Text="ID" CssClass="form-label"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblServiceID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <%--       <FooterTemplate>
                                                                        <asp:Label ID="lblServiceID1" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </FooterTemplate>--%>
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
                                                                    <%--  <FooterTemplate>
                                                                        <asp:TextBox ID="txtServices" runat="server" Text="" CssClass="form-control" Placeholder="Services"></asp:TextBox>
                                                                        <br />
                                                                        <asp:RequiredFieldValidator ID="rfv_InvoiceItem3" ControlToValidate="txtServices" Display="Dynamic" runat="server" ErrorMessage="Enter Services" Font-Size="12px" ForeColor="Red" ValidationGroup="Services"></asp:RequiredFieldValidator>
                                                                    </FooterTemplate>--%>
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
                                                                    <%-- <FooterTemplate>
                                                                        <asp:TextBox ID="txtDuration" runat="server" Text="1" CssClass="form-control" Placeholder="Duration" TextMode="Number" Style="width: 60px"></asp:TextBox>
                                                                        <br />
                                                                        <asp:RequiredFieldValidator ID="rfv_Duration23" ControlToValidate="txtDuration" Display="Dynamic" runat="server" ErrorMessage="Enter Service Duration" ForeColor="Red" Font-Size="12px" ValidationGroup="Services"></asp:RequiredFieldValidator>
                                                                    </FooterTemplate>--%>
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
                                                                    <%-- <FooterTemplate>
                                                                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Text="" CssClass="form-control" Placeholder="Description"></asp:TextBox>
                                                                    </FooterTemplate>--%>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="60px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblQuantity" runat="server" Text="Quantity" CssClass="form-label"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtQtyService1" runat="server" Text='<%# Bind("Quantity") %>' CssClass="form-control" Placeholder="Quantity" TextMode="Number" Style="width: 60px" AutoPostBack="true"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblQuantity1" runat="server" Text='<%# Bind("Quantity") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <%-- <FooterTemplate>
                                                                        <asp:TextBox ID="txtServiceFoterrQty" runat="server" Text="1" CssClass="form-control" Placeholder="Quantity" TextMode="Number" Style="width: 60px" AutoPostBack="true"></asp:TextBox>
                                                                        <br />
                                                                        <asp:RequiredFieldValidator ID="rfv_Qty3" ControlToValidate="txtServiceFoterrQty" Display="Dynamic" runat="server" ErrorMessage="Enter Quantity" ForeColor="Red" Font-Size="12px" ValidationGroup="Services"></asp:RequiredFieldValidator>
                                                                    </FooterTemplate>--%>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="150px">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblPrice" runat="server" Text="Price" CssClass="form-label"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtPrice1" runat="server" Text='<%# Bind("Price") %>' CssClass="form-control" Placeholder="Service Price" AutoPostBack="true"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPrice1" runat="server" Text='<%# Bind("Price") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <%-- <FooterTemplate>
                                                                        <asp:TextBox ID="txtServicePrice" runat="server" Text="" CssClass="form-control" Placeholder="Service Price" AutoPostBack="true"></asp:TextBox>
                                                                        <br />
                                                                        <asp:RequiredFieldValidator ID="rfv_Price3" ControlToValidate="txtServicePrice" Display="Dynamic" runat="server" ErrorMessage="Enter Service Price" ForeColor="Red" Font-Size="12px" ValidationGroup="Services"></asp:RequiredFieldValidator>
                                                                    </FooterTemplate>--%>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblAmontname" runat="server" Text="Amount" CssClass="form-label"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblEditAmontService" runat="server" Text='<%# Bind("TotalAmont") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAmont1" runat="server" Text='<%# Bind("TotalAmont") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <%--  <FooterTemplate>
                                                                        <asp:Label ID="lblAmont" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </FooterTemplate>--%>
                                                                </asp:TemplateField>
                                                                <%--  <asp:TemplateField HeaderStyle-Width="110px">
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
                                                                        <asp:LinkButton ID="btnAddServices" runat="server" CausesValidation="false" CssClass="btn btn-sm btn-rounded btn-info" Text="" TabIndex="9" ValidationGroup="Service"><i class="ti ti-check"></i></asp:LinkButton>
                                                                        &nbsp;&nbsp;&nbsp;
                                                                            <asp:LinkButton ID="btnCancelServices" runat="server" CausesValidation="false" CssClass="btn btn-sm btn-rounded btn-danger" ValidationGroup="CanccelService" Text=""><i class=" ti ti-clear-all"></i></asp:LinkButton>

                                                                    </FooterTemplate>
                                                                </asp:TemplateField>--%>
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
                                                    <h5>Purchase Order Costing</h5>
                                                    <hr />
                                                    <div class="row">
                                                        <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6">
                                                            <%--  <i class="ti ti-star text-info"></i>&nbsp;<asp:Label ID="lblDuration" runat="server" Text="Purchase Order Complete Duration:" Font-Size="12px" Font-Bold="true" ForeColor="Blue"></asp:Label>&nbsp; &nbsp;
                                                                       <asp:Label ID="lblDurationDays" runat="server" Text="" Font-Size="12px"></asp:Label>--%>
                                                        </div>
                                                        <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6 text-end">
                                                            <i class="ti ti-star text-info"></i>&nbsp;<asp:Label ID="lblTotalcost" runat="server" Text="Purchase Order Cost :" Font-Size="12px" Font-Bold="true" ForeColor="Blue"></asp:Label>&nbsp; &nbsp;
                                                                       <asp:Label ID="lblTotalAmountProcu" runat="server" Text="" Font-Size="12px"></asp:Label>

                                                            &nbsp;
                                                                    <asp:Label ID="lblServicelistTotal" runat="server" Text="" Font-Size="12px"></asp:Label>

                                                            <br />
                                                            <i class="ti ti-star text-info"></i>&nbsp;<asp:Label ID="lblTotalCost5" runat="server" Text="Total Purchase Order Cost :" Font-Size="12px" Font-Bold="true" ForeColor="Blue"></asp:Label>&nbsp; &nbsp;
                                                                    <asp:Label ID="lblTotalProjectCost" runat="server" Text="" Font-Size="12px" ForeColor="Blue"></asp:Label>

                                                        </div>
                                                    </div>
                                                    <br />
                                                </div>
                                                <!-- PurchaseOrder Service Gridview End-->
                                            </div>
                                        </div>

                                    </div>

                                    <br />

                                    <div class="container">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:Label ID="lblNote" runat="server" Text="Note :" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblNote1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                                <br />
                                                <br />
                                                <asp:Label ID="lblTermsCondition1" runat="server" Text="Terms & Condition :" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lbltermsandcodition" runat="server" Text="" Font-Size="12px"></asp:Label><br />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- tab PurchaseOrder end --%>

                                <%-- tab File Start --%>
                                <div id="File" class="tab-pane p-20" role="tabpanel">
                                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>--%>
                                    <asp:Label ID="lblLeadIdd" runat="server" Text="" CssClass="form-label" Visible="false"></asp:Label>
                                    <asp:Label ID="lblMainname" runat="server" Text="" CssClass="form-label" Visible="false"></asp:Label>
                                    <asp:Label ID="lblNameLead" runat="server" Text=""></asp:Label>

                                    <div class="p-20">
                                        <div class="row">
                                            <div class="col-md-8 col-sm-8 col-lg-8  col-xs-8">

                                                <div class="mb-2">
                                                    <asp:Label ID="lblAttachment" runat="server" Text="Attachment" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label>


                                                    <div class="input-group">
                                                        <asp:FileUpload ID="FileUpload" runat="server" Text="" CssClass="form-control mdi-file-import" />
                                                        <asp:Button ID="Btn_POUpload" runat="server" Text="Upload" CssClass="btn btn-primary btn-sm " OnClick="Btn_POUpload_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4 col-sm-4 col-lg-4  col-xs-4">
                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="mb-2">
                                                <asp:Label ID="lbltxtArea" runat="server" Text="Description" CssClass="form-label" Visible="false"></asp:Label>

                                                <asp:TextBox ID="txtArea" runat="server" placeholder="Description" TextMode="MultiLine" class="form-control" Visible="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 col-lg-12">
                                                <asp:Label ID="lbdLeaveMID" runat="server" Text="" Font-Size="12px" Font-Bold="false" Visible="true"></asp:Label>

                                                <asp:GridView ID="GridLeadFile" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                    ClientIDMode="Static" ShowHeader="false" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblLeadFileId" runat="server" Text="FileName" Font-Size="12px" Font-Bold="false" Visible="false"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblfileid" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblLeadFileName" runat="server" Font-Size="12px" Text="FileName" Font-Bold="false"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLeadFileName1" runat="server" Text='<%# Bind("FileName") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Download" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnDownload" runat="server" CausesValidation="false" CommandName="Delete" CssClass="btn btn-sm btn-success " OnClick="btnDownload_Click" Visible="false"><i class="ti ti-download"  ></i></asp:LinkButton>
                                                            </ItemTemplate>

                                                            <EditItemTemplate>
                                                            </EditItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnDeleteLeadFile" runat="server" CausesValidation="false" CommandName="Delete" OnClick="btnDeleteLeadFile_Click" CssClass="btn btn-sm btn-danger" Visible="false" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
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
                                    <%--  </ContentTemplate>

                                    </asp:UpdatePanel>--%>
                                </div>
                                <%-- tab File end --%>

                                <%-- tab Task Start --%>
                                <div id="Task" class="tab-pane p-20" role="tabpanel">
                                    <asp:UpdatePanel ID="UpdatePanelTask" runat="server">
                                        <ContentTemplate>
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
                                                                    <asp:Button ID="btnReloadTask" runat="server" Text="Reload" CssClass="btn btn-sm btn-sm btn-outline-info" OnClick="btnReloadTask_Click" />
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
                                                                            <asp:BulletedList ID="bulletlist1" runat="server" BulletStyle="Circle" CssClass="" Width="170px" Font-Size="12px">
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
                                        </ContentTemplate>

                                    </asp:UpdatePanel>
                                </div>
                                <%-- tab Task end --%>

                                <%-- tab Reminder Start --%>
                                <div class="tab-pane" id="Reminder" role="tabpanel">
                                    <asp:UpdatePanel ID="UpdatePanelRemainder" runat="server">
                                        <ContentTemplate>
                                            <div class="p-20">
                                                <div class="row">
                                                    <div class="col-md-12  col-sm-12 col-ld-12 col-xs-12">
                                                        <asp:LinkButton ID="lnkbtnCreateRemainder" runat="server" ValidationGroup="btn14" OnClick="lnkbtnCreateRemainder_Click" CssClass="btn btn-sm font-medium btnmodalPopup btn-outline-info btn-sm " data-bs-toggle="modal"
                                                            data-bs-target="#ReminderID"> <i class="ti ti-bell"></i>Set Lead Reminder</asp:LinkButton>

                                                        <div class="modal fade" id="ReminderID" data-bs-backdrop="static"
                                                            data-bs-keyboard="false" tabindex="-1" aria-labelledby="scroll-long-inner-modal"
                                                            aria-hidden="true">
                                                            <div class="modal-dialog modal-dialog-scrollable">
                                                                <div class="modal-content">
                                                                    <div class="modal-header d-flex align-items-center">
                                                                        <h4 class="modal-title" id="myLargeModalLabel1"></h4>
                                                                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                                                    </div>
                                                                    <div class="modal-body">

                                                                        <h5 class="card-title" style="color: blue">Add Reminder</h5>
                                                                        <hr />

                                                                        <div id="craeteButton" runat="server" visible="true">

                                                                            <div class="mb-2">

                                                                                <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                                                    <asp:Label ID="lblDateNotified" runat="server" CssClass="form-label" sText="Date To be Notified"></asp:Label>
                                                                                    <br />
                                                                                    <asp:Label ID="lblRID" runat="server" Text="" Visible="false"></asp:Label>
                                                                                    <asp:TextBox ID="txtDateNotified" type="DateTime-Local" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="Enter Date"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="mb-2">

                                                                                <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                                                    <asp:Label ID="lblSetRemainder" runat="server" CssClass="form-label" Text="Set To Remainder"></asp:Label>
                                                                                    <br />

                                                                                    <asp:DropDownList ID="ddlreminderMember" runat="server" CssClass="form-control">
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </div>

                                                                            <div class="mb-2">
                                                                                <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                                                    <asp:Label ID="ModalDescription" runat="server" CssClass="form-label" Text="Description"></asp:Label>
                                                                                    <br />

                                                                                    <asp:TextBox ID="TextBox1" TextMode="MultiLine" CssClass="form-control border" Style="display: inline-block;" runat="server" placeholder="Enter Description"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <div class="mb-2">

                                                                                <div class="checkbox checkbox-primary">
                                                                                    <asp:CheckBox ID="chksetRemainderforEmail" runat="server" CssClass="w-50 h-50" />
                                                                                    <asp:Label ID="lblsetRemainderforEmail" runat="server" Text="Send also an email for this reminder"></asp:Label>

                                                                                </div>
                                                                            </div>

                                                                            <div class="mb-2">

                                                                                <div class="row">

                                                                                    <div class="col-md-6 col-sm-6 col-ld-6 col-xs-6 text-left">
                                                                                        <asp:Button ID="btnCreateRemainder" runat="server" CssClass="btn btn-info btn-sm " Text="Create Reminder" OnClick="btnCreateRemainder_Click" />
                                                                                        &nbsp
                                                                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" OnClick="btnClear_Click" />
                                                                                        <br />
                                                                                        &nbsp&nbsp
                                                                                <asp:Button ID="btnupdateLeadReminder" runat="server" Text="Update" CssClass="btn btn-sm btn-success" OnClick="btnupdateLeadReminder_Click" Visible="false" />
                                                                                        &nbsp
                                                                           <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-sm btn-danger" OnClick="btnClose_Click" Visible="false" />
                                                                                    </div>
                                                                                    <div class="col-md-6 col-sm-6 col-ld-6 col-xs-6"></div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <br />
                                                                    <div class="modal-footer">
                                                                        <%--  <button type="Button" class="btn btn-sm btn-danger" data-bs-dismiss="modal">Close</button>--%>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-lg-12 col-12 col-xs-12">
                                                        <h5 class="mb-3">View Reminders Details</h5>

                                                        <hr />

                                                        <div class="row">
                                                            <div class="col-md-10 col-lg-10 col-sm-10 col-xs-10">
                                                                <div class="bd-example">
                                                                    <div class="btn-group">
                                                                        <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                                                        <asp:Button ID="Button3" runat="server" Style="display: none" />
                                                                        <div class="dropdown-menu">
                                                                            <asp:LinkButton ID="LnkBtnReminderExcel" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="LnkBtnReminderExcel_Click"></asp:LinkButton>
                                                                            <asp:LinkButton ID="LnkBtnReminderPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="LnkBtnReminderPDF_Click"></asp:LinkButton>

                                                                        </div>
                                                                    </div>
                                                                    <asp:Button ID="LnkBtnReminderVisibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="LnkBtnReminderVisibility_Click" />

                                                                    <asp:Button ID="LnkBtnReminderReload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="LnkBtnReminderReload_Click" />


                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                                                            </div>
                                                        </div>

                                                        <br />
                                                        <br />
                                                        <asp:GridView ID="GridLeadReminder" runat="server" ScrollBars="Both" CssClass="table border table-hover table-bordered text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="R_ID" OnRowDataBound="GridLeadReminder_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("R_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("R_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescription1" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                                <asp:TemplateField HeaderText="NotifyDate" SortExpression="NotifyDate" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblnotifyDate" runat="server" Text='<%# Bind("NotifyDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblnotifyDate1" runat="server" Text='<%# Bind("NotifyDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Remainder" SortExpression="SetToReminder" HeaderStyle-Font-Size="12px">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblSetToReminder" runat="server" Text='<%# Bind("SetToReminder") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSetToReminder1" runat="server" Text='<%# Bind("SetToReminder") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                                <asp:TemplateField HeaderText="status" SortExpression="status" HeaderStyle-Font-Size="12px" Visible="false">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblStatuse" runat="server" Text='<%# Bind("status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStatuse1" runat="server" Text='<%# Bind("status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEditReminder" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditReminder_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDeleteReminder" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteReminder_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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
                                        </ContentTemplate>
                                        <Triggers>
                                            <%--   <asp:AsyncPostBackTrigger ControlID="ddllocationstate" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddllocationdistrict" EventName="SelectedIndexChanged" />--%>
                                            <asp:PostBackTrigger ControlID="lnkbtnCreateRemainder" />
                                            <asp:PostBackTrigger ControlID="btnClear" />
                                            <asp:PostBackTrigger ControlID="btnupdateLeadReminder" />
                                            <asp:PostBackTrigger ControlID="btnCreateRemainder" />
                                            <asp:PostBackTrigger ControlID="btnClose" />
                                            <%-- <asp:AsyncPostBackTrigger ControlID="ddllocationcity" EventName="SelectedIndexChanged" />--%>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <%-- tab Reminder end --%>

                                <%-- tab ActivityLog Start --%>
                                <div id="ActivityLogs" class="tab-pane p-20" role="tabpanel">

                                    <h5>Activity Log</h5>
                                    <hr />

                                    <div class="todo-widget scrollable" style="height: 600px">
                                        <asp:GridView ID="GridViewAct1" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" Style="width: 100%" AutoGenerateColumns="false" CellPadding="4"
                                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" OnRowDataBound="GridViewAct1_RowDataBound">
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
                                <%-- tab ActivityLog end --%>

                                <%-- tab Notes Start --%>
                                <div id="Notes" class="tab-pane p-20" role="tabpanel">
                                    <div class="container-fluid">
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 col-ld-12">

                                                <h5 class="font-weight-medium mb-0">Note</h5>
                                                <hr />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12 col-ld-12">
                                                        <asp:Label ID="lblNoteDesc" runat="server" Text="" CssClass="text-info " Font-Size="13px"></asp:Label>
                                                        <asp:TextBox ID="txtNoteDescription" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>

                                                        <br />
                                                        <asp:Button ID="btnNotesSave" runat="server" Text="Save" CssClass="btn btn-sm btn-primary  fa-align-right" OnClick="btnNotesSave_Click" />&nbsp;&nbsp;
                                                                 <asp:Button ID="btnNoteClear" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger fa-align-right" OnClick="btnNoteClear_Click" />
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>

                                <%-- tab Notes end --%>
                            </div>

                            <%--   <div class="mb-2">
                                                        <asp:Button ID="btnSaveRemainder" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="Remainder" OnClick="btnSaveRemainder_Click" />
                                                        &nbsp;&nbsp;
                                                    <asp:Button ID="btnClearRemainder" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" OnClick="btnClearRemainder_Click" ValidationGroup="Remainder1" />

                                                        <asp:Button ID="btnUpdateReminder" runat="server" Text="Update" CssClass="btn btn-sm btn-success" ValidationGroup="updateRemainder" OnClick="btnUpdateReminder_Click" Visible="false" />
                                                        &nbsp;&nbsp;
                                                    <asp:Button ID="btnCancelReminder" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" ValidationGroup="cacelRemainder" OnClick="btnCancelReminder_Click" Visible="false" />
                                                    </div>--%>
                        </div>
                    </div>

                    <%-- <hr />--%>
                    <div id="Timesheet" runat="server" visible="true">
                        <asp:Label ID="lblRemainderInfoWGV" runat="server" Text="" Visible="false"></asp:Label>
                        <br />
                        <%-- <h5 class="font-weight-medium mb-0">View Reminder Details</h5>--%>
                        <hr />

                        <%--  <asp:Button ID="btnexport" runat="server" Text="Export" CssClass="btn btn-sm btn-outline-success" OnClick="btnexport_Click" />
                                                <asp:Button ID="btnVisibilityRemainder" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="btnVisibilityRemainder_Click" />

                                                <asp:Button ID="btnReload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="btnReload_Click" />
                                                <br />
                                                <br />--%>

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
                                <%--  <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
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
                                                        </asp:TemplateField>--%>
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



</asp:Content>
