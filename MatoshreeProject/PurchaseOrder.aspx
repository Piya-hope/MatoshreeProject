<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="PurchaseOrder.aspx.cs" Inherits="MatoshreeProject.PurchaseOrder" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridPurchaseOrderlist = $("#GridPurchaseOrderlist").prepend($("<thead></thead>").append($("#GridPurchaseOrderlist").find("tr:first"))).DataTable(
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
        <h5 class="font-weight-medium mb-0">Purchase Order</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="#">LEGAL
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="WorkOrder.aspx">Purchase Order</li>
            </ol>
        </nav>
        <br />


        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="row">
                    <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                        <div id="addnew" runat="server">
                            <asp:Button ID="btn_CreatePurchaseOrder" runat="server" Text="New Purchase Order" CssClass="btn btn-primary btn-sm" OnClick="btn_CreatePurchaseOrder_Click" />
                            <hr />
                        </div>
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

                <h5 class="fs-5 mt-3 mb-3">Purchase Order Summary</h5>
                <div class="row">
                  <%--  <div class="col-lg-3 col-md-6">
                        <div class="card border-bottom border-info">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblWorkOrdernoCount" CssClass="text-primary text-dark" runat="server" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-info mb-0">
                                            <asp:Label ID="lblWorkOrdernoCount1" runat="server" Text="Purchase Order" Font-Size="14px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-info display-6">
                                            <i class="ti ti-file-text"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>

                     <div class="col-md-3 col-sm-3 col-lg-3 border-right">
                           <div class="card border-bottom border-info">
                            <div class="card-body">
                                <h6 class="card-title mb-0"><asp:Label ID="Label3" runat="server" Text="Purchase Order" CssClass="text-info" Font-Size="14px"></asp:Label></h6>
                                     <asp:Label ID="lblTotalPurchaseOrderCount" runat="server" Text="" Visible="false" ForeColor="Blue" Font-Size="14px"></asp:Label>
                                <br />
                                <div class="text-right">
                                    <asp:Label ID="lblPurchaseOrder" runat="server" Text="" ForeColor="Blue" Font-Size="14px"></asp:Label>

                                    <asp:Label ID="lblPercentPurchaseOrder" runat="server" Text="" CssClass="fa-pull-right"  Font-Size="14px"></asp:Label>

                                </div>
                                <div class="progress mt-3">
                                    <div class="progress-bar progress-bar-striped bg-info" role="progressbar" aria-valuenow="90" aria-valuemin="0" aria-valuemax="100" id="purchaseOrderid" runat="server"></div>
                                </div>
                            </div>
                        </div>
                    </div>

                     <div class="col-md-2 col-sm-2 col-lg-2 border-right">
                           <div class="card border-bottom border-success">
                            <div class="card-body">
                                <h6 class="card-title mb-0"><asp:Label ID="Label6" runat="server" Text="Accept" CssClass="text-success" Font-Size="14px"></asp:Label></h6>

                                <br />
                                <div class="text-right">
                                    <asp:Label ID="lblAccepted" runat="server" Text="" ForeColor="Blue" Font-Size="14px"></asp:Label>

                                    <asp:Label ID="lblPercentAccepted" runat="server" Text="" CssClass="fa-pull-right"  Font-Size="14px"></asp:Label>

                                </div>
                                <div class="progress mt-3">
                                    <div class="progress-bar progress-bar-striped bg-success" role="progressbar" aria-valuenow="90" aria-valuemin="0" aria-valuemax="100" id="ProgressPercentAccept" runat="server"></div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%-- <div class="col-lg-3 col-md-6">
                        <div class="card border-bottom border-success">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="Label1" CssClass="text-primary text-dark" runat="server" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-success mb-0">
                                            <asp:Label ID="Label2" runat="server" Text=" Accept" Font-Size="14px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-success display-6">
                                            <i class="ti ti-file-text"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                      <div class="col-md-2 col-sm-2 col-lg-2 border-right">
                           <div class="card border-bottom border-danger">
                            <div class="card-body">
                                <h6 class="card-title mb-0"><asp:Label ID="Label1" runat="server" Text="Decline" CssClass="text-danger" Font-Size="14px"></asp:Label></h6>
                                <br />
                                <div class="text-right">
                                    <asp:Label ID="lblDeclined" runat="server" Text="" ForeColor="Blue" Font-Size="14px"></asp:Label>

                                    <asp:Label ID="lblDeclinedPercent" runat="server" Text="" CssClass="fa-pull-right"  Font-Size="14px"></asp:Label>

                                </div>
                                <div class="progress mt-3">
                                    <div class="progress-bar progress-bar-striped bg-danger" role="progressbar" aria-valuenow="90" aria-valuemin="0" aria-valuemax="100" id="PgBarPurchaseOrderDecline" runat="server"></div>
                                </div>
                            </div>
                        </div>
                    </div>
              <%--      <div class="col-lg-3 col-md-6">
                        <div class="card border-bottom border-warning">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblDeclineCount" runat="server" CssClass="text-center text-dark" Font-Size="16px" Font-Bold="true"></asp:Label></h2>
                                        <h6 class="fw-medium text-warning mb-0">
                                            <asp:Label ID="lblDeclineCount1" runat="server" Text="Decline" CssClass="text-warning" Font-Size="14px" Font-Bold="true"></asp:Label></h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-warning display-6">
                                            <i class="ti ti-file-alert"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>

                      <div class="col-md-2 col-sm-2 col-lg-2 border-right">
                           <div class="card border-bottom border-warning">
                            <div class="card-body">
                                <h6 class="card-title mb-0"><asp:Label ID="LabelOverDue" runat="server" Text="OverDue" CssClass="text-warning" Font-Size="14px"></asp:Label></h6>
                                <br />
                                <div class="text-right">
                                    <asp:Label ID="lblPurchaseOrderOverDue" runat="server" Text="" ForeColor="Blue" Font-Size="14px"></asp:Label>

                                    <asp:Label ID="lblPurchaseOrderDuePercent" runat="server" Text="" CssClass="fa-pull-right"  Font-Size="14px"></asp:Label>

                                </div>
                                <div class="progress mt-3">
                                    <div class="progress-bar progress-bar-striped bg-warning" role="progressbar" aria-valuenow="90" aria-valuemin="0" aria-valuemax="100" id="PgBarPurchaseOrderOverDue" runat="server"></div>
                                </div>
                            </div>
                        </div>
                    </div>

                         <div class="col-md-3 col-sm-3 col-lg-3 border-right">
                           <div class="card border-bottom border-dark">
                            <div class="card-body">
                                <h6 class="card-title mb-0"><asp:Label ID="Label10" runat="server" Text="Draft" CssClass="text-dark" Font-Size="14px"></asp:Label></h6>
                                <br />
                                <div class="text-right">
                                    <asp:Label ID="lblPurchaseOrderDraft" runat="server" Text="" ForeColor="Blue" Font-Size="14px"></asp:Label>

                                    <asp:Label ID="lblPurchaseOrderDraftPercent" runat="server" Text="" CssClass="fa-pull-right"  Font-Size="14px"></asp:Label>

                                </div>
                                <div class="progress mt-3">
                                    <div class="progress-bar progress-bar-striped bg-dark" role="progressbar" aria-valuenow="90" aria-valuemin="0" aria-valuemax="100" id="PgBarPurchaseOrderDraft" runat="server"></div>
                                </div>
                            </div>
                        </div>
                    </div>

                <%--    <div class="col-md-2 col-sm-2 col-lg-2">
                      <div class="card border-bottom border-dark">
                            <div class="card-body">
                                <h6 class="card-title mb-0"><asp:Label ID="LabelDraft" runat="server" Text="Draft" CssClass="text-dark" Font-Size="14px"></asp:Label></h6>
                                <br />
                                <div class="text-right">
                                    <asp:Label ID="lblInvoiceDraft" runat="server" Text="" ForeColor="Blue" Font-Size="14px"></asp:Label>

                                    <asp:Label ID="lblInvoiceDraftPercent" runat="server" Text="" CssClass="fa-pull-right"  Font-Size="14px"></asp:Label>
                                </div>
                                <div class="progress mt-3">
                                    <div class="progress-bar progress-bar-striped bg-dark" role="progressbar" aria-valuenow="90" aria-valuemin="0" aria-valuemax="100" id="PgBarInvoiceDraft" runat="server"></div>
                                </div>
                            </div>
                        </div>
                    </div>--%>

                    <%-- <div class="col-lg-3 col-md-6">
                        <div class="card border-bottom border-success">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblAcceptCount" runat="server" CssClass="text-center text-dark" Font-Size="16px" Font-Bold="true"></asp:Label><br />
                                        </h2>
                                        <h6 class="fw-mediumb text-success mb-0">
                                            <asp:Label ID="lblAcceptCount1" runat="server" Text="Accept" Font-Size="14px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-success display-6">
                                            <i class="ti ti-file-analytics"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>


                    

                    <%-- <div class="col-lg-3 col-md-6">
                        <div class="card border-bottom border-danger">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblCanceledCount" runat="server" CssClass="text-center text-dark" Font-Size="16px" Font-Bold="true"></asp:Label></h2>
                                        <h6 class="fw-medium text-danger mb-0">
                                            <asp:Label ID="lblCanceledCount1" runat="server" Text="Cancel" CssClass="text-danger" Font-Size="14px" Font-Bold="true"></asp:Label></h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-danger display-6">
                                            <i class="ti ti-receipt-refund"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                </div>

                 <%-- Progress Bar  --%>
                <div class="row">
                     <%--<div class="col-md-2 col-sm-2 col-lg-2">
                             <div class="card border-bottom border-danger">
                            <div class="card-body">
                                <h6 class="card-title mb-0"><asp:Label ID="LabelUnpaid" runat="server" Text="Unpaid" CssClass="text-danger" Font-Size="14px"></asp:Label></h6><asp:Label ID="lblTotalInvoiceCount" runat="server" Text="" Visible="false" ForeColor="Blue" Font-Size="14px"></asp:Label>
                                <br />
                                <div class="text-right">
                                    <asp:Label ID="lblUnpaid" runat="server" Text="" ForeColor="Blue" Font-Size="14px"></asp:Label>

                                    <asp:Label ID="lblPercentUnpaid" runat="server" Text="" CssClass="fa-pull-right" Font-Size="14px"></asp:Label>
                                </div>
                                <div class="progress mt-3">
                                    <div class="progress-bar progress-bar-striped bg-danger" role="progressbar" aria-valuenow="90" aria-valuemin="0" aria-valuemax="100" id="ProgressUnpaid" runat="server"></div>
                                </div>
                            </div>
                        </div>
                    </div>

                      <div class="col-md-2 col-sm-2 col-lg-2">
                         <div class="card border-bottom border-success">
                            <div class="card-body">
                                <h6 class="card-title mb-0"><asp:Label ID="LabelPaid" runat="server" Text="Paid" CssClass="text-success" Font-Size="14px"></asp:Label></h6>
                                <br />
                                <div class="text-right">
                                    <asp:Label ID="lblPaid" runat="server" Text="" ForeColor="Blue" Font-Size="14px"></asp:Label>

                                    <asp:Label ID="lblPercentPaid" runat="server" Text="" CssClass="fa-pull-right" Font-Size="14px"></asp:Label>
                                </div>
                                <div class="progress mt-3">
                                    <div class="progress-bar progress-bar-striped bg-success" role="progressbar" aria-valuenow="90" aria-valuemin="0" aria-valuemax="100" id="ProgressPercentPaid" runat="server"></div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-2 col-sm-2 col-lg-2 border-right">
                             <div class="card border-bottom border-info">
                            <div class="card-body">
                                <h6 class="card-title mb-0"><asp:Label ID="LabelPartal" runat="server" Text="Partally Paid"  CssClass="text-info" Font-Size="14px"></asp:Label></h6>
                                <br />
                                <div class="text-right">
                                    <asp:Label ID="lblPartallyPaid" runat="server" Text="" ForeColor="Blue" Font-Size="14px"></asp:Label>

                                    <asp:Label ID="lblPartallyPaidpercent" runat="server" Text="" CssClass="fa-pull-right"  Font-Size="14px"></asp:Label>
                                </div>
                                <div class="progress mt-3">
                                    <div class="progress-bar progress-bar-striped bg-info" role="progressbar" aria-valuenow="90" aria-valuemin="0" aria-valuemax="100" id="ProgressPartallyPaid" runat="server"></div>
                                </div>
                            </div>
                        </div>
                    </div>--%>

                  
                    <div class="col-md-2 col-sm-2 col-lg-2"></div>
                </div>

            </div>

            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <h5 class="font-weight-medium mt-3 mb-3">View Purchase Order Details</h5>
                        <hr />
                        <div class="row">
                            <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
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
                        <asp:GridView ID="GridPurchaseOrderlist" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%" HeaderStyle-Font-Size="12px"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridPurchaseOrderlist_RowDataBound">
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
                                        <asp:LinkButton ID="LinkPONumber" runat="server" Text='<%# Bind("PONumber") %>' Font-Size="12px" OnClick="LinkPONumber_Click" CssClass="text-info"></asp:LinkButton>
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
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" Font-Bold="false" Font-Size="12px"  style="width: 160px;"></asp:DropDownList>
                                        <%--  <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control form-select">
                                                    </asp:DropDownList>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                             
                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditPurchaseOrder" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditPurchaseOrder_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDeletePurchaseOrder" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeletePurchaseOrder_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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
</asp:Content>
