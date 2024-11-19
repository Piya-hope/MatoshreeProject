<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Schedule_Task.aspx.cs" Inherits="MatoshreeProject.Schedule_Task" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridEmail = $("#GridEmail").prepend($("<thead></thead>").append($("#GridEmail").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });
        });

    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                    <h5 class="font-weight-medium mb-0">Task Schedule</h5>
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item">
                                <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                                </a>
                            </li>
                            <li class="breadcrumb-item">
                                <a class="text-muted text-decoration-none" href="TaskDetailsStaff.aspx">TASK</a>

                            </li>
                            <li class="breadcrumb-item text-muted" aria-current="page" href="NewCustomer.aspx">Task Schedule</li>
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
                <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="card-header">
                            <asp:Label ID="lblTaskName" runat="server" Text="" CssClass="text-purple"></asp:Label>&nbsp;&nbsp;&nbsp;                      
                           <asp:Label ID="lblstatusname" runat="server" Text=""></asp:Label>
                            <hr />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-8 col-sm-8 col-ld-8 col-xs-8">
                                    <div class="row">
                                        <div class="form-row" style="display: flex; flex-direction: row; justify-content: left; align-items: center">
                                            <asp:Label ID="lblTaskNameWGV" runat="server" Text="" Visible="false"></asp:Label>
                                            <h4>
                                                <asp:Label ID="lblrelated" runat="server" Text="Related:"></asp:Label>
                                            </h4>
                                            <h5>
                                                <asp:Label ID="lblRelatedTo" runat="server" Text="" CssClass="text-purple"></asp:Label></h5>

                                            <asp:Label ID="lblSceduletask" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:Label ID="lblStaffEmail" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lblStaffDesignation" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lblEmpName11" runat="server" Text="" Visible="false"></asp:Label>

                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="mb-2">
                                                <asp:LinkButton ID="LinkbtnCheck" runat="server" CausesValidation="false" OnClick="LinkbtnCheck_Click" CssClass="btn btn-sm btn-info text-white"><i class="ti ti-check"></i></asp:LinkButton>
                                                <asp:LinkButton ID="Linkbtnet" runat="server" CausesValidation="false" OnClick="LinkbtnTimesheet_Click" CssClass="btn btn-sm btn-light"><i class="ti ti-alarm"></i></asp:LinkButton>
                                                <asp:LinkButton ID="Linkbtntimer" runat="server" CausesValidation="false" CssClass="btn btn-sm btn-light" OnClick="Linkbtntimer_Click" ><i class="ti ti-check"></i> Start Timer</asp:LinkButton>
                                            </div>
                                            <hr />
                                        </div>
                                        <div id="Timesheet" runat="server" visible="false">
                                            <div class="row">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="GridSheduleTask" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4"
                                                        ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                                                        <Columns>

                                                            <asp:TemplateField HeaderText="TaskName" SortExpression="TaskName" HeaderStyle-Font-Size="12px" HeaderStyle-Width="130px">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txttaskName" runat="server" Text='<%# Bind("TaskName") %>' Font-Size="12px"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltaskName1" runat="server" Text='<%# Bind("TaskName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    <%--<asp:LinkButton ID="LnkbtntaskName" Text='<%# Bind("Subject") %>' runat="server">LinkButton</asp:LinkButton>--%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="StartDate" SortExpression="Start_Date" HeaderStyle-Font-Size="12px">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblStart_Date" runat="server" Text='<%# Bind("Start_Date") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStart_Date1" runat="server" Text='<%# Bind("Start_Date") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="EndDate" SortExpression="End_Date" HeaderStyle-Font-Size="12px" HeaderStyle-Width="90px">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblEnd_Date" runat="server" Text='<%#Bind("End_Date") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEnd_Date" runat="server" Text='<%#Bind("End_Date") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Members" SortExpression="AssignTo" HeaderStyle-Font-Size="12px" HeaderStyle-Width="150px">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("AssignTo") %>' Font-Size="12px"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("AssignTo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px" HeaderStyle-Width="70px">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnEditTask" runat="server" CssClass="btn btn-sm btn-outline-info mb-3"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnDeleteTask" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>

                                                        </Columns>
                                                    </asp:GridView>
                                                    <%---------------------------------------------------------- --%>
                                                </div>
                                            </div>
                                            <asp:Label ID="lbltimesheet" runat="server" Text="Add timesheet:" CssClass="form-label"></asp:Label>
                                            <hr />
                                            <div class="row">
                                                <div class="col-md-6 col-sm-6 col-ld-6 col-xs-6">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblstrattime" runat="server" Text="Start Time" CssClass="form-label"></asp:Label>
                                                        <asp:TextBox ID="txtStartDate" type="DateTime-Local" CssClass="form-control" runat="server" placeholder="Enter Start Date" ValidationGroup="Savebtnval"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiretxtStartDate" runat="server" ErrorMessage="Enter  stratdate" ControlToValidate="txtStartDate" ForeColor="Red" Font-Bold="false" ValidationGroup="Savebtnval" Font-Size="12px"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 col-sm-6 col-ld-6 col-xs-6">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblendtime" runat="server" Text="End Time" CssClass="form-label"></asp:Label>
                                                        <asp:TextBox ID="txtendtime" type="DateTime-Local" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="Enter End Date"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="Requiretxtendtime" runat="server" ErrorMessage="Enter  EndDate" ControlToValidate="txtendtime" ForeColor="Red" Font-Bold="false" ValidationGroup="Savebtnval" Font-Size="12px"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="mb-2">
                                                    <asp:CheckBox ID="ChBoxAllMember" runat="server" Text="All Members" Checked="true" OnCheckedChanged="ChBoxAllMember_CheckedChanged" AutoPostBack="true" CssClass="form-label" />
                                                    <br />
                                                    <asp:Label ID="lblmember" runat="server" Text="Member" CssClass="form-label" Visible="false"></asp:Label>
                                                    <asp:DropDownList ID="ddlMember" runat="server" CssClass="form-control" Visible="false">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblNote" runat="server" Text="Note" CssClass="form-label"></asp:Label>
                                                    <asp:TextBox ID="txtareaNote1" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="mb-2">
                                                    <div class="col-md-6 col-sm-6 col-ld-6 col-xs-6">
                                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-sm btn-primary text-start" ValidationGroup="Savebtnval" OnClick="btnSave_Click" Text="Save" />
                                                    </div>
                                                    <div class="col-md-6 col-sm-6 col-ld-6 col-xs-6"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="mb-2">
                                            <%--------------------- Description------------------------------------------------- --%>
                                            <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="form-label" Font-Size="14px"></asp:Label>&nbsp;&nbsp;
                                                <asp:LinkButton ID="btndescriptionedit" OnClick="btndescriptionedit_Click" ValidationGroup="descriptionedit" CssClass="btn btn-sm btn-outline-info" runat="server"><i class="ti ti-edit"></i></asp:LinkButton>
                                            <br />
                                            <br />
                                            <asp:TextBox ID="txtareaDesc" placeholder="Description" CssClass="form-control" OnTextChanged="txtareaDesc_TextChanged" AutoPostBack="true" runat="server" Visible="false" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <hr />
                                    <div class="row">
                                        <div class="mb-2">
                                            <i class="ti ti-circle-plus text-info"></i>
                                            <asp:LinkButton ID="btnchklistitem" runat="server" OnClick="btnchklistitem_Click" CssClass="text-purple" ValidationGroup="chklistitem1" Font-Size="14px">Checklist Items</asp:LinkButton>
                                        </div>
                                        <%---------------------------checklistItem -------------------------%>
                                        <div id="chklistitem" runat="server" visible="true">
                                            <div class="row">
                                                <div class="mb-2">
                                                    <div class="col-md-12 col-sm-12 col-ld-6 col-xs-12 ">
                                                        <div class="input-group">
                                                            <asp:TextBox ID="txthide" runat="server" Text="" placeholder="Add Checklist Item" CssClass="form-control" Font-Size="12px"></asp:TextBox>
                                                            <div class="btn-group">

                                                                <button class="btn btn-sm btn-success" name="Assignees" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                                    <a href="#" class="trigger manual-popover pull-left" title="btnpop">
                                                                        <i class="ti ti-users"></i>
                                                                    </a>
                                                                </button>
                                                                <asp:Label ID="lblnameAssignees" runat="server" Text="" Font-Bold="false" Visible="false"></asp:Label>
                                                                <div class="dropdown-menu">
                                                                    <asp:DropDownList ID="ddlMerbersTaskCheck" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMerbersTaskCheck_SelectedIndexChanged"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <asp:Button ID="btnchekItemAdd" runat="server" Text="Add" CssClass="btn btn-sm btn-info" ValidationGroup="chkitem1" OnClick="btnchekItemAdd_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12 col-sm-12 col-lg-12">
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="GridViewCheckListItemTask" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="CL_ID" Style="width: 100%"
                                                            ShowHeader="false" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="False" BackColor="White" BorderStyle="None" OnRowDataBound="GridViewCheckListItemTask_RowDataBound"
                                                            ShowFooter="true">
                                                            <Columns>
                                                                <asp:TemplateField Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("CL_ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField Visible="false">
                                                                    <%--  <ItemTemplate>
                                                                <asp:CheckBox ID="ChBoxB2" runat="server" Checked='<%# Bind("CheckStatus") %>' Font-Bold="true" Font-Size="12px" Style="display: grid;" />
                                                            </ItemTemplate>--%>
                                                                    <FooterTemplate>
                                                                        <asp:CheckBox ID="ChBoxB1" runat="server" Font-Bold="true" Font-Size="12px" Checked="true" Style="display: grid;" />
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblcheckItem1" runat="server" Text='<%# Bind("Checklist_Item") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <i class="ti ti-circle-dot text-info"></i>
                                                                        <asp:Label ID="lblcheckItem" runat="server" Text='<%# Bind("Checklist_Item") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:TextBox ID="txtcheckItem1" runat="server" Text='<%# Bind("Checklist_Item") %>' CssClass="form-control" OnTextChanged="txtcheckItem1_TextChanged" Font-Bold="false" AutoPostBack="true" Font-Size="12px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="Requiredchkitem" runat="server" ErrorMessage="Enter  checklist_Item" ControlToValidate="txtcheckItem1" ForeColor="Red" Font-Bold="false" ValidationGroup="Upadtechkitem" Font-Size="12px"></asp:RequiredFieldValidator>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblddlDevlopername1" runat="server" Text='<%# Bind("AssignTo") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <div style="position: relative; display: inline-block;">
                                                                            <i class="ti ti-user-plus ti-2fa" title="Assign Staff">
                                                                                <asp:DropDownList ID="ddlDevlopername" runat="server" CssClass="form-control" Style="position: absolute; top: 0; left: 0; opacity: 0;" data-bs-toggle="tooltip" OnSelectedIndexChanged="ddlDevlopername_SelectedIndexChanged" AutoPostBack="true">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RequiredDevlopername" runat="server" ErrorMessage="Select Member" ControlToValidate="ddlDevlopername" ForeColor="Red" Font-Bold="false" ValidationGroup="Upadtechkitem" InitialValue="0" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>
                                                                                <asp:Label ID="ddldevmsg" runat="server" Text="" Font-Bold="false" Font-Size="15px"></asp:Label>
                                                                            </i>
                                                                        </div>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButtonDelete" runat="server" ValidationGroup="btn" CssClass="m-2 btn btn-sm btn-outline-danger" OnClick="LinkButtonDelete_Click2"><i class="ti ti-trash"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                            </Columns>

                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <hr />
                                    <div class="row">
                                        <%-- ------------------------COMMENT----------------------- --%>
                                        <asp:LinkButton ID="Lbtncomment" runat="server" OnClick="Lbtncomment_Click" CssClass="text-purple" Font-Size="14px">Comments</asp:LinkButton>
                                        <div class="row">

                                            <div id="Commentshide" runat="server" visible="true">
                                                <div class="mb-2">
                                                    <asp:TextBox ID="txttypewriter1" CssClass="form-control same-width" runat="server" TextMode="MultiLine" Placeholder="Comments"></asp:TextBox>
                                                    <br />
                                                    <div class="text-end">
                                                        <asp:Button ID="btnaddcomnt" runat="server" CssClass="px-3 btn btn-primary btn-sm" OnClick="btnaddcomnt_Click" Text="Add Comment" />
                                                    </div>
                                                </div>
                                                <div class="table-responsive">
                                                    <asp:GridView ID="GridComment" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="id" Style="width: 100%" CellPadding="4" data-plugin="dataTable"
                                                        ClientIDMode="Static" ShowHeader="false" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="False" BorderColor="#999999" BorderStyle="None" CellSpacing="2" OnRowEditing="GridComment_RowEditing" OnRowUpdating="GridComment_RowUpdating"
                                                        EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" OnRowCancelingEdit="GridComment_RowCancelingEdit" OnRowDeleting="GridComment_RowDeleting" OnPageIndexChanging="GridComment_PageIndexChanging">
                                                        <Columns>
                                                            <asp:TemplateField Visible="false">

                                                                <ItemTemplate>

                                                                    <asp:Label ID="lblcommentID1" runat="server" Text='<%# Bind("id") %>' Font-Bold="false" Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblcommentID1y" runat="server" Text='<%# Bind("id") %>' Font-Bold="false" Visible="false"></asp:Label>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderStyle-Width="10px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblcomment" runat="server" Text='<%# Bind("comment") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                    <br />
                                                                    <asp:Label ID="lblcreateby" runat="server" Text='<%# Bind("Createby") %>' Font-Bold="false" Font-Size="12px"></asp:Label>

                                                                    <br />
                                                                    <asp:Label ID="lblDate" runat="server" Text='<%# Bind("dateliked") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtcomment" runat="server" Text='<%# Bind("comment") %>' CssClass="form-control same-width" TextMode="MultiLine" Font-Size="12px"></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnEditcomment" runat="server" CommandName="Edit" CssClass="btn btn-sm btn-outline-info"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                    &nbsp
                                                          <asp:LinkButton ID="LinkCommentDelete" runat="server" CommandName="Delete" ValidationGroup="btn11" CssClass="btn btn-sm btn-outline-danger m-2"><i class="ti ti-trash"></i></asp:LinkButton>

                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>

                                                                <EditItemTemplate>
                                                                    <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update" TabIndex="18"></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="Cancel" TabIndex="19"></asp:LinkButton>
                                                                </EditItemTemplate>
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
                                <%-- 4 Div --%>
                                <div class="col-md-4 col-sm-4 col-ld-4 col-xs-4 bg-success-subtle text-info">
                                    <div class="row">
                                        <div class="col-md-6 col-sm-6 col-ld-6 col-xs-6">
                                            <div class="mb-2">
                                                <h5>Task Info</h5>
                                            </div>
                                        </div>
                                        <div class="col-md-6 col-sm-6 col-ld-6 col-xs-6 text-end">
                                            <div class="text-end task-menu-options">
                                                <div class="btn-group">

                                                    <button class="btn btn-sm btn-info w-85" name="btnpop" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                        <a href="#" class="trigger manual-popover pull-left" title="btnpop">
                                                            <i class="ti ti-circle"></i>

                                                        </a>
                                                    </button>

                                                    <div class="dropdown-menu">
                                                        <asp:LinkButton ID="LinkButton9" Text="Action" runat="server" CssClass="dropdown-item" ForeColor="Black"></asp:LinkButton>
                                                        <asp:LinkButton ID="lnkbtnviewascustmer" Text="Edit" runat="server" CssClass="dropdown-item" ForeColor="Blue" OnClick="lnkbtnviewascustmer_Click"></asp:LinkButton>
                                                        <asp:LinkButton ID="lnkbtnattachfile" Text="Copy" runat="server" CssClass="dropdown-item" OnClick="lnkbtnattachfile_Click" ForeColor="Blue"></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <p>
                                            <asp:Label ID="lblCreateBy1" runat="server" Text="Created By:" CssClass="form-label"></asp:Label>
                                            <asp:Label ID="lblCreateBy" runat="server" Text="" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                            <br />
                                            <asp:Label ID="lblCreateTime" runat="server" Text="Created at time:" CssClass="form-label"></asp:Label>


                                            <i class="ti ti-clock" data-bs-toggle="tooltip" data-bs-placement="top">
                                                <asp:Label ID="lblCreateTim" runat="server" Text="" Font-Size="12px"></asp:Label></i>
                                            <%-- <br>--%>
                                        </p>
                                    </div>
                                    <hr>
                                    <div class="row">
                                        <div class="col-sm-4 col-md-4 col-ld-4">
                                            <i class="ti ti-star text-dark"></i>
                                            <asp:Label ID="lblStatus" runat="server" Text="Status:" CssClass="form-label"></asp:Label>
                                        </div>
                                        <div class="col-sm-8 col-md-8 col-lg-8">
                                            <asp:DropDownList ID="ddlProcess" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlProcess_SelectedIndexChanged">
                                                <asp:ListItem Text="Action"></asp:ListItem>
                                                <asp:ListItem Text="Mark as Started"></asp:ListItem>
                                                <asp:ListItem Text="Mark as Not Started"></asp:ListItem>
                                                <asp:ListItem Text="In Progress"></asp:ListItem>
                                                <asp:ListItem Text="Mark as Testing"></asp:ListItem>
                                                <asp:ListItem Text="Mark as Awaiting Feedback"></asp:ListItem>
                                                <asp:ListItem Text="Mark as Complete"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-sm-offset-2 col-sm-10 col-md-4 col-ld-4">
                                            <h5><i class="ti ti-calendar"></i>
                                                <asp:Label ID="lblStratDate" runat="server" Text="Start Date:" CssClass="form-label"></asp:Label></h5>
                                        </div>
                                        <div class="col-sm-10 col-md-8 col-lg-8">
                                            <asp:TextBox ID="txtStartDtae" CssClass="form-control" Text="" runat="server" OnTextChanged="txtStartDtae_TextChanged1" AutoPostBack="true" ValidationGroup="stratdate11" placeholder="Start Date" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-offset-2 col-sm-10 col-md-4 col-ld-4">
                                            <h5><i class="ti ti-calendar-event"></i>
                                                <asp:Label ID="lblDueDate" runat="server" Text="Due Date:" CssClass="form-label"></asp:Label></h5>
                                        </div>
                                        <div class="col-sm-10 col-md-8 col-lg-8">
                                            <asp:TextBox ID="txtDueDate" CssClass="form-control" runat="server" OnTextChanged="txtDueDate_TextChanged" AutoPostBack="true" placeholder="Due Date" Font-Size="12px" ValidationGroup="duedat1" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-10 col-md-4 col-ld-4">
                                            <h5><i class="ti ti-bolt"></i>
                                                <asp:Label ID="lblPriority" runat="server" Text="Priority:" CssClass="form-label"></asp:Label></h5>
                                        </div>
                                        <div class="col-sm-10 col-md-8 col-lg-8">
                                            <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form-control" AutoPostBack="true" ValidationGroup="dropdownPriority1" OnSelectedIndexChanged="ddlPriority_SelectedIndexChanged">
                                                <asp:ListItem Text="Action" Value="Action"></asp:ListItem>
                                                <asp:ListItem Text="Low" Value="Low"></asp:ListItem>
                                                <asp:ListItem Text="Medium" Value="Medium"></asp:ListItem>
                                                <asp:ListItem Text="Urgent" Value="Urgent"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-sm-10 col-md-4 col-lg-4">
                                            <h5><i class="ti ti-clock"></i>
                                                <asp:Label ID="lblHourlyRate" runat="server" Text="Hourly Rate:" CssClass="form-label"></asp:Label></h5>
                                        </div>
                                        <div class="col-sm-10 col-md-8 col-lg-8">
                                            <asp:TextBox ID="txtHourly_Rate" runat="server" class="form-control dropdown-toggle " OnTextChanged="txtHourly_Rate_TextChanged" ValidationGroup="houreffect" AutoPostBack="true" aria-expanded="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-sm-10 col-md-4 col-lg-4">
                                            <h5><i class="ti ti-credit-card"></i>
                                                <asp:Label ID="LabellblBillable2" runat="server" Text="Billable:" CssClass="form-label"></asp:Label></h5>
                                        </div>
                                        <div class="col-sm-10 col-md-8 col-lg-8">
                                            <div class="bd-example">
                                                <div class="btn-group btn-group-md btn-group-sm">
                                                    <button class="btn btn-md btn-light dropdown-toggle " data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false" id="BTNBIIL1" runat="server"></button>
                                                    <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                                    <div class="dropdown-menu">
                                                        <asp:LinkButton ID="lnkbtnbillable" Text="Billable" runat="server" CssClass="dropdown-item" OnClick="lnkbtnbillable_Click"></asp:LinkButton>
                                                        <asp:LinkButton ID="lnkbtnNotbillable" Text="Not Billable" runat="server" CssClass="dropdown-item" OnClick="lnkbtnNotbillable_Click"></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div id="BillableAmount1" runat="server" visible="false">
                                        <div class="row">
                                            <div class="col-sm-10 col-md-4 col-lg-4">
                                                <h5><i class="ti ti-credit-card"></i>
                                                    <asp:Label ID="lblBillableAmt" runat="server" Text="Billable Amount:" CssClass="form-label"></asp:Label>
                                                </h5>
                                            </div>
                                            <div class="col-sm-10 col-md-8 col-lg-8">

                                                <asp:Label ID="lblBillableAmount" runat="server" Text="0.00" Font-Size="12px"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6 col-md-6 col-lg-6">
                                            <h5><i class="far fa-clock" aria-hidden="true"></i>
                                                <asp:Label ID="lblLoggedTime1" runat="server" Text="Your logged time:" CssClass="form-label"></asp:Label></h5>
                                        </div>
                                        <div class="col-sm-6 col-md-6 col-lg-6">
                                            <asp:Label ID="lbllogtime" runat="server" Text="0:00" Font-Size="12px"></asp:Label>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-sm-3 col-md-3 col-lg-3">
                                            <asp:TextBox ID="txtTag" CssClass="form-control" Style="display: inline-block; background-color: #d2edf9b8; width: 150px" runat="server" OnTextChanged="txtTag_TextChanged" AutoPostBack="true" placeholder="Tag" Visible="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <asp:Label ID="lbltaskassign" runat="server" Text="This task is assigned to you by:" CssClass="form-label"></asp:Label>
                                        <asp:Label ID="lblassigntaskby" runat="server" Text="" ForeColor="Blue" Font-Size="12px"></asp:Label>
                                        <hr class="task-info-separator">
                                        <h5>
                                            <i class="ti ti-bell" aria-hidden="true"></i>
                                            <span class="">Reminders </span>
                                        </h5>
                                        <asp:LinkButton ID="lnkbtnCreateRemainder" Text="Create Reminder" runat="server" ValidationGroup="btn14" CssClass="text-purple" Font-Size="14px" OnClick="lnkbtnCreateRemainder_Click"></asp:LinkButton>
                                    </div>
                                    <div id="craeteButton" runat="server" visible="false">
                                        <div class="row">
                                            <div class="form-group mb-2" app-field-wrapper="date">
                                                <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                    <asp:Label ID="lblDateNotified" runat="server" Text="Date To be Notified" CssClass="form-label"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lblRID" runat="server" Text="" Visible="false" Font-Size="12px"></asp:Label>
                                                    <asp:TextBox ID="txtDateNotified" type="DateTime-Local" CssClass="form-control" Style="display: inline-block;" runat="server" Font-Size="12px" placeholder="Enter Date"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group mb-2" app-field-wrapper="date">
                                                <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                    <asp:Label ID="lblSetRemainder" runat="server" Text="Set To Remainder" CssClass="form-label"></asp:Label>
                                                    <br />
                                                    <asp:DropDownList ID="ddlreminderMember" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group mb-2" app-field-wrapper="date">
                                                <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                    <asp:Label ID="Label1" runat="server" Text="Description" CssClass="form-label"></asp:Label>
                                                    <br />
                                                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" CssClass="form-control border" Style="display: inline-block;" runat="server" placeholder="Enter Description"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group mb-2" app-field-wrapper="date">
                                                <div class="checkbox checkbox-primary">
                                                    <asp:CheckBox ID="chksetRemainderforEmail" runat="server" CssClass="w-50 h-50" />
                                                    <asp:Label ID="lblsetRemainderforEmail" runat="server" Text="Send also an email for this reminder" CssClass="form-label"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group mb-2">
                                                <div class="col-md-6 col-sm-6 col-ld-6 col-xs-6 text-left"></div>
                                                <div class="col-md-6 col-sm-6 col-ld-6 col-xs-6 text-end">
                                                    <asp:Button ID="btnCreateRemainder" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnCreateRemainder_Click" Text="Create Reminder" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group mb-2">
                                            <asp:Label ID="lblreminderfor" runat="server" Text="Remainder for" CssClass="form-label"></asp:Label>
                                            <asp:Label ID="lblremMember" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            <asp:Label ID="lblremon" runat="server" Text="on" CssClass="form-label"></asp:Label>
                                            <asp:Label ID="lblremdate" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            &nbsp;&nbsp;
                                             <asp:LinkButton ID="btnEditTask" runat="server" OnClick="btnEditTask_Click" ForeColor="Blue" CssClass="btn btn-sm"><i class="ti ti-edit"></i></asp:LinkButton>
                                            &nbsp;
                                             <asp:LinkButton ID="btnDeleteTask" runat="server" CommandName="Delete" CssClass="btn btn-sm " OnClick="btnDeleteTask_Click" ForeColor="Red" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group mb-2">
                                            <div id="newTaskReminder" class="mtop15" style="display: none;">
                                                <%-- <asp:FormView ID="FormView1" runat="server"> </asp:FormView>--%>
                                                <form action="#" id="form-reminder-task11" method="post">
                                                    <input type="hidden" name="rel_id" value="73">
                                                    <input type="hidden" name="rel_type" value="task">
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group mb-2">
                                            <h4 class="task-info-heading tw-font-medium tw-text-base tw-flex tw-items-center tw-text-neutral-800 tw-mb-1">
                                                <i class="ti ti-user" aria-hidden="true"></i>
                                                <span class="form-label">Assignees </span>
                                            </h4>
                                            <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                <div class="ms-2">
                                                    <asp:BulletedList ID="BulletedListAsssigness" runat="server" Font-Size="12px" BulletStyle="Square">
                                                    </asp:BulletedList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group mb-2">
                                            <div class="simple-bootstrap-select tw-mb-2">
                                                <hr class="task-info-separator">
                                                <h4 class="task-info-heading tw-font-medium tw-text-base tw-flex tw-items-center tw-text-neutral-800 tw-mb-1">
                                                    <i class="ti ti-user-search" aria-hidden="true"></i>
                                                    <span class="form-label">Followers </span>
                                                </h4>
                                                <div class="simple-bootstrap-select tw-mb-2">
                                                    <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                        <div class="ms-2">
                                                            <asp:BulletedList ID="BulletedListfollwers" Font-Size="12px" runat="server" BulletStyle="Square">
                                                            </asp:BulletedList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group mb-2">
                                            <div class="uploadOuterforTaskInfo">
                                                <span class="dragBox">Darg and Drop image here           
                                                 <input type="file" runat="server" onchange="dragNdrop(event)" ondragover="drag()" ondrop="drop()" id="File1" />
                                                </span>
                                            </div>
                                            <br />
                                            <br />
                                            <div id="preview"></div>
                                            <div id="btndesgin">
                                                    <asp:Label ID="lblSceduletaskTime" runat="server" Text="" CssClass="form-label"></asp:Label>
                                     
                                                <br />
                                                <asp:LinkButton ID="Linkupload" runat="server" CommandName="Close" CssClass="btn btn-sm  btn-outline-info  ml-4" OnClick="Linkupload_Click"><i class="ti ti-upload"></i></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <style>
        .txt {
            margin-left: 2px;
        }

        .rounded-10 {
            border-radius: 10px;
        }

        .uploadOuterforTaskInfo {
            text-align: center;
            padding: 20px;
            /*  strong {
            padding: 0 10px
            }*/
        }

        .uploadOuter {
            text-align: center;
            /*  padding: 20px;*/
            /*  strong {
            padding: 0 10px
            }*/
        }

        .dragBox {
            width: 100%;
            height: 150px;
            margin: 0 0px 0px 0px;
            position: relative;
            text-align: center;
            font-weight: bold;
            line-height: 95px;
            color: #999;
            border: 2px dashed #ccc;
            display: inline-block;
            transition: transform 0.3s;
        }

            .dragBox input[type="file"] {
                /* position: absolute; */
                opacity: 0; /* Hide the input element */
                position: absolute;
                top: 0;
                left: 0;
                width: 100%;
                height: 100%;
                cursor: pointer; /* Show pointer cursor when hovering over the dragBox */
            }

        .draging {
            transform: scale(1.1);
        }

        #preview {
            text-align: center;
        }


            #preview img {
                height: 150px;
                width: 250px;
            }

        #btndesgin {
            text-align: center;
        }



        /* .footer:hover {
            background-color: lightblue;
            width: auto;
        }*/

        .same-width {
            width: 100%;
            align-content: flex-start;
        }
    </style>

    <script>
        "use strict";

        function dragNdrop(event) {
            var fileName = URL.createObjectURL(event.target.files[0]);
            var preview = document.getElementById("preview");
            var previewImg = document.createElement("img");
            previewImg.setAttribute("src", fileName);
            preview.innerHTML = "";
            preview.appendChild(previewImg);
        }

        function drag() {
            document.getElementById('uploadFile').parentNode.className = 'dragging dragBox';
        }

        function drop() {
            document.getElementById('uploadFile').parentNode.className = 'dragBox';
        }



    </script>

</asp:Content>



