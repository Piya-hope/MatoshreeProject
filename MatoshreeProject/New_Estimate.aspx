<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="New_Estimate.aspx.cs" Inherits="MatoshreeProject.New_Estimate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
          <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="font-weight-medium mb-0">New Estimate</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Estimates_Home.aspx">Estimate</a>
                        </li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="#">New Estimate</li>
                    </ol>
                </nav>
            </div>
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
                            <h5 class="text-purple">General Options</h5>
                            <asp:Label ID="lblAmont30" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="TAXCount" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="TAXCount2" runat="server" Text="" Visible="false"></asp:Label>
                            <hr />
                            <asp:UpdatePanel ID="UpdatePanelddlState" runat="server">
                                <ContentTemplate>
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="mb-2">
                                            <asp:Label ID="lblCustomers" runat="server" Text="Customer" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:DropDownList ID="ddlCustomers" runat="server" CssClass="form-control form-select" OnSelectedIndexChanged="ddlCustomers_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_Customer" runat="server" ControlToValidate="ddlCustomers" ErrorMessage="Select Customer" ForeColor="Red" Display="Dynamic" InitialValue="0" ValidationGroup="Invoice1" Font-Size="12px"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="mb-2">
                                            <asp:Label ID="lblProjects" runat="server" Text="Project" CssClass="form-label"></asp:Label>
                                            <asp:DropDownList ID="ddlProjects" runat="server" CssClass="form-control form-select">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="mb-2">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlProjects" ErrorMessage="Select Project" ForeColor="Red" Display="Dynamic" InitialValue="0" ValidationGroup="Invoice1" Font-Size="12px"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>


                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <asp:LinkButton ID="btnCopyAddresslink" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnCopyAddresslink_Click" ValidationGroup="copy"><i class="ti ti-edit"></i></asp:LinkButton>
                                        <hr />
                                        <div class="row">
                                            <div class="col-md-6 col-sm-6 col-lg-6">
                                                <h6>Bill To</h6>
                                                <asp:Label ID="lblBillTo" runat="server" Text="" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblbillTo1" runat="server" Text="--" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblbillTo2" runat="server" Text="--" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblbillTo3" runat="server" Text="--" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblbillTo4" runat="server" Text="--" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblbillTo5" runat="server" Text="--" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblbillTo7" runat="server" Text="--" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblbillTo6" runat="server" Text="--" CssClass="form-label"></asp:Label>

                                            </div>
                                            <div class="col-md-6 col-sm-6 col-lg-6">
                                                <h6>Ship To</h6>
                                                <asp:Label ID="lblShipTo" runat="server" Text="" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblShipTo1" runat="server" Text="--" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblShipTo2" runat="server" Text="--" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblShipTo3" runat="server" Text="--" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblShipTo4" runat="server" Text="--" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblShipTo5" runat="server" Text="--" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblShipTo7" runat="server" Text="--" CssClass="form-label"></asp:Label>
                                                <asp:Label ID="lblShipTo6" runat="server" Text="--" CssClass="form-label"></asp:Label>
                                            </div>
                                        </div>
                                        <hr />
                                    </div>

                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlCustomers" EventName="SelectedIndexChanged" />

                                </Triggers>
                            </asp:UpdatePanel>
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <div class="mb-2">
                                    <asp:Label runat="server" Text="Estimate Number" Font-Bold="true" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:Label ID="lblInitialNumber" runat="server" Text="-" Font-Bold="true" CssClass="form-control text-purple" ReadOnly="true"></asp:Label>
                                    <asp:TextBox ID="txtEstimateNumber" runat="server" CssClass="form-control text-purple" ReadOnly="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_EstimateNumber" ControlToValidate="txtEstimateNumber" Display="Dynamic" runat="server" ErrorMessage="Please Enter Estimate Number" ForeColor="Red" ValidationGroup="Invoice1" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <div class="mb-2">
                                    <asp:Label runat="server" Text="Reference #" Font-Bold="true" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtReference" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <div class="row">
                                    <div class="col-md-6 col-sm-6 col-lg-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblEstimateDate" runat="server" Text="Estimate Date" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:TextBox ID="txtEstimateDate" type="date" CssClass="form-control" Style="display: inline-block;" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_EstimateDate" ControlToValidate="txtEstimateDate" Display="Dynamic" runat="server" ErrorMessage="Please Select Estimate Date" ForeColor="Red" ValidationGroup="Invoice1" Font-Size="12px"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-lg-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblExpiryDate" runat="server" Text="Expiry Date" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txtExpiryDate" type="date" CssClass="form-control" Style="display: inline-block;" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-6 col-lg-6">
                            <h5 class="text-purple">Advanced Options</h5>
                            <hr />
                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-lg-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblStatus" runat="server" Text="Status" CssClass="form-label"></asp:Label>
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control form-select">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-lg-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblCurrency" runat="server" Text="Currency" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <asp:DropDownList ID="ddlCurrency" runat="server" CssClass="form-control form-select">
                                            <asp:ListItem Value="0" Text="Nothing Selected" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="INR"></asp:ListItem>

                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfv_Currency" runat="server" ControlToValidate="ddlCurrency" ErrorMessage="Please Select Currency..." ForeColor="Red" InitialValue="0" Display="Dynamic" ValidationGroup="Invoice1" Font-Size="12px"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-lg-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblSalesAgent" runat="server" Text="Sales Agent" CssClass="form-label"></asp:Label>
                                        <asp:DropDownList ID="ddlSalesAgent" runat="server" CssClass="form-control form-select">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-lg-6">
                                  
                                </div>
                                <div class="col-md-12 col-sm-12 col-lg-12">
                                    <div class="mb-2">
                                        <asp:Label ID="lblAdminNote" runat="server" Text="Admin Note" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="txtAdminNote" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                    </div>
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
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-4 col-xs-4 col-sm-4 col-lg-4">
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
                                <div class="col-md-5 col-xs-5 col-sm-5 col-lg-5">
                                </div>

                                <div class="col-md-3 col-xs-3 col-sm-3 col-lg-3">
                                    <div class="input-group">
                                        <asp:Label ID="Label12" runat="server" Text="Show Qty As: " CssClass="form-label"></asp:Label>
                                        <asp:RadioButtonList ID="RadioButtonListQty" runat="server" RepeatDirection="Horizontal" class="round" CssClass="ms-2" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonListQty_SelectedIndexChanged">
                                            <asp:ListItem Text="Qty" Value="1" Selected="True"></asp:ListItem>
                                            <%--   <asp:ListItem Text="Hours" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Qty/hours" Value="3"></asp:ListItem>--%>
                                        </asp:RadioButtonList>

                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-lg-12">
                                    <div class="alert alert-warning" role="alert" id="msgdiv" runat="server" visible="false">
                                        <asp:Label ID="lblMsg1" runat="server" Text="" Visible="false" Font-Bold="false" Font-Size="12px" ForeColor="Red" ValidateRequestMode="Disabled"></asp:Label>
                                    </div>
                                    <div class="alert alert-info" role="alert" id="SuccessDiv1" runat="server" visible="false">
                                        <asp:Label ID="lblMsg" runat="server" Text="" Visible="false" Font-Bold="false" Font-Size="12px" ForeColor="Blue" ValidateRequestMode="Disabled"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <!-- Table -->

                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-lg-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="GridCalculate" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4"
                                            ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" FooterStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="true" OnRowDataBound="GridCalculate_RowDataBound">
                                            <Columns>
                                                <%-- <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px" HeaderStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server"  Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderStyle-Width="130px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblItem" runat="server" Text="Item" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                          <asp:Label ID="lblItemID1" runat="server" Text='<%# Bind("ItemID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                         
                                                        <asp:Label ID="lblItem1" runat="server" Text='<%# Bind("EstimateItem") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtItem" runat="server" TextMode="MultiLine" Text="" CssClass="form-control" Placeholder="Description" Width="130px" Font-Size="12px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_InvoiceItem" ControlToValidate="txtItem" Display="Dynamic" runat="server" ErrorMessage="Select Item" ForeColor="Red" ValidationGroup="ItemInvoice" Font-Size="12px"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="180px" ItemStyle-Width="200px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescription1" runat="server" Text='<%# Bind("Description") %>' Font-Bold="false" Font-Size="12px" Width="180px"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Text="" CssClass="form-control" Placeholder="Long Description" Font-Size="12px"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHSNname" runat="server" Text="HSN" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblHSN1" runat="server" Text='<%# Bind("HSN") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblHSN" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                     </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="60px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblQuantity" runat="server" Text="Qnty" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtQty1" runat="server" Text='<%# Bind("Qnty") %>' CssClass="form-control" Placeholder="Quantity" TextMode="Number" Style="width: 60px" Visible="false" AutoPostBack="true" OnTextChanged="txtQty1_TextChanged" Font-Size="12px"></asp:TextBox>
                                                        <asp:Label ID="lblQuantity1" runat="server" Text='<%# Bind("Qnty") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtQty" runat="server" Text="1" CssClass="form-control" Placeholder="Quantity" TextMode="Number" Style="width: 60px" AutoPostBack="true" OnTextChanged="txtQty_TextChanged" Font-Size="12px"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="60px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblRate" runat="server" Text="Rate" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtRate1" runat="server" Text='<%# Bind("Rate") %>' CssClass="form-control" Placeholder="Rate" TextMode="Number" Style="width: 80px" Visible="false" AutoPostBack="true" OnTextChanged="txtRate1_TextChanged" Font-Size="12px"></asp:TextBox>
                                                        <asp:Label ID="lblRate1" runat="server" Text='<%# Bind("Rate") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtRate" runat="server" Text="" CssClass="form-control" Placeholder="Rate" AutoPostBack="true" OnTextChanged="txtRate_TextChanged" Font-Size="12px" Width="80px"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblSubAmont" runat="server" Text="Amount" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSubAmont1" runat="server" Text='<%# Bind("SubTotal") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblSubAmont1F" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="120px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblTax" runat="server" Text="GST1" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTaxValees" runat="server" Text='<%# Bind("Tax1Rate") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblTax1" runat="server" Text='<%# Bind("Tax1Name") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                        <asp:DropDownList ID="ddlTaxCost" runat="server" CssClass="form-control" DataTextField="" AutoPostBack="true" OnSelectedIndexChanged="ddlTaxCost_SelectedIndexChanged" Visible="false" Font-Size="12px" Style="width: 120px">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblTaxValeesF" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblTax1F" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                                        <asp:DropDownList ID="ddlTax" runat="server" CssClass="form-control" AutoPostBack="true" Style="width: 120px" OnSelectedIndexChanged="ddlTax_SelectedIndexChanged" Font-Size="12px">
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="GSTAmt" SortExpression="Tax1Amount" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="true">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblTax1Rate" runat="server" Text='<%# Bind("Tax1Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTax1Rate1" runat="server" Text='<%# Bind("Tax1Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtTax1Rate1F" runat="server" Text="" CssClass="form-control" Placeholder="Rate" ReadOnly="true" Font-Size="12px"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="120px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblTax1A" runat="server" Text="GST2" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTaxValees1A" runat="server" Text='<%# Bind("Tax2Rate") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblTax1A" runat="server" Text='<%# Bind("Tax2Name") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                        <asp:DropDownList ID="ddlTaxCost1A" runat="server" CssClass="form-control" DataTextField="" AutoPostBack="true" OnSelectedIndexChanged="ddlTaxCost1A_SelectedIndexChanged" Visible="false" Font-Size="12px" Style="width: 120px">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblTaxValees1AF" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblTax1AF" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                                        <asp:DropDownList ID="ddlTax1A" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTax1A_SelectedIndexChanged" Style="width: 120px" Font-Size="12px">
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="GST2Amt" SortExpression="Tax2Amount" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Bold="true">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblTax2Rate" runat="server" Text='<%# Bind("Tax2Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTax2Rate1" runat="server" Text='<%# Bind("Tax2Amount") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtTax2Rate1F" runat="server" Text="" CssClass="form-control" Placeholder="Rate" ReadOnly="true" Font-Size="12px"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblAmontname" runat="server" Text="Total" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAmont1" runat="server" Text='<%# Bind("TotalAmont") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblGrandAmontF" runat="server" Text="" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="btnOption" runat="server" Text="" CausesValidation="false" ValidationGroup="setting"><i class="ti ti-settings"></i></asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDeleteItemCal" runat="server" CommandName="Delete" CausesValidation="false" CssClass="btn btn-sm btn-rounded btn-danger" ValidationGroup="DelItemInvoice" Text="" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteItemCal_Click" Visible="false"><i class="ti ti-trash"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:LinkButton ID="btnAddInvoiceItem" runat="server" CssClass="btn btn-sm btn-rounded btn-info" Text="" CausesValidation="false" OnClick="btnAddInvoiceItem_Click" TabIndex="9" ValidationGroup="ItemInvoice"><i class="ti ti-check"></i></asp:LinkButton>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlItem" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <br />
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-lg-12">
                            <div class="container-fluid">
                                <div class="container-fluid ">
                                    <%-- subcost--%>
                                    <div class="row">
                                        <asp:Table ID="Table2" runat="server" CssClass="col-md-12 col-sm-12 col-lg-12">
                                            <asp:TableRow ID="TableRow3" runat="server" class="mb-2">
                                                <asp:TableCell CssClass="col-md-7 col-sm-7 col-lg-7">
                                                </asp:TableCell>
                                                <asp:TableCell CssClass="col-md-2 col-sm-2 col-lg-2">
                                                    <asp:Label ID="lblSubTotal" CssClass="form-label me-2 ms-2" runat="server" Text="Sub Total :"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell CssClass="col-md-3 col-sm-3 col-lg-3">
                                                    <asp:Label ID="lblSubTotalCost" runat="server" Text="₹ 0.00" CssClass="form-control ms-2" Font-Size="12px" Font-Bold="false"></asp:Label>
                                                </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </div>
                                </div>

                                <div class="container-fluid">
                                    <%-- Discount--%>
                                    <div class="row">
                                        <asp:Table ID="Table3" runat="server" CssClass="col-md-12 col-sm-12 col-lg-12">
                                            <asp:TableRow ID="TableRow4" runat="server" class="mb-2">
                                                <asp:TableCell CssClass="col-md-3 col-sm-3 col-lg-3">
                                                </asp:TableCell>
                                                <asp:TableCell CssClass="col-md-2 col-sm-2 col-lg-2">
                                                    <asp:Label ID="Label13" runat="server" Text="Discount :" CssClass="form-label me-2 ms-2"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell CssClass="col-md-2 col-sm-2 col-lg-2">

                                                    <asp:TextBox ID="txtDiscount1" Text="- 0.00" runat="server" TextMode="Number" CssClass="form-control" placeholder="0.00" BorderColor="Blue" AutoPostBack="true" OnTextChanged="txtDiscount1_TextChanged" ValidationGroup="di"></asp:TextBox>
                                                </asp:TableCell>
                                                <asp:TableCell CssClass="col-md-2 col-sm-2 col-lg-2">
                                                    <asp:DropDownList ID="ddlDiscountCost" runat="server" CssClass="form-control" Style="border-color: Blue" AutoPostBack="true" OnSelectedIndexChanged="ddlDiscountCost_SelectedIndexChanged" ValidationGroup="di2">
                                                        <asp:ListItem Text="%" Value="%" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Fixed Amount" Value="Fixed Amount"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </asp:TableCell>
                                                <asp:TableCell CssClass="col-md-3 col-sm-3 col-lg-3">

                                                    <%--Labels--%>
                                                    <asp:Label ID="lblDiscountCost" runat="server" Text="₹ 0.00" CssClass="form-control ms-2" Font-Bold="false"></asp:Label>
                                                </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </div>
                                </div>

                                <div class="container-fluid">
                                    <%-- Tax list--%>
                                    <div class="row">
                                        <asp:Table ID="Table1" runat="server" CssClass="col-md-12 col-sm-12 col-lg-12">
                                            <asp:TableRow ID="TableRow1" runat="server" class="mb-2">
                                                <asp:TableCell CssClass="col-md-4 col-sm-4 col-lg-4">
                                                </asp:TableCell>
                                                <asp:TableCell CssClass="col-md-2 col-sm-2 col-lg-2">
                                                    <asp:Label ID="lblCostTaax" runat="server" Text="Tax :" CssClass="form-label" Visible="false"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell CssClass="col-md-3 col-sm-3 col-lg-3">
                                                    <asp:Label ID="lbltotaltaxPer" runat="server" Text="" Visible="false"></asp:Label>

                                                    <asp:Label ID="lbltotalcosttax" runat="server" Text="" Visible="false"></asp:Label>
                                                    <%--Bullet List--%>
                                                    <asp:BulletedList ID="listTaxNames1" runat="server" Font-Size="12px" Font-Bold="false" BulletStyle="NotSet" CssClass="form-label"></asp:BulletedList>
                                                </asp:TableCell>
                                                <asp:TableCell CssClass="col-md-3 col-sm-3 col-lg-3">
                                                    <%--fas fa-rupee-sign--%>
                                                    <asp:BulletedList ID="listTaxValues1" runat="server" Font-Size="12px" Font-Bold="false" BulletStyle="CustomImage" BulletImageUrl="Image/indiCurrency10.png" Style="margin-left: 90px;"></asp:BulletedList>
                                                </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </div>
                                </div>

                                <div class="container-fluid">
                                    <%-- Adjustment--%>
                                    <div class="row">
                                        <asp:Table ID="Table4" runat="server" CssClass="col-md-12 col-sm-12 col-lg-12">
                                            <asp:TableRow ID="TableRow5" runat="server" class="mb-2">
                                                <asp:TableCell CssClass="col-md-4 col-sm-4 col-lg-4"> 
                                                </asp:TableCell>
                                                <asp:TableCell CssClass="col-md-2 col-sm-2 col-lg-2">
                                                    <asp:Label ID="lblAdjustment" runat="server" Text="Adjustment:" CssClass="form-label ms-2"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell CssClass="col-md-3 col-sm-3 col-lg-3">
                                                    <asp:TextBox ID="TxtAdjustment1" Text="" runat="server" TextMode="Number" CssClass="form-control ms-2" placeholder="₹0.00" BorderColor="Blue" AutoPostBack="true" OnTextChanged="TxtAdjustment1_TextChanged" ValidationGroup="ad"></asp:TextBox>
                                                </asp:TableCell>
                                                <asp:TableCell CssClass="col-md-3 col-sm-3 col-lg-3">
                                                    <%--Labels--%>
                                                    <asp:Label ID="lblAdjustmentCost" runat="server" Text="₹0.00" CssClass="form-control ms-2" Font-Size="12px" Font-Bold="false"></asp:Label>
                                                </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </div>
                                </div>
                                <div class="container-fluid">
                                    <%-- Total--%>
                                    <div class="row">
                                        <asp:Table ID="Table5" runat="server" CssClass="col-md-12 col-sm-12 col-lg-12">
                                            <asp:TableRow ID="TableRow6" runat="server" class="mb-2">
                                                <asp:TableCell CssClass="col-md-7 col-sm-7 col-lg-7"></asp:TableCell>
                                                <asp:TableCell CssClass="col-md-2 col-sm-2 col-lg-2">
                                                    <asp:Label ID="lbltotal" CssClass="form-label ms-2" runat="server" Text="Total:"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell CssClass="col-md-3 col-sm-3 col-lg-3">
                                                    <%--Labels--%>
                                                    <asp:Label ID="lbltotalAmonutInvoiceCost" runat="server" Text="₹0.00" CssClass="form-control" Font-Size="12px" Font-Bold="false"></asp:Label>
                                                </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </div>
                                </div>
                                <br />
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="card">
                <div class="card-body">
                    <div class="col-md-12 col-sm-12 col-lg-12">
                        <div class="mb-2">
                            <asp:Label ID="lblClientNote" runat="server" Text="Client Note" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtClientNote" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-12 col-sm-12 col-lg-12">
                        <div class="mb-2">
                            <asp:Label ID="lblTermsConditions" runat="server" Text="Terms & Conditions" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtTermsAndConditions" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-12 col-sm-12 col-lg-12">

                        <div class="mb-2">
                            <asp:Button ID="btn_SubmitEstimate" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="Invoice1" OnClick="btn_SubmitEstimate_Click1" />
                            &nbsp;&nbsp;
                             <asp:Button ID="btnSaveAsDraft" runat="server" Text="Save As Draft" CssClass="btn btn-sm btn-dark" ValidationGroup="Draft" OnClick="btnSaveAsDraft_Click1" />
                            &nbsp;&nbsp;
                               <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="Clear" OnClick="btnClear_Click" />
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
