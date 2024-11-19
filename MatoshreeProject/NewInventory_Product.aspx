<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="NewInventory_Product.aspx.cs" Inherits="MatoshreeProject.NewInventory_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridCalculate = $("#GridCalculate").prepend($("<thead></thead>").append($("#GridCalculate").find("tr:first"))).DataTable(
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
         <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="font-weight-medium mb-0">New Product</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Inventory_Product.aspx">Product Details
                            </a>
                        </li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="#">New Product</li>
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
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6 col-sm-6 col-lg-6 border-right">
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6 col-sm-6 col-lg-6">
                                            <div class="mb-2">
                                                <asp:Label ID="lblUsername" runat="server" Text="UserName" CssClass="form-label"></asp:Label>
                                                <asp:TextBox ID="txtusername" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6 col-sm-6 col-lg-6">
                                            <div class="mb-2">
                                                <asp:Label ID="lblDesignation" runat="server" Text="Designation" CssClass="form-label"></asp:Label>
                                                <asp:TextBox ID="txtDesignation" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 col-sm-12 col-lg-12">
                                    <div class="row">
                                        <div class="col-md-6 col-sm-6 col-lg-6">
                                            <div class="mb-2">
                                                <asp:Label ID="lblPhoneNo" runat="server" Text="Phone No" CssClass="form-label"></asp:Label>
                                                <asp:TextBox ID="txtPhoneNo" CssClass="form-control" runat="server" TextMode="Number" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6 col-sm-6 col-lg-6">
                                            <div class="mb-2">
                                                <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 col-sm-12 col-lg-12">
                                    <div class="mb-2">
                                        <asp:Label ID="lblProjects" runat="server" Text="Project" CssClass="form-label"></asp:Label>
                                        <asp:DropDownList ID="ddlProjects" runat="server" CssClass="form-control form-select" OnSelectedIndexChanged="ddlProjects_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-6 col-lg-6 border-right">
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <div class="mb-2">
                                    <asp:Label ID="lblInventoryDepo" runat="server" Text="Inventory Depo" CssClass="form-label"></asp:Label>
                                    <asp:DropDownList ID="ddlDepo" runat="server" CssClass="form-control form-select" OnSelectedIndexChanged="ddlDepo_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <div class="mb-2">
                                    <asp:Label ID="lbldepotype" runat="server" Text="Depo Type" CssClass="form-label"></asp:Label>
                                    <asp:DropDownList ID="ddldepoType" runat="server" CssClass="form-control form-select">
                                        <asp:ListItem Value="0">Select NA</asp:ListItem>
                                        <asp:ListItem Value="Office">Office</asp:ListItem>
                                        <asp:ListItem Value="Rental">Rental</asp:ListItem>
                                        <asp:ListItem Value="Project">Project</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4 col-sm-4 col-lg-4">
                            <div class="mb-2">
                                <asp:Label ID="Label11" runat="server"></asp:Label>
                                 <div class="input-group">
                                        <asp:DropDownList ID="ddlItem" runat="server" CssClass="form-select form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <!-- Button trigger modal -->
                                        <button type="button" class="btn btn-info btn-sm font-medium"
                                            data-bs-toggle="modal" data-bs-target="#ItemID">
                                            +
                                        </button>
                                    </div>
                            </div>
                        </div>
                         <div class="col-md-4 col-sm-4 col-lg-4">
                            <div class="mb-2">
                                <asp:Label ID="Label2" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-4 col-sm-4 col-lg-4"></div>
                       
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-lg-12">
                            <div class="alert alert-warning" role="alert" id="msgdiv" runat="server" visible="false">
                                <asp:Label ID="lblMsg1" runat="server" Text="" Visible="false" Font-Bold="false" CssClass="font-12" ForeColor="Red" ValidateRequestMode="Disabled"></asp:Label>
                            </div>
                            <div class="alert alert-info" role="alert" id="SuccessDiv1" runat="server" visible="false">
                                <asp:Label ID="lblMsg" runat="server" Text="" Visible="false" Font-Bold="false" CssClass="font-12" ForeColor="Blue" ValidateRequestMode="Disabled"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-lg-12">
                            
                                <asp:GridView ID="GridCalculate" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                    ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" FooterStyle-BackColor="#f8f9fa" HeaderStyle-Font-Bold="true" ShowFooter="true" DataKeyNames="ID" OnRowDataBound="GridCalculate_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField Visible="false" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemid" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Font-Size="12px">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblItem" runat="server" Text="Item" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblItem1" runat="server" Text='<%# Bind("ProductName") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtItem" runat="server" TextMode="MultiLine" Text="" CssClass="form-control" Placeholder="Description" Style="width: auto"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfv_TenderItem" ControlToValidate="txtItem" Display="Dynamic" runat="server" ErrorMessage="Please Select Item" ForeColor="Red" ValidationGroup="ItemTender" Font-Size="12px"></asp:RequiredFieldValidator>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Font-Size="12px">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescription1" runat="server" Text='<%# Bind("Description") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Text="" CssClass="form-control" Placeholder="Long Description" Style="width: auto"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="120px" HeaderStyle-Font-Size="12px">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblQuantity" runat="server" Text="Quantity" CssClass="form-label" Font-Size="12px"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtQty1" runat="server" Text='<%# Bind("Quantity") %>' CssClass="form-control" Placeholder="Quantity" TextMode="Number" Style="width: 90px" Visible="false" OnTextChanged="txtQty1_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                <asp:Label ID="lblQuantity1" runat="server" Text='<%# Bind("Quantity") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtQty" runat="server" Text="1" CssClass="form-control" Placeholder="Quantity" TextMode="Number" Style="width: 105px" OnTextChanged="txtQty_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="50px" HeaderStyle-Font-Size="12px">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblRate" runat="server" Text="Rate" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtProRate" runat="server" Text='<%# Bind("Rate") %>' CssClass="form-control" Style="width: 105px" Visible="false" OnTextChanged="txtProRate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtrate1" runat="server" CssClass="form-control" Placeholder="Rate" TextMode="Number" Style="width: 105px" OnTextChanged="txtrate1_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="120px" HeaderStyle-Font-Size="12px">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblCategory" runat="server" Text="Category" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblCategory1" runat="server" Text='<%# Bind("Category") %>' Font-Bold="false" CssClass="font-12" Visible="false"></asp:Label>
                                                <asp:DropDownList ID="ddlProjectCategory" runat="server" CssClass="form-select form-control" Visible="false" Style="width: 105px">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddlProjectCategory1" runat="server" CssClass="form-select form-control" Style="width: 105px">
                                                </asp:DropDownList>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="120px" HeaderStyle-Font-Size="12px">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblProductType" runat="server" Text="Usable" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductType" runat="server" Text='<%# Bind("ProductType") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                <asp:DropDownList ID="ddlProType" runat="server" CssClass="form-control form-select" Visible="false" Style="width: 105px" OnSelectedIndexChanged="ddlProType_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem Value="0" Text="Select NA"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="OneTime"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Reusable"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList ID="ddlProType1" runat="server" CssClass="form-control form-select" Style="width: 105px">
                                                    <asp:ListItem Value="0" Text="Select NA"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="OneTime"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Reusable"></asp:ListItem>
                                                </asp:DropDownList>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Font-Size="12px">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblAmontname" runat="server" Text="Amount" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmont1" runat="server" Text='<%#Bind("TotalAmount") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblAmontP" runat="server" Text="" Font-Bold="false" CssClass="font-12"></asp:Label>

                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Font-Size="12px" Visible="false">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblCreateBy" runat="server" Text="AddedBy" CssClass="form-label"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblCreateBy1" runat="server" Text='<%#Bind("CreateBy") %>' Font-Bold="false" CssClass="font-12"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblCreateByF" runat="server" Text="" Font-Bold="false" CssClass="font-12"></asp:Label>

                                            </FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-Font-Size="12px">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="btnOption" runat="server" Text="" ValidationGroup="setting" CssClass="font-14"><i class="ti ti-settings"></i></asp:LinkButton>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDeleteItemCal" runat="server" CausesValidation="false" CssClass="btn btn-sm btn-rounded btn-danger" ValidationGroup="DelItemTender" Text="" OnClientClick="return confirm('Are you sure you want to delete?')" Visible="false" OnClick="btnDeleteItemCal_Click"><i class="ti ti-trash"></i></asp:LinkButton>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:LinkButton ID="btnAddItem" runat="server" CausesValidation="false" CssClass="btn btn-sm btn-rounded btn-info" Text="" TabIndex="9" OnClick="btnAddItem_Click" ValidationGroup="ItemTender"><i class="ti ti-check"></i></asp:LinkButton>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                       
                    </div>
                </div>
            </div>
        </div>


         <!-- Modal -->
        <div class="row">
            <div class="col-md-6">
                <!-- Modal -->
                <div class="modal fade" id="ItemID" data-bs-backdrop="static"
                    data-bs-keyboard="false" tabindex="-1" aria-labelledby="scroll-long-inner-modal"
                    aria-hidden="true">
                    <div class="modal-dialog modal-dialog-scrollable">
                        <div class="modal-content">
                            <div class="modal-header d-flex align-items-center">
                                <h4 class="modal-title" id="myLargeModalLabel"></h4>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">

                                <h5 class="text-purple">Add Item</h5>
                                <hr />
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="mb-2">
                                            <asp:Label ID="lbl_Description" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txt_Description" runat="server" Font-Size="12px" CssClass="form-control" placeholder="Enter Description"></asp:TextBox>
                                        </div>

                                        <div class="mb-2">
                                            <asp:Label ID="lbl_Rate" runat="server" Text="Rate" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:TextBox ID="txt_Rate" runat="server" CssClass="form-control" Font-Size="12px" placeholder="Enter Rate"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Rate" runat="server" ErrorMessage="Enter Rate" Display="Dynamic" ControlToValidate="txt_Rate" ForeColor="Red" ValidationGroup="SaveITEM" Font-Size="12px"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="mb-2">
                                            <asp:Label ID="lblHSNCode" runat="server" Text="HSNCode" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:TextBox ID="txtHSNCode" runat="server" CssClass="form-control" Font-Size="12px" placeholder="Enter HSNCode"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtHSNCode" ErrorMessage="Enter HSNCode" ForeColor="Red" ValidationGroup="SaveITEM" Font-Size="12px"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="mb-2">
                                            <asp:Label ID="lbl_LongDescription" runat="server"  Text="Long Description" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txt_LongDescription" TextMode="MultiLine" runat="server" Font-Size="12px" CssClass="form-control" placeholder="Enter Long Description"></asp:TextBox>
                                        </div>

                                        <div class="mb-2">
                                            <asp:Label ID="lbl_Tax" runat="server" Text="Tax1"  CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:DropDownList ID="ddlTaxitem" runat="server" CssClass="form-control" Font-Size="12px" AutoPostBack="true" OnSelectedIndexChanged="ddlTaxitem_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="lblTaxValues1" runat="server" Font-Bold="true" Text="" Font-Size="12px" Visible="false"></asp:Label>


                                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlTaxitem" ErrorMessage="Select TAX1" InitialValue="0" ForeColor="Red" ValidationGroup="SaveITEM" Font-Size="12px"></asp:RequiredFieldValidator>

                                        </div>

                                        <div class="mb-2">
                                            <asp:Label ID="lbl_Tax2" runat="server" Text="Tax2" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:DropDownList ID="ddlTaxItem1" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTaxItem1_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="lblTaxValues2" runat="server" Font-Bold="true" Text="" Font-Size="12px" Visible="false"></asp:Label>

                                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlTaxItem1" ErrorMessage="Select TAX2" InitialValue="0" ForeColor="Red" ValidationGroup="SaveITEM" Font-Size="12px"></asp:RequiredFieldValidator>

                                        </div>



                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlTaxitem" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlTaxItem1" EventName="SelectedIndexChanged" />

                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <br />
                            <div class="modal-footer">
                                <asp:Button ID="btnSaveItem" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="SaveITEM" OnClick="btnSaveItem_Click" />
                                &nbsp;&nbsp;
                                                <button type="button"
                                                    class="btn btn-sm btn-danger"
                                                    data-bs-dismiss="modal">
                                                    Close
                                                </button>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Modal -->
            </div>
        </div>
        <!-- Modal -->
    </div>
         </div>
</asp:Content>
