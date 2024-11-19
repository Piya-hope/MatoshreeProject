<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="InventoryUserAllocation.aspx.cs" Inherits="MatoshreeProject.InventoryUserAllocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var GridInventoryStaff = $("#GridInventoryStaff").prepend($("<thead></thead>").append($("#GridInventoryStaff").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });
        });
        $(document).ready(function () {
            var GridViewinventoryStaffMapping = $("#GridViewinventoryStaffMapping").prepend($("<thead></thead>").append($("#GridViewinventoryStaffMapping").find("tr:first"))).DataTable(
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
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="font-weight-medium mb-0">Depo Allocation</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="#">Inventory
                            </a>
                        </li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="InventoryUserAllocation.aspx">Inventory User Allocation</li>
                    </ol>
                </nav>
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
        <div class="row">
            <div class="col-md-6 col-sm-6 col-lg-6">
                <div class="card">
                    <div class="card-body">
                        <h6>Depo Allocation</h6>
                        <hr />
                        <div class="col-md-12 col-sm-12 col-lg-12">

                            <div class="col-md-8 col-sm-8 col-lg-8">
                                <div class="mb-2">
                                    <asp:Label ID="lblDepo" runat="server" Text="Depo" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                                    <asp:DropDownList ID="ddlDepo" runat="server" CssClass="form-control form-select">
                                    </asp:DropDownList>
                                </div>
                                <div class="mb-2">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDepo" ErrorMessage="Select Depo" ForeColor="Red" Display="Dynamic" InitialValue="0" ValidationGroup="Inventory" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-md-4 col-sm-4 col-lg-4 col-xs-4">
                            </div>
                        </div>

                        <br />

                        <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12">
                            <div class="mb-2">

                                <asp:GridView ID="GridInventoryStaff" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                    ClientIDMode="Static" ShowHeader="true" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" OnRowDataBound="GridInventoryStaff_RowDataBound" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="Staff_ID">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblchk" runat="server" Text="" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkInvDepo" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField Visible="false">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblInventoryStaffID" runat="server" Text="" Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblInventoryStaffID1" runat="server" Text='<%# Bind("Staff_ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblInventoryStaffName" runat="server" Text="StaffName" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblInventoryStaffName1" runat="server" Text='<%# Bind("FullName") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblInventoryStaffRole" runat="server" Text="Designation" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblInventoryStaffRole1" runat="server" Text='<%# Bind("Role") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblInventoryStaffPhonNo" runat="server" Text="PhoneNumber" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblInventoryStaffPhonNo1" runat="server" Text='<%# Bind("PhoneNumber") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblInventoryStaffEmail" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblInventoryStaffEmail1" runat="server" Text='<%# Bind("Email") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                     <EmptyDataTemplate>
                                <div align="center" style="color: red">
                                    <h6>No records found.</h6>
                                </div>
                            </EmptyDataTemplate>
                                </asp:GridView>

                                <br />
                                <center>

                                    <div class="mb-2">
                                        <asp:Button ID="Btn_Allocate" runat="server" CssClass="btn btn-success btn-sm" ValidationGroup="Inventory" Text="Allocate" OnClick="Btn_Allocate_Click" />
                                        &nbsp;&nbsp;    
                                       <asp:Button ID="Btn_Decline" runat="server" CssClass="btn btn-danger btn-sm" Text="Deallocate" OnClick="Btn_Decline_Click" ValidationGroup="Inventory" />

                                    </div>

                                </center>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

            <div class="col-md-6 col-sm-6 col-lg-6">
                <div class="card">
                    <div class="card-body">
                        <h6>View Staff Inventory Allocation</h6>
                        <hr />

                        <div class="col-md-6 col-sm-6 col-lg-6">
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
                                <asp:Button ID="Btn_Reload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="Btn_Reload_Click" />
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

                        <br />

                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="lblDepo1" runat="server" Text="Search By Depo" CssClass="form-label"></asp:Label><span class="text-danger"> *</span>
                            </div>

                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="mb-2">
                                            <asp:DropDownList ID="ddlDepo1" runat="server" CssClass="form-control form-select">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="mb-2">
                                            <asp:Button ID="Btn_Search" runat="server" CssClass="btn btn-sm btn-primary" Text="Search" OnClick="Btn_Search_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <br />

                        <div class="col-md-12 col-sm-12 col-lg-12">
                            <div class="mb-2">
                                <asp:GridView ID="GridViewinventoryStaffMapping" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                    ClientIDMode="Static" ShowHeader="true" EmptyDataText="No Records Found" OnRowDataBound="GridViewinventoryStaffMapping_RowDataBound" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="MAPID">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField Visible="false">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblInventoryDepoID" runat="server" Text="" Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblInventoryDepoID1" runat="server" Text='<%# Bind("MAPID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblInventoryDepoName" runat="server" Text="DepoName" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblInventoryDepoName1" runat="server" Text='<%# Bind("DepoName") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblInventoryStaffName" runat="server" Text="StaffName" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblInventoryStaffName1" runat="server" Text='<%# Bind("StaffName") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblInventoryStaffRole" runat="server" Text="Designation" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblInventoryStaffRole1" runat="server" Text='<%# Bind("Role") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblInventoryStaffPhonNo" runat="server" Text="PhoneNumber" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblInventoryStaffPhonNo1" runat="server" Text='<%# Bind("PhoneNumber") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblInventoryStaffEmail" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblInventoryStaffEmail1" runat="server" Text='<%# Bind("Email") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblInventoryDepoAddress" runat="server" Text="DepoAddress" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblInventoryDepoAddress1" runat="server" Text='<%# Bind("Address") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblInventoryStatus" runat="server" Text="Address" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblInventoryStatus" runat="server" Text='<%# Bind("Status") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                    </div>


                </div>


            </div>

        </div>
    </div>
</asp:Content>
