<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="ViewSalarySlip.aspx.cs" Inherits="MatoshreeProject.ViewSalarySlip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridViewSlip = $("#GridViewSlip").prepend($("<thead></thead>").append($("#GridViewSlip").find("tr:first"))).DataTable(
                {
                    "order": false,
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
        <h5 class="card-title">View Salary Slip</h5>

        <%-- BreadCrumbs --%>

        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="ViewSalarySlip.aspx">View Salary Slip</li>
            </ol>
        </nav>
        <%-- BreadCrumbs --%>

        <div class="row">
            <div class="card-title">
                <hr />
                <div class="row">
                    <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                        <h5 class="font-weight-medium mt-3 mb-3">Employee Salary Summary</h5>
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


                <asp:Label ID="lblTittle" runat="server" Text="" Font-Bold="true" Font-Size="20px"></asp:Label>
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col-md-3 col-sm-3 col-lg-3">
                                <asp:Label ID="lblMonth" runat="server" Text="Month" CssClass="form-label"></asp:Label>
                                <asp:DropDownList ID="ddlMonth" runat="server" class="form-control"></asp:DropDownList>

                            </div>

                            <div class="col-md-3 col-sm-3 col-lg-3">
                                <asp:Label ID="lblYear" runat="server" Text="Year" CssClass="form-label"></asp:Label>
                                <asp:DropDownList ID="ddlYear" runat="server" class="form-control"></asp:DropDownList>
                            </div>

                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <br />
                                <asp:CheckBox ID="chkSendEmail" runat="server" Font-Bold="false" />&nbsp;<asp:Label ID="lblSendEmail" runat="server" Text="Send Email" CssClass="form-label"></asp:Label>
                            </div>
                            <div class="col-md-3 col-sm-3 col-lg-3">
                                <asp:Label ID="Label1" runat="server" Text="" CssClass="form-label"></asp:Label><br />
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-sm btn-primary" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>




                <div class="card">
                    <div class="card-body">
                        <h5 class="font-weight-medium mt-3 mb-3">View Employee Salary Details</h5>
                        <hr />
                        <br />
                        <asp:GridView ID="GridViewSlip" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" OnRowDataBound="GridViewSlip_RowDataBound" AutoGenerateColumns="false" Width="100%" CellPadding="4"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="Staff_ID">
                            <Columns>
                                <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID" SortExpression="StaffID" HeaderStyle-Font-Size="12px" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStaffID" runat="server" Text='<%# Bind("Staff_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name" SortExpression="Name" HeaderStyle-Font-Size="12px">

                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("FullName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email" SortExpression="Email" HeaderStyle-Font-Size="12px" Visible="false">

                                    <ItemTemplate>
                                        <asp:Label ID="lblStaffEmaill" runat="server" Text='<%# Bind("Email") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Package" SortExpression="Package" HeaderStyle-Font-Size="12px">

                                    <ItemTemplate>
                                        <asp:Label ID="lblPackage" runat="server" Text='<%# Bind("Package") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Annual Addition" SortExpression="Annual Addition" HeaderStyle-Font-Size="12px">

                                    <ItemTemplate>
                                        <asp:Label ID="lblAnnualSalaryComp" runat="server" Text='<%# Bind("TotalComponent") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Monthly Addition" SortExpression="Monthly Addition" HeaderStyle-Font-Size="12px">

                                    <ItemTemplate>
                                        <asp:Label ID="lblMonthlySalaryComp" runat="server" Text='<%# Bind("TotalMonthlyComp") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Monthly Deduction" SortExpression="Monthly Deduction" HeaderStyle-Font-Size="12px">

                                    <ItemTemplate>
                                        <asp:Label ID="lblMonthlySalaryContri" runat="server" Text='<%# Bind("TotalAnnualEmployeer") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Annual Deduction" SortExpression="Annual Deduction" HeaderStyle-Font-Size="12px">

                                    <ItemTemplate>
                                        <asp:Label ID="lblAnnualSalaryContri" runat="server" Text='<%# Bind("TotalEmployeer") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Month" SortExpression="Month" HeaderStyle-Font-Size="12px">

                                    <ItemTemplate>
                                        <asp:Label ID="lblMonthGrid" runat="server" Text="" TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        <asp:Label ID="lblUpaidLeave" runat="server" Text="" TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Year" SortExpression="Year" HeaderStyle-Font-Size="12px">

                                    <ItemTemplate>
                                        <asp:Label ID="lblYearGrid" runat="server" Text="" TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        <asp:Label ID="lblHalfDays" runat="server" Text="" TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Net Salary" SortExpression="Net Salary" HeaderStyle-Font-Size="12px">

                                    <ItemTemplate>
                                        <asp:Label ID="lblNetSalary" runat="server" Text="" TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">

                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnViewEmpSalDetails" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnViewEmpSalDetails_Click"><i class="ti ti-eye"></i></asp:LinkButton>
                                    </ItemTemplate>
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
