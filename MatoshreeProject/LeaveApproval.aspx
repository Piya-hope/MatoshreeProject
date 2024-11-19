<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="LeaveApproval.aspx.cs" Inherits="MatoshreeProject.LeaveApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="text/css" href="https://cdn.datatabls.net/responsive/1.0.7/js/dataTabls.responsive.min.css" />
<script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script type="text/javascript" src="https://cdn.datatabls.net/responsive/1.10.9/js/jquery.min.js"></script>
<script type="text/javascript" src="https://cdn.datatabls.net/responsive/1.0.7/js/dataTabls.responsive.min.js"></script>
<script type="text/javascript" src="https://cdn.datatabls.net/1.10.9/js/dataTabls.bootstrap.min.js"></script>
<script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        var GridLeaveApproval = $("#GridLeaveApproval").prepend($("<thead></thead>").append($("#GridLeaveApproval").find("tr:first"))).DataTable(
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
        <%-- BreadCrumbs --%>
      
        <%-- BreadCrumbs --%>
          <div class="row">
      <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
          <br />
          <div class="row">
              <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                  <h5>Leave Approval</h5>
                  <nav aria-label="breadcrumb">
                      <ol class="breadcrumb">
                          <li class="breadcrumb-item">
                              <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                              </a>
                          </li>
                          <li class="breadcrumb-item text-muted" href="#">HRMS</li>
                          <li class="breadcrumb-item text-muted" aria-current="page" href="LeaveApproval.aspx">Leave Approval</li>

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
          <hr />

      </div>
      </div>
        <div class="row">
            <h5>Leave Approval Summary</h5>
            <div class="col-md-3 col-sm-3 col-xs-3 col-lg-3">
                <div class="card border-bottom border-warning">
                    <div class="card-body">
                        <div class="d-flex align-items-center">
                            <div>
                                <h2 class="fs-7">
                                    <asp:Label ID="lblTotalApplycount" CssClass="text-center text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                </h2>
                                <h6 class="fw-medium text-warning mb-0">
                                    <asp:Label ID="lblTotalApply" runat="server" Text="TotalApply" CssClass="text-warning" Font-Size="12px" Font-Bold="true"></asp:Label>
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
            <div class="col-md-3 col-sm-3 col-xs-3 col-lg-3">


                <div class="card border-bottom border-success">
                    <div class="card-body">
                        <div class="d-flex align-items-center">
                            <div>
                                <h2 class="fs-7">
                                    <asp:Label ID="lblAcceptCount" runat="server" CssClass="text-center text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                </h2>
                                <h6 class="fw-medium text-success mb-0">
                                    <asp:Label ID="lblAccepLeave" runat="server" Text="Accept" CssClass="text-success" Font-Size="12px" Font-Bold="true"></asp:Label>
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
                                    <asp:Label ID="lblRejectCount" runat="server" CssClass="text-center  text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                </h2>
                                <h6 class="fw-medium text-danger mb-0">
                                    <asp:Label ID="lblRejectLeave" runat="server" Text="Reject" CssClass="text-danger" Font-Size="12px" Font-Bold="true"></asp:Label>
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
         

            <div class="col-md-3 col-sm-3 col-xs-3 col-lg-3">

                <div class="card border-bottom border-info">
                    <div class="card-body">
                        <div class="d-flex align-items-center">
                            <div>
                                <h2 class="fs-7">
                                    <asp:Label ID="lblPendingLeaveCount" runat="server" CssClass="text-center  text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                </h2>
                                <h6 class="fw-medium text-info mb-0">
                                    <asp:Label ID="lblPendingLeave" runat="server" Text="Pending" CssClass="text-info" Font-Size="12px" Font-Bold="true"></asp:Label>
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

        </div>

        <%-- Toaster --%>
          
      
            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <h5>View Leave Approval Details</h5>
                        <hr />

                        <div class="row">
                            <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                                <div class="bd-example">
                                    <div class="btn-group">
                                        <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                        <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                        <div class="dropdown-menu">
                                            <asp:LinkButton ID="lnkbtnExcel" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="lnkbtnExcel_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="linkbtnPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnPDF_Click"></asp:LinkButton>

                                        </div>
                                    </div>
                                    <asp:Button ID="BTN_Visibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="BTN_Visibility_Click" />

                                    <asp:Button ID="Btn_Reload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="Btn_Reload_Click" />


                                </div>
                            </div>
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
                                <asp:Label ID="lblphone" runat="server" Text="Phone:" CssClass="" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblphoneNo1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblvat" runat="server" Text="VAT NO:" CssClass="" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblVatNo1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" CssClass="" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblGSTNo1A" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                            </div>
                        </div>

                        <br />
                        <br />


                        <asp:GridView ID="GridLeaveApproval" runat="server" ScrollBars="Both" CssClass="table  table-hover table-bordered table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridLeaveApproval_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="StaffName" SortExpression="Name" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblStaffName" runat="server" Text='<%# Bind("Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStaffName1" runat="server" Text='<%# Bind("Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Department" SortExpression="Department" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblDepartment" runat="server" Text='<%# Bind("Department") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDepartment1" runat="server" Text='<%# Bind("Department") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="StartDate" SortExpression="StartDate" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblStartDate" runat="server" Text='<%# Bind("StartDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStartDate1" runat="server" Text='<%# Bind("StartDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="EndDate" SortExpression="EndDate" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblEndDate" runat="server" Text='<%# Bind("EndDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEndDate1" runat="server" Text='<%# Bind("EndDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="LeaveType" SortExpression="LeaveType" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblLeaveType" runat="server" Text='<%# Bind("LeaveType") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblLeaveType1" runat="server" Text='<%# Bind("LeaveType") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Reason" SortExpression="Reason" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblReason" runat="server" Text='<%# Bind("Reason") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblReason1" runat="server" Text='<%# Bind("Reason") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ApprovalStatus" SortExpression="ApprovalStatus" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblApprovalStatus" runat="server" Text='<%# Bind("ApprovalStatus") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblApprovalStatus1" runat="server" Text='<%# Bind("ApprovalStatus") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remark" SortExpression="RejectedReason" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblRejectedReason" runat="server" Text='<%# Bind("RejectedReason") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRejectedReason1" runat="server" Text='<%# Bind("RejectedReason") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField SortExpression="Status" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status") %>' Visible="false" Font-Bold="false"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus1" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnViewLeaveMangement" runat="server" OnClick="btnViewLeaveMangement_Click" CssClass="btn btn-sm btn-outline-info "><i class="ti ti-eye"></i></asp:LinkButton>
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
            </div>
        </div>
        </div>


</asp:Content>
