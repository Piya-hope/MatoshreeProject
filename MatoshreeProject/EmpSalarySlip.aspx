<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="EmpSalarySlip.aspx.cs" Inherits="MatoshreeProject.EmpSalarySlip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AMatrixLatest/dist/assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="AMatrixLatest/dist/assets/libs/datatables.net-bs5/js/dataTables.bootstrap5.min.js"></script>
    <style type="text/css">
        #leftPanel {
            width: 600px;
            float: left;
            position: relative;
        }

        #rightPanel {
            width: 600px;
            float: right;
            position: relative;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h5 class="card-title">Employee Salary Slip</h5>
        <%-- BreadCrumbs --%>

        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="ViewSalarySlip.aspx">View Salary Slip</li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="EmpSalarySlip.aspx">Employee Salary Slip</li>
            </ol>
        </nav>
        <%-- BreadCrumbs --%>
        <br />


        <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
            <div class="card">
                <div class="card-body">

                    <div class="row">
                        <div class="col-md-4 col-lg-4 col-sm-4 col-xs-4">
                            <asp:Label ID="prtIdnono" runat="server" Text="" CssClass="font-bold text-info" Font-Size="16px" Visible="false"></asp:Label><br />
                            <asp:Label ID="prtIdno2" runat="server" Text="" CssClass="font-bold text-info" Font-Size="16px" Visible="false"></asp:Label><br />

                            <asp:Image ID="Image1" runat="server" Style="display: none; border: 1px solid #ccc" Visible="false" />
                            <asp:Image ID="Image2" runat="server" Style="display: none; border: 1px solid #ccc" Visible="false" />
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
                    <div class="row">
                        <div class="col-md-3 col-sm-3 col-lg-3">
                            <asp:Label ID="lblStaffID" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="lblName1" runat="server" Text="Name:" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-3 col-sm-3 col-lg-3">
                            <asp:Label ID="lblName" runat="server" Text="" CssClass="form-label" Font-Bold="false"></asp:Label>

                        </div>
                        <div class="col-md-3 col-sm-3 col-lg-3">
                            <asp:Label ID="lblDepartment1" runat="server" Text="Department:" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-3 col-sm-3 col-lg-3">
                            <asp:Label ID="lblDepartment" runat="server" Text="" CssClass="form-label" Font-Bold="false"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3 col-sm-3 col-lg-3">
                            <asp:Label ID="lblDesignation1" runat="server" Text="Designation:" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-3 col-sm-3 col-lg-3">
                            <asp:Label ID="lblDesignation" runat="server" Text="" CssClass="form-label" Font-Bold="false"></asp:Label>

                        </div>
                        <div class="col-md-3 col-sm-3 col-lg-3">
                            <asp:Label ID="lblPackage1" runat="server" Text="Package:" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-3 col-sm-3 col-lg-3">
                            <asp:Label ID="lblPackage" runat="server" Text="" CssClass="form-label" Font-Bold="false"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3 col-sm-3 col-lg-3">
                            <asp:Label ID="lblDate1" runat="server" Text="Date:" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-3 col-sm-3 col-lg-3">
                            <asp:Label ID="lblDate" runat="server" Text="" CssClass="form-label" Font-Bold="false"></asp:Label>
                            <asp:Label ID="lblEMPNumber" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                            <asp:Label ID="lblAdharCardNumber" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                            <asp:Label ID="lblBankName" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                            <asp:Label ID="lblBankAccNumber" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                            <asp:Label ID="lblPFNumber" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                            <asp:Label ID="lblUAN" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                            <asp:Label ID="lblDOJ" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                            <asp:Label ID="lblDOB" runat="server" Text="" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
            <div class="card">
                <div class="card-body">
                    <div class="table-responsive">
                        <table style="width: 100%" class="table table-responsive table-responsive-sm table-responsive-md table-responsive-lg">
                            <tr>
                                <td>

                                    <asp:GridView ID="GridViewComponent" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%" Height="400px" HeaderStyle-Height="30px" FooterStyle-Height="30px"
                                        ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#68c5f0" FooterStyle-BackColor="#68c5f0" HeaderStyle-ForeColor="Blue" FooterStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" ShowFooter="true" OnRowDataBound="GridViewComponent_RowDataBound" DataKeyNames="StaffID">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblCompnent" runat="server" Text="Compnent" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("StaffID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblComponentID" runat="server" Text='<%# Bind("PertCate_ID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblCompnent1" runat="server" Text='<%# Bind("Category") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblCompnent2" runat="server" Text="Total-A" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblPercentage" runat="server" Text="Percentage" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <asp:Label ID="lblPercentage1" runat="server" Text='<%# Bind("Percentage") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblPercentage2" runat="server" Text="" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblAmount" runat="server" Text="Monthly Amount" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtAmount1" runat="server" Text='<%# Bind("MonthlyAmount") %>' Font-Size="12px" CssClass="form-control" Placeholder="Monthly Amount" TextMode="Number" Style="width: 150px" Visible="false" ValidationGroup="R"></asp:TextBox>
                                                    <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("MonthlyAmount") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblAmount2" runat="server" Text="" ForeColor="Black" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>

                                </td>
                                <td>

                                    <asp:GridView ID="GridViewEmpCompansion" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover table-responsive" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%" Height="400px" HeaderStyle-Height="30px" FooterStyle-Height="30px"
                                        ClientIDMode="Static" Font-Bold="false" HeaderStyle-BackColor="#68c5f0" FooterStyle-BackColor="#68c5f0" HeaderStyle-ForeColor="Blue" FooterStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" FooterStyle-Font-Bold="true" ShowFooter="true" OnRowDataBound="GridViewEmpCompansion_RowDataBound" DataKeyName="DStaffID">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblCompnent" runat="server" Text="Compnent" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("DStaffID") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblComponentsID1" runat="server" Text='<%# Bind("DpertCate") %>' Font-Bold="true" Font-Size="12px" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblCompnents1" runat="server" Text='<%# Bind("Dcategory") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblCompnents2" runat="server" Text="Total-B" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblPercentages" runat="server" Text="Percentages" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <asp:Label ID="lblPercentages1" runat="server" Text='<%# Bind("Dpercentage") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>

                                                <FooterTemplate>
                                                    <asp:Label ID="lblPercentages2" runat="server" Text="" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                                </FooterTemplate>

                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblAmounts" runat="server" Text="Monthly Amount" Font-Size="12px" Font-Bold="true"></asp:Label>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmounts1" runat="server" Text='<%# Bind("DannualAmount") %>' Font-Bold="false" Font-Size="12px" Visible="true"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblAmounts2" runat="server" Text="" ForeColor="Black" Font-Size="12px" Font-Bold="true" Visible="true"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>

                                            <%--<asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblMonthlyAmounts" runat="server" Text="Annual Amount" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <asp:Label ID="lblMonthlyAmounts1" runat="server" Text='<%# Bind("DmonthlyAmount") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblMonthlyAmounts2" runat="server" Text="" Font-Size="12px" Font-Bold="true" Visible="false"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>
                                    </asp:GridView>

                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>



        <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
            <div class="card">
                <div class="card-body">
                    <div id="Div1">
                        <table class="table table-bordered table-hover table-responsive" style="width: 100%;">
                            <thead style="background-color: #f8f9fa;">
                                <tr>
                                    <th style="display: none;">
                                        <label style="font-weight: normal; font-size: 12px;">1</label>
                                    </th>
                                    <th>
                                        <label style="font-weight: normal; font-size: 12px;">Net Salary (A-B)</label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lblNetSalary" runat="server" Text="" Font-Bold="true" Font-Size="12px"></asp:Label>
                                    </th>
                                </tr>
                            </thead>

                        </table>
                    </div>

                    <div class="text-center">
                        <asp:LinkButton ID="linkbtnPDFSalarySlip" runat="server" Text="PDF" CssClass="btn btn-sm btn-primary" OnClick="linkbtnPDFSalarySlip_Click"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>



    </div>
</asp:Content>
