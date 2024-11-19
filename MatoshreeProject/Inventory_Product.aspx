<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Inventory_Product.aspx.cs" Inherits="MatoshreeProject.Inventory_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridInventoryProd = $("#GridInventoryProd").prepend($("<thead></thead>").append($("#GridInventoryProd").find("tr:first"))).DataTable(
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
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="https://cdn.rawgit.com/mobomo/sketch.js/master/lib/sketch.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="font-weight-medium mb-0">Product Details</h5>
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
                        <li class="breadcrumb-item text-muted" aria-current="page" href="Inventory_Product.aspx">Product Details</li>
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
            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">

                <div id="addnew" runat="server">
                    <div class="col-md-12 col-sm-12 col-ld-12">
                        <div class="row">

                            <div class="col-md-1 col-sm-1 col-ld-1 align-items-start">
                                <asp:Button ID="btnNewInventoryProd" runat="server" Text="New Product" CssClass="btn btn-sm btn-primary" OnClick="btnNewInventoryProd_Click" />
                            </div>
                            <div class="col-md-7 col-sm-7 col-ld-7"></div>
                            <div class="col-md-1 col-sm-1 col-ld-1">
                                <asp:Label ID="Label1" runat="server" Text="Depo" CssClass="form-label"></asp:Label>
                            </div>
                            <div class="col-md-3 col-sm-3 col-ld-3 text-end">
                                <asp:DropDownList ID="ddlDepo" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlDepo_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>

                            </div>
                            
                        </div>
                    </div>
                    <hr />
                </div>
                <h5>Product Summary</h5>
                <div class="row">
                    <div class="col-lg-4 col-md-6">
                        <div class="card border-bottom border-success">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblTotalInventoryProdCount" CssClass="text-center text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-success mb-0">
                                            <asp:Label ID="lblTotalVendors" runat="server" Text="Total Product" CssClass="text-success" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-success display-6">
                                           
                                            <iconify-icon icon="fluent-mdl2:product" class="aside-icon"></iconify-icon>
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
                                            <asp:Label ID="lblActiveInventoryProdsCount" runat="server" CssClass="text-center text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-info mb-0">
                                            <asp:Label ID="lblActiveVendors" runat="server" Text="Active Product" CssClass="text-info" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-info display-6">
                                            <iconify-icon icon="fluent-mdl2:product" class="aside-icon"></iconify-icon>
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
                                            <asp:Label ID="lblInActiveInventoryProdsCount" runat="server" CssClass="text-center  text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label></h2>
                                        <h6 class="fw-medium text-danger mb-0">
                                            <asp:Label ID="lblInActiveVendors" runat="server" Text="Inactive Product" CssClass="text-danger" Font-Size="12px" Font-Bold="true"></asp:Label></h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-danger display-6">
                                            <iconify-icon icon="fluent-mdl2:product" class="aside-icon"></iconify-icon>
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
                        <h5>View Product Details</h5>
                        <hr />
                        <div class="">
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
                            <div class="col-md-2">
                                <asp:Image ID="Image1" runat="server" Style="display: none; border: 1px solid #ccc" />
                                <asp:Label ID="lbladdCompany11" runat="server" Text="" CssClass="font-bold text-dark font-14" Visible="false"></asp:Label>
                                <asp:Label ID="lbladdress11" runat="server" Text="" CssClass="font-14" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddCity1" runat="server" Text="" CssClass="font-14" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text="" CssClass="font-14" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddState1" runat="server" Text="" CssClass="font-14" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddCountry1" runat="server" Text="," Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblpincode" runat="server" Text="PIN:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblphone" runat="server" Text="Phone:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblphoneNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblvat" runat="server" Text="VAT NO:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblVatNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblGSTNo1A" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                            </div>
                        </div>
                        <br />
                        <asp:GridView ID="GridInventoryProd" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridInventoryProd_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblInventoryProdID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblInventoryProdID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ProductName" SortExpression="ProductName" HeaderStyle-Font-Size="12px" HeaderStyle-Width="120px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("ProductName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductName1" runat="server" Text='<%# Bind("ProductName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DepoName" SortExpression="DepoName" HeaderStyle-Font-Size="12px" HeaderStyle-Width="120px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblDepo" runat="server" Text='<%# Bind("DepoName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDepoID" runat="server" Text='<%# Bind("DepoID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                        <asp:Label ID="lblDepo1" runat="server" Text='<%# Bind("DepoName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Usable" SortExpression="ProductType" HeaderStyle-Font-Size="12px" HeaderStyle-Width="120px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblProductType" runat="server" Text='<%# Bind("ProductType") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductType1" runat="server" Text='<%# Bind("ProductType") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Font-Size="12px" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescription1" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity" HeaderStyle-Font-Size="12px" HeaderStyle-Width="70px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuantity1" runat="server" Text='<%# Bind("Quantity") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Rate" SortExpression="Rate" HeaderStyle-Font-Size="12px" HeaderStyle-Width="70px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblRate" runat="server" Text='<%# Bind("Rate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRate1" runat="server" Text='<%# Bind("Rate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TotalAmount" SortExpression="TotalAmount" HeaderStyle-Font-Size="12px" HeaderStyle-Width="90px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblTotalAmount" runat="server" Text='<%# Bind("TotalAmount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalAmount1" runat="server" Text='<%# Bind("TotalAmount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Category" SortExpression="Category" HeaderStyle-Font-Size="12px" HeaderStyle-Width="120px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategory1" runat="server" Text='<%# Bind("Category") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Createdate" SortExpression="Createdate" HeaderStyle-Font-Size="12px" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblCreatedate" runat="server" Text='<%# Bind("Createdate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreatedate1" runat="server" Text='<%# Bind("Createdate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" SortExpression="Status" HeaderStyle-Font-Size="12px" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus1" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px" Visible="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditProd" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditProd_Click" Text=""><i class="ti ti-edit"></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Font-Size="12px">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblCreateBy" runat="server" Text="AddedBy" Font-Size="12px"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreateBy1" runat="server" Text='<%#Bind("CreateBy") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
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
