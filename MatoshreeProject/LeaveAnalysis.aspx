<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="LeaveAnalysis.aspx.cs" Inherits="MatoshreeProject.LeaveAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--<head runat="server">
        <!-- Add your CSS and other head elements here -->
        <link href="your-stylesheet.css" rel="stylesheet" type="text/css" />
    </head>--%>

    <link rel="text/css" href="https://cdn.datatabls.net/responsive/1.0.7/js/dataTabls.responsive.min.css" />
    <%--   <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>--%>
    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />--%>
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatabls.net/responsive/1.10.9/js/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatabls.net/responsive/1.0.7/js/dataTabls.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatabls.net/1.10.9/js/dataTabls.bootstrap.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var GridLeaveAnalysis = $("#GridLeaveAnalysis").prepend($("<thead></thead>").append($("#GridLeaveAnalysis").find("tr:first"))).DataTable(
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
  <%--  <script type='text/javascript'>
        function openModal() {
            $('[id*=myModal]').modal('show');
        }
    </script>--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <%--  <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>--%>
        <script type="text/javascript">
            function openModal() {
                document.getElementById("myModal").style.display = "block";
            }

            function closeModal() {
                document.getElementById("myModal").style.display = "none";
            }


</script>
    <script>
        document.addEventListener('DOMContentLoaded', function () {
            var closeModalButton = document.getElementById('btnCloseModalFooter');
            var modal = document.getElementById('myModal');

            closeModalButton.addEventListener('click', function () {
                modal.style.display = 'none';
            });
        });
</script>
    <div class="container-fluid">

        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <%-- BreadCrumbs --%>
                <%--<h5>Leave Analysis</h5>--%>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item text-muted" href="#">HRMS</li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="LeaveAnalysis.aspx">Leave Analysis</li>

                    </ol>
                </nav>

                <%-- BreadCrumbs --%>
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

        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12 col-xl-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <h5 class="card-title">Leave Analysis</h5>
                            <hr />
                        </div>
                        <br />

                        <!-- Modal -->



                        <div class="row">
                            <div class="col-md-1">
                                <asp:Label ID="lblStaffName" Text="Staff" runat="server" CssClass="form-label" Font-Bold="true"></asp:Label>

                            </div>

                            <div class="col-md-3 col-sm-3 col-lg-3 col-xl-3">
                                <asp:DropDownList ID="ddlStaffName" CssClass="form-control form-select" runat="server" OnSelectedIndexChanged="ddlStaffName_SelectedIndexChanged" AutoPostBack="false"></asp:DropDownList>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="lblMonth" Text="Month" runat="server" CssClass="form-label" Font-Bold="true"></asp:Label>

                            </div>
                            <div class="col-md-3 col-sm-3 col-lg-3 col-xl-3">

                                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control form-select" Placeholder="Select Expenses Type">
                                    <asp:ListItem Value="0" Text="Select Month"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="January"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="February"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="March"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="April"></asp:ListItem>
                                    <asp:ListItem Value="5" Text="May"></asp:ListItem>
                                    <asp:ListItem Value="6" Text="June"></asp:ListItem>
                                    <asp:ListItem Value="7" Text="July"></asp:ListItem>
                                    <asp:ListItem Value="8" Text="August"></asp:ListItem>
                                    <asp:ListItem Value="9" Text="September"></asp:ListItem>
                                    <asp:ListItem Value="10" Text="October"></asp:ListItem>
                                    <asp:ListItem Value="11" Text="November"></asp:ListItem>
                                    <asp:ListItem Value="12" Text="December"></asp:ListItem>
                                </asp:DropDownList>

                            </div>

                            <div class="col-md-1">
                                <asp:Label ID="lblYear" Text="Year" runat="server" CssClass="form-label" Font-Bold="true"></asp:Label>

                            </div>
                            <div class="col-md-3 col-sm-3 col-lg-3 col-xl-3">
                                <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control form-select" Placeholder="Select Year">
                                </asp:DropDownList>
                            </div>

                        </div>
                        <br />


                        <br />
                        <div class="row">
                            <div class="col-md-4"></div>

                            <div class="col-md-1">
                                <asp:Button ID="btnSearchRerort" runat="server" Text="View Report" CssClass="btn btn-primary mr-4 btn-sm " OnClick="btnSearchRerort_Click" />
                            </div>
                            &nbsp; &nbsp; &nbsp; &nbsp;
                            <div class="col-md-1">
                                <div class="bd-example">
                                    <div class="btn-group">
                                        <button class="btn btn-sm btn-success  dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                        <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                        <div class="dropdown-menu">
                                            <asp:LinkButton ID="lnkbtnExcel" Text="Excel" runat="server" OnClick="lnkbtnExcel_Click" CssClass="dropdown-item"></asp:LinkButton>
                                            <asp:LinkButton ID="linkbtnPDF" runat="server" Text="PDF" OnClick="linkbtnPDF_Click" CssClass="dropdown-item"></asp:LinkButton>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="col-md-1">
                                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CssClass="btn btn-danger btn-sm" />
                            </div>

                            <div class="col-md-4">
                                <!------PDF code--------->

                                <div id="companuData" runat="server" visible="false">
                                    <asp:Label ID="lbladdCompany11" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lbladdress11" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblcompanyaddCity1" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblcompanyaddState1" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblcompanyaddCountry1" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblphoneNo1" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblVatNo1" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblGSTNo1A" runat="server" Text=""></asp:Label>
                                    <asp:Image ID="Image1" Text="" runat="server" Height="80px" Width="130px" />


                                    <asp:Label ID="lblshiftstaffid" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblNameShift11" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblShiftID" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblshiftHours" runat="server" Text=""></asp:Label>


                                    <asp:Label ID="lblLeabveMarkID" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblMarkName" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblMarkCount" runat="server" Text=""></asp:Label>

                                    <asp:Label ID="lblLeavename" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                </div>


                                <br />
                                <!------PDF code--------->

                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12 col-xl-12">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">View Leave Analysis</h5>
                        <hr />

                        <asp:GridView ID="GridLeaveAnalysis" runat="server" ScrollBars="Both" CssClass="table  table-hover table-bordered table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%" OnRowDataBound="GridLeaveAnalysis_RowDataBound"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID">
                            <Columns>
                                <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>

                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Visible="true" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>

                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Visible="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="StaffID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStaffID" runat="server" Text='<%# Bind("Staff_ID") %>' Font-Bold="false" Visible="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="StaffName" SortExpression="StaffName" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblStaffName" runat="server" Text='<%# Bind("StaffName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>

                                        <asp:Label ID="lblStaffName1" runat="server" Text='<%# Bind("StaffName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Designation" SortExpression="Role" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblRole" runat="server" Text='<%# Bind("Role") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>

                                        <asp:Label ID="lblRole1" runat="server" Text='<%# Bind("Role") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="InTime" SortExpression="InTime" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblInTime" runat="server" Text='<%# Bind("InTime") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblInTime1" runat="server" Text='<%# Bind("InTime") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="OutTime" SortExpression="OutTime" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblOutTime" runat="server" Text='<%# Bind("OutTime") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblOutTime1" runat="server" Text='<%# Bind("OutTime") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Remark" SortExpression="Remark" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblRemark1" runat="server" Text='<%# Bind("Remark") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="WorkHRs" SortExpression="TotalHours" HeaderStyle-Font-Size="12px">

                                    <EditItemTemplate>
                                        <asp:Label ID="lblTotalHours1" runat="server" Text='<%# Bind("TotalHRS") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalHours" runat="server" Text='<%# Bind("TotalHRS") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ShiftName" SortExpression="ShiftName" HeaderStyle-Font-Size="12px" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblShiftName" runat="server" Text='<%# Bind("ShiftName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblShiftName1" runat="server" Text='<%# Bind("ShiftName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="LateTime" SortExpression="LateTime" HeaderStyle-Font-Size="12px" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblLateTime" runat="server" Text='<%# Bind("LateTime") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblLateTime1" runat="server" Text='<%# Bind("LateTime") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Duration" SortExpression="Duration" HeaderStyle-Font-Size="12px" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblDuration" runat="server" Text='<%# Bind("Duration") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDuration1" runat="server" Text='<%# Bind("Duration") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField SortExpression="Status" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus1" runat="server" Text='<%#Bind("Status") %>' Visible="false" Font-Bold="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="view" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnview" runat="server" OnClick="btnview_Click" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-eye"></i></asp:LinkButton>
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
                           <div id="myModal" class="modal"  style="display: none; opacity: 0.8; justify-content:center; align-content:center; background-color: rgba(0, 0, 0, 0.5);">
                         <div class="modal-dialog modal-lg">
                             
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title">Monthly Record</h4>
                                      
                                    </div>
                                    <div class="modal-body">
                                        <div class="container-fluid">
                                         
                                            <div class="row">
                                                   <div class="col-md-12 col-sm-12 col-lg-12 mb-12">
                                                <asp:Label ID="lblsf" runat="server" CssClass="text-dark" Text="StaffName:" Font-Size="16px" Font-Bold="false"></asp:Label>
                                                  <asp:Label ID="lblempname" runat="server" CssClass="text-dark" Text="" Font-Size="16px" Font-Bold="false"></asp:Label>
                                              </div>
                                                    <!-- Attendance Count -->
                                                <div class="col-md-3 col-sm-6 col-lg-3 mb-3">
                                                    <div class="card border-warning">
                                                        <div class="card-body text-center">
                                                            <h2 class="fs-7">
                                                                <asp:Label ID="lblAttendanceCount" runat="server" CssClass="text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                                            </h2>
                                                            <h6 class="fw-medium text-info mb-0">
                                                                <asp:Label ID="lblAttendance" runat="server" Text="Attendance" CssClass="text-warning" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                            </h6>
                                                            <span class="text-warning display-6">
                                                                <iconify-icon icon="fluent-mdl2:leave-user" class="aside-icon"></iconify-icon>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                                
                                                <!-- Sick Leave Count -->
                                                <div class="col-md-2 col-sm-6 col-lg-2 mb-3">
                                                    <div class="card border-success">
                                                        <div class="card-body text-center">
                                                            <h2 class="fs-7">
                                                                <asp:Label ID="lblSickLeaveCount" CssClass="text-dark" runat="server" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                                            </h2>
                                                            <h6 class="fw-medium text-success mb-0">
                                                                <asp:Label ID="lblTotalLeave" runat="server" Text="Sick" CssClass="text-success" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                            </h6>
                                                            <span class="text-success display-6">
                                                                <iconify-icon icon="fluent-mdl2:leave-user" class="aside-icon"></iconify-icon>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Casual Leave Count -->
                                                <div class="col-md-2 col-sm-6 col-lg-2 mb-3">
                                                    <div class="card border-info">
                                                        <div class="card-body text-center">
                                                            <h2 class="fs-7">
                                                                <asp:Label ID="lblCasualLeaveCount" runat="server" CssClass="text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                                            </h2>
                                                            <h6 class="fw-medium text-info mb-0">
                                                                <asp:Label ID="lblCasualLeave" runat="server" Text="Casual" CssClass="text-info" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                            </h6>
                                                            <span class="text-info display-6">
                                                                <iconify-icon icon="fluent-mdl2:leave-user" class="aside-icon"></iconify-icon>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Paid Leave Count -->
                                                <div class="col-md-2 col-sm-6 col-lg-2 mb-3">
                                                    <div class="card border-success">
                                                        <div class="card-body text-center">
                                                            <h2 class="fs-7">
                                                                <asp:Label ID="lblPaidCount" runat="server" CssClass="text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                                            </h2>
                                                            <h6 class="fw-medium text-success mb-0">
                                                                <asp:Label ID="lblPaid" runat="server" Text="Paid" CssClass="text-success" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                            </h6>
                                                            <span class="text-success display-6">
                                                                <iconify-icon icon="fluent-mdl2:leave-user" class="aside-icon"></iconify-icon>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Unpaid Leave Count -->
                                                <div class="col-md-3 col-sm-6 col-lg-3 mb-3">
                                                    <div class="card border-danger">
                                                        <div class="card-body text-center">
                                                            <h2 class="fs-7">
                                                                <asp:Label ID="lblUnpaidCount" runat="server" CssClass="text-dark" Text="" Font-Size="16px" Font-Bold="true"></asp:Label>
                                                            </h2>
                                                            <h6 class="fw-medium text-danger mb-0">
                                                                <asp:Label ID="lblUnpaid" runat="server" Text="Unpaid" CssClass="text-danger" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                            </h6>
                                                            <span class="text-danger display-6">
                                                                <iconify-icon icon="fluent-mdl2:leave-user" class="aside-icon"></iconify-icon>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" id="btnCloseModalFooter" class="btn btn-danger btn-sm" data-dismiss="modal">Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                  </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
