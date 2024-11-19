<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="career.aspx.cs" Inherits="MatoshreeProject.career" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridCareer = $("#GridCareer").prepend($("<thead></thead>").append($("#GridCareer").find("tr:first"))).DataTable(
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
        <h5 class="font-weight-medium mb-0">Career</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="career.aspx">Career</li>
            </ol>
        </nav>
      
          <div class="row">
            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                <br />
                <div class="row">
                    <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                        <div id="addnew" runat="server">
                            <asp:Button ID="btnAddCareer" runat="server" Text="Add Career" CssClass="btn btn-sm btn-primary" OnClick="btnAddCareer_Click" />
                        </div>
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

                <h5 class="font-weight-medium mt-3 mb-3">Career Summary</h5>
                <div class="row">

                    <div class="col-lg-4 col-md-6">
                        <div class="card border-bottom border-success">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblTotalCareerCount" CssClass="text-center text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-success mb-0">
                                            <%--<asp:Label ID="lblTotalCareer1" runat="server" Text="Total Apply" CssClass="text-success" Font-Size="12px" Font-Bold="true"></asp:Label>--%>
                                            <asp:LinkButton ID="lblTotalCareer" runat="server" Text="Total Apply" CssClass="text-success" Font-Size="12px" Font-Bold="true" CausesValidation="false" OnClick="lblTotalCareer_Click"></asp:LinkButton>
                                            </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-success display-6">
                                           <iconify-icon icon="fa-solid:user-tie"  class="aside-icon"></iconify-icon>
                                        </span>
                                        <%--  <span class="text-success display-6"><i class="ti ti-file-text"></i></span>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6">
                        <div class="card border-bottom border-info">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblActiveCareerCount" runat="server" CssClass="text-center text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-info mb-0">
                                            <asp:LinkButton ID="lblActiveCareer" runat="server" Text="Accepted" CssClass="text-info" Font-Size="12px" Font-Bold="true" CausesValidation="false" OnClick="lblActiveCareer_Click"></asp:LinkButton>

                                            <%--<asp:Label ID="lblActiveCustmer" runat="server" Text="Active Customers" CssClass="text-info" Font-Size="12px" Font-Bold="true"></asp:Label>--%>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-info display-6">
                                            <iconify-icon icon="fa-solid:user-tie"  class="aside-icon"></iconify-icon>
                                          <%--  <iconify-icon icon="carbon:user-multiple" class="aside-icon"></iconify-icon>--%>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="col-lg-4 col-md-6">
                        <div class="card border-bottom border-danger">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblInActiveCareerCount" runat="server" CssClass="text-center  text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label></h2>
                                        <h6 class="fw-medium text-danger mb-0">
                                            <asp:LinkButton ID="lblInActiveCareers" runat="server" Text="Rejected" CssClass="text-danger" Font-Size="12px" Font-Bold="true" CausesValidation="false"></asp:LinkButton>
                                           
                                            <%--<asp:Label ID="lblInActiveCustomers" runat="server" Text="Inactive Customers" CssClass="text-danger" Font-Size="12px" Font-Bold="true"></asp:Label>--%></h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-danger display-6">
                                   <iconify-icon icon="fa-solid:user-tie"  class="aside-icon"></iconify-icon>

                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <h5 class="font-weight-medium mt-3 mb-3">View Career Details</h5>
                        <hr />

                        <div class="row">
                            <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                                <div class="bd-example">
                                    <div class="btn-group">
                                        <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                        <asp:Button ID="btnmore" runat="server" Style="display: none" />

                                        <div class="dropdown-menu">
                                            <asp:LinkButton ID="lnkbtnExcelcareer" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="lnkbtnExcelcareer_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="linkbtnPDFcareer" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnPDFcareer_Click"></asp:LinkButton>

                                        </div>
                                    </div>
                                    <asp:Button ID="BTN_Visibilitycareer" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="BTN_Visibilitycareer_Click"/>

                                    <asp:Button ID="Btn_Reloadcareer" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="Btn_Reloadcareer_Click" />


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
                        <br />

                        <asp:GridView ID="GridCareer" runat="server" ScrollBars="Both" CssClass="table border table-hover table-bordered text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="id" OnRowDataBound="GridCareer_RowDataBound1" OnRowDeleting="GridCareer_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="id" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="id" SortExpression="ID" Visible="false" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("id") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("id") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FullName" SortExpression="FullName" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblFullName" runat="server" Text='<%# Bind("FullName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblFullName1" runat="server" Text='<%# Bind("FullName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
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
                                <asp:TemplateField HeaderText="Phone" SortExpression="Phone" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblMobileNumber" runat="server" Text='<%# Bind("MobileNumber") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblMobileNumber1" runat="server" Text='<%# Bind("MobileNumber") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                                <asp:TemplateField HeaderText="Status" SortExpression="Status" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblStats61" runat="server" Text=""></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStats6" runat="server" Text='<%# Bind("Approval") %>' Visible="false"></asp:Label>
                                        <asp:Button ID="btnStatus" runat="server" Text='<%# Bind("Approval") %>' Style="border-radius: 80px;" Font-Size="12px" Visible="false"/>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Qualification" SortExpression="Qualification" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblQualification" runat="server" Text='<%# Bind("Qualification") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblQualification1" runat="server" Text='<%# Bind("Qualification") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Experience" SortExpression="Experience" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblExperience" runat="server" Text='<%# Bind("Experience") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblExperience1" runat="server" Text='<%# Bind("Experience") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Position" SortExpression="AppliedPost" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblAppliedPost" runat="server" Text='<%# Bind("AppliedPost") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAppliedPost1" runat="server" Text='<%# Bind("AppliedPost") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                             <%--   <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditcarrier" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditcarrier_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDeletecarrier" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeletecarrier_Click"><i class="ti ti-trash"></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>--%>
                                   <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnViewcarrier" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-info" OnClick="btnViewcarrier_Click"><i class="ti ti-eye"></i></asp:LinkButton>
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
