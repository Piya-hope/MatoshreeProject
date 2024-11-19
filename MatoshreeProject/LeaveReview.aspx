<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="LeaveReview.aspx.cs" Inherits="MatoshreeProject.LeaveReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5>Leave Review</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="LeaveApproval.aspx">Leave Approval
                            </a>
                        </li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="LeaveReview.aspx">Leave Review</li>
                    </ol>
                </nav>
            </div>

        </div>
        <br />
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
                                    <asp:Label ID="lblmsgdele2" runat="server" Text="" Font-Size="13.5px" ForeColor="Black"></asp:Label>
                                </div>
                                <button type="button" class="btn-close me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- Toaster --%>
        <br />

        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12  col-xs-12">

                <div class="row">
                    <h5>Number of Leaves</h5>
                    <div class="col-md-3 col-sm-3 col-xs-3 col-lg-3">
                        <div class="card border-bottom border-success">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblTotalLeaveCount" CssClass="text-center text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-success mb-0">
                                            <asp:Label ID="lblTotalLeave" runat="server" Text="Total" CssClass="text-success" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-success display-6">
                                            <iconify-icon icon="fluent-mdl2:leave-user" class="aside-icon"></iconify-icon>
                                        </span>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2 col-sm-2 col-xs-2 col-lg-2">


                        <div class="card border-bottom border-warning">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblSickLeaveCount" runat="server" CssClass="text-center text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-info mb-0">
                                            <asp:Label ID="lblSickLeave" runat="server" Text="Sick" CssClass="text-warning" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-warning display-6">
                                            <iconify-icon icon="fluent-mdl2:leave-user" class="aside-icon"></iconify-icon>
                                        </span>

                                    </div>
                                </div>
                            </div>
                        </div>


                    </div>

                    <div class="col-md-2 col-sm-2 col-xs-2 col-lg-2">

                        <div class="card border-bottom border-info">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblCasualLeaveCount" runat="server" CssClass="text-center  text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-danger mb-0">
                                            <asp:Label ID="lblCasualLeave" runat="server" Text="Casual" CssClass="text-info" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-info display-6">
                                            <iconify-icon icon="fluent-mdl2:leave-user" class="aside-icon"></iconify-icon>
                                        </span>

                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-md-2 col-sm-2 col-xs-2 col-lg-2">
                        <div class="card border-bottom border-success">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">

                                            <asp:Label ID="lblYourLeaveCount" runat="server" CssClass="text-center  text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-success mb-0">
                                            <asp:Label ID="lblYourLeave" runat="server" Text="Your" CssClass="text-success" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-success display-6">
                                            <iconify-icon icon="fluent-mdl2:leave-user" class="aside-icon"></iconify-icon>
                                        </span>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-3 col-sm-3 col-xs-3 col-lg-3">

                        <div class="card border-bottom border-danger">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblRemainingLeaveCount" runat="server" CssClass="text-center  text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                        </h2>
                                        <h6 class="fw-medium text-danger mb-0">
                                            <asp:Label ID="lblRemainingLeave" runat="server" Text="Remaining" CssClass="text-danger" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-danger display-6">
                                            <iconify-icon icon="fluent-mdl2:leave-user" class="aside-icon"></iconify-icon>
                                        </span>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>



                <div id="ExpDiv" runat="server" visible="true">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title" style="color: blue">Leave Review</h5>
                            <hr />
                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblInitialLeave" runat="server" Text="" Visible="false" ForeColor="Black"></asp:Label>
                                        <asp:Label ID="lblInitialNumber" runat="server" Text="" Visible="false" ForeColor="Black"></asp:Label>
                                        <asp:Label ID="lblStaffEmail" runat="server" Text="" Visible="false"></asp:Label>
                                        <asp:Label ID="lblStaffDesignation" runat="server" Text="" Visible="false"></asp:Label>
                                        <asp:Label ID="lblEmpName11" runat="server" Text="" Visible="false"></asp:Label>
                                        <asp:Label ID="lblMesDelete" runat="server" Text="" Font-Size="13.5px" Visible="false" ForeColor="Black"></asp:Label>
                                        <asp:Label ID="lblLeaveID" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                        <asp:Label ID="lblStaffName" runat="server" Text="Staff Name" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label>
                                        <asp:TextBox ID="txtStaffName" runat="server" Font-Size="12px" ReadOnly="true" placeholder="Enter Staff Name" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblDepartment" runat="server" Text="Department" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label>
                                        &nbsp;<span style="color: #FF0000">*</span>
                                        <asp:DropDownList ID="ddlDepartment" runat="server" Font-Size="12px" CssClass="form-control form-select" Placeholder="Select Department">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblDesignation" runat="server" Text="Designation" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label>
                                        <asp:TextBox ID="txtDesignation" runat="server" Font-Size="12px" placeholder="Enter Designation" ReadOnly="true" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblPhone" for="Phone" runat="server" Text="Phone" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label>
                                        <asp:TextBox ID="txtPhone" runat="server" Font-Size="12px" placeholder="Enter Phone Number" ReadOnly="true" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblStartDate" runat="server" Text="Start Date" CssClass="form-label" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        &nbsp;<span style="color: #FF0000">*</span>
                                        <asp:TextBox ID="txtStartDate" type="date" CssClass="form-control" Font-Size="12px" Style="display: inline-block;" runat="server" placeholder="Enter Start Date"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredStartDate" runat="server" Font-Size="12px" ErrorMessage="Enter Start Date" ControlToValidate="txtStartDate" ForeColor="Red" Font-Bold="false" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblEndDate" runat="server" Text="End Date" CssClass="form-label" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        &nbsp;<span style="color: #FF0000">*</span>
                                        <asp:TextBox ID="txtEndDate" type="date" CssClass="form-control" Font-Size="12px" Style="display: inline-block;" runat="server" placeholder="Enter End Date"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldEnd2" runat="server" Font-Size="12px" ErrorMessage="Enter End Date" ControlToValidate="txtEndDate" ForeColor="Red" Font-Bold="false" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblLeaveType" runat="server" Text="Leave Type" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label>
                                        &nbsp;<span style="color: #FF0000">*</span>
                                        <asp:DropDownList ID="ddlLeaveType" runat="server" Font-Size="12px" CssClass="form-control form-select" Placeholder="Select LeaveType">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    <div class="mb-2">
                                          <asp:Label ID="lbltype" runat="server" Text="Leave Payment Type" CssClass="form-label" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        
                                        <asp:DropDownList ID="ddlPaymentType" runat="server" Font-Size="12px" CssClass="form-control form-select" Placeholder="Select Payment Type">
                                            <asp:ListItem Value="0" Text="Select payment Type"></asp:ListItem>
                                            <asp:ListItem Value="Paid" Text="Paid"></asp:ListItem>
                                            <asp:ListItem Value="UnPaid" Text="UnPaid"></asp:ListItem>
                                        </asp:DropDownList>
                                           <asp:RequiredFieldValidator ID="RequiredFieldpaymenttype" runat="server" Font-Size="12px" ErrorMessage="Select Payment Type" ControlToValidate="ddlPaymentType" ForeColor="Red" Font-Bold="false" ValidationGroup="AcceptLM" InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="Label2" runat="server" Text="Reason" CssClass="form-label" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        <asp:TextBox ID="txtReason" runat="server" Font-Size="12px" TextMode="MultiLine" placeholder="Enter Designation" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    <div class="mb-2">

                                        <asp:Label ID="Label3" runat="server" Text="Duration" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <div class="row">
                                              <asp:Label ID="lblgetDuration" runat="server" Text="" Visible="false"></asp:Label>
                                            <div class="col-md-4 col-sm-4 col-lg-4  col-xs-4"><asp:TextBox ID="txtno" runat="server" Font-Size="12px" CssClass="form-control" /></div>
                                          
                                              <div class="col-md-4 col-sm-4 col-lg-4  col-xs-4"><asp:CheckBox ID="chkbefore" Font-Size="12px" runat="server"  OnCheckedChanged="chkbefore_CheckedChanged" AutoPostBack="true" Font-Bold="true" />&nbsp;<asp:Label ID="Label4" runat="server" Text="Before" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label> </div>
                                              <div class="col-md-4 col-sm-4 col-lg-4  col-xs-4"><asp:CheckBox ID="chkafter" Font-Size="12px" runat="server"  Font-Bold="true" OnCheckedChanged="chkafter_CheckedChanged" AutoPostBack="true" />&nbsp;<asp:Label ID="Label5" runat="server" Text="After" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label>   </div>
                                        </div>
                                        
                                  </div>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-lg-12  col-xs-12">
                                    <div class="mb-2">
                                        <asp:Label ID="Label1" runat="server" Text="Remark" CssClass="form-label" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        <asp:TextBox ID="txtResonReject" runat="server" Font-Size="12px" TextMode="MultiLine" placeholder="Enter Reason" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldDepartment" runat="server" Font-Size="12px" ErrorMessage="Enter Reason" ControlToValidate="txtResonReject" ForeColor="Red" Font-Bold="false" ValidationGroup="btnRejectLM"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                 <asp:Label ID="lblAttachment" runat="server" Text="Attachment" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label>
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    
                                      <div class="row">
                                          <div class="col-md-12 col-sm-12 col-lg-12  col-xs-12">
                                                 
                                    <div class="mb-2">
                                                 <div class="input-group">
                                                  
                                            <asp:FileUpload ID="FileUpload" runat="server" Text="" CssClass="form-control mdi-file-import"  />
                                                
                                            <asp:Button ID="Btn_Upload" runat="server" Text="Upload" CssClass="btn btn-primary btn-sm " OnClick="Btn_Upload_Click" />
                                                  </div>     
                                        </div>
                                              </div>
                                          </div>
                                    </div>

                                    <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                        <div class="mb-2">
                                            <div class="row">
                                                <div class="col-md-12 col-sm-12 col-lg-12">
                                                     <asp:Label ID="lbdLeaveMID" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                    <asp:GridView ID="GridLeaveRequestFile" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                        ClientIDMode="Static" ShowHeader="false" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false"  DataKeyNames="ID">
                                                        <Columns>
                                                            <asp:TemplateField Visible="false">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblLeaveFileId" runat="server" Text="FileName" Font-Size="12px" Font-Bold="false" Visible="false"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLeaveFileId1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                   
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblLeaveRequestFileName" runat="server" Font-Size="12px" Text="FileName" Font-Bold="false"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLeaveFileName1" runat="server" Text='<%# Bind("FileName") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="Download" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnDownload" runat="server" CausesValidation="false" CommandName="download" OnClick="btnDownload_Click" CssClass="btn btn-sm btn-success " Visible="false"><i class="ti ti-download" ></i></asp:LinkButton>
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



                            <div class="row">
                                   
                                        <div class="mb-2 text-center">
                                            <asp:Button ID="btnAcceptLM" runat="server" Text="Accept" ValidationGroup="AcceptLM" CssClass="btn btn-success btn-sm " OnClick="btnAcceptLM_Click" />
                                            &nbsp;&nbsp;
                                        <asp:Button ID="btnRejectLM" runat="server" Text="Reject" CssClass="btn btn-danger  btn-sm" ValidationGroup="btnRejectLM" OnClick="btnRejectLM_Click" />

                                        </div>
                                  
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
