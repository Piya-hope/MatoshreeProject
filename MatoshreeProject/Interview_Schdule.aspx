<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Interview_Schdule.aspx.cs" Inherits="MatoshreeProject.Interview_Schdule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

      <script type="text/javascript">
        $(document).ready(function () {
            var GridInterviewSchedule = $("#GridInterviewSchedule").prepend($("<thead></thead>").append($("#GridInterviewSchedule").find("tr:first"))).DataTable(
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
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="font-weight-medium mb-0">View Interview Schdule</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="career.aspx">Career
                            </a>
                        </li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="Interview_Schdule.aspx">Interview Schdule</li>
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
                <div class="card">
                    <div class="card-body">
                        <h5 class="font-weight-medium mt-3 mb-3">View Interview Schdule Details</h5>
                        <hr />

                        <div class="row">
                          <%--  <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                                <div class="bd-example">
                                    <div class="btn-group">
                                        <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                        <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                        <div class="dropdown-menu">
                                            <asp:LinkButton ID="lnkbtnExcel" Text="Excel" runat="server" CssClass="dropdown-item"></asp:LinkButton>
                                            <asp:LinkButton ID="linkbtnPDF" runat="server" Text="PDF" CssClass="dropdown-item" ></asp:LinkButton>

                                        </div>
                                    </div>
                                    <asp:Button ID="BTN_Visibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" />

                                    <asp:Button ID="Btn_Reload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" />


                                </div>
                            </div>--%>
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
                                <asp:Label ID="Label1" runat="server" Text="Phone:" CssClass="" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblphoneNo1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblvat" runat="server" Text="VAT NO:" CssClass="" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblVatNo1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" CssClass="" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblGSTNo1A" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                            </div>
                        </div>

                      <%--  <br />
                        <br />--%>

                        <asp:GridView ID="GridInterviewSchedule" runat="server" ScrollBars="Both" CssClass="table border table-hover table-bordered text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="id" OnRowDataBound="GridInterviewSchedule_RowDataBound" OnRowDeleting="GridInterviewSchedule_RowDeleting">
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
                          
                                   <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnViewInterviewSchdule" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-info" OnClick="btnViewInterviewSchdule_Click"><%--<i class="ti ti-eye"></i>--%>Interview Schedule</asp:LinkButton>
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

            <div class="col-md-12 col-sm-12 col-lg-12">

                <div class="card">
                    <div class="card-body">
                        <h5>Interview Schdule</h5>
                        <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>

                        <hr />

                        <div class="row">

                            <div class="col-md-6 col-sm-6 col-lg-6">
                                  <asp:Label ID="lblFirstNmID" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                    <asp:Label ID="lblStaffEmail" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="lblStaffDesignation" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="lblEmpName11" runat="server" Text="" Visible="false"></asp:Label>
                                <div class="mb-2">
                                    <asp:Label ID="lblFullNm" for="FullName" runat="server" Text="FullName" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtFullNm" runat="server" name="FullName" CssClass="form-control" placeholder="Enter Full Name" ReadOnly="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_Phone" runat="server" Display="Dynamic" ControlToValidate="txtFullNm" ErrorMessage="Enter Full Name" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblPosition" for="Employer" runat="server" Text="Position" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtPosition" runat="server" name="phone" CssClass="form-control" placeholder="Enter Position" ReadOnly="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ControlToValidate="txtPosition" ErrorMessage="Enter Position" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblEmail" for="Phone" runat="server" Text="Email" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtEmail" runat="server" name="email" CssClass="form-control" placeholder="Enter Email Address" ReadOnly="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rvfEmail" runat="server" Display="Dynamic" ControlToValidate="txtEmail" ErrorMessage="Enter Email Address" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px" ReadOnly="true"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="Regulexemail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Address Invalid." ForeColor="Red" ValidationGroup="SaveValidate" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" Font-Size="12px"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblPhone" for="Phone" runat="server" Text="Phone" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtPhone" runat="server" name="phone" CssClass="form-control" placeholder="Enter Phone Number" MaxLength="10" TextMode="Phone" ReadOnly="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtPhone" ErrorMessage="Enter 10 digit Phone Number" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="Regulexphone" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone Number Invalid." ForeColor="Red" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblInterviewDate" runat="server" Text="InterviewDate" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtInterviewDate" runat="server" CssClass="form-control" placeholder="Enter Interview Date" type="date" Style="display: inline-block;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtInterviewDate" ErrorMessage="Enter Interview Date" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>

                                </div>
                            </div>

                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblInterviewerLoc" runat="server" Text="Interviewer Location" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:RadioButtonList ID="rbtnList" runat="server" RepeatDirection="Vertical" Font-Size="12px" AutoPostBack="True" OnSelectedIndexChanged="rbtnList_SelectedIndexChanged">
                                        <asp:ListItem Text="Onsite" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Online" Value="2"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblInterviewTime" runat="server" Text="InterviewTime" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtInterviewTime" runat="server" CssClass="form-control" placeholder="Enter Interview Time" type="time" Style="display: inline-block;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtInterviewTime" ErrorMessage="Enter Interview Time" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>

                                </div>
                            </div>


                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblAddress" runat="server" Text="Address" CssClass="form-label"></asp:Label><%--&nbsp;<span style="color: #FF0000">*</span>--%>
                                 <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Address"></asp:TextBox>
                                     <%--  <asp:RequirValidator runat="server" Display="Dynamic" TextMode="MultiLine" ControlToValidate="txtAddress" ErrorMessage="Enter Address" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>--%>
                        </div>

                        </div>
                            </div>

                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblInterviewerNm" runat="server" Text="Interviewer Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtInterviewerNm" runat="server" CssClass="form-control" placeholder="Enter Interviewer Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtInterviewerNm" ErrorMessage="Enter Interviewer Name" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lbllink" runat="server" Text="Meeting ID/link" CssClass="form-label"></asp:Label><%--&nbsp;<span style="color: #FF0000">*</span>--%>
                                    <asp:TextBox ID="txtlink" runat="server" CssClass="form-control" placeholder="Enter Meeting ID/link"></asp:TextBox>
                                    <%--  <asp:RequiredFValidator runat="server" Display="Dynamic" TextMode="MultiLine" ControlToValidate="txtlink" ErrorMessage="Enter Meeting ID/link" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>--%>
                                </div>
                            </div>
                              </div>
                       
                             <br />
                        <center>
                           <div class="mb-2">
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="SaveValidate" OnClick="btnSave_Click"/>
                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="Validateclear" OnClick="btnClear_Click"/>

                            </div>
                            </center>
                  
                </div>
            </div>

             
        </div>
    </div>

                  </div>
            </div>
</asp:Content>
