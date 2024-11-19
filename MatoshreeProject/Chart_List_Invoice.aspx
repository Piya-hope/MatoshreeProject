<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Chart_List_Invoice.aspx.cs" Inherits="MatoshreeProject.Chart_List_Invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var GridInvoice = $("#GridInvoice").prepend($("<thead></thead>").append($("#GridInvoice").find("tr:first"))).DataTable(
                {
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
        <h5 class="font-weight-medium mb-0">Invoice</h5>
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
                <li class="breadcrumb-item text-muted" aria-current="page" href="Chart_List_Invoice.aspx">Invoices</li>
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
                                    <asp:Button ID="btn_Create_New_Invoice" runat="server" Text="Create New Invoice" CssClass="btn btn-sm btn-primary fa-pull-left" OnClick="btn_Create_New_Invoice_Click" />
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

                <h5>Invoice Summary</h5>
                <div class="row">
                    <div class="col-md-3 col-sm-3 col-lg-3">
                        <div class="card border-bottom border-dark">
                            <div class="card-body">
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlPriceCurrency" runat="server" CssClass="form-control-sm form-select">
                                        <asp:ListItem>INR</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control form-control-sm form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-3 col-lg-3">
                        <div class="card border-bottom border-info">
                            <div class="card-body">
                                <div class="row">
                                    <asp:Label ID="lbl_Outstanding_Invoice" CssClass="font-14 text-center" runat="server" Text="312,412.14"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <h6 id="ct6_YourControl1" class="text text-center text-info">Outstanding Invoice</h6>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-3 col-lg-3">
                        <div class="card border-bottom border-dark">
                            <div class="card-body">
                                <div class="form-group">
                                    <div class="row">
                                        <asp:Label ID="lbl_Past_Due_Invoice" CssClass="float:left font-14 text-center" runat="server" Text="0.00"></asp:Label>
                                    </div>
                                    <div class="form-group">
                                        <h6 id="past_Due-Invoice" class="text text-center text-dark">Past Due Invoice</h6>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-3 col-lg-3">
                        <div class="card border-bottom border-success">
                            <div class="card-body">
                                <div class="row">
                                    <asp:Label ID="lbl_Paid_Invoice" CssClass="float:left font-14 text-center" runat="server" Text="0.00"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <h6 id="paid_Invoice" class="text text-center text-success">Paid Invoice</h6>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                 <!-- Row -->
              <div class="row">
                 <%-- Unpaid--%>
                <div class="col-sm-4 col-xs-4 col-lg-4 col-md-6">
                  <div class="card">
                    <div class="card-body">
                      <div class="d-flex align-items-center mb-3">
                        <div>
                          <h3 class="fs-6"> 
                              <asp:Label ID="lblUnpaid" runat="server" Text="" ForeColor="Blue" Font-Size="12px" Visible="false"></asp:Label>
                              <asp:Label ID="lblPercentUnpaid" runat="server" Text="" Font-Size="12px"></asp:Label>
                          </h3>
                          <h6 class="card-subtitle mb-1 text-muted">         
                              <asp:Label ID="LabelUnpaid" runat="server" Text="Unpaid" CssClass="text-danger" Font-Size="12px"></asp:Label></h6>
                              <asp:Label ID="lblTotalInvoiceCount" runat="server" Text="" Visible="false" ForeColor="Blue" Font-Size="12px"></asp:Label>                       
                        </div>
                        <div class="ms-auto">
                          <span class="text-danger display-6"><i class="ti ti-package"></i></span>
                        </div>
                      </div>
                      <div class="progress text-bg-light">
                        <div class="progress-bar text-bg-danger" role="progressbar"
                          aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" id="ProgressUnpaid" runat="server"></div>
                      </div>
                    </div>
                  </div>
                </div>
                  <%-- Paid --%>
                <div class="col-sm-4 col-xs-4 col-lg-4 col-md-6">
                  <div class="card">
                    <div class="card-body">
                      <div class="d-flex align-items-center mb-3">
                        <div>
                          <h3 class="fs-6">  
                              <asp:Label ID="lblPaid" runat="server" Text="" ForeColor="Blue" Font-Size="12px" Visible="false"></asp:Label>
                              <asp:Label ID="lblPercentPaid" runat="server" Text="" Font-Size="12px"></asp:Label>
                          </h3>
                          <h6 class="card-subtitle mb-1 text-muted">        
                              <asp:Label ID="LabelPaid" runat="server" Text="Paid" CssClass="text-success" Font-Size="12px"></asp:Label>
                          </h6>               
                        </div>
                        <div class="ms-auto">
                          <span class="text-success display-6"><i class="ti ti-receipt-2"></i></span>
                        </div>
                      </div>
                      <div class="progress text-bg-light">
                        <div class="progress-bar text-bg-success" role="progressbar"
                          aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" id="ProgressPercentPaid" runat="server"></div>
                      </div>
                    </div>
                  </div>
                </div>
                  <%-- PartallyPaid --%>
                 <div class="col-sm-4 col-xs-4 col-lg-4 col-md-6">
                  <div class="card">
                    <div class="card-body">
                      <div class="row">
                        <div class="col-12">
                          <div class="d-flex align-items-center mb-3">
                            <div>
                              <h3 class="fs-6">   
                                  <asp:Label ID="lblPartallyPaid" runat="server" Text="" ForeColor="Blue" Font-Size="12px" Visible="false"></asp:Label>

                                    <asp:Label ID="lblPartallyPaidpercent" runat="server" Text="" Font-Size="12px"></asp:Label>
                                     </h3>
                              <h6 class="card-subtitle mb-1 text-muted">         
                                  <asp:Label ID="LabelPartal" runat="server" Text="Partally Paid" CssClass="text-info" Font-Size="12px"></asp:Label>

                              </h6>
        
                            </div>
                            <div class="ms-auto">
                              <span class="text-info display-6"><i class="ti ti-recharging"></i></span>
                            </div>
                          </div>
                        </div>
                        <div class="col-12">
                          <div class="progress text-bg-light">
                            <div class="progress-bar text-bg-info" role="progressbar"
                              aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" id="ProgressPartallyPaid" runat="server"></div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                  <%-- OverDue --%>
                 <div class="col-sm-4 col-xs-4 col-lg-4 col-md-6">
                  <div class="card">
                    <div class="card-body">
                      <div class="row">
                        <div class="col-12">
                          <div class="d-flex align-items-center mb-3">
                            <div>
                              <h3 class="fs-6">    
                                  <asp:Label ID="lblInvoiceOverDue" runat="server" Text="" ForeColor="Blue" Font-Size="12px" Visible="false"></asp:Label>

                                    <asp:Label ID="lblInvoiceOverDuePercent" runat="server" Text="" Font-Size="12px"></asp:Label>
                              </h3>
                              <h6 class="card-subtitle mb-1 text-muted">   
                                  <asp:Label ID="LabelOverDue" runat="server" Text="OverDue" CssClass="text-warning" Font-Size="12px"></asp:Label>

                              </h6>
         
                            </div>
                            <div class="ms-auto">
                              <span class="text-warning display-6"><i class="ti ti-receipt"></i></span>
                            </div>
                          </div>
                        </div>
                        <div class="col-12">
                          <div class="progress text-bg-light">
                            <div class="progress-bar text-bg-warning" role="progressbar"
                              aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" id="PgBarInvoiceOverDue" runat="server"></div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                   <%-- Draft --%>
                 <div class="col-sm-4 col-xs-4 col-lg-4 col-md-6">
                      <div class="card">
                    <div class="card-body">
                      <div class="row">
                        <div class="col-12">
                          <div class="d-flex align-items-center mb-3">
                            <div>
                              <h3 class="fs-6">     
                                  <asp:Label ID="lblInvoiceDraft" runat="server" Text="" ForeColor="Blue" Font-Size="12px" Visible="false"></asp:Label>

                                    <asp:Label ID="lblInvoiceDraftPercent" runat="server" Text="" Font-Size="12px"></asp:Label>
                             </h3>
                              <h6 class="card-subtitle mb-1 text-muted">          
                                  <asp:Label ID="LabelDraft" runat="server" Text="Draft" CssClass="text-dark" Font-Size="12px"></asp:Label>

                              </h6>
                      
                            </div>
                            <div class="ms-auto">
                              <span class="text-dark display-6"><i class="ti ti-file-text"></i></span>
                            </div>
                          </div>
                        </div>
                        <div class="col-12">
                          <div class="progress text-bg-light">
                            <div class="progress-bar text-bg-dark" role="progressbar"
                              aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" id="PgBarInvoiceDraft" runat="server"></div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                     </div>
               
                   <%-- Cancelled --%>
             <div class="col-sm-4 col-xs-4 col-lg-4 col-md-6">
                  <div class="card">
                    <div class="card-body">
                      <div class="row">
                        <div class="col-12">
                          <div class="d-flex align-items-center mb-3">
                            <div>
                              <h3 class="fs-6">    
                                  <asp:Label ID="lblCancelled" runat="server" Text="" ForeColor="Blue" Font-Size="12px" Visible="false"></asp:Label>

                                    <asp:Label ID="lblCancelledPercent" runat="server" Text="" Font-Size="12px"></asp:Label>
                             </h3>
                              <h6 class="card-subtitle mb-1 text-muted">  
                                  <asp:Label ID="LabelCancelled" runat="server" CssClass="text-danger" Text="Cancelled" ForeColor="Red" Font-Size="12px"></asp:Label>

                              </h6>
  
                            </div>
                            <div class="ms-auto">
                              <span class="text-danger display-6"><i class="ti ti-receipt-refund"></i></span>
                            </div>
                          </div>
                        </div>
                        <div class="col-12">
                          <div class="progress text-bg-light">
                            <div class="progress-bar text-bg-danger" role="progressbar"
                              aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" id="PgBarCancelled" runat="server"></div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
            
              <!-- End Row -->

                <%-- Progress Bar  --%>
                <br />

            </div>
                 </div>

            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                       <h5 class="font-weight-medium mt-3 mb-3">View Invoice Details</h5>
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

                                    <asp:Button ID="btn_Reload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="btn_Reload_Click" />
                                    <asp:Button ID="Btn_Visibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="Btn_Visibility_Click" />
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
                    </div>

                    <div class="card-body">
                        <asp:GridView ID="GridInvoice" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%" HeaderStyle-Font-Size="12px"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridInvoice_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px"/>
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
                                <asp:TemplateField HeaderText="InvoiceNumber" SortExpression="Invoice" HeaderStyle-Width="90px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblInvoice" runat="server" Text='<%# Bind("InvoiceNo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblInvoice1" runat="server" Text='<%# Bind("InvoiceNo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                        <asp:LinkButton ID="LinkInvoiceNumber" runat="server" Text='<%# Bind("InvoiceNo") %>' Font-Size="12px" CssClass="text-info" OnClick="LinkInvoiceNumber_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount" SortExpression="InvoiceTotalAmont" HeaderStyle-Width="90px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("InvoiceTotalAmont") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("InvoiceTotalAmont") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="InvoiceDate" SortExpression="InvoiceDate">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%# Bind("InvoiceDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate1" runat="server" Text='<%# Bind("InvoiceDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer" SortExpression="Cust_Name" HeaderStyle-Width="90px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblCustomer" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustomer1" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Project" SortExpression="ProjectName" HeaderStyle-Width="90px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblProject" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblProject1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SalesAgent" SortExpression="Sales_Agent" HeaderStyle-Width="90px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblSales_Agent" runat="server" Text='<%# Bind("Sales_Agent") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSales_Agent1" runat="server" Text='<%# Bind("Sales_Agent") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="InvoiceStatus" SortExpression="Status">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblStats61" runat="server" Text=""></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStats6" runat="server" Text='<%# Bind("Status") %>' Visible="false"></asp:Label>
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" DataTextField='<%# Bind("Status") %>' DataValueField='<%# Bind("Status") %>' AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                            <asp:ListItem Text="Unpaid" Value="Unpaid"></asp:ListItem>
                                            <asp:ListItem Text="Paid" Value="Paid"></asp:ListItem>
                                            <asp:ListItem Text="Partially Paid" Value="Partially Paid"></asp:ListItem>
                                            <asp:ListItem Text="Overdue" Value="Overdue"></asp:ListItem>
                                            <asp:ListItem Text="Cancelled" Value="Cancelled"></asp:ListItem>
                                            <asp:ListItem Text="Draft" Value="Draft"></asp:ListItem>
                                            <asp:ListItem Text="Send" Value="Send"></asp:ListItem>
                                        </asp:DropDownList>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DueDate" SortExpression="Expiry_Date">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblDue_Date" runat="server" Text='<%# Bind("Expiry_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDue_Date1" runat="server" Text='<%# Bind("Expiry_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditInvoice" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditInvoice_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
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
        </div>
</asp:Content>
