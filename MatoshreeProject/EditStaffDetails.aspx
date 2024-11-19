<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="EditStaffDetails.aspx.cs" Inherits="MatoshreeProject.EditStaffDetails" EnableEventValidation="false" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridStaffMembers = $("#GridStaffMembers").prepend($("<thead></thead>").append($("#GridStaffMembers").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

           

            var GridViewNote = $("#GridViewNote").prepend($("<thead></thead>").append($("#GridViewNote").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridStaffLogIn = $("#GridStaffLogIn").prepend($("<thead></thead>").append($("#GridStaffLogIn").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,              
                });

            var GridStaffProject = $("#GridStaffProject").prepend($("<thead></thead>").append($("#GridStaffProject").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,

                    "columnDefs": [
                        { orderable: false, targets: 0 }, // Disable ordering on column 0 (checkbox)
                       
                    ]
                });

        });
    </script>


    <script> 
        tinymce.init({
            // selector: 'textarea',
            //selector : "textarea.Editor"
            selector: ".EditorNote",
            //theme: "modern",
            //plugins: ["lists link image charmap print preview hr anchor pagebreak"],

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="font-weight-medium mb-0">Edit Staff</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item"><a class="text-muted text-decoration-none" href="Setup_StaffDetails.aspx">Staff Details</a></li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="#">Edit Staff</li>
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

        <div id="div_log" runat="server" visible="false">
            <div class="card">
                <div class="card-body">
                    <h5>Staff Log Timesheet</h5>
                    <hr />
                    <div class="row container-fluid">
                        <div class="col-sm-3 col-md-2" style="width: 220px;">
                            <div class="card">
                                <div class="card-body border" style="height: 97px;">
                                    <h6 class="font-bold  mb-0 text-center">00:00</h6>
                                    <div class="col-md-12 mt-3">
                                        <h6 class="text-center text-danger">Total Logged Time</h6>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-3 col-md-2" style="width: 220px; height: 119px">
                            <div class="card">
                                <div class="card-body border" style="height: 97px;">
                                    <h6 class="font-bold  mb-0 text-center">00:00 </h6>
                                    <div class="col-md-12 mt-3">
                                        <h6 class="text-center text-info" style="color: forestgreen; height: 30px">Last Month Logged Time</h6>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-3 col-md-2" style="width: 220px;">
                            <div class="card">
                                <div class="card-body border" style="height: 97px;">
                                    <h6 class="font-bold  mb-0 text-center">00:00</h6>
                                    <div class="col-md-12 mt-3">
                                        <h6 class="text-center" style="color: deepskyblue">This Month Logged Time</h6>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-3 col-md-2" style="width: 220px;">
                            <div class="card">
                                <div class="card-body border" style="height: 97px;">
                                    <h6 class="font-bold  mb-0 text-center">00:00</h6>
                                    <div class="col-md-12 mt-3">
                                        <h6 class="text-center" style="color: forestgreen">Last Week Logged Tim</h6>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-3 col-md-2" style="width: 220px;">
                            <div class="card">
                                <div class="card-body border" style="height: 97px;">
                                    <h6 class="font-bold  mb-0 text-center">00:00</h6>
                                    <div class="col-md-12 mt-3">
                                        <h6 class="text-center" style="color: deepskyblue">This Week Logged Time</h6>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-2" style="width: 220px;">
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-5 col-sm-5 col-lg-5">
                <div class="card">
                    <div class="card-body">
                        <div>
                            <asp:Label ID="lblID" runat="server" Text="Staff ID:" Font-Bold="false" Font-Size="12px" ForeColor="Black" Visible="false"></asp:Label>
                            <asp:Label ID="lblStaffID" runat="server" Text="" Font-Bold="false" Font-Size="12px" ForeColor="Blue" Visible="false"></asp:Label>

                            <asp:Label ID="lblEmpNameEmail11" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="lblEmpName11" runat="server" Text="" Visible="false"></asp:Label>

                        </div>

                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link active" data-bs-toggle="tab" href="#home" role="tab"><span class="hidden-sm-up"></span>
                                    <span class="hidden-sm-down  font-bold">Profile</span></a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" data-bs-toggle="tab" href="#profile" role="tab"><span class="hidden-sm-up"></span>
                                    <span class="hidden-sm-down  font-bold">Permission</span></a>
                            </li>

                        </ul>
                        <br />
                        <!-- Tab panes -->
                        <!-- home -->
                        <div class="tab-content tabcontent-border">
                            <div class="tab-pane active" id="home" role="tabpanel">
                                <div class="p-20">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <asp:Label ID="Label1" runat="server" for="formFile" class="form-label" Text="Profile Image" CssClass="form-label"></asp:Label>
                                            <div class="mb-2">
                                                <div class="input-group">
                                                    <asp:FileUpload ID="FileUpload1" runat="server" name="fileupload" class="form-control" />
                                                    <asp:Button ID="btnImgUpload" runat="server" Text="Upload" CssClass="btn btn-sm btn-primary" OnClick="btnImgUpload_Click" />
                                                </div>
                                                <br />
                                                <asp:Image ID="Image1" runat="server" Height="100" Width="233" />
                                            </div>
                                        </div>
                                        <br />
                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:RadioButtonList ID="RadioSelectedStaff" runat="server" TabIndex="24" Font-Size="12px">
                                                    <asp:ListItem Text="Not Staff Member" Value="1" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Staff Member" Value="0"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lbl_First_Name" runat="server" Text="First Name" CssClass="form-label"></asp:Label>
                                                &nbsp;<span id="ct6_YourControl1" style="color: red;">* </span>
                                                <asp:TextBox ID="txt_First_Name" runat="server" Placeholder="Enter the first name" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="Subject_RequiredFieldValidator" runat="server" ErrorMessage="Enter First Name" Display="Dynamic" ControlToValidate="txt_First_Name" ForeColor="Red" ValidationGroup="Save" Font-Size="12px"></asp:RequiredFieldValidator>

                                            </div>
                                        </div>


                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lbl_Last_Name" runat="server" Text="Last Name" CssClass="form-label">
                                                </asp:Label>
                                                &nbsp;<span id="ct6_YourControl3" style="color: red;">* </span>
                                                <asp:TextBox ID="txt_Last_Name" runat="server" Placeholder="Enter the last name" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="Related_RequiredFieldValidator" runat="server" ErrorMessage="Enter Last Name" Display="Dynamic" ControlToValidate="txt_Last_Name" ForeColor="Red" ValidationGroup="Save" Font-Size="12px"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="Label2" runat="server" Text="Email" CssClass="form-label">
                                                </asp:Label>
                                                &nbsp;<span id="ct6_Email" style="color: red;">* </span>
                                                <asp:TextBox ID="txt_Email" runat="server" Placeholder="Enter the Email" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter E-mail" Display="Dynamic" ControlToValidate="txt_Email" ForeColor="Red" ValidationGroup="Save" Font-Size="12px"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Email address!" ControlToValidate="txt_Email" Display="Dynamic" ForeColor="Red" ValidationGroup="Save" ValidationExpression="^\S+@\S+$" Font-Size="12px"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>

                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="Label3" runat="server" Text="Phone" CssClass="form-label">
                                                </asp:Label>
                                                &nbsp;<span style="color: red;">* </span>
                                                <asp:TextBox ID="txt_Phone" runat="server" Placeholder="Enter the phone " CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfv_Phone" runat="server" Display="Dynamic" ControlToValidate="txt_Phone" ErrorMessage="Enter 10 digit Phone Number.." ForeColor="Red" ValidationGroup="Save" Font-Size="12px"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="Regulexphone" runat="server" ControlToValidate="txt_Phone" ErrorMessage="Phone Number Invalid." ForeColor="Red" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$" ValidationGroup="Save" Font-Size="12px"></asp:RegularExpressionValidator>

                                            </div>
                                        </div>

                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <iconify-icon icon="jam:facebook-square"></iconify-icon>

                                                <asp:Label ID="lblFacebook" runat="server" Text="Facebook" CssClass="form-label">
                                                </asp:Label>
                                                <asp:TextBox ID="txt_Facebook" runat="server" Placeholder="Enter Facebook" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <iconify-icon icon="bi:linkedin"></iconify-icon>
                                                <asp:Label ID="Label5" runat="server" Text="LinkedIn" CssClass="form-label">
                                                </asp:Label>
                                                <asp:TextBox ID="txt_LinkedIn" runat="server" Placeholder="Enter LinkedIn" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <iconify-icon icon="teenyicons:skype-outline"></iconify-icon>
                                                <asp:Label ID="Label6" runat="server" Text="Skype" CssClass="form-label">
                                                </asp:Label>
                                                <asp:TextBox ID="txt_Skype" runat="server" Placeholder="Enter Skype" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="Label8" runat="server" Text="Default Language" CssClass="form-label"></asp:Label>
                                                <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="form-control form-select">
                                                    <asp:ListItem>Select Language</asp:ListItem>
                                                    <asp:ListItem>English</asp:ListItem>
                                                    <asp:ListItem>Marathi</asp:ListItem>
                                                    <asp:ListItem>Hindi</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <iconify-icon icon="bi:question-circle" data-toggle="tooltip" data-title="If empty default email signature from settings will be used" data-original-title="" title=""></iconify-icon>
                                                <asp:Label ID="Label9" runat="server" Text="Email Signature" CssClass="form-label">
                                                </asp:Label>
                                                <asp:TextBox ID="txt_Email_Signature" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="Label10" runat="server" Text="Direction" CssClass="form-label"></asp:Label>
                                                <asp:DropDownList ID="ddlDirection" runat="server" CssClass="form-control form-select">
                                                    <asp:ListItem>System Default</asp:ListItem>
                                                    <asp:ListItem>LTR</asp:ListItem>
                                                    <asp:ListItem>RTL</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lblDeptStaffName" runat="server" Text="Department" CssClass="form-label"></asp:Label>
                                                &nbsp;<span style="color: red;">* </span>
                                                <br />
                                                <asp:DropDownList ID="ddlDeptStaffName" runat="server" CssClass="form-control form-select" Placeholder="Select Department">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RFVddlDeptStaffName" runat="server" ControlToValidate="ddlDeptStaffName" ErrorMessage="Select Department"
                                                    Display="Dynamic" ForeColor="Red" ValidationGroup="Save" InitialValue="0" Font-Size="12px"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lblShift" runat="server" Text="Shift" CssClass="form-label"></asp:Label>
                                                &nbsp;<span style="color: red;">* </span>
                                                <br />
                                                <asp:DropDownList ID="ddlShift" runat="server" CssClass="form-control form-select" Placeholder="Select Shift">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredShift" runat="server" ControlToValidate="ddlShift" ErrorMessage="Select Shift"
                                                    Display="Dynamic" ForeColor="Red" ValidationGroup="Save" InitialValue="0" Font-Size="12px"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <div class="mb-2">
                                                <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="form-label"></asp:Label>&nbsp;<span id="ctl_YourContro112" style="color: red;">*</span>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txt_Password" runat="server" CssClass="form-control" aria-describedby="basic-addon2 basic-addon3">
                                                    </asp:TextBox>

                                                    <asp:LinkButton ID="LinkBtnEyesPassword" runat="server" ForeColor="Black" CssClass="btn btn-sm btn-purple"><i class="ti ti-eye"></i></asp:LinkButton>

                                                    <asp:LinkButton ID="LinkbtnResetPassword" runat="server" ForeColor="Black" ValidationGroup="String" CssClass="btn btn-sm btn-secondary" OnClick="LinkbtnResetPassword_Click"><iconify-icon icon="mdi:circle-arrows"></iconify-icon></asp:LinkButton>
                                                </div>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Password" ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Password." ValidationGroup="Save" />

                                            </div>
                                        </div>

                                        <div class="col-md-12 col-sm-12 col-lg-12">
                                            <asp:CheckBox ID="CheckBoxSendEmail" runat="server" Text="If you want send updated email" CssClass=" font-bold" AutoPostBack="true" OnCheckedChanged="CheckBoxSendEmail_CheckedChanged" />
                                        </div>


                                        <div class="col-md-12 col-sm-12 col-ld-12">
                                            <asp:TextBox ID="txtEmailDescription" runat="server" TextMode="MultiLine" class="EditorNote" Visible="false"></asp:TextBox>
                                        </div>

                                        <br />
                                        <br />
                                        <div class="col-md-12 col-sm-12 col-ld-12">
                                            <div class="mb-2">
                                                <asp:Label ID="LabelStatus" runat="server" Text="Status" CssClass="form-label"></asp:Label>
                                                <asp:RadioButtonList ID="RadiobtnStatusStaff" runat="server" TabIndex="24" Font-Size="12px">
                                                    <asp:ListItem Text="Active" Value="1" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <!--profile-->
                            <div class="tab-pane p-20" id="profile" role="tabpanel">
                                <div class="p-20">
                                    <h5>Permissions</h5>
                                    <hr />
                                    <asp:UpdatePanel ID="UpdatePanelddlState" runat="server">
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="mb-2">
                                                    <asp:Label ID="Label11" runat="server" Text="Role" CssClass="form-label"></asp:Label>
                                                    &nbsp;<span style="color: red;">* </span>
                                                    <asp:DropDownList ID="ddlRoleType" runat="server" CssClass="form-control form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlRoleType_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <hr />

                                            <div class="row">
                                                <div class="col-md-12 col-sm-12 col-lg-12">
                                                    <div class="mb-2">
                                                        <div class="table-responsive" style="height: 100%">
                                                            <asp:GridView ID="GridRole" AutoGenerateColumns="false" CssClass="table table-bordered table-responsive" runat="server" Style="width: 100%" OnRowDataBound="GridRole_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblID" Text='<%#Eval("PageID")%>' runat="server" Visible="false" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Features" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="12px">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblWebPage" Text='<%#Eval("WebPageName")%>' runat="server" Font-Size="12px" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Capabilities" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="12px">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="ChkGlobal" runat="server" Text="View(Global)" Checked='<%#Eval("GlobalView")%>' AutoPostBack="true" OnCheckedChanged="ChkGlobal_CheckedChanged" CssClass="form-group" Font-Size="12px" />
                                                                            <br />
                                                                            <asp:CheckBox ID="ChkView" runat="server" Text="View(Own)" Checked='<%#Eval("View")%>' AutoPostBack="true" OnCheckedChanged="ChkView_CheckedChanged" CssClass="form-group" Font-Size="12px" />
                                                                            <br />
                                                                            <asp:CheckBox ID="ChkCreate" runat="server" Text="Create" Checked='<%#Eval("Create")%>' CssClass="form-group" Font-Size="12px" />
                                                                            <br />
                                                                            <asp:CheckBox ID="ChkEdit" runat="server" Text="Edit" Checked='<%#Eval("Edit")%>' CssClass="form-group" Font-Size="12px" />
                                                                            <br />
                                                                            <asp:CheckBox ID="ChkDelete" runat="server" Text="Delete" Checked='<%#Eval("Delete")%>' CssClass="form-group" Font-Size="12px" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div align="center">
                                                                        <h8 style="color: red">No records found.</h8>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlRoleType" EventName="SelectedIndexChanged" />

                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-lg-12">
                                    <div class="mb-2">
                                        <asp:Button ID="btn_Update" runat="server" Text="Update" CssClass="btn btn-sm btn-success" ValidationGroup="Save" OnClick="btn_Update_Click" />
                                        <asp:Button ID="btn_Close" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" OnClick="btn_Close_Click" />
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
            </div>
            <!-- Cards -->
            <div class="col-md-7 col-sm-7 col-lg-7">
                <div id="div_notes" runat="server">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <h5>Notes</h5>
                                <hr />
                                <asp:Label ID="Label4" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="Label12" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="Label13" runat="server" Text="0" Visible="false"></asp:Label>

                                <asp:Button ID="btn_New_Item" runat="server" Text="New Note" CssClass="btn btn-sm btn-primary col-md-2" ValidationGroup="note" OnClick="btn_New_Item_Click1" />


                                <br />
                                <br />
                                <div id="dtaffnote" runat="server" visible="false">
                                    <asp:Label ID="lbl_Note_description" runat="server" Text="Note description" CssClass="form-label"></asp:Label>
                                    &nbsp;
                                <br />
                                    <br />
                                    <asp:TextBox ID="txt_Note_description" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>

                                    <br />
                                    <asp:Button ID="btnSavenote" runat="server" Text="Save" CssClass="btn btn-sm btn-info" ValidationGroup="Savenote" OnClick="btnSavenote_Click" />
                                </div>
                            </div>
                            <br />
                            <hr />

                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-lg-12">
                                    <div class="mb-2">
                                        <asp:GridView ID="GridViewNote" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Visible="false" Font-Size="12px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStaffID" Text='<%#Eval("StaffID")%>' runat="server" Visible="false" />
                                                        <asp:Label ID="lblProjectID" Text='<%#Eval("ProjectID")%>' runat="server" Visible="false" />
                                                        <asp:Label ID="lblNoteID" Text='<%#Eval("NoteID")%>' runat="server" Visible="false" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Note" HeaderStyle-Font-Size="12px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNote" Text='<%#Eval("Note")%>' runat="server" Font-Size="12px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="AddedForm" HeaderStyle-Font-Size="12px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAddedForm" Text='<%#Eval("Createby")%>' runat="server" Font-Size="12px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="DateAdded" HeaderStyle-Font-Size="12px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDateAdded" Text='<%#Eval("CreateDate","{0:dd/MM/yyyy}")%>' runat="server" Font-Size="12px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditNote" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditNote_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDeleteNote" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteNote_Click"><i class="ti ti-trash"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                    </EditItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div align="center">
                                                    <h8 style="color: red">No records found.</h8>
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <h5>Timesheets & Reports</h5>
                            <hr />
                            <div class="row">
                                <div class="mb-2">
                                    <asp:Label ID="Label14" runat="server" Text="LogIn Status" CssClass="form-label"></asp:Label>

                                    <div class="input-group">
                                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control form-select">
                                            <asp:ListItem Text="This Month Logged Time" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Last Month Logged Time" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="This Week Logged Time" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Last Week Logged Time" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Period" Value="5"></asp:ListItem>
                                        </asp:DropDownList>

                                        <asp:Button ID="btn_Apply" runat="server" Text="Apply" CssClass="btn btn-sm btn-primary  " />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <div class="mb-2">
                                    <asp:GridView ID="GridStaffLogIn" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                        ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Visible="false" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="LoginTime" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLoginTime" Text='<%#Eval("LoginTime","{0:dd/MM/yyyy hh:mm:ss}")%>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="LogoutTime" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLogoutTime" Text='<%#Eval("LogoutTime","{0:dd/MM/yyyy  hh:mm:ss}")%>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Monthly" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMonthly" Text='<%#Eval("MonthDiff")%>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Hours" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHOUREDiff" Text='<%#Eval("HOUREDiff")%>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStaffID" Text='<%#Eval("Staff_ID")%>' runat="server" Visible="false" />
                                                    <asp:Label ID="lblProjectID" Text='<%#Eval("DeptID")%>' runat="server" Visible="false" />
                                                    <asp:Label ID="lblRole" Text='<%#Eval("Role")%>' runat="server" Visible="false" />
                                                    <asp:Label ID="lblStatusBit" Text='<%#Eval("Status")%>' runat="server" Visible="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Task" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTaskName" Text='<%#Eval("TaskName")%>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Start_Date" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStart_Date" Text='<%#Eval("StartTaskTime","{0:dd/MM/yyyy}")%>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Deadline" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDeadline" Text='<%#Eval("StopTaskTime","{0:dd/MM/yyyy}")%>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Related" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRelated" Text='<%#Eval("RelatedTo")%>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TaskBelong" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRelatedBelong" Text='<%#Eval("RelatedToCast")%>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatusName" Text='<%#Eval("Status")%>' runat="server" Visible="false" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEditTask" runat="server" CssClass="btn btn-sm btn-outline-info mb-3" OnClick="btnEditTask_Click" Visible="false"><i class="ti ti-edit"></i></asp:LinkButton>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                </EditItemTemplate>
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDeleteTask" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteTask_Click" Visible="false"><i class="ti ti-trash"></i></asp:LinkButton>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                </EditItemTemplate>
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>

                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div align="center">
                                                <h8 style="color: red">No records found.</h8>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>


                                </div>
                            </div>

                        </div>
                    </div>
                </div>

                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <h5>Project</h5>
                            <hr />
                        </div>

                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <div class="mb-2">
                                    <asp:GridView ID="GridStaffProject" runat="server" OnRowDataBound="GridStaffProject_RowDataBound" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                        ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStaffID" Text='<%#Eval("Staff_ID")%>' runat="server" Visible="false" />
                                                    <asp:Label ID="lblProjectID" Text='<%#Eval("Project_ID")%>' runat="server" Visible="false" />
                                                    <asp:Label ID="lblStatusBit" Text='<%#Eval("Statusbit")%>' runat="server" Visible="false" />
                                                    <asp:Label ID="lblAllocate" Text='<%#Eval("Allocate")%>' runat="server" Visible="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ProjectName" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProjectName" Text='<%#Eval("ProjectName")%>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Start_Date" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStart_Date" Text='<%#Eval("Start_Date","{0:dd/MM/yyyy}")%>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Deadline" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDeadline" Text='<%#Eval("Deadline","{0:dd/MM/yyyy}")%>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatusName" Text='<%#Eval("StatusName")%>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="View" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnDisAllocateProject" runat="server" Text="" CssClass="btn btn-sm btn-danger" OnClick="btnDisAllocateProject_Click" Visible="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div align="center">
                                                <h8 style="color: red">No records found.</h8>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>

                            </div>

                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>

    <script type="text/javascript">
        var togglePassword = document.querySelector('#LinkBtnEyesPassword');
        var password = document.querySelector('#txt_Password');
        togglePassword.addEventListener('click', function (e) {
            const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
            password.setAttribute('type', type);
            this.classList.toggle('fa-eye-slash');
        });
    </script>
</asp:Content>
