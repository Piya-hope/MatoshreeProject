<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="MatoshreeProject.EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h5 class="font-weight-medium mb-0">Edit Profile</h5>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a class="text-muted text-decoration-none" href="Dashboard.aspx">Dashboard
                    </a>
                </li>
                <li class="breadcrumb-item text-muted" aria-current="page" href="EditProfile.aspx">Edit Profile</li>
            </ol>
        </nav>
        <br />
        <div class="row">
            <div class="col-md-7">
                <asp:Label ID="lblProfileName" runat="server" Text="Dynamic User Name" CssClass="form-label"></asp:Label>

                <!-- Profile Form Card -->
                <div class="card mt-2">
                    <div class="card-body">
                        <div class="mb-2">
                            <asp:Label ID="lblProfileImg" runat="server" Text="Profile Image" CssClass="form-label"></asp:Label>
                            <div class="input-group">
                                <asp:FileUpload ID="FileUpload1" runat="server" name="fileupload" class="form-control" />
                                <asp:Button ID="btnImgUpload" runat="server" Text="Upload" CssClass="btn btn-sm btn-primary" OnClick="btnImgUpload_Click" />
                            </div>
                            <br />

                            <asp:Image ID="Image1" runat="server" Height="100" Width="233" Visible="false" />
                        </div>
                        <div class="mb-2">
                            <asp:Label ID="lbl_First_Name" runat="server" Text="First Name" CssClass="form-label"></asp:Label>&nbsp;<span style="color: red;">*</span>
                            <asp:TextBox ID="txt_First_Name" runat="server" Placeholder=" Enter First Name" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Subject_RequiredFieldValidator" runat="server" ErrorMessage=" Enter First Name" Display="Dynamic" ControlToValidate="txt_First_Name" ForeColor="Red" ValidationGroup="Save" Font-Size="12px"></asp:RequiredFieldValidator>
                        </div>
                        <div class="mb-2">
                            <asp:Label ID="lbl_Last_Name" runat="server" Text="Last Name" CssClass="form-label">
                            </asp:Label>&nbsp;<span style="color: red;">*</span>
                            <asp:TextBox ID="txt_Last_Name" runat="server" Placeholder=" Enter Last Name" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Related_RequiredFieldValidator" runat="server" ErrorMessage=" Enter Last Name" Display="Dynamic" ControlToValidate="txt_Last_Name" ForeColor="Red" ValidationGroup="Save" Font-Size="12px"></asp:RequiredFieldValidator>
                        </div>
                        <div class="mb-2">
                            <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="form-label">
                            </asp:Label>&nbsp;<span style="color: red;">*</span>
                            <asp:TextBox ID="txt_Email" runat="server" Placeholder="Enter Email" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" Enter Email" Display="Dynamic" ControlToValidate="txt_Email" ForeColor="Red" ValidationGroup="Save" Font-Size="12px"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Email Address" ControlToValidate="txt_Email" Display="Dynamic" ForeColor="Red" ValidationGroup="Save" ValidationExpression="^\S+@\S+$" Font-Size="12px"></asp:RegularExpressionValidator>
                        </div>
                        <div class="mb-2">
                            <asp:Label ID="lblPhone" runat="server" Text="Phone" CssClass="form-label">
                            </asp:Label>&nbsp;<span style="color: red;">*</span>
                            <asp:TextBox ID="txt_Phone" runat="server" Placeholder=" Enter Phone Number" CssClass="form-control" MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_Phone" runat="server" Display="Dynamic" ControlToValidate="txt_Phone" ErrorMessage="Enter 10 digit Phone Number" ForeColor="Red" ValidationGroup="Save" Font-Size="12px"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="Regulexphone" runat="server" ControlToValidate="txt_Phone" ErrorMessage="Phone Number Invalid" ForeColor="Red" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$" ValidationGroup="Save" Font-Size="12px"></asp:RegularExpressionValidator>
                        </div>
                        <div class="mb-2">
                            <asp:Label ID="lblLanguage" runat="server" Text="Default Language" CssClass="form-label"></asp:Label>
                            <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="form-control form-select">
                                <asp:ListItem>System Default</asp:ListItem>
                                <asp:ListItem>English</asp:ListItem>
                                <asp:ListItem>Hindi</asp:ListItem>
                                <asp:ListItem>Marathi</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="mb-2">
                            <asp:Label ID="lblDirection" runat="server" Text="Direction" CssClass="form-label"></asp:Label>
                            <asp:DropDownList ID="ddlDirection" runat="server" CssClass="form-control form-select">
                                <asp:ListItem>System Default</asp:ListItem>
                                <asp:ListItem>LTR</asp:ListItem>
                                <asp:ListItem>RTL</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="mb-2">
                            <iconify-icon icon="jam:facebook-square"></iconify-icon>
                            <asp:Label ID="lblFacebook" runat="server" Text="Facebook" CssClass="form-label">
                            </asp:Label>
                            <asp:TextBox ID="txt_Facebook" runat="server" Placeholder="Facebook" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-2">
                            <iconify-icon icon="bi:linkedin"></iconify-icon>
                            <asp:Label ID="lblLinkedIn" runat="server" Text="LinkedIn" CssClass="form-label">
                            </asp:Label>
                            <asp:TextBox ID="txt_LinkedIn" runat="server" Placeholder="LinkedIn" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-2">
                            <iconify-icon icon="teenyicons:skype-outline"></iconify-icon>
                            <asp:Label ID="lblSkype" runat="server" Text="Skype" CssClass="form-label">
                            </asp:Label>
                            <asp:TextBox ID="txt_Skype" runat="server" Placeholder="Skype" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-2">
                            <iconify-icon icon="bi:question-circle" data-toggle="tooltip" data-title="If empty default email signature from settings will be used" data-original-title="" title=""></iconify-icon>
                            <asp:Label ID="lblEmailSignature" runat="server" Text="Email Signature"  CssClass="form-label">
                            </asp:Label>
                            <asp:TextBox ID="txt_Email_Signature" runat="server" TextMode="MultiLine" Placeholder="Email Signature" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-2">
                            <asp:Button ID="btnEditProfile" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="Save" OnClick="btnEditProfile_Click" />

                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-5">
                <asp:Label ID="lblChangePassword" runat="server" Text="Change your password" CssClass="form-label"></asp:Label>
                <!-- Password Details Card -->
                <div class="card mt-2">
                    <div class="card-body">
                        <div class="mb-2">
                            <asp:Label ID="lblOldPassword" runat="server" Text="Old Password" CssClass="form-label"></asp:Label>&nbsp;<span style="color: red;">*</span>
                            <div class="input-group">
                                <asp:TextBox ID="txt_OldPassword" runat="server" CssClass="form-control" aria-describedby="basic-addon2 basic-addon3" ReadOnly="true">
                                </asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="reqOldPassword" runat="server" ControlToValidate="txt_OldPassword" ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Password." ValidationGroup="SavePassword" />
                        </div>
                        <div class="mb-2">
                            <asp:Label ID="lblNewPassword" runat="server" Text="New Password" CssClass="form-label"></asp:Label>&nbsp;<span style="color: red;">*</span>
                            <div class="input-group">
                                <asp:TextBox ID="txt_NewPassword" runat="server" CssClass="form-control" aria-describedby="basic-addon2 basic-addon3">
                                </asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_NewPassword" ForeColor="Red" Display="Dynamic" ErrorMessage="Enter New Password." ValidationGroup="SavePassword" />
                        </div>
                        <div class="mb-2">
                            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password" CssClass="form-label"></asp:Label>
                            <div class="input-group">
                                <asp:TextBox ID="txt_ConfirmPassword" runat="server" CssClass="form-control" aria-describedby="basic-addon2 basic-addon3">
                                </asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_ConfirmPassword" ForeColor="Red" Display="Dynamic" ErrorMessage="Enter Confirm Password." ValidationGroup="SavePassword" />
                            <br />
                            <asp:CompareValidator ID="CompareValidaConfirmPassword" runat="server" ControlToCompare="txt_NewPassword" ControlToValidate="txt_ConfirmPassword" ErrorMessage="Password does not match." ForeColor="Red" Font-Bold="false" ValidationGroup="SavePassword" Font-Size="12px"></asp:CompareValidator>


                        </div>
                        <div class="mb-2">
                            <asp:Button ID="btnChnagePassword" runat="server" Text="Save" CssClass="btn btn-sm btn-primary" ValidationGroup="SavePassword" OnClick="btnChnagePassword_Click" />

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
