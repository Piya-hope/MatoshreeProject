<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Calender.aspx.cs" Inherits="MatoshreeProject.Calender" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var GridActivityReport = $("#GridActivityReport").prepend($("<thead></thead>").append($("#GridActivityReport").find("tr:first"))).DataTable(
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
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-8 col-lg-8 col-sm-8">
                    <h5 class="font-weight-medium mb-0">Calendar</h5>
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item">
                                <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                                </a>
                            </li>
                            <li class="breadcrumb-item">
                                <a class="text-muted text-decoration-none" href="#">SETUP
                                </a>
                            </li>
                            <li class="breadcrumb-item text-muted" aria-current="page" href="Calender.aspx">Calendar</li>
                        </ol>
                    </nav>
                </div>
                <%-- Toaster --%>
                <div class="col-md-4 col-sm-4 col-xl-4 col-lg-4">
                    <div id="Toasteralert" runat="server" visible="false">
                        <div class="toast" role="alert" aria-live="assertive" aria-atomic="true">
                            <div class="d-flex">
                                <div class="toast-body">
                                    <asp:Label ID="Label1" runat="server" Text="" Font-Size="13.5px" ForeColor="Black"></asp:Label>
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
                <div class="col-md-12 col-sm-12 col-lg-12  col-xs-12">
                    <h5>Calendar</h5>
                    <br />
                    <div class="row justify-content-center">
                        <div class="card-body">
                            <div class="table-responsive">
                                <div class="col-12 col-md-12 col-lg-12">
                                    <asp:Calendar ID="Calendar1" runat="server" Width="100%" Height="120%" CssClass="table table-bordered"
                                        OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged"
                                        OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399">
                                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                        <OtherMonthDayStyle ForeColor="#999999" />
                                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                        <WeekendDayStyle BackColor="#CCCCFF" />

                                    </asp:Calendar>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <b>
                        <asp:Label ID="LabelAction" runat="server"></asp:Label>
                    </b>
                  
                    <br />
                    <div class="row">
                         <div class="col-md-2 col-sm-2 col-lg-2 col-xs-2">
                            <button type="button" id="btnhide" runat="server" class="btn btn-info btn-sm font-medium" data-bs-toggle="modal" data-bs-target="#ItemID">Add New Event</button>
                        </div>
                        <div class="col-md-10 col-sm-10 col-lg-10 col-xs-10">
                            <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                        </div>
                       
                    </div>

                    <br />


                    <div class="card">
                        <div class="card-body">
                            <h5>View Event List</h5>
                            <hr />
                            <div class="row">
                                <div class="col-sm-4 col-md-4 col-lg-4">
                                     <div class="mb-2">
                                        <asp:Label ID="Label3" runat="server" Text="Event Type"></asp:Label>
                                        <asp:DropDownList ID="ddlEventType" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlEventType_SelectedIndexChanged">
                                            <asp:ListItem Value="1" Text="Official"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Personal"></asp:ListItem>                                          
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="GVCalendar" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" Width="100%" Height="80%"
                                    CellPadding="1" CssClass="table table-bordered table-striped table-hover"
                                    EmptyDataText="No Records found" ShowHeaderWhenEmpty="True"
                                    EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false" HeaderStyle-Font-Size="12px">
                                            <EditItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="StartDate" SortExpression="StartDate" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStart" runat="server" Text='<%#Bind("StartDate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="EndDate" SortExpression="EndDate" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEnd" runat="server" Text='<%#Bind("EndDate","{0:dd/MM/yyyy}") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="EventTitle" SortExpression="EventTitle" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEvent" runat="server" Text='<%# Bind("EventTitle") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDeletecust" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeletecust_Click"><i class="ti ti-trash"></i></asp:LinkButton>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="bg-primary text-white" />
                                    <RowStyle CssClass="bg-blue" />
                                    <AlternatingRowStyle CssClass="bg-white" />
                                    <SelectedRowStyle CssClass="bg-info text-white" />
                                    <PagerStyle CssClass="pagination justify-content-center" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>


                    <div class="modal fade" id="ItemID" data-bs-backdrop="static"
                        data-bs-keyboard="false" tabindex="-1" aria-labelledby="scroll-long-inner-modal"
                        aria-hidden="true">
                        <div class="modal-dialog modal-dialog-scrollable">
                            <div class="modal-content">
                                <div class="modal-header d-flex align-items-center">
                                    <h4 class="modal-title" id="myLargeModalLabel">Add Event</h4>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">
                                    <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
                                    <div class="mb-2">
                                        <asp:Label ID="lblEventTitlecal" runat="server" Text="Event Title"></asp:Label> &nbsp;<span id="ct6_Email" style="color: red;">* </span>
                                        <asp:TextBox ID="EventTitle" runat="server" CssClass="form-control" placholder="Enter Event"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqEventTitle" runat="server" ErrorMessage="Enter Event Name" Display="Dynamic" ControlToValidate="EventTitle" ForeColor="Red" ValidationGroup="Saveevent1" Font-Size="12px"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="mb-2">
                                        <asp:Label ID="lbleventColor" runat="server" Text="Event Color"></asp:Label>
                                        <asp:DropDownList ID="ddlEventColor" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="text-danger">Danger</asp:ListItem>
                                            <asp:ListItem Value="text-success">Success</asp:ListItem>
                                            <asp:ListItem Value="text-primary">Primary</asp:ListItem>
                                            <asp:ListItem Value="text-warning">Warning</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="mb-2">
                                        <asp:Label ID="Label6" runat="server" Text="Start Date"></asp:Label>&nbsp;<span id="ct6_Email1" style="color: red;">* </span>
                                        <asp:TextBox ID="startDate1" runat="server" type="date" CssClass="form-control"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="restart" runat="server" ErrorMessage="Enter Event Start Date" Display="Dynamic" ControlToValidate="startDate1" ForeColor="Red" ValidationGroup="Saveevent1" Font-Size="12px"></asp:RequiredFieldValidator>
                                
                                    </div>
                                    <div class="mb-2">

                                        <asp:Label ID="Label7" runat="server" Text="End Date"></asp:Label>
                                        <asp:TextBox ID="EndDate1" runat="server" type="date" CssClass="form-control"></asp:TextBox>
                                    </div>
                                     <div class="mb-2">
                                        <asp:Label ID="Label2" runat="server" Text="Event Type"></asp:Label>&nbsp;<span id="ct6_Email12" style="color: red;">* </span>
                                        <asp:DropDownList ID="ddlEventType1" runat="server" CssClass="form-control">
                                              <asp:ListItem Value="0" Text="Select Event Type"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Official"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Personal"></asp:ListItem>                                          
                                        </asp:DropDownList>
                                           <asp:RequiredFieldValidator ID="reqEventype" runat="server" ErrorMessage="Select Event Type" Display="Dynamic" ControlToValidate="ddlEventType1" InitialValue="0" ForeColor="Red" ValidationGroup="Saveevent1" Font-Size="12px"></asp:RequiredFieldValidator>
                                
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnSaveEvent" runat="server" CssClass="btn btn-primary btn-sm" Text="Save Event" ValidationGroup="Saveevent1" OnClick="btnSaveEvent_Click" />
                                    <asp:Button ID="Btn_Close" runat="server" Text="Close" ValidationGroup="cl5" OnClick="Btn_Close_Click" CssClass="btn btn-sm btn-danger rounded-3" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
