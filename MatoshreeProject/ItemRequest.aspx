<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="ItemRequest.aspx.cs" Inherits="MatoshreeProject.ItemRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var GridItemRequest = $("#GridItemRequest").prepend($("<thead></thead>").append($("#GridItemRequest").find("tr:first"))).DataTable(
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
        <h5 class="font-weight-medium mb-0">Item Request</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="ItemRequest.aspx">ItemRequest</li>
            </ol>
        </nav>
        <%-- BreadCrumbs --%>
        <br />
        <br />
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                <br />
                <div class="row">
                    <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                        <div id="addnew" runat="server">
                            <asp:Button ID="btnNewInveItemRequest" runat="server" Text="New Item Request" CssClass="btn btn-sm btn-primary" OnClick="btnNewInveItemRequest_Click" />

                        </div>
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
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-lg-12">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <h5>Notifications Received Prelist From Project </h5>
                                    <hr />
                                    <div class="col-md-6 col-sm-6 col-xs-6 col-lg-6 border-right">
                                      
                                        <div class="mb-0 fw-medium text-black">
                                            Accepted Project  Prelist Count:
                                                 <asp:Label ID="lblAccepted" runat="server" Text="" CssClass="text-success"></asp:Label>

                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-6 col-lg-6">
                                        <div class="mb-0 fw-medium text-black">
                                            You have New &nbsp;  <iconify-icon icon="solar:bell-bing-line-duotone"></iconify-icon>
                                              
                                                 <asp:Label ID="lblRequestCount" runat="server" Text="" CssClass="text-danger"></asp:Label>
                                            &nbsp; Request Prelist Notifications
                                        </div>
                                       
                                    </div>
                                    <br />
                                    <asp:LinkButton ID="linkbtnForAlert" runat="server" CausesValidation="false" CssClass="text-success" Text="Click Here View Prelist Project Request" OnClick="linkbtnForAlert_Click"></asp:LinkButton>
                                
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <h5>Item Request Summary</h5>
                <div class="row">
                    <div class="col-lg-4 col-md-6">
                        <div class="card border-bottom border-success">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblTotalItemRequestCount" CssClass="text-center text-dark" runat="server" Text=""></asp:Label><br />
                                        </h2>
                                        <h6 class="fw-medium text-success mb-0">
                                            <asp:Label ID="lblTotalItemRequest" runat="server" Text="Total Item Request" CssClass="text-success"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-success display-6">
                                            <iconify-icon icon="fluent-mdl2:assign-policy" class="aside-icon"></iconify-icon>
                                        </span>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6">
                        <div class="card border-bottom border-info">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblActiveItemRequestCount" runat="server" CssClass="text-center text-dark" Text=""></asp:Label><br />
                                        </h2>
                                        <h6 class="fw-medium text-info mb-0">
                                            <asp:Label ID="lblActiveItemRequest" runat="server" Text="Active Item Request" CssClass="text-info"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-info display-6">
                                            <iconify-icon icon="fluent-mdl2:assign-policy" class="aside-icon"></iconify-icon>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6">
                        <div class="card border-bottom border-danger">
                            <div class="card-body">
                                <div class="d-flex align-items-center">
                                    <div>
                                        <h2 class="fs-7">
                                            <asp:Label ID="lblInActiveItemRequestCount" runat="server" CssClass="text-center text-dark" Text=""></asp:Label><br />
                                        </h2>
                                        <h6 class="fw-medium text-danger mb-0">
                                            <asp:Label ID="lblInActiveItemRequest" runat="server" Text="Inactive Item Request" CssClass="text-danger"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="ms-auto">
                                        <span class="text-danger display-6">
                                            <iconify-icon icon="fluent-mdl2:assign-policy" class="aside-icon"></iconify-icon>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">

                            <div class="col-md-3 col-sm-3 col-xs-3 col-lg-3">
                                <h5>View Item Request Details</h5>

                            </div>
                            <div class="col-md-3 col-sm-3 col-xs-3 col-lg-3">
                            </div>
                            <div class="col-md-3 col-sm-3 col-xs-3 col-lg-3">
                                <asp:DropDownList ID="ddlProjects" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlProjects_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-3 col-sm-3 col-xs-3 col-lg-3">
                                <asp:DropDownList ID="ddlDepo" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlDepo_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>

                        </div>
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

                            <div class="col-md-2">
                                <asp:Image ID="Image1" runat="server" Style="display: none; border: 1px solid #ccc" />
                                <asp:Label ID="lbladdCompany11" runat="server" Text="" CssClass="font-bold text-dark font-14" Visible="false"></asp:Label>
                                <asp:Label ID="lbladdress11" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddCity1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddState1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddCountry1" runat="server" Text="," Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblpincode" runat="server" Text="PIN:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblphone" runat="server" Text="Phone:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblphoneNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblvat" runat="server" Text="VAT NO:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblVatNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblGSTNo1A" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                            </div>


                            <div class="col-md-2">
                                <!------PDF code--------->


                                <asp:Label ID="lblProjectName1" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblProjectAddress" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblDeponame1A" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblDepoAddresss" runat="server" Text="" CssClass="" Visible="false"></asp:Label>
                                <asp:Label ID="lblSendBy" runat="server" Text="," Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblDestribute" runat="server" Text="PIN:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblSendbyRole" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lbldestributebyrole" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <!------PDF code--------->

                            </div>

                        </div>
                        <br />
                        <br />

                        <asp:GridView ID="GridItemRequest" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridItemRequest_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblItemRequestID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemRequestID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ProductName" SortExpression="ProductName" HeaderStyle-Font-Size="12px" HeaderStyle-Width="140px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("ProductName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductName1" runat="server" Text='<%# Bind("ProductName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DepoName" SortExpression="DepoName" HeaderStyle-Font-Size="12px" HeaderStyle-Width="140px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblDepo" runat="server" Text='<%# Bind("DepoName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDepoID" runat="server" Text='<%# Bind("DepoID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                        <asp:Label ID="lblDepo1" runat="server" Text='<%# Bind("DepoName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ProjectName" SortExpression="ProjectName" HeaderStyle-Font-Size="12px" HeaderStyle-Width="140px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblProject" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblProject1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Usable" SortExpression="ProductType" HeaderStyle-Font-Size="12px" HeaderStyle-Width="140px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblProductType" runat="server" Text='<%# Bind("ProductType") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductType1" runat="server" Text='<%# Bind("ProductType") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity" HeaderStyle-Font-Size="12px" HeaderStyle-Width="90px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuantity1" runat="server" Text='<%# Bind("Quantity") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Rate" SortExpression="Rate" HeaderStyle-Font-Size="12px" HeaderStyle-Width="90px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblRate" runat="server" Text='<%# Bind("Rate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRate1" runat="server" Text='<%# Bind("Rate") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="StaffName" SortExpression="StaffName" HeaderStyle-Font-Size="12px" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblStaffName" runat="server" Text='<%# Bind("StaffName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStaffName1" runat="server" Text='<%# Bind("StaffName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RequestDate" SortExpression="RequestDate" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblRequestDate" runat="server" Text='<%# Bind("RequestDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRequestDate1" runat="server" Text='<%# Bind("RequestDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="RequestApproval" SortExpression="RequestApproval" HeaderStyle-Font-Size="12px" HeaderStyle-Width="90px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblReqApprove" runat="server" Text='<%# Bind("RequestApproval") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkReqApp" runat="server" Checked='<%#Bind("RequestApproval") %>' OnCheckedChanged="ChkReqApp_CheckedChanged" AutoPostBack="true" />

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Status" SortExpression="Status" HeaderStyle-Font-Size="12px" HeaderStyle-Width="120px" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus1" runat="server" Text='<%# Bind("Status") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="RequestApproveBy" SortExpression="ReqApproveBy" HeaderStyle-Font-Size="12px" HeaderStyle-Width="120px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblReqAppBy" runat="server" Text='<%# Bind("ReqApproveBy") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblReqAppBy1A" runat="server" Text='<%# Bind("ReqApproveBy") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="RequestApproveDate" SortExpression="RequestApproveDate" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblRequestApproveDate" runat="server" Text='<%# Bind("ReqApproveDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblReqAppDate1" runat="server" Text='<%# Bind("ReqApproveDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>




                                <asp:TemplateField HeaderStyle-Font-Size="12px">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblCreateBy" runat="server" Text="AddedBy" CssClass="font-12"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreateBy1" runat="server" Text='<%#Bind("UserName") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Font-Size="12px">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblRemark" runat="server" Text="Remark" Font-Size="12px"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemark1" runat="server" Text='<%#Bind("Remark") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Font-Size="12px" Visible="false">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblInstock" runat="server" Text="Instock" Font-Size="12px"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblInstock1" runat="server" Text='<%#Bind("Instock") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
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
    </div>
</asp:Content>
