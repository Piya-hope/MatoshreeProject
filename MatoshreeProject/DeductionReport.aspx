<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="DeductionReport.aspx.cs" Inherits="MatoshreeProject.DeductionReport" EnableEventValidation="false"%>

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
     <script type="text/javascript">
         $(document).ready(function () {
             var GridDeductionReport = $("#GridDeductionReport").prepend($("<thead></thead>").append($("#GridDeductionReport").find("tr:first"))).DataTable(
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
        <h5 class="card-title">Deduction Report</h5>
        <br />
       <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                     
                        <div class="row">
                             <div class="col-md-2 col-sm-2 col-lg-2">
                             <asp:Label ID="lblContribution" Text="Contribution" runat="server"  CssClass="form-label">
                               </asp:Label>
                            </div>

                            <div class="col-md-4 col-sm-4 col-lg-4">
                                <asp:DropDownList ID="ddlContribution" CssClass="form-control form-select" runat="server" OnSelectedIndexChanged="ddlContribution_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem>Select Contribution</asp:ListItem>
                                    <asp:ListItem Text="Employee" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Employeer" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:Label ID="lblDeduction" Text="Deduction" runat="server"  CssClass="form-label"></asp:Label><br />

                            </div>
                            <div class="col-md-4 col-sm-4 col-lg-4">
                                <asp:DropDownList ID="ddlDeduction" CssClass="form-control form-select" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                           
                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:Label ID="lbldate" Text="Date" runat="server"  CssClass="form-label"></asp:Label>
                            </div>
                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:DropDownList ID="ddlMonth" runat="server" class="form-control">
                                    <asp:ListItem>Select Month</asp:ListItem>
                                    <asp:ListItem>January</asp:ListItem>
                                    <asp:ListItem>February</asp:ListItem>
                                    <asp:ListItem>March</asp:ListItem>
                                    <asp:ListItem>April</asp:ListItem>
                                    <asp:ListItem>May</asp:ListItem>
                                    <asp:ListItem>June</asp:ListItem>
                                    <asp:ListItem>July</asp:ListItem>
                                    <asp:ListItem>August</asp:ListItem>
                                    <asp:ListItem>September</asp:ListItem>
                                    <asp:ListItem>October</asp:ListItem>
                                    <asp:ListItem>November</asp:ListItem>
                                    <asp:ListItem>December</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                            <div class="col-md-2 col-sm-2 col-lg-2">
                                <asp:TextBox ID="txtYear" runat="server" CssClass="form-control" placeholder="Enter Year"></asp:TextBox>
                            </div>
                        </div>

                        <br />
                        <div class="row">
                            <div class="col-md-4 col-sm-4 col-lg-4"></div>

                             <div class="col-md-1 col-sm-1 col-lg-1">
                                <asp:Button ID="btnSearchReport" runat="server" Text="View Report" CssClass="btn btn-primary btn-sm" OnClick="btnSearchReport_Click" /> 
                            </div>
                          &nbsp; &nbsp; &nbsp; &nbsp;
                                    <div class="col-md-1 col-sm-1 col-lg-1"">
                                        <div class="bd-example">
                                            <div class="btn-group">
                                                <button class="btn btn-sm btn-success dropdown-toggle w-85" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Export</button>
                                                <asp:Button ID="btnmore" runat="server" Style="display: none" />
                                                <div class="dropdown-menu">
                                                    <asp:LinkButton ID="lnkbtnExcel" Text="Excel" runat="server" CssClass="dropdown-item" OnClick="lnkbtnExcel_Click"></asp:LinkButton>
                                                    <asp:LinkButton ID="linkbtnPDF" runat="server" Text="PDF" CssClass="dropdown-item" OnClick="linkbtnPDF_Click"></asp:LinkButton>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                  <div class="col-md-1 col-sm-1 col-lg-1"">
                                 <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-danger btn-sm" OnClick="btnClear_Click" />
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
                   </div>
          </div>
                </div>
      </div>
       <div class="row">
            <div class="col-md-12 col-sm-12 col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <h5>View Deduction Report</h5>
                        <hr />
                        <asp:GridView ID="GridDeductionReport" runat="server" ScrollBars="Both" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                            ClientIDMode="Static" EmptyDataText="No Records found" DataKeyNames="ID" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false">
                            <Columns>

                                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100"  HeaderStyle-Font-Size="12px" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px"/>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-Font-Size="12px" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="EMPID" SortExpression="EMP_ID" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px" Visible="false">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblEMPID" runat="server" Text='<%# Bind("StaffID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEMPID1" runat="server" Text='<%# Bind("StaffID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px" Visible="false"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                

                                <asp:TemplateField HeaderText="EMPName" SortExpression="EMP_Name" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblEMPName" runat="server" Text='<%# Bind("First_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEMPName1" runat="server" Text='<%# Bind("First_Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="EMPID" SortExpression="EMP_ID" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                <EditItemTemplate>
                                <asp:Label ID="lblEMPNumber" runat="server" Text='<%# Bind("EMPNumber") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                <asp:Label ID="lblEMPNumber1" runat="server" Text='<%# Bind("EMPNumber") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ReferenceID" SortExpression="Reference_ID" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                <EditItemTemplate>
                                <asp:Label ID="lblReferenceID" runat="server" Text='<%# Bind("ReferenceID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                <asp:Label ID="lblReferenceID1" runat="server" Text='<%# Bind("ReferenceID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>

                                </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="PFNumber" SortExpression="PF_Number" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                 <EditItemTemplate>
                                 <asp:Label ID="lblPFNumber" runat="server" Text='<%# Bind("EPFID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                 <asp:Label ID="lblPFNumber1" runat="server" Text='<%# Bind("EPFID") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                 </ItemTemplate>
                                 </asp:TemplateField>

                                <asp:TemplateField HeaderText="Amount" SortExpression="Amount" HeaderStyle-Width="90px" HeaderStyle-Font-Size="12px">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("EPFAMT") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount1" runat="server" Text='<%# Bind("EPFAMT") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
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
