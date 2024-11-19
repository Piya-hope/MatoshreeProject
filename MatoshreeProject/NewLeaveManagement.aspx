<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="NewLeaveManagement.aspx.cs" Inherits="MatoshreeProject.NewLeaveManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container-fluid">

        <div class="row">
            <div class="col-md-8 col-sm-8 col-xs-8 col-lg-8">
                <h5 class="font-weight-medium mb-0">Leave Management</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="LeaveManagement.aspx">Leave Management
                            </a>
                        </li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="NewLeaveManagement.aspx">New Leave Management</li>
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
                                    <asp:Label ID="lblMesDelete1" runat="server" Text="" Font-Size="13.5px" ForeColor="Black"></asp:Label>
                                </div>
                                <button type="button" class="btn-close me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- Toaster --%>
              </div>
          <br />
        
         <h5 >Number of Leaves</h5>
        
         <div class="row">
             <div class="col-md-3 col-sm-3 col-xs-3 col-lg-3">
                    <div class="card border-bottom border-success">
                        <div class="card-body">
                            <div class="d-flex align-items-center">
                                <div>
                                    <h2 class="fs-7">
                                        <asp:Label ID="lblTotalLeaveCount" CssClass="text-center text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                    </h2>
                                    <h6 class="fw-medium text-success mb-0">
                                        <asp:Label ID="lblTotalLeave" runat="server" Text="TotalL" CssClass="text-success" Font-Size="12px" Font-Bold="true"></asp:Label>
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
                                        <asp:Label ID="lblSickLeave" runat="server" Text="SickL" CssClass="text-warning" Font-Size="12px" Font-Bold="true"></asp:Label>
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
                                     <asp:Label ID="lblYourLeave" runat="server" Text="YourL" CssClass="text-success" Font-Size="12px" Font-Bold="true"></asp:Label>
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
                                     <asp:Label ID="lblRemainingLeave" runat="server" Text="RemainingL" CssClass="text-danger" Font-Size="12px" Font-Bold="true"></asp:Label>
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
            
  
         <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12  col-xs-12">
                <div id="ExpDiv" runat="server" visible="true">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title" style="color: blue">Leave Request</h5>
                            <hr />
                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblStaffEmail" runat="server" Text="" Visible="false"></asp:Label>
                                        <asp:Label ID="lblStaffDesignation" runat="server" Text="" Visible="false"></asp:Label>
                                        <asp:Label ID="lblEmpName11" runat="server" Text="" Visible="false"></asp:Label>
                                        <asp:Label ID="lblMesDelete" runat="server" Text="" Font-Size="13.5px" Visible="false" ForeColor="Black"></asp:Label>
                                        <asp:Label ID="lblStaffName" runat="server" Text="Staff Name" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label>
                                        <asp:TextBox ID="txtStaffName" runat="server" Font-Size="12px" placeholder="Enter Staff Name" ReadOnly="true" class="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblDepartment" runat="server" Text="Department" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <asp:DropDownList ID="ddlDepartment" runat="server" Font-Size="12px" CssClass="form-control form-select" Placeholder="Select Department">
                                        </asp:DropDownList>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldDepartment" runat="server" Font-Size="12px" ErrorMessage="Select Department" ControlToValidate="ddlDepartment" ForeColor="Red" Font-Bold="false" ValidationGroup="Save" InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblDesignation" runat="server" Text="Designation" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label>
                                        <asp:TextBox ID="txtDesignation" runat="server" Font-Size="12px" placeholder="Enter Designation" class="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblPhone" for="Phone" runat="server" Text="Phone" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label>
                                        <asp:TextBox ID="txtPhone" runat="server" Font-Size="12px" placeholder="Enter Phone Number" ReadOnly="true" MaxLength="10" class="form-control"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <br />
                           <div class="row">
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblStartDate" runat="server" Text="Start Date" CssClass="form-label" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <asp:TextBox ID="txtStartDate" type="date" CssClass="form-control" Font-Size="12px" Style="display: inline-block;" runat="server" placeholder="Enter Start Date"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredStartDate" runat="server" Font-Size="12px" ErrorMessage="Enter Start Date" ControlToValidate="txtStartDate" ForeColor="Red" Font-Bold="false" ValidationGroup="SaveLM"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblEndDate" runat="server" Text="End Date" CssClass="form-label" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <asp:TextBox ID="txtEndDate" type="date" CssClass="form-control" Font-Size="12px" Style="display: inline-block;" runat="server" placeholder="Enter End Date"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldEnd2" runat="server" Font-Size="12px" ErrorMessage="Enter End Date" ControlToValidate="txtEndDate" ForeColor="Red" Font-Bold="false" ValidationGroup="SaveLM"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                             <div class="row">
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblLeaveType" runat="server" Text="Leave Type" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <asp:DropDownList ID="ddlLeaveType" runat="server" Font-Size="12px" CssClass="form-control form-select" Placeholder="Select LeaveType">
                                        </asp:DropDownList>
                                         <asp:RequiredFieldValidator ID="RequiredFieldLeaveType" runat="server" Font-Size="12px" ErrorMessage="Select Leave Type" ControlToValidate="ddlLeaveType" ForeColor="Red" Font-Bold="false" ValidationGroup="SaveLM" InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="Label1" runat="server" Text="Duration" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                      
                                            <br />
                                                <div class="row">
                                                  
                                                    <div class="col-md-6">
                                                             <asp:CheckBox ID="chkHalfDay"  Font-Size="12px" runat="server" Font-Bold="true"/>
                                                      <asp:Label ID="Label2" runat="server"   Font-Size="12px" Text="HalfDay" ></asp:Label>

                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:TextBox ID="txtno" runat="server" Width="15%"  Font-Size="12px" CssClass="text-box" TextMode="Number" />
                                                            <asp:CheckBox ID="chkFullDay"  Font-Size="12px" runat="server" Font-Bold="true" />
                                                        <asp:Label ID="Label3" runat="server"  Font-Size="12px"  Text="FullDay" ></asp:Label>

                                                    </div>
                                                </div>
                                               
                                           </div>
                                </div>
                            </div>
                          <br />


                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                  
                                    <div class="mb-2">
                                        <asp:Label ID="lblReason" runat="server" Text="Reason" CssClass="form-label" Font-Size="12px" Font-Bold="true"></asp:Label>

                                        <asp:TextBox ID="txtReason" runat="server" Font-Size="12px" placeholder="Enter Reason" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <br />
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                 
                                  <%--  <div class="row">
                                        <div class="col-md-8 col-lg-8 col-sm-8 col-xs-8">
                                              <div class="mb-2">
                                            <asp:FileUpload ID="FileUpload" runat="server" Text="" CssClass="form-control mdi-file-import" Style="width: 120%" />
                                                  </div>
                                        </div>

                                        <div class="col-md-1 col-lg-1 col-sm-1 col-xs-1">
                                        </div>

                                        <div class="col-md-3 col-lg-3 col-sm-3 col-xs-3">
                                              <div class="mb-2">
                                            <asp:Button ID="Btn_Upload" runat="server" Text="Upload" CssClass="btn btn-primary btn-sm "  />
                                                  </div>
                                        </div>

                                       <%-- <div class="col-md-1 col-lg-1 col-sm-1 col-xs-1">
                                        </div>--%>
                                   <%-- </div>--%>
                                    </div>
                                   
                                </div>
                            <br />
                            <div class="row">
                                <center>
                                    <div class="mb-2">

                                        <asp:Button ID="btnSaveLM" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" OnClick="btnSaveLM_Click" ValidationGroup="SaveLM" />
                                        &nbsp;&nbsp;

                                        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger " ValidationGroup="clearLM" OnClick="btnClear_Click" />
                                    </div>
                                </center>
                            </div>



                        </div>
                    </div>
                </div>

            </div>
        </div>
        <br />
     
      
          
       <br />
       


                    
        </div>
  
</asp:Content>
