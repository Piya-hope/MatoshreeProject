<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="LeaveRequest.aspx.cs" Inherits="MatoshreeProject.LeaveRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



    <link rel="text/css" href="https://cdn.datatabls.net/responsive/1.0.7/js/dataTabls.responsive.min.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatabls.net/responsive/1.10.9/js/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatabls.net/responsive/1.0.7/js/dataTabls.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatabls.net/1.10.9/js/dataTabls.bootstrap.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridLeaveRequest = $("#GridLeaveRequest").prepend($("<thead></thead>").append($("#GridLeaveRequest").find("tr:first"))).DataTable(
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
            <div class="row">
                <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                    <%-- BreadCrumbs --%>
                    <h5>Leave Request</h5>
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item">
                                <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                                </a>
                            </li>
                            <li class="breadcrumb-item text-muted" href="#">HRMS</li>
                            <li class="breadcrumb-item text-muted" aria-current="page" href="LeaveRequest.aspx">Leave Request</li>

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



            <%-- Toaster --%>
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
                    <br />
                    <div class="row">
                        <div class="col-md-4 col-sm-4 col-xs-4 col-lg-4">
                            <asp:LinkButton ID="btnLeaveRequest" runat="server" CssClass="btn btn-sm btn-primary  btnmodalPopup" data-bs-toggle="modal" data-bs-target="#AddLeave">Apply Leave Request</asp:LinkButton>
                            <br />
                            <br />

                        </div>
                        <hr />


                    </div>
                    <!-- Modal-->
                    <div class="add" runat="server">
                        <div class="modal fade" id="AddLeave" data-bs-backdrop="static"
                            data-bs-keyboard="false" tabindex="-1" aria-labelledby="scroll-long-inner-modal"
                            aria-hidden="true">
                            <div class="modal-dialog modal-dialog-scrollable" style="width:100%">
                                <div class="modal-content">
                                    <div class="modal-header d-flex align-items-center">
                                        <h4 class="modal-title" id="myLargeModalLabel1"></h4>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">

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
                                                                        <asp:Label ID="lblLeaveID" runat="server" Text="" Visible="false" ForeColor="Black"></asp:Label>
                                                                        <asp:Label ID="lblInitialNumber" runat="server" Text="" Visible="false" ForeColor="Black"></asp:Label>
                                                                        <asp:Label ID="lblstaffid" runat="server" Text="" Visible="false" ForeColor="Black"></asp:Label>
                                                                        <asp:Label ID="lblStaffEmail" runat="server" Text="" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblStaffDesignation" runat="server" Text="" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblEmpName11" runat="server" Text="" Visible="false"></asp:Label>
                                                                        <asp:Label ID="Label1" runat="server" Text="" Font-Size="13.5px" Visible="false" ForeColor="Black"></asp:Label>
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
                                                                        <asp:Label ID="Label2" for="Phone" runat="server" Text="Phone" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label>
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
                                                                        <asp:Label ID="Label3" runat="server" Text="Duration" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>

                                                                        <br />
                                                                        <div class="row">

                                                                            <div class="col-md-6 col-sm-6 col-lg-6  col-xs-4">
                                                                                <asp:CheckBox ID="chkHalfDay" Font-Size="12px" runat="server" Font-Bold="true" />
                                                                                <asp:Label ID="Label4" runat="server" Font-Size="12px" Text="HalfDay"></asp:Label>

                                                                            </div>
                                                                            <div class="col-md-6 col-sm-6 col-lg-6  col-xs-4">

                                                                                <asp:CheckBox ID="chkFullDay" Font-Size="12px" runat="server" OnCheckedChanged="chkFullDay_CheckedChanged" AutoPostBack="true" Font-Bold="true" />
                                                                                <asp:Label ID="Label5" runat="server" Font-Size="12px" Text="FullDay"></asp:Label>
                                                                                <asp:TextBox ID="txtno" runat="server" Font-Size="12px" Width="50%" CssClass="text-form" Visible="false" TextMode="Number" />

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

                                                                <div class="col-md-6 col-sm-6 col-lg-6  col-xs-6">

                                                                    <div class="mb-2">
                                                                        <asp:Label ID="lblAttachment" runat="server" Text="Attachment" CssClass="form-label" Font-Bold="true" Font-Size="12px"></asp:Label>


                                                                        <div class="input-group">
                                                                            <asp:FileUpload ID="FileUpload" runat="server" Text="" CssClass="form-control mdi-file-import" />
                                                                            <asp:Button ID="Btn_Upload" runat="server" Text="Upload" CssClass="btn btn-primary btn-sm " OnClick="Btn_Upload_Click" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <br />

                                                            <div class="row">
                                                                <center>
                                                                    <div class="mb-2">

                                                                        <asp:Button ID="btnSaveLM" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" OnClick="btnSaveLM_Click" ValidationGroup="SaveLM" />
                                                                        &nbsp;&nbsp;

                                                                            <asp:Button ID="btnClear" runat="server" Text="Close" CssClass="btn btn-sm btn-danger " ValidationGroup="clearLM" OnClick="btnClear_Click" />

                                                                    </div>
                                                                </center>

                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>

                                    </div>

                                    <div class="modal-footer">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- ------------------------------------ --%>


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

                </div>

                <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
                    <div class="card">
                        <div class="card-body">
                            <h5>View Leave Request Details</h5>
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

                            <asp:Label ID="lblIDleave" runat="server" Text="" Font-Bold="false" Visible="false" Font-Size="12px"></asp:Label>
                             <div class="row">
                                   <div class="col-md-12 col-sm-12 col-lg-12  col-xs-12">
                            <asp:GridView ID="GridLeaveRequest" runat="server" ScrollBars="Both" CssClass="table  table-hover table-bordered table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridLeaveRequest_RowDataBound">
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
                                    <asp:TemplateField HeaderText="UniqueNo" SortExpression="UniqueNo" HeaderStyle-Font-Size="12px" Visible="false">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblUniqueNo" runat="server" Text='<%# Bind("UniqueNo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblUniqueNo1" runat="server" Text='<%# Bind("UniqueNo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
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
                                    <asp:TemplateField HeaderText="Attachment" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                        <ItemTemplate>
                                         <asp:LinkButton ID="btnfileAttachment" runat="server" OnClick="ShowDetails_Click" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-pin"></i></asp:LinkButton>
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
                     


                       
                             <div id="myModal" class="modal"  style="display: none; opacity: 0.8; justify-content:center; align-content:center; background-color: rgba(0, 0, 0, 0.5);" >
                                <div class="modal-dialog">
                                
                                    <div class="modal-content">
                                        <div class="modal-header">
                                        
                                            <h5 class="modal-title">Attachment</h5>
                                             <hr />
                                        </div>
                                        <div class="modal-body">
                                                       
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                                            <asp:Label ID="lbdLeaveMID" runat="server" Text="" Font-Size="12px" Font-Bold="false" Visible="true"></asp:Label>

                                                            <asp:GridView ID="GridLeaveRequestFile" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                                ClientIDMode="Static" ShowHeader="false" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                                                                <Columns>
                                                                    <asp:TemplateField Visible="false">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblLeaveFileId" runat="server" Text="FileName" Font-Size="12px" Font-Bold="false" Visible="false"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblfileid" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

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
                                                                            <asp:LinkButton ID="btnDownload" runat="server" CausesValidation="false" CommandName="Delete" OnClick="btnDownload_Click" CssClass="btn btn-sm btn-success " Visible="false"><i class="ti ti-download" ></i></asp:LinkButton>
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
                                        <div class="modal-footer">

                                              <button type="button" id="btnCloseModalFooter" class="btn btn-danger btn-sm">Close</button>
                                        </div>
                                    </div>
                                </div>
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
