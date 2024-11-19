<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="LeaveTally.aspx.cs" Inherits="MatoshreeProject.LeaveTally" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--    <head runat="server">
        <!-- Add your CSS and other head elements here -->
        <link href="your-stylesheet.css" rel="stylesheet" type="text/css" />
    </head>--%>

    <link rel="text/css" href="https://cdn.datatabls.net/responsive/1.0.7/js/dataTabls.responsive.min.css" />
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                        <li class="breadcrumb-item text-muted" aria-current="page" href="LeaveTally.aspx">Leave Tally</li>

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
            <div class="col-md-4">
                <div id="companyData" runat="server" visible="false">

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

            </div>
            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <h5 class="card-title">View Leave Tally</h5>
                            <hr />
                        </div>
                         <br />
                         <asp:GridView ID="GridLeaveAnalysis" runat="server" ScrollBars="Both" CssClass="table  table-hover table-bordered table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%" OnRowDataBound="GridLeaveAnalysis_RowDataBound"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID">
                            <Columns>
                                <asp:TemplateField>

                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true"  Checked="false" OnCheckedChanged="chkAll_CheckedChanged1" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkItem" runat="server" Checked="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>

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

                                <asp:TemplateField HeaderText="Staff_ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStaffID" runat="server" Text='<%# Bind("Staff_ID") %>' Font-Bold="false" Visible="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText="StaffName" SortExpression="Name" HeaderStyle-Font-Size="12px">
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
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemark" runat="server" Text="" TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                             
                                <asp:TemplateField HeaderText="WorkHRs" SortExpression="TotalHours" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalHours" runat="server" Text="" TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
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

                                <asp:TemplateField HeaderText="LeaveType" SortExpression="LeaveType" HeaderStyle-Font-Size="12px" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblLeaveType" runat="server" Text='<%# Bind("LeaveType") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblLeaveType1" runat="server" Text='<%# Bind("LeaveType") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
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
        <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12">
                <center>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-sm btn-success form-control"  Visible="false" OnClick="btnUpdate_Click"   Width="90px" ValidationGroup="Accept" />
                   &nbsp; &nbsp;
                     <asp:Button ID="btnClear" runat="server" Text="Close" OnClick="btnClear_Click" CssClass="btn btn-danger btn-sm"  />
                   
                </center>
            </div>
        </div>
        <br />
    </div>
</asp:Content>
