<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="PaymentReport.aspx.cs" Inherits="MatoshreeProject.PaymentReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridPaymentReport = $("#GridPaymentReport").prepend($("<thead></thead>").append($("#GridPaymentReport").find("tr:first"))).DataTable(
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
        <h5 class="font-weight-medium mb-0">Payment Report</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="#">Report
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="PaymentReport.aspx">Payment Report</li>
            </ol>
        </nav>
        <br />
        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                     
                        <div class="row">
                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:Label ID="lblCustomer" Text="Customer" runat="server"  CssClass="form-label"></asp:Label>
                            </div>

                            <div class="col-md-4 col-sm-4 col-lg-4">
                                <asp:DropDownList ID="ddlCustomer" CssClass="form-control form-select" runat="server" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:Label ID="lblproject" Text="Project" runat="server"  CssClass="form-label"></asp:Label><br />

                            </div>
                            <div class="col-md-4 col-sm-4 col-lg-4">
                                <asp:DropDownList ID="ddlProject" CssClass="form-control form-select" runat="server" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:Label ID="lblInvoicname" Text="Invoice" runat="server"  CssClass="form-label"></asp:Label><br />

                            </div>
                            <div class="col-md-4 col-sm-4 col-lg-4">
                                <asp:DropDownList ID="ddlInvoiceNumber" CssClass="form-control form-select" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:Label ID="lbldate" Text="Date" runat="server"  CssClass="form-label"></asp:Label>
                            </div>
                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:TextBox ID="txtStartDate" type="date" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="StartDate(mm/dd/yyyy)"></asp:TextBox>

                            </div>
                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:TextBox ID="txtEndDate" type="date" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="EndDate(mm/dd/yyyy)"></asp:TextBox>
                            </div>
                        </div>

                        <br />
                        <div class="row">
                            <div class="col-md-4 col-sm-4 col-lg-4"></div>

                             <div class="col-md-1 col-sm-1 col-lg-1">
                                <asp:Button ID="btnSearchRerort" runat="server" Text="View Report" CssClass="btn btn-primary mr-4 btn-sm" OnClick="btnSearchRerort_Click" /> 
                            </div>
                          &nbsp; &nbsp; &nbsp; &nbsp;
                                    <div class="col-md-1 col-sm-1 col-lg-1"">
                                        <div class="bd-example">
                                            <div class="btn-group">
                                                <button class="btn btn-sm btn-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                                <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                                <div class="dropdown-menu">
                                                    <asp:LinkButton ID="lnkbtnExcel" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="lnkbtnExcel_Click"></asp:LinkButton>
                                                    <asp:LinkButton ID="linkbtnPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnPDF_Click"></asp:LinkButton>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                            <div class="col-md-1 col-sm-1 col-lg-1"">
                                 <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-danger btn-sm" OnClick="btnClear_Click" />
                            </div>

                           <div class="col-md-5 col-sm-5 col-lg-5">
                                <!------PDF code--------->

                                <div id="companyData" runat="server" visible="false">
                                    <asp:Label ID="lbladdCompany11" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lbladdress11" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblcompanyaddCity1" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblcompanyaddState1" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblcompanyaddCountry1" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblphoneNo1" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblVatNo1" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblGSTNo1A" runat="server" Text=""></asp:Label>
                                    <asp:Image ID="Image1" Text="" runat="server" Height="80px" Width="130px" />
                                </div>
                                <br />
                                <!------PDF code--------->

                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    
        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <h5>View Payment Details</h5>
                        <hr />
                        <asp:GridView ID="GridPaymentReport" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                            ClientIDMode="Static" EmptyDataText="No Records found" DataKeyNames="ID" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                            <Columns>

                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100"  HeaderStyle-Font-Size="12px" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px"/>
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

                                <asp:TemplateField HeaderText="TransationID" SortExpression="Transation_ID" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblTransationID" runat="server" Text='<%# Bind("Transation_ID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblTransationID1" runat="server" Text='<%# Bind("Transation_ID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Paymentdate" SortExpression="Payment_date" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblPayment_date" runat="server" Text='<%# Bind("Payment_date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPayment_date" runat="server" Text='<%# Bind("Payment_date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="RecivedAmount" SortExpression="Amount_Recived" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblAmountRecived" runat="server" Text='<%# Bind("Amount_Recived") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmountRecived1" runat="server" Text='<%# Bind("Amount_Recived") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="InvoiceNumber" SortExpression="InvoiceNo" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblInvoiceNo" runat="server" Text='<%# Bind("InvoiceNo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblInvoiceNo1" runat="server" Text='<%# Bind("InvoiceNo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="InvoiceAmount" SortExpression="TotalAmount" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblTotalAmount" runat="server" Text='<%# Bind("TotalAmount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalAmount1" runat="server" Text='<%# Bind("TotalAmount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="InvoiceDate" SortExpression="InvoiceDate" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblInvoiceDate" runat="server" Text='<%# Bind("InvoiceDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblInvoiceDate1" runat="server" Text='<%# Bind("InvoiceDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="AmountDeo" SortExpression="AmountDeo" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblAmountDeo" runat="server" Text='<%# Bind("AmountDeo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmountDeo1" runat="server" Text='<%# Bind("AmountDeo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="PaymentMode" SortExpression="Payment_Mode" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblPaymentMode" runat="server" Text='<%# Bind("Payment_Mode") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPaymentMode1" runat="server" Text='<%# Bind("Payment_Mode") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Customer" SortExpression="Customer" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lbCustomerName" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustomerName1" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Project" SortExpression="Project" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblProjectName" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblProjectName1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
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
        </div>
    </div>

</asp:Content>
