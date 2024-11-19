<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="AddCareer.aspx.cs" Inherits="MatoshreeProject.AddCareer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 col-sm-8 col-xl-8 col-lg-8">
                <h5 class="font-weight-medium mb-0">Add Career</h5>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                            </a>
                        </li>
                        <li class="breadcrumb-item">
                            <a class="text-muted text-decoration-none" href="career.aspx">Career
                            </a>
                        </li>
                        <li class="breadcrumb-item text-muted" aria-current="page" href="AddCareer.aspx">Add Career</li>
                    </ol>
                </nav>
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
        <div class="row">
           
            <div class="col-md-12 col-sm-12 col-lg-12">

                <div class="card">
                    <div class="card-body">
                        <h5>View Career</h5>
                        <hr />

                        <div class="row">
                            <div class="col-md-4 col-sm-4 col-lg-4">
                                <div class="mb-2">
                                    <asp:Label ID="lblFirstName" runat="server" Text="FirstName" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="Enter First Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtFirstName" ErrorMessage="Enter First Name" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                              <div class="col-md-4 col-sm-4 col-lg-4">
                                <div class="mb-2">
                                    <asp:Label ID="lblMiddleNm" runat="server" Text="MiddleName" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtMiddleNm" runat="server" CssClass="form-control" placeholder="Enter Middle Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtMiddleNm" ErrorMessage="Enter Middle Name" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                              <div class="col-md-4 col-sm-4 col-lg-4">
                                <div class="mb-2">
                                    <asp:Label ID="lblLastNm" for="Phone" runat="server" Text="LastName" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtLastNm" runat="server" name="phone" CssClass="form-control" placeholder="Enter Last Name" MaxLength="10" TextMode="Phone"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_Phone" runat="server" Display="Dynamic" ControlToValidate="txtLastNm" ErrorMessage="Enter Last Name" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                        </div>

                         <div class="row">
                                        <div class="col-md-6 col-sm-6 col-lg-6">
                                             <div class="mb-2">
                                                <asp:Label ID="lblEmail" for="Phone" runat="server" Text="Email" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                <asp:TextBox ID="txtEmail" runat="server" name="email" CssClass="form-control" placeholder="Enter Email Address"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rvfEmail" runat="server" Display="Dynamic" ControlToValidate="txtEmail" ErrorMessage="Enter Email Address" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="Regulexemail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Address Invalid." ForeColor="Red" ValidationGroup="SaveValidate" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" Font-Size="12px"></asp:RegularExpressionValidator>

                                            </div>
                                        </div>
                                        <div class="col-md-6 col-sm-6 col-lg-6">
                                           <div class="mb-2">
                                                <asp:Label ID="lblPhone" for="Phone" runat="server" Text="Phone" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                                <asp:TextBox ID="txtPhone" runat="server" name="phone" CssClass="form-control" placeholder="Enter Phone Number" MaxLength="10" TextMode="Phone"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtPhone" ErrorMessage="Enter 10 digit Phone Number" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="Regulexphone" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone Number Invalid." ForeColor="Red" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                    </div>

                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblCurrentLoc" runat="server" Text="Current Location" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtCurrentLoc" runat="server" CssClass="form-control" placeholder="Enter Current Location"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtCurrentLoc" ErrorMessage="Enter Current Location" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblExperience" for="Experience" runat="server" Text="Year of Experience" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtExperience" runat="server" name="phone" CssClass="form-control" placeholder="Enter Year of  Experience" MaxLength="10" TextMode="Phone"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="txtExperience" ErrorMessage="Enter Year of  Experience" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                        </div>

                          <div class="row">
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblQualification" runat="server" Text="Qualification" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtQualification" runat="server" CssClass="form-control" placeholder="Enter Qualification"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtQualification" ErrorMessage="Enter Qualification" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblPostApplied" for="Employer" runat="server" Text="Post Applied" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtPostApplied" runat="server" name="phone" CssClass="form-control" placeholder="Enter Post Applied" MaxLength="10" TextMode="Phone"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ControlToValidate="txtPostApplied" ErrorMessage="Enter Post Applied" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                        </div>

                          <div class="row">
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblEmployeement" runat="server" Text="What is your Current Employeement Status?" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtEmployeement" runat="server" CssClass="form-control" placeholder="Enter Current Employeement"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="txtEmployeement" ErrorMessage="Enter Current Employeement" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                          <%--  <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="mb-2">
                                    <asp:Label ID="lblEmployer" for="Employer" runat="server" Text="Current Employer" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                    <asp:TextBox ID="txtEmployer" runat="server" name="phone" CssClass="form-control" placeholder="Enter Current Employer" MaxLength="10" TextMode="Phone"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ControlToValidate="txtEmployer" ErrorMessage="Enter Current Employer" ForeColor="Red" ValidationGroup="SaveValidate" Font-Size="12px"></asp:RequiredFieldValidator>
                                </div>
                            </div>--%>
                               <div class="col-md-6 col-sm-6 col-lg-6">
                              <div class="mb-2">
                                        <asp:Label ID="lblAttachment" runat="server" Text="Attach Your Resume" CssClass="form-label"></asp:Label>&nbsp;<span style="color: #FF0000">*</span>
                                        <div class="input-group">
                                            <asp:FileUpload ID="FileUpload" runat="server" Text="" CssClass="form-control" />
                                        
                                            <%--<asp:Button ID="Btn_Upload" runat="server" CssClass="form-control-file" OnClick="Btn_Upload_Click" ValidationGroup="SaveValidate" />--%>
                                            </div>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="FileUpload" ErrorMessage="Attach Your Resume To upload"  ForeColor="Red" InitialValue="" Display="Dynamic" ValidationGroup="SaveValidate" Font-Size="12px" />

                                    </div>
                                   </div>
                        </div>
                       <%--  <div class="row">
                                 <asp:FileUpload ID="FileUploadControl" runat="server" CssClass="form-control" />
                         </div>--%>
                     
                     <br />
                        <center>
                             <div class="mb-2">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="SaveValidate" OnClick="btnSave_Click"/>
                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-sm btn-danger" ValidationGroup="Validateclear" OnClick="btnClear_Click" />
                               
                        </div>
                        </center>
                       
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
