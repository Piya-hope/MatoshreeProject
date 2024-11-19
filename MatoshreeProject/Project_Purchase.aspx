<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Project_Purchase.aspx.cs" Inherits="MatoshreeProject.Project_Purchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {

            var GridProjectPurchase = $("#GridProjectPurchase").prepend($("<thead></thead>").append($("#GridProjectPurchase").find("tr:first"))).DataTable(
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
        <h5 class="font-weight-medium mb-0">Project Purchase</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="#">Expenses
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="Project_Purchase.aspx">Project Purchase</li>
            </ol>
        </nav>
        <br />
        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12 col-xl-12">
                <div class="row">
                    <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                        <div id="addnew" runat="server">
                            <asp:Button ID="btnRecordExpense" runat="server" Text="New Project Purchase" CssClass="btn btn-primary btn-sm" OnClick="btnRecordExpense_Click" />
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
                <%-- Summery strat------------%>
                <h5 class="fs-5 mt-3 mb-3">Project Purchase Summary</h5>
                <div class="row">
                    <div class="col-sm-4 col-md-6 col-lg-4 col-xl-4 ">
                        <div class="card border-bottom border-success">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblTotalAmountCount" CssClass="text-center text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-success mb-0">
                                            <asp:Label ID="lblTotalAmount" runat="server" Text="Total Amount" CssClass="text-success" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-success display-6">
                                            <iconify-icon icon="bi:file-earmark-bar-graph" class="aside-icon"></iconify-icon>

                                        </span>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6 col-lg-4 col-xl-4 ">
                        <div class="card border-bottom border-info">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblRegular_ExpTypecount" runat="server" CssClass="text-center text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-info mb-0">
                                            <asp:Label ID="lblRegular_ExpType" runat="server" Text="Regular" CssClass="text-info" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-info display-6">
                                            <iconify-icon icon="bi:file-earmark-bar-graph" class="aside-icon"></iconify-icon>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6 col-lg-4 col-xl-4 ">
                        <div class="card border-bottom border-danger">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblReimbursementTypeCount" runat="server" CssClass="text-center  text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label></h2>
                                        <h6 class="fw-medium text-danger mb-0">
                                            <asp:Label ID="lblReimbursementType" runat="server" Text="Reimbursement" CssClass="text-danger" Font-Size="12px" Font-Bold="true"></asp:Label></h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-danger display-6">
                                            <iconify-icon icon="bi:file-earmark-bar-graph" class="aside-icon"></iconify-icon>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- Summery End------------%>
                </div>
            </div>

            <div class="col-md-12 col-sm-12 col-lg-12 col-xl-12">
                <div class="card">
                    <div class="card-body">
                        <h5 class="fs-5 mt-3 mb-3">View Expenses Details</h5>
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
                                    <asp:Button ID="BTN_Visibility" runat="server" Text="Visibilty" CssClass="btn btn-sm btn-outline-info" OnClick="BTN_Visibility_Click" />
                                    <asp:Button ID="btn_Reload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="btn_Reload_Click" />
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
                        <asp:GridView ID="GridProjectPurchase" runat="server" OnRowDataBound="GridProjectPurchase_RowDataBound" ScrollBars="Both" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="false" CellPadding="4"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="Pur_id">
                            <Columns>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" SortExpression="Order" HeaderStyle-Font-Size="12px" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Pur_Status") %>' Font-Bold="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID" SortExpression="Pur_id" HeaderStyle-Font-Size="12px" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblPur_id" runat="server" Text='<%# Bind("Pur_id") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPur_id1" runat="server" Text='<%# Bind("Pur_id") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PurchaseName" SortExpression="Pur_Name" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblPur_Name" runat="server" Text='<%# Bind("Pur_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPur_Name1" runat="server" Text='<%# Bind("Pur_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                        <asp:LinkButton ID="linkPur_Name1" runat="server" Text='<%# Bind("Pur_Name") %>' Font-Bold="false" Font-Size="12px" OnClick="linkPur_Name1_Click"></asp:LinkButton>
                                        <%--<asp:Label ID="lblPur_Name1" runat="server" Text='<%# Bind("Pur_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount" SortExpression="Pur_Amount" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblPur_Amount" runat="server" Text='<%# Bind("Pur_Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPur_Amount1" runat="server" Text='<%# Bind("Pur_Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer" SortExpression="Pur_Customer" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblPur_Customer" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPur_Customer1" runat="server" Text='<%# Bind("Cust_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Project" SortExpression="Pur_Project" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblPur_Project" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPur_Project1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PurchaseDate" SortExpression="Pur_Date" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblPur_Date" runat="server" Text='<%# Bind("Pur_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPur_Date1" runat="server" Text='<%# Bind("Pur_Date","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ExpensesType" SortExpression="Pur_Type" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblExpenses_Type" runat="server" Text='<%# Bind("Pur_Type") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblExpenses_Type1" runat="server" Text='<%# Bind("Pur_Type") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ApprovalSatus" SortExpression="ApprovalSatus" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblApprovalSatus" runat="server" Text='<%#Bind("ApprovalSatus") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblApprovalSatus1" runat="server" Text='<%#Bind("ApprovalSatus") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ApprovalBy" SortExpression="ApprovalBy" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblApprovalBy" runat="server" Text='<%#Bind("ApprovalBy") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblApprovalBy1" runat="server" Text='<%#Bind("ApprovalBy") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditProjectPurchase" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditProjectPurchase_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
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
        </div>
</asp:Content>
