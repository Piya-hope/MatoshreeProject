<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="ImportLeads.aspx.cs" Inherits="MatoshreeProject.ImportLeads" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link rel="text/css" href="https://cdn.datatabls.net/responsive/1.0.7/js/dataTabls.responsive.min.css" />

  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://cdn.datatabls.net/responsive/1.10.9/js/jquery.min.js"></script>
  <script type="text/javascript" src="https://cdn.datatabls.net/responsive/1.0.7/js/dataTabls.responsive.min.js"></script>
  <script type="text/javascript" src="https://cdn.datatabls.net/1.10.9/js/dataTabls.bootstrap.min.js"></script>
  <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
  <script type="text/javascript">
      $(document).ready(function () {
          var GridImportLeads = $("#GridImportLeads").prepend($("<thead></thead>").append($("#GridImportLeads").find("tr:first"))).DataTable(
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


        <%-- BreadCrumbs --%>
        <%-- Toaster --%>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">

                <div class="row">
                    <div class="col-md-7 col-sm-7 col-xl-7 col-lg-7">
                        <%-- BreadCrumbs --%>
                        <h5>Import Leads Sheet</h5>
                        <nav aria-label="breadcrumb">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item">
                                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                                    </a>
                                </li>
                                <li class="breadcrumb-item text-muted" href="ViewLead">Leads</li>
                                <li class="breadcrumb-item text-muted" aria-current="page" href="ImportLeads.aspx">Leads Excel Sheet</li>

                            </ol>
                        </nav>
                    </div>
                    <%-- Toaster --%>
                    <div class="col-md-5 col-sm-5 col-xl-5 col-lg-5">
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
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
                        <div class="card  bg-primary-subtle 
                          ">
                            <div class="card-body">
                                <asp:Label ID="lbl1" Text="1.Your Excel Data Should be in the format below.The first line of your Excel file should be the column headers as in the table example. Also make sure that your file is UTF-8 to
                                   avoid unnecessary encoding problems."
                                    runat="server" Font-Size="12px" CssClass="form-label text-primary"></asp:Label>
                                <br />
                                <asp:Label ID="lbl2" Text="2.If the column you are trying to import is date make sure that is formatted in format Y-m-d(2024-06-01)" Font-Size="12px" runat="server" CssClass="form-label  text-primary"></asp:Label>
                                <br />
                                <asp:Label ID="lbl3" Text="3.Duplicate email rows won't be imported." runat="server" Font-Size="12px" CssClass="form-label text-danger"></asp:Label>
                            </div>

                        </div>
                    </div>
                </div>


                <div class="row">
                    <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6">
                        <h5>Import Excel Sheet</h5>
                    </div>
                    <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6 text-end">
                        <asp:LinkButton ID="btnDownload" runat="server" CausesValidation="false" OnClick="btnDownload_Click" CssClass="btn btn-sm btn-success">Download Sample<i class="ti ti-download"></i></asp:LinkButton>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <asp:Label ID="lblStaffId" Text="" runat="server" CssClass="form-label" Visible="false"></asp:Label>
                                    <asp:Label ID="lblStaffId1" Text="" runat="server" CssClass="form-label" Visible="false"></asp:Label>
                                    <asp:Label ID="lblshiftHours" Text="" runat="server" CssClass="form-label" Visible="false"></asp:Label>
                                    <asp:Label ID="lblempPass" Text="" runat="server" CssClass="form-label" Visible="false"></asp:Label>
                                    <asp:Label ID="lblshiftstaffid" Text="" runat="server" CssClass="form-label" Visible="false"></asp:Label>
                                    <asp:Label ID="lblNameShift11" Text="" runat="server" CssClass="form-label" Visible="false"></asp:Label>
                                    <asp:Label ID="lblShiftID" Text="" runat="server" CssClass="form-label" Visible="false"></asp:Label>
                                    <asp:Label ID="lblLeabveMarkID" Text="" runat="server" CssClass="form-label" Visible="false"></asp:Label>
                                    <asp:Label ID="lblMarkName" Text="" runat="server" CssClass="form-label" Visible="false"></asp:Label>
                                    <asp:Label ID="lblMarkCount" Text="" runat="server" CssClass="form-label" Visible="false"></asp:Label>

                                    <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
                                        <asp:GridView ID="GridImportLeads" runat="server" ScrollBars="Both" CssClass="table border table-hover table-bordered text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                                            <Columns>
                                                <asp:BoundField DataField="Id" HeaderText="Id" HeaderStyle-Font-Size="12px" />
                                                <asp:BoundField DataField="Name" HeaderText="Name" HeaderStyle-Font-Size="12px" />
                                                <asp:BoundField DataField="Address" HeaderText="Address" HeaderStyle-Font-Size="12px" />
                                                 <asp:BoundField DataField="Role" HeaderText="Role" HeaderStyle-Font-Size="12px" />
                                                 <asp:BoundField DataField="City" HeaderText="City" HeaderStyle-Font-Size="12px" />
                                                 <asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-Font-Size="12px" />
                                                 <asp:BoundField DataField="Website" HeaderText="Website" HeaderStyle-Font-Size="12px" />
                                                <asp:BoundField DataField="Phone" HeaderText="Phone" HeaderStyle-Font-Size="12px" />
                                                <asp:BoundField DataField="LeadValue" HeaderText="LeadValue" HeaderStyle-Font-Size="12px" />
                                                <asp:BoundField DataField="DefaultLanguage" HeaderText="DefaultLanguage" HeaderStyle-Font-Size="12px" />
                                                <asp:BoundField DataField="Company" HeaderText="Company" HeaderStyle-Font-Size="12px" />
                                                <asp:BoundField DataField="SourceName" HeaderText="SourceName" HeaderStyle-Font-Size="12px" />
                                                <asp:BoundField DataField="AssignedName" HeaderText="AssignedName" HeaderStyle-Font-Size="12px" />
                                                <asp:BoundField DataField="ContactDate" HeaderText="ContactDate" HeaderStyle-Font-Size="12px" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-16 col-lg-6 col-sm-6 col-xs-6">
                                        <asp:Label ID="lblLeaveFileId" runat="server" Text="Choose File" Font-Size="12px" Font-Bold="true"></asp:Label>

                                        <div class="mb-2">
                                            <div class="input-group">
                                                <asp:FileUpload ID="FileUpload" runat="server" Font-Size="12px" CssClass="form-control mdi-file-import" />

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6"></div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6">
                                        <asp:Label ID="lblPassword" runat="server" Text="" Font-Size="12px" Visible="false" Font-Bold="false"></asp:Label>
                                        <asp:Label ID="lblPassword1" runat="server" Text="Password" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        <asp:TextBox ID="txtPassword" CssClass="form-control" Font-Size="12px" Style="display: inline-block;" runat="server" placeholder="Enter Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" ErrorMessage="Enter Password" Font-Size="12px" ForeColor="Red" Display="Dynamic" ValidationGroup="Import">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6"></div>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6">
                                        <div class="mb-2">
                                            <asp:Button ID="btnImport" runat="server" Text="Import" CssClass="btn btn-sm btn-primary" ValidationGroup="Import" OnClick="btnImport_Click" />
                                            &nbsp;&nbsp;
                                    <asp:Button ID="btnClear" runat="server" Text="Close" CssClass="btn btn-sm btn-danger " ValidationGroup="clearLM" />
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
