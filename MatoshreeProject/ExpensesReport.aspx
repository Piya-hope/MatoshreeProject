<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="ExpensesReport.aspx.cs" Inherits="MatoshreeProject.ExpensesReport" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            var GridViewStaffReport = $("#GridViewStaffReport").prepend($("<thead></thead>").append($("#GridViewStaffReport").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridViewOfficeReport = $("#GridViewOfficeReport").prepend($("<thead></thead>").append($("#GridViewOfficeReport").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridViewProjectReport = $("#GridViewProjectReport").prepend($("<thead></thead>").append($("#GridViewProjectReport").find("tr:first"))).DataTable(
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
        <h5 class="font-weight-medium mb-0">Expenses Report</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="#">REPORT
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="ExpensesReport.aspx">Expenses Report</li>
            </ol>
        </nav>
        <br />

        <div class="row">
            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">

                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:Label ID="lblRelatedTo" Text="Expenses Category" runat="server" CssClass="form-label"></asp:Label><br />
                                <asp:Label ID="lblExpensesNamee" runat="server" Text="" Visible="false" Font-Size="12px"></asp:Label>
                            </div>
                            <div class="col-md-4 col-sm-4 col-lg-4">
                                <asp:DropDownList ID="ddlExpensesCategory" runat="server" CssClass="form-control form-select" Placeholder="Select Expenses Category" OnSelectedIndexChanged="ddlExpensesCategory_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:Label ID="lblExpensesSubCategory" Text="" runat="server" CssClass="form-label"></asp:Label><br />

                            </div>
                            <div class="col-md-4 col-sm-4 col-lg-4">
                                <asp:DropDownList ID="ddlSubCategory" runat="server" CssClass="form-control form-select" Placeholder="Select Expenses SubCategory">
                                </asp:DropDownList>
                            </div>



                        </div>


                        <br />
                        <div class="row">

                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:Label ID="Label3" Text="Date" runat="server" CssClass="form-label"></asp:Label>

                            </div>
                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:TextBox ID="txtStartDate" type="date" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="StartDate(mm/dd/yyyy)"></asp:TextBox>
                            </div>
                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:TextBox ID="txtEndDate" type="date" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="EndDate(mm/dd/yyyy)"></asp:TextBox>
                            </div>
                            <div class="col-md-2 col-sm-2 col-lg-2">

                                <asp:Label ID="lblExpensestype" Text="Expenses Type" runat="server" CssClass="form-label"></asp:Label>
                            </div>
                            <div class="col-md-4 col-sm-4 col-lg-4">
                                <asp:DropDownList ID="ddlExpensesType" runat="server" CssClass="form-control form-select" Placeholder="Select Expenses Type">
                                    <asp:ListItem Value="Ns" Text="Select ExpType"></asp:ListItem>
                                    <asp:ListItem Value="Regular" Text="Regular"></asp:ListItem>
                                    <asp:ListItem Value="reimbursement" Text="Reimbursement"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <br />
                        <br />
                        <div class="row">
                            <div class="col-md-4 col-sm-4 col-lg-4"></div>
                            <div class="col-md-5 col-sm-5 col-lg-5">
                                <asp:Button ID="btnViewRerort" runat="server" Text="View Report" CssClass="btn btn-primary btn-sm" OnClick="btnViewRerort_Click" ValidationGroup="View" />
                                &nbsp;
                            <asp:Button ID="btnExportReport" runat="server" Text="Export Report" OnClick="btnExportReport_Click" CssClass="btn btn-success btn-sm" />
                                &nbsp;
                              <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CssClass="btn btn-danger btn-sm" />
                            </div>
                            <div class="col-md-3 col-sm-3 col-lg-3"></div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <h5>View Expenses Report</h5>
                        <hr />
                        <asp:GridView ID="GridViewOfficeReport" runat="server" Visible="false" ScrollBars="Both" CssClass="table border table-bordered table-responsive table-hover text-nowrap align-content-center" AutoGenerateColumns="false" Width="100%" CellPadding="4"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="Exp_id" OnRowDataBound="GridViewAllExpenses_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100"  HeaderStyle-Font-Size="12px">
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
                                <asp:TemplateField HeaderText="RelatedTo" SortExpression="[Belong To]" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblRelatedTo" runat="server" Text='<%# Bind("[Belong To]") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRelatedTo1" runat="server" Text='<%# Bind("[Belong To]") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
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
                                <asp:TemplateField HeaderText="ExpensesType" SortExpression="Exp_Type" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblExp_Type" runat="server" Text='<%# Bind("Exp_Type") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblExp_Type1" runat="server" Text='<%# Bind("Exp_Type") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
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
                                <asp:TemplateField HeaderText="ExpPayment" SortExpression="Exp_Payment" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblExp_Payment" runat="server" Text='<%# Bind("Exp_Payment") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblExp_Payment1" runat="server" Text='<%# Bind("Exp_Payment") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Category" SortExpression="Exp_Category" HeaderStyle-Font-Size="12px" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblExp_Category" runat="server" Text='<%# Bind("Exp_Category") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblExp_Category1" runat="server" Text='<%# Bind("Exp_Category") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ExpSubCategory" SortExpression="[Exp_SubCategory]" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblfor" runat="server" Text='<%# Bind("Exp_SubCategory") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblfor1" runat="server" Text='<%# Bind("Exp_SubCategory") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div align="center" style="color: red">
                                    <h6>No records found.</h6>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <asp:GridView ID="GridViewProjectReport" runat="server" Visible="false" ScrollBars="Both" CssClass="table border table-bordered table-hover table-responsive text-nowrap align-content-center" AutoGenerateColumns="false" Width="100%" CellPadding="4"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="Exp_id" OnRowDataBound="GridViewAllExpenses_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100"  HeaderStyle-Font-Size="12px">
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
                                <asp:TemplateField HeaderText="RelatedTo" SortExpression="[Belong To]" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblRelatedTo" runat="server" Text='<%# Bind("[Belong To]") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRelatedTo1" runat="server" Text='<%# Bind("[Belong To]") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
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
                                <asp:TemplateField HeaderText="ExpensesType" SortExpression="Exp_Type" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblExp_Type" runat="server" Text='<%# Bind("Exp_Type") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblExp_Type1" runat="server" Text='<%# Bind("Exp_Type") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
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
                                <asp:TemplateField HeaderText="Exp_Payment" SortExpression="Exp_Payment" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblExp_Payment" runat="server" Text='<%# Bind("Exp_Payment") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblExp_Payment1" runat="server" Text='<%# Bind("Exp_Payment") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ProjectName" SortExpression="ProjectName" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblPur_Project" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPur_Project1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div align="center" style="color: red">
                                    <h6>No records found.</h6>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <asp:GridView ID="GridViewStaffReport" runat="server" Visible="false" ScrollBars="Both" CssClass="table border table-bordered table-responsive table-hover text-nowrap align-content-center" AutoGenerateColumns="false" Width="100%" CellPadding="4"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="Exp_id" OnRowDataBound="GridViewAllExpenses_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100"  HeaderStyle-Font-Size="12px">
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
                                <asp:TemplateField HeaderText="RelatedTo" SortExpression="[Belong To]" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblRelatedTo" runat="server" Text='<%# Bind("[Belong To]") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRelatedTo1" runat="server" Text='<%# Bind("[Belong To]") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
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
                                <asp:TemplateField HeaderText="ExpensesType" SortExpression="Exp_Type" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblExp_Type" runat="server" Text='<%# Bind("Exp_Type") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblExp_Type1" runat="server" Text='<%# Bind("Exp_Type") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
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
                                <asp:TemplateField HeaderText="Exp_Payment" SortExpression="Exp_Payment" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblExp_Payment" runat="server" Text='<%# Bind("Exp_Payment") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblExp_Payment1" runat="server" Text='<%# Bind("Exp_Payment") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="StaffName" SortExpression="First_Name" HeaderStyle-Font-Size="12px" Visible="true">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblstaffr" runat="server" Text='<%# Bind("First_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblstaff1" runat="server" Text='<%# Bind("First_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
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
