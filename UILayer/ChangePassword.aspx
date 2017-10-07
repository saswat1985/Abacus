<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="full-width">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        Enter New Password :
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="txtBox" TextMode="Password"
                            MaxLength="8"></asp:TextBox><asp:RequiredFieldValidator ID="fvtxtPassword" runat="server"
                                ErrorMessage="Please Enter New Passowrd" ControlToValidate="txtPassword" SetFocusOnError="true"
                                ValidationGroup="ResetPassword"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Confirm New Password :
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="txtBox" TextMode="Password"
                            MaxLength="8"></asp:TextBox><asp:RequiredFieldValidator ID="fvtxtConfirmPassword" runat="server"
                                ErrorMessage="Please Enter Confirm Passowrd" ControlToValidate="txtConfirmPassword" SetFocusOnError="true"
                                ValidationGroup="ResetPassword"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnChangePwd" runat="server" Text="Change My Password" CssClass="button blue"
                            OnClick="btnChangePwd_Click" ValidationGroup="ResetPassword" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="button blue" OnClick="btnReset_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
