<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="ViewPreSalStructure.aspx.cs" Inherits="MatoshreeProject.ViewPreSalStructure" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var GridViewCompansion = $("#GridViewComponent").prepend($("<thead></thead>").append($("#GridViewComponent").find("tr:first"))).DataTable(
                {
                    "order": false,
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridViewCompansion = $("#GridViewEmpCompansion").prepend($("<thead></thead>").append($("#GridViewEmpCompansion").find("tr:first"))).DataTable(
                {
                    "order": false,
                    "responsive": true,
                    "scrollY": "300px",
                    "scrollX": "80%",
                    "scrollCollapse": true,
                    "searching": true,
                    "paging": true,
                });

            var GridViewPreSalaryStructure = $("#GridViewPreSalaryStructure").prepend($("<thead></thead>").append($("#GridViewPreSalaryStructure").find("tr:first"))).DataTable(
                {
                    "order": false,
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
        <h5 class="font-weight-medium mb-0">PreSalaryStructure</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="ViewPreSalStructure.aspx">ViewPreSalStructure</li>
            </ol>
        </nav>
        <%-- BreadCrumbs --%>


        <div class="row">
            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                <br />
                <div class="row">
                    <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                        <div id="addnew" runat="server">
                            <asp:Button ID="btnNewPreSalaryStructure" runat="server" Text="New PreSalStructure" CssClass="btn btn-sm btn-primary" OnClick="btnNewPreSalaryStructure_Click" />
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

            </div>

            <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <h5 class="font-weight-medium mt-3 mb-3">View PreSalaryStructure Details</h5>
                        <hr />

                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-lg-12">
                                <div class="col-md-4 col-sm-4 col-lg-4">
                                    <div class="form-group">
                                        <asp:Label ID="lblClass" runat="server" Text="Class" Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label><%--&nbsp;<span style="color: #FF0000">*</span>--%>
                                        <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" Visible="false">
                                        </asp:DropDownList>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlClass"
                                            ForeColor="Red" Font-Size="12px" Font-Bold="false"
                                            InitialValue="0" Display="Dynamic"
                                            ValidationGroup="SaveValidate"
                                            ErrorMessage="Please select a class."></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                                <div class="bd-example">
                                    <div class="btn-group">
                                        <button class="btn btn-sm btn-outline-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                        <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                        <div class="dropdown-menu">
                                           <%--    <asp:LinkButton ID="lnkbtnExcelViewPreSalStruct" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="btnNewPreSalaryStructure_Click"></asp:LinkButton>
                                            --%>
                                             <asp:LinkButton ID="lnkbtnExcelViewPreSalStruct" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="lnkbtnExcelViewPreSalStruct_Click"></asp:LinkButton>
                                        
                                            <asp:LinkButton ID="linkbtnPDFViewPreSalStruct" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnPDFViewPreSalStruct_Click"></asp:LinkButton>

                                        </div>
                                    </div>
                                      <asp:Button ID="BTN_VisibilityViewPreSalStruct" runat="server" Text="Visibility" CssClass="btn btn-sm btn-outline-info" OnClick="BTN_VisibilityViewPreSalStruct_Click"/>

                                    <asp:Button ID="Btn_ReloadViewPreSalStruct" runat="server" Text="Reload" CssClass="btn btn-sm btn-outline-info" OnClick="Btn_ReloadViewPreSalStruct_Click"/>
                                    
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
                        <!-- Grid Class View Component -->
                        <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                            <asp:GridView ID="GridViewPreSalaryStructure" runat="server" ScrollBars="Both" CssClass="table border table-hover table-bordered " AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridViewPreSalaryStructure_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblSalClassID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSalClassID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ClassName" SortExpression="ClassName" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblSalClassName" runat="server" Text='<%# Bind("ClassName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnSalClassName1" Text='<%# Bind("ClassName") %>' runat="server" CssClass="dropdown-item" OnClick="lnkbtnSalClassName1_Click" Font-Bold="false" Font-Size="12px" Visible="false"></asp:LinkButton>

                                            <asp:Label ID="lblSalClassName1" runat="server" Text='<%# Bind("ClassName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CreateBy" SortExpression="CreateBy" HeaderStyle-Font-Size="12px">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblSalClassCreateby" runat="server" Text='<%# Bind("Createby") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSalClassCreateby1" runat="server" Text='<%# Bind("Createby") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Status" SortExpression="Status" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblSalClassStatus" runat="server" Text=""></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSalClassStatus1" runat="server" Text='<%# Bind("Status") %>' Visible="false"></asp:Label>
                                      <asp:Button ID="btnSalClassStatus" runat="server" Text='<%# Bind("Status") %>' OnClick="btnSalClassStatus_Click"  Font-Size="12px" />
                                    </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditSalClass" runat="server" CssClass="btn btn-sm btn-outline-info" OnClick="btnEditSalClass_Click"><i class="ti ti-edit"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDeleteSalClass" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" OnClientClick="return confirm('Are you sure you want to delete?')" OnClick="btnDeleteSalClass_Click"><i class="ti ti-trash"></i></asp:LinkButton>
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
                        <!-- Grid Class View Component END-->

                        <!-- Grid View Component -->
                        <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                            <asp:GridView ID="GridViewComponent" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" FooterStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="true" OnRowDataBound="GridViewComponent_RowDataBound">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblCompnent" runat="server" Text="Compnent" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <%--   <FooterTemplate>
                                       
                                            <asp:TextBox ID="txtCompnent" runat="server" TextMode="MultiLine" Text="" CssClass="form-control" Font-Size="12px" Placeholder="Compnent Name" Visible="false"></asp:TextBox>

                                        </FooterTemplate>--%>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCompnentID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                            <asp:Label ID="lblCompnentClassID" runat="server" Text='<%# Bind("ClassID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                            <asp:Label ID="lblComponentPertCateID" runat="server" Text='<%# Bind("PertCate_ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>

                                            <asp:Label ID="lblCompnent1" runat="server" Text='<%# Bind("Perticular") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblPercentage" runat="server" Text="Percentage" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <%--    <FooterTemplate>
                                            <asp:TextBox ID="txtPercentage" runat="server" TextMode="MultiLine" Font-Size="12px" Text="" CssClass="form-control" Placeholder="Percentage" Visible="false"></asp:TextBox>
                                        </FooterTemplate>--%>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPercentage1" runat="server" Text='<%# Bind("Percentage") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblAmount" runat="server" Text="Amount" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <%-- <FooterTemplate>
                                            <asp:TextBox ID="txtAmount" runat="server" Text="0" Font-Size="12px" CssClass="form-control" AutoPostBack="true" Placeholder="Amount" Visible="false"></asp:TextBox>
                                        </FooterTemplate>--%>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtAmount1" runat="server" Text='<%# Bind("Amount") %>' Font-Size="12px" CssClass="form-control" Placeholder="Amount" TextMode="Number" Style="width: 150px" Visible="false" ValidationGroup="R"></asp:TextBox>
                                            <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("Amount") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblCatType" runat="server" Text="Catgory Type" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                        </HeaderTemplate>
                                        <%--    <FooterTemplate>
                                            <asp:DropDownList ID="ddlCatType1" runat="server" CssClass="form-control form-select" Font-Size="12px" Placeholder="Select Type" Visible="false">
                                               
                                                <asp:ListItem Text="Addition" Value="Addition" Selected="True"></asp:ListItem>
                                             
                                            </asp:DropDownList>
                                        </FooterTemplate>--%>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCatType" runat="server" Text='<%# Bind("PerticularType") %>' Font-Size="12px" CssClass="form-control" Placeholder="Select Type" TextMode="Number" Style="width: 150px" Visible="false" ValidationGroup="R"></asp:TextBox>
                                            <asp:Label ID="lblCatType1" runat="server" Text='<%# Bind("PerticularType") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="false">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblPartCat" runat="server" Text="Category" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                        </HeaderTemplate>
                                        <%-- <FooterTemplate>
                                            <asp:DropDownList ID="ddlComponentCat1" runat="server" CssClass="form-control" Font-Size="12px" Visible="false">
                                                <asp:ListItem Value="0" Text="Select Type"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Component" Selected="True"></asp:ListItem>
                                               
                                            </asp:DropDownList>
                                        </FooterTemplate>--%>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPertCateID" runat="server" Text='<%# Bind("PertCate_ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                            <asp:TextBox ID="txtPartCat1" runat="server" Text='<%# Bind("PertCategory") %>' Font-Size="12px" CssClass="form-control" Placeholder="Amount" TextMode="Number" Style="width: 150px" Visible="false" ValidationGroup="R"></asp:TextBox>
                                            <asp:Label ID="lblPartCat1" runat="server" Text='<%# Bind("PertCategory") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <%--  <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="btnOption" runat="server" Text="" ValidationGroup="setting"><i class="fas fa-cog"></i></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDeleteComponent" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-rounded btn-danger" ValidationGroup="DelItemTender" Text="" OnClientClick="return confirm('Are you sure you want to delete?')" Visible="false"><i class="ti ti-trash"></i></asp:LinkButton>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="btnAddComponent" runat="server" CssClass="btn btn-sm btn-rounded btn-info" Text="" TabIndex="9" ValidationGroup="ItemTender"><i class="ti ti-check"></i></asp:LinkButton>
                                        </FooterTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <!-- End Grid View Component -->

                        <br />
                        <!-- Compansion Grid View -->
                        <div class="col-md-12 col-sm-12 col-lg-12">

                            <asp:GridView ID="GridViewEmpCompansion" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#f8f9fa" FooterStyle-BackColor="#f8f9fa" HeaderStyle-ForeColor="Blue" HeaderStyle-Font-Bold="true" ShowFooter="true">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblCompnent" runat="server" Text="Compnent" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <%-- <FooterTemplate>
                                         
                                            <asp:TextBox ID="txtCompnents" runat="server" TextMode="MultiLine" Text="" CssClass="form-control" Font-Size="12px" Placeholder="Compnent Name"></asp:TextBox>

                                        </FooterTemplate>--%>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCompnentsID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                            <asp:Label ID="lblEmplyrCobtriPertCatID" runat="server" Text='<%# Bind("PertCate_ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                            <asp:Label ID="lblCompnentsClassID1" runat="server" Text='<%# Bind("ClassID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                            <asp:Label ID="lblCompnentsID1" runat="server" Text='<%# Bind("Perticular") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblPercentages" runat="server" Text="Percentages" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <%--  <FooterTemplate>
                                            <asp:TextBox ID="txtPercentages" runat="server" TextMode="MultiLine" Font-Size="12px" Text="" CssClass="form-control" Placeholder="Percentages"></asp:TextBox>
                                        </FooterTemplate>--%>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPercentages1" runat="server" Text='<%# Bind("Percentage") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblAmounts" runat="server" Text="Amount" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <%-- <FooterTemplate>
                                            <asp:TextBox ID="txtAmounts" runat="server" Text="0" Font-Size="12px" CssClass="form-control" AutoPostBack="true" Placeholder="Amounts"></asp:TextBox>
                                        </FooterTemplate>--%>
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmounts1" runat="server" Text='<%# Bind("Amount") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="false">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblPartCat" runat="server" Text="Category" Font-Size="12px" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <%--  <FooterTemplate>
                                            <asp:DropDownList ID="ddlCompasionCat" runat="server" CssClass="form-control" Font-Size="12px">
                                               
                                                <asp:ListItem Value="2" Text="Employee Contribution"></asp:ListItem>
                                             
                                            </asp:DropDownList>
                                        </FooterTemplate>--%>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPartCat" runat="server" Text='<%# Bind("PertCategory") %>' Font-Size="12px" CssClass="form-control" Placeholder="Amount" TextMode="Number" Style="width: 150px" Visible="false" ValidationGroup="R"></asp:TextBox>
                                            <asp:Label ID="lblPartCat1" runat="server" Text='<%# Bind("PertCategory") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--  <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="btnOption" runat="server" Text="" ValidationGroup="setting"><i class="fas fa-cog"></i></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDeleteComp" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-rounded btn-danger" ValidationGroup="DeleteComp" Text="" OnClientClick="return confirm('Are you sure you want to delete?')" Visible="false"><i class="ti ti-trash"></i></asp:LinkButton>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="btnAddComp" runat="server" CssClass="btn btn-sm btn-rounded btn-info" Text="" TabIndex="9" ValidationGroup="Comp"><i class="ti ti-check"></i></asp:LinkButton>
                                        </FooterTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>



                        </div>
                        <!--  Compansion Grid View -->
                    </div>


                </div>
            </div>
        </div>
    </div>
</asp:Content>
