<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="ViewLeaveManagement.aspx.cs" Inherits="MatoshreeProject.ViewLeaveManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
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
                        <li class="breadcrumb-item text-muted" aria-current="page" href="ViewLeaveManagement.aspx">View Leave Management</li>
                    </ol>
                </nav>
            </div>

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
                            <asp:Label ID="lblmsgdelte" runat="server" Text="" Font-Size="13.5px" ForeColor="Black"></asp:Label>
                        </div>
                        <button type="button" class="btn-close me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
                    </div>
                </div>
            </div>
        </div>
        <%-- Toaster --%>


        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12  col-xs-12">
                <div id="ExpDiv" runat="server" visible="true">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title" style="color: blue">View  Leave Management</h5>
                            <hr />
                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    <div class="mb-2">
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
                                        <asp:Label ID="lblDepartment" runat="server" Text="Department" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
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
                                        <asp:Label ID="lblStartDate" runat="server" Text="Start Date" CssClass="form-label" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <asp:TextBox ID="txtStartDate" type="date" CssClass="form-control" Font-Size="12px" Style="display: inline-block;" runat="server" placeholder="Enter Start Date"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredStartDate" runat="server" Font-Size="12px" ErrorMessage="Enter Start Date" ControlToValidate="txtStartDate" ForeColor="Red" Font-Bold="false" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblEndDate" runat="server" Text="End Date" CssClass="form-label" Font-Size="12px" Font-Bold="true"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <asp:TextBox ID="txtEndDate" type="date" CssClass="form-control" Font-Size="12px" Style="display: inline-block;" runat="server" placeholder="Enter End Date"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldEnd2" runat="server" Font-Size="12px" ErrorMessage="Enter End Date" ControlToValidate="txtEndDate" ForeColor="Red" Font-Bold="false" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblLeaveType" runat="server" Text="Leave Type" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <asp:DropDownList ID="ddlLeaveType" runat="server" Font-Size="12px" CssClass="form-control form-select" Placeholder="Select LeaveType">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">
                                    <div class="mb-2">
                                        <asp:Label ID="lblReason" runat="server" Text="Reason" CssClass="form-label" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        <asp:TextBox ID="txtReason" runat="server" Font-Size="12px" TextMode="MultiLine" placeholder="Enter Designation" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-lg-12  col-xs-12">
                                    <div class="mb-2">
                                        <asp:Label ID="Label1" runat="server" Text="Reason(Accept/Reject)" CssClass="form-label" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        <asp:TextBox ID="txtResonReject" runat="server" Font-Size="12px" TextMode="MultiLine" placeholder="Enter Reason" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldDepartment" runat="server" Font-Size="12px" ErrorMessage="Enter Reason" ControlToValidate="txtResonReject" ForeColor="Red" Font-Bold="false" ValidationGroup="btnRejectLM"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                            </div>
                            <br />



                            <div class="row">
                                <center>
                                    <div class="mb-2">
                                        <asp:Button ID="btnAcceptLM" runat="server" Text="Accept" CssClass="btn btn-success btn-sm " OnClick="btnAcceptLM_Click" />
                                        &nbsp;&nbsp;
                                      <asp:Button ID="btnRejectLM" runat="server" Text="Reject" CssClass="btn btn-danger  btn-sm" OnClick="btnRejectLM_Click" ValidationGroup="btnRejectLM" />

                                    </div>
                                </center>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
