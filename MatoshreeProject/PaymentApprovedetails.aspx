<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="PaymentApprovedetails.aspx.cs" Inherits="MatoshreeProject.PaymentApprovedetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="font-weight-medium  mb-0">Payment Approval Details</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item text-muted" href="#">Expenses</li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="PaymentApprovedetails.aspx">Payment Approve Details</li>
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
            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <div>
                            <h5 class="text-purple">Payment Approval Details</h5>
                        </div>
                        <hr />
                        <div class="row">
                            <asp:Label ID="payApprovalID" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                            <asp:Label ID="lblRefID" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                            <div class="col-md-3 col-sm-3 col-lg-3">
                                <div class="mb-2">
                                    <asp:Label ID="lblRefPRimary" runat="server" Text="" Font-Bold="true" Visible="false" Font-Size="12px"></asp:Label>
                                    <asp:Label ID="lblstaffid" runat="server" Text="" Font-Bold="true" Visible="false" Font-Size="12px"></asp:Label>
                                    <asp:Label ID="lblName" runat="server" Text="ExpName:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblExpName" runat="server" Text="" Font-Size="12px"></asp:Label>
                                    <asp:Label ID="lblTotalApprovalAmount" runat="server" Text="" Visible="false" Font-Size="12px"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3 col-lg-3">
                                <div class="mb-2">

                                    <asp:Label ID="lblRelatedTo" runat="server" Text="RelatedTo:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblRelatedTo1" runat="server" Text="" Font-Size="12px"></asp:Label>

                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3 col-lg-3">
                                <div class="mb-2">
                                    <asp:Label ID="lblBillno" runat="server" Text="Bill Number:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblBillno1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3 col-lg-3">
                                <div class="mb-2">

                                    <asp:Label ID="lblPayementMode" runat="server" Text="Note:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblPayementMode1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-3 col-sm-3 col-lg-3">
                                <div class="mb-2">
                                    <asp:Label ID="lblExp_Type" runat="server" Text="Exp_Type:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblExp_Type1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3 col-lg-3">
                                <div class="mb-2">

                                    <asp:Label ID="lblExpDate" runat="server" Text="Date:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblExpDate1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3 col-lg-3">
                                <div class="mb-2">
                                    <asp:Label ID="lblAmount11" runat="server" Text="Amount:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblAmount111" runat="server" Text="" Font-Size="12px"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3 col-lg-3">
                                <div class="mb-2">

                                    <asp:Label ID="lblCurrency" runat="server" Text="Currency:" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblCurrency1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">

                            <div class="col-md-3 col-sm-3 col-lg-3">
                                <div class="mb-2">
                                    <asp:Label ID="lblCategory" runat="server" Text="Category:" CssClass="form-label" Visible="false"></asp:Label>
                                    <asp:Label ID="lblCategory1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                    <asp:Label ID="lblCategoryid" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3 col-lg-3">
                                <div class="mb-2">

                                    <asp:Label ID="lblSub_Category" runat="server" Text="Sub_Category:" CssClass="form-label" Visible="false"></asp:Label>
                                    <asp:Label ID="lblSub_Category1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                    <asp:Label ID="lblSub_Category1id" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3 col-sm-3 col-lg-3">
                                <div class="mb-2">
                                    <asp:Label ID="lblCustomer" runat="server" Text="Customer:" CssClass="form-label" Visible="false"></asp:Label>
                                    <asp:Label ID="lblCustomer1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3 col-lg-3">
                                <div class="mb-2">

                                    <asp:Label ID="lblProject" runat="server" Text="Project:" CssClass="form-label" Visible="false"></asp:Label>
                                    <asp:Label ID="lblProject1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>

                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-3 col-sm-3 col-lg-3">
                                <div class="mb-2">
                                    <asp:Label ID="lblStaff" runat="server" Text="StaffName:" CssClass="form-label" Visible="false"></asp:Label>
                                    <asp:Label ID="lblStaff1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <br />
                    </div>
                </div>
            </div>

        </div>

        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <div>
                            <h5 class="text-purple">Expenses Item Details</h5>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <div class="alert alert-warning" role="alert" id="msgdiv" runat="server" visible="false">
                                    <asp:Label ID="lblMsg1" runat="server" Text="" Visible="false" Font-Bold="false" Font-Size="12px" ForeColor="Red" ValidateRequestMode="Disabled"></asp:Label>
                                    <asp:Label ID="lblprojectId" runat="server" Text="" Visible="false" Font-Size="12px"></asp:Label>
                                </div>
                                <div class="alert alert-info" role="alert" id="SuccessDiv1" runat="server" visible="false">
                                    <asp:Label ID="lblMsg" runat="server" Text="" Visible="false" Font-Bold="false" Font-Size="12px" ForeColor="Blue" ValidateRequestMode="Disabled"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <asp:Label ID="lblMsId" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblBillNoretrive" runat="server" Text="" Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                        <asp:Label ID="lblExpNameWGV" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblexpid2" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                        <asp:Label ID="lblRemmainingAmount12" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="col-md-4 col-xs-4 col-sm-4 col-lg-4">
                                                <div class="input-group">
                                                    <asp:Label ID="Label2" runat="server"></asp:Label>
                                                    <asp:DropDownList ID="ddlItem" runat="server" CssClass="form-select form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged">
                                                    </asp:DropDownList>

                                                    <!-- Button trigger modal -->
                                                    <button type="button" class="btn btn-info btn-sm font-medium" data-bs-toggle="modal"
                                                        data-bs-target="#ItemID">
                                                        +
                                                    </button>
                                                </div>
                                            </div>
                                            <div class="col-md-4 col-xs-4 col-sm-4 col-lg-4"></div>
                                            <div class="col-md-4 col-xs-4 col-sm-4 col-lg-4"></div>
                                        </div>
                                    </div>
                                    <br />  <br />
                                    <div class="row">
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridViewOffice" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4"
                                                ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" FooterStyle-ForeColor="Blue" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="true">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="chkAll_CheckedChanged" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkItem" runat="server" Checked="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ID" ItemStyle-Width="100">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblID" runat="server" Text="ID" CssClass="form-label"></asp:Label>
                                                        </HeaderTemplate>

                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblItem" runat="server" Text="Item" CssClass="form-label"></asp:Label>

                                                        </HeaderTemplate>

                                                        <FooterTemplate>

                                                            <asp:TextBox ID="txtItem" runat="server" TextMode="MultiLine" Text="" CssClass="form-control" Placeholder="Description"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfv_TenderItem" ControlToValidate="txtItem" Display="Dynamic" runat="server" ErrorMessage="Please Select Item" ForeColor="Red" ValidationGroup="ItemTender"></asp:RequiredFieldValidator>
                                                        </FooterTemplate>
                                                        <ItemTemplate>

                                                            <asp:Label ID="lblItem1" runat="server" Text='<%# Bind("Item") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            <asp:Label ID="lblItemID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                                            <asp:Label ID="lblcreateby1" runat="server" Text='<%# Bind("CreatedBy") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                                            <asp:Label ID="lblsendDesignation" runat="server" Text='<%# Bind("Designation") %>' Font-Size="12px" Visible="false"></asp:Label>
                                                            <asp:Label ID="lblRemmainingamt" runat="server" Text="" Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                        </HeaderTemplate>

                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Text="" CssClass="form-control" Placeholder="Long Description"></asp:TextBox>
                                                        </FooterTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDescription1" runat="server" Text='<%# Bind("Description") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            <asp:Label ID="lblEmpId" runat="server" Text='<%# Bind("EmpID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblRate" runat="server" Text="Rate" CssClass="form-label"></asp:Label>
                                                        </HeaderTemplate>

                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtRate" runat="server" Text="" Font-Size="12px" CssClass="form-control" Placeholder="Rate"></asp:TextBox>
                                                        </FooterTemplate>

                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtRate1" runat="server" Text='<%# Bind("Rate") %>' Font-Size="12px" CssClass="form-control" Placeholder="Rate" TextMode="Number" Style="width: 150px" Visible="false" ValidationGroup="R"></asp:TextBox>

                                                            <asp:Label ID="lblRate1" runat="server" Text='<%# Bind("Rate") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>



                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblQuantity" runat="server" Text="Qty" CssClass="form-label"></asp:Label>
                                                        </HeaderTemplate>

                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtQty" runat="server" Text="1" CssClass="form-control" Font-Size="12px" Placeholder="Quantity" TextMode="Number" Style="width: 60px"></asp:TextBox>
                                                        </FooterTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQty1" runat="server" Text='<%# Bind("Quantity") %>' CssClass="form-control" Placeholder="Quantity" TextMode="Number" Style="width: 60px" Visible="false" ValidationGroup="Q"></asp:TextBox>
                                                            <asp:Label ID="lblQuantity1" runat="server" Text='<%# Bind("Quantity") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblAmount1" runat="server" Text="Amount" CssClass="form-label"></asp:Label>
                                                        </HeaderTemplate>

                                                        <FooterTemplate>
                                                            <asp:Label ID="lblHSN" runat="server" Text="" Visible="false" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            <asp:Label ID="lblTotalAmount" runat="server" Text="Amount" CssClass="form-label"></asp:Label>
                                                        </FooterTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("Amount") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                            <asp:TextBox ID="txtExpAmount" runat="server" Text='<%# Bind("Amount") %>' Font-Size="12px" class="form-control"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="btnOption" runat="server" Text="" ValidationGroup="setting"><i class="ti ti-cog"></i></asp:LinkButton>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnDeleteItemCal" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-rounded btn-danger" ValidationGroup="DelItemTender" Text="" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteItemCal_Click" Visible="false"><i class="ti ti-trash"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <FooterTemplate>

                                                            <asp:LinkButton ID="btnAddPaymentApprovalItem" runat="server" CssClass="btn btn-sm btn-rounded btn-info" Text="" TabIndex="9" OnClick="btnAddPaymentApprovalItem_Click" ValidationGroup="ItemTender"><i class="ti ti-check"></i></asp:LinkButton>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblReason" runat="server" Text="Reason" CssClass="form-label"></asp:Label>
                                                        </HeaderTemplate>

                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtReason" CssClass="form-control same-width" Text="" runat="server" Placeholder="Reason" TextMode="MultiLine"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblAccept" runat="server" Text="Accept" CssClass="form-label"></asp:Label>
                                                        </HeaderTemplate>


                                                        <ItemTemplate>
                                                            <asp:Button ID="btnAccept" runat="server" Text="Accept" CssClass="btn btn-success btn-sm form-control " Width="70px" OnClick="btnAccept_Click" ValidationGroup="Accept" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblDecline" runat="server" Text="Decline" CssClass="form-label"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnDecline" runat="server" Text="Decline" CssClass="btn btn-danger btn-sm form-control " OnClick="btnDecline_Click1" Width="70px" ValidationGroup="ExpenseD" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                        </div>
                                       <br />

                                       <div class="row">
                        <div class="col-md-12 col-sm-12 col-lg-12">
                            <div class="container-fluid ">
                                <div class="row">
                                    <asp:Table ID="Table2" runat="server" CssClass="col-md-12 col-sm-12 col-lg-12  font-bold">
                                        <asp:TableRow ID="TableRow3" runat="server" class="">
                                            <asp:TableCell CssClass="col-md-6 col-sm-6 col-lg-6">
                                            </asp:TableCell>
                                            <asp:TableCell CssClass="col-md-3 col-sm-3 col-lg-3">
                                                <asp:Label ID="lblSubTotal" CssClass="form-label" runat="server" Text="Total Amount :"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell CssClass="col-md-3 col-sm-3 col-lg-3">
                                                <asp:Label ID="lblSubTotalCost" runat="server" Text="₹ 0" CssClass="form-control" Font-Size="12px" Font-Bold="false"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </div>
                            </div>
                        </div>
                    </div>
                                    <br />
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlItem" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                        
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-lg-12">
                            <center>
                                <asp:Button ID="btnAcceptALL" runat="server" Text="AcceptALL" CssClass="btn btn-success btn-sm" Visible="false" OnClick="btnAcceptALL_Click" Width="90px" ValidationGroup="Accept" />
                                &nbsp;
                                <asp:Button ID="btnDeclineALL" runat="server" Text="DeclineALL" CssClass="btn btn-danger btn-sm " Visible="false" OnClick="btnDeclineALL_Click" Width="90px" ValidationGroup="ExpenseD" />
                            </center>
                        </div>
                    </div>
                    
                          </div>

                </div>
            </div>
            </div>



            <div class="row">
                <div class="col-md-12 col-sm-12 col-lg-12">
                    <div class="card">
                        <div class="card-body">
                            <div>
                                <h5>Approval Item Details</h5>
                            </div>
                            <hr />
                            <div class="row">

                                <div class="col-md-12 col-sm-12 col-lg-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="GridApprovalItem" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                            ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" FooterStyle-ForeColor="Blue" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true">
                                            <Columns>
                                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text="ID" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>

                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRowNumber" Font-Size="12px" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblItem" runat="server" Text="Item" CssClass="form-label"></asp:Label>

                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblItem1" runat="server" Text='<%# Bind("Item") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        <asp:Label ID="lblItemID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblDescription1" runat="server" Text="Description" CssClass="form-label"></asp:Label>

                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescriptions" runat="server" Text='<%# Bind("Description") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblRate" runat="server" Text="Rate" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>



                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtRates" runat="server" Text='<%# Bind("Rate") %>' Font-Size="12px" CssClass="form-control" Placeholder="Rate" TextMode="Number" Style="width: 150px" Visible="false" ValidationGroup="R"></asp:TextBox>

                                                        <asp:Label ID="lblRates" runat="server" Text='<%# Bind("Rate") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>



                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblQuantity" runat="server" Text="Qty" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>

                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtQtys" runat="server" Text='<%# Bind("Quantity") %>' Font-Size="12px" CssClass="form-control" Placeholder="Quantity" TextMode="Number" Style="width: 60px" Visible="false" ValidationGroup="Q"></asp:TextBox>
                                                        <asp:Label ID="lblQuantitys" runat="server" Text='<%# Bind("Quantity") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblAmount1" runat="server" Text="Amount" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>

                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAmounts" runat="server" Text='<%# Bind("ApprovalAmount") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblReason" runat="server" Text="Reason" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>

                                                    <ItemTemplate>

                                                        <asp:Label ID="lblReason" runat="server" Text='<%# Bind("Reason") %>' Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblcondition" runat="server" Text="Approval" CssClass="form-label"></asp:Label>
                                                    </HeaderTemplate>


                                                    <ItemTemplate>

                                                        <asp:Label ID="lblcondition" runat="server" Text='<%# Bind("ApprovalSatus") %>' Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>

                                    </div>
                                </div>
                            </div>

                            <br />
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-lg-12">
                                    <div class="container-fluid ">
                                        <div class="row">
                                            <asp:Table ID="Table1" runat="server" CssClass="col-md-12 col-sm-12 col-lg-12  font-bold">
                                                <asp:TableRow ID="TableRow1" runat="server" class="">
                                                    <asp:TableCell CssClass="col-md-6 col-sm-6 col-lg-6">
                                                    </asp:TableCell>
                                                    <asp:TableCell CssClass="col-md-3 col-sm-3 col-lg-3">
                                                        <asp:Label ID="lblSubTotal1" CssClass="form-label" runat="server" Text="Total Approval Amount :"></asp:Label>
                                                    </asp:TableCell>
                                                    <asp:TableCell CssClass="col-md-3 col-sm-3 col-lg-3">
                                                        <asp:Label ID="lblSubTotalCost1" runat="server" Text="0" CssClass="form-control" Font-Size="12px" Font-Bold="false"></asp:Label>
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                            </asp:Table>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>


                <div class="col-md-12 col-sm-12 col-lg-12">


                    <div class="card">

                        <div class="card-body">
                            <div>
                                <h5 class="text-purple">Approval File Details</h5>

                            </div>
                            <hr />

                            <%-- ------------------------------------------- File Uploadd----------------------------------- --%>


                            <div class="row">
                                <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                    <div class="input-group">

                                        <asp:FileUpload ID="FileUpload" runat="server" Text="" CssClass="form-control" />

                                        <asp:Button ID="Btn_Upload" runat="server" Text="Upload" CssClass="btn btn-sm btn-primary" OnClick="Btn_Upload_Click" />
                                    </div>
                                </div>

                            </div>
                            <br />
                            <br />
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-lg-12">

                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-lg-12">

                                            <asp:GridView ID="GridExpensesFile" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                ClientIDMode="Static" ShowHeader="false" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                                                <Columns>
                                                    <asp:TemplateField Visible="false">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblExpensesFileId" runat="server" Text="FileName" Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblExpensesFileId1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                            <asp:Label ID="lblcreateby" runat="server" Text='<%# Bind("CreatedBy") %>' Visible="false" CssClass="form-label"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblExpensesFileName" runat="server" Text="FileName" CssClass="form-label"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblExpensesrFileName1" runat="server" Text='<%# Bind("FileName") %>' Font-Bold="false" Font-Size="12px"></asp:Label>

                                                            <asp:Label ID="lblFilePath" runat="server" Text='<%# Bind("FilePath") %>' Font-Bold="false" Visible="false" Font-Size="12px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnDeleteExpensesFile" runat="server" ForeColor="Red" Visible="false" CssClass="btn btn-sm btn-rounded" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteExpensesFile_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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

                            <%-- ------------------------------------------- File Uploadd----------------------------------- --%>
                        </div>
                    </div>
                </div>
            </div>

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

                            <h5 class="card-title" style="color: blue">Add Item</h5>
                            <hr />
                            <div class="mb-2">
                                <asp:Label ID="lbl_Description" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txt_Description" runat="server" Font-Size="12px" CssClass="form-control" placeholder="Enter Description"></asp:TextBox>
                            </div>
                            <br />
                            <div class="mb-2">
                                <asp:Label ID="lbl_Rate" runat="server" Text="Rate" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                <asp:TextBox ID="txt_Rate" runat="server" CssClass="form-control" Font-Size="12px" placeholder="Enter Rate"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Rate" runat="server" ErrorMessage="Enter Rate" Display="Dynamic" ControlToValidate="txt_Rate" ForeColor="Red" ValidationGroup="SaveITEM" Font-Size="12px"></asp:RequiredFieldValidator>
                            </div>
                            <br />
                            <div class="mb-2">
                                <asp:Label ID="lblHSNCode" runat="server" Text="HSNCode" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                <asp:TextBox ID="txtHSNCode" runat="server" CssClass="form-control" Font-Size="12px" placeholder="Enter HSNCode"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtHSNCode" ErrorMessage="Enter HSNCode" ForeColor="Red" ValidationGroup="SaveITEM" Font-Size="12px"></asp:RequiredFieldValidator>
                            </div>
                            <br />
                            <div class="mb-2">
                                <asp:Label ID="lbl_LongDescription" runat="server" Text="Long Description" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txt_LongDescription" TextMode="MultiLine" runat="server" Font-Size="12px" CssClass="form-control" placeholder="Enter Long Description"></asp:TextBox>
                            </div>
                            <br />
                            <div class="mb-2">
                                <asp:Label ID="lbl_Tax" runat="server" Text="Tax1" Font-Bold="true"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                <asp:DropDownList ID="ddlTaxitem" runat="server" CssClass="form-control" Font-Size="12px" AutoPostBack="true" OnSelectedIndexChanged="ddlTaxitem_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:Label ID="lblTaxValues1" runat="server" Font-Bold="true" Text="" Font-Size="12px" Visible="false"></asp:Label>


                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlTaxitem" ErrorMessage="Select TAX1" InitialValue="0" ForeColor="Red" ValidationGroup="SaveITEM" Font-Size="12px"></asp:RequiredFieldValidator>

                            </div>
                            <br />
                            <div class="mb-2">
                                <asp:Label ID="lbl_Tax2" runat="server" Text="Tax2" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                <asp:DropDownList ID="ddlTaxItem1" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTaxItem1_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:Label ID="lblTaxValues2" runat="server" Font-Bold="true" Text="" Font-Size="12px" Visible="false"></asp:Label>

                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="ddlTaxItem1" ErrorMessage="Select TAX2" InitialValue="0" ForeColor="Red" ValidationGroup="SaveITEM" Font-Size="12px"></asp:RequiredFieldValidator>

                            </div>

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

</asp:Content>
