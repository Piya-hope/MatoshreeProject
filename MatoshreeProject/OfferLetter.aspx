<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="OfferLetter.aspx.cs" Inherits="MatoshreeProject.OfferLetter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var GridOfferLetter = $("#GridOfferLetter").prepend($("<thead></thead>").append($("#GridOfferLetter").find("tr:first"))).DataTable(
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
        <h5 class="font-weight-medium mb-0">Candidate</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" aria-current="page" href="OfferLetter.aspx">OfferLetter</a>
                </li>
            </ol>
        </nav>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                <br />
                <div class="row">
                    <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                        <div id="addnew" runat="server">
                            <asp:Button ID="btn_CreateOfferLetter" runat="server" Text="New Offer Letter" CssClass="btn btn-sm btn-primary" OnClick="btn_CreateOfferLetter_Click" />
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
                <h5 class="font-weight-medium mt-3 mb-3">Candidate Summary</h5>
                <div class="row">
                    <div class="col-lg-4 col-md-6">
                        <div class="card border-bottom border-success">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblTotalCandCount" CssClass="text-center text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-success mb-0">
                                            <asp:LinkButton ID="lnkbtnTotalCand" runat="server" Text="Total Apply" CssClass="text-success" Font-Size="12px" Font-Bold="true" CausesValidation="false" OnClick="lnkbtnTotalCand_Click"></asp:LinkButton>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-success display-6">
                                            <%-- <iconify-icon icon="vaadin:user-check"></iconify-icon>--%>
                                            <iconify-icon icon="fa-solid:user-graduate"></iconify-icon>
                                            <%-- <iconify-icon icon="mdi:shield-user"></iconify-icon>--%>
                                        </span>
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
                                            <asp:Label ID="lblActiveCandCount" runat="server" CssClass="text-center text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-info mb-0">
                                            <asp:LinkButton ID="lblActiveCand" runat="server" Text="Accepted" CssClass="text-info" Font-Size="12px" Font-Bold="true" CausesValidation="false" OnClick="lblActiveCand_Click"></asp:LinkButton>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-info display-6">
                                            <%-- <iconify-icon icon="vaadin:user-check"></iconify-icon>--%>
                                            <iconify-icon icon="fa-solid:user-graduate"></iconify-icon>
                                            <%-- <iconify-icon icon="mdi:shield-user"></iconify-icon>--%>
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
                                            <asp:Label ID="lblInActiveCandCount" runat="server" CssClass="text-center  text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label></h2>
                                        <h6 class="fw-medium text-danger mb-0">
                                            <asp:LinkButton ID="lblInActiveCands" runat="server" Text="Rejected" CssClass="text-danger" Font-Size="12px" Font-Bold="true" CausesValidation="false"></asp:LinkButton>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-danger display-6">
                                            <%-- <iconify-icon icon="vaadin:user-check"></iconify-icon>--%>
                                            <iconify-icon icon="fa-solid:user-graduate"></iconify-icon>
                                            <%-- <iconify-icon icon="mdi:shield-user"></iconify-icon>--%>
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
                        <h5 class="font-weight-medium mt-3 mb-3">View Candidate Details</h5>
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
                                    <asp:Button ID="Btn_Visibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="Btn_Visibility_Click" />
                                    <asp:Button ID="btnReload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="btnReload_Click" />
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

                        <asp:GridView ID="GridOfferLetter" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                            ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" FooterStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" OnRowDataBound="GridOfferLetter_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="ID" HeaderStyle-Width="90px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Width="90px" HeaderStyle-Font-Size="14px" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Visible="false" Font-Size="14px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="14px" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="CandNo" Visible="false" SortExpression="CandNo" HeaderStyle-Width="90px" HeaderStyle-Font-Size="14px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblCandNo" runat="server" Text='<%# Bind("Cand_No") %>' TabIndex="6" Font-Bold="false" Font-Size="14px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCandNo1" runat="server" Text='<%# Bind("Cand_No") %>' TabIndex="6" Font-Bold="false" Font-Size="14px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Candidate" SortExpression="Candidate" HeaderStyle-Width="90px" HeaderStyle-Font-Size="14px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblCandName" runat="server" Text='<%# Bind("Cand_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="14px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnCandName1" Text='<%# Bind("Cand_Name") %>' runat="server" CssClass="dropdown-item" OnClick="lnkbtnCandName1_Click"></asp:LinkButton>
                                        <asp:Label ID="lblCandName1" Visible="false" runat="server" Text='<%# Bind("Cand_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="14px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Designation" SortExpression="Tender" HeaderStyle-Width="90px" HeaderStyle-Font-Size="14px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblCandDesignation" runat="server" Text='<%# Bind("Cand_Designation") %>' TabIndex="6" Font-Bold="false" Font-Size="14px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCandDesignation1" runat="server" Text='<%# Bind("Cand_Designation") %>' TabIndex="6" Font-Bold="false" Font-Size="14px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Department" SortExpression="Sales_Agent" HeaderStyle-Width="90px" HeaderStyle-Font-Size="14px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblCandDepartment" runat="server" Text='<%# Bind("Cand_Department") %>' TabIndex="6" Font-Bold="false" Font-Size="14px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCandDepartment1" runat="server" Text='<%# Bind("Cand_Department") %>' TabIndex="6" Font-Bold="false" Font-Size="14px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="EmailID" SortExpression="Sales_Agent" HeaderStyle-Width="90px" HeaderStyle-Font-Size="14px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblCandEmailID" runat="server" Text='<%# Bind("Cand_EmailID") %>' TabIndex="6" Font-Bold="false" Font-Size="14px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCandEmailID1" runat="server" Text='<%# Bind("Cand_EmailID") %>' TabIndex="6" Font-Bold="false" Font-Size="14px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Package" SortExpression="OfferLetter" HeaderStyle-Width="90px" HeaderStyle-Font-Size="14px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblPackage" runat="server" Text='<%# Bind("Package") %>' TabIndex="6" Font-Bold="false" Font-Size="14px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPackage1" runat="server" Text='<%# Bind("Package") %>' TabIndex="6" Font-Bold="false" Font-Size="14px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="GrandTotal" SortExpression="OfferLetter" HeaderStyle-Width="90px" HeaderStyle-Font-Size="14px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblGrandTotal" runat="server" Text='<%# Bind("GrandTotal") %>' TabIndex="6" Font-Bold="false" Font-Size="14px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrandTotal1" runat="server" Text='<%# Bind("GrandTotal") %>' TabIndex="6" Font-Bold="false" Font-Size="14px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Status" Visible="false" SortExpression="Status" HeaderStyle-Width="90px" HeaderStyle-Font-Size="14px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus1" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="14px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="14px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditOfferLetter" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditOfferLetter_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="14px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDeleteOfferletter" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteOfferletter_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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
