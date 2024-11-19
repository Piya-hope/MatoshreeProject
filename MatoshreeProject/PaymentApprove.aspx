<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="PaymentApprove.aspx.cs" Inherits="MatoshreeProject.PaymentApprove" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridViewAllExpenses = $("#GridViewAllExpenses").prepend($("<thead></thead>").append($("#GridViewAllExpenses").find("tr:first"))).DataTable(
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
        <h5 class="font-weight-medium mb-0">Payment Approval</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" href="#">Expenses</li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="PaymentApprove.aspx">Payment Approve</li>
            </ol>
        </nav>
        <br />
        <div class="row">
            <div class="col-md-12 col-sm-12 col-ld-12">
               
                        <%-- Summery strat------------%>
                        <h5>Payment Approval Summary</h5>
                        <hr />
                        <div class="row">
                            <div class="col-sm-3 col-md-3 col-lg-3 col-xl-3 ">
                                <div class="card border-bottom border-success">
                                    <div class="card-body">
                                        <div class="d-flex align-items-center">
                                            <div>
                                                <h2 class="fs-7">

                                                    <asp:Label ID="lblTotalAmountCountOffice" CssClass="text-center text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                                </h2>
                                                <h6 class="fw-medium text-success mb-0">
                                                    <asp:Label ID="lblAmountOffice" runat="server" Text="Office Expenses Amount" CssClass="text-success" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                </h6>
                                            </div>
                                            <div class="ms-auto">
                                                <span class="text-success display-6">
                                                    <iconify-icon icon="akar-icons:chat-approve" class="aside-icon"></iconify-icon>
                                                </span>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-3 col-md-3 col-lg-3 col-xl-3 ">
                                <div class="card border-bottom border-secondary">
                                    <div class="card-body">
                                        <div class="d-flex align-items-center">
                                            <div>
                                                <h2 class="fs-7">

                                                    <asp:Label ID="lblTotalAmountCountPaymentRequest" CssClass="text-center text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                                </h2>
                                                <h6 class="fw-medium text-secondary mb-0">
                                                    <asp:Label ID="lblAmountPaymentRequest" runat="server" Text="Payment Request Amount" CssClass="text-secondary" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                </h6>
                                            </div>
                                            <div class="ms-auto">
                                                <span class="text-secondary display-6">
                                                    <iconify-icon icon="akar-icons:chat-approve" class="aside-icon"></iconify-icon>
                                                </span>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-3 col-md-3 col-lg-3 col-xl-3 ">
                                <div class="card border-bottom border-purple">
                                    <div class="card-body">
                                        <div class="d-flex align-items-center">
                                            <div>
                                                <h2 class="fs-7">

                                                    <asp:Label ID="lblTotalAmountCountProjectPurcase" CssClass="text-center text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                                </h2>
                                                <h6 class="fw-medium text-purple mb-0">
                                                    <asp:Label ID="lblAmountProjectPurcase" runat="server" Text="Project Purcase Amount" CssClass="text-purple" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                </h6>
                                            </div>
                                            <div class="ms-auto">
                                                <span class="text-purple display-6">
                                                    <iconify-icon icon="akar-icons:chat-approve" class="aside-icon"></iconify-icon>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-3 col-md-3 col-lg-3 col-xl-3 ">
                                <div class="card border-bottom border-danger">
                                    <div class="card-body">
                                        <div class="d-flex align-items-center">
                                            <div>
                                                <h2 class="fs-7">
                                                    <asp:Label ID="lblTotalAmountCountStaffExpenses" CssClass="text-center text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                                </h2>
                                                <h6 class="fw-medium text-danger mb-0">
                                                    <asp:Label ID="lblAmountStaffExpenses" runat="server" Text="Staff Expenses Amount" CssClass="text-danger" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                </h6>
                                            </div>
                                            <div class="ms-auto">
                                                <span class="text-danger display-6">

                                                    <iconify-icon icon="akar-icons:chat-approve" class="aside-icon"></iconify-icon>
                                                </span>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%-- Summery End------------%>
                    </div>
               
        </div>

        <div class="row">
            <div class="col-md-12 col-sm-12 col-ld-12">
                <div class="card">
                    <div class="card-body">
                        <h5>View  Payment Approval  Details</h5>
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
                                    <asp:Button ID="btn_Visibility" runat="server" Text="Visibility" CssClass="btn btn-sm  btn btn-sm btn-outline-info" OnClick="btn_Visibility_Click" />
                                    <asp:Button ID="btn_Reload" runat="server" Text="Reload" CssClass="btn btn-sm btn-sm btn btn-sm btn-outline-info" OnClick="btn_Reload_Click" />

                                </div>
                            </div>
                            <div class="col-md-2">
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

                        <asp:GridView ID="GridViewAllExpenses" runat="server" ScrollBars="Both" OnRowDataBound="GridViewAllExpenses_RowDataBound1" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" Width="100%" CellPadding="4"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="Exp_id">
                            <Columns>
                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID" SortExpression="Exp_id" HeaderStyle-Font-Size="12px" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblExp_id" runat="server" Text='<%# Bind("Exp_id") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblExp_id1" runat="server" Text='<%# Bind("Exp_id") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        <asp:Label ID="lblPefrPK" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        <asp:Label ID="lblReferenceId" runat="server" Text='<%# Bind("ReferenceID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Expenses" SortExpression="Exp_Name" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblExp_Name" runat="server" Text='<%# Bind("Exp_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblExp_Name1" runat="server" Text='<%# Bind("Exp_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ExpensesDate" SortExpression="Exp_Date" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblExp_Date" runat="server" Text='<%# Bind("Exp_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblExp_Date1" runat="server" Text='<%# Bind("Exp_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount" SortExpression="Exp_Amount" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblExp_Amount" runat="server" Text='<%# Bind("Exp_Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblExp_Amount1" runat="server" Text='<%# Bind("Exp_Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ExpensesType" SortExpression="Exp_Type" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblExp_Type" runat="server" Text='<%# Bind("Exp_Type") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblExp_Type1" runat="server" Text='<%# Bind("Exp_Type") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ExpPayment" SortExpression="ExpPayment" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblExp_Payment" runat="server" Text='<%# Bind("Exp_Payment") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblExp_Payment1" runat="server" Text='<%# Bind("Exp_Payment") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RemainingAmount" SortExpression="ViewApproval" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblRemainingAmount" runat="server" Text='<%# Bind("RemainingAmount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemainingAmount1" runat="server" Text='<%# Bind("RemainingAmount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RelatedTo" SortExpression="RelatedTo" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblRelatedTo" runat="server" Text='<%# Bind("RelatedTo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRelatedTo1" runat="server" Text='<%# Bind("RelatedTo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ViewApproval" SortExpression="ViewApproval" HeaderStyle-Font-Size="12px" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblViewApproval" runat="server" Text='<%# Bind("ViewApproval") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblViewApproval1" runat="server" Text='<%# Bind("ViewApproval") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnViewExpenses" runat="server" OnClick="btnViewExpenses_Click" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-eye"></i></asp:LinkButton>
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

</asp:Content>
