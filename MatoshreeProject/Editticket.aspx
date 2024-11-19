<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Editticket.aspx.cs" Inherits="MatoshreeProject.Editticket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
             <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="font-weight-medium mb-0">Edit Ticket</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item"><a class="text-muted text-decoration-none" href="Ticket_Details.aspx">Ticket Details</a></li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="#">Edit Ticket</li>
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
                        <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6 border-right">
                             <asp:Label ID="lblStaffEmail" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lblStaffDesignation" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lblEmpName11" runat="server" Text="" Visible="false"></asp:Label>

                            <hr />
                            <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                <div class="mb-2">
                                    <asp:Label ID="lblInitialTicket1" runat="server" Text="Ticket Number" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblInitialNumber" runat="server" Text="-" Visible="false" Font-Bold="true" CssClass="form-control text-purple" ReadOnly="true"></asp:Label>
                                    <asp:TextBox ID="txtInitialTicket" runat="server" ReadOnly="true" CssClass="form-control text-purple"></asp:TextBox>
                                    <asp:Label ID="lblCustomerID" runat="server" Text="" Visible="false" Font-Bold="true" CssClass="form-control" ReadOnly="true"></asp:Label>


                                </div>
                            </div>

                            <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                <div class="mb-2">
                                    <asp:Label ID="lblTicketid" runat="server" Text="" Visible="false" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblsubject" runat="server" Text="Subject" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtsubject" runat="server" placeholder="Enter Subject" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtsubject" ErrorMessage="Enter  Subject.." ForeColor="Red" ValidationGroup="Save" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                <div class="row">
                                    <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblcontact" runat="server" Text="Contact" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:DropDownList ID="ddlcontact" runat="server" CssClass="form-control form-select" OnSelectedIndexChanged="ddlcontact_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredContact" runat="server" ErrorMessage="Select Contact" ControlToValidate="ddlcontact" ForeColor="Red" Font-Bold="false" ValidationGroup="Save" InitialValue="0" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblProject" runat="server" Text="Project Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:DropDownList ID="ddlProject" runat="server" CssClass="form-control form-select">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredProject" runat="server" ErrorMessage="Select Project" ControlToValidate="ddlProject" ForeColor="Red" Font-Bold="false" ValidationGroup="Save" InitialValue="0" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                <div class="row">
                                    <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblname" runat="server" Text="Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:TextBox ID="txtname" CssClass="form-control" placeholder="Enter Name" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="Requiredname" ControlToValidate="txtname" Display="Dynamic" runat="server" ErrorMessage="Please Select Name" ForeColor="Red" Font-Size="12px"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblemail" runat="server" Text="Email Address" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txtemail" CssClass="form-control" placeholder="Enter Email Address" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lbldept" runat="server" Text="Department" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                            <asp:DropDownList ID="ddldepart" runat="server" CssClass="form-control form-select">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="Reqdepart" runat="server" ErrorMessage="Select Department" ControlToValidate="ddldepart" ForeColor="Red" Font-Bold="false" ValidationGroup="Save" InitialValue="0" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                        <div class="mb-2">
                                            <asp:Label ID="lblcc" runat="server" Text="CC" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txtcc" CssClass="form-control" placeholder="Enter cc" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <hr />
                            <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                <div class="mb-2">
                                    <asp:Label ID="lblbody" runat="server" Text="Ticket Body" Font-Bold="true" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txtareabody" runat="server" placeholder="Enter Ticket Body" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                    <br />
                                    <asp:CheckBox ID="chkSendEmail" Text="&nbsp; Send Email" runat="server" CssClass=" font-bold" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                            <hr />
                            <div class="row">

                                <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblassignticket" runat="server" Text="Assign ticket" Font-Bold="true" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <asp:DropDownList ID="ddlassign" runat="server" CssClass="form-control form-select">
                                            <asp:ListItem>Nothing Selected</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="Requiredassign1" runat="server" ErrorMessage="Select Assined" ControlToValidate="ddlassign" ForeColor="Red" Font-Bold="false" ValidationGroup="Save" InitialValue="0" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblStatus" runat="server" Text="Status Name" Font-Bold="true" CssClass="form-label"></asp:Label>
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control form-select">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblprioprity" runat="server" Text="Priority" Font-Bold="true" CssClass="form-label"></asp:Label>
                                        <asp:DropDownList ID="ddlpriority" runat="server" CssClass="form-control form-select">
                                            <asp:ListItem>Nothing Selected</asp:ListItem>
                                            <asp:ListItem>Low</asp:ListItem>
                                            <asp:ListItem>Medium</asp:ListItem>
                                            <asp:ListItem>High</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblService" runat="server" Text="Service" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="txtservice" runat="server" placeholder="Service" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                    <div class="mb-2">
                                        <div class="row">
                                            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                                                <div>
                                                    <h6>
                                                        <asp:Label ID="lblAttachment" runat="server" Text="Attachment" Font-Size="12px"></asp:Label></h6>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="input-group">
                                                <asp:FileUpload ID="FileUpload" runat="server" Text="" CssClass="form-control" />
                                                <asp:Button ID="Btn_Upload" runat="server" Text="Upload" CssClass="btn btn-sm btn-info" OnClick="Btn_Upload_Click" />
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="GridTicketFile" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                        ClientIDMode="Static" ShowHeader="false" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                                                        <Columns>
                                                            <asp:TemplateField Visible="false">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblTicketFileId" runat="server" Text="FileName" CssClass=" font-bold" Visible="false"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTicketFileId1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblTicketFileName" runat="server" Text="FileName" CssClass="form-label"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTicketFileName1" runat="server" Text='<%# Bind("Tick_File") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
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

                                        </div>

                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                    <center>
                        <div class="mb-2">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success btn-sm" ValidationGroup="Validate" OnClick="btnUpdate_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnClear" runat="server" Text="Cancel" CssClass="btn btn-danger btn-sm" OnClick="btnClear_Click" />
                        </div>

                    </center>
                </div>
            </div>
        </div>
    </div>
        </div>
</asp:Content>
