<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeSalDetails.aspx.cs" Inherits="MatoshreeProject.EmployeeSalDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridViewCompansion = $("#GridEmpSalDetails").prepend($("<thead></thead>").append($("#GridEmpSalDetails").find("tr:first"))).DataTable(
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
          <h5 class="card-title">Employee Salary Details</h5>
                        <%-- BreadCrumbs --%>
                    
                        <nav aria-label="breadcrumb">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item">
                                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                                    </a>
                                </li>
                                <li class="breadcrumb-item text-muted" aria-current="page" href="EmployeeSalDetails.aspx">Employee Salary Details</li>
                            </ol>
                        </nav>
                        <%-- BreadCrumbs --%>

        <div class="row">
            <div class="card-title">
                  <br />
                  <div class="row">
                              <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                                  <div id="addnew" runat="server">
                                <asp:Button ID="btnSalaryStructure" runat="server" Text="Salary Structure" CssClass="btn btn-sm btn-primary" OnClick="btnSalaryStructure_Click" />
                            </div>
                                  </div>
                         <%--   <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:Button ID="btnSamplePackage" runat="server" Text="Sample Package" CssClass="btn btn-sm btn-success" OnClick="btnSamplePackage_Click" />
                            </div>--%>

                         <%-- Toaster --%>
                    <div class="col-md-4 col-sm-4 col-xl-4 col-lg-4">
                        <div id="Toasteralert"  runat="server" visible="false">
                            <div class="toast" role="alert" aria-live="assertive" aria-atomic="true">
                                <div class="d-flex">
                                    <div class="toast-body">
                                        <asp:Label ID="lblMessage" runat="server" Text="" Font-Size="13.5px" ForeColor="Black"></asp:Label>
                                    </div>
                                    <button type="button" class="btn-close me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
                                </div>
                            </div>
                        </div>

                         <div id="deleteToaster"  runat="server" visible="false">
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
                 <hr />

             <%--   <h5 class="font-weight-medium mt-3 mb-3">Employee Salary Summary</h5>--%>
                <asp:Label ID="lblTittle" runat="server" Text="" Font-Bold="true" Font-Size="20px"></asp:Label>

                <div class="card">
                    <div class="card-body">
                       <h5 class="font-weight-medium mt-3 mb-3">View Employee Salary Details</h5>
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

                                    <asp:Button ID="Btn_Reload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="Btn_Reload_Click" />


                                </div>
                            </div>

                            <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                                <asp:Image ID="Image1" runat="server" Style="display: none; border: 1px solid #ccc" />
                                <asp:Image ID="Image2" runat="server" Style="display: none; border: 1px solid #ccc" />
                                <asp:Label ID="lbladdCompany11" runat="server" Text="" CssClass="font-bold text-dark " Visible="false"></asp:Label>
                                <asp:Label ID="lbladdress11" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddCity1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddState1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddCountry1" runat="server" Text="," CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblpincode" runat="server" Text="PIN:" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblphone" runat="server" Text="Phone:" CssClass="" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblphoneNo1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblvat" runat="server" Text="VAT NO:" CssClass="" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblVatNo1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" CssClass="" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblGSTNo1A" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                            </div>
                        </div>

                        <br />
                       
                        <asp:GridView ID="GridEmpSalDetails" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" OnRowDataBound="GridEmpSalDetails_RowDataBound" Width="100%" CellPadding="4"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="Staff_ID">
                            <Columns>
                                <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID" SortExpression="StaffID" HeaderStyle-Font-Size="12px" Visible="false">

                                    <ItemTemplate>
                                        <asp:Label ID="lblStaffID1" runat="server" Text='<%# Bind("Staff_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name" SortExpression="Name" HeaderStyle-Font-Size="12px">

                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("FullName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Department" SortExpression="Department" HeaderStyle-Font-Size="12px">

                                    <ItemTemplate>
                                        <asp:Label ID="lblDeptName" runat="server" Text='<%# Bind("Dept_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Designation" SortExpression="Designation" HeaderStyle-Font-Size="12px">

                                    <ItemTemplate>
                                        <asp:Label ID="lblDesignation" runat="server" Text='<%# Bind("Role") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Package" SortExpression="Package" HeaderStyle-Font-Size="12px">

                                    <ItemTemplate>
                                        <asp:Label ID="lblPackage" runat="server" Text='<%# Bind("Package") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Monthly Salary" SortExpression="Monthly Salary" HeaderStyle-Font-Size="12px">

                                    <ItemTemplate>
                                        <asp:Label ID="lblMonthlySalary" runat="server" Text='<%# Bind("TotalMonthlyComp") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Status" SortExpression="Status" HeaderStyle-Font-Size="12px" Visible="true">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblStats61" runat="server" Text=""></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStats6" runat="server" Text='<%# Bind("Status") %>' Visible="False"></asp:Label>
                                        <asp:Button ID="btnStatus" runat="server" Text='<%# Bind("Status") %>' OnClick="btnStatus_Click" Font-Size="12px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                              <%--  <asp:TemplateField HeaderText="Status" SortExpression="Status" HeaderStyle-Font-Size="12px" Visible="true">

                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>

                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditSalaryStructure" runat="server" CausesValidation="false" OnClick="btnEditSalaryStructure_Click" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"  ></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                               <%-- <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                   <%-- <ItemTemplate>
                                        <asp:CheckBox ID="chkStatus" runat="server" BackColor="LightGreen" Text="" CssClass="btn btn-sm btn-outline-success" OnCheckedChanged="chkStatus_CheckedChanged" AutoPostBack="true" />
                                    </ItemTemplate>
                                      <ItemTemplate>
                                        <asp:LinkButton ID="btnViewEmpSalDetails" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-info" OnClick="btnViewEmpSalDetails_Click"><i class="ti ti-eye"></i></asp:LinkButton>
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
