<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="ViewStaffAttendence.aspx.cs" Inherits="MatoshreeProject.ViewStaffAttendence" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <%-- BreadCrumbs --%>
        <h5 class="font-weight-medium mb-0">Attendance</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="Attendence.aspx">Attendance</li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="ViewStaffAttendence.aspx">Staff Attendance</li>
            </ol>
        </nav>
        <%-- BreadCrumbs --%>
        <%-- Toaster --%>
        <br />
                <div class="row">  
                     <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-lg-6 border-right">
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblUsername" runat="server" Text="UserName" CssClass="form-label"></asp:Label>
                                                        <asp:TextBox ID="txtusername" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblDesignation" runat="server" Text="Designation" CssClass="form-label"></asp:Label>
                                                        <asp:TextBox ID="txtDesignation" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblPhoneNo" runat="server" Text="Phone No" CssClass="form-label"></asp:Label>
                                                        <asp:TextBox ID="txtPhoneNo" CssClass="form-control" runat="server" TextMode="Number" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="mb-2">
                                                        <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                                                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                              </div>
                            </div>
                        </div>
                    </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
                            <div class="card">
                                <div class="card-body">
                                    <h5>View Attendance Details</h5>
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

                                    <asp:GridView ID="GridAttendence" runat="server" ScrollBars="Both" CssClass="table border table-hover table-bordered text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                                        ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridAttendence_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false" HeaderStyle-Font-Size="12px">

                                                <ItemTemplate>
                                                    <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="StaffName" SortExpression="StaffName" HeaderStyle-Font-Size="12px">

                                                <ItemTemplate>
                                                    <asp:Label ID="lblStaffName1" runat="server" Text='<%# Bind("StaffName") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="InTime" SortExpression="InTime" HeaderStyle-Font-Size="12px">

                                                <ItemTemplate>
                                                    <asp:Label ID="lblInTime1" runat="server" Text='<%# Bind("InTime") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="OutTime" SortExpression="Phone" HeaderStyle-Font-Size="12px">

                                                <ItemTemplate>
                                                    <asp:Label ID="lblOutTime1" runat="server" Text='<%# Bind("OutTime") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TotalHr" SortExpression="TotalHr" HeaderStyle-Font-Size="12px">

                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalHr1" runat="server" Text='<%# Bind("TotalHr") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" SortExpression="Status" HeaderStyle-Font-Size="12px" Visible="false">

                                                <ItemTemplate>
                                                    <asp:Label ID="lblStats6" runat="server" Text='<%# Bind("Status") %>' Visible="false"></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="OverTime" SortExpression="OverTime" HeaderStyle-Font-Size="12px">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblOverTime" runat="server" Text='<%# Bind("OverTime") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOverTime1" runat="server" Text='<%# Bind("OverTime") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
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
