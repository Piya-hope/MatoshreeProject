<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="TicketOverView.aspx.cs" Inherits="MatoshreeProject.TicketOverView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GVTotalTicket = $("#GVTotalTicket").prepend($("<thead></thead>").append($("#GVTotalTicket").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridTask1 = $("#GridTask1").prepend($("<thead></thead>").append($("#GridTask1").find("tr:first"))).DataTable(
                {
                    "responsive": true,
                    "scrollY": "400px",
                    "scrollX": "100%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridReminderticket = $("#GridReminderticket").prepend($("<thead></thead>").append($("#GridReminderticket").find("tr:first"))).DataTable(
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
    <style>
        .Background {
            background-color: Black;
            filter: blur(1px);
            opacity: 0.8;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="font-weight-medium mb-0">Ticket Overview</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Ticket_Details.aspx">Ticket Details
                            </a>
                        </li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="#">Ticket Overview</li>
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
            <div class="row">
                 <asp:Label ID="lblStaffEmail" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lblStaffDesignation" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lblEmpName11" runat="server" Text="" Visible="false"></asp:Label>

                <div class="col-md-9 col-sm-9 col-lg-9 col-xs-9 text-left">
                    <asp:Label ID="lblsubjectname" runat="server" Text="" CssClass="form-label text-purple" Font-Size="18px"></asp:Label>
                    &nbsp;
                       <asp:Label ID="lblstatusname1" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-md-3 col-sm-3 col-lg-3 col-xs-3 text-end">
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                    <asp:Label ID="lblticketLinkProject" runat="server" Text="This ticket is linked to project:" CssClass="form-label"></asp:Label>
                    <asp:Label ID="lblProjName" runat="server" Text="" CssClass="text-info"></asp:Label>
                </div>
            </div>
            <br />
            <br />
            <div class="container-fluid">
                <div class="card">
                    <div class="card-body">
                        <ul class="nav nav-tabs" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link active" data-bs-toggle="tab" href="#AddReply" role="tab"><span class="hidden-sm-up"></span>
                                    <span class="hidden-sm-down">Add Reply</span></a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" data-bs-toggle="tab" href="#AddNote" role="tab"><span class="hidden-sm-up"></span>
                                    <span class="hidden-sm-down">Add Note</span></a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" data-bs-toggle="tab" href="#Reminders" role="tab"><span class="hidden-sm-up"></span>
                                    <span class="hidden-sm-down">Reminders</span></a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" data-bs-toggle="tab" href="#OtherTickets" role="tab"><span class="hidden-sm-up"></span>
                                    <span class="hidden-sm-down">Other Tickets</span></a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" data-bs-toggle="tab" href="#Tasks" role="tab"><span class="hidden-sm-up"></span>
                                    <span class="hidden-sm-down">Tasks</span></a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" data-bs-toggle="tab" href="#Settings" role="tab"><span class="hidden-sm-up"></span>
                                    <span class="hidden-sm-down">Settings</span></a>
                            </li>

                        </ul>
                        <br />
                        <div class="mb-2">

                            <div class="tab-content tabcontent-border">
                                <div class="tab-pane active p-20" id="AddReply" role="tabpanel">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                            <%--<asp:LinkButton ID="btnDeleteReply" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-rounded" OnClientClick="return confirm('Are you sure you want to delete?')"><i class="ti ti-trash"></i></asp:LinkButton>--%>

                                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-sm btn-outline-dark">
                                                <asp:Label ID="Label2" runat="server" Text="Priority:" Font-Size="12px"></asp:Label><asp:Label ID="lblpriority1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            </asp:LinkButton>
                                            &nbsp; 
                                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-sm btn-outline-dark">
                                                <asp:Label ID="Label4" runat="server" Text="Department:" Font-Size="12px"></asp:Label><asp:Label ID="lblDepartment1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            </asp:LinkButton>
                                            &nbsp; 
                                             <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-sm btn-outline-info">
                                                 <asp:Label ID="Label6" runat="server" Text="Assigned:" Font-Size="12px"></asp:Label><asp:Label ID="lblAssigned1" runat="server" Text="" Font-Size="12px"></asp:Label>
                                             </asp:LinkButton>
                                            &nbsp; 
                                          <asp:LinkButton ID="lnkbtnTicketPublicForm" runat="server" OnClick="lnkbtnTicketPublicForm_Click" CssClass="btn btn-sm btn-outline-info">
                                              <asp:Label ID="lblTicketPublicForm" runat="server" Text="View Public Form" Font-Size="12px"></asp:Label>
                                          </asp:LinkButton>

                                        </div>
                                    </div>
                                    <br />


                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                            <asp:TextBox ID="txtReplyby" CssClass="form-control" OnTextChanged="txtReplyby_TextChanged" Placeholder="Add Reply" AutoPostBack="true" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                            <asp:Label ID="lblStatus" runat="server" Text="Change Status" CssClass="form-label"></asp:Label>
                                            <asp:DropDownList ID="ddlstauschange" runat="server" CssClass="form-control form-select">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-6 col-sm-6 col-lg-6 col-xl-6">
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">

                                            <asp:Label ID="lblcc" runat="server" Text="CC" CssClass="form-label"></asp:Label>
                                            <asp:TextBox ID="txtcc" CssClass="form-control" placeholder="Enter cc" runat="server"></asp:TextBox>
                                            <asp:Label ID="lblTicketid" runat="server" Text="" Visible="false" CssClass="form-label"></asp:Label>

                                        </div>
                                        <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">

                                            <asp:CheckBox ID="chkSendEmail" Text="&nbsp; Assign this ticket to me automatically" runat="server" CssClass="form-label" />

                                        </div>
                                        <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                            <asp:CheckBox ID="CheckBox1" Text="&nbsp; Return to Ticket list after response is submitted" runat="server" CssClass="form-label" />

                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">

                                            <h6>
                                                <asp:Label ID="lblAttachment" runat="server" Text="Attachment" CssClass="form-label"></asp:Label></h6>
                                            <div class="row">
                                                <div class="input-group">
                                                    <asp:FileUpload ID="FileUpload" runat="server" Text="" CssClass="form-control" />
                                                    <asp:Button ID="Btn_Upload" runat="server" Text="Upload" CssClass="btn btn-sm btn-primary" OnClick="Btn_Upload1_Click" />
                                                </div>
                                            </div>
                                            <br />
                                        </div>
                                        <div class="col-md-6 col-sm-6 col-lg-6">
                                        </div>
                                    </div>

                                </div>
                                <div class="tab-pane p-20" id="AddNote" role="tabpanel">
                                    <div class="row">
                                        <asp:LinkButton ID="LbtnNote" runat="server" CssClass="text-dark  font-bold">Note</asp:LinkButton>


                                        <div class="row">
                                            <div id="Nodeshide" runat="server" visible="true">

                                                <asp:TextBox ID="txtareaNotes" CssClass="form-control same-width" placeholder="Note" runat="server" TextMode="MultiLine"></asp:TextBox>

                                                <br />


                                                <br />

                                                <div class="row">

                                                    <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12 text-12">
                                                        <div class="mb-2">
                                                            <asp:Button ID="btnaddNotes" runat="server" OnClick="btnaddNotes_Click" CssClass="btn btn-primary btn-sm text-center" Text="Add Note" />
                                                            &nbsp;&nbsp;
                                                         <asp:Button ID="btnClear" runat="server" Text="Cancel" CssClass="btn btn-danger btn-sm" OnClick="btnClear_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="tab-pane p-20" id="Reminders" role="tabpanel">


                                    <asp:LinkButton ID="LinkbtnReminder" runat="server" CommandName="Closed" Visible="true" CssClass="btn btn-sm btn-outline-dark  p-1  "><i class="ti ti-bell" aria-hidden="true"></i> Set Ticket Reminders</asp:LinkButton>
                                    <br />
                                    <br />
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-lg-12 col-12 col-xs-12">
                                            <div class="table-responsive">
                                                <asp:GridView ID="GridReminderticket" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                                    ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px"/>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="NotifyDate" SortExpression="NotifyDate" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblExp_Date" runat="server" Text='<%# Bind("NotifyDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblExp_Date1" runat="server" Text='<%# Bind("NotifyDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="SetToReminder" SortExpression="SetToReminder" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblDepartment" runat="server" Text='<%# Bind("SetToReminder") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDepartment1" runat="server" Text='<%# Bind("SetToReminder") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-Font-Size="12px">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblServices" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblServices1" runat="server" Text='<%# Bind("Description") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
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


                                    <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="LinkbtnReminder"
                                        CancelControlID="btnCloseReminder" BackgroundCssClass="Background">
                                    </cc1:ModalPopupExtender>

                                    <asp:Panel ID="Panl1" runat="server" CssClass="container-fluid" align="left" Style="display: none; width: 900px; height: 350px;">
                                        <div classs="container-fluid">
                                            <div class="row">
                                                <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                    <div class="card">
                                                        <div class="card-body">
                                                            <div id="ReminderButton" runat="server" visible="true">
                                                                <div class="mb-2">
                                                                    <h5>Add Reminder</h5>
                                                                    <hr />
                                                                </div>
                                                                <div class="form-group mb-2" app-field-wrapper="date">
                                                                    <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                                        <asp:Label ID="lblDateNotified" runat="server" Text="Date To be Notified" Font-Size="12px"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="lblRID" runat="server" Text="" Visible="false" Font-Size="14px"></asp:Label>
                                                                        <asp:TextBox ID="txtDateNotified" type="DateTime-Local" CssClass="form-control" Style="display: inline-block;" runat="server" Font-Size="12px" placeholder="Enter Date"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group mb-2" app-field-wrapper="date">
                                                                    <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                                        <asp:Label ID="lblSetRemainder" runat="server" Text="Set To Remainder" Font-Size="12px"></asp:Label>
                                                                        <br />

                                                                        <asp:DropDownList ID="ddlReminderMember" runat="server" CssClass="form-control form-select">
                                                                            <asp:ListItem>Nothing Selected</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group mb-2" app-field-wrapper="date">
                                                                    <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12">
                                                                        <asp:Label ID="lbldescriptionrem" runat="server" Text="Description" Font-Size="12px"></asp:Label>
                                                                        <br />
                                                                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" CssClass="form-control border" Style="display: inline-block;" runat="server" placeholder="Enter Description"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group mb-2" app-field-wrapper="date">
                                                                    <div class="checkbox checkbox-primary">
                                                                        <asp:CheckBox ID="chksetRemainderforEmail" runat="server" CssClass="form-label" />
                                                                        <asp:Label ID="lblsetRemainderforEmail" runat="server" Text="Send also an email for this reminder" CssClass="form-label"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="mb-2">
                                                                    <div class="row">
                                                                        <center>
                                                                            <div class="col-md-12 col-sm-12 col-ld-12 col-xs-12 ">
                                                                                <asp:Button ID="btnRemainderSave" runat="server" CssClass="btn btn-sm btn-primary " OnClick="btnRemainderSave_Click" Text="Save" />
                                                                                &nbsp;
                                                                                <asp:Button ID="btnCloseReminder" runat="server" CssClass="btn btn-sm btn-danger " Text="Close" />
                                                                            </div>
                                                                        </center>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <br />
                                </div>
                                <div class="tab-pane p-20" id="OtherTickets" role="tabpanel">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">

                                            <asp:GridView ID="GVTotalTicket" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover table-responsive" OnRowDataBound="GVTicket_RowDataBound" AutoGenerateColumns="false" CellPadding="4" Width="100%"
                                                ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px"/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Subject" SortExpression="Subject" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblSubject" runat="server" Text='<%# Bind("Subject") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSubject1" runat="server" Text='<%# Bind("Subject") %>' Visible="true" TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

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
                                                    <asp:TemplateField HeaderText="Services" SortExpression="Services" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblServices" runat="server" Text='<%# Bind("Services") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblServices1" runat="server" Text='<%# Bind("Services") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Contact" SortExpression="Raise_By" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblRaiseBy" runat="server" Text='<%# Bind("Raise_By") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRaiseBy1" runat="server" Text='<%# Bind("Raise_By") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Status" SortExpression="StatusName" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblStatusNamee" runat="server" Text='<%# Bind("StatusName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatusNamee1" runat="server" Text='<%# Bind("StatusName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Priority" SortExpression="Priority" Visible="true" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblPriority" runat="server" Text='<%# Bind("Priority") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPriority1" runat="server" Text='<%# Bind("Priority") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Created" SortExpression="Createby" HeaderStyle-Font-Size="12px">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblCreateby" runat="server" Text='<%# Bind("Createby") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCreateby1" runat="server" Text='<%# Bind("Createby") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status1" SortExpression="Status" HeaderStyle-Font-Size="12px" Visible="false">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatus1" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
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
                                <div class="tab-pane p-20" id="Tasks" role="tabpanel">
                                    <div class="container-fluid">
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 col-lg-12 col-12 col-xl-12">
                                            
                                                <div class="row">
                                                    <div id="addnewTask" runat="server" class="col-md-2 col-sm-2 col-2 col-lg-2">
                                                        <asp:Button ID="btn_New_Task" runat="server" Text="New Task" CssClass="btn btn-sm btn-primary col-md-1" OnClick="btnSaveTask_Click" Style="width: 90px;" />&nbsp;
                                                    </div>
                                                    <div class="col-md-6 col-sm-6 col-lg-6  col-6"></div>
                                                    <div id="Div1" runat="server" class="col-md-4 col-sm-4 col-4 col-lg-4">
                                                        <%--    <asp:Button ID="btn_Task_Overview" runat="server" Text="Task Overview" CssClass="btn btn-sm btn-primary col-md-2" Width="170px" BackColor="ForestGreen" ForeColor="White" OnClick="" />&nbsp;
                                                        --%>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                   
                                        <div class='row'>
                                            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 p-2">
                                                <h5>View Task Details</h5>
                                                <hr />
                                                <br />
                                                <div class="col-md-6 col-sm-6 col-lg-6">
                                                    <div class="bd-example">
                                                        <div class="btn-group">
                                                            <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                                            <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                                            <div class="dropdown-menu">
                                                                <asp:LinkButton ID="lnkbtnExcel" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="lnkbtnExcel_Click"></asp:LinkButton>
                                                                <asp:LinkButton ID="linkbtnPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnPDF_Click"></asp:LinkButton>

                                                            </div>
                                                        </div>
                                                        <asp:Button ID="btn_Visibility" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="btn_Visibility_Click" />
                                                        <asp:Button ID="BtnReloadTask" runat="server" Text="Reload" CssClass="btn btn-sm btn-sm btn-outline-info" OnClick="BtnReloadTask_Click" />
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <!------PDF code--------->

                                                    <asp:Image ID="Image1" runat="server" Style="display: none; border: 1px solid #ccc" Visible="false" />

                                                    <asp:Label ID="lbladdCompany11" runat="server" Text="" CssClass="font-bold text-dark " Visible="false"></asp:Label>
                                                    <asp:Label ID="lbladdress11" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblcompanyaddCity1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblcompanyaddState1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblcompanyaddCountry1" runat="server" Text="," Font-Size="12px" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblpincode" runat="server" Text="PIN:" CssClass=" font-bold" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblphone" runat="server" Text="Phone:" CssClass=" font-bold" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblphoneNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblvat" runat="server" Text="VAT NO:" CssClass=" font-bold" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblVatNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" CssClass=" font-bold" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblGSTNo1A" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                                    <!------PDF code--------->

                                                </div>
                                                <br />
                                                <div id="grd" style="width: 100%">
                                                    <asp:GridView ID="GridTask1" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover text-nowrap align-content-center" Style="width: 100%" AutoGenerateColumns="false" CellPadding="4"
                                                        ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" OnRowDataBound="GridTask1_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRowNumTask" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px"/>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Name" SortExpression="Subject" HeaderStyle-Font-Size="12px">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txttaskName" runat="server" Text='<%# Bind("Subject") %>' Font-Size="12px"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltaskName1" runat="server" Text='<%# Bind("Subject") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="StartDate" SortExpression="Start_Date" HeaderStyle-Font-Size="12px">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblStart_Date" runat="server" Text='<%#Bind("Start_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStart_Date1" runat="server" Text='<%#Bind("Start_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="DueDate" SortExpression="Due_Date" HeaderStyle-Font-Size="12px">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblDue_Date" runat="server" Text='<%#Bind("Due_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDue_Date1" runat="server" Text='<%#Bind("Due_Date","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="AssignedTo" SortExpression="AssignTo" HeaderStyle-Font-Size="12px" HeaderStyle-Width="180px">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblReletd_To" runat="server" Text='<%# Bind("AssignTo") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:BulletedList ID="bulletlist1" runat="server" BulletStyle="Circle" CssClass="" Width="170px">
                                                                    </asp:BulletedList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Status" SortExpression="TaskStatus" HeaderStyle-Font-Size="12px" HeaderStyle-Width="160px">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblTaskStatus" runat="server" Text='<%#Bind("TaskStatus") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlTaskStatus" runat="server" CssClass="form-control " AutoPostBack="true" OnSelectedIndexChanged="ddlTaskStatus_SelectedIndexChanged" Style="width: 160px">
                                                                        <asp:ListItem Text="In Progress" Value="In Progress"></asp:ListItem>
                                                                        <asp:ListItem Text="Mark as Started" Value="Mark as  Started"></asp:ListItem>
                                                                        <asp:ListItem Text="Mark as Not Started" Value="Mark as Not Started"></asp:ListItem>
                                                                        <asp:ListItem Text="Mark as Testing" Value="Mark as Testing"></asp:ListItem>
                                                                        <asp:ListItem Text="Mark as Awaiting Feedback" Value="Mark as Awaiting Feedback"></asp:ListItem>
                                                                        <asp:ListItem Text="Mark as Complete" Value="Mark as Complete"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:Label ID="lblTaskStatus1" runat="server" Text='<%#Bind("TaskStatus") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Status" SortExpression="Status" Visible="false">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblstatus" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnStatus" runat="server" Text='<%# Bind("Status") %>' CssClass="btn btn-info pull-left display-block mright5" TabIndex="126" />
                                                                    <asp:Label ID="lblstatus1" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false" Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Reapeted" SortExpression="Reapet_Every" HeaderStyle-Font-Size="12px" Visible="false">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblReapet_Every" runat="server" Text='<%# Bind("Reapet_Every") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblReapet_Every1" runat="server" Text='<%# Bind("Reapet_Every") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Priority" SortExpression="Priority" HeaderStyle-Font-Size="12px" HeaderStyle-Width="120px">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblPriority" runat="server" Text='<%# Bind("Priority") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form-control " AutoPostBack="true" OnSelectedIndexChanged="ddlPriority_SelectedIndexChanged" Style="width: 140px">
                                                                        <asp:ListItem Text="Medium" Value="Medium"></asp:ListItem>
                                                                        <asp:ListItem Text="High" Value="High"></asp:ListItem>
                                                                        <asp:ListItem Text="Low" Value="Low"></asp:ListItem>
                                                                        <asp:ListItem Text="Urgent" Value="Urgent"></asp:ListItem>
                                                                    </asp:DropDownList>

                                                                    <asp:Label ID="lblPriority1" runat="server" Text='<%# Bind("Priority") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Billable" SortExpression="Billable" Visible="false">
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblBillable" runat="server" Text='<%# Bind("Billable") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnBillable" runat="server" Text='<%# Bind("Billable") %>' CssClass="btn btn-info pull-left display-block mright5" TabIndex="126" />
                                                                    <asp:Label ID="lblBillable1" runat="server" Text='<%# Bind("Billable") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnEditTask" runat="server" CssClass="btn btn-sm btn-outline-info mb-3" OnClick="btnEditTask_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnDeleteTask" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteTask_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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
                                <div class="tab-pane p-20" id="Settings" role="tabpanel">
                                    <div class="row">
                                        <div class="col-md-6 col-sm-6 col-lg-6 col-xs-12 border-right">
                                            <hr />
                                            <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblsubject" runat="server" Text="Subject" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                    <asp:TextBox ID="txtsubject" runat="server" placeholder="Enter Subject" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtsubject" ErrorMessage="Enter  Subject" ForeColor="Red" ValidationGroup="Save" Font-Size="12px"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                <div class="row">
                                                    <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblcontact" runat="server" Text="Contact" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:DropDownList ID="ddlcontact" runat="server" CssClass="form-control form-select" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredContact" runat="server" ErrorMessage="Select Contact" ControlToValidate="ddlcontact" ForeColor="Red" Font-Bold="false" ValidationGroup="Save" InitialValue="0" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblProject" runat="server" Text="Project Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:DropDownList ID="ddlProject" runat="server" CssClass="form-control form-select">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredProject" runat="server" ErrorMessage="Select Project" ControlToValidate="ddlProject" ForeColor="Red" Font-Bold="false" ValidationGroup="Save" InitialValue="0" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                <div class="row">
                                                    <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblname" runat="server" Text="Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:TextBox ID="txtname" CssClass="form-control" placeholder="Enter Name" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="Requiredname" ControlToValidate="txtname" Display="Dynamic" runat="server" ErrorMessage="Please Select Name" ForeColor="Red" Font-Size="12px"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblemail" runat="server" Text="Email Address" CssClass="form-label"></asp:Label>
                                                            <asp:TextBox ID="txtemail" CssClass="form-control" placeholder="Enter Email Address" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                                        <div class="mb-2">
                                                            <asp:Label ID="lbldept" runat="server" Text="Department" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                            <asp:DropDownList ID="ddldepart" runat="server" CssClass="form-control form-select">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="Reqdepart" runat="server" ErrorMessage="Select Department" ControlToValidate="ddldepart" ForeColor="Red" Font-Bold="false" ValidationGroup="Save" InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                                        <div class="mb-2">
                                                            <asp:Label ID="lblSettingCC" runat="server" Text="CC" CssClass="form-label"></asp:Label>
                                                            <asp:TextBox ID="txtSettingCC" CssClass="form-control" placeholder="Enter cc" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                            <hr />
                                            <div class="col-md-12 col-sm-12 col-lg-12 col-xs-12">
                                                <div class="mb-2">
                                                    <asp:Label ID="lblbody" runat="server" Text="Ticket Body" Font-Bold="true" CssClass="form-label"></asp:Label>
                                                    <asp:TextBox ID="txtareabody" runat="server" placeholder="Enter Ticket Body" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                                    <br />
                                                    <asp:CheckBox ID="chkSettingSendMail" Text="&nbsp;  Send Email" runat="server" CssClass="form-label" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                            <hr />
                                            <div class="row">

                                                <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblassignticket" runat="server" Text="Assign ticket" Font-Bold="true" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                        <asp:DropDownList ID="ddlassign" runat="server" CssClass="form-control form-select">
                                                            <asp:ListItem>Nothing Selected</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="Requiredassign1" runat="server" ErrorMessage="Select Assined" ControlToValidate="ddlassign" ForeColor="Red" Font-Bold="false" ValidationGroup="Save" InitialValue="0" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                                    <div class="mb-2">
                                                        <asp:Label ID="Label10" runat="server" Text="Status Name" Font-Bold="true" CssClass="form-label"></asp:Label>
                                                        <asp:DropDownList ID="ddlstatussetting" runat="server" CssClass="form-control form-select">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>

                                                <div class="col-md-6 col-sm-6 col-lg-6 col-xs-6">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblprioprity" runat="server" Text="Priority" Font-Bold="true" CssClass="form-label"></asp:Label>
                                                        <asp:DropDownList ID="ddlpriority" runat="server" CssClass="form-control form-select">
                                                            <asp:ListItem>Nothing Selected</asp:ListItem>
                                                            <asp:ListItem>Low</asp:ListItem>
                                                            <asp:ListItem>Medium</asp:ListItem>
                                                            <asp:ListItem>High</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 col-sm-6 col-lg-6">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblService" runat="server" Text="Service" CssClass="form-label"></asp:Label>
                                                        <asp:TextBox ID="txtservice" runat="server" placeholder="Service" CssClass="form-control"></asp:TextBox>

                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 col-sm-12 col-lg-12  col-xs-12">
                                        
                                            <div class="mb-2 text-end">
                                                <asp:Button ID="btn_Saveticket" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="Save" OnClick="btn_Saveticket_Click" />
                                                &nbsp;&nbsp;
                                          <%--   <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click1" CssClass="btn btn-danger" />--%>
                                            </div>
                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <br />
            <div class="container-fluid">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-2 col-sm-2 col-lg-2 col-xs-2">
                                <asp:Label ID="lblstaffname" runat="server" Text="" CssClass="form-label"></asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="lblstaffProf" runat="server" Text="Staff" CssClass="form-label"></asp:Label>
                                <br />
                                <br />
                                <asp:LinkButton ID="LinkBtnconvtoTask" runat="server" CssClass="btn btn-sm btn-outline-dark  p-1 " OnClick="LinkBtnconvtoTask_Click">Convert To Task</asp:LinkButton>

                            </div>
                            <div class="col-md-2 col-sm-2 col-lg-2 col-xs-2 border-right">
                            </div>
                            <div class="col-md-8 col-sm-8 col-lg-8 col-xs-8">

                                <div id="initialTenderno" runat="server" visible="false">
                                    <asp:Label ID="lblInitialTicket1" runat="server" Text="Ticket Number" CssClass="form-label"></asp:Label>
                                    <asp:Label ID="lblInitialNumber" runat="server" Text="-" Font-Bold="true" CssClass="form-control col-1 col-md-1" ReadOnly="true"></asp:Label>
                                    <asp:TextBox ID="txtInitialTicket" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    <asp:Label ID="lblCustomerID" runat="server" Text="" Visible="false" Font-Bold="true" CssClass="form-control col-1 col-md-1" ReadOnly="true"></asp:Label>

                                </div>
                                <div class="table-responsive">
                                    <asp:GridView ID="GridTicketFile" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                        ClientIDMode="Static" ShowHeader="false" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblTicketFileId" runat="server" Text="FileName" CssClass="form-label" Visible="false"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTicketFileId1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblTicketFileName" runat="server" Text="FileName" CssClass="form-label"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTicketFileName1" runat="server" Text='<%# Bind("Tick_File") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDeleteExpensesFile" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-rounded btn-danger" Visible="false" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteExpensesFile_Click1"><i class="ti ti-trash"></i></asp:LinkButton>
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
            </div>
        </div>
    </div>

</asp:Content>


