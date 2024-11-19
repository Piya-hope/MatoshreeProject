<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Payments.aspx.cs" Inherits="MatoshreeProject.Payments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var GridPayments = $("#GridPayments").prepend($("<thead></thead>").append($("#GridPayments").find("tr:first"))).DataTable(
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
        <%-- BreadCrumbs --%>
        <h5 class="font-weight-medium mb-0">Payment</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item"><a class="text-muted text-decoration-none" href="#">SALE</a></li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="Payments.aspx">Payments</li>
            </ol>
        </nav>
        <%-- BreadCrumbs --%>
        <br />

        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
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

        <div class="card">
            <div class="card-body">
                <h5>View Payment Details</h5>
                <hr />
                <div class="row">
                    <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                        <div class="bd-example">
                            <div class="btn-group">
                                <button class="btn btn-sm btn-outline-success dropdown-toggle" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                <asp:Button ID="Button3" runat="server" Style="display: none" />
                                <div class="dropdown-menu">
                                    <asp:LinkButton ID="btn_Export" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="btn_Export_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="linkPaymentPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkPaymentPDF_Click"></asp:LinkButton>
                                </div>
                            </div>

                            <asp:Button ID="btn_Visibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="btn_Visibility_Click" />
                            <asp:Button ID="btn_Reload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="btn_Reload_Click" />
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
                <div class="row">
                    <asp:GridView ID="GridPayments" runat="server" ScrollBars="Both" OnRowDataBound="GridPayments_RowDataBound" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" Width="100%" CellPadding="4"
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
                            <asp:TemplateField HeaderText="TransactionID" SortExpression="Transaction_ID" HeaderStyle-Font-Size="12px">
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
                                    <asp:LinkButton ID="btnView" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnView_Click"><i class="ti ti-eye"></i></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClick="btnDelete_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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

</asp:Content>
