<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Setup_StaffDetails.aspx.cs" Inherits="MatoshreeProject.Setup_StaffDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var gvStaff = $("#gvStaff1").prepend($("<thead></thead>").append($("#gvStaff1").find("tr:first"))).DataTable(
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
        <h5 class="font-weight-medium mb-0">Staff</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="Setup_StaffDetails.aspx">Staff Details</li>
            </ol>
        </nav>
        <br />
        <%-- BreadCrumbs --%>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12">

                <div class="row">
                    <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                        <br />
                        <div id="addnew" runat="server">
                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:Button ID="btn_New_Staff" runat="server" Text="New Staff Member" CssClass="btn btn-sm btn-primary" OnClick="btn_New_Staff_Click" />

                            </div>
                        </div>
                        <hr />
                    </div>



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
                <h5 class="fs-5 mt-3 mb-3">Staff Summary</h5>
                <div class="row">
                     <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                        <div class="card border-bottom border-success">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblTotalStaffCount" CssClass="text-center text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-success mb-0">
                                            <asp:Label ID="lblTotalStaff" runat="server" Text="Total Staff" Font-Size="12px" Font-Bold="true"></asp:Label>

                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-success display-6">
                                            <iconify-icon icon="solar:user-plus-broken"></iconify-icon>

                                        </span>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                      <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                        <div class="card border-bottom border-info">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblActiveStaffCount" CssClass="text-center text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-info mb-0">
                                            <asp:Label ID="lblActiveStaff" runat="server" Text="Active Staff" Font-Size="12px" Font-Bold="true"></asp:Label>

                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-info display-6">
                                            <iconify-icon icon="solar:user-plus-broken"></iconify-icon>

                                        </span>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                        <div class="card border-bottom border-danger">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblInActiveStaffCount" CssClass="text-center text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-danger mb-0">
                                            <asp:Label ID="lblInActiveStaff" runat="server" Text="Inactive Staff" Font-Size="12px" Font-Bold="true"></asp:Label>

                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-danger display-6">
                                            <iconify-icon icon="solar:user-plus-broken"></iconify-icon>

                                        </span>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                   

                    
                </div>


                <br />

            </div>

        </div>


        <div class="card">
            <div class="card-body">
                 <h5 class="font-weight-medium mb-0">View Staff Detail</h5>
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
                            <%--    <asp:Button ID="Btn_Export" runat="server" Text="Export" CssClass="btn btn-sm btn-outline-success" OnClick="Btn_Export_Click"/>--%>
                            <asp:Button ID="BTN_Visibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="BTN_Visibility_Click" />
                            <asp:Button ID="Btn_Reload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="Btn_Reload_Click" />
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
               
                <asp:GridView ID="gvStaff1" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" OnRowDataBound="gvStaff1_RowDataBound"
                    ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="Staff_ID" Style="width: 100%">
                    <Columns>
                        <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                            <ItemTemplate>
                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Staff_ID" SortExpression="Staff_ID" Visible="false" HeaderStyle-Font-Size="12px">
                            <EditItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("Staff_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblID1" runat="server" Text='<%# Bind("Staff_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FullName" SortExpression="FullName" HeaderStyle-Font-Size="12px">
                            <EditItemTemplate>
                                <asp:Label ID="lblFirst_Name" runat="server" Text='<%# Bind("FullName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <%--  <asp:LinkButton ID="LinkButtonMyprofile" runat="server" Text='<%# Bind("FullName") %>' OnClick="LinkButtonMyprofile_Click"></asp:LinkButton>--%>
                                <asp:Label ID="lblFirst_Name1" runat="server" Text='<%# Bind("FullName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Department" SortExpression="Dept_Name" HeaderStyle-Font-Size="12px">
                            <EditItemTemplate>
                                <asp:Label ID="lblDepartment" runat="server" Text='<%# Bind("Dept_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDepartment1" runat="server" Text='<%# Bind("Dept_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Shift" SortExpression="ShiftName" HeaderStyle-Font-Size="12px">
                            <EditItemTemplate>
                                <asp:Label ID="lblShiftName" runat="server" Text='<%# Bind("ShiftName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblShiftName1" runat="server" Text='<%# Bind("ShiftName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email" SortExpression="Email" HeaderStyle-Font-Size="12px">
                            <EditItemTemplate>
                                <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblEmail1" runat="server" Text='<%# Bind("Email") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Role" SortExpression="Role" HeaderStyle-Font-Size="12px">
                            <EditItemTemplate>
                                <asp:Label ID="lblRole" runat="server" Text='<%# Bind("Role") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRole1" runat="server" Text='<%# Bind("Role") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Last LogIn" SortExpression="Last_login" HeaderStyle-Font-Size="12px">
                            <EditItemTemplate>
                                <asp:Label ID="lblLast_login" runat="server" Text='<%# Bind("Last_login") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblLast_login1" runat="server" Text='<%# Bind("Last_login") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Active" SortExpression="Statusactive" Visible="false" HeaderStyle-Font-Size="12px">
                            <EditItemTemplate>
                                <asp:Label ID="lblStatusShow" runat="server" Text='<%# Bind("Statusactive") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblStatusShow1" runat="server" Text='<%# Bind("Statusactive") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkEditStaff" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="LinkEditStaff_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDeleteStaff" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteStaff_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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

</asp:Content>
