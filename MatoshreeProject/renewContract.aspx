<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="renewContract.aspx.cs" Inherits="MatoshreeProject.renewContract" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
           <h5 class="font-weight-medium mb-0">Renew Contract</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="#">Contract
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="renewContract.aspx">Renew Contract</li>
            </ol>
        </nav>
        <br />
        <div class="row">
            <div class="col-md-6 col-lg-6 col-sm-6 col-xs-6">
                <div class="card">
                    <div class="card-body">
                        
                        <div class="row">
                             <div class="mb-2">
                      
                         <asp:Label ID="lblContractRenewID" runat="server"  Visible="false"  Text=""></asp:Label>
                        </div>
                            <div class="col-md-6 col-sm-6 col-lg-6">
                            <div class="mb-2">
                                <asp:Label ID="lblOldStartDate" runat="server" Text="Old Start Date" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                <asp:TextBox ID="txtOldStartDate"  CssClass="form-control"  runat="server" placeholder="Enter Old Start Date" ReadOnly="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredOldStartDate" runat="server" ErrorMessage="Enter Old Start Date" ControlToValidate="txtOldStartDate" ForeColor="Red" Font-Bold="false" ValidationGroup="Save"  Font-Size="12px"></asp:RequiredFieldValidator>
                            </div>
                                </div>
                             <div class="col-md-6 col-sm-6 col-lg-6">
                            <div class="mb-2">
                                <asp:Label ID="lblNewStartDate" runat="server" Text="New Start Date" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                <asp:TextBox ID="txtNewStartDate"  CssClass="form-control" runat="server" placeholder="Enter New Start Date" type="date" Style="display: inline-block;" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredNewStartDate" runat="server" ErrorMessage="Enter New Start Date" ControlToValidate="txtNewStartDate" ForeColor="Red" Font-Bold="false" ValidationGroup="Save"  Font-Size="12px"></asp:RequiredFieldValidator>
                            </div>
                            </div>
                            </div>
                         <div class="row">
                             <div class="col-md-6 col-sm-6 col-lg-6">
                            <div class="mb-2">
                                <asp:Label ID="lblOldEndDate" runat="server" Text="Old End Date" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtOldEndDate"  CssClass="form-control" runat="server" placeholder="Enter Old End Date" ReadOnly="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredOldEndDate" runat="server" ErrorMessage="Enter Old End Date" ControlToValidate="txtOldEndDate" ForeColor="Red" Font-Bold="false" ValidationGroup="Save"  Font-Size="12px"></asp:RequiredFieldValidator>
                            </div>
                                 </div>
                             <div class="col-md-6 col-sm-6 col-lg-6">
                               <div class="mb-2">
                                <asp:Label ID="lblNewEndDate" runat="server" Text="New End Date" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtNewEndDate" type="date" CssClass="form-control" Style="display: inline-block;" runat="server" placeholder="Enter New End Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredNewEndDate" runat="server" ErrorMessage="Enter New End Date" ControlToValidate="txtNewEndDate" ForeColor="Red" Font-Bold="false" ValidationGroup="Save"  Font-Size="12px"></asp:RequiredFieldValidator>
                            </div>
                                 </div>
                             </div>
                         <div class="row">
                         
                               <div class="col-md-6 col-sm-6 col-lg-6">
                            <div class="input-group">
                                <asp:Label ID="lblOldContractValue" runat="server" Text="Old Contract Value" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtOldContractValue" runat="server" placeholder="Old Contract Value" type="number" name="hourly_rate" value="0" class="form-control" aria-invalid="false" Style="width: 132%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredOldContractValue" runat="server" ErrorMessage="Enter Old Contract Value" ControlToValidate="txtOldContractValue" ForeColor="Red" Font-Bold="false" ValidationGroup="Save"  Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                                   </div>
                               <div class="col-md-6 col-sm-6 col-lg-6">
                                 <div class="input-group">
                                <asp:Label ID="lblNewContractValue" runat="server" Text="New Contract Value" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtNewContractValue" runat="server" placeholder="New Contract Value" type="number" name="hourly_rate" value="0" class="form-control" aria-invalid="false" Style="width: 132%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredNewContractValue" runat="server" ErrorMessage="Enter New Contract Value" ControlToValidate="txtNewContractValue" ForeColor="Red" Font-Bold="false" ValidationGroup="Save"  Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                        </div>
                        </div>

                        

                             </div>
                        <div class="mb-2">
                              <asp:Button ID="btnRenewSaveContract" runat="server" Text="Save" CssClass="btn btn-primary" ValidationGroup="Save" OnClick="btnRenewSaveContract_Click"/>
                              <asp:Button ID="btnCloseContract" runat="server" Text="Close" CssClass="btn btn-danger" OnClick="btnCloseContract_Click1"/>
                         </div>
                          </div>
                    </div>
                </div>
            </div>
        
    
</asp:Content>
