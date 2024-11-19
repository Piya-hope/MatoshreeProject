<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="LeaveManagementApproval.aspx.cs" Inherits="MatoshreeProject.LeaveManagementApproval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="container-fluid">
       <%-- BreadCrumbs --%>
       <h5 class="font-weight-medium mb-0">Leave Management Approval</h5>
       <nav aria-label="breadcrumb">
           <ol class="breadcrumb">
               <li class="breadcrumb-item">
                   <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                   </a>
               </li>
                <li class="breadcrumb-item text-muted" href="#">HRMS</li>
               <li class="breadcrumb-item text-muted" aria-current="page" href="LeaveManagementApproval.aspx">Leave Management Approval</li>
             
           </ol>
       </nav>
       <%-- BreadCrumbs --%>

       <%-- Toaster --%>
       <div class="row">
           <div class="col-md-12 col-sm-12 col-xl-12 col-lg-12">
               <br />
               <div class="row">
                
                   <%-- Toaster --%>
                   <div class="col-md-4 col-sm-4 col-xl-4 col-lg-4">
                       <div id="Toasteralert" runat="server" visible="false" >
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
                       <h5 class="font-weight-medium mt-3 mb-3">View Leave Approval Details</h5>
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

                   
                    <asp:GridView ID="GridLeaveManagementApproval" runat="server" ScrollBars="Both" CssClass="table border table-hover table-bordered text-nowrap align-content-center" AutoGenerateColumns="false" CellPadding="4" Style="width: 100%"
                        ClientIDMode="Static" EmptyDataText="No Records found" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center" Font-Bold="false" DataKeyNames="ID" OnRowDataBound="GridLeaveManagementApproval_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="ID" HeaderStyle-Font-Size="12px">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" Font-Size="12px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false" HeaderStyle-Font-Size="12px">
                                <EditItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblID1" runat="server" Text='<%# Bind("ID") %>' Font-Bold="false" Font-Size="12px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="StaffName" SortExpression="Name" HeaderStyle-Font-Size="12px">
                                <EditItemTemplate>
                                    <asp:Label ID="lblStaffName" runat="server" Text='<%# Bind("Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblStaffName1" runat="server" Text='<%# Bind("Name") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
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
                            <asp:TemplateField HeaderText="StartDate" SortExpression="StartDate" HeaderStyle-Font-Size="12px">
                                <EditItemTemplate>
                                    <asp:Label ID="lblStartDate" runat="server" Text='<%# Bind("StartDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblStartDate1" runat="server" Text='<%# Bind("StartDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EndDate" SortExpression="EndDate" HeaderStyle-Font-Size="12px">
                                <EditItemTemplate>
                                    <asp:Label ID="lblEndDate" runat="server" Text='<%# Bind("EndDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEndDate1" runat="server" Text='<%# Bind("EndDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="LeaveType" SortExpression="LeaveType" HeaderStyle-Font-Size="12px">
                                <EditItemTemplate>
                                    <asp:Label ID="lblLeaveType" runat="server" Text='<%# Bind("LeaveType") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblLeaveType1" runat="server" Text='<%# Bind("LeaveType") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reason" SortExpression="Reason" HeaderStyle-Font-Size="12px">
                                <EditItemTemplate>
                                    <asp:Label ID="lblReason" runat="server" Text='<%# Bind("Reason") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblReason1" runat="server" Text='<%# Bind("Reason") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RaisedDate" SortExpression="RaisedDate" HeaderStyle-Font-Size="12px">
                                <EditItemTemplate>
                                    <asp:Label ID="lblRaisedDate" runat="server" Text='<%# Bind("RaisedDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblRaisedDate1" runat="server" Text='<%# Bind("RaisedDate","{0:dd/MM/yyyy}") %>' TabIndex="6" Font-Bold="false" Font-Size="12px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  SortExpression="Status" Visible="false">
                                <EditItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status") %>'  Visible="false" Font-Bold="false"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus1" runat="server" Text='<%#Bind("Status") %>' Font-Bold="false" Visible="false" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        
                            <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnViewLeaveMangement" runat="server" OnClick="btnViewLeaveMangement_Click1" CssClass="btn btn-sm btn-outline-info "><i class="ti ti-eye"></i></asp:LinkButton>
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


</asp:Content>
