<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="EditInventory_Product.aspx.cs" Inherits="MatoshreeProject.EditInventory_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="font-weight-medium mb-0">Edit Product</h5>
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
                        <li class="breadcrumb-item text-muted" aria-current="page" href="#">Edit Product</li>
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

            <%-- <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">--%>
            <div class="card">
                <div class="card-body">
                    <asp:Label ID="lblInventoryProdid" runat="server" Text="" Visible="false"></asp:Label>
                    <hr />
                    <div class="row mb-3">
                        <div class="col-md-2 col-sm-2 col-lg-2">
                            <asp:Label ID="lblProdName" runat="server" Text="Product Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                        </div>
                        <div class="col-md-3 col-sm-3 col-lg-3">
                            <asp:TextBox ID="txtProdName" CssClass="form-control" runat="server" Placeholder="Enter Product Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtProdName" Display="Dynamic" runat="server" ErrorMessage="Enter Product Name" ForeColor="Red" ValidationGroup="Inventory1" Font-Size="12px"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2 col-sm-2 col-lg-2"></div>
                        <div class="col-md-2 col-sm-2 col-lg-2">
                            <asp:Label ID="lblProdType" runat="server" Text="Usable" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                        </div>
                        <div class="col-md-3 col-sm-3 col-lg-3">
                            <asp:DropDownList ID="ddlProdType" runat="server" CssClass="form-control form-select">
                                <asp:ListItem Value="0" Text="Select Product Type"></asp:ListItem>
                                <asp:ListItem Value="OneTime" Text="OneTime"></asp:ListItem>
                                <asp:ListItem Value="Reusable" Text="Reusable"></asp:ListItem>
                            </asp:DropDownList>
                            <%--<asp:TextBox ID="txtProdType" CssClass="form-control" runat="server" Placeholder="Enter Product Type"></asp:TextBox>--%>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlProdType" Display="Dynamic" runat="server" ErrorMessage="Enter Usable" ForeColor="Red" ValidationGroup="Inventory1" Font-Size="12px"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <div class="col-md-2 col-sm-2 col-lg-2">
                            <asp:Label ID="lblDepo" for="Depo" runat="server" Text="Depo" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                        </div>
                        <div class="col-md-3 col-sm-3 col-lg-3">
                            <asp:DropDownList ID="ddlDepo" runat="server" CssClass="form-control form-select" Placeholder="Select Category" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Select Depo" ControlToValidate="ddlDepo" ForeColor="Red" Font-Bold="false" ValidationGroup="Inventory1" InitialValue="0" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-2 col-sm-2 col-lg-2"></div>

                        <div class="col-md-2 col-sm-2 col-lg-2">
                            <asp:Label ID="lblMeasurement" for="Depo" runat="server" Text="Measurement" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                        </div>
                        <div class="col-md-2 col-sm-2 col-lg-2">
                            <asp:DropDownList ID="ddlMeasurement" runat="server" CssClass="form-control form-select" Placeholder="Select Measurement" AutoPostBack="true" OnSelectedIndexChanged="ddlMeasurement_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Select Measurement" ControlToValidate="ddlMeasurement" ForeColor="Red" Font-Bold="false" ValidationGroup="Inventory1" InitialValue="0" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-1 col-sm-1 col-lg-1">
                            <asp:TextBox ID="txtAbbreviations" runat="server" name="phone" CssClass="form-control" ReadOnly="true" placeholder="Abbreviations" OnTextChanged="txtQuantity_TextChanged" AutoPostBack="true"></asp:TextBox>

                        </div>

                    </div>


                    <div class="row mb-3">
                        <div class="col-md-2">
                            <asp:Label ID="lblBrand" for="Brand" runat="server" Text="Brand" CssClass="form-label"></asp:Label><%--&nbsp;<span style="color: #FF0000">*</span>--%>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtBrand" runat="server" name="Brand" CssClass="form-control" placeholder="Enter Brand"></asp:TextBox>
                          
                        </div>
                        <div class="col-md-2"></div>
                        <div class="col-md-2">
                            <asp:Label ID="lblQuantity" for="Quantity" runat="server" Text="Quantity" Font-Bold="true" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtQuantity" runat="server" name="phone" CssClass="form-control" placeholder="Enter Quantity" OnTextChanged="txtQuantity_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <div class="validate">
                                <asp:RequiredFieldValidator ID="rvfEmail" runat="server" Display="Dynamic" ControlToValidate="txtQuantity" ErrorMessage="Enter Quantity" ForeColor="Red" ValidationGroup="Inventory1" Font-Size="12px"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                    </div>
                    <div class="row mb-3">
                        <div class="col-md-2">
                            <asp:Label ID="lblCategory" runat="server" Text="Storage Type" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlProjectCategory" runat="server" CssClass="form-control form-select" Placeholder="Select Storage Type" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Storage Type" ControlToValidate="ddlProjectCategory" ForeColor="Red" Font-Bold="false" ValidationGroup="Inventory1" InitialValue="-1" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>
                          </div>

                        <div class="col-md-2"></div>
                        <div class="col-md-2">
                            <asp:Label ID="lblRate" for="Rate" runat="server" Text="Rate" Font-Bold="true" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                        </div>

                        <div class="col-md-3">
                            <asp:TextBox ID="txtRate" runat="server" name="gstnumber" CssClass="form-control" placeholder="Enter Rate" MaxLength="15" ValidateRequestMode="Enabled" OnTextChanged="txtRate_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_GSTNumber" runat="server" Display="Dynamic" ControlToValidate="txtRate" ErrorMessage="Enter Rate" ForeColor="Red" ValidationGroup="Inventory1" Font-Size="12px"></asp:RequiredFieldValidator>
                        </div>

                    </div>
                    <div class="row mb-3">
                        <div class="col-md-2">
                            <asp:Label ID="lblDesp" for="Description" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtDesp" runat="server" name="Description" CssClass="form-control" placeholder="Enter Description" TextMode="MultiLine"></asp:TextBox>

                        </div>
                        <div class="col-md-2"></div>
                        <div class="col-md-2">
                            <asp:Label ID="lblTotalAmount" runat="server" Text="Total Amount" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtTotalAmount" CssClass="form-control" runat="server" Placeholder="Enter Total Amount" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row mb-3">


                        <div class="col-md-2">
                            <asp:Label ID="lblStatus" runat="server" Text="Status" Font-Bold="true" Font-Size="14px"></asp:Label>
                        </div>
                        <div class="col-md-3">
                            <div class="mb-2">
                                <asp:RadioButtonList ID="RadioButtonListVendor" runat="server" TabIndex="24" Font-Size="12px">
                                    <asp:ListItem Text="Active" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>
                    <%-- <br />--%>
                    <%-- <div class="col-md-6 col-sm-6 col-lg-6">
                       
                    </div>--%>

                    <div class="row">

                        <div class="form-group text-center">
                            <asp:Button ID="btn_UpdateInventoryProd" runat="server" Text="Update" CssClass="btn btn-sm btn-success" ValidationGroup="Inventory1" OnClick="btn_UpdateInventoryProd_Click" />
                            &nbsp;&nbsp;
                               <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" ValidationGroup="Clear" OnClick="btnCancel_Click" />

                        </div>

                    </div>

                </div>

            </div>

        </div>
    </div>
</asp:Content>
