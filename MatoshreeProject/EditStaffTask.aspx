<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="EditStaffTask.aspx.cs" Inherits="MatoshreeProject.EditStaffTask" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script> 
        tinymce.init({
            selector: 'textarea',
        });

    </script>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="font-weight-medium mb-0">Edit Task</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item"><a class="text-muted text-decoration-none" href="TaskDetailsStaff">Task Details</a></li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="#">Edit Task</li>
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
        <div class="col-md-12 col-sm-12 col-lg-12">
            <div class="row">
                <div class="col-md-1 col-sm-1 col-lg-1">
                    <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
                </div>
                <div class="col-md-9 col-sm-9 col-lg-9">
                    <div class="card shadow-lg border-dark">
                        <div class="card-body">
                            <h5 class="text-purple">Edit Task </h5>
                              <asp:Label ID="lblStaffEmail" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lblStaffDesignation" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lblEmpName11" runat="server" Text="" Visible="false"></asp:Label>

                            <hr />
                            <div class="form-group mb-2">
                                <asp:CheckBox ID="Cbx_Bank" Text="&nbsp;Public" runat="server" Font-Bold="true" Font-Size="13px" />
                                &nbsp;&nbsp;
                                <asp:CheckBox ID="Cbx_Cash" Text="&nbsp;Billable" runat="server" Checked="true" Font-Bold="true" Font-Size="13px" />


                            </div>
                            <div id="file1" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
                                        <asp:LinkButton ID="linkAttachment" runat="server" CssClass="text-end" Text="Attach Files" OnClick="linkAttachment_Click"></asp:LinkButton>
                                        <br />
                                        <div class="mb-2">
                                            <div class="input-group">
                                                <asp:FileUpload ID="FileUploadtask" runat="server" CssClass="form-control" Visible="false" />
                                                <asp:Button ID="btnUpload" runat="server" Text="+" CssClass="btn btn-sm btn-info" Visible="false" OnClick="btnUpload_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
                                        <div class="mb-2">
                                            <asp:Label ID="lblFileUploadtask" runat="server" Text="" CssClass="form-label" Visible="false"></asp:Label>
                                            <asp:Label ID="lblFileUploadFile1" runat="server" Text="" CssClass="form-label" Visible="false" ForeColor="Blue"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group mb-2">
                                <asp:Label ID="lbl_Subject" runat="server" Text="Subject" CssClass="form-label"></asp:Label>&nbsp;
                                        <span id="ct6_Subject" style="color: red;">*</span>
                                <asp:TextBox ID="txt_Subject" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Rate" runat="server" ErrorMessage="Enter Subject" Display="Dynamic" ControlToValidate="txt_Subject" ForeColor="Red" ValidationGroup="NEWTASK"></asp:RequiredFieldValidator>
                            </div>
                            <div class="row">
                                <div class="form-group mb-2">
                                    <asp:Label ID="lbl_Hourly_Rate" runat="server" Text="Hourly Rate" CssClass="form-label"></asp:Label>
                                    <asp:TextBox ID="txt_Hourly_Rate" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-lg-6">
                                    <div class="form-group mb-2">
                                        <asp:Label ID="lbl_Start_Date" runat="server" Text="Start Date" CssClass="form-label"></asp:Label>

                                        <asp:TextBox ID="txt_Start_Date" type="date" CssClass="form-control" runat="server" Style="display: inline-block;"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-lg-6">
                                    <div class="form-group mb-2">
                                        <asp:Label ID="lbl_Due_Date" runat="server" Text="Due Date" CssClass="form-label"></asp:Label>

                                        <asp:TextBox ID="txt_Due_Date" type="date" CssClass="form-control" runat="server" Style="display: inline-block;"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-lg-6">
                                    <asp:Label ID="lbl_Priority" runat="server" Text="Priority" CssClass="form-label"></asp:Label>
                                    <div class="form-group mb-2">

                                        <asp:DropDownList ID="ddl_Priority" CssClass="form-control form-select" runat="server">
                                            <asp:ListItem Value="0" Text="Select Priority"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Medium"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="High"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Low"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="Urgent"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-lg-6">
                                    <asp:Label ID="lbl_Reapet_Every" runat="server" Text="Reapet Every" CssClass="form-label"></asp:Label>
                                    <div class="form-group mb-2">
                                        <asp:DropDownList ID="ddl_Reapet_Every" CssClass="form-control form-select" runat="server" OnSelectedIndexChanged="ddl_Reapet_Every_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Value="0" Text="Select Reapet Every "></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Week"> </asp:ListItem>
                                            <asp:ListItem Value="2" Text="2 Week"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="1 Month"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="2 Month"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="3 Month"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="6 Month"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="1 Year"></asp:ListItem>
                                            <asp:ListItem Value="8" Text="Custom"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-lg-6 mb-2">
                                    <asp:TextBox ID="txtselectcustom1" runat="server" CssClass="form-control" type="number" Visible="false"></asp:TextBox>
                                </div>
                                <div class="col-md-6 col-sm-6 col-lg-6 mb-2">
                                    <asp:DropDownList ID="ddldays1" CssClass="form-control form-select" Height="32px" runat="server" Visible="false">
                                        <asp:ListItem Value="0" Text="Day(s)"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Week(s)"> </asp:ListItem>
                                        <asp:ListItem Value="2" Text="month(s)"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Year(s)"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row">
                                <div class="form-group mb-2">
                                    <asp:Label ID="Lblselect1" runat="server" Text="Events On (Leave blank for never)" CssClass="form-label" Visible="false"></asp:Label>
                                    <asp:TextBox ID="txtevent1" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                </div>
                            </div>

                            <br />
                            <div class="row">
                               <div class="col-md-6 col-sm-6 col-lg-6">
                                    <asp:Label ID="lblRelated1" runat="server" Text="Releted To" CssClass="form-label"></asp:Label>
                                    <div class="form-group mb-2">
                                        <div class="input-group">
                                            <asp:DropDownList ID="ddlRelatedTo" CssClass="form-control form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRelatedTo_SelectedIndexChanged">
                                                <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                                                <%--<asp:ListItem Text="Select Related To" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Project" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Invoice" Value="2"> </asp:ListItem>
                                            <asp:ListItem Text="Customer" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Estimate" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Tender" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Contract" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="Ticket" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="Expenses" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="Vendor" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="WorkOrder" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="Announcement" Value="11"></asp:ListItem>
                                            <asp:ListItem Text="Inventory" Value="12"></asp:ListItem>
                                            <asp:ListItem Text="Distribution" Value="13"></asp:ListItem>
											    <asp:ListItem Text="PurchaseOrder" Value="14"></asp:ListItem>
											    <asp:ListItem Text="EmployeeSalary" Value="15"></asp:ListItem>
												  <asp:ListItem Text="EmployeePreSalary" Value="16"></asp:ListItem>
												    <asp:ListItem Text="LeaveAnalysis" Value="17"></asp:ListItem>
													  <asp:ListItem Text="Leave" Value="18"></asp:ListItem>
													    <asp:ListItem Text="Leads" Value="19"></asp:ListItem>
														 <asp:ListItem Text="Proposal" Value="20"></asp:ListItem>
											 <asp:ListItem Text="HRMS" Value="21"></asp:ListItem>
                                            <asp:ListItem Text="Other" Value="22"></asp:ListItem>--%>
                                            </asp:DropDownList>

                                            <button type="button" id="btnSource" class="btn btn-info btn-sm font-medium btnmodalPopup" data-bs-toggle="modal"
                                                data-bs-target="#SourceID">
                                                +
                                            </button>
                                        </div>

                                        <%-- Related Modal PopUp --%>
                                        <div class="modal fade" id="SourceID" data-bs-backdrop="static"
                                            data-bs-keyboard="false" tabindex="-1" aria-labelledby="scroll-long-inner-modal"
                                            aria-hidden="true">
                                            <div class="modal-dialog modal-dialog-scrollable">
                                                <div class="modal-content">
                                                    <div class="modal-header d-flex align-items-center">
                                                        <h4 class="modal-title" id="myLargeModalLabel1"></h4>
                                                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                                    </div>
                                                    <div class="modal-body">

                                                        <h6 class="card-title" style="color: blue">Add Related Model</h6>
                                                        <hr />
                                                        <div class="mb-2">
                                                            <asp:Label ID="Label1" runat="server" Text="Related To" CssClass="form-label"></asp:Label>&nbsp;
                                                                 <span id="Ct5Related" style="color: red;">*</span>
                                                            <asp:TextBox ID="txtRelatedModel" runat="server" CssClass="form-control" placeholder="Enter RelatedTo Name"></asp:TextBox>

                                                            <asp:RequiredFieldValidator ID="RequiredSourcename" runat="server" ErrorMessage="Enter RelatedTo Name" ControlToValidate="txtRelatedModel" ForeColor="Red" Font-Bold="false" ValidationGroup="savesource"></asp:RequiredFieldValidator>
                                                        </div>

                                                    </div>
                                                    <br />
                                                    <div class="modal-footer">
                                                        <asp:Button ID="btnsaveModel" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" OnClick="btnsaveModel_Click" ValidationGroup="savesource" />
                                                        &nbsp;&nbsp;
                                                      <button type="Button" class="btn btn-sm btn-danger" data-bs-dismiss="modal">Close</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <%-- !!Madal Popup  --%>
                                    </div>
                                </div>

                                <div class="col-md-6 col-sm-6 col-lg-6">
                                    <asp:Label ID="Label2" runat="server" Text="Options" CssClass="form-label"></asp:Label>

                                    <div class="form-group mb-2">
                                        <asp:DropDownList ID="ddlRelatedCasted" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRelatedCasted_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                    <asp:Label ID="lbl_Reletd_To" runat="server" Text="Assign To" CssClass="form-label"></asp:Label>

                                    <div class="table-responsive" style="height: 273px; width: 100%;">
                                        <asp:GridView ID="gvStaffList" runat="server" CssClass="table table-responsive" AutoGenerateColumns="false" ShowHeader="false" ShowHeaderWhenEmpty="false" EmptyDataText="Not Data Found" Style="width: 100%" OnRowDataBound="gvStaffList_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkRows" runat="server" CssClass="form-label listCheckbox" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStaff" runat="server" Text='<%# Bind("First_Name") %>' Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                    <asp:Label ID="lblFollow" runat="server" Text="Followers" CssClass="form-label"></asp:Label>

                                    <div class="table-responsive" style="height: 273px; width: 100%;">
                                        <asp:GridView ID="GridFollower" runat="server" CssClass="table table-responsive" AutoGenerateColumns="false" ShowHeader="false" ShowHeaderWhenEmpty="false" Style="width: 100%" OnRowDataBound="GridFollower_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkRows" runat="server" CssClass="form-label listCheckbox" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStaff1" runat="server" Text='<%# Bind("Followers") %>' Font-Size="12px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <!--Text Editor-->

                            <div class="row">

                                <asp:Label ID="lbl_Task_Description" runat="server" Text="Task Description" CssClass="form-label"></asp:Label>

                                <hr />
                                <div>
                                    <asp:TextBox ID="txtDescription" runat="server" Placeholder="Description" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                    <div class="hs-docs-content-divider">
                                        <div id="div_editor1" class="text-body" style="min-height: 50%; min-width: 45%;">
                                        </div>
                                        <script>
                                            var editor1 = new RichTextEditor("#div_editor1");
                                        </script>
                                    </div>
                                </div>
                            </div>

                            <br />
                            <div class="row">
                                <div class="form-group">
                                    <asp:Label ID="lbl_Status" runat="server" Text="Status" CssClass="form-label"></asp:Label><br />
                                    <asp:RadioButtonList ID="RadioButtonListTask" runat="server" TabIndex="24" Font-Size="12px">
                                        <asp:ListItem Text="Active" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>

                            <br />
                            <div class="form-group">
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-sm btn-success" ValidationGroup="NEWTASK" OnClick="btnUpdate_Click" />
                                &nbsp;&nbsp;
                            <asp:Button ID="btnClear" runat="server" Text="Cancel" CssClass="btn btn-sm btn-danger" OnClick="btnClear_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-1 col-sm-1 col-lg-1">
                </div>
            </div>
        </div>
    </div>
        </div>

</asp:Content>
