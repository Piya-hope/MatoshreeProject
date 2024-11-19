<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Estimates_Home.aspx.cs" Inherits="MatoshreeProject.Estimates_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            var GridEstimate = $("#GridEstimate").prepend($("<thead></thead>").append($("#GridEstimate").find("tr:first"))).DataTable(
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
        <h5 class="font-weight-medium mb-0">Estimate</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="#">SALES
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="Estimates_Home.aspx">Estimate</li>
            </ol>
        </nav>
        <br />
        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="row">
                    <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">            
                        <div id="addnew" runat="server">
                            <div class="row">
                                <div class="mb-2">
                                    <asp:Button ID="btn_CreateEstimate" runat="server" Text="Create New Estimate" CssClass="btn btn-primary btn-sm" OnClick="btn_CreateEstimate_Click" />
                                </div>
                            </div>
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
                <br />
                <h5>Estimate Summary</h5>
                <div class="row">
                    <%-- LabelExpired--%>
                    <div class="col-sm-3 col-xs-3 col-lg-3 col-md-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="d-flex align-items-center mb-3">
                                    <div>
                                        <h3 class="fs-6">
                                            <asp:Label ID="lblExpired" runat="server" Text="" CssClass="text-dark" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                      
                                          <asp:Label ID="lblPercentExpired" runat="server" Text="" CssClass="text-dark" Font-Size="12px" Font-Bold="true"></asp:Label>

                                        </h3>
                                        <h6 class="card-subtitle mb-1 text-muted">

                                            <asp:Label ID="LabelExpired" runat="server" Text="Expired" ForeColor="IndianRed" Font-Size="12px" CssClass="text-center text-danger"></asp:Label></h6>
                                        <asp:Label ID="lblTotalEstimateCount" runat="server" Text="" Visible="false" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                        <asp:Label ID="lblTotalExpiredCount" runat="server" Text="" Visible="false" ForeColor="Blue" Font-Size="12px"></asp:Label>

                                       
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-danger display-6"><i class="ti ti-receipt-off"></i></span>
                                    </div>
                                </div>
                                <div class="progress text-bg-light">
                                    <div class="progress-bar text-bg-danger" role="progressbar"
                                        aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" id="ProgressUnpaid" runat="server">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- LabelAccepted --%>
                    <div class="col-sm-3 col-xs-3 col-lg-3 col-md-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="d-flex align-items-center mb-3">
                                    <div>
                                        <h3 class="fs-6">
                                            <asp:Label ID="lblAccepted" runat="server" Text="" CssClass="text-dark" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                       
                                            <asp:Label ID="lblPercentAccepted" runat="server" Text="" CssClass="text-dark" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </h3>
                                        <h6 class="card-subtitle mb-1 text-muted">
                                            <asp:Label ID="LabelAccepted" runat="server" Text="Accepted" ForeColor="Green" Font-Size="12px" CssClass="text-center text-success"></asp:Label>

                                        </h6>

                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-success display-6"><i class="ti ti-file-certificate"></i></span>
                                    </div>
                                </div>
                                <div class="progress text-bg-light">
                                    <div class="progress-bar text-bg-success" role="progressbar"
                                        aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" id="ProgressPercentPaid" runat="server">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- lblDeclined --%>
                    <div class="col-sm-3 col-xs-3 col-lg-3 col-md-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-12">
                                        <div class="d-flex align-items-center mb-3">
                                            <div>
                                                <h3 class="fs-6">
                                                    <asp:Label ID="lblDeclined" runat="server" Text="" CssClass="text-dark" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                               
                                                 <asp:Label ID="lblDeclinedPercent" runat="server" Text="" CssClass="text-dark" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                </h3>
                                                <h6 class="card-subtitle mb-1 text-muted">
                                                    <asp:Label ID="LabelDeclined" runat="server" Text="Declined" ForeColor="Orange" Font-Size="12px" CssClass="text-center text-warning"></asp:Label>

                                                </h6>
                                            </div>
                                            <div class="ms-auto">
                                                <span class="text-warning display-6"><i class="ti ti-file-alert"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-12">
                                        <div class="progress text-bg-light">
                                            <div class="progress-bar text-bg-warning" role="progressbar"
                                                aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" id="PgBarInvoiceOverDue" runat="server">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- lblSend --%>
                    <div class="col-sm-3 col-xs-3 col-lg-3 col-md-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-12">
                                        <div class="d-flex align-items-center mb-3">
                                            <div>
                                                <h3 class="fs-6">
                                                    <asp:Label ID="lblSend" runat="server" Text="" CssClass="text-dark" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                                 
                                                     <asp:Label ID="lblSendpercent" runat="server" Text="" CssClass="text-dark" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                </h3>
                                                <h6 class="card-subtitle mb-1 text-muted">
                                                    <asp:Label ID="LabelSend" runat="server" Text="Send" ForeColor="SkyBlue" Font-Size="12px" CssClass="text-center text-info"></asp:Label>
                                                </h6>
                                            </div>
                                            <div class="ms-auto">
                                                <span class="text-info display-6"><i class="ti ti-file-check"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-12">
                                        <div class="progress text-bg-light">
                                            <div class="progress-bar text-bg-info" role="progressbar"
                                                aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" id="ProgressPartallyPaid" runat="server">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- Draft --%>

                    <!-- End Row -->

                    <%-- Progress Bar  --%>
                    <br />
                </div>
            </div>

            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <h5>View Estimate Details</h5>
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
                                    <asp:Button ID="Btn_Visibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="Btn_Visibility_Click" />

                                    <asp:Button ID="Btn_Reload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-primary" ValidationGroup="reload" OnClick="Btn_Reload_Click" />
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
                        <asp:GridView ID="GridEstimate" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridEstimate_RowDataBound">
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
                                <asp:TemplateField HeaderText="EstimateNumber" SortExpression="EstimateNo" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblEstimateNumber" runat="server" Text='<%# Bind("EstimateNo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstimateNo1" runat="server" Text='<%# Bind("EstimateNo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                        <asp:LinkButton ID="LinkEstimateNumber" runat="server" Text='<%# Bind("EstimateNo") %>' OnClick="LinkEstimateNumber_Click" CssClass="text-info" Font-Size="12px"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount" SortExpression="Amount" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("InvoiceTotalAmont") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("InvoiceTotalAmont") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="EstimateDate" SortExpression="EstimateDate" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblEstimateDate" runat="server" Text='<%# Bind("EstimateDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstimateDate1" runat="server" Text='<%# Bind("EstimateDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer" SortExpression="Customer" HeaderStyle-Width="130px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblCustomerID" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustomerID1" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Project" SortExpression="ProjectName" HeaderStyle-Width="130px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblProjectID" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblProjectID1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SalesAgent" SortExpression="Sales_Agent" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblSales_Agent" runat="server" Text='<%# Bind("Sales_Agent") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSales_Agent1" runat="server" Text='<%# Bind("Sales_Agent") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
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
                                <asp:TemplateField HeaderText="ExpiryDate" SortExpression="Expiry_Date" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblExpiry_Date" runat="server" Text='<%# Bind("Expiry_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblExpiry_Date1" runat="server" Text='<%# Bind("Expiry_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
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
</asp:Content>
