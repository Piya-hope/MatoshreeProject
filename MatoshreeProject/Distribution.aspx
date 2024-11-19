<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Distribution.aspx.cs" Inherits="MatoshreeProject.Distribution" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {

            var GridDistribution = $("#GridDistribution").prepend($("<thead></thead>").append($("#GridDistribution").find("tr:first"))).DataTable(
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
        <h5 class="font-weight-medium mb-0">Distribution</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="Distribution.aspx">Distribution</li>
            </ol>
        </nav>
        <br />

        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <div id="addnew" runat="server">
                    <div class="row">

                        <div class="Col-md-2 col-lg-2 col-sm-2 col-xs-2">
                            <asp:Button ID="btnDistribution" runat="server" Text="New Distribution" CssClass="btn btn-primary btn-sm " OnClick="btnDistribution_Click" />
                        </div>
                    </div>
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
        <br />
        <br />
        <div class="row">
            <div class="card">
                <div class="card-body">
                    <div class="col-md-12 col-sm-12 col-lg-12">
                        <div class="row">
                            <div class="col-md-3 col-sm-3 col-lg-3 align-items-start">
                                <h5>View Distribution Details</h5>
                            </div>
                            
                             <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:Label ID="lblProjname" runat="server" Text="Project:" CssClass="form-label"></asp:Label>
                            </div>
                            <div class="col-md-3 col-sm-3 col-lg-3 text-end">
                                <asp:DropDownList ID="ddlProjectName" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlProjectName_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>

                            </div>
                            <div class="col-md-1 col-sm-1 col-lg-1">
                                <asp:Label ID="lblDeponame" runat="server" Text="Depo:" CssClass="form-label"></asp:Label>
                            </div>
                            <div class="col-md-3 col-sm-3 col-lg-3 text-end">
                                <asp:DropDownList ID="ddldeponame" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddldeponame_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                                <div class="bd-example">
                                    <div class="btn-group">
                                        <button class="btn btn-sm btn-outline-success  dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                        <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                        <div class="dropdown-menu">
                                            <asp:LinkButton ID="lnkbtnExcel" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="lnkbtnExcel_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="linkbtnPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnPDF_Click"></asp:LinkButton>

                                        </div>
                                    </div>

                                    <asp:Button ID="Btn_Visiblity" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info " OnClick="Btn_Visiblity_Click" />
                                    <asp:Button ID="btn_Reload" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info " OnClick="btn_Reload_Click1" />

                                </div>
                            </div>

                            <div class="col-md-4">
                                <!------PDF code--------->

                                <asp:Image ID="Image1" runat="server" Style="display: none; border: 1px solid #ccc" />

                                <asp:Label ID="lbladdCompany11" runat="server" Text="" CssClass="font-bold text-dark font-14" Visible="false"></asp:Label>
                                <asp:Label ID="lbladdress11" runat="server" Text="" CssClass="font-14" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddCity1" runat="server" Text="" CssClass="font-14" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddDistrict1" runat="server" Text="" CssClass="font-14" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddState1" runat="server" Text="" CssClass="font-14" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddCountry1" runat="server" Text="," Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblpincode" runat="server" Text="PIN:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblcompanyaddZIPCode11" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblphone" runat="server" Text="Phone:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblphoneNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblvat" runat="server" Text="VAT NO:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblVatNo1" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblCompanygstno" runat="server" Text="GST NO:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblGSTNo1A" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <!------PDF code--------->

                            </div>

                            <div class="col-md-4">
                                <!------PDF code--------->


                                <asp:Label ID="lblProjectName1" runat="server" Text="" CssClass="font-14" Visible="false"></asp:Label>
                                <asp:Label ID="lblProjectAddress" runat="server" Text="" CssClass="font-14" Visible="false"></asp:Label>
                                <asp:Label ID="lblDeponame1A" runat="server" Text="" CssClass="font-14" Visible="false"></asp:Label>
                                <asp:Label ID="lblDepoAddresss" runat="server" Text="" CssClass="font-14" Visible="false"></asp:Label>
                                <asp:Label ID="lblSendBy" runat="server" Text="," Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblDestribute" runat="server" Text="PIN:" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="lblSendbyRole" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lbldestributebyrole" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <!------PDF code--------->

                            </div>
                        </div>
                        <br />
        
                        <asp:GridView ID="GridDistribution" runat="server" ScrollBars="Both" CssClass="table border table-bordered table-responsive table-hover text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                            ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" OnRowDataBound="GridDistribution_RowDataBound" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID">
                            <Columns>
                                <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
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
                                <asp:TemplateField HeaderText="ProjectName" SortExpression="ProjectName" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProjectId" runat="server" Text='<%# Bind("ProjectID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                        <asp:Label ID="lblProjectName1" runat="server" Text='<%# Bind("ProjectName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                        <asp:LinkButton ID="LinkProjectName" runat="server" Text='<%# Bind("ProjectName") %>' Font-Size="12px" CssClass="text-info" OnClick="LinkProjectName_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="DepoName" SortExpression="DepoName" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblDepoName" runat="server" Text='<%# Bind("DepoName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDepoID" runat="server" Text='<%# Bind("DepoID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                        <asp:Label ID="lblDepoName1" runat="server" Text='<%# Bind("DepoName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ProductName" SortExpression="DepoName" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("ProductName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>

                                        <asp:Label ID="lblProductName1" runat="server" Text='<%# Bind("ProductName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="DistibuteBy" SortExpression="DistibuteBy" HeaderStyle-Width="130px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblDistibuteBy" runat="server" Text='<%# Bind("DestributeBy") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDistibuteBy1" runat="server" Text='<%# Bind("DestributeBy") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="SendByRole" SortExpression="DistibuteBy" HeaderStyle-Width="130px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblRole" runat="server" Text='<%# Bind("Role") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRole1" runat="server" Text='<%# Bind("Role") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="SendBy" SortExpression="SendBy" HeaderStyle-Width="130px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblSendBy" runat="server" Text='<%# Bind("SendBy") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSendBy1" runat="server" Text='<%# Bind("SendBy") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Quantity" SortExpression="DistQuantity" HeaderStyle-Width="130px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblDistQuantity" runat="server" Text='<%# Bind("DistQuantity") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDistQuantity1" runat="server" Text='<%# Bind("DistQuantity") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Instock" SortExpression="Instock" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblInstock" runat="server" Text='<%# Bind("Instock") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblInstock1" runat="server" Text='<%# Bind("Instock") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="OnField" SortExpression="OnField" HeaderStyle-Width="180px" HeaderStyle-Font-Size="12px" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblOnField" runat="server" Text='<%# Bind("OnField") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblOnField1" runat="server" Text='<%# Bind("OnField") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Remark" SortExpression="OnField" HeaderStyle-Width="180px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemark1" runat="server" Text='<%# Bind("Remark") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Trash" SortExpression="OnField" HeaderStyle-Width="180px" HeaderStyle-Font-Size="12px" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblTrash" runat="server" Text='<%# Bind("Trash") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblTrash1" runat="server" Text='<%# Bind("Trash") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" SortExpression="Status" HeaderStyle-Font-Size="12px" Visible="false">
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
        </div>
</div>
    </div>

</asp:Content>
