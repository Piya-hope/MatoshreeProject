<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="New_Staff_Expenses.aspx.cs" Inherits="MatoshreeProject.New_Staff_Expenses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="font-weight-medium  mb-0">New Staff Expenses</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item text-muted" href="#">Expenses</li>
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Staff_Expenses.aspx">Staff Expenses
                            </a>
                        </li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="#">New Staff Expenses</li>
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
            <div class="col-md-5 col-sm-5 col-lg-5">
                <div id="ExpDiv" runat="server" visible="true">
                    <div class="card">
                        <div class="card-body">
                            <div class="mb-2">
                                <asp:Label ID="lblName" runat="server" Text="Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                <asp:TextBox ID="txtExpenseName" runat="server" placeholder="Enter Expense Name" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldExpense" runat="server" ErrorMessage="Enter Expense Name" ControlToValidate="txtExpenseName" Font-Size="12px" ForeColor="Red" Font-Bold="false" ValidationGroup="Expense"></asp:RequiredFieldValidator>
                            </div>
                            <div class="mb-2">
                                <asp:Label ID="lblNote" runat="server" Text="Note" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000"></span>
                                <asp:TextBox ID="txtNote" runat="server" placeholder="Enter Expense Note" class="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <asp:Label ID="lblExpensestype" runat="server" Text="Expenses Type" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                <asp:DropDownList ID="ddlExpensesType" runat="server" CssClass="form-control form-select" Placeholder="Select Expenses Type">
                                    <asp:ListItem Value="0" Text="Nothing Selected"></asp:ListItem>
                                    <asp:ListItem Value="Regular" Text="Regular"></asp:ListItem>
                                    <asp:ListItem Value="reimbursement" Text="Reimbursement"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rqfddlExpensesType" runat="server" ErrorMessage="Select Expenses Type" ControlToValidate="ddlExpensesType" Display="Dynamic" Font-Size="12px" ForeColor="Red" Font-Bold="false" InitialValue="0" ValidationGroup="Expense"></asp:RequiredFieldValidator>
                            </div>

                            <div class="mb-2">
                                <asp:TextBox ID="txtother" runat="server" CssClass="form-control" Visible="false" placeholder="Other"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <asp:Label ID="lblExpensesDate" runat="server" Text="Expenses Date" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                <asp:TextBox ID="txtExpensesDate" type="date" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="Enter Expenses Date"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredExpensestDate" runat="server" ErrorMessage="Enter Expenses Date" ControlToValidate="txtExpensesDate" ForeColor="Red" Font-Bold="false" Font-Size="12px" ValidationGroup="Expense"></asp:RequiredFieldValidator>
                            </div>
                            <div class="mb-2">
                                <asp:Label ID="lblbillno" runat="server" Text="Expenses Bill Number" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                <asp:TextBox ID="txtBillno" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="Enter Expenses Bill Number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Expenses Bill Number" ControlToValidate="txtBillno" ForeColor="Red" Font-Bold="false" Font-Size="12px" ValidationGroup="Expense"></asp:RequiredFieldValidator>
                                <div class="mb-2">
                                    <asp:Label ID="lblCurrency" runat="server" Text="Currency" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtCurrency" runat="server" CssClass="form-control" placeholder="INR" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="row">
                                    <div class="mb-2">
                                        <asp:Label ID="lblPaymentMode" runat="server" Text="Payment Mode" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <asp:DropDownList ID="ddlPaymentMode" runat="server" CssClass="form-control form-select">
                                            <asp:ListItem Value="0" Text="Nothing Selected"></asp:ListItem>
                                            <asp:ListItem Value="Bank" Text="Bank"></asp:ListItem>
                                            <asp:ListItem Value="Cash" Text="Cash"></asp:ListItem>
                                            <asp:ListItem Value="Online" Text="Online"> </asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredPaymentMode" runat="server" ErrorMessage="Select Payment Mode" ControlToValidate="ddlPaymentMode" ForeColor="Red" Font-Bold="false" Font-Size="12px" ValidationGroup="Expense" InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>


                                    </div>
                                    <div class="mb-2">
                                        <asp:Label ID="lblStaff" runat="server" Text="Staff Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <asp:DropDownList ID="ddlStaff" runat="server" CssClass="form-control form-select " Placeholder="Select ddlStaff">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFielddlddlStaff" runat="server" ErrorMessage="Select Staff" ControlToValidate="ddlStaff" ForeColor="Red" Font-Bold="false" Font-Size="12px" ValidationGroup="Expense" InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="mb-2">
                                    <asp:Button ID="btnSaveStaffExpense" runat="server" Text="Next" CssClass="btn btn-success btn-sm" ValidationGroup="Expense" OnClick="btnSaveStaffExpense_Click" />
                                    <asp:Button ID="btnSaveAll" runat="server" Text="Save" CssClass="btn btn-primary btn-sm " ValidationGroup="ExpenseD" Visible="false" OnClick="btnSaveAll_Click" />
                                    &nbsp;&nbsp;
                                       <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-danger  btn-sm" OnClick="btnClear_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-7 col-sm-7 col-lg-7">
                <div id="itemtable" runat="server" visible="false">
                    <div class="card">
                        <div class="card-body">
                        <h6 class="text-purple">
                            <asp:Label ID="lblItem" runat="server" Text="Add Expenses Item"></asp:Label>
                        </h6>
                        <hr />
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <div class="alert alert-warning" role="alert" id="msgdiv" runat="server">
                                    <asp:Label ID="lblMsg1" runat="server" Text="" Visible="false" Font-Bold="false" Font-Size="12px" ForeColor="Red" ValidateRequestMode="Disabled"></asp:Label>
                                </div>
                                <div class="alert alert-info" role="alert" id="SuccessDiv1" runat="server">
                                    <asp:Label ID="lblMsg" runat="server" Text="" Visible="false" Font-Bold="false" Font-Size="12px" ForeColor="Blue" ValidateRequestMode="Disabled"></asp:Label>
                                </div>

                            </div>
                        </div>
                        <asp:Label ID="lblMsId" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblExpNameWGV" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblexpid2" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                        <div class="row">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="col-md-6 col-xs-6 col-sm-6 col-lg-6">
                                                <div class="input-group">
                                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                                    <asp:DropDownList ID="ddlItem" runat="server" CssClass="form-select form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged">
                                                    </asp:DropDownList>

                                                    <!-- Button trigger modal -->
                                                    <button type="button" class="btn btn-info btn-sm font-medium" data-bs-toggle="modal"
                                                        data-bs-target="#ItemID">
                                                        +
                                                    </button>
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-xs-6 col-sm-6 col-lg-6"></div>
                                        </div>

                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="table-responsive">
                                                <asp:GridView ID="GridViewOffice" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                    ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" FooterStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="true">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblItem" runat="server" Text="ItemName" CssClass="form-label"></asp:Label>
                                                            </HeaderTemplate>
                                                            <FooterTemplate>
                                                                <%--<asp:TextBox ID="txtItem" runat="server" Text="" CssClass="form-control" Placeholder="Description"></asp:TextBox>--%>
                                                                <asp:TextBox ID="txtItem" runat="server" TextMode="MultiLine" Text="" CssClass="form-control" Placeholder="Item Name"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfv_TenderItem" ControlToValidate="txtItem" Display="Dynamic" runat="server" ErrorMessage="Please Select Item" ForeColor="Red" ValidationGroup="ItemTender" Font-Size="12px"></asp:RequiredFieldValidator>
                                                            </FooterTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblItemID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblItem1" runat="server" Text='<%# Bind("Item") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                            </HeaderTemplate>
                                                            <FooterTemplate>
                                                                   <asp:Label ID="lblHSN" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                                             
                                                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Text="" CssClass="form-control" Placeholder="Long Description"></asp:TextBox>
                                                            </FooterTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDescription1" runat="server" Text='<%# Bind("Description") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblRate" runat="server" Text="ItemRate" CssClass="form-label"></asp:Label>
                                                            </HeaderTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txtRate" runat="server" Text="" CssClass="form-control" Placeholder="Rate"></asp:TextBox>
                                                            </FooterTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtRate1" runat="server" Text='<%# Bind("Rate") %>' CssClass="form-control" Placeholder="Rate" TextMode="Number" Style="width: 150px" Visible="false" ValidationGroup="R"></asp:TextBox>
                                                                <asp:Label ID="lblRate1" runat="server" Text='<%# Bind("Rate") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblQuantity" runat="server" Text="Qty" CssClass="form-label"></asp:Label>
                                                            </HeaderTemplate>
                                                            <FooterTemplate>
                                                                <asp:TextBox ID="txtQty" runat="server" Text="1" CssClass="form-control" Placeholder="Quantity" TextMode="Number" Style="width: 60px"></asp:TextBox>
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
                                                                <asp:Label ID="lblTotalAmount" runat="server" Text="Amount" CssClass="form-label"></asp:Label>
                                                            </FooterTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("Amount") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="btnOption" runat="server" Text="" ValidationGroup="setting"><i class="ti ti-settings"></i></asp:LinkButton>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnDeleteItemCal" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-rounded btn-danger btn-sm" ValidationGroup="DelItemTender" Text="" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteItemCal_Click" Visible="false"><i class="ti ti-trash"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:LinkButton ID="btnAddStaffItem" runat="server" CssClass="btn btn-sm btn-rounded btn-info" Text="" TabIndex="9" OnClick="btnAddStaffItem_Click" ValidationGroup="ItemTender"><i class="ti ti-check"></i></asp:LinkButton>
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
                                    <div class="container-fluid ">
                                        <div class="row">
                                            <asp:Table ID="Table2" runat="server" CssClass="col-md-12 col-sm-12 col-lg-12  font-bold">
                                                <asp:TableRow ID="TableRow3" runat="server">
                                                    <asp:TableCell CssClass="col-md-6 col-sm-6 col-lg-6">
                                                    </asp:TableCell>
                                                    <asp:TableCell CssClass="col-md-3 col-sm-3 col-lg-3">
                                                        <asp:Label ID="lblSubTotal" CssClass="form-label" runat="server" Text="Total Amount :"></asp:Label>
                                                    </asp:TableCell>
                                                    <asp:TableCell CssClass="col-md-3 col-sm-3 col-lg-3">
                                                        <asp:Label ID="lblSubTotalCost" runat="server" Text="0" CssClass="form-control ms-2" Font-Size="12px" Font-Bold="false"></asp:Label>
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                            </asp:Table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-lg-12">
                                    <asp:Label ID="lblBillNoretrive" runat="server" Text="" CssClass="form-label" Visible="false"></asp:Label>

                                    <%-- ------------------------------------------- File Uploadd----------------------------------- --%>

                                    <div class="row">
                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                            <div>
                                                <h6>
                                                    <asp:Label ID="lblAttachment" runat="server" Text="Attachment" Font-Size="12px"></asp:Label></h6>
                                            </div>
                                        </div>
                                    </div>

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

                                            <asp:GridView ID="GridExpensesFile" runat="server" ScrollBars="Both" CssClass="table table-responsive border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                ClientIDMode="Static" ShowHeader="false" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                                                <Columns>
                                                    <asp:TemplateField Visible="false">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblExpensesFileId" runat="server" Text="FileName" CssClass=" font-bold" Visible="false"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblExpensesFileId1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblExpensesFileName" runat="server" Text="FileName" CssClass="form-label"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblExpensesrFileName1" runat="server" Text='<%# Bind("FileName") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnDeleteExpensesFile" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-rounded btn-danger" Visible="false" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteExpensesFile_Click"><i class="ti ti-trash"></i></asp:LinkButton>
                                                        </ItemTemplate>

                                                        <EditItemTemplate>
                                                        </EditItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>

                                        </div>

                                    </div>

                                    <%-- ------------------------------------------- File Uploadd----------------------------------- --%>
                                </div>




                            </div>
                        </div>
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
                                            <asp:Label ID="lbl_LongDescription" runat="server" Text="Long Description" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txt_LongDescription" TextMode="MultiLine" runat="server" Font-Size="12px" CssClass="form-control" placeholder="Enter Long Description"></asp:TextBox>
                                        </div>

                                        <div class="mb-2">
                                            <asp:Label ID="lbl_Tax" runat="server" Text="Tax1" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
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

</asp:Content>
